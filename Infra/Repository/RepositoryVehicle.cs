using Domain.Interfaces;
using Entities.Entities;
using Entities.Enums;
using Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class RepositoryVehicle :  IVehicle
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
        public async Task<bool> DeleteVehicle(int id)
        {
            try
            {
                using (var data = new Context(_optionsbuilder))
                {
                    var vehicleCheck = await data.Vehicle.FindAsync(id);
                    if (vehicleCheck != null || vehicleCheck.Id == id)
                    {
                        data.Vehicle.Remove(vehicleCheck);
                        await data.SaveChangesAsync();
                    }
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
