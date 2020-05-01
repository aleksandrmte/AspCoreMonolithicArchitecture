using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Feature.Auth.Commands.Login;
using Web.Feature.Auth.Dto;

namespace Web.Controllers.Api
{
    public class AuthController : ApiController
    {
        [HttpPost("auth")]
        public async Task<ActionResult<JwtTokenVm>> Authenticate([FromBody] LoginCommand command)
        {
            return await Mediator.Send(command);
        }

    }
}