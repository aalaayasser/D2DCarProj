﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Models
{
    public enum StateType
    {
        New = 1,
        Assigned = 2,
        Finished = 3
    }
    public class Ticket : ModelClass
    {
        //public int Id { get; set; }
        
        public long  CurrentKilometres { get; set; }    
        public DateTime? StartDateTime { get; set; }    
        public string Location { get; set; }    
        public virtual StateType stateType { get; set; }     
        public string? FinalReport { get; set; } = null!;
        public DateTime? EndDateTime { get; set; }
        public string Feedback { get; set; }


        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

        //public virtual ICollection<Service> Services { get; set; } = new HashSet<Service>();
        //public virtual ICollection<Part> Parts { get; set; } = new HashSet<Part>();


        //[InverseProperty(nameof(Appointment.Tickets))]
        public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();

        //[InverseProperty(nameof(Car.Tickets))]
        public int CarId { get; set; }
        public virtual Car Cars { get; set; }


        //public int InvoiceId { get; set; }
        //public virtual Invoice Invoice { get; set; }
        
    }

}

