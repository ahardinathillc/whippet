using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="LegacyDigitalLibraryServer"/> objects. This class must be inherited.
    /// </summary>
    public abstract class LegacyDigitalLibraryServerCommandBase : WhippetCommand, IWhippetCommand, ILegacyDigitalLibraryServerCommand
    {
        /// <summary>
        /// Gets the <see cref="LegacyDigitalLibraryServer"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public LegacyDigitalLibraryServer Server
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="ILegacyDigitalLibraryServer"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        ILegacyDigitalLibraryServer ILegacyDigitalLibraryServerCommand.Server
        {
            get
            {
                return Server;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegacyDigitalLibraryServerCommandBase"/> class with no arguments.
        /// </summary>
        protected LegacyDigitalLibraryServerCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegacyDigitalLibraryServerCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="server"><see cref="LegacyDigitalLibraryServer"/> instance to create or act upon in the data store.</param>
        protected LegacyDigitalLibraryServerCommandBase(LegacyDigitalLibraryServer server)
            : base()
        {
            Server = server;
        }
    }
}
