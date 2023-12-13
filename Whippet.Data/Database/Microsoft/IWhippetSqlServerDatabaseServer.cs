using System;
using Microsoft.Data.SqlClient;

namespace Athi.Whippet.Data.Database.Microsoft
{
    /// <summary>
    /// Represents an <see cref="IDatabaseServer{TConnection}"/> for a Microsoft SQL Server instance.
    /// </summary>
    public interface IWhippetSqlServerDatabaseServer : IDatabaseServer<WhippetSqlServerConnection>
    {
        /// <summary>
        /// Specifies whether integrated security should be used.
        /// </summary>
        bool IntegratedSecurity
        { get; set; }
        
        /// <summary>
        /// Gets or sets the database instance to load upon successful connection to the server.
        /// </summary>
        string Database
        { get; set; }
        
        /// <summary>
        /// Specifies whether to use multiple active result sets (MARS).
        /// </summary>
        bool MultipleActiveResultSets
        { get; set; }
        
        /// <summary>
        /// Gets or sets the mirror database server or <see langword="null"/> if no mirror is used.
        /// </summary>
        IWhippetSqlServerDatabaseServer Mirror
        { get; set; }
        
        /// <summary>
        /// Gets or sets a string that contains the name of the primary data file. This includes the full path name of an attachable database.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        string AttachDBFilename
        { get; set; }

        /// <summary>
        /// Gets or sets the packet size.
        /// </summary>
        int PacketSize
        { get; set; }
        
        /// <summary>
        /// Gets or sets the authentication method used for <a href="https://azure.microsoft.com/documentation/articles/sql-database-aad-authentication/#7-connect-to-your-database-by-using-azure-active-directory-identities">Connecting to SQL Database By Using Azure Active Directory Authentication</a>.
        /// </summary>
        SqlAuthenticationMethod Authentication
        { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the application associated with the connection string.
        /// </summary>
        string ApplicationName
        { get; set; }
        
        /// <summary>
        /// Declares the application workload type when connecting to a database in an SQL Server Availability Group. For more information about SqlClient support for Always On Availability Groups,
        /// see <a href="https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql/sqlclient-support-for-high-availability-disaster-recovery">SqlClient Support for High Availability, Disaster Recovery</a>.
        /// </summary>
        ApplicationIntent ApplicationIntent
        { get; set; }
        
        /// <summary>
        /// Gets or sets the column encryption settings for the connection string.
        /// </summary>
        SqlConnectionColumnEncryptionSetting ColumnEncryptionSetting
        { get; set; }

        /// <summary>
        /// The default wait time (in seconds) before terminating the attempt to execute a command and generating an error. The default is 30 seconds.
        /// </summary>
        int CommandTimeout
        { get; set; }
        
        /// <summary>
        /// The number of reconnections attempted after identifying that there was an idle connection failure. This must be an integer between 0 and 255. Default is 1. Set to 0 to disable reconnecting on idle connection failures.
        /// </summary>
        /// <exception cref="ArgumentException" />
        byte ConnectRetryCount
        { get; set; }
        
        /// <summary>
        /// Amount of time (in seconds) between each reconnection attempt after identifying that there was an idle connection failure. This must be an integer between 1 and 60. The default is 10 seconds.
        /// </summary>
        /// <exception cref="ArgumentException" />
        byte ConnectRetryInterval
        { get; set; }

        /// <summary>
        /// Gets or sets the length of time (in seconds) to wait for a connection to the server before terminating the attempt and generating an error.
        /// </summary>
        int ConnectTimeout
        { get; set; }

        /// <summary>
        /// Gets or sets the language used for database server warning or error messages.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        string CurrentLanguage
        { get; set; }

        /// <summary>
        /// Gets or sets the value of Attestation Protocol.
        /// </summary>
        SqlConnectionAttestationProtocol AttestationProtocol
        { get; set; }

        /// <summary>
        /// Gets or sets the enclave attestation URL to be used with enclave based Always Encrypted.
        /// </summary>
        string EnclaveAttestationUrl
        { get; set; }

        /// <summary>
        /// Gets or sets the IP address family preference when establishing TCP connections.
        /// </summary>
        SqlConnectionIPAddressPreference IPAddressPreference
        { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="Boolean"/> value that indicates whether SQL Server uses SSL encryption for all data sent between the client and server if the server has a certificate installed.
        /// </summary>
        bool Encrypt
        { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="Boolean"/> value that indicates whether the SQL Server connection pooler automatically enlists the connection in the creation thread's current transaction context.
        /// </summary>
        bool Enlist
        { get; set; }
        
        /// <summary>
        /// Gets or sets the minimum time, in seconds, for the connection to live in the connection pool before being destroyed.
        /// </summary>
        int LoadBalanceTimeout
        { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of connections allowed in the connection pool for this specific connection string.
        /// </summary>
        int MaxPoolSize
        { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of connections allowed in the connection pool for this specific connection string.
        /// </summary>
        int MinPoolSize
        { get; set; }
        
        /// <summary>
        /// If your application is connecting to an AlwaysOn availability group (AG) on different subnets, setting <see cref="MultiSubnetFailover"/> to <see langword="true"/> provides faster detection of and connection to the (currently) active server.
        /// </summary>
        bool MultiSubnetFailover
        { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="Boolean"/> value that indicates if security-sensitive information, such as the password, is not returned as part of the connection if the connection is open or has ever been in an open state.
        /// </summary>
        bool PersistSecurityInfo
        { get; set; }

        /// <summary>
        /// The blocking period behavior for a connection pool.
        /// </summary>
        PoolBlockingPeriod PoolBlockingPeriod
        { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="Boolean"/> value that indicates whether the connection will be pooled or explicitly opened every time that the connection is requested.
        /// </summary>
        bool Pooling
        { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="Boolean"/> value that indicates whether replication is supported using the connection.
        /// </summary>
        bool Replication
        { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="String"/> value that indicates how the connection maintains its association with an enlisted <see cref="System.Transactions"/> transaction.
        /// </summary>
        string TransactionBinding
        { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether the channel will be encrypted while bypassing walking the certificate chain to validate trust.
        /// </summary>
        bool TrustServerCertificate
        { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="String"/> value that indicates the type system the application expects.
        /// </summary>
        string TypeSystemVersion
        { get; set; }
        
        /// <summary>
        /// Gets or sets a value that indicates whether to redirect the connection from the default SQL Server Express instance to a runtime-initiated instance running under the account of the caller.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        bool UserInstance
        { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the workstation connecting to SQL Server.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        string WorkstationID
        { get; set; }
    }
}
