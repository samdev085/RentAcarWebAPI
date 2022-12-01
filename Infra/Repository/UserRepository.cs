using Application.DTO_s.Request;
using Application.DTO_s.Response;
using Application.Services;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class UserRepository : IServiceUser
    {
        private readonly SignInManager<Client> _signInManager;
        private readonly UserManager<Client> _userManager;

        public UserRepository(SignInManager<Client> signInManager, UserManager<Client> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<UserRegisterResponse> AddNewUser(UserRegisterRequest usuarioCadastro)
        {
            var identityUser = new Client
            {
                UserName = usuarioCadastro.Email,
                Email = usuarioCadastro.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(identityUser, usuarioCadastro.Senha);
            if (result.Succeeded)
                await _userManager.SetLockoutEnabledAsync(identityUser, false);

            var userRegisterResponse = new UserRegisterResponse(result.Succeeded);
            if (!result.Succeeded && result.Errors.Count() > 0)
                userRegisterResponse.AdicionarErros(result.Errors.Select(r => r.Description));

            return userRegisterResponse;
        }
    }
}
