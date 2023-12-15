using System;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.Data.Database.Microsoft.Extensions;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ILegacyDigitalLibraryServer"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ILegacyDigitalLibraryServerExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ILegacyDigitalLibraryServer"/> object to a <see cref="LegacyDigitalLibraryServer"/> object.
        /// </summary>
        /// <param name="server"><see cref="ILegacyDigitalLibraryServer"/> object to convert.</param>
        /// <returns><see cref="LegacyDigitalLibraryServer"/> object.</returns>
        public static LegacyDigitalLibraryServer ToLegacyDigitalLibraryServer(this ILegacyDigitalLibraryServer server)
        {
            LegacyDigitalLibraryServer sddlServer = null;

            if (server is LegacyDigitalLibraryServer)
            {
                sddlServer = (LegacyDigitalLibraryServer)(server);
            }
            else
            {
                sddlServer = new LegacyDigitalLibraryServer(
                    server.ID,
                    server.Name,
                    server.Username,
                    server.Password,
                    server.Tenant.ToWhippetTenant(),
                    server.Active,
                    server.Deleted,
                    server.CreatedDateTime,
                    server.CreatedBy,
                    server.LastModifiedDateTime,
                    server.LastModifiedBy
                );

                sddlServer.ImportWhippetSqlServerDatabaseServer(server);
                sddlServer.Mirror = (server.Mirror == null ? null : server.Mirror.ToLegacyDigitalLibraryServer());
            }

            return sddlServer;
        }
    }
}
