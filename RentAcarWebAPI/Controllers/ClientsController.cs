using Application.Interfaces;
using Application.Interfaces.Generic;
using Entities.Entities;
using Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
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
        //private readonly IApplicationGeneric<Client> _IApplicationGeneric;
        private readonly UserManager<Client> _userManager;
        private readonly SignInManager<Client> _signInManager;

        public ClientsController(IApplicationClient IApplicationClient, SignInManager<Client> signInManager, UserManager<Client> userManager)
        {
            _IApplicationClient = IApplicationClient;
            //_IApplicationGeneric = IApplicationGeneric;
            _userManager = userManager;
            _signInManager = signInManager;
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
        [HttpPost("/api/CreateTokenIdentity")]
        public async Task<IActionResult> CreateTokenIdentity([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.email) || string.IsNullOrWhiteSpace(login.password))
                return Unauthorized();

            var result = await
                _signInManager.PasswordSignInAsync(login.email, login.password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var userId = await _IApplicationClient.ReturnIdUser(login.email);
                var token = new TokenJWTBuilder()
                     .AddSecurityKey(JwtSecurityKey.Create("Secret_Key-12345678"))
                 .AddSubject("Company - SamDev085")
                 .AddIssuer("Test.Securiry.Bearer")
                 .AddAudience("Test.Securiry.Bearer")
                 .AddClaim("userId", userId)
                 .AddExpiry(30) // minutes for a token expiration
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
        [HttpPost("/api/AddUserIdentity")]
        public async Task<IActionResult> AddUserIdentity([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.email) || string.IsNullOrWhiteSpace(login.password))
                return Ok("Falta alguns dados");

            var user = new Client
            {
                UserName = login.email,
                Email = login.email,
                Type = UserType.CommonUser
            };
            var result = await _userManager.CreateAsync(user, login.password);

            if (result.Errors.Any())
            {
                return Ok(result.Errors);
            }

            // Geração de Confirmação caso precise
            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            // retorno email 
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result2 = await _userManager.ConfirmEmailAsync(user, code);

            if (result2.Succeeded)
                return Ok("Usuário Adicionado com Sucesso");
            else
                return Ok("Erro ao confirmar usuários");

        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/DeleteUser")]
        public async Task<IActionResult> DeleteUser(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
                return Ok("User data is invalid.");

            var user = await _IApplicationClient.ReturnIdUser(id);
            if (user == null)
                return Ok("User not found.");

            else
                await _IApplicationClient.DeleteUser(user);
                return Ok("User successfully deleted.");

        }
    }
}

