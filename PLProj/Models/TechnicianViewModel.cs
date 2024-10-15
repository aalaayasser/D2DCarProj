using System.Collections.Generic;

namespace DALProject.Models
{
    public class TechnicianViewModel : EmployeeViewModel
    {

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    }
}
