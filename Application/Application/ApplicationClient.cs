using Application.Interfaces;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return await _IClient.AddUser(name, email, address, password, phone);
        }

        public async Task<bool> CheckUser(string email, string password)
        {
            return await _IClient.CheckUser(email, password);
        }

        public async Task<string> ReturnIdUser(string email)
        {
            return await _IClient.ReturnIdUser(email);
        }
    }
}
