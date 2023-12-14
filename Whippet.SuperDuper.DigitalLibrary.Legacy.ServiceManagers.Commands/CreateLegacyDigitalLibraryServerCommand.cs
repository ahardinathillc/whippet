using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="LegacyDigitalLibraryServer"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateLegacyDigitalLibraryServerCommand : LegacyDigitalLibraryServerCommandBase, ILegacyDigitalLibraryServerCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLegacyDigitalLibraryServerCommand"/> class with the specified <see cref="LegacyDigitalLibraryServer"/> object.
        /// </summary>
        /// <param name="server"><see cref="LegacyDigitalLibraryServer"/> object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateLegacyDigitalLibraryServerCommand(LegacyDigitalLibraryServer server)
            : base(server)
        {
            ArgumentNullException.ThrowIfNull(server);
        }
    }
}
