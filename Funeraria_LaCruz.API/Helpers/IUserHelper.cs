﻿using Microsoft.AspNetCore.Identity;
using Funeraria_LaCruz.Shared.Entities;
using Funeraria_LaCruz.Shared.DTOS;

namespace Funeraria_LaCruz.API.Helpers
{
    public interface IUserHelper
    {

        Task<User> GetUserAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<SignInResult> LoginAsync(LoginDTO model);

        Task LogoutAsync();


    }
}
