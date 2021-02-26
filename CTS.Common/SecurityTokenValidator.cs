using Microsoft.AspNetCore.Http.Features.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CTS.Common
{
   public class SecurityTokenValidator : ISecurityTokenValidator
    {
        public bool CanValidateToken => throw new NotImplementedException();

        public int MaximumTokenSizeInBytes
        {
            get => throw new NotImplementedException(); set => throw new NotImplementedException();
        }

        public bool CanReadToken(string securityToken)
        {
            throw new NotImplementedException();
        }

        public ClaimsPrincipal ValidateToken(string securityToken,TokenValidationParameters validationParameters,out SecurityToken validatedToken)
        {
            throw new NotImplementedException();
        }
        public string CreateToken(AuthenticationCredintials credintials, IConfiguration configuration)
        {
            var claims = new[]
            {
                new System.Security.Claims.Claim("UserProfile",JsonConvert.SerializeObject(credintials)),
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.UniqueName,credintials.UserName),
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.Iat,credintials.Password),
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(configuration["Tokens:Issuer"],
                configuration["Tokens:Issuer"],
                claims,
                DateTime.Now,
                DateTime.Now.AddDays(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
