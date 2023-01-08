using Domain.DTO_s.Models;
using Domain.Interfaces;
using Entities.Entities;
using Entities.Enums;
using Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class VehicleRepository : IVehicle
    {
        private readonly DbContextOptions<Context> _optionsbuilder;

        public VehicleRepository(DbContextOptions<Context> optionsbuilder)
        {
            _optionsbuilder = optionsbuilder;
        }

        public async Task<bool> AddNewVehicle(VehicleModel request)
        {
            try
            {
                using (var data = new Context(_optionsbuilder))
                {
                    await data.Vehicle.AddAsync(
                          new Vehicle
                          {
                              Manufacturer = request.Manufacturer,
                              Model = request.Model,
                              Color = request.Color,
                              Year = request.Year,
                              Category = CategoryPrice.Basic,
                              Status = 1
                          });

                    await data.SaveChangesAsync();

                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
