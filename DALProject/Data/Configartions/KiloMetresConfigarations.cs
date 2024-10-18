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
	internal class KiloMetresConfigarations : IEntityTypeConfiguration<KiloMetres>
	{
		public void Configure(EntityTypeBuilder<KiloMetres> builder)
		{
			//builder.HasKey(x => new {x.Id,x.kiloMetres});

			builder.Property(c => c.kiloMetres)
			.IsRequired()
			.HasColumnType("bigint");
		}
	}
}
