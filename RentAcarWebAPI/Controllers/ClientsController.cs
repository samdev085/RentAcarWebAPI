using Application.Interfaces;
using Entities.Entities;
using Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using RentAcarWebAPI.Models;
using RentAcarWebAPI.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAcarWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IApplicationClient _IApplicationClient;

        public ClientsController(IApplicationClient IApplicationClient)
        {
            _IApplicationClient = IApplicationClient;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet("/api/ListClients")]
        public async Task<List<Client>> ListClients()
        {
            return await _IApplicationClient.ListClients();
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet("/api/GetUser")]
        public async Task<ActionResult<Client>> GetUser(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return Ok("Field is empty.");

            var user = await _IApplicationClient.GetUser(id);
            if (user != null)
            {
                return user;
            }
            return Ok("User not found.");
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/AddUser")]
        public async Task<IActionResult> AddUser([FromBody] Register reg)
        {
            if (string.IsNullOrWhiteSpace(reg.email) || string.IsNullOrWhiteSpace(reg.password))
                return Ok("Falta alguns dados");

            var result = await
                _IApplicationClient.AddUser(reg.userName, reg.email, reg.phoneNumber, reg.address, reg.password);

            if (result)
                return Ok("Usuário Adicionado com Sucesso");
            else
                return Ok("Erro ao adicionar usuário");
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CreateToken")]
        public async Task<IActionResult> CreateToken([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.email) || string.IsNullOrWhiteSpace(login.password))
                return Unauthorized();

            var result = await _IApplicationClient.CheckUser(login.email, login.password);
            if (result)
            {
                var userId = await _IApplicationClient.ReturnIdUser(login.email);
                var token = new TokenJWTBuilder()
                     .AddSecurityKey(JwtSecurityKey.Create("Secret_Key-12345678"))
                 .AddSubject("Company - SamDev085")
                 .AddIssuer("Test.Securiry.Bearer")
                 .AddAudience("Test.Securiry.Bearer")
                 .AddClaim("userId", userId)
                 .AddExpiry(60) // minutes for a token expiration
                 .Builder();

                return Ok(token.value);
            }
            else
            {
                return Unauthorized();
            }

        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpDelete("/api/DeleteUser")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return Ok("Field is empty.");
            var result = await _IApplicationClient.DeleteUser(id);
            if (result==true)
                return Ok("User deleted.");
            else
            return Ok("User not found.");
        }

    }
}


