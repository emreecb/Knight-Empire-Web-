using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Master.Auth;
using Master.Helpers;
using Master.Model;
using Master.Models;
using Master.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Master.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly IEmailSender _emailSender;
        private readonly JwtIssuerOptions _jwtOptions;

        public AuthController(UserManager<AppUser> userManager, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions, IEmailSender emailSender)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _emailSender = emailSender;
            _jwtOptions = jwtOptions.Value;
        }

        // POST api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]CredentialsViewModel credentials)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identity = await GetClaimsIdentity(credentials.UserName, credentials.Password);
            if (identity == null)
            {
                return BadRequest(Errors.AddErrorToModelState("login_failure", "Hatalı kullanıcı adı veya şifre", ModelState));
            }

            var jwt = await Tokens.GenerateJwt(identity, _jwtFactory, credentials.UserName, _jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });
            return new OkObjectResult(jwt);
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);

            var userToVerify = await _userManager.FindByNameAsync(userName);

            if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);

            if (await _userManager.CheckPasswordAsync(userToVerify, password))
            {
                return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userName, userToVerify.Id));
            }

            return await Task.FromResult<ClaimsIdentity>(null);
        }


        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody]ChangePasswordViewModel obj)
        {
            if (string.IsNullOrEmpty(obj.UserName) || string.IsNullOrEmpty(obj.oldPassword))
                return BadRequest();

            var userToVerify = await _userManager.FindByNameAsync(obj.UserName);

            if (userToVerify == null) return BadRequest();

            if (await _userManager.CheckPasswordAsync(userToVerify, obj.oldPassword))
            {

                await _userManager.ChangePasswordAsync(userToVerify, obj.oldPassword, obj.newPassword);

                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody]ForgotPasswordViewModel obj)
        {
            if (string.IsNullOrEmpty(obj.Email))
                return BadRequest();

            var user = await _userManager.FindByEmailAsync(obj.Email);

            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user))) return BadRequest();

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var callbackUrl = "http://localhost:4200/forgetpass?token=" + token + '&' + "userId=" + user.Email;

            await _emailSender.SendEmailAsync(user.Email, "şifre sıfırlama", " şifre sıfırlamak için tıklayın:" + callbackUrl);
            return Ok();

        }

        [HttpPost("resetpasword")]
        public async Task<IActionResult> Resetpassword([FromBody]ConfirmPasswordViewModel obj)
        {
            if (string.IsNullOrEmpty(obj.Email) || string.IsNullOrEmpty(obj.Password))
                return BadRequest();
            var user = await _userManager.FindByEmailAsync(obj.Email);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user))) return BadRequest();

            var result = await _userManager.ResetPasswordAsync(user, obj.Token, obj.Password);

            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}