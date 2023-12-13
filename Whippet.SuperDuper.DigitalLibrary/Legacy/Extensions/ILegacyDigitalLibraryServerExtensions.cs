using System;
using Athi.Whippet.Security.Tenants.Extensions;

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

                sddlServer.IntegratedSecurity = server.IntegratedSecurity;
                sddlServer.Database = server.Database;
                sddlServer.MultipleActiveResultSets = server.MultipleActiveResultSets;
                sddlServer.Mirror = (server.Mirror == null ? null : server.Mirror.ToLegacyDigitalLibraryServer());
                sddlServer.AttachDBFilename = server.AttachDBFilename;
                sddlServer.PacketSize = server.PacketSize;
                sddlServer.Authentication = server.Authentication;
                sddlServer.ApplicationName = server.ApplicationName;
                sddlServer.ApplicationIntent = server.ApplicationIntent;
                sddlServer.ColumnEncryptionSetting = server.ColumnEncryptionSetting;
                sddlServer.CommandTimeout = server.CommandTimeout;
                sddlServer.ConnectRetryCount = server.ConnectRetryCount;
                sddlServer.ConnectRetryInterval = server.ConnectRetryInterval;
                sddlServer.ConnectTimeout = server.ConnectTimeout;
                sddlServer.CurrentLanguage = server.CurrentLanguage;
                sddlServer.AttestationProtocol = server.AttestationProtocol;
                sddlServer.EnclaveAttestationUrl = server.EnclaveAttestationUrl;
                sddlServer.IPAddressPreference = server.IPAddressPreference;
                sddlServer.Encrypt = server.Encrypt;
                sddlServer.Enlist = server.Enlist;
                sddlServer.LoadBalanceTimeout = server.LoadBalanceTimeout;
                sddlServer.MaxPoolSize = server.MaxPoolSize;
                sddlServer.MinPoolSize = server.MinPoolSize;
                sddlServer.MultiSubnetFailover = server.MultiSubnetFailover;
                sddlServer.PersistSecurityInfo = server.PersistSecurityInfo;
                sddlServer.PoolBlockingPeriod = server.PoolBlockingPeriod;
                sddlServer.Pooling = server.Pooling;
                sddlServer.Replication = server.Replication;
                sddlServer.TransactionBinding = server.TransactionBinding;
                sddlServer.TrustServerCertificate = server.TrustServerCertificate;
                sddlServer.TypeSystemVersion = server.TypeSystemVersion;
                sddlServer.UserInstance = server.UserInstance;
                sddlServer.WorkstationID = server.WorkstationID;
            }

            return sddlServer;
        }
    }
}
