using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopsWebApi.Dependencies.Interfaces;
using ShopsWebApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ShopsWebApi.Services
{
    public class JwtTokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public JwtTokenService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public string GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim>() 
            {
                new Claim("login", user.Login),
                new Claim("role", user.Role.ToString())
            };
             
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims, expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }


    }
}
