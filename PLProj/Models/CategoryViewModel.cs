using PLProj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Models
{
    public class CategoryViewModel 
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Technician> Technician { get; set; } = new HashSet<Technician>();
        public virtual ICollection<Service> Services { get; set; } = new HashSet<Service>();


        #region Mapping
        public static explicit operator CategoryViewModel(Category model)
        {
            return new CategoryViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Technician = model.Technician,
                Services = model.Services
            };
        }

        public static explicit operator Category(CategoryViewModel viewModel)
        {
            return new Category
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
               
            };
        }
        #endregion
    }

}

