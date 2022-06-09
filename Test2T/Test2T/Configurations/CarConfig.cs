using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2T.Models;

namespace Test2T.Configurations
{
    public class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(e => e.IdCar).HasName("Id_Car");
            builder.Property(e => e.IdCar).UseIdentityColumn();

            builder.Property(e => e.Name).HasMaxLength(50).IsRequired();

            builder.Property(e => e.ProductionYear).IsRequired();

            var cars = new List<Car>();
            cars.Add(new Car
            {
                IdCar = 1,
                Name = "Corsa",
                ProductionYear = 2018
            });

            builder.HasData(cars);
        }
    }
}
