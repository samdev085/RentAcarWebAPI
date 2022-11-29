using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationClient
    {
        Task<List<Client>> ListClients();
        Task<Client> GetUser(string id);
        Task<bool> AddUser(string name, string email, string phone, string address, string password);
        Task<bool> CheckUser(string email, string password);
        Task<string> ReturnIdUser(string id);
        Task<bool> DeleteUser(string id);
    }
}
