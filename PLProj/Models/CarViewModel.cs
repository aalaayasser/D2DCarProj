using PLProj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Models
{
	public class CarViewModel
	{
		public int Id { get; set; }

		[Display(Name = "Model ID")]

		public int ModelId { get; set; }

		[Display(Name = "Customer ID")]

		public int? CustomerId { get; set; }

		[Display(Name = "Color ID")]
		public int ColorId { get; set; }
		[Required]



		[Display(Name = "Year of Manufacture")]
		public int Year { get; set; }

		[Display(Name = "Description")]
		public string? Description { get; set; }



		//		public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
		//		public virtual ICollection<KiloMetres> KiloMetres { get; set; } = new HashSet<KiloMetres>();
		//		public virtual Customer Customer { get; set; } = null!;
		//      public virtual Color Color { get; set; } = null!;
		//      public virtual Model Model { get; set; } = null!;





		#region Mapping

		public static explicit operator CarViewModel(Car model)
		{
			return new CarViewModel
			{
				Id = model.Id,
				ModelId = model.ModelId,
				CustomerId = model.CustomerId,
				ColorId = model.ColorId,
				Year = model.Year,
				Description = model.Description,
				//Tickets =model.Tickets,
				//Customer = model.Customer,
				//Color = model.Color,
				//Model = model.Model,
				//KiloMetres = model.KiloMetres,
			};
		}

		public static explicit operator Car(CarViewModel viewModel)
		{
			return new Car
			{
				Id = viewModel.Id,
				ModelId = viewModel.ModelId,
				CustomerId = viewModel.CustomerId,
				ColorId = viewModel.ColorId,
				Year = viewModel.Year,
				Description = viewModel.Description,

			};
		}

		#endregion

	}
}
