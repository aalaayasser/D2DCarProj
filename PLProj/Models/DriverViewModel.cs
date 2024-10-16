using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DALProject.Models
{
    public class  DriverViewModel 
    {

        public int Id { get; set; }
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        [Display(Name = "Contact Number")]
        public long ContactNumber { get; set; }

        public string Availability { get; set; }

        public DateTime BirthDate { get; set; } // .net 5 not support date only
        public string License  { get; set; }

        [Display(Name = "License Date")]
        public DateTime LicenseDate { get; set; }

        [Display(Name = "License Expiry Date")]
        public DateTime LicenseExpDate { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();

        #region Mapping

        public static explicit operator DriverViewModel(Driver model)
        {
            return new DriverViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Street = model.Street,
                ContactNumber = model.ContactNumber,
                City = model.City,
                Email = model.Email,
                Availability = model.Availability,
                BirthDate = model.BirthDate,
                License = model.License,
                LicenseDate = model.LicenseDate,
                LicenseExpDate = model.LicenseExpDate,
                Appointments = model.Appointments
            };
        }

        public static explicit operator Driver(DriverViewModel ViewModel)
        {
            return new Driver
            {
                Id = ViewModel.Id,
                Name = ViewModel.Name,
                Street = ViewModel.Street,
                ContactNumber = ViewModel.ContactNumber,
                City = ViewModel.City,
                Email = ViewModel.Email,
                Availability = ViewModel.Availability,
                BirthDate = ViewModel.BirthDate,
                License = ViewModel.License,
                LicenseDate = ViewModel.LicenseDate,
                LicenseExpDate = ViewModel.LicenseExpDate,
            };
        }

        #endregion
    }


}
