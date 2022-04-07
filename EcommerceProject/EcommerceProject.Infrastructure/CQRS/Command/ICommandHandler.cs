using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Infrastructure.CQRS.Command
{
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, CommandResult<TResponse>>
        where TCommand : IRequest<CommandResult<TResponse>>
    {

    }
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, CommandResult>
        where TCommand : IRequest<CommandResult>
    {

    }
}
