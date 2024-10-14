using System.Collections.Generic;

namespace DALProject.Models
{
    public class Technician : Employee
    {

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    }
}
