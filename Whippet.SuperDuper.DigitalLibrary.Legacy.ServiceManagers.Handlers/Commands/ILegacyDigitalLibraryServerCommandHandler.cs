using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Commands;
using Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.Repositories;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Provides support for all <see cref="ILegacyDigitalLibraryServerCommand"/> command handlers.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="ILegacyDigitalLibraryServerCommand"/> object type to handle.</typeparam>
    public interface ILegacyDigitalLibraryServerCommandHandler<TCommand> : IWhippetCommandHandler<TCommand>
        where TCommand : ILegacyDigitalLibraryServerCommand
    {
        
    }
}
