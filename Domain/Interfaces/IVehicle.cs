using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IVehicle
    {
        Task<bool> AddVehicle(string manufacturer, string model, int year);
    }
}
