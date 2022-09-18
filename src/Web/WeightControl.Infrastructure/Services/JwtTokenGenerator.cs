using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WeightControl.Application.Common.Interfaces;
using WeightControl.Application.Common.Options;
using WeightControl.Domain.Entities;

namespace WeightControl.Infrastructure.Services
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly AuthOptions authOptions;

        public JwtTokenGenerator(IOptions<AuthOptions> authOptions)
        {
            this.authOptions = authOptions.Value;
        }

        public string GenerateToken(User user)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.Secret)),
                SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            foreach (Role role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            };

            var securityToken = new JwtSecurityToken(
                issuer: authOptions.Issuer,
                expires: DateTime.Now.AddMinutes(authOptions.ExpiryMinutes),
                claims: claims,
                signingCredentials: signingCredentials,
                audience: authOptions.Audience);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
