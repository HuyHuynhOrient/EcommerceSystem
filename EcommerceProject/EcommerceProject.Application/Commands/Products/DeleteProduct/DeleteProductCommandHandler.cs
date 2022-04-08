using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
using EcommerceProject.Infrastructure.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Commands.Products.DeleteProduct
{
    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, int>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<CommandResult<int>> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindOneAsync(command.Id, cancellationToken);
            await _productRepository.DeleteAsync(product);
            return CommandResult<int>.Success(product.Id);
        }
    }
}
