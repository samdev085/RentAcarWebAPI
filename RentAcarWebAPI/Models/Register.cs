﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentAcarWebAPI.Models
{
    public class Register
    {
        public string userName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public string password { get; set; }
    }
}
