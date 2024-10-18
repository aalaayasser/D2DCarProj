using DALProject.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BLLProject.Specifications
{
    public class BaseSpecification<T> : ISpecification<T> where T : ModelClass
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set ; } = new
            List<Expression<Func<T, object>>>();
		public List<string> ThenIncludes { get; set; } = new List<string>();
		public BaseSpecification()
        {
           
        }

        public BaseSpecification(Expression<Func<T, bool>> CriteriaExpression )
        {
            Criteria = CriteriaExpression;
        }
    }

}
