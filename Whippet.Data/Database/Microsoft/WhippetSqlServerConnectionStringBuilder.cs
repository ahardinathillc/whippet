using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.ComponentModel;
using System.Reflection;
using Microsoft.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;

namespace Athi.Whippet.Data.Database.Microsoft
{
    /// <summary>
    /// Allows for the programmatic construction of <see cref="WhippetSqlServerConnection"/> connection strings. This class cannot be inherited.
    /// </summary>
    [DefaultProperty("DataSource")]
    public sealed class WhippetSqlServerConnectionStringBuilder : DbConnectionStringBuilder
    {
        private const string TOKEN_DOCKER_CONTAINER = "docker_container";
        
        private SqlConnectionStringBuilder _builder;

        /// <summary>
        /// Gets tokens that are not supported by NHibernate when connecting to a Linux container. This property is read-only.
        /// </summary>
        private static IEnumerable<string> InvalidDockerTokens
        {
            get
            {
                return new string[] { "MultipleActiveResultSets", "TrustServerCertificate" };
            }
        }
        
        /// <summary>
        /// Gets or sets the internal <see cref="SqlConnectionStringBuilder"/> object.
        /// </summary>
        private SqlConnectionStringBuilder InternalBuilder
        {
            get
            {
                if (_builder == null)
                {
                    _builder = new SqlConnectionStringBuilder();
                }

                return _builder;
            }
            set
            {
                _builder = value;
            }
        }

        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <param name="keyword">The key of the item to get or set.</param>
        /// <returns>THe value associated with the specified key.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="KeyNotFoundException" />
        /// <exception cref="FormatException" />
        public override object this[string keyword]
        {
            get
            {
                return InternalBuilder[keyword];
            }
            set
            {
                InternalBuilder[keyword] = value;
            }
        }

        /// <summary>
        /// Indicates whether the <see cref="WhippetSqlServerConnectionStringBuilder"/> is read-only. This property is read-only.
        /// </summary>
        public new bool IsReadOnly
        {
            get
            {
                return InternalBuilder.IsReadOnly;   
            }
        }

        /// <summary>
        /// Gets the current number of keys that are in the <see cref="WhippetSqlServerConnectionStringBuilder"/>. This property is read-only.
        /// </summary>
        public override int Count
        {
            get
            {
                return InternalBuilder.Count;
            }
        }

