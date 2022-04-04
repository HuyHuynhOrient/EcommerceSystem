using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Domain.Core
{
    public interface IRepository<TAggregateRoot, in TId> where TAggregateRoot : AggregateRoot<TId>
    {
        Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync(ISpecification<TAggregateRoot> specification, CancellationToken cancellationToken = default);
        
        Task<TAggregateRoot> FindOneAsync(TId id, CancellationToken cancellationToken = default);
        
        Task<TAggregateRoot> FineOneAsync(ISpecification<TAggregateRoot> specification, CancellationToken cancellationToken = default);
        
        Task<IEnumerable<TAggregateRoot>> FindAllAsync(ISpecification<TAggregateRoot> specification,
            CancellationToken cancellationToken = default);
        
        Task AddAsync(TAggregateRoot aggregate, CancellationToken cancellationToken = default);
        
        Task SaveAsync(TAggregateRoot aggregate, CancellationToken cancellationToken = default);
        
        Task DeleteAsync(TAggregateRoot aggregate, CancellationToken cancellationToken = default);
    }
}
