using Domain.Interfaces;
using Entities.Entities;
using Entities.Enums;
using Infra.Configuration;
using Infra.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class RepositoryVehicle : RepositoryGeneric<Vehicle>, IVehicle
    {

        private readonly DbContextOptions<Context> _optionsbuilder;

        public RepositoryVehicle()
        {
            _optionsbuilder = new DbContextOptions<Context>();
        }

        public async Task<bool> AddVehicle(string manufacturer, string model, int year)
        {
            try
            {
                using (var data = new Context(_optionsbuilder))
                {
                    await data.Vehicle.AddAsync(
                          new Vehicle
                          {
                              Manufacturer = manufacturer,
                              Model = model,
                              Year = year,
                              Category = CategoryPrice.Basic                     
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
