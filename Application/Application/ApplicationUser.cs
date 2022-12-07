using Application.Interfaces;
using Domain.DTO_s.Request;
using Domain.DTO_s.Response;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application
{
    public class ApplicationUser : IApplicationUser
    {
        IUser _IUser;


        public ApplicationUser(IUser IUser)
        {
            _IUser = IUser;
        }

        public async Task<UserRegisterResponse> AddNewUser(UserRegisterRequest request)
        {
            return await _IUser.AddNewUser(request);
        }

        public async Task<UserLoginResponse> Login(UserLoginRequest request)
        {
            return await _IUser.Login(request);
        }

        public async Task<UserLoginResponse> LoginWithoutPassword(string userId)
        {
            return await _IUser.LoginWithoutPassword(userId);
        }
    }
}
