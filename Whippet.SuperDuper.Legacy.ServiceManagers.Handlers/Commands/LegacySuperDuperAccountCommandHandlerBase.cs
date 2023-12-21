using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Commands;
using Athi.Whippet.SuperDuper.Legacy.Repositories;

namespace Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Base class for <see cref="ILegacySuperDuperAccountCommand"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="ILegacySuperDuperAccountCommand"/> object type to handle.</typeparam>
    public abstract class LegacySuperDuperAccountCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, ILegacySuperDuperAccountCommandHandler<TCommand>
        where TCommand : ILegacySuperDuperAccountCommand
    {
        /// <summary>
        /// Gets or sets the internal <see cref="ILegacySuperDuperAccountRepository"/> to execute the commands against.
        /// </summary>
        protected ILegacySuperDuperAccountRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegacySuperDuperAccountCommandHandlerBase{TCommand}"/> class with the specified <see cref="ILegacySuperDuperAccountRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ILegacySuperDuperAccountRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected LegacySuperDuperAccountCommandHandlerBase(ILegacySuperDuperAccountRepository repository)
            : base()
        {
            ArgumentNullException.ThrowIfNull(repository);
            Repository = repository;
        }
    }
}
