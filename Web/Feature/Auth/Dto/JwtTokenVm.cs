using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Feature.Auth.Dto
{
    public class JwtTokenVm
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
