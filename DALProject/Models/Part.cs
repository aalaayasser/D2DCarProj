﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Models
{
    public class Part : ModelClass
    {

       

        public string PartName { get; set; }
        public int Price { get; set; }
        public long PartKilometresToChange { get; set; }
        public string Description { get; set; }


       
        
    }
}