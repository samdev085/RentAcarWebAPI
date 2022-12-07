using Application.Interfaces;
using Domain.DTO_s.Request;
using Domain.DTO_s.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RentAcarWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IApplicationUser _IApplicationUser;


        public UsersController(IApplicationUser IApplicationUser)
        {
            _IApplicationUser = IApplicationUser;
        }



        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/AddNewUser")]
        public async Task<ActionResult<UserRegisterResponse>> AddNewUser(UserRegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _IApplicationUser.AddNewUser(request);
            if (result.Success)
                return Ok(result);
            else if (result.Erros.Count > 0)
                return BadRequest(result);

            return StatusCode(StatusCodes.Status500InternalServerError);

        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/Login")]
        public async Task<ActionResult<UserRegisterResponse>> Login(UserLoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _IApplicationUser.Login(request);
            if (result.Success)
                return Ok(result);

            return Unauthorized(result);
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/RefreshLogin")]
        public async Task<ActionResult<UserRegisterResponse>> RefreshLogin()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return BadRequest();

            var result = await _IApplicationUser.LoginWithoutPassword(userId);
            if (result.Success)
                return Ok(result);

            return Unauthorized(result);
        }

    }
}
