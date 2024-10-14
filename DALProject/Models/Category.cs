using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Technician> Technician { get; set; } = new HashSet<Technician>();
        public virtual ICollection<Service> Services { get; set; } = new HashSet<Service>();

    }
}
