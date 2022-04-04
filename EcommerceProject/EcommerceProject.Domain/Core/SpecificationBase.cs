using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Domain.Core
{
    public class SpecificationBase<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Expression { get; }
        public List<Expression<Func<T, object>>> Includes { get; }
        public SpecificationBase(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
            Includes = new();
        }
    }
}
