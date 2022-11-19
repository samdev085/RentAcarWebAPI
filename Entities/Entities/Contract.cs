using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [Table("TB_CONTRACTS")]
    public class Contract
    {
        [Key()]
        [Column("CTRC_ID")]
        public int Id { get; set; }

        [ForeignKey("CLNT")]
        [Column("CTRC_CLIENT")]
        public virtual Client Client { get; set; }

        [ForeignKey("VHCL")]
        [Column("CTRC_VEHICLE")]
        public virtual Vehicle Vehicle { get; set; }

        [Column("CTRC_START")]
        public DateTime Start { get; set; }

        [Column("CTRC_FINISH")]
        public DateTime Finish { get; set; }

        [Column("CTRC_PRICE")]
        public decimal Price { get; set; }
    }
}
