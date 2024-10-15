﻿using System;

namespace DALProject.Models
{
    abstract public class EmployeeViewModel : User
    {
        public string Availability { get; set; }

        public DateTime BirthDate  { get; set; } // .net 5 not support date only
    }
   

}