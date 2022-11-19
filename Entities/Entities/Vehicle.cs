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
    [Table("TB_VEHICLES")]
    public class Vehicle
    {
        [Key()]
        [Column("VHCL_ID")]
        public int Id { get; set; }

        [Required]
        [Column("VHCL_MANUFACTURER")]
        [MaxLength(50)]
        public string Manufacturer { get; set; }

        [Required]
        [Column("VHCL_MODEL")]
        [MaxLength(50)]
        public string Model { get; set; }

        [Required]
        [Column("VHCL_YEAR")]
        public int Year { get; set; }

        [Required]
        [Column("VHCL_CATEGORY")]
        public CategoryPrice? Category { get; set; }

    }
}
