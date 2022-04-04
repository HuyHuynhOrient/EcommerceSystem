using System.Linq.Expressions;

namespace EcommerceProject.Domain.Core
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Expression { get; }
        List<Expression<Func<T, object>>> Includes { get; }
    }
}