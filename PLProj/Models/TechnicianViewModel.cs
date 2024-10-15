using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DALProject.Models
{
    public class TechnicianViewModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }

        [Display(Name = "Contact Number")]
        public long ContactNumber { get; set; }
        public string Availability { get; set; }

        public DateTime BirthDate { get; set; } // .net 5 not support date only
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    }
}
