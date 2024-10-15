using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Models
{
    public class Color : ModelClass
    {
        
        public string Name { get; set; }

        public virtual ICollection<Car> Car { get; set; } = new HashSet<Car>();

    }
}
