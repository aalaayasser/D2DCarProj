using DALProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Data.Configartions
{
    public class PartConfiguration : IEntityTypeConfiguration<Part>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Part> builder)
        {
            
            
            
            builder.Property(p => p.PartName)
                .IsRequired() 
                .HasColumnType("varchar(100)"); 

           
            builder.Property(p => p.Price)
                .IsRequired() 
                .HasColumnType("decimal(18, 2)");


            builder.Property(p => p.PartKilometresToChange)
                .IsRequired()
                .HasColumnType("bigint"); 
        }
    }
}

