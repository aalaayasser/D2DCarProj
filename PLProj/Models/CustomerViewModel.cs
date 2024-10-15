using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DALProject.Models
{
    public class CustomerViewModel : UserViewModel 
    {
        [Display(Name = "Preferred Communication")]
        public string PrefCommunication { get; set; }

        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
   

}
