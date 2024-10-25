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
    internal class AppointmentConfigration : IEntityTypeConfiguration<Appointment>
    {
        

        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.Property(e => e.PartialReport)
                .IsRequired(false)
                .HasColumnType("text");
            builder.HasOne(e => e.Technicians)
                .WithMany(s => s.Appointments)
                .HasForeignKey(e => e.TechnicianId)
                .OnDelete( DeleteBehavior.NoAction);


        }
    }
}
