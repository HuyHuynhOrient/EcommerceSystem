using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Domain.Core
{
    public interface IUnitOfWork
    {
        Task ExecuteAsync(Func<Task> action, CancellationToken cancellationToken = default);
        Task<TResponse> ExecuteAsync<TResponse>(Func<Task<TResponse>> action,
            CancellationToken cancellationToken = default);
    }
}
