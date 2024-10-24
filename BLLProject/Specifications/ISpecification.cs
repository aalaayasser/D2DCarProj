using DALProject.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLLProject.Specifications
{

    public interface ISpecification<T> where T : ModelClass
    {
        public Expression<Func<T, bool>> Criteria { get; set; } 
        public List<Expression<Func<T, object >>> Includes { get; set; }
        public List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> AllIncludes { get; }
    }

}
