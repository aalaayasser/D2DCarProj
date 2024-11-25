﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DALProject.Models
{
    public class Customer :  ModelClass
    {
        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
        public string AppUserId { get; set; }
    }
}
