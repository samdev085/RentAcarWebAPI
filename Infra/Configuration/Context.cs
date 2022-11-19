using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Configuration
{
    public class Context : IdentityDbContext<Client>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Contract> Contract { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConnection());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Client>().ToTable("AspNetUsers").HasKey(t => t.Id);
            builder.Entity<Vehicle>().ToTable("Vehicles").HasKey(t => t.Id);


            base.OnModelCreating(builder);
        }

        public string GetStringConnection()
        {
            string strcon = "Data Source=SAMUELPC;Initial Catalog=RentACardb;Integrated Security=SSPI;Persist Security Info=False;";
            return strcon;
        }
    }
}
