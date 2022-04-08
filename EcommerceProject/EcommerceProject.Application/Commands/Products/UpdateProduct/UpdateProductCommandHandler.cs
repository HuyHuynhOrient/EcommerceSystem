using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
using EcommerceProject.Infrastructure.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Commands.Products.UpdateProduct
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<CommandResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindOneAsync(command.ProductId, cancellationToken);
            if (product is null) return CommandResult.Error($"Product with id {command.ProductId} does not exist.");

            product.UpdateProduct(command.Name, command.Price, command.TradeMark, command.Origin, command.Discription);

            await _productRepository.SaveAsync(product, cancellationToken);
            return CommandResult.Success();
        }
    }
}
