using PLProj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Models
{
    public class CategoryViewModel 
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<TechnicianViewModel> Technician { get; set; } = new HashSet<TechnicianViewModel>();
        public virtual ICollection<ServiceViewModel> Services { get; set; } = new HashSet<ServiceViewModel>();

    }
}
