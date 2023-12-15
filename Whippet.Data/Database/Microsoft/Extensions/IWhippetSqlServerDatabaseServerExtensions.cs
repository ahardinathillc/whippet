using System;
using System.Collections.Generic;

namespace Athi.Whippet.Data.Database.Microsoft.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IWhippetSqlServerDatabaseServer"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IWhippetSqlServerDatabaseServerExtensions
    {
        /// <summary>
        /// Imports the configuration settings of a <see cref="IWhippetSqlServerDatabaseServer"/> into the specified base <see cref="IWhippetSqlServerDatabaseServer"/>.
        /// </summary>
        /// <param name="baseServer">Base <see cref="IWhippetSqlServerDatabaseServer"/> object.</param>
        /// <param name="toImport"><see cref="ImportWhippetSqlServerDatabaseServer"/> object to import.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ImportWhippetSqlServerDatabaseServer(this IWhippetSqlServerDatabaseServer baseServer, IWhippetSqlServerDatabaseServer toImport)
        {
            if (baseServer == null)
            {
                throw new ArgumentNullException(nameof(baseServer));
            }
            else if (toImport == null)
            {
                throw new ArgumentNullException(nameof(toImport));
            }
            else
            {
                baseServer.IntegratedSecurity = toImport.IntegratedSecurity;
                baseServer.Database = toImport.Database;
                baseServer.MultipleActiveResultSets = toImport.MultipleActiveResultSets;
                baseServer.Mirror = toImport.Mirror;
                baseServer.AttachDBFilename = toImport.AttachDBFilename;
                baseServer.PacketSize = toImport.PacketSize;
                baseServer.Authentication = toImport.Authentication;
                baseServer.ApplicationName = toImport.ApplicationName;
                baseServer.ApplicationIntent = toImport.ApplicationIntent;
                baseServer.ColumnEncryptionSetting = toImport.ColumnEncryptionSetting;
                baseServer.CommandTimeout = toImport.CommandTimeout;
                baseServer.ConnectRetryCount = toImport.ConnectRetryCount;
                baseServer.ConnectRetryInterval = toImport.ConnectRetryInterval;
                baseServer.ConnectTimeout = toImport.ConnectTimeout;
                baseServer.CurrentLanguage = toImport.CurrentLanguage;
                baseServer.AttestationProtocol = toImport.AttestationProtocol;
                baseServer.EnclaveAttestationUrl = toImport.EnclaveAttestationUrl;
                baseServer.IPAddressPreference = toImport.IPAddressPreference;
                baseServer.Encrypt = toImport.Encrypt;
                baseServer.Enlist = toImport.Enlist;
                baseServer.LoadBalanceTimeout = toImport.LoadBalanceTimeout;
                baseServer.MaxPoolSize = toImport.MaxPoolSize;
                baseServer.MinPoolSize = toImport.MinPoolSize;
                baseServer.MultiSubnetFailover = toImport.MultiSubnetFailover;
                baseServer.PersistSecurityInfo = toImport.PersistSecurityInfo;
                baseServer.PoolBlockingPeriod = toImport.PoolBlockingPeriod;
                baseServer.Pooling = toImport.Pooling;
                baseServer.Replication = toImport.Replication;
                baseServer.TransactionBinding = toImport.TransactionBinding;
                baseServer.TrustServerCertificate = toImport.TrustServerCertificate;
                baseServer.TypeSystemVersion = toImport.TypeSystemVersion;
                baseServer.UserInstance = toImport.UserInstance;
                baseServer.WorkstationID = toImport.WorkstationID;            
            }
        }

        /// <summary>
        /// Creates a default <see cref="DatabaseConnectionPropertyVisibilityMask"/> instance for the specified <see cref="IWhippetSqlServerDatabaseServer"/> object.
        /// </summary>
        /// <param name="server"><see cref="IWhippetSqlServerDatabaseServer"/> object to create mask for.</param>
        /// <returns><see cref="DatabaseConnectionPropertyVisibilityMask"/> object.</returns>
        public static DatabaseConnectionPropertyVisibilityMask CreateDefaultPropertyVisibilityMask(this IWhippetSqlServerDatabaseServer server)
        {
            Dictionary<string, bool> dict = new Dictionary<string, bool>();

            dict.Add(nameof(IWhippetSqlServerDatabaseServer.IntegratedSecurity), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.Database), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.MultipleActiveResultSets), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.AttachDBFilename), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.PacketSize), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.Authentication), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.ApplicationName), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.ApplicationIntent), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.ColumnEncryptionSetting), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.CommandTimeout), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.ConnectRetryCount), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.ConnectTimeout), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.CurrentLanguage), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.AttestationProtocol), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.EnclaveAttestationUrl), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.IPAddressPreference), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.Encrypt), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.Enlist), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.LoadBalanceTimeout), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.MaxPoolSize), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.MinPoolSize), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.MultiSubnetFailover), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.PersistSecurityInfo), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.PoolBlockingPeriod), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.Pooling), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.Replication), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.TransactionBinding), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.TrustServerCertificate), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.TypeSystemVersion), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.UserInstance), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.WorkstationID), true);
            dict.Add(nameof(IWhippetSqlServerDatabaseServer.Mirror), true);

            return new DatabaseConnectionPropertyVisibilityMask(dict);
        }

        /// <summary>
        /// Creates a default <see cref="HashCode"/> instance for the given <see cref="IWhippetSqlServerDatabaseServer"/>.
        /// </summary>
        /// <param name="server"><see cref="IWhippetSqlServerDatabaseServer"/> object to create <see cref="HashCode"/> for.</param>
        /// <returns><see cref="HashCode"/> object.</returns>
        public static HashCode GenerateDefaultHashCode(this IWhippetSqlServerDatabaseServer server)
        {
            HashCode hash = new HashCode();

            if (server != null)
            {
                hash.Add(server.IntegratedSecurity);
                hash.Add(server.Database);
                hash.Add(server.MultipleActiveResultSets);
                hash.Add(server.AttachDBFilename);
                hash.Add(server.PacketSize);
                hash.Add(server.Authentication);
                hash.Add(server.ApplicationName);
                hash.Add(server.ApplicationIntent);
                hash.Add(server.ColumnEncryptionSetting);
                hash.Add(server.CommandTimeout);
                hash.Add(server.ConnectRetryCount);
                hash.Add(server.ConnectTimeout);
                hash.Add(server.CurrentLanguage);
                hash.Add(server.AttestationProtocol);
                hash.Add(server.EnclaveAttestationUrl);
                hash.Add(server.IPAddressPreference);
                hash.Add(server.Encrypt);
                hash.Add(server.Enlist);
                hash.Add(server.LoadBalanceTimeout);
                hash.Add(server.MaxPoolSize);
                hash.Add(server.MinPoolSize);
                hash.Add(server.MultiSubnetFailover);
                hash.Add(server.PersistSecurityInfo);
                hash.Add(server.PoolBlockingPeriod);
                hash.Add(server.Pooling);
                hash.Add(server.Replication);
                hash.Add(server.TransactionBinding);
                hash.Add(server.TrustServerCertificate);
                hash.Add(server.TypeSystemVersion);
                hash.Add(server.UserInstance);
                hash.Add(server.WorkstationID);
                hash.Add(server.Mirror);
            }

            return hash;
        }
    }
}
