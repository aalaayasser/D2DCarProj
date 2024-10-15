using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DALProject.Models
{
    public class CustomerViewModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }

        [Display(Name = "Contact Number")]
        public long ContactNumber { get; set; }
        [Display(Name = "Preferred Communication")]
        public string PrefCommunication { get; set; }

        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
   

}
