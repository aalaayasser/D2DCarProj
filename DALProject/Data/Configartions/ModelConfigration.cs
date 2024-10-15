using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALProject.Models;

namespace DALProject.Data.Configartions
{
    internal class ModelConfigration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.Property(m => m.Name)
           .IsRequired()
           .HasColumnType("text");

            builder.HasMany(e => e.Parts)
              .WithMany(e => e.Models);
        }
    }
}
