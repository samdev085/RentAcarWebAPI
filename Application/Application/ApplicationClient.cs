using Application.Interfaces;
using Domain.Interfaces;
using System.Threading.Tasks;

namespace Application.Application
{
    public class ApplicationClient : IApplicationClient 
    {
        IClient _IClient;
        

        public ApplicationClient(IClient IClient)
        {
            _IClient = IClient;
            
        }

        public async Task<bool> AddUser(string name, string email, string phone, string address, string password)
        {
            return await _IClient.AddUser(name, email, phone, address, password);
        }

        public async Task<bool> CheckUser(string email, string password)
        {
            return await _IClient.CheckUser(email, password);
        }

        public async Task<string> ReturnIdUser(string id)
        {
            return await _IClient.ReturnIdUser(id);
        }

        public async Task<bool> DeleteUser(string id)
        {
            return await _IClient.DeleteUser(id);
        }
    }
}
