using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.Response
{
    public class ListUsersResponse
    {
        public List<Client> Clients { get; set; }
    }
}
