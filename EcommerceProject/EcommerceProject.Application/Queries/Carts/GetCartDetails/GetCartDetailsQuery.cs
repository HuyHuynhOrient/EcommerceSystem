using EcommerceProject.Infrastructure.CQRS.Queries;
using EcommerceProject.Domain.AggregatesModel.CartAggregate;

namespace EcommerceProject.Application.Queries.Carts.GetCartDetails
{
    public class GetCartDetailsQuery : IQuery<Cart>
    {
        public int CartId { get; init; }
        public Guid CustomerId { get; init; }
    }
}
