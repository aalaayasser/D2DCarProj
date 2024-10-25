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
               .HasColumnType("varchar(100)");

            

             
           

              builder.Property(e => e.FinalReport)
               
               .HasColumnType("text");

             builder.Property(e => e.Feedback)
               .HasColumnType("text");


            builder.Property(e => e.stateType)
             .HasConversion(
             (ST) => ST.ToString(),
             (STAsString) => (StateType)Enum.Parse(typeof(StateType), STAsString, true)
             );



        }
    }
}
