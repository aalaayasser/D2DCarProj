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

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Updated Date")]
        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
        public virtual Brand Brand { get; set; } = null!;
       
        public virtual ICollection<PartViewModel> Parts { get; set; } = new HashSet<PartViewModel>();

        #region Mapping

        public static explicit operator ModelViewModel(Model model)
        {
            return new ModelViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Brand = model.Brand,
                CreatedDate = model.CreatedDate,
                UpdatedDate = model.UpdatedDate,
                BrandId = model.BrandId,
                Cars = model.Cars,
                Parts = model.Parts.Select(part => new PartViewModel
                {
                    Id = part.Id,
                    PartName = part.PartName,
                    Price = part.Price,
                    PartKilometresToChange = part.PartKilometresToChange
                }).ToList()
            };
        }

        public static explicit operator Model(ModelViewModel viewModel)
        {
            return new Model
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Brand = viewModel.Brand,
                CreatedDate = viewModel.CreatedDate,
                UpdatedDate = viewModel.UpdatedDate,
                BrandId = viewModel.BrandId,
                Cars = viewModel.Cars,
                Parts = viewModel.Parts.Select(partViewModel => new Part
                {
                    Id = partViewModel.Id,
                    PartName = partViewModel.PartName,
                    Price = partViewModel.Price,
                    PartKilometresToChange = partViewModel.PartKilometresToChange
                }).ToList()
            };
        }

        #endregion
    }
}
