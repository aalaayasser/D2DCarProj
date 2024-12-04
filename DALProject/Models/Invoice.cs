using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Models
{
    public class Invoice : ModelClass
    {


        public DateTime Date { get; set; }

        public Decimal TotalPrice { get; set; }

        //public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
        public virtual ICollection<Payment> Payment { get; set; } = new HashSet<Payment>();




    }
}

