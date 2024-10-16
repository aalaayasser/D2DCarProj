using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DALProject.Models
{
    public class CustomerViewModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        [Display(Name = "Contact Number")]
        public long ContactNumber { get; set; }
        [Display(Name = "Preferred Communication")]
        public string PrefCommunication { get; set; }

        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();

        #region Mapping

        public static explicit operator CustomerViewModel(Customer model)
        {
            return new CustomerViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Cars = model.Cars,
                Street = model.Street,
                ContactNumber = model.ContactNumber,
                City = model.City,
                Email = model.Email,
                PrefCommunication = model.PrefCommunication
            };
        }

        public static explicit operator Customer(CustomerViewModel ViewModel)
        {
            return new Customer
            {
                Id = ViewModel.Id,
                Name = ViewModel.Name,
                Street = ViewModel.Street,
                ContactNumber = ViewModel.ContactNumber,
                City = ViewModel.City,
                Email = ViewModel.Email,
                PrefCommunication = ViewModel.PrefCommunication
            };
        }

        #endregion


    }
   

}
