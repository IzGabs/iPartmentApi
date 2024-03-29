

using API.Domain.User;
using iPartmentApi;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Application
{
    public class TokenService
    {

        public static string GenerateToken(UserObject user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {

                    new Claim(ClaimTypes.Name, user.Name.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(250),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }



    }
}