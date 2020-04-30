using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Web.Framework.Helpers;
using Web.Models;

namespace Web.Controllers.Api
{
    public class AuthController : ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;

        public AuthController(UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }

        [HttpPost("auth")]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginVm model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return NotFound();
            var secretKey = _config.GetValue<string>("Secret");
            var tokenString = IdentityHelper.CreateClaimsWithToken(user.Email, secretKey);
            return Ok(new JwtTokenVm
            {
                Email = user.Email,
                Token = tokenString
            });
        }

    }
}