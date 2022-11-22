using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentAcarWebAPI.Models;
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
        [HttpPost("/api/AddVehicle")]
        public async Task<IActionResult> AddVehicle([FromBody] VehicleModel vehicle)
        {
            if (string.IsNullOrWhiteSpace(vehicle.manufacturer) || string.IsNullOrWhiteSpace(vehicle.model) || vehicle.year == 0)
                return Ok("Some data invalid.");

            var result = await
                _IApplicationVehicle.AddVehicle(vehicle.manufacturer, vehicle.model, vehicle.year);

            if (result)
                return Ok("New vehicle add successfully.");
            else
                return Ok("Error when add new vehicle.");
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpDelete("/api/DeleteVehicle")]
        public async Task<IActionResult> DeleteVehicle([FromBody] VehicleModel vehicle)
        {

            var response = await _IApplicationVehicle.DeleteVehicle(vehicle.id);
            if (response)
                return Ok("New vehicle add successfully.");
            else
                return Ok("Error when add new vehicle.");
        }

    }    
}
