using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Models
{
    public class Car : ModelClass
    {
        
        
        public int ModelId { get; set; }

        
        
        public int CustomerId { get; set; }

        
        public int ColorId { get; set; }
        
        public long KiloMetres { get; set; }

        
        public DateTime Year { get; set; }

       
        public string? Description { get; set; }

        

        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();

        public virtual Customer Customer { get; set; } = null!;
        public virtual Color Color { get; set; } = null!;
        public virtual Model Model { get; set; } = null!;

    }
}
