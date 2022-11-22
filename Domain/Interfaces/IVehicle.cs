using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IVehicle 
    {
        Task<bool> AddVehicle(string manufacturer, string model, int year);
        Task<bool> DeleteVehicle(int id);
    }
}
