using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Athi.Whippet.Tools.Installer
{
    /// <summary>
    /// Install runner for the core Whippet application framework. This class must be inherited.
    /// </summary>
    [Obsolete("This component is deprecated and will be removed in a future version.")]
    public abstract class WhippetInstallRunner : InstallRunner, IDisposable, IWhippetInstallRunner
    {
        internal const string DEFAULT_DB_NAME = "Whippet";

        /// <summary>
        /// Gets or sets the database name. By default, this is set to "Whippet".
        /// </summary>
        public static string DatabaseName
        { get; set; } = DEFAULT_DB_NAME;

        /// <summary>
        /// Indicates whether the <see cref="ConnectionString"/> value points to a database that is hosted on a Linux Docker container.
        /// </summary>
        public static bool DatabaseIsSqlServerLinuxContainer
        { get; set; }

        /// <summary>
        /// Gets the <see cref="ISession"/> used to set the current database connection. This property is read-only.
        /// </summary>
        public virtual ISession Session
        { get; private set; }

        /// <summary>
        /// Gets the connection string used to set the current database connection. This property is read-only.
        /// </summary>
        public virtual string ConnectionString
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetInstallRunner"/> class with no arguments.
        /// </summary>
        private WhippetInstallRunner()
            : base("Whippet", "Installs the core Whippet application framework.")
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetInstallRunner"/> class.
        /// </summary>
        /// <param name="session"><see cref="ISession"/> that provides a context to the data store.</param>
        /// <param name="installerName">Name of the product or application the installer implements.</param>
        /// <param name="installerDescription">Installer description.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetInstallRunner(ISession session, string installerName, string installerDescription)
            : base(installerName, installerDescription)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            else
            {
                Session = session;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetInstallRunner"/> class.
        /// </summary>
        /// <param name="connectionString">Connection string to the data store.</param>
        /// <param name="installerName">Name of the product or application the installer implements.</param>
        /// <param name="installerDescription">Installer description.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetInstallRunner(string connectionString, string installerName, string installerDescription)
            : base(installerName, installerDescription)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            else
            {
                ConnectionString = connectionString;
            }
        }

        /// <summary>
        /// Disposes of the object and releases its resources from memory.
        /// </summary>
        public virtual void Dispose()
        {
            if (Session != null)
            {
                Session.Dispose();
            }
        }
    }
}
