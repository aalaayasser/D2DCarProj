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
    internal class TicketConfigration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.Property(e => e.CurrentKilometres)
                .IsRequired();

            builder.Property(e => e.Location)
               .IsRequired()
               .HasColumnType("varchar");

             builder.Property(e => e.State)
               .IsRequired()
               .HasColumnType("varchar");

             
             builder.Property(e => e.Location)
               .IsRequired()
               .HasColumnType("varchar");

              builder.Property(e => e.FinalReport)
               .IsRequired()
               .HasColumnType("text");

             builder.Property(e => e.Feedback)
               .IsRequired()
               .HasColumnType("text");

            builder.Property(e => e.IsPayed)
               .IsRequired()
               .HasColumnType("varchar");

             

        }
    }
}
