using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Commands
{
    /// <summary>
    /// Provides support for commands that act upon <see cref="ILegacyDigitalLibraryServer"/> objects.
    /// </summary>
    public interface ILegacyDigitalLibraryServerCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="ILegacyDigitalLibraryServer"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public ILegacyDigitalLibraryServer Server
        { get; }
    }
}
