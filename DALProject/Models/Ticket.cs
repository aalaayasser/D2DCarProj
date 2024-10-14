using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Models
{
    public class Ticket
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
    }

}

