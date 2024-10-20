using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DALProject.Models
{
    public class TechnicianViewModel 
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        [Display(Name = "Contact Number")]
        public long ContactNumber { get; set; }
        public string Availability { get; set; }
        public DateTime BirthDate { get; set; } // .net 5 not support date only

        #region Mapping
        public static explicit operator TechnicianViewModel(Technician Model)
        {
            return new TechnicianViewModel
            {
                Id = Model.Id,
                CategoryId = Model.CategoryId,
                Name = Model.Name,
                Email = Model.Email,
                City = Model.City,
                Street = Model.Street,
                ContactNumber = Model.ContactNumber,
                Availability = Model.Availability,
                BirthDate = Model.BirthDate,
            };

        }
        public static explicit operator Technician(TechnicianViewModel ViewModel)
        {
            return new Technician
            {
                Id = ViewModel.Id,
                CategoryId = ViewModel.CategoryId,
                Name = ViewModel.Name,
                Email = ViewModel.Email,
                City = ViewModel.City,
                Street = ViewModel.Street,
                ContactNumber = ViewModel.ContactNumber,
                Availability = ViewModel.Availability,
                BirthDate = ViewModel.BirthDate,
            };

        } 
        #endregion


    }
}
