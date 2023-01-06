using Domain.DTO_s.Models;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTO_s.Response
{
    public class UserLoginResponse
    {
        public UserModel User { get; set; }

        public bool Success => Erros.Count == 0;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string AccessToken { get; private set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string RefreshToken { get; private set; }

        public List<string> Erros { get; private set; }

        public UserLoginResponse() =>
            Erros = new List<string>();

        public UserLoginResponse(bool success, string accessToken, string refreshToken, Client user) : this()
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            User = new UserModel
            {
                Name = user.UserName,
                Email = user.Email,
                Phone = user.PhoneNumber,
                Address = user.Address,
                Status = user.Status
            };

        }

        public void AddErrors(string erro) =>
            Erros.Add(erro);

        public void AddErrors(IEnumerable<string> erros) =>
            Erros.AddRange(erros);
    }
}
