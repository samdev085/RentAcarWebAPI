using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClient 
    {
        Task<List<Client>> ListClients();
        Task<Client> GetUser(string id);
        Task<bool> AddUserIdentity(string name, string email, string phone, string address, string password);
        Task<bool> AddUser(string name, string email, string phone, string address, string password);   
        Task<bool> CheckUser(string email, string password);
        Task<string> ReturnIdUser(string email);
        Task<bool> DeleteUser(string id);
    }
}
