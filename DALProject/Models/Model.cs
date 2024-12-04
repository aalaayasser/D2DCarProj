using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Models
{
    public class Model : ModelClass
    {
        //public int Id { get; set; }
        
        public string Name { get; set; }

       
        public int BrandId { get; set; }

        
        

        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
        public virtual Brand Brand { get; set; } = null!;

        public virtual ICollection<Part> Parts { get; set; } = new HashSet<Part>();
    }
}
