using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.Models
{
    public class VehicleModel
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }

        //public bool Success { get; private set; }
        //public List<string> Erros { get; private set; }


        //public VehicleModel(bool success = true) : this() =>
        //    Success = success;

        //public VehicleModel() =>
        //    Erros = new List<string>();


        //public void AddErros(IEnumerable<string> erros) =>
        //    Erros.AddRange(erros);
    }
}
