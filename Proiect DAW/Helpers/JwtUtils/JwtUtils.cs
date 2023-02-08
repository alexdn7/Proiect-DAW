﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Proiect_DAW.Models.Enums;
using System.Text;
using System.Linq;
using System;
using Proiect_DAW.Models;

namespace Proiect_DAW.Helpers.JwtUtils
{
    public class JwtUtils : IJwtUtils
    {
        public readonly AppSettings _appSettings;

        public JwtUtils(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var appPrivateKey = Encoding.ASCII.GetBytes(_appSettings.JwtToken);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new[] { new Claim("id", user.Id.ToString()) }
                    ),
                Expires = DateTime.UtcNow.AddDays(120),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(appPrivateKey), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public Guid ValidateJwtToken(string token)
        {
            if (token == null)
                return Guid.Empty;

            var tokenHandler = new JwtSecurityTokenHandler();
            var appPrivateKey = Encoding.ASCII.GetBytes(_appSettings.JwtToken);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(appPrivateKey),
                ValidateIssuer = true,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero,
            };
            try
            {
                tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                var result = jwtToken.Claims.FirstOrDefault(x => x.Type == "id");
                if (result == null)
                    return Guid.Empty;
                var userId = new Guid(result.Value);
                return userId;
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }
    }
}
