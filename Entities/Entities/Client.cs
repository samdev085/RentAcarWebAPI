using Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Client : IdentityUser
    {
        [Column("Address")]
        public string Address { get; set; }

        [Column("Status")]
        public int Status { get; set; }

        [Column("Type")]
        public UserType? Type { get; set; }
    }
}
