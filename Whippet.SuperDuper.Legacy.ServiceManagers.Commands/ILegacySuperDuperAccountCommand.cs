using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Commands
{
    /// <summary>
    /// Provides support for commands that act upon <see cref="ILegacySuperDuperAccount"/> objects.
    /// </summary>
    public interface ILegacySuperDuperAccountCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="ILegacySuperDuperAccount"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public ILegacySuperDuperAccount Account
        { get; }
    }
}
