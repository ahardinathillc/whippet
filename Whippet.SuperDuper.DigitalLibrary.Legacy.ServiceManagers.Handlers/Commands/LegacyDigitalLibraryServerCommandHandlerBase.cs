using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Commands;
using Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.Repositories;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Base class for <see cref="ILegacyDigitalLibraryServerCommand"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="ILegacyDigitalLibraryServerCommand"/> object type to handle.</typeparam>
    public abstract class LegacyDigitalLibraryServerCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, ILegacyDigitalLibraryServerCommandHandler<TCommand>
        where TCommand : ILegacyDigitalLibraryServerCommand
    {
        /// <summary>
        /// Gets or sets the internal <see cref="ILegacyDigitalLibraryServerRepository"/> to execute the commands against.
        /// </summary>
        protected ILegacyDigitalLibraryServerRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegacyDigitalLibraryServerCommandHandlerBase{TCommand}"/> class with the specified <see cref="ILegacyDigitalLibraryServerRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ILegacyDigitalLibraryServerRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected LegacyDigitalLibraryServerCommandHandlerBase(ILegacyDigitalLibraryServerRepository repository)
            : base()
        {
            ArgumentNullException.ThrowIfNull(repository);
            Repository = repository;
        }
    }
}
