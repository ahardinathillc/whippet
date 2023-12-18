using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Data.NHibernate.UserTypes;

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

        /// <summary>
        /// Creates a mapping for an <see cref="IWhippetSqlServerDatabaseServer"/> entity.
        /// </summary>
        /// <param name="map"><see cref="WhippetFluentMap{T}"/> object.</param>
        /// <param name="nameDecorator"><see cref="Func{TResult}"/> that decorates the column names to prevent reserved word clashing.</param>
        /// <typeparam name="TEntity"><see cref="IWhippetSqlServerDatabaseServer"/> object that is being mapped.</typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void MapNHibernateColumns<TEntity>(this WhippetFluentMap<TEntity> map, Func<string, string> nameDecorator) where TEntity : WhippetEntity, IWhippetSqlServerDatabaseServer, new()
        {
            if (map == null)
            {
                throw new ArgumentNullException(nameof(map));
            }
            else if (nameDecorator == null)
            {
                throw new ArgumentNullException(nameof(nameDecorator));
            }
            else
            {
                object objectExtension = null;

                map.Map(sdt => sdt.Password).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.Password))).Length(objectExtension.GetMaximumStringLength()).Nullable();
                map.Map(sdt => sdt.Username).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.Username))).Length(objectExtension.GetDefaultStringLength()).Nullable();
                map.Map(ldls => ldls.IntegratedSecurity).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.IntegratedSecurity))).Not.Nullable();
                map.Map(ldls => ldls.Database).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.Database))).Length(objectExtension.GetDefaultEntityNameMaxLength()).Nullable();
                map.Map(ldls => ldls.MultipleActiveResultSets).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.MultipleActiveResultSets))).Not.Nullable();
                map.Map(ldls => ldls.AttachDBFilename).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.AttachDBFilename))).Length(objectExtension.GetMaximumStringLength()).Nullable();
                map.Map(ldls => ldls.PacketSize).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.PacketSize))).Not.Nullable();
                map.Map(ldls => ldls.Authentication).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.Authentication))).CustomType<EnumUserType<SqlAuthenticationMethod>>().Not.Nullable();
                map.Map(ldls => ldls.ApplicationName).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.ApplicationName))).Length(objectExtension.GetMaximumStringLength()).Nullable();
                map.Map(ldls => ldls.ApplicationIntent).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.ApplicationIntent))).CustomType<EnumUserType<ApplicationIntent>>().Not.Nullable();
                map.Map(ldls => ldls.ColumnEncryptionSetting).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.ColumnEncryptionSetting))).CustomType<EnumUserType<SqlConnectionColumnEncryptionSetting>>().Not.Nullable();
                map.Map(ldls => ldls.CommandTimeout).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.CommandTimeout))).Not.Nullable();
                map.Map(ldls => ldls.ConnectRetryCount).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.ConnectRetryCount))).Not.Nullable();
                map.Map(ldls => ldls.ConnectRetryInterval).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.ConnectRetryInterval))).Not.Nullable();
                map.Map(ldls => ldls.ConnectTimeout).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.ConnectTimeout))).Not.Nullable();
                map.Map(ldls => ldls.CurrentLanguage).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.CurrentLanguage))).Nullable();
                map.Map(ldls => ldls.AttestationProtocol).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.AttestationProtocol))).CustomType<EnumUserType<SqlConnectionAttestationProtocol>>().Not.Nullable();
                map.Map(ldls => ldls.EnclaveAttestationUrl).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.EnclaveAttestationUrl))).Length(objectExtension.GetMaximumGoogleUrlLength()).Nullable();
                map.Map(ldls => ldls.IPAddressPreference).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.IPAddressPreference))).CustomType<EnumUserType<SqlConnectionIPAddressPreference>>().Not.Nullable();
                map.Map(ldls => ldls.Encrypt).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.Encrypt))).Not.Nullable();
                map.Map(ldls => ldls.Enlist).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.Enlist))).Not.Nullable();
                map.Map(ldls => ldls.LoadBalanceTimeout).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.LoadBalanceTimeout))).Not.Nullable();
                map.Map(ldls => ldls.MaxPoolSize).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.MaxPoolSize))).Not.Nullable();
                map.Map(ldls => ldls.MinPoolSize).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.MinPoolSize))).Not.Nullable();
                map.Map(ldls => ldls.MultiSubnetFailover).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.MultiSubnetFailover))).Not.Nullable();
                map.Map(ldls => ldls.PersistSecurityInfo).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.PersistSecurityInfo))).Not.Nullable();
                map.Map(ldls => ldls.PoolBlockingPeriod).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.PoolBlockingPeriod))).CustomType<EnumUserType<PoolBlockingPeriod>>().Not.Nullable();
                map.Map(ldls => ldls.Pooling).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.Pooling))).Not.Nullable();
                map.Map(ldls => ldls.Replication).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.Replication))).Not.Nullable();
                map.Map(ldls => ldls.TransactionBinding).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.TransactionBinding))).Length(objectExtension.GetDefaultStringLength()).Not.Nullable();
                map.Map(ldls => ldls.TrustServerCertificate).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.TrustServerCertificate))).Not.Nullable();
                map.Map(ldls => ldls.TypeSystemVersion).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.TypeSystemVersion))).Length(objectExtension.GetDefaultStringLength()).Nullable();
                map.Map(ldls => ldls.UserInstance).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.UserInstance))).Nullable();
                map.Map(ldls => ldls.WorkstationID).Column(nameDecorator(nameof(IWhippetSqlServerDatabaseServer.WorkstationID))).Length(objectExtension.GetDefaultStringLength()).Nullable();

                map.References<TEntity>(entity => entity.Mirror).Nullable().LazyLoad(Laziness.False);
            }
        }
    }
}
