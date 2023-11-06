using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Reflection;
using System.Net.Http;
using System.Net.Http.Headers;
using CouchDB.Driver;
using CouchDB.Driver.Options;
using Athi.Whippet.Extensions.Primitives;

namespace Athi.Whippet.Data.Database.NoSQL.Apache.CouchDB
{
    /// <summary>
    /// Represents a connection to an Apache CouchDB instance.
    /// </summary>
    public class WhippetCouchDBConnection : CouchClient, IDbConnection, IDisposable
    {
        private const ushort DEFAULT_PORT = 5984;

        private const string DEFAULT_HOST = "http://127.0.0.1";
        private const string DEFAULT_OPTIONS_FIELD_NAME = "_options";

        private CouchOptions _InternalOptions;

        /// <summary>
        /// Gets the <see cref="CouchOptions"/> that were used to construct the connection. This property is read-only.
        /// </summary>
        public CouchOptions Options
        {
            get
            {
                FieldInfo[] fields = null;
                FieldInfo optionField = null;

                bool found = false;

                if (_InternalOptions == null)
                {
                    fields = typeof(CouchClient).GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

                    if (fields != null && fields.Length > 0)
                    {
                        optionField = fields.Where(f => typeof(CouchOptions).Equals(f.FieldType) && String.Equals(f.Name?.Trim(), DEFAULT_OPTIONS_FIELD_NAME, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                        if (optionField == null)
                        {
                            optionField = fields.Where(f => typeof(CouchOptions).Equals(f.FieldType)).FirstOrDefault();     // grab the first instance of CouchOptions as there should only be one
                            found = (optionField != null);
                        }
                        else
                        {
                            found = true;
                        }

                        if (found)
                        {
                            _InternalOptions = optionField.GetValue((CouchClient)(this)) as CouchOptions;
                        }
                    }
                }

                return _InternalOptions;
            }
        }

        /// <summary>
        /// Gets the connection string used to connect to the CouchDB instance. This property is read-only.
        /// </summary>
        /// <exception cref="InvalidOperationException" />
        string IDbConnection.ConnectionString
        {
            get
            {
                return ConnectionString;
            }
            set
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Gets the connection string used to connect to the CouchDB instance. This property is read-only.
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return base.Endpoint?.ToString();
            }
        }

        /// <summary>
        /// Gets the time to wait(in seconds) while trying to establish a connection before terminating the attempt and generating an error. This property is read-only.
        /// </summary>
        int IDbConnection.ConnectionTimeout
        {
            get
            {
                return 0;   // depends on RestSharp
            }
        }

        /// <summary>
        /// Gets the name of the current database or the database to be used after a connection is opened. This property is read-only.
        /// </summary>
        string IDbConnection.Database
        {
            get
            {
                return String.Empty;    // CouchDB is stateless
            }
        }

        /// <summary>
        /// Gets the current state of the connection. This property is read-only.
        /// </summary>
        ConnectionState IDbConnection.State
        {
            get
            {
                return ConnectionState.Open;
            }
        }

        /// <summary>
        /// Gets the username used to connect to the database. This property is read-only.
        /// </summary>
        public string Username
        { get; private set; }

        /// <summary>
        /// Gets the password used to connect to the database. This property is read-only.
        /// </summary>
        public string Password
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCouchDBConnection"/> class with no arguments.
        /// </summary>
        private WhippetCouchDBConnection()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCouchDBConnection"/> class with the specified <see cref="Uri"/>.
        /// </summary>
        /// <param name="clientUrl"><see cref="Uri"/> representing the address and port number to the CouchDB instance.</param>
        /// <param name="username">Connection username.</param>
        /// <param name="password">Connection password.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetCouchDBConnection(Uri clientUrl, string username, string password)
            : this(options =>
            {
                PopulateOptionsBuilderInternal(options, clientUrl, username, password);
                
            })
        {
            if (String.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException(nameof(username));
            }
            else if (String.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password));
            }
            else
            {
                Username = username;
                Password = password;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCouchDBConnection"/> class with the specified URL.
        /// </summary>
        /// <param name="url">URL representing the address of the CouchDB instance.</param>
        /// <param name="username">Connection username.</param>
        /// <param name="password">Connection password.</param>
        /// <param name="port">Port number of the CouchDB instance.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetCouchDBConnection(string url, string username, string password, ushort port = DEFAULT_PORT)
            : this(BuildUrl(url, port), username, password)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCouchDBConnection"/> class with the delegate to assign attributes to the connection using a <see cref="CouchOptionsBuilder"/>.
        /// </summary>
        /// <param name="builder"><see cref="CouchOptionsBuilder"/> object.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetCouchDBConnection(Action<CouchOptionsBuilder> builder)
            : base(builder)
        {
            ArgumentNullException.ThrowIfNull(builder);
        }

        /// <summary>
        /// Builds an <see cref="HttpClient"/> object for the current <see cref="WhippetCouchDBConnection"/> based on the current username and password values.
        /// </summary>
        /// <param name="authenticationValue"><see cref="AuthenticationHeaderValue"/> to use or <see langword="null"/> to use basic authentication.</param>
        /// <returns><see cref="HttpClient"/> object.</returns>
        public HttpClient BuildHttpClient(AuthenticationHeaderValue authenticationValue = null)
        {
            HttpClient client = new HttpClient();
            
            client.BaseAddress = Endpoint;

            if (authenticationValue == null)
            {
                client.DefaultRequestHeaders.Authorization = BuildAuthenticationHeader();
            }
            else
            {
                client.DefaultRequestHeaders.Authorization = authenticationValue;
            }

            return client;
        }

        /// <summary>
        /// Creates an <see cref="AuthenticationHeaderValue"/> for the current <see cref="WhippetCouchDBConnection"/> using basic authentication.
        /// </summary>
        /// <returns><see cref="AuthenticationHeaderValue"/> object.</returns>
        public AuthenticationHeaderValue BuildAuthenticationHeader()
        {
            return new AuthenticationHeaderValue("Basic", (Username + ":" + Password).ToBase64());
        }
        
        /// <summary>
        /// Constructs a new <see cref="Uri"/> object based on the specified URL and port number.
        /// </summary>
        /// <param name="url">Base URL.</param>
        /// <param name="port">Port number.</param>
        /// <returns><see cref="Uri"/> object.</returns>
        private static Uri BuildUrl(string url, ushort port)
        {
            UriBuilder builder = new UriBuilder(url);
            builder.Port = port;

            return builder.Uri;
        }

        /// <summary>
        /// Constructs a very simple <see cref="CouchOptionsBuilder"/> with basic authentication.
        /// </summary>
        /// <param name="options"><see cref="CouchOptionsBuilder"/> object.</param>
        /// <param name="endpoint">Endpoint of the CouchDB server.</param>
        /// <param name="username">Username to authenticate with.</param>
        /// <param name="password">Password to authenticate with.</param>
        private static void PopulateOptionsBuilderInternal(CouchOptionsBuilder options, Uri endpoint, string username, string password)
        {
            if (options != null)
            {
                options
                    .UseEndpoint(endpoint)
                    .EnsureDatabaseExists()
                    .UseBasicAuthentication(username, password);
            }
        }

        /// <summary>
        /// Constructs a very simple <see cref="CouchOptionsBuilder"/> with basic authentication.
        /// </summary>
        /// <param name="options"><see cref="CouchOptionsBuilder"/> object.</param>
        public void PopulateOptionsBuilder(CouchOptionsBuilder options)
        {
            PopulateOptionsBuilderInternal(options, Endpoint, Username, Password);
        }

        /// <summary>
        /// Creates a new <see cref="WhippetCouchDBConnection"/> object from a connection string.
        /// </summary>
        /// <param name="connectionString">CouchDB connection string.</param>
        /// <returns><see cref="WhippetCouchDBConnection"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static WhippetCouchDBConnection BuildFromConnectionString(string connectionString)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            else
            {
                const string TOKEN_SERVER = "Server";
                const string TOKEN_USERNAME = "username";
                const string TOKEN_PASSWORD = "password";

                //Server=localhost:5984;username=admin;password=webbdash

                string[] pieces = connectionString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                StringBuilder builder = null;

                Uri serverUrl = null;
                string username = null;
                string password = null;
                string token = null;

                if (pieces == null || pieces.Length < 3)
                {
                    throw new ArgumentException();
                }
                else
                {
                    for (int i = 0; i < pieces.Length; i++)
                    {
                        builder = new StringBuilder();
                        token = null;

                        // build the token

                        for (int j = 0; j < pieces[i].Length; j++)
                        {
                            if (pieces[i][j] == '=')
                            {
                                // we've hit the assignment operator, get the rest of the string

                                if (pieces[i].IndexOf('=') < pieces[i].Length - 1)
                                {
                                    token = pieces[i].Substring(pieces[i].IndexOf('=') + 1);
                                    break;
                                }
                            }
                            else
                            {
                                builder.Append(pieces[i][j]);
                            }
                        }

                        if (!String.IsNullOrWhiteSpace(builder.ToString()) && !String.IsNullOrWhiteSpace(token))
                        {
                            // see what token we have

                            if (String.Equals(builder.ToString().Trim(), TOKEN_SERVER, StringComparison.InvariantCultureIgnoreCase))
                            {
                                serverUrl = new Uri(token);
                            }
                            else if (String.Equals(builder.ToString().Trim(), TOKEN_USERNAME, StringComparison.InvariantCultureIgnoreCase))
                            {
                                username = token;
                            }
                            else if (String.Equals(builder.ToString().Trim(), TOKEN_PASSWORD, StringComparison.InvariantCultureIgnoreCase))
                            {
                                password = token;
                            }

                            // if no tokens match, ignore it and move onto next
                        }
                    }

                    return new WhippetCouchDBConnection(serverUrl, username, password);
                }
            }
        }

