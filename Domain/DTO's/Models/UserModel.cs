using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public List<string> Erros { get; private set; }


        public UserModel() =>
            Erros = new List<string>();


        public void AddErros(IEnumerable<string> erros) =>
            Erros.AddRange(erros);
    }
}
