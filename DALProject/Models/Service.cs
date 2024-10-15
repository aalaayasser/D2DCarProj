using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Models
{
    public class Service : ModelClass
    {
        //public int Id { get; set; }
        
        public string Name { get; set; }

       
        public decimal Price{ get; set; }
        public DataType EstimatedTime{ get; set; }
        public string? Description{ get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }





}

