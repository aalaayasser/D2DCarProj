using BLLProject.Interfaces;
using DALProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLProject.Repositories
{
    public class GenericRopository<T> : IGenericRepository<T> where T : ModelClass
    {




    }
}