        /// <summary>
        /// Declares the application workload type when connecting to a database in an SQL Server Availability Group. For more information about SqlClient support for Always On Availability Groups,
        /// see <a href="https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql/sqlclient-support-for-high-availability-disaster-recovery">SqlClient Support for High Availability, Disaster Recovery</a>.
        /// </summary>
        [DisplayName("Application Intent")]
        [RefreshProperties(RefreshProperties.All)]
        public ApplicationIntent ApplicationIntent
        {
            get
            {
                return InternalBuilder.ApplicationIntent;
            }
            set
            {
                InternalBuilder.ApplicationIntent = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the application associated with the connection string.
        /// </summary>
        [DisplayName("Application Name")]
        [RefreshProperties(RefreshProperties.All)]
        public string ApplicationName
        {
            get
            {
                return InternalBuilder.ApplicationName;
            }
            set
            {
                InternalBuilder.ApplicationName = value;
            }
        }

        /// <summary>
        /// Gets or sets a string that contains the name of the primary data file. This includes the full path name of an attachable database.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        [DisplayName("AttachDbFilename")]
        [Editor("System.Windows.Forms.Design.FileNameEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [RefreshProperties(RefreshProperties.All)]
        public string AttachDBFilename
        {
            get
            {
                return InternalBuilder.AttachDBFilename;
            }
            set
            {
                InternalBuilder.AttachDBFilename = value;
            }
        }

        /// <summary>
        /// Gets or sets the authentication method used for <a href="https://azure.microsoft.com/documentation/articles/sql-database-aad-authentication/#7-connect-to-your-database-by-using-azure-active-directory-identities">Connecting to SQL Database By Using Azure Active Directory Authentication</a>.
        /// </summary>
        [DisplayName("Authentication")]
        [RefreshProperties(RefreshProperties.All)]
        public SqlAuthenticationMethod Authentication
        {
            get
            {
                return InternalBuilder.Authentication;
            }
            set
            {
                InternalBuilder.Authentication = value;
            }
        }

        /// <summary>
        /// Gets or sets the column encryption settings for the connection string builder.
        /// </summary>
        [DisplayName("Column Encryption Setting")]
        [RefreshProperties(RefreshProperties.All)]
        public SqlConnectionColumnEncryptionSetting ColumnEncryptionSetting
        {
            get
            {
                return InternalBuilder.ColumnEncryptionSetting;
            }
            set
            {
                InternalBuilder.ColumnEncryptionSetting = value;
            }
        }

        /// <summary>
        /// The default wait time (in seconds) before terminating the attempt to execute a command and generating an error. The default is 30 seconds.
        /// </summary>
        /// <exception cref="ArgumentException" />
        [DisplayName("Command Timeout")]
        [RefreshProperties(RefreshProperties.All)]
        public int CommandTimeout
        {
            get
            {
                return InternalBuilder.CommandTimeout;
            }
            set
            {
                InternalBuilder.CommandTimeout = value;
            }
        }

        /// <summary>
        /// Gets or sets the connection string associated with the <see cref="DbConnectionStringBuilder"/>.
        /// </summary>
        /// <exception cref="ArgumentException" />
        public new string ConnectionString
        {
            get
            {
                return InternalBuilder.ConnectionString;
            }
            set
            {
                InternalBuilder.ConnectionString = value;
            }
        }

        /// <summary>
        /// The number of reconnections attempted after identifying that there was an idle connection failure. This must be an integer between 0 and 255. Default is 1.
        /// Set to 0 to disable reconnecting on idle connection failures. An <see cref="ArgumentException"/> will be thrown if set to a value outside of the allowed range.
        /// </summary>
        /// <exception cref="ArgumentException" />
        [DisplayName("Connect Retry Count")]
        [RefreshProperties(RefreshProperties.All)]
        public int ConnectRetryCount
        {
            get
            {
                return InternalBuilder.ConnectRetryCount;
            }
            set
            {
                InternalBuilder.ConnectRetryCount = value;
            }
        }

        /// <summary>
        /// Amount of time (in seconds) between each reconnection attempt after identifying that there was an idle connection failure. This must be an integer between 1 and 60. The default is 10 seconds.
        /// </summary>
        /// <exception cref="ArgumentException" />
        [DisplayName("Connect Retry Interval")]
        [RefreshProperties(RefreshProperties.All)]
        public int ConnectRetryInterval
        {
            get
            {
                return InternalBuilder.ConnectRetryInterval;
            }
            set
            {
                InternalBuilder.ConnectRetryInterval = value;
            }
        }

        /// <summary>
        /// Gets or sets the length of time (in seconds) to wait for a connection to the server before terminating the attempt and generating an error.
        /// </summary>
        [DisplayName("Connect Timeout")]
        [RefreshProperties(RefreshProperties.All)]
        public int ConnectTimeout
        {
            get
            {
                return InternalBuilder.ConnectTimeout;
            }
            set
            {
                InternalBuilder.ConnectTimeout = value;
            }
        }

        /// <summary>
        /// Gets or sets the language used for database server warning or error messages.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        [DisplayName("Current Language")]
        [RefreshProperties(RefreshProperties.All)]
        public string CurrentLanguage
        {
            get
            {
                return InternalBuilder.CurrentLanguage;
            }
            set
            {
                InternalBuilder.CurrentLanguage = value;
            }
        }

        /// <summary>
        /// Gets or sets the name or network address of the instance of SQL Server to connect to.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        [DisplayName("Data Source")]
        [RefreshProperties(RefreshProperties.All)]
        public string DataSource
        {
            get
            {
                return InternalBuilder.DataSource;
            }
            set
            {
                InternalBuilder.DataSource = value;
            }
        }

        /// <summary>
        /// Gets or sets the value of Attestation Protocol.
        /// </summary>
        [DisplayName("Attestation Protocol")]
        [RefreshProperties(RefreshProperties.All)]
        public SqlConnectionAttestationProtocol AttestationProtocol
        {
            get
            {
                return InternalBuilder.AttestationProtocol;
            }
            set
            {
                InternalBuilder.AttestationProtocol = value;
            }
        }

        /// <summary>
        /// Gets or sets the enclave attestation URL to be used with enclave based Always Encrypted.
        /// </summary>
        [DisplayName("Enclave Attestation Url")]
        [RefreshProperties(RefreshProperties.All)]
        public string EnclaveAttestationUrl
        {
            get
            {
                return InternalBuilder.EnclaveAttestationUrl;
            }
            set
            {
                InternalBuilder.EnclaveAttestationUrl = value;
            }
        }

        /// <summary>
        /// Gets or sets the IP address family preference when establishing TCP connections.
        /// </summary>
        [DisplayName("IP Address Preference")]
        [RefreshProperties(RefreshProperties.All)]
        public SqlConnectionIPAddressPreference IPAddressPreference
        {
            get
            {
                return InternalBuilder.IPAddressPreference;
            }
            set
            {
                InternalBuilder.IPAddressPreference = value;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Boolean"/> value that indicates whether SQL Server uses SSL encryption for all data sent between the client and server if the server has a certificate installed.
        /// </summary>
        [DisplayName("Encrypt")]
        [RefreshProperties(RefreshProperties.All)]
        public bool Encrypt
        {
            get
            {
                return InternalBuilder.Encrypt;
            }
            set
            {
                InternalBuilder.Encrypt = value;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Boolean"/> value that indicates whether the SQL Server connection pooler automatically enlists the connection in the creation thread's current transaction context.
        /// </summary>
        [DisplayName("Enlist")]
        [RefreshProperties(RefreshProperties.All)]
        public bool Enlist
        {
            get
            {
                return InternalBuilder.Enlist;
            }
            set
            {
                InternalBuilder.Enlist = value;
            }
        }

        /// <summary>
        /// Gets or sets the name or address of the partner server to connect to if the primary server is down.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        [DisplayName("Failover Partner")]
        [RefreshProperties(RefreshProperties.All)]
        public string FailoverPartner
        {
            get
            {
                return InternalBuilder.FailoverPartner;
            }
            set
            {
                InternalBuilder.FailoverPartner = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the database associated with the connection.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        [DisplayName("Initial Catalog")]
        [RefreshProperties(RefreshProperties.All)]
        public string InitialCatalog
        {
            get
            {
                return InternalBuilder.InitialCatalog;
            }
            set
            {
                InternalBuilder.InitialCatalog = value;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Boolean"/> value that indicates whether User ID and Password are specified in the connection (when <see langword="false"/>) or whether the current Windows account credentials are used for authentication (when <see langword="true"/>).
        /// </summary>
        [DisplayName("Integrated Security")]
        [RefreshProperties(RefreshProperties.All)]
        public bool IntegratedSecurity
        {
            get
            {
                return InternalBuilder.IntegratedSecurity;
            }
            set
            {
                InternalBuilder.IntegratedSecurity = value;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the <see cref="WhippetSqlServerConnectionStringBuilder"/> has a fixed size. This property is read-only.
        /// </summary>
        public override bool IsFixedSize
        {
            get
            {
                return InternalBuilder.IsFixedSize;
            }
        }

        /// <summary>
        /// Gets an <see cref="ICollection"/> that contains the keys in the <see cref="WhippetSqlServerConnectionStringBuilder"/>. This property is read-only.
        /// </summary>
        public override ICollection Keys
        {
            get
            {
                return InternalBuilder.Keys;
            }
        }

        /// <summary>
        /// Gets or sets the minimum time, in seconds, for the connection to live in the connection pool before being destroyed.
        /// </summary>
        [DisplayName("Load Balance Timeout")]
        [RefreshProperties(RefreshProperties.All)]
        public int LoadBalanceTimeout
        {
            get
            {
                return InternalBuilder.LoadBalanceTimeout;
            }
            set
            {
                InternalBuilder.LoadBalanceTimeout = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum number of connections allowed in the connection pool for this specific connection string.
        /// </summary>
        [DisplayName("Max Pool Size")]
        [RefreshProperties(RefreshProperties.All)]
        public int MaxPoolSize
        {
            get
            {
                return InternalBuilder.MaxPoolSize;
            }
            set
            {
                InternalBuilder.MaxPoolSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the minimum number of connections allowed in the connection pool for this specific connection string.
        /// </summary>
        [DisplayName("Min Pool Size")]
        [RefreshProperties(RefreshProperties.All)]
        public int MinPoolSize
        {
            get
            {
                return InternalBuilder.MinPoolSize;
            }
            set
            {
                InternalBuilder.MinPoolSize = value;
            }
        }

        /// <summary>
        /// When <see langword="true"/>,  an application can maintain multiple active result sets (MARS). When <see langword="false"/>, an application must process or cancel all result sets from one batch before 
        /// it can execute any other batch on that connection. For more information, see <a href="https://msdn.microsoft.com//library/cfa084cz.aspx">Multiple Active Result Sets (MARS)</a>.
        /// </summary>
        [DisplayName("Multiple Active Result Sets")]
        [RefreshProperties(RefreshProperties.All)]
        public bool MultipleActiveResultSets
        {
            get
            {
                return InternalBuilder.MultipleActiveResultSets;
            }
            set
            {
                InternalBuilder.MultipleActiveResultSets = value;
            }
        }

        /// <summary>
        /// If your application is connecting to an AlwaysOn availability group (AG) on different subnets, setting <see cref="MultiSubnetFailover"/> to <see langword="true"/> provides faster detection of and connection 
        /// to the (currently) active server.
        /// </summary>
        [DisplayName("Multi Subnet Failover")]
        [RefreshProperties(RefreshProperties.All)]
        public bool MultiSubnetFailover
        {
            get
            {
                return InternalBuilder.MultiSubnetFailover;
            }
            set
            {
                InternalBuilder.MultiSubnetFailover = value;
            }
        }

        /// <summary>
        /// Gets or sets the size in bytes of the network packets used to communicate with an instance of SQL Server.
        /// </summary>
        [DisplayName("Packet Size")]
        [RefreshProperties(RefreshProperties.All)]
        public int PacketSize
        {
            get
            {
                return InternalBuilder.PacketSize;
            }
            set
            {
                InternalBuilder.PacketSize = (value <= 0) ? WhippetSqlServerConnection.DefaultPacketSize : value;
            }
        }

        /// <summary>
        /// Gets or sets the password for the SQL Server account.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        [DisplayName("Password")]
        [PasswordPropertyText(true)]
        [RefreshProperties(RefreshProperties.All)]
        public string Password
        {
            get
            {
                return InternalBuilder.Password;
            }
            set
            {
                InternalBuilder.Password = value;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Boolean"/> value that indicates if security-sensitive information, such as the password, is not returned as part of the connection if the connection is open or has ever been in an open state.
        /// </summary>
        [DisplayName("Persist Security Info")]
        [RefreshProperties(RefreshProperties.All)]
        public bool PersistSecurityInfo
        {
            get
            {
                return InternalBuilder.PersistSecurityInfo;
            }
            set
            {
                InternalBuilder.PersistSecurityInfo = value;
            }
        }

        /// <summary>
        /// The blocking period behavior for a connection pool.
        /// </summary>
        [DisplayName("Pool Blocking Period")]
        [RefreshProperties(RefreshProperties.All)]
        public PoolBlockingPeriod PoolBlockingPeriod
        {
            get
            {
                return InternalBuilder.PoolBlockingPeriod;
            }
            set
            {
                InternalBuilder.PoolBlockingPeriod = value;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Boolean"/> value that indicates whether the connection will be pooled or explicitly opened every time that the connection is requested.
        /// </summary>
        [DisplayName("Pooling")]
        [RefreshProperties(RefreshProperties.All)]
        public bool Pooling
        {
            get
            {
                return InternalBuilder.Pooling;
            }
            set
            {
                InternalBuilder.Pooling = value;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Boolean"/> value that indicates whether replication is supported using the connection.
        /// </summary>
        [DisplayName("Replication")]
        [RefreshProperties(RefreshProperties.All)]
        public bool Replication
        {
            get
            {
                return InternalBuilder.Replication;
            }
            set
            {
                InternalBuilder.Replication = value;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="String"/> value that indicates how the connection maintains its association with an enlisted <see cref="System.Transactions"/> transaction.
        /// </summary>
        [DisplayName("Transaction Binding")]
        [RefreshProperties(RefreshProperties.All)]
        public string TransactionBinding
        {
            get
            {
                return InternalBuilder.TransactionBinding;
            }
            set
            {
                InternalBuilder.TransactionBinding = value;
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether the channel will be encrypted while bypassing walking the certificate chain to validate trust.
        /// </summary>
        [DisplayName("Trust Server Certificate")]
        [RefreshProperties(RefreshProperties.All)]
        public bool TrustServerCertificate
        {
            get
            {
                return InternalBuilder.TrustServerCertificate;
            }
            set
            {
                InternalBuilder.TrustServerCertificate = value;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="String"/> value that indicates the type system the application expects.
        /// </summary>
        [DisplayName("Type System Version")]
        [RefreshProperties(RefreshProperties.All)]
        public string TypeSystemVersion
        {
            get
            {
                return InternalBuilder.TypeSystemVersion;
            }
            set
            {
                InternalBuilder.TypeSystemVersion = value;
            }
        }

        /// <summary>
        /// Gets or sets the user ID to be used when connecting to SQL Server.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        [DisplayName("User ID")]
        [RefreshProperties(RefreshProperties.All)]
        public string UserID
        {
            get
            {
                return InternalBuilder.UserID;
            }
            set
            {
                InternalBuilder.UserID = value;
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether to redirect the connection from the default SQL Server Express instance to a runtime-initiated instance running under the account of the caller.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        [DisplayName("User Instance")]
        [RefreshProperties(RefreshProperties.All)]
        public bool UserInstance
        {
            get
            {
                return InternalBuilder.UserInstance;
            }
            set
            {
                InternalBuilder.UserInstance = value;
            }
        }

        /// <summary>
        /// Gets an <see cref="ICollection"/> that contains the values in the <see cref="WhippetSqlServerConnectionStringBuilder"/>. This property is read-only.
        /// </summary>
        public override ICollection Values
        {
            get
            {
                return InternalBuilder.Values;
            }
        }

        /// <summary>
        /// Gets or sets the name of the workstation connecting to SQL Server.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        [DisplayName("Workstation ID")]
        [RefreshProperties(RefreshProperties.All)]
        public string WorkstationID
        {
            get
            {
                return InternalBuilder.WorkstationID;
            }
            set
            {
                InternalBuilder.WorkstationID = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerConnectionStringBuilder"/> class with no arguments.
        /// </summary>
        public WhippetSqlServerConnectionStringBuilder()
            : this(new SqlConnectionStringBuilder())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerConnectionStringBuilder"/> class with the specified <see cref="SqlConnectionStringBuilder"/> object.
        /// </summary>
        /// <param name="builder"><see cref="SqlConnectionStringBuilder"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetSqlServerConnectionStringBuilder(SqlConnectionStringBuilder builder)
            : base()
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            else
            {
                InternalBuilder = builder;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerConnectionStringBuilder"/> class with the specified connection string.
        /// </summary>
        /// <param name="connectionString">Connection string to initialize with.</param>
        /// <exception cref="ArgumentException" />
        /// <exception cref="FormatException" />
        /// <exception cref="KeyNotFoundException" />
        public WhippetSqlServerConnectionStringBuilder(string connectionString)
            : this(new SqlConnectionStringBuilder(connectionString))
        { }

        /// <summary>
        /// Clears the contents of the <see cref="WhippetSqlServerConnectionStringBuilder"/> instance.
        /// </summary>
        public override void Clear()
        {
            InternalBuilder.Clear();
        }

        /// <summary>
        /// Determines whether the <see cref="WhippetSqlServerConnectionStringBuilder"/> contains a specific key.
        /// </summary>
        /// <param name="keyword">The key to locate in the <see cref="WhippetSqlServerConnectionStringBuilder"/>.</param>
        /// <returns><see langword="true"/> if the <see cref="WhippetSqlServerConnectionStringBuilder"/> contains an element that has the specified key; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        public override bool ContainsKey(string keyword)
        {
            return InternalBuilder.ContainsKey(keyword);
        }

        /// <summary>
        /// Removes an entry with the specified key from the <see cref="WhippetSqlServerConnectionStringBuilder"/> instance.
        /// </summary>
        /// <param name="keyword">The key of the key/value pair to be removed from the connection string in this <see cref="WhippetSqlServerConnectionStringBuilder"/>.</param>
        /// <returns><see langword="true"/> if the key existed within the connection string and was removed; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        public override bool Remove(string keyword)
        {
            return InternalBuilder.Remove(keyword);
        }

        /// <summary>
        /// Indicates whether the specified key and associated value should be serialized.
        /// </summary>
        /// <param name="keyword">The key of the key/value pair to in the connection string in this <see cref="WhippetSqlServerConnectionStringBuilder"/>.</param>
        /// <returns><see langword="true"/> if the key/value pair should be serialized; otherwise, <see langword="false"/>.</returns>
        public override bool ShouldSerialize(string keyword)
        {
            return InternalBuilder.ShouldSerialize(keyword);
        }

        /// <summary>
        /// Retrieves a value corresponding to the supplied key from this <see cref="WhippetSqlServerConnectionStringBuilder"/>.
        /// </summary>
        /// <param name="keyword">The key of the item to retrieve.</param>
        /// <param name="value">The value corresponding to keyword.</param>
        /// <returns><see langword="true"/> if <paramref name="keyword"/> was found within the connection string; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        public override bool TryGetValue(string keyword, [NotNullWhen(true)] out object value)
        {
            return InternalBuilder.TryGetValue(keyword, out value);
        }

        /// <summary>
        /// Adds an entry with the specified key and value into the <see cref="WhippetSqlServerConnectionStringBuilder"/> instance.
        /// </summary>
        /// <param name="keyword">The key to add to the <see cref="WhippetSqlServerConnectionStringBuilder"/>.</param>
        /// <param name="value">The value for the specified key.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="NotSupportedException" />
        public new void Add(string keyword, object value)
        {
            InternalBuilder.Add(keyword, value);
        }

        /// <summary>
        /// Compares the connection information in this <see cref="WhippetSqlServerConnectionStringBuilder"/> object with the connection information in the supplied object.
        /// </summary>
        /// <param name="connectionStringBuilder">The <see cref="DbConnectionStringBuilder"/> to be compared with this <see cref="WhippetSqlServerConnectionStringBuilder"/> object.</param>
        /// <returns><see langword="true"/> if the connection information in both of the <see cref="DbConnectionStringBuilder"/> objects causes an equivalent connection string; otherwise, <see langword="false"/>.</returns>
        public override bool EquivalentTo(DbConnectionStringBuilder connectionStringBuilder)
        {
            return InternalBuilder.EquivalentTo(connectionStringBuilder);
        }

        /// <summary>
        /// Returns the connection string associated with this <see cref="WhippetSqlServerConnectionStringBuilder"/>.
        /// </summary>
        /// <returns>The current <see cref="ConnectionString"/> property.</returns>
        public override string ToString()
        {
            return InternalBuilder.ToString();
        }

        /// <summary>
        /// Fills a supplied <see cref="Hashtable"/> with information about all the properties of the <see cref="WhippetSqlServerConnectionStringBuilder"/>.
        /// </summary>
        /// <param name="propertyDescriptors">The <see cref="Hashtable"/> to be filled with information about this <see cref="WhippetSqlServerConnectionStringBuilder"/>.</param>
        [RequiresUnreferencedCode("PropertyDescriptor's PropertyType cannot be statically discovered.")]
        protected override void GetProperties(Hashtable propertyDescriptors)
        {
            MethodInfo mInfo = typeof(DbConnectionStringBuilder).GetMethod(nameof(GetProperties), BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, new[] { typeof(Hashtable) }, null);
            mInfo.Invoke(InternalBuilder, new object[] { propertyDescriptors });
        }

        /// <summary>
        /// Strips the Docker container flag from the connection string.
        /// </summary>
        /// <param name="connectionString">Connection string to sanitize.</param>
        /// <returns>Sanitized connection string.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string StripDockerToken(string connectionString)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            else
            {
                StringBuilder csBuilder = null;
                Dictionary<string, string> tokens = null;

                string[] tokenPieces = null;
                string keyValuePair = String.Empty;
                string key = String.Empty;
                string value = String.Empty;

                bool hasDockerContainerToken = false;
                bool isDockerContainerInstance = false;
                
                if (connectionString.Contains(TOKEN_DOCKER_CONTAINER + "=true;", StringComparison.InvariantCultureIgnoreCase)
                    || connectionString.Contains(TOKEN_DOCKER_CONTAINER + "=false;", StringComparison.InvariantCultureIgnoreCase)
                    || connectionString.Contains(';' + TOKEN_DOCKER_CONTAINER + "=true", StringComparison.InvariantCultureIgnoreCase)
                    || connectionString.Contains(';' + TOKEN_DOCKER_CONTAINER + "=false", StringComparison.InvariantCultureIgnoreCase))
                {
                    hasDockerContainerToken = true;
                }

                if (hasDockerContainerToken)
                {
                    tokenPieces = connectionString.Split(new char[] { ';' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

                    csBuilder = new StringBuilder();
                    tokens = new Dictionary<string, string>();

                    if (tokenPieces != null && tokenPieces.Length > 0)
                    {
                        for (int i = 0; i < tokenPieces.Length; i++)
                        {
                            keyValuePair = tokenPieces[i].Trim();
                            key = keyValuePair.Substring(0, keyValuePair.IndexOf('='));
                            value = keyValuePair.Substring(keyValuePair.IndexOf('='));

                            if (!String.IsNullOrWhiteSpace(value) && value.StartsWith('='))
                            {
                                if (value.Length > 1)
                                {
                                    value = value.Substring(1);
                                }
                                else
                                {
                                    value = String.Empty;
                                }
                            }

                            if (!String.IsNullOrWhiteSpace(key))
                            {
                                tokens.Add(key, value);
                            }
                        }
                    }

                    foreach (KeyValuePair<string, string> entry in tokens)
                    {
                        if (!String.Equals(entry.Key?.Trim(), TOKEN_DOCKER_CONTAINER, StringComparison.InvariantCultureIgnoreCase))
                        {
                            csBuilder.Append(entry.Key);
                            csBuilder.Append('=');
                            csBuilder.Append(entry.Value);
                            csBuilder.Append(';');
                        }
                    }
                }
                else
                {
                    csBuilder = new StringBuilder(connectionString);
                }

                return csBuilder.ToString();                
            }
        }
        
        /// <summary>
        /// Sanitizes the specified connection string for use with NHibernate when connecting to a Docker SQL Server instance.
        /// </summary>
        /// <param name="connectionString">Connection string to sanitize.</param>
        /// <returns>Sanitized connection string.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string EnsureDockerCompatibility(string connectionString)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            else
            {
                StringBuilder csBuilder = null;
                Dictionary<string, string> tokens = null;

                string[] tokenPieces = null;
                string keyValuePair = String.Empty;
                string key = String.Empty;
                string value = String.Empty;

                bool hasDockerContainerToken = false;
                bool isDockerContainerInstance = false;
                
                if (connectionString.Contains(TOKEN_DOCKER_CONTAINER + "=true;", StringComparison.InvariantCultureIgnoreCase)
                    || connectionString.Contains(TOKEN_DOCKER_CONTAINER + "=false;", StringComparison.InvariantCultureIgnoreCase)
                    || connectionString.Contains(';' + TOKEN_DOCKER_CONTAINER + "=true", StringComparison.InvariantCultureIgnoreCase)
                    || connectionString.Contains(';' + TOKEN_DOCKER_CONTAINER + "=false", StringComparison.InvariantCultureIgnoreCase))
                {
                    hasDockerContainerToken = true;
                    isDockerContainerInstance = connectionString.Contains(TOKEN_DOCKER_CONTAINER + "=true", StringComparison.InvariantCultureIgnoreCase) || connectionString.Contains(';' + TOKEN_DOCKER_CONTAINER + "=true", StringComparison.InvariantCultureIgnoreCase);
                }

                if (hasDockerContainerToken)
                {
                    tokenPieces = connectionString.Split(new char[] { ';' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

                    csBuilder = new StringBuilder();
                    tokens = new Dictionary<string, string>();

                    if (tokenPieces != null && tokenPieces.Length > 0)
                    {
                        for (int i = 0; i < tokenPieces.Length; i++)
                        {
                            keyValuePair = tokenPieces[i].Trim();
                            key = keyValuePair.Substring(0, keyValuePair.IndexOf('='));
                            value = keyValuePair.Substring(keyValuePair.IndexOf('='));

                            if (!String.IsNullOrWhiteSpace(value) && value.StartsWith('='))
                            {
                                if (value.Length > 1)
                                {
                                    value = value.Substring(1);
                                }
                                else
                                {
                                    value = String.Empty;
                                }
                            }

                            if (!String.IsNullOrWhiteSpace(key))
                            {
                                tokens.Add(key, value);
                            }
                        }
                    }

                    foreach (KeyValuePair<string, string> entry in tokens)
                    {
                        if (isDockerContainerInstance && InvalidDockerTokens.Where(t => String.Equals(t?.Trim(), entry.Key?.Trim(), StringComparison.InvariantCultureIgnoreCase)).Any())
                        {
                            continue;
                        }
                        else
                        {
                            if (!String.Equals(entry.Key?.Trim(), TOKEN_DOCKER_CONTAINER, StringComparison.InvariantCultureIgnoreCase))
                            {
                                csBuilder.Append(entry.Key);
                                csBuilder.Append('=');
                                csBuilder.Append(entry.Value);
                                csBuilder.Append(';');
                            }
                        }
                    }
                }
                else
                {
                    csBuilder = new StringBuilder(connectionString);
                }

                return csBuilder.ToString();
            }
        }
    }
}
