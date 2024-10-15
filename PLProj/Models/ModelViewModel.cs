﻿using PLProj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Models
{
    public class ModelViewModel : ModelBase
    {
        //public int Id { get; set; }
        

        
        public string Name { get; set; }

        [Display(Name = "Brand ID")]
        public int BrandId { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Updated Date")]
        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
        public virtual Brand Brand { get; set; } = null!;
       
        public virtual ICollection<PartViewModel> Parts { get; set; } = new HashSet<PartViewModel>();
    }
}
