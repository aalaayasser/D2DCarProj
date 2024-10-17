using BLLProject.Specifications;
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
        public void Add(T entity);


        public void Delete(T entity);


        public T Get(int Id);


        public IEnumerable<T> GetAll();


        public void Update(T entity);
        public T GetEntityWithSpec(ISpecification<T> spec);

        public IEnumerable<T> GetAllWithSpec(ISpecification<T> spec);

    }
}
