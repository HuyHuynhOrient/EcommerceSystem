using EcommerceProject.Domain.SeedWork;

namespace EcommerceProject.Domain.AggregatesModel.OrderAggregate
{
    public interface IOrderRepository : IBaseRepository<Order, int>
    {
    }
}
