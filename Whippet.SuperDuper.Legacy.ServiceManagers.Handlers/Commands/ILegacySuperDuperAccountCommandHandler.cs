using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Commands;

namespace Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Provides support for all <see cref="ILegacySuperDuperAccountCommand"/> command handlers.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="ILegacySuperDuperAccountCommand"/> object type to handle.</typeparam>
    public interface ILegacySuperDuperAccountCommandHandler<TCommand> : IWhippetCommandHandler<TCommand>
        where TCommand : ILegacySuperDuperAccountCommand
    { }
}
