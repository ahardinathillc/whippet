using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Extensions.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.AccessControl.Repositories;
using Athi.Whippet.Security.AccessControl.ServiceManagers.Commands;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Base class for <see cref="IWhippetRoleCommand"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetRoleCommand"/> type to handle.</typeparam>
    public abstract class WhippetRoleCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, IWhippetRoleCommandHandler<TCommand>
        where TCommand : IWhippetRoleCommand
    {
        /// <summary>
        /// Gets or sets the internal <see cref="IWhippetRoleRepository"/> to execute the commands against.
        /// </summary>
        protected IWhippetRoleRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRoleCommandHandlerBase{TCommand}"/> class with the specified <see cref="IWhippetRoleRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetRoleRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetRoleCommandHandlerBase(IWhippetRoleRepository repository)
            : base()
        {
            if (repository == null)
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
