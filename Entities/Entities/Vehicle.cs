using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Vehicle
    {
        [ForeignKey("Id")]
        //[Required()]
        [Column("Id")]
        public Guid Id { get; set; }

        [Required()]
        [Column("Manufacturer")]
        [MaxLength(50)]
        public string Manufacturer { get; set; }

        [Required()]
        [Column("Model")]
        [MaxLength(50)]
        public string Model { get; set; }

        [Required()]
        [Column("Color")]
        [MaxLength(50)]
        public string Color { get; set; }

        [Required()]
        [Column("Year")]
        public int Year { get; set; }

        [Required()]
        [Column("Status")]
        public int Status { get; set; }

        [Required()]
        [Column("Category")]
        public CategoryPrice? Category { get; set; }

    }
}
