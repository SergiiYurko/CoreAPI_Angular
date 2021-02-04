using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace KnowledgeSystemAPI.Helpers
{
    public class AuthOptions
    {
        public const string ISSUER = "https://localhost:44374"; 
        public const string AUDIENCE = "http://localhost:4200"; 
        const string KEY = "testSecretKey@421"; 
        public const int LIFETIME = 100;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }

        public static string GenerateToken()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: ISSUER,
                audience: AUDIENCE,
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(100),
                signingCredentials: signingCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return tokenString;
        }
    }
}