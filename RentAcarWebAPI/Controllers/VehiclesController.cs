using Application.Interfaces;
using Domain.DTO_s.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentAcarWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IApplicationVehicle _IApplicationVehicle;


        public VehiclesController(IApplicationVehicle IApplicationVehicle)
        {
            _IApplicationVehicle = IApplicationVehicle;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/AddNewVehicle")]
        public async Task<IActionResult> AddNewVehicle(VehicleModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _IApplicationVehicle.AddNewVehicle(request);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);

        }
    }
}
