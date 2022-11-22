using Domain.Interfaces.Generic;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClient 
    {
        Task<bool> AddUser(string name, string email, string phone, string address, string password);
        Task<bool> CheckUser(string email, string password);
        Task<string> ReturnIdUser(string email);
        Task<bool> DeleteUser(string id);
    }
}
