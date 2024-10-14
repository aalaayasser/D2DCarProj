using DALProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Data.Configartions
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Color> builder)
        {
          

        
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50) 
                .HasColumnType("varchar"); 
        }
    }
}
