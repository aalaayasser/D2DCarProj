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
    public class AppointmentViewModel
    {
        public int Id { get; set; }


        [Display(Name = "Partial Report")]
        [Required]
        public string PartialReport { get; set; } = null!;
        [Display(Name = "Start Date & Time")]
        [Required]
        public DateTime StartDateTime { get; set; }
        [Display(Name = "End Date & Time")]
        [Required]
        public DateTime EndtDateTime { get; set; }
        public int TechnicalId { get; set; }
        public int DriverId { get; set; }
        public int TicketId { get; set; }

        [InverseProperty(nameof(Technician.Appointments))]
        public virtual Technician Technicians { get; set; } = null!;

        [InverseProperty(nameof(Driver.Appointments))]
        public virtual Driver Drivers { get; set; } = null!;

        [InverseProperty(nameof(Ticket.Appointments))]
        public virtual Ticket Tickets { get; set; } = null!;

        #region Mapping
        public static explicit operator AppointmentViewModel(Appointment model)
        {
            return new AppointmentViewModel
            {
                Id = model.Id,
                PartialReport = model.PartialReport,
                StartDateTime = model.StartDateTime,
                EndtDateTime = model.EndtDateTime,
                TechnicalId = model.TechnicalId,
                DriverId = model.DriverId,
                TicketId = model.TicketId,
                Technicians = model.Technicians, 
                Drivers = model.Drivers,             
                Tickets = model.Tickets              
            };
        }

        public static explicit operator Appointment(AppointmentViewModel viewModel)
        {
            return new Appointment
            {
                Id = viewModel.Id,
                PartialReport = viewModel.PartialReport,
                StartDateTime = viewModel.StartDateTime,
                EndtDateTime = viewModel.EndtDateTime,
                TechnicalId = viewModel.TechnicalId , 
                DriverId = viewModel.DriverId ,
                TicketId = viewModel.TicketId
                            
            };
        }
        #endregion

    }
}
