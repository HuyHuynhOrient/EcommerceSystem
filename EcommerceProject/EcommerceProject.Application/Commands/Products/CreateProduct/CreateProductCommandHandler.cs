using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
using EcommerceProject.Infrastructure.CQRS.Command;

namespace EcommerceProject.Application.Commands.Products.CreateProduct
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<CommandResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product(command.Name, command.Price, command.TradeMark, command.Origin, command.Discription);
            await _productRepository.AddAsync(product, cancellationToken);

            return CommandResult<int>.Success();
        }

    }
}
