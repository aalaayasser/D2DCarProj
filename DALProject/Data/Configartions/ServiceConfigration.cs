using DALProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Data.Configartions
{
    public class ServiceConfigration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(s => s.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();
              builder.Property(s => s.Price)
                .HasColumnType("decimal(8,2)")
                .IsRequired();

            builder.Property(s =>s.Description)
                .HasColumnType("text");

            

        }
    }
}
