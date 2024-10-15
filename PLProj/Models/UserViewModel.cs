using PLProj.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Models
{
    abstract  public class UserViewModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }

        [Display(Name = "Contact Number")]
        public long ContactNumber { get; set; }
    }
   

}
