using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO_s.Response
{
    public class UserRegisterResponse
    {
        public bool Sucesso { get; private set; }
        public List<string> Erros { get; private set; }

        public UserRegisterResponse() =>
            Erros = new List<string>();

        public UserRegisterResponse(bool sucesso = true) : this() =>
            Sucesso = sucesso;

        public void AdicionarErros(IEnumerable<string> erros) =>
            Erros.AddRange(erros);
    }
}
