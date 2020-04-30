using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApplicationCore.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Web.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = Convert.ToInt32(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        public int? UserId { get; }
    }
}
