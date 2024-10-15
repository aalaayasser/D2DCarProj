using PLProj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Models
{
    public class ModelViewModel 
    {
        public int Id { get; set; }
        

        
        public string Name { get; set; }

        [Display(Name = "Brand ID")]
        public int BrandId { get; set; }

      

        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
        public virtual Brand Brand { get; set; } = null!;
       
        public virtual ICollection<Part> Parts { get; set; } = new HashSet<Part>();

        #region Mapping

        public static explicit operator ModelViewModel(Model model)
        {
            return new ModelViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Brand = model.Brand,
                
                BrandId = model.BrandId,
                Cars = model.Cars,
                Parts = model.Parts
                
            };
        }

        public static explicit operator Model(ModelViewModel viewModel)
        {
            return new Model
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                 BrandId = viewModel.BrandId,
               
            };
        }

        #endregion
    }
}
