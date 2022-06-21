using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2T.Configurations;

namespace Test2T.Models
{
    public class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options) { }


        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Inspection> Inspection { get; set; }
        public virtual DbSet<Mechanic> Mechanic { get; set; }
        public virtual DbSet<ServiceTypeDict> ServiceTypeDict { get; set; }
        public virtual DbSet<ServiceTypeDict_Inspection> ServiceTypeDict_Inspection { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s22338;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceTypeDict_Inspection>().HasKey(k => new { k.IdServiceType, k.IdInspection });
            modelBuilder.ApplyConfiguration(new CarConfig());
        }
    }
}
