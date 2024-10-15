using System;
using System.ComponentModel.DataAnnotations;

namespace DALProject.Models
{
    abstract public class Employee : User
    {
        
        public string Availability { get; set; }

        public DateTime BirthDate  { get; set; } // .net 5 not support date only
    }
   

}
