using Domain.DTO_s.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationVehicle
    {
        Task<bool> AddNewVehicle(VehicleModel request);
    }
}
