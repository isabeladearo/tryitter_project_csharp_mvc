using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Tryitter.Models;
using Microsoft.Extensions.Configuration;
using Tryitter.Models.DTOs.StudentDTO;

namespace Tryitter.Services
{
    public class TokenService : ITokenService
    {
        public string GerarToken(string key, StudentDTOLogin studentLogin)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, studentLogin.Email),
                new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }
    }
}
