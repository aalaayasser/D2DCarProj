﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DALProject.Models
{
    public class Customer : User
    {
        [Display(Name = "Preferred Communication")]
        [Required]
        public string PrefCommunication { get; set; }

        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
   

}
