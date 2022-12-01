using Application.DTO_s.Request;
using Application.DTO_s.Response;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RentAcarWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
   
        private readonly IServiceUser _IServiceUser;

        public ClientsController(IServiceUser IServiceUser)
        {
            _IServiceUser = IServiceUser;
        }

      

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/AddNewUser")]
        public async Task<ActionResult<UserRegisterResponse>> AddNewUser(UserRegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _IServiceUser.AddNewUser(request);
            if (result.Sucesso)
                return Ok(result);
            else if (result.Erros.Count > 0)
                return BadRequest(result);

            return StatusCode(StatusCodes.Status500InternalServerError);

        }

    }
}


