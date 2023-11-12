using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.ComponentModel;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;
using MySql.Data.MySqlClient;
using Microsoft.Data.SqlClient;

namespace Athi.Whippet.Data.Database.Oracle.MySQL
{
    /// <summary>
    /// Aids in the creation of MySQL connection strings by exposing the connection options as properties. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetMySqlConnectionStringBuilder : DbConnectionStringBuilder, ICustomTypeDescriptor, IDictionary, IEnumerable
    {
        private MySqlConnectionStringBuilder _builder;

        /// <summary>
        /// Gets or sets the internal <see cref="MySqlConnectionStringBuilder"/> object.
        /// </summary>
        private MySqlConnectionStringBuilder InternalBuilder
        {
            get
            {
                if (_builder == null)
                {
                    _builder = new MySqlConnectionStringBuilder();
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
        /// Gets or sets the name of the server.
        /// </summary>
        public string Server
        {
            get
            {
                return InternalBuilder.Server;
            }
            set
            {
                InternalBuilder.Server = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the database for the initial connection.
        /// </summary>
        public string Database
        {
            get
            {
                return InternalBuilder.Database;
            }
            set
            {
                InternalBuilder.Database = value;
            }
        }

        /// <summary>
        /// Gets or sets the protocol that should be used for communicating with MySQL.
        /// </summary>
        public MySqlConnectionProtocol ConnectionProtocol
        {
            get
            {
                return InternalBuilder.ConnectionProtocol;
            }
            set
            {
                InternalBuilder.ConnectionProtocol = value;
            }
        }

        /// <summary>
        /// Gets or sets the port number that is used when the socket protocol is being used.
        /// </summary>
        public uint Port
        {
            get
            {
                return InternalBuilder.Port;
            }
            set
            {
                InternalBuilder.Port = value;
            }
        }

        /// <summary>
        /// Specifies whether the connection should resolve DNS SRV records.
        /// </summary>
        public bool DNS_SRV
        {
            get
            {
                return InternalBuilder.DnsSrv;
            }
            set
            {
                InternalBuilder.DnsSrv = value;
            }
        }

        /// <summary>
        /// Gets or sets the password for a second authentication that should be used to make a connection.
        /// </summary>
        public string Password2
        {
            get
            {
                return InternalBuilder.Password2;
            }
            set
            {
                InternalBuilder.Password2 = value;
            }
        }

        /// <summary>
        /// Gets or sets the password for a third authentication that should be used to make a connection.
        /// </summary>
        public string Password3
        {
            get
            {
                return InternalBuilder.Password3;
            }
            set
            {
                InternalBuilder.Password3 = value;
            }
        }

        /// <summary>
        /// Gets or sets the path to the certificate file to be used.
        /// </summary>
        public string CertificateFile
        {
            get
            {
                return InternalBuilder.CertificateFile;
            }
            set
            {
                InternalBuilder.CertificateFile = value;
            }
        }

        /// <summary>
        /// Gets or sets the password to be used in conjunction with the certificate file.
        /// </summary>
        public string CertificatePassword
        {
            get
            {
                return InternalBuilder.CertificatePassword;
            }
            set
            {
                InternalBuilder.CertificatePassword = value;
            }
        }

        /// <summary>
        /// Gets or sets the location to a personal store where a certificate is held.
        /// </summary>
        public MySqlCertificateStoreLocation CertificateStoreLocation
        {
            get
            {
                return InternalBuilder.CertificateStoreLocation;
            }
            set
            {
                InternalBuilder.CertificateStoreLocation = value;
            }
        }

        /// <summary>
        /// Gets or sets a certificate thumbprint to ensure correct identification of a certificate contained within a personal store.
        /// </summary>
        public string CertificateThumbprint
        {
            get
            {
                return InternalBuilder.CertificateThumbprint;
            }
            set
            {
                InternalBuilder.CertificateThumbprint = value;
            }
        }

        /// <summary>
        /// Indicates whether to use SSL connections and how to handle server certificate errors.
        /// </summary>
        public MySqlSslMode SecureSocketMode
        {
            get
            {
                return InternalBuilder.SslMode;
            }
            set
            {
                InternalBuilder.SslMode = value;
            }
        }

        /// <summary>
        /// Gets or sets the path to a local file that contains a list of trusted TLS/SSL certificate authorities.
        /// </summary>
        public string SecureSocketCerticiateAuthority
        {
            get
            {
                return InternalBuilder.SslCa;
            }
            set
            {
                InternalBuilder.SslCa = value;
            }
        }

        /// <summary>
        /// Specifies the TLS version(s) to use in an SSL connection to the server.
        /// </summary>
        public string TLS
        {
            get
            {
                return InternalBuilder.TlsVersion;
            }
            set
            {
                InternalBuilder.TlsVersion = value;
            }
        }

        /// <summary>
        /// Gets or sets the path to a local key file in PEM format to use for establishing an encrypted connection.
        /// </summary>
        public string SecureSocketKey
        {
            get
            {
                return InternalBuilder.SslKey;
            }
            set
            {
                InternalBuilder.SslKey = value;
            }
        }

        /// <summary>
        /// Gets or sets the path to a local certificate file in PEM format to use for establishing an encrypted connection.
        /// </summary>
        public string SecureSocketCertificate
        {
            get
            {
                return InternalBuilder.SslCert;
            }
            set
            {
                InternalBuilder.SslCert = value;
            }
        }

        /// <summary>
        /// Gets or sets the idle connection time (in seconds) for TCP connections.
        /// </summary>
        public uint KeepAlive
        {
            get
            {
                return InternalBuilder.Keepalive;
            }
            set
            {
                InternalBuilder.Keepalive = value;
            }
        }

        /// <summary>
        /// Gets or sets the character set that should be used for sending queries to the server.
        /// </summary>
        public string CharacterSet
        {
            get
            {
                return InternalBuilder.CharacterSet;
            }
            set
            {
                InternalBuilder.CharacterSet = value;
            }
        }

        /// <summary>
        /// Indicates whether the <see cref="WhippetMySqlConnectionStringBuilder"/> is read-only. This property is read-only.
        /// </summary>
        public new bool IsReadOnly
        {
            get
            {
                return InternalBuilder.IsReadOnly;
            }
        }

        /// <summary>
        /// Gets the current number of keys that are in the <see cref="WhippetMySqlConnectionStringBuilder"/>. This property is read-only.
        /// </summary>
        public override int Count
        {
            get
            {
                return InternalBuilder.Count;
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
        /// Gets a value that indicates whether the <see cref="WhippetMySqlConnectionStringBuilder"/> has a fixed size. This property is read-only.
        /// </summary>
        public override bool IsFixedSize
        {
            get
            {
                return InternalBuilder.IsFixedSize;
            }
        }

        /// <summary>
        /// Gets an <see cref="ICollection"/> that contains the keys in the <see cref="WhippetMySqlConnectionStringBuilder"/>. This property is read-only.
        /// </summary>
        public override ICollection Keys
        {
            get
            {
                return InternalBuilder.Keys;
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
        /// Gets or sets the name of the named pipe that should be used for communicating with the MySQL server.
        /// </summary>
        public string PipeName
        {
            get
            {
                return InternalBuilder.PipeName;
            }
            set
            {
                InternalBuilder.PipeName = value;
            }
        }

        /// <summary>
        /// Specifies whether the connection should use compression.
        /// </summary>
        public bool UseCompression
        {
            get
            {
                return InternalBuilder.UseCompression;
            }
            set
            {
                InternalBuilder.UseCompression = value;
            }
        }

        /// <summary>
        /// Specifies whether the connection will allow commands to send multiple SQL statements in one execution.
        /// </summary>
        public bool AllowBatch
        {
            get
            {
                return InternalBuilder.AllowBatch;
            }
            set
            {
                InternalBuilder.AllowBatch = value;
            }
        }

        /// <summary>
        /// Specifies whether logging is enabled.
        /// </summary>
        public bool Logging
        {
            get
            {
                return InternalBuilder.Logging;
            }
            set
            {
                InternalBuilder.Logging = value;
            }
        }

        /// <summary>
        /// Gets or sets the base name of the shared memory objects used to communicate with MySQL when the shared memory protocol is being used.
        /// </summary>
        public string SharedMemoryName
        {
            get
            {
                return InternalBuilder.SharedMemoryName;
            }
            set
            {
                InternalBuilder.SharedMemoryName = value;
            }
        }

        /// <summary>
        /// Gets or sets the default command timeout.
        /// </summary>
        public uint DefaultCommandTimeout
        {
            get
            {
                return InternalBuilder.DefaultCommandTimeout;
            }
            set
            {
                InternalBuilder.DefaultCommandTimeout = value;
            }
        }

        /// <summary>
        /// Gets or sets the connection timeout (in seconds).
        /// </summary>
        public uint ConnectionTimeout
        {
            get
            {
                return InternalBuilder.ConnectionTimeout;
            }
            set
            {
                InternalBuilder.ConnectionTimeout = value;
            }
        }

        /// <summary>
        /// Specifies whether the connection will allow the ability to load data from the local infile.
        /// </summary>
        public bool AllowLoadLocalInFile
        {
            get
            {
                return InternalBuilder.AllowLoadLocalInfile;
            }
            set
            {
                InternalBuilder.AllowLoadLocalInfile = value;
            }
        }

        /// <summary>
        /// Gets or sets the safe path where files can be read and uploaded to the server.
        /// </summary>
        public string LocalInFilePath
        {
            get
            {
                return InternalBuilder.AllowLoadLocalInfileInPath;
            }
            set
            {
                InternalBuilder.AllowLoadLocalInfileInPath = value;
            }
        }

        /// <summary>
        /// Specifies whether the RSA public keys should be retrieved from the server.
        /// </summary>
        public bool AllowPublicKeyRetrieval
        {
            get
            {
                return InternalBuilder.AllowPublicKeyRetrieval;
            }
            set
            {
                InternalBuilder.AllowPublicKeyRetrieval = value;
            }
        }

        /// <summary>
        /// Gets or sets the default authentication plugin to be used. This plugin takes precedence over the server-side default authentication plugin when a valid authentication plugin is specified.
        /// </summary>
        public string DefaultAuthenticationPlugin
        {
            get
            {
                return InternalBuilder.DefaultAuthenticationPlugin;
            }
            set
            {
                InternalBuilder.DefaultAuthenticationPlugin = value;
            }
        }

        /// <summary>
        /// Gets or sets the OCI configuration file location.
        /// </summary>
        public string OCIConfigurationFile
        {
            get
            {
                return InternalBuilder.OciConfigFile;
            }
            set
            {
                InternalBuilder.OciConfigFile = value;
            }
        }

        /// <summary>
        /// Gets or sets the API to be used in Kerberos authentication.
        /// </summary>
        public KerberosAuthMode KerberosAuthenticationMode
        {
            get
            {
                return InternalBuilder.KerberosAuthMode;
            }
            set
            {
                InternalBuilder.KerberosAuthMode = value;
            }
        }

        /// <summary>
        /// Specifies whether zero date/time values are supported.
        /// </summary>
        public bool AllowZeroDateTime
        {
            get
            {
                return InternalBuilder.AllowZeroDateTime;
            }
            set
            {
                InternalBuilder.AllowZeroDateTime = value;
            }
        }

        /// <summary>
        /// Specifies whether zero date/time values should be converted to <see cref="DateTime.MinValue"/>.
        /// </summary>
        public bool ConvertZeroDateTime
        {
            get
            {
                return InternalBuilder.ConvertZeroDateTime;
            }
            set
            {
                InternalBuilder.ConvertZeroDateTime = value;
            }
        }

        /// <summary>
        /// Specifies whether the Usage Advisor should be enabled.
        /// </summary>
        public bool UseUsageAdvisor
        {
            get
            {
                return InternalBuilder.UseUsageAdvisor;
            }
            set
            {
                InternalBuilder.UseUsageAdvisor = value;
            }
        }

        /// <summary>
        /// Gets or sets the size of the stored procedure cache.
        /// </summary>
        public uint ProcedureCacheSize
        {
            get
            {
                return InternalBuilder.ProcedureCacheSize;
            }
            set
            {
                InternalBuilder.ProcedureCacheSize = value;
            }
        }

        /// <summary>
        /// Specifies whether the performance monitor hooks should be enabled.
        /// </summary>
        public bool UsePerformanceMonitor
        {
            get
            {
                return InternalBuilder.UsePerformanceMonitor;
            }
            set
            {
                InternalBuilder.UsePerformanceMonitor = value;
            }
        }

        /// <summary>
        /// Specifies whether an opened connection should participate in the connection scope.
        /// </summary>
        public bool AutoEnlist
        {
            get
            {
                return InternalBuilder.AutoEnlist;
            }
            set
            {
                InternalBuilder.AutoEnlist = value;
            }
        }

        /// <summary>
        /// Specifies whether security asserts must be included.
        /// </summary>
        public bool IncludeSecurityAsserts
        {
            get
            {
                return InternalBuilder.IncludeSecurityAsserts;
            }
            set
            {
                InternalBuilder.IncludeSecurityAsserts = value;
            }
        }

        /// <summary>
        /// Specifies whether column binary flags set by the server are ignored.
        /// </summary>
        public bool RespectBinaryFlags
        {
            get
            {
                return InternalBuilder.RespectBinaryFlags;
            }
            set
            {
                InternalBuilder.RespectBinaryFlags = value;
            }
        }

        /// <summary>
        /// Specifies whether <b>TINYINT(1)</b> should be treated as <b>BOOLEAN</b>.
        /// </summary>
        public bool TreatTinyAsBoolean
        {
            get
            {
                return InternalBuilder.TreatTinyAsBoolean;
            }
            set
            {
                InternalBuilder.TreatTinyAsBoolean = value;
            }
        }

        /// <summary>
        /// Specifies whether the provider should expect user variables in the SQL.
        /// </summary>
        public bool AllowUserVariables
        {
            get
            {
                return InternalBuilder.AllowUserVariables;
            }
            set
            {
                InternalBuilder.AllowUserVariables = value;
            }
        }

        /// <summary>
        /// Specifies if the session should be interactive.
        /// </summary>
        public bool InteractiveSession
        {
            get
            {
                return InternalBuilder.InteractiveSession;
            }
            set
            {
                InternalBuilder.InteractiveSession = value;
            }
        }

        /// <summary>
        /// Specifies whether server functions should be treated as returning strings.
        /// </summary>
        public bool FunctionsReturnString
        {
            get
            {
                return InternalBuilder.FunctionsReturnString;
            }
            set
            {
                InternalBuilder.FunctionsReturnString = value;
            }
        }

        /// <summary>
        /// Specifies whether the server should report affected rows instead of found rows.
        /// </summary>
        public bool UseAffectedRows
        {
            get
            {
                return InternalBuilder.UseAffectedRows;
            }
            set
            {
                InternalBuilder.UseAffectedRows = value;
            }
        }

        /// <summary>
        /// Specifies whether items of data type <b>BINARY(16)</b> should be treated as GUIDs.
        /// </summary>
        public bool OldGUIDs
        {
            get
            {
                return InternalBuilder.OldGuids;
            }
            set
            {
                InternalBuilder.OldGuids = value;
            }
        }

        /// <summary>
        /// Specifies if SQL Server syntax should be allowed by supporting square brackets around symbols instead of backticks.
        /// </summary>
        public bool SQLServerMode
        {
            get
            {
                return InternalBuilder.SqlServerMode;
            }
            set
            {
                InternalBuilder.SqlServerMode = value;
            }
        }

        /// <summary>
        /// Specifies whether caching of TableDirect commands is enabled.
        /// </summary>
        public bool TableCaching
        {
            get
            {
                return InternalBuilder.TableCaching;
            }
            set
            {
                InternalBuilder.TableCaching = value;
            }
        }

        /// <summary>
        /// Gets or sets the seconds for how long a TableDirect result should be cached.
        /// </summary>
        public int DefaultTableCacheAge
        {
            get
            {
                return InternalBuilder.DefaultTableCacheAge;
            }
            set
            {
                InternalBuilder.DefaultTableCacheAge = value;
            }
        }

        /// <summary>
        /// Specifies whether stored routine parameters should be checked against the server.
        /// </summary>
        public bool CheckParameters
        {
            get
            {
                return InternalBuilder.CheckParameters;
            }
            set
            {
                InternalBuilder.CheckParameters = value;
            }
        }

        /// <summary>
        /// Gets or sets the list of interceptors that can triage <see cref="MySqlException"/> instances thrown.
        /// </summary>
        public string ExceptionInterceptors
        {
            get
            {
                return InternalBuilder.ExceptionInterceptors;
            }
            set
            {
                InternalBuilder.ExceptionInterceptors = value;
            }
        }

        /// <summary>
        /// Gets or sets the list of interceptors that can intercept command operations.
        /// </summary>
        public string CommandInterceptors
        {
            get
            {
                return InternalBuilder.CommandInterceptors;
            }
            set
            {
                InternalBuilder.CommandInterceptors = value;
            }
        }

        /// <summary>
        /// Gets or sets the lifetime of a pooled connection (in seconds).
        /// </summary>
        public uint ConnectionLifeTime
        {
            get
            {
                return InternalBuilder.ConnectionLifeTime;
            }
            set
            {
                InternalBuilder.ConnectionLifeTime = value;
            }
        }

        /// <summary>
        /// Gets or sets the minimum pool size.
        /// </summary>
        public uint MinimumPoolSize
        {
            get
            {
                return InternalBuilder.MinimumPoolSize;
            }
            set
            {
                InternalBuilder.MinimumPoolSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum pool size.
        /// </summary>
        public uint MaximumPoolSize
        {
            get
            {
                return InternalBuilder.MaximumPoolSize;
            }
            set
            {
                InternalBuilder.MaximumPoolSize = value;
            }
        }

        /// <summary>
        /// Specifies whether the connection should be reset when retrieved from the pool.
        /// </summary>
        public bool ConnectionReset
        {
            get
            {
                return InternalBuilder.ConnectionReset;
            }
            set
            {
                InternalBuilder.ConnectionReset = value;
            }
        }

        /// <summary>
        /// Specifies whether the server variable settings are updated by a <b>SHOW VARIABLES</b> command each time a pooled connection is returned.
        /// </summary>
        public bool CacheServerProperties
        {
            get
            {
                return InternalBuilder.CacheServerProperties;
            }
            set
            {
                InternalBuilder.CacheServerProperties = value;
            }
        }

        /// <summary>
        /// Specifies whether binary BLOBs should be treated as UTF-8 format.
        /// </summary>
        public bool TreatBLOBsAsUTF8
        {
            get
            {
                return InternalBuilder.TreatBlobsAsUTF8;
            }
            set
            {
                InternalBuilder.TreatBlobsAsUTF8 = value;
            }
        }

        /// <summary>
        /// Gets or sets the pattern to match for the columns that should be treated as UTF-8.
        /// </summary>
        public string BLOBAsUTF8IncludePattern
        {
            get
            {
                return InternalBuilder.BlobAsUTF8IncludePattern;
            }
            set
            {
                InternalBuilder.BlobAsUTF8IncludePattern = value;
            }
        }

        /// <summary>
        /// Gets or sets the pattern to match for the columns that should not be treated as UTF-8.
        /// </summary>
        public string BLOBAsUTF8ExcludePattern
        {
            get
            {
                return InternalBuilder.BlobAsUTF8ExcludePattern;
            }
            set
            {
                InternalBuilder.BlobAsUTF8ExcludePattern = value;
            }
        }

        /// <summary>
        /// Gets an <see cref="ICollection"/> that contains the values in the <see cref="WhippetMySqlConnectionStringBuilder"/>. This property is read-only.
        /// </summary>
        public override ICollection Values
        {
            get
            {
                return InternalBuilder.Values;
            }
        }

        /// <summary>
        /// 
        /// </summary>
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
        /// Initializes a new instance of the <see cref="WhippetMySqlConnectionStringBuilder"/> class with no arguments.
        /// </summary>
        public WhippetMySqlConnectionStringBuilder()
            : this(new MySqlConnectionStringBuilder())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlConnectionStringBuilder"/> class with the specified <see cref="MySqlConnectionStringBuilder"/> object.
        /// </summary>
        /// <param name="builder"><see cref="MySqlConnectionStringBuilder"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetMySqlConnectionStringBuilder(MySqlConnectionStringBuilder builder)
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
        /// Initializes a new instance of the <see cref="WhippetMySqlConnectionStringBuilder"/> class with the specified connection string.
        /// </summary>
        /// <param name="connectionString">Connection string to initialize with.</param>
        /// <param name="isAnalyzed">Specifies whether the connection string has been analyzed prior to instantiation.</param>
        /// <exception cref="ArgumentException" />
        /// <exception cref="FormatException" />
        /// <exception cref="KeyNotFoundException" />
        public WhippetMySqlConnectionStringBuilder(string connectionString, bool isAnalyzed = false)
            : this(new MySqlConnectionStringBuilder(connectionString))
        { }

        /// <summary>
        /// Clears the contents of the <see cref="WhippetMySqlConnectionStringBuilder"/> instance.
        /// </summary>
        public override void Clear()
        {
            InternalBuilder.Clear();
        }

        /// <summary>
        /// Determines whether the <see cref="WhippetMySqlConnectionStringBuilder"/> contains a specific key.
        /// </summary>
        /// <param name="keyword">The key to locate in the <see cref="WhippetMySqlConnectionStringBuilder"/>.</param>
        /// <returns><see langword="true"/> if the <see cref="WhippetMySqlConnectionStringBuilder"/> contains an element that has the specified key; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        public override bool ContainsKey(string keyword)
        {
            return InternalBuilder.ContainsKey(keyword);
        }

        /// <summary>
        /// Removes an entry with the specified key from the <see cref="WhippetMySqlConnectionStringBuilder"/> instance.
        /// </summary>
        /// <param name="keyword">The key of the key/value pair to be removed from the connection string in this <see cref="WhippetMySqlConnectionStringBuilder"/>.</param>
        /// <returns><see langword="true"/> if the key existed within the connection string and was removed; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        public override bool Remove(string keyword)
        {
            return InternalBuilder.Remove(keyword);
        }

        /// <summary>
        /// Indicates whether the specified key and associated value should be serialized.
        /// </summary>
        /// <param name="keyword">The key of the key/value pair to in the connection string in this <see cref="WhippetMySqlConnectionStringBuilder"/>.</param>
        /// <returns><see langword="true"/> if the key/value pair should be serialized; otherwise, <see langword="false"/>.</returns>
        public override bool ShouldSerialize(string keyword)
        {
            return InternalBuilder.ShouldSerialize(keyword);
        }

        /// <summary>
        /// Retrieves a value corresponding to the supplied key from this <see cref="WhippetMySqlConnectionStringBuilder"/>.
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
        /// Adds an entry with the specified key and value into the <see cref="WhippetMySqlConnectionStringBuilder"/> instance.
        /// </summary>
        /// <param name="keyword">The key to add to the <see cref="WhippetMySqlConnectionStringBuilder"/>.</param>
        /// <param name="value">The value for the specified key.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="NotSupportedException" />
        public new void Add(string keyword, object value)
        {
            InternalBuilder.Add(keyword, value);
        }

        /// <summary>
        /// Compares the connection information in this <see cref="WhippetMySqlConnectionStringBuilder"/> object with the connection information in the supplied object.
        /// </summary>
        /// <param name="connectionStringBuilder">The <see cref="DbConnectionStringBuilder"/> to be compared with this <see cref="WhippetMySqlConnectionStringBuilder"/> object.</param>
        /// <returns><see langword="true"/> if the connection information in both of the <see cref="DbConnectionStringBuilder"/> objects causes an equivalent connection string; otherwise, <see langword="false"/>.</returns>
        public override bool EquivalentTo(DbConnectionStringBuilder connectionStringBuilder)
        {
            return InternalBuilder.EquivalentTo(connectionStringBuilder);
        }

        /// <summary>
        /// Returns the connection string associated with this <see cref="WhippetMySqlConnectionStringBuilder"/>.
        /// </summary>
        /// <returns>The current <see cref="ConnectionString"/> property.</returns>
        public override string ToString()
        {
            return InternalBuilder.ToString();
        }

        /// <summary>
        /// Fills a supplied <see cref="Hashtable"/> with information about all the properties of the <see cref="WhippetMySqlConnectionStringBuilder"/>.
        /// </summary>
        /// <param name="propertyDescriptors">The <see cref="Hashtable"/> to be filled with information about this <see cref="WhippetMySqlConnectionStringBuilder"/>.</param>
        [RequiresUnreferencedCode("PropertyDescriptor's PropertyType cannot be statically discovered.")]
        protected override void GetProperties(Hashtable propertyDescriptors)
        {
            MethodInfo mInfo = typeof(DbConnectionStringBuilder).GetMethod(nameof(GetProperties), BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, new[] { typeof(Hashtable) }, null);
            mInfo.Invoke(InternalBuilder, new object[] { propertyDescriptors });
        }

        /// <summary>
        /// Returns the connection string.
        /// </summary>
        /// <param name="includePassword">If <see langword="true"/>, will include the password used for authentication.</param>
        /// <returns>Connection string.</returns>
        public string GetConnectionString(bool includePassword)
        {
            return InternalBuilder.GetConnectionString(includePassword);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return InternalBuilder.Equals(obj);
        }

        /// <summary>
        /// Gets the hash code for the current instance.
        /// </summary>
        /// <returns>Hash code for the current instance.</returns>
        public override int GetHashCode()
        {
            return InternalBuilder.GetHashCode();
        }

        /// <summary>
        /// Returns a collection of custom attributes for this instance of a component.
        /// </summary>
        /// <returns><see cref="AttributeCollection"/> object.</returns>
        AttributeCollection ICustomTypeDescriptor.GetAttributes()
        {
            return ((ICustomTypeDescriptor)(InternalBuilder)).GetAttributes();
        }

        /// <summary>
        /// Returns the class name of this instance of a component.
        /// </summary>
        /// <returns>Class name.</returns>
        string ICustomTypeDescriptor.GetClassName()
        {
            return ((ICustomTypeDescriptor)(InternalBuilder)).GetClassName();
        }

        /// <summary>
        /// Returns the name of this instance of a component.
        /// </summary>
        /// <returns>The name of the object, or <see langword="null"/> if the object does not have a name.</returns>
        string ICustomTypeDescriptor.GetComponentName()
        {
            return ((ICustomTypeDescriptor)(InternalBuilder)).GetComponentName();
        }

        /// <summary>
        /// Returns a type converter for this instance of a component.
        /// </summary>
        /// <returns>A <see cref="TypeConverter"/> that is the converter for this object or <see langword="null"/> if there is no <see cref="TypeConverter"/> for this object.</returns>
        [RequiresUnreferencedCode("Generic TypeConverters may require the generic types to be annotated. For example, NullableConverter requires the underlying type to be DynamicallyAccessedMembers All.")]
        TypeConverter ICustomTypeDescriptor.GetConverter()
        {
            return ((ICustomTypeDescriptor)(InternalBuilder)).GetConverter();
        }

        /// <summary>
        /// Returns the default event for this instance of a component.
        /// </summary>
        /// <returns>An <see cref="EventDescriptor"/> that represents the default event for this object or <see langword="null"/> if this object does not have events.</returns>
        [RequiresUnreferencedCode("The built-in EventDescriptor implementation uses Reflection which requires unreferenced code.")]
        EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
        {
            return ((ICustomTypeDescriptor)(InternalBuilder)).GetDefaultEvent();
        }

        /// <summary>
        /// Returns the default property for this instance of a component.
        /// </summary>
        /// <returns>An <see cref="PropertyDescriptor"/> that represents the default property for this object or <see langword="null"/> if this object does not have properties.</returns>
        [RequiresUnreferencedCode("PropertyDescriptor's PropertyType cannot be statically discovered.")]
        PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
        {
            return ((ICustomTypeDescriptor)(InternalBuilder)).GetDefaultProperty();
        }

        /// <summary>
        /// Returns an editor of the specified type for this instance of a component.
        /// </summary>
        /// <param name="editorBaseType">A <see cref="Type"/> that represents the editor for this object.</param>
        /// <returns>An <see cref="Object"/> of the specified type that is the editor for this object or <see langword="null"/> if the editor cannot be found.</returns>
        [RequiresUnreferencedCode("Editors registered in TypeDescriptor.AddEditorTable may be trimmed.")]
        object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
        {
            return ((ICustomTypeDescriptor)(InternalBuilder)).GetEditor(editorBaseType);
        }

        /// <summary>
        /// Returns the events for this instance of a component.
        /// </summary>
        /// <returns>An <see cref="EventDescriptorCollection"/> that represents the events for this component instance.</returns>
        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        {
            return ((ICustomTypeDescriptor)(InternalBuilder)).GetEvents();
        }

        /// <summary>
        /// Returns the events for this instance of a component using the specified attribute array as a filter.
        /// </summary>
        /// <param name="attributes">An array of type <see cref="Attribute"/> that is used as a filter.</param>
        /// <returns>An <see cref="EventDescriptorCollection"/> that represents the filtered events for this component instance.</returns>
        [RequiresUnreferencedCode("The public parameterless constructor or the 'Default' static field may be trimmed from the Attribute's Type.")]
        EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
        {
            return ((ICustomTypeDescriptor)(InternalBuilder)).GetEvents(attributes);
        }

        /// <summary>
        /// Returns the properties for this instance of a component.
        /// </summary>
        /// <returns>A <see cref="PropertyDescriptorCollection"/> that represents the properties for this component instance.</returns>
        [RequiresUnreferencedCode("PropertyDescriptor's PropertyType cannot be statically discovered.")]
        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            return ((ICustomTypeDescriptor)(InternalBuilder)).GetProperties();
        }

        /// <summary>
        /// Returns the properties for this instance of a component using the attribute array as a filter.
        /// </summary>
        /// <param name="attributes">An array of type <see cref="Attribute"/> that is used as a filter.</param>
        /// <returns>An <see cref="PropertyDescriptorCollection"/> that represents the filtered properties for this component instance.</returns>
        [RequiresUnreferencedCode("PropertyDescriptor's PropertyType cannot be statically discovered. The public parameterless constructor or the 'Default' static field may be trimmed from the Attribute's Type.")]
        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
        {
            return ((ICustomTypeDescriptor)(InternalBuilder)).GetProperties(attributes);
        }

        /// <summary>
        /// Returns an object that contains the property described by the specified property descriptor.
        /// </summary>
        /// <param name="pd">A <see cref="PropertyDescriptor"/> that represents the property whose owner is to be found.</param>
        /// <returns>An <see cref="Object"/> that represents the owner of the specified property.</returns>
        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
        {
            return ((ICustomTypeDescriptor)(InternalBuilder)).GetPropertyOwner(pd);
        }

        public static implicit operator WhippetMySqlConnectionStringBuilder(MySqlConnectionStringBuilder builder)
        {
            return (builder == null) ? null : new WhippetMySqlConnectionStringBuilder(builder);
        }

        public static implicit operator MySqlConnectionStringBuilder(WhippetMySqlConnectionStringBuilder builder)
        {
            return (builder == null) ? null : builder.InternalBuilder;
        }
    }
}