﻿using Application.Interfaces.Generic;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationVehicle
    {
        Task<bool> AddVehicle(string manufacturer, string model, int year);
        Task<bool> DeleteVehicle(int id);

    }
}
