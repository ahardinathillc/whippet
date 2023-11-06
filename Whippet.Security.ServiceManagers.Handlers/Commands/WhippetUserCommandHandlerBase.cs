using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Extensions.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.ServiceManagers.Commands;
using Athi.Whippet.Security.Repositories;

namespace Athi.Whippet.Security.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Base class for <see cref="IWhippetUserCommand"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetUserCommand"/> type to handle.</typeparam>
    public abstract class WhippetUserCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, IWhippetUserCommandHandler<TCommand>
        where TCommand : IWhippetUserCommand
    {
        /// <summary>
        /// Gets or sets the internal <see cref="IWhippetUserRepository"/> to execute the commands against.
        /// </summary>
        protected IWhippetUserRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserCommandHandlerBase{TCommand}"/> class with the specified <see cref="IWhippetUserRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetUserRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetUserCommandHandlerBase(IWhippetUserRepository repository)
            : base()
        { 
            if(repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            else
            {
                Repository = repository;
            }
        }
    }
}
