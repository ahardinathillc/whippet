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
    /// Base class for <see cref="IWhippetIpAddressBlacklistCommand"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetIpAddressBlacklistCommand"/> type to handle.</typeparam>
    public abstract class WhippetIpAddressBlacklistCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, IWhippetIpAddressBlacklistCommandHandler<TCommand>
        where TCommand : IWhippetIpAddressBlacklistCommand
    {
        /// <summary>
        /// Gets or sets the internal <see cref="IWhippetIpAddressBlacklistRepository"/> to execute the commands against.
        /// </summary>
        protected IWhippetIpAddressBlacklistRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetIpAddressBlacklistCommandHandlerBase{TCommand}"/> class with the specified <see cref="IWhippetIpAddressBlacklistRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetIpAddressBlacklistRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetIpAddressBlacklistCommandHandlerBase(IWhippetIpAddressBlacklistRepository repository)
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
