using PLProj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Models
{
    public class TicketViewModel 
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Current Kilometres")]
        public long  CurrentKilometres { get; set; }

        [Display(Name = "Start Date & Time")]
        public DateTime StartDateTime { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string State { get; set; }

        [Display(Name = "Final Report")]
        public string FinalReport { get; set; } = null!;

        [Display(Name = "End Date & Time")]
        public DateTime EndDateTime { get; set; }

        [Display(Name = "Active Date of Part")]
        public DateTime ActiveDatePfPart { get; set; }

        public int CarId { get; set; }
        public int ServiceId { get; set; }

        public string? Feedback { get; set; }

        [Display(Name = "Is Paid")]
        [Required]
        public string IsPayed { get; set; }

        [InverseProperty(nameof(Appointment.Tickets))]
        public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();

        [InverseProperty(nameof(Car.Tickets))]
        public virtual Car Cars { get; set; }

        public virtual Service Service { get; set; }


        #region Mapping

        public static explicit operator TicketViewModel(Ticket model)
        {
            return new TicketViewModel
            {
                Id = model.Id,
                CurrentKilometres = model.CurrentKilometres,
                StartDateTime = model.StartDateTime,
                Location = model.Location,
                State = model.State,
                FinalReport = model.FinalReport,
                EndDateTime = model.EndDateTime,
                ActiveDatePfPart = model.ActiveDatePfPart,
                CarId = model.CarId,
                ServiceId = model.ServiceId,
                Feedback = model.Feedback,
                IsPayed = model.IsPayed,
                Cars = model.Cars,
                Service = model.Service,
                Appointments = model.Appointments
            };
        }

        public static explicit operator Ticket(TicketViewModel viewModel)
        {
            return new Ticket
            {
                Id = viewModel.Id,
                CurrentKilometres = viewModel.CurrentKilometres,
                StartDateTime = viewModel.StartDateTime,
                Location = viewModel.Location,
                State = viewModel.State,
                FinalReport = viewModel.FinalReport,
                EndDateTime = viewModel.EndDateTime,
                ActiveDatePfPart = viewModel.ActiveDatePfPart,
                CarId = viewModel.CarId,
                ServiceId = viewModel.ServiceId,
                Feedback = viewModel.Feedback,
                IsPayed = viewModel.IsPayed,
                
            };
        }

        #endregion


    }

}

