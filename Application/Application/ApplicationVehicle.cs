using Application.Interfaces;
using Domain.DTO_s.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application
{
    public class ApplicationVehicle : IApplicationVehicle
    {
        IVehicle _IVehicle;


        public ApplicationVehicle(IVehicle IVehicle)
        {
            _IVehicle = IVehicle;
        }

        public async Task<bool> AddNewVehicle(VehicleModel request)
        {
            return await _IVehicle.AddNewVehicle(request);
        }
    }
}
