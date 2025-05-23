﻿using NTierArchitecture.DataAccess.Context;
using NTierArchitecture.Entities.Abstractions;
using NTierArchitecture.Entities.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTierArchitecture.Entities.Options;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace NTierArchitecture.DataAccess.Services
{
    internal sealed class JwtProvider : IJwtProvider
    {
        private readonly ApplicationDbContext _context;
        private readonly Jwt _jwt;
        public JwtProvider(ApplicationDbContext context, IOptions<Jwt> jwt)
        {
            _context = context;
            _jwt = jwt.Value;
        }

        public async Task<string> CreateTokenAsync(AppUser user)
        {
            Claim[] claims = new Claim[]
            {
            new Claim("NameLastname", string.Join(" ",user.Name,user.LastName)),
            new Claim("Email", user.Email),
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };

            JwtSecurityToken securityToken = new(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddSeconds(10),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SecretKey)), SecurityAlgorithms.HmacSha512));

            JwtSecurityTokenHandler handler = new();
            string token = handler.WriteToken(securityToken);

            return token;
        }
    }
}
