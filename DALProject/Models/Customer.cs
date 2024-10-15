using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DALProject.Models
{
    public class Customer : User
    {
        
        public string PrefCommunication { get; set; }

        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
   

}
