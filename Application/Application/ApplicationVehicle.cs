using Application.Interfaces;
using Domain.Interfaces;
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


        public async Task<bool> AddVehicle(string manufacturer, string model, int year)
        {
            return await _IVehicle.AddVehicle(manufacturer, model, year);
        }

        public async Task<bool> DeleteVehicle(int id)
        {
            return await _IVehicle.DeleteVehicle(id);
        }
    }
}
