using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Display(Name = "Model ID")]
        
        public int? ModelId { get; set; }

        [Display(Name = "Customer ID")]
        
        public int? CustomerId { get; set; }

        [Display(Name = "Color ID")]
        public int? ColorId { get; set; }
        [Required]

        [Display(Name = "Kilometres")]
        public long KiloMetres { get; set; }

        [Display(Name = "Year of Manufacture")]
        public DateTime Year { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        

        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();

        public virtual Customer Customer { get; set; } = null!;
        public virtual Color Color { get; set; } = null!;
        public virtual Model Model { get; set; } = null!;

    }
}
