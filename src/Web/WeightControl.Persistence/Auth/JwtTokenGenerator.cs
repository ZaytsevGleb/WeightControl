﻿using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WeightControl.Application.Common.Interfaces;
using WeightControl.Domain.Entities;

namespace WeightControl.Persistence.Auth
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {

        private readonly JwtSettings jwtSettings;

        public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings)
        {
            this.jwtSettings = jwtSettings.Value;
        }

        public string GenerateToken(string name, string email, ICollection<Role> reles)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Name, name),
                new Claim("Date", DateTime.Now.ToString())
            };

            foreach (Role role in reles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            };

            var securityToken = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                expires: DateTime.Now.AddMinutes(jwtSettings.ExpiryMinutes),
                claims: claims,
                signingCredentials: signingCredentials,
                audience: jwtSettings.Audience
                );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
