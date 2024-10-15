using BLLProject.Interfaces;
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
        public int Add(T entity)
        {
            dbContect.Add(entity);
            return dbContect.SaveChanges();
        }

        public int Delete(T entity)
        {
            dbContect.Remove(entity);
            return dbContect.SaveChanges();
        }

        public T Get(int Id)
        {
            return dbContect.Set<T>().Find(Id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbContect.Set<T>().AsNoTracking().ToList();
        }

        public int Update(T entity)
        {
            dbContect.Set<T>().Update(entity);
            return dbContect.SaveChanges();
        }



    }
}
