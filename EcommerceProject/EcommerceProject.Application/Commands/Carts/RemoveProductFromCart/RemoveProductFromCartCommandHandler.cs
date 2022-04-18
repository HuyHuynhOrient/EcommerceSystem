﻿using EcommerceProject.Domain.AggregatesModel.CartAggregate;
using EcommerceProject.Domain.AggregatesModel.UserAggregate;
using EcommerceProject.Domain.SeedWork;
using EcommerceProject.Infrastructure.CQRS.Command;

namespace EcommerceProject.Application.Commands.Carts.RemoveProductFromCart
{
    public class RemoveProductFromCartCommandHandler : ICommandHandler<RemoveProductFromCartCommand, Guid>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IUserRepository _userRepository;

        public RemoveProductFromCartCommandHandler(ICartRepository cartRepository, IUserRepository userRepository)
        {
            _cartRepository = cartRepository;
            _userRepository = userRepository;
        }

        public async Task<CommandResult<Guid>> Handle(RemoveProductFromCartCommand command, CancellationToken cancellationToken)
        {
            var spec = new SpecificationBase<Cart>(x => x.UserId == command.UserId);
            var cart = await _cartRepository.FindOneAsync(spec, cancellationToken);
            if (cart == null) return CommandResult<Guid>.Error("Do not find a cart with customer id.");

            cart.RemoveCartProduct(command.CartProductId);
            await _cartRepository.SaveAsync(cart, cancellationToken);

            return CommandResult<Guid>.Success(command.UserId);
        }
    }
}
