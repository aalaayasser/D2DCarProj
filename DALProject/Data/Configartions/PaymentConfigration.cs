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
    public class PaymentConfigration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(e => e.Method)
            .HasConversion(
            (PM) => PM.ToString(),
            (PMAsString) => (PaymentMethod)Enum.Parse(typeof(PaymentMethod), PMAsString, true)
            );
        }

       
    }
}
