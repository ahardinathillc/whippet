using System;
using Athi.Whippet.Data.NHibernate;
using Athi.Whippet.Data.Database;
using Athi.Whippet.Data.Database.Microsoft;
using Athi.Whippet.Data.Database.Oracle.MySQL;
using PasswordGenerator;

namespace Athi.Whippet.Installer.Framework.Database
{
    /// <summary>
    /// Installs the Whippet database. This class cannot be inherited.
    /// </summary>
    public sealed class DatabaseInstaller : InstallerBase, IInstaller
    {
        /// <summary>
        /// Indicates whether the installer supports asynchronous execution. This property is read-only.
        /// </summary>
        public override bool SupportsAsync
        {
            get
            {
                return false;
            }
        }
        
        /// <summary>
        /// Gets or sets the database name to use when creating the instance.
        /// </summary>
        private string DatabaseName
        { get; set; }
        
        /// <summary>
        /// Gets or sets the database password to use when creating the login.
        /// </summary>
        private string DatabaseUserPassword
        { get; set; }
        
        /// <summary>
        /// Database connection used to execute each action.
        /// </summary>
        private WhippetDatabaseConnection Connection
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseInstaller"/> class with the specified parameters.
        /// </summary>
        /// <param name="actions">Collection of <see cref="IInstallerAction"/> actions to perform sorted by their execution order.</param>
        /// <param name="updateProgressPercentage"><see cref="Action{T}"/> that updates the current progress percentage of the task execution.</param>
        /// <param name="errorHandler"><see cref="Action{T}"/> that handles caught exceptions and processes them, such as logging.</param>
        private DatabaseInstaller(IEnumerable<KeyValuePair<int, IInstallerAction>> actions, Action<double> updateProgressPercentage = null, Action<Exception> errorHandler = null)
            : base(actions, updateProgressPercentage, errorHandler)
        { }

        /// <summary>
        /// Executes the current installer with the provided arguments.
        /// </summary>
        /// <param name="args">Arguments to supply to the install actions (if any).</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public override WhippetResultContainer<object> Install(params object[] args)
        {
            WhippetResultContainer<object> result = null;
            int complete = 0;
            
            try
            {
                foreach (KeyValuePair<int, IInstallerAction> action in Actions)
                {
                    if (action.Value != null)
                    {
                        result = action.Value.Execute(Connection, DatabaseName, DatabaseUserPassword);
                        complete++;
                        UpdateProgress(complete);
                    }

                    if (!result.IsSuccess)
                    {
                        HandleError(result.Exception);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<object>(e);
                HandleError(e);
            }

            return result;
        }

        /// <summary>
        /// Executes the current installer asynchronously with the specified parameters.
        /// </summary>
        /// <param name="args">Parameters to pass to the installer actions (if any).</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotSupportedException"></exception>
        public override Task<WhippetResultContainer<object>> InstallAsync(IEnumerable<object> args = null, CancellationToken token = default(CancellationToken))
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Creates a new instance of the <see cref="DatabaseInstaller"/> class with the specified parameters.
        /// </summary>
        /// <param name="databaseConnection"><see cref="WhippetDatabaseConnection"/> object used to connect to the database.</param>
        /// <param name="databaseName">Database name.</param>
        /// <param name="updateProgressPercentage"><see cref="Action{T}"/> that updates the progress percentage of the installer.</param>
        /// <param name="errorHandler"><see cref="Action{T}"/> that reports exceptions to an external caller.</param>
        /// <returns><see cref="DatabaseInstaller"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DatabaseInstaller CreateInstaller(WhippetDatabaseConnection databaseConnection, string databaseName = null, Action<double> updateProgressPercentage = null, Action<Exception> errorHandler = null)
        {
            if (databaseConnection == null)
            {
                throw new ArgumentNullException(nameof(databaseConnection));
            }
            else
            {
                SortedList<int, IInstallerAction> actions = new SortedList<int, IInstallerAction>();

                DatabaseInstaller installer = null;
                
                IInstallerAction dbCreateAction = null;
                IInstallerAction dbCreateSchemaAction = null;
                IInstallerAction dbLoginAction = null;
                IInstallerAction dbPrincipalAction = null;

                IPassword password = null;
                
                // determine the type of install action to get

                if (databaseConnection is WhippetSqlServerConnection)
                {
                    dbCreateAction = new DBCreateAction.MSSQL();
                    dbCreateSchemaAction = new DBCreateSchemaAction.MSSQL();
                    dbLoginAction = new DBCreateLoginAction.MSSQL();
                    dbPrincipalAction = new DBCreatePrincipalAction.MSSQL();
                }
                else if (databaseConnection is WhippetMySqlConnection)
                {
                    //TODO: finish MySQL installer
                    throw new InvalidOperationException("This method has not been implemented yet.");
                }
                else
                {
                    throw new ArgumentException("Database connection of type " + databaseConnection.GetType().FullName + " is not supported.");
                }

                actions.Add(0, dbCreateAction);
                actions.Add(1, dbCreateSchemaAction);
                actions.Add(2, dbLoginAction);
                actions.Add(3, dbPrincipalAction);

                password = new Password().IncludeLowercase().IncludeNumeric().IncludeUppercase().IncludeSpecial("~!@^&_").LengthRequired(64);
                
                installer = new DatabaseInstaller(actions, updateProgressPercentage, errorHandler);
                installer.DatabaseName = String.IsNullOrWhiteSpace(databaseName) ? InstallerTokens.TOKEN_DBNAME__DEFAULT : databaseName?.Trim();
                installer.DatabaseUserPassword = password.Next();
                installer.Connection = databaseConnection;

                return installer;
            }
        }
    }
}
