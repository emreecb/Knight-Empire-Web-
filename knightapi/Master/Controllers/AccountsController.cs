using Master.Helpers;
using Master.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Master.Models;
using System.Text.Encodings.Web;
using Master.Model;
using Master.Infrastructure;

namespace Master.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {

        private readonly MasterContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private ICharacterDetailsRepository _characterDetailsRepository;
        private IMoneyRepository _moneyRepository;

        public AccountsController(UserManager<AppUser> userManager, IMoneyRepository moneyRepository, ICharacterDetailsRepository CharacterDetailsRepository, IMapper mapper, MasterContext appDbContext, IEmailSender emailSender, ILoggerFactory loggerFactory)
        {
            _emailSender = emailSender;
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
            _logger = loggerFactory.CreateLogger<AccountsController>();
            _characterDetailsRepository = CharacterDetailsRepository;
            _moneyRepository = moneyRepository;
        }

        // POST api/accounts
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<AppUser>(model);

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            await _appDbContext.CharacterDetails.AddAsync(new CharacterDetails
            {
                IdentityId = userIdentity.Id,
                Nickname = model.NickName,
                Nation = model.Nation,
                CharacterLevel = 1,
                Experience = 0,
                NationalPoint = 100,
                Health = 100,
                Mana = 100
            });
            await _appDbContext.SaveChangesAsync();
            Money money = new Money();
            var character = _characterDetailsRepository.Get(x => x.IdentityId == userIdentity.Id);
            money.CharacterDetailsId = character.Id;
            money.Coin = 50;
            money.KnightPoint = 10;
            _moneyRepository.Update(money);

            var user = await _userManager.FindByIdAsync(userIdentity.Id);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = user.Id, code = code },
                protocol: Request.Scheme);

            var callUrl = "http://knightfront.turgutyazici.com/confirm?" + "userId=" + user.Id + "&code=" + code;

            await _emailSender.SendEmailAsync(model.Email, "Hesabınızı aktifleştirin", $"Lütfen Linke tıklayarak hesabınızı aktifleştirin: <a href='" + callUrl + "'>link</a>");

            return new OkObjectResult("Hesap oluşturuldu");
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return BadRequest("Error");
            }
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return BadRequest("Error");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
