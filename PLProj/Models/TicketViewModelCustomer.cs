﻿using PLProj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Models
{
	public class TicketViewModelCustomer 
	{
		public int Id { get; set; }

		[Required]
		[Display(Name = "Current Kilometres")]
		public long CurrentKilometres { get; set; }

		[Required]
		public string Location { get; set; }
		//public string Feedback { get; set; }

		public int CarId { get; set; }
		public int ServiceId { get; set; }


		#region Mapping

		public static explicit operator TicketViewModelCustomer(Ticket model)
		{
			return new TicketViewModelCustomer
			{
				Id = model.Id,
				CurrentKilometres = model.CurrentKilometres,

				Location = model.Location,

				CarId = model.CarId,
				ServiceId = model.ServiceId,
				//Feedback = model.Feedback
				


			};
		}

		public static explicit operator Ticket(TicketViewModelCustomer viewModel)
		{
			return new Ticket
			{
				Id = viewModel.Id,
				CurrentKilometres = viewModel.CurrentKilometres,

				Location = viewModel.Location,


				CarId = viewModel.CarId,
				ServiceId = viewModel.ServiceId,
				//Feedback = viewModel.Feedback,


			};
		}

		#endregion
	}

}
