using MediatR;
using Web.Feature.Auth.Dto;

namespace Web.Feature.Auth.Commands.Login
{
    public class LoginCommand : IRequest<JwtTokenVm>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
