using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.Response
{
    public class UserRegisterResponse
    {
        public bool Success { get; private set; }
        public List<string> Erros { get; private set; }

        public UserRegisterResponse() =>
            Erros = new List<string>();

        public UserRegisterResponse(bool success = true) : this() =>
            Success = success;

        public void AddErros(IEnumerable<string> erros) =>
            Erros.AddRange(erros);
    }
}
