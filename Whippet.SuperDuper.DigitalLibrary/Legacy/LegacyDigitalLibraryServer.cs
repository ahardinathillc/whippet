﻿using System;
using Microsoft.Data.SqlClient;
using NodaTime;
using Dynamitey;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Database;
using Athi.Whippet.Data.Database.Microsoft;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.Extensions;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy
{
    /// <summary>
    /// Represents the database server for the legacy Super Duper Digital Library (SDDL) application.
    /// </summary>
    public class LegacyDigitalLibraryServer : SuperDuperServer, ILegacyDigitalLibraryServer, ISuperDuperServer, IWhippetSqlServerDatabaseServer, IDatabaseServer<WhippetSqlServerConnection>
    {
        private DatabaseConnectionPropertyVisibilityMask _mask;
        
        /// <summary>
        /// Gets a <see cref="DatabaseConnectionPropertyVisibilityMask"/> that specifies which properties are to be used in building the connection string called by <see cref="CreateConnection()"/>. By default, all properties are set to <see langword="true"/>. This property is read-only. 
        /// </summary>
        public virtual DatabaseConnectionPropertyVisibilityMask ConnectionPropertyMask
        {
            get
            {
                if (_mask == null)
                {
                    _mask = CreateMask();
                }

                return _mask;
            }
        }

        /// <summary>
        /// Specifies whether integrated security should be used.
        /// </summary>
        public virtual bool IntegratedSecurity
        { get; set; }
        
        /// <summary>
        /// Gets or sets the database instance to load upon successful connection to the server.
        /// </summary>
        public virtual string Database
        { get; set; }
        
        /// <summary>
        /// Specifies whether to use multiple active result sets (MARS).
        /// </summary>
        public virtual bool MultipleActiveResultSets
        { get; set; }
        
        /// <summary>
        /// Gets or sets the mirror database server or <see langword="null"/> if no mirror is used.
        /// </summary>
        IWhippetSqlServerDatabaseServer IWhippetSqlServerDatabaseServer.Mirror
        {
            get
            {
                return Mirror;
            }
            set
            {
                if (value != null && !(value is LegacyDigitalLibraryServer))
                {
                    throw new InvalidCastException();
                }
                else
                {
                    Mirror = (LegacyDigitalLibraryServer)(value);
                }
            }
        }
        
        /// <summary>
        /// Gets or sets a string that contains the name of the primary data file. This includes the full path name of an attachable database.
        /// </summary>
        public virtual string AttachDBFilename
        { get; set; }
        
        /// <summary>
        /// Gets or sets the packet size.
        /// </summary>
        public virtual int PacketSize
        { get; set; }
        
        /// <summary>
        /// Gets or sets the authentication method used for <a href="https://azure.microsoft.com/documentation/articles/sql-database-aad-authentication/#7-connect-to-your-database-by-using-azure-active-directory-identities">Connecting to SQL Database By Using Azure Active Directory Authentication</a>.
        /// </summary>
        public virtual SqlAuthenticationMethod Authentication
        { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the application associated with the connection string.
        /// </summary>
        public virtual string ApplicationName
        { get; set; }
        
        /// <summary>
        /// Declares the application workload type when connecting to a database in an SQL Server Availability Group. For more information about SqlClient support for Always On Availability Groups,
        /// see <a href="https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql/sqlclient-support-for-high-availability-disaster-recovery">SqlClient Support for High Availability, Disaster Recovery</a>.
        /// </summary>
        public virtual ApplicationIntent ApplicationIntent
        { get; set; }
        
        /// <summary>
        /// Gets or sets the column encryption settings for the connection string.
        /// </summary>
        public virtual SqlConnectionColumnEncryptionSetting ColumnEncryptionSetting
        { get; set; }

        /// <summary>
        /// The default wait time (in seconds) before terminating the attempt to execute a command and generating an error. The default is 30 seconds.
        /// </summary>
        public virtual int CommandTimeout
        { get; set; }
        
        /// <summary>
        /// The number of reconnections attempted after identifying that there was an idle connection failure. This must be an integer between 0 and 255. Default is 1. Set to 0 to disable reconnecting on idle connection failures.
        /// </summary>
        /// <exception cref="ArgumentException" />
        public byte ConnectRetryCount
        { get; set; }
        
        /// <summary>
        /// Amount of time (in seconds) between each reconnection attempt after identifying that there was an idle connection failure. This must be an integer between 1 and 60. The default is 10 seconds.
        /// </summary>
        /// <exception cref="ArgumentException" />
        public virtual byte ConnectRetryInterval
        { get; set; }

        /// <summary>
        /// Gets or sets the length of time (in seconds) to wait for a connection to the server before terminating the attempt and generating an error.
        /// </summary>
        public virtual int ConnectTimeout
        { get; set; }

        /// <summary>
        /// Gets or sets the language used for database server warning or error messages.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        public virtual string CurrentLanguage
        { get; set; }

        /// <summary>
        /// Gets or sets the value of Attestation Protocol.
        /// </summary>
        public virtual SqlConnectionAttestationProtocol AttestationProtocol
        { get; set; }

        /// <summary>
        /// Gets or sets the enclave attestation URL to be used with enclave based Always Encrypted.
        /// </summary>
        public virtual string EnclaveAttestationUrl
        { get; set; }

        /// <summary>
        /// Gets or sets the IP address family preference when establishing TCP connections.
        /// </summary>
        public virtual SqlConnectionIPAddressPreference IPAddressPreference
        { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="Boolean"/> value that indicates whether SQL Server uses SSL encryption for all data sent between the client and server if the server has a certificate installed.
        /// </summary>
        public virtual bool Encrypt
        { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="Boolean"/> value that indicates whether the SQL Server connection pooler automatically enlists the connection in the creation thread's current transaction context.
        /// </summary>
        public virtual bool Enlist
        { get; set; }
        
        /// <summary>
        /// Gets or sets the minimum time, in seconds, for the connection to live in the connection pool before being destroyed.
        /// </summary>
        public virtual int LoadBalanceTimeout
        { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of connections allowed in the connection pool for this specific connection string.
        /// </summary>
        public virtual int MaxPoolSize
        { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of connections allowed in the connection pool for this specific connection string.
        /// </summary>
        public virtual int MinPoolSize
        { get; set; }
        
        /// <summary>
        /// If your application is connecting to an AlwaysOn availability group (AG) on different subnets, setting <see cref="MultiSubnetFailover"/> to <see langword="true"/> provides faster detection of and connection to the (currently) active server.
        /// </summary>
        public virtual bool MultiSubnetFailover
        { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="Boolean"/> value that indicates if security-sensitive information, such as the password, is not returned as part of the connection if the connection is open or has ever been in an open state.
        /// </summary>
        public virtual bool PersistSecurityInfo
        { get; set; }

        /// <summary>
        /// The blocking period behavior for a connection pool.
        /// </summary>
        public virtual PoolBlockingPeriod PoolBlockingPeriod
        { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="Boolean"/> value that indicates whether the connection will be pooled or explicitly opened every time that the connection is requested.
        /// </summary>
        public virtual bool Pooling
        { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="Boolean"/> value that indicates whether replication is supported using the connection.
        /// </summary>
        public virtual bool Replication
        { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="String"/> value that indicates how the connection maintains its association with an enlisted <see cref="System.Transactions"/> transaction.
        /// </summary>
        public virtual string TransactionBinding
        { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether the channel will be encrypted while bypassing walking the certificate chain to validate trust.
        /// </summary>
        public virtual bool TrustServerCertificate
        { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="String"/> value that indicates the type system the application expects.
        /// </summary>
        public virtual string TypeSystemVersion
        { get; set; }
        
        /// <summary>
        /// Gets or sets a value that indicates whether to redirect the connection from the default SQL Server Express instance to a runtime-initiated instance running under the account of the caller.
        /// </summary>
        public virtual bool UserInstance
        { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the workstation connecting to SQL Server.
        /// </summary>
        public virtual string WorkstationID
        { get; set; }
        
        /// <summary>
        /// Gets or sets the mirror database server or <see langword="null"/> if no mirror is used.
        /// </summary>
        public virtual LegacyDigitalLibraryServer Mirror
        { get; set; }

        /// <summary>
        /// Gets or sets the mirror database server or <see langword="null"/> if no mirror is used.
        /// </summary>
        ILegacyDigitalLibraryServer ILegacyDigitalLibraryServer.Mirror
        {
            get
            {
                return Mirror;
            }
            set
            {
                Mirror = value.ToLegacyDigitalLibraryServer();
            }
        }
        
        /// <summary>
        /// Creates a new instance of the <see cref="SuperDuperServer"/> class.
        /// </summary>
        /// <param name="id">Unique ID to assign to the <see cref="SuperDuperServer"/>.</param>
        /// <param name="name">Unique name of the server profile.</param>
        /// <param name="username">Username used to connect to the database.</param>
        /// <param name="password">Password used to connect to the database.</param>
        /// <param name="tenant"><see cref="WhippetTenant"/> the server is registered with.</param>
        /// <param name="active">Specifies whether the profile is currently active.</param>
        /// <param name="deleted">Specifies whether the profile has been deleted.</param>
        /// <param name="createdDateTime">Date and time the object was created.</param>
        /// <param name="createdBy"><see cref="Guid"/> representing the <see cref="SuperDuperServer"/> who created the account.</param>
        /// <param name="lastModifiedDateTime">Date and time of when the object was last modified.</param>
        /// <param name="lastModifiedBy"><see cref="Guid"/> representing the <see cref="SuperDuperServer"/> who last modified the account.</param>
        public LegacyDigitalLibraryServer(Guid id, string name, string username, string password, WhippetTenant tenant, bool active, bool deleted, Instant? createdDateTime, Guid? createdBy, Instant? lastModifiedDateTime, Guid? lastModifiedBy)
            : base(id, name, username, password, tenant, active, deleted, createdDateTime, createdBy, lastModifiedDateTime, lastModifiedBy, ExternalDataSourceType.Database)
        { }

        /// <summary>
        /// Creates a new <see cref="WhippetSqlServerConnection" />> object based on the current <see cref="ConnectionString"/> value or, if no value exists for <see cref="ConnectionString"/>, a default instance of <see cref="WhippetSqlServerConnection" />>.
        /// </summary>
        /// <returns><see cref="WhippetSqlServerConnection" />> object.</returns>
        public virtual WhippetSqlServerConnection CreateConnection()
        {
            WhippetSqlServerConnectionStringBuilder builder = new WhippetSqlServerConnectionStringBuilder();

            foreach (KeyValuePair<string, bool> mask in ConnectionPropertyMask)
            {
                if (mask.Value)
                {
                    Dynamic.InvokeSet(builder, mask.Key, this.GetType().GetProperties().Single(pi => String.Equals(mask.Key?.Trim(), pi.Name?.Trim(), StringComparison.InvariantCultureIgnoreCase)).GetValue(this, null));
                }
            }
            
            return String.IsNullOrWhiteSpace(builder.ConnectionString) ? new WhippetSqlServerConnection() : new WhippetSqlServerConnection(builder.ConnectionString);
        }

        /// <summary>
        /// Creates a new <see cref="DatabaseConnectionPropertyVisibilityMask"/> object for the current instance.
        /// </summary>
        /// <returns><see cref="DatabaseConnectionPropertyVisibilityMask"/> object.</returns>
        private DatabaseConnectionPropertyVisibilityMask CreateMask()
        {
            Dictionary<string, bool> mask = new Dictionary<string, bool>();

            mask.Add(nameof(IntegratedSecurity), true);
            mask.Add(nameof(Database), true);
            mask.Add(nameof(MultipleActiveResultSets), true);
            mask.Add(nameof(AttachDBFilename), true);
            mask.Add(nameof(PacketSize), true);
            mask.Add(nameof(Authentication), true);
            mask.Add(nameof(ApplicationName), true);
            mask.Add(nameof(ApplicationIntent), true);
            mask.Add(nameof(ColumnEncryptionSetting), true);
            mask.Add(nameof(CommandTimeout), true);
            mask.Add(nameof(ConnectRetryCount), true);
            mask.Add(nameof(ConnectTimeout), true);
            mask.Add(nameof(CurrentLanguage), true);
            mask.Add(nameof(AttestationProtocol), true);
            mask.Add(nameof(EnclaveAttestationUrl), true);
            mask.Add(nameof(IPAddressPreference), true);
            mask.Add(nameof(Encrypt), true);
            mask.Add(nameof(Enlist), true);
            mask.Add(nameof(LoadBalanceTimeout), true);
            mask.Add(nameof(MaxPoolSize), true);
            mask.Add(nameof(MinPoolSize), true);
            mask.Add(nameof(MultiSubnetFailover), true);
            mask.Add(nameof(PersistSecurityInfo), true);
            mask.Add(nameof(PoolBlockingPeriod), true);
            mask.Add(nameof(Pooling), true);
            mask.Add(nameof(Replication), true);
            mask.Add(nameof(TransactionBinding), true);
            mask.Add(nameof(TrustServerCertificate), true);
            mask.Add(nameof(TypeSystemVersion), true);
            mask.Add(nameof(UserInstance), true);
            mask.Add(nameof(WorkstationID), true);
            mask.Add(nameof(Mirror), true);

            return new DatabaseConnectionPropertyVisibilityMask(mask);
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            
            hash.Add(base.GetHashCode());
            hash.Add(IntegratedSecurity);
            hash.Add(Database);
            hash.Add(MultipleActiveResultSets);
            hash.Add(AttachDBFilename);
            hash.Add(PacketSize);
            hash.Add(Authentication);
            hash.Add(ApplicationName);
            hash.Add(ApplicationIntent);
            hash.Add(ColumnEncryptionSetting);
            hash.Add(CommandTimeout);
            hash.Add(ConnectRetryCount);
            hash.Add(ConnectTimeout);
            hash.Add(CurrentLanguage);
            hash.Add(AttestationProtocol);
            hash.Add(EnclaveAttestationUrl);
            hash.Add(IPAddressPreference);
            hash.Add(Encrypt);
            hash.Add(Enlist);
            hash.Add(LoadBalanceTimeout);
            hash.Add(MaxPoolSize);
            hash.Add(MinPoolSize);
            hash.Add(MultiSubnetFailover);
            hash.Add(PersistSecurityInfo);
            hash.Add(PoolBlockingPeriod);
            hash.Add(Pooling);
            hash.Add(Replication);
            hash.Add(TransactionBinding);
            hash.Add(TrustServerCertificate);
            hash.Add(TypeSystemVersion);
            hash.Add(UserInstance);
            hash.Add(WorkstationID);
            hash.Add(Mirror);

            return hash.ToHashCode();
        }
    }
}