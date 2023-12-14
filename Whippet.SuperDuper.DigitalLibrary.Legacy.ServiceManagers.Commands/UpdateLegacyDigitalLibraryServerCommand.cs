using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="LegacyDigitalLibraryServer"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateLegacyDigitalLibraryServerCommand : LegacyDigitalLibraryServerCommandBase, ILegacyDigitalLibraryServerCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateLegacyDigitalLibraryServerCommand"/> class with the specified <see cref="LegacyDigitalLibraryServer"/> object.
        /// </summary>
        /// <param name="server"><see cref="LegacyDigitalLibraryServer"/> object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateLegacyDigitalLibraryServerCommand(LegacyDigitalLibraryServer server)
            : base(server)
        {
            ArgumentNullException.ThrowIfNull(server);
        }
    }
}
