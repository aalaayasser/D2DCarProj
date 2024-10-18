using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Models
{
	public class KiloMetres : ModelClass
	{
		public long kiloMetres { get; set; }
		public virtual Car Car { get; set; } = null!;
	}
}
