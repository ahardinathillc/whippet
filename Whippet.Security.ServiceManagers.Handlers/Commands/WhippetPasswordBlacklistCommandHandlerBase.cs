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
    /// Base class for <see cref="IWhippetPasswordBlacklistCommand"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetPasswordBlacklistCommand"/> type to handle.</typeparam>
    public abstract class WhippetPasswordBlacklistCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, IWhippetPasswordBlacklistCommandHandler<TCommand>
        where TCommand : IWhippetPasswordBlacklistCommand
    {
        /// <summary>
        /// Gets or sets the internal <see cref="IWhippetPasswordBlacklistRepository"/> to execute the commands against.
        /// </summary>
        protected IWhippetPasswordBlacklistRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPasswordBlacklistCommandHandlerBase{TCommand}"/> class with the specified <see cref="IWhippetPasswordBlacklistRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetPasswordBlacklistRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetPasswordBlacklistCommandHandlerBase(IWhippetPasswordBlacklistRepository repository)
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