        /// <summary>
        /// Begins a database transaction. This method is not supported.
        /// </summary>
        /// <returns>An object representing the new transaction.</returns>
        /// <exception cref="NotSupportedException"></exception>
        IDbTransaction IDbConnection.BeginTransaction()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Begins a database transaction with the specified IsolationLevel value.
        /// </summary>
        /// <param name="il">One of the <see cref="IsolationLevel"/> values.</param>
        /// <returns>An object representing the new transaction.</returns>
        /// <exception cref="NotSupportedException"></exception>
        IDbTransaction IDbConnection.BeginTransaction(IsolationLevel il)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Closes the connection to the database.
        /// </summary>
        void IDbConnection.Close()
        { }

        /// <summary>
        /// Changes the current database for an open connection object. This method is not supported.
        /// </summary>
        /// <param name="databaseName">The name of the database to use in place of the current database.</param>
        /// <exception cref="NotSupportedException"></exception>
        void IDbConnection.ChangeDatabase(string databaseName)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Creates and returns an <see cref="IDbCommand"/> object associated with the connection.
        /// </summary>
        /// <returns>An <see cref="IDbCommand"/> object associated with the connection.</returns>
        /// <exception cref="NotSupportedException"></exception>
        IDbCommand IDbConnection.CreateCommand()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Opens a database connection with the settings specified by the <see cref="ConnectionString"/> property of the provider-specific <see cref="IDbConnection"/> object.
        /// </summary>
        void IDbConnection.Open()
        { }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public void Dispose()
        {
            Task.Run(() => DisposeAsync());
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return (Endpoint == null) ? base.ToString() : Endpoint.ToString();
        }
    }
}
