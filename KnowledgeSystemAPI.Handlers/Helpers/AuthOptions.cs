using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace KnowledgeSystemAPI.Handlers.Helpers
{
    public class AuthOptions
    {
        public const string Issuer = "https://localhost:44374"; 
        public const string Audience = "http://localhost:4200"; 
        const string KEY = "testSecretKey@421"; 
        public const int Lifetime = 100;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }

        public static string GenerateToken(string userName, string role)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, role)
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(100),
                signingCredentials: signingCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return tokenString;
        }
    }
}