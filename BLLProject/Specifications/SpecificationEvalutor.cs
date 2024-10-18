using DALProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BLLProject.Specifications
{
    public static class SpecificationEvalutor<TEntity> where TEntity : ModelClass
    {
      
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> input  , ISpecification<TEntity> spec)
        {
            var query = input; 
            if (spec.Criteria is not null)
                query = query.Where(spec.Criteria);

            query = spec.Includes.Aggregate(query, (Current, IncludeExpression) => Current.Include(IncludeExpression));

			foreach (var thenInclude in spec.ThenIncludes)
			{
				query = query.Include(thenInclude); 
			}

			return query;
		}

    }

}
