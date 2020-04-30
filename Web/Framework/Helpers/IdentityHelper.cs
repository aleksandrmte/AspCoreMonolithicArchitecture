using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Web.Framework.Helpers
{
    public class IdentityHelper
    {
        /// <summary>
        /// Created claims and jwt-token
        /// </summary>
        /// <param name="email"></param>
        /// <param name="secretKey"></param>
        /// <param name="countExpiresDay"></param>
        /// <returns></returns>
        public static string CreateClaimsWithToken(string email, string secretKey, int countExpiresDay = 7)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, email)
                }),
                Expires = DateTime.UtcNow.AddDays(countExpiresDay),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }

}
