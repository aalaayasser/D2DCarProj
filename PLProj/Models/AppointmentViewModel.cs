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
        public int? TechnicalId { get; set; }
        public int? DriverId { get; set; }
        public int? TicketId { get; set; }

        [InverseProperty(nameof(TechnicianViewModel.Appointments))]
        public virtual TechnicianViewModel Technicians { get; set; } = null!;

        [InverseProperty(nameof(DriverViewModel.Appointments))]
        public virtual DriverViewModel Drivers { get; set; } = null!;

        [InverseProperty(nameof(TicketViewModel.Appointments))]
        public virtual TicketViewModel Tickets { get; set; } = null!;


    }
}
