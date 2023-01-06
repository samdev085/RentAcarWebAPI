using Domain.DTO_s.Models;
using Domain.DTO_s.Request;
using Domain.DTO_s.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUser
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
