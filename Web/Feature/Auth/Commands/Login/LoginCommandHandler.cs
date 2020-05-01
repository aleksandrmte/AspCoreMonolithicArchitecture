using Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;
using Web.Feature.Auth.Dto;
using Web.Framework.Helpers;

namespace Web.Feature.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, JwtTokenVm>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;

        public LoginCommandHandler(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
        }

        public async Task<JwtTokenVm> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);
            if (!result.Succeeded)
                throw new ApplicationException("INVALID_LOGIN_ATTEMPT");

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new ApplicationException("INVALID_LOGIN_ATTEMPT");

            var secretKey = _config.GetValue<string>("Secret");
            var tokenString = IdentityHelper.CreateClaimsWithToken(user.Email, secretKey);
            return new JwtTokenVm
            {
                Email = user.Email,
                Token = tokenString
            };
        }
    }
}
