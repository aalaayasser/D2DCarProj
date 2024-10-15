using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Models
{
    public class Part : ModelClass
    {
       
        //public int Id { get; set; }

        
        public string PartName { get; set; }

        
        
        public int Price { get; set; }

        
        public long PartKilometresToChange { get; set; }
        public virtual ICollection<Model> Models { get; set; } = new HashSet<Model>();
    }
}