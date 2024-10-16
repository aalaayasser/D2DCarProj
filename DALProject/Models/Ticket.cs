using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Models
{
    public class Ticket : ModelClass
    {
        //public int Id { get; set; }
        
        public long  CurrentKilometres { get; set; }

        
        public DateTime StartDateTime { get; set; }

        
        public string Location { get; set; }

        
        public string State { get; set; }

        
        public string FinalReport { get; set; } = null!;

        public DateTime EndDateTime { get; set; }

        public DateTime ActiveDatePfPart { get; set; }

        public int CarId { get; set; }
        public int ServiceId { get; set; }

        public string Feedback { get; set; }

        
        public string IsPayed { get; set; }

        [InverseProperty(nameof(Appointment.Tickets))]
        public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();

        [InverseProperty(nameof(Car.Tickets))]
        public virtual Car Cars { get; set; }

        public virtual Service Service { get; set; }
    }

}

