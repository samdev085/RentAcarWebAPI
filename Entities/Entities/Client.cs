using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Client
    {
        [Column("CLNT_ID")]
        public int Id { get; set; }

        [Column("CLNT_NAME")]
        public string Name { get; set; }

        [Column("CLNT_EMAIL")]
        public string Email { get; set; }

        [Column("CLNT_PHONE")]
        public string Phone { get; set; }

        [Column("CLNT_PASSWORD")]
        public string Password { get; set; }

        [Column("CLNT_ADDRESS")]
        public string Address { get; set; }

        [Column("CLNT_TYPE")]
        public UserType Type { get; set; }
    }
}
