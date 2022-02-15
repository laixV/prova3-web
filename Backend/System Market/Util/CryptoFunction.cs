using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Market.Util
{
    public static class CryptoFunction
    {
        public static string GenerateToken(IConfiguration configuration)
        {
            var key = Encoding.UTF8.GetBytes(configuration["SecurityKey"]);
            var symmetricSecurityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var tokenExpireTimeLapse = int.Parse(configuration["TokenExpireTimeLapse"]);
            var token = new JwtSecurityToken(
                issuer: configuration["Issuer"],
                audience: configuration["Audience"],
                expires: DateTime.Now.AddMinutes(tokenExpireTimeLapse),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
