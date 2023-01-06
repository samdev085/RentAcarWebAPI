using Domain.DTO_s.Models;
using Domain.DTO_s.Request;
using Domain.DTO_s.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationUser
    {
        Task<List<UserModel>> ListUsers();
        Task<bool> DeleteUser(string id);
        Task<UserModel> GetUserById(string id);
        Task<UserRegisterResponse> AddNewUser(UserRegisterRequest request);
        Task<UserModel> UpdateUser(UserModel request);
        Task<UserLoginResponse> Login(UserLoginRequest request);
        Task<UserLoginResponse> LoginWithoutPassword(string userId);
    }
}
