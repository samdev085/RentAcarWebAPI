using Application.DTO_s.Request;
using Application.DTO_s.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IServiceUser
    {
        Task<UserRegisterResponse> AddNewUser(UserRegisterRequest request);
    }
}
