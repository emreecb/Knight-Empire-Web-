using Master.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Master.Controllers
{
    [Authorize(Policy = "ApiUser")]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly ClaimsPrincipal _caller;
        private readonly MasterContext _appDbContext;

        public UserController(UserManager<AppUser> userManager, MasterContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _appDbContext = appDbContext;
        }

        // GET api/dashboard/home
        [HttpGet]
        public async Task<IActionResult> Home()
        {

            var userId = _caller.Claims.Single(c => c.Type == "id");
            var customer = await _appDbContext.CharacterDetails.Include(c => c.Identity).SingleAsync(c => c.Identity.Id == userId.Value);
            return new OkObjectResult(customer);
        }
    }
}
