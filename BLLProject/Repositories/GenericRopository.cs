using BLLProject.Interfaces;
using BLLProject.Specifications;
using DALProject;
using DALProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLProject.Repositories
{
    public class GenericRopository<T> : IGenericRepository<T> where T : ModelClass
    {
        public readonly CarAppDbContext dbContect;

        public GenericRopository(CarAppDbContext dbContect)
        {
            this.dbContect = dbContect;
        }
        public void Add(T entity)
        {
            dbContect.Add(entity);
            
        }

        public void Delete(T entity)
        {
            dbContect.Remove(entity);
            
        }
        public void Update(T entity)
        {
            dbContect.Set<T>().Update(entity);
            
        }


        public T Get(int Id)
        {
            return dbContect.Set<T>().Find(Id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbContect.Set<T>().AsNoTracking().ToList();
        }

       
        public T GetEntityWithSpec(ISpecification<T> spec) =>
             SpecificationEvalutor<T>.GetQuery(dbContect.Set<T>(), spec).FirstOrDefault();

        public IEnumerable<T> GetAllWithSpec(ISpecification<T> spec) =>
             SpecificationEvalutor<T>.GetQuery(dbContect.Set<T>(), spec).AsNoTracking().ToList();
    }
}
