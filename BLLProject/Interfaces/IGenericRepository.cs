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
        public int Add(T entity);


        public int Delete(T entity);


        public T Get(int Id);


        public IEnumerable<T> GetAll();


        public int Update(T entity);
    }
}
