using DALProject;
using DALProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLProject.Repositories
{
    public class CustomerRepository : GenericRopository<Customer>
    {
        public CustomerRepository(CarAppDbContext dbContext) : base(dbContext) 
        {
            
        }

    }
}
