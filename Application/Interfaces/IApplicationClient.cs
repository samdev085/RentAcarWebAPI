﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationClient
    {
        Task<bool> AddUser(string email, string password);
        Task<bool> CheckUser(string email, string password);
        Task<string> ReturnIdUser(string email);
    }
}