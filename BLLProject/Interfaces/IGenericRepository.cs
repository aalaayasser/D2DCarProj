using DALProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLProject.Interfaces
{
    public interface IGenericRepository<T> where T : ModelClass
    {
    }
}
