﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using NTierArchitecture.Entities.Abstractions;
using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.Business.Features.Auth.Login
{
    internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtProvider _jwtProvider;
        public LoginCommandHandler(UserManager<AppUser> userManager, IJwtProvider jwtProvider)
        {
            _userManager = userManager;
            _jwtProvider = jwtProvider;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            AppUser appUser = await _userManager.Users.Where(x => x.UserName == request.UserNameOrEmail || x.Email == request.UserNameOrEmail).FirstOrDefaultAsync(cancellationToken);
            if (appUser is null)
            {
                throw new ArgumentException("Böyle bir kullanıcı bulunamadı.");
            }
            bool CheckPassword = await _userManager.CheckPasswordAsync(appUser, request.Password);

            if (!CheckPassword)
            {
                throw new ArgumentException("Şifre Yanlış");
            }
            string token = await _jwtProvider.CreateTokenAsync(appUser);
            return new(AccessToken:token,UserID: appUser.Id);
        }
    }
}
