using System;
using Microsoft.AspNetCore.Identity;
using Athi.Whippet.Installer;
using Athi.Whippet.Data.Database;
using Athi.Whippet.Data.Database.Microsoft;
using Athi.Whippet.Data.Database.Oracle.MySQL;
using Athi.Whippet.Security;

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
        /// 
        /// </summary>
        /// <param name="databaseConnection"></param>
        /// <param name="databaseName"></param>
        /// <param name="updateProgressPercentage"></param>
        /// <param name="errorHandler"></param>
        /// <returns></returns>
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
                IInstallerAction dbLoginAction = null;
                IInstallerAction dbPrincipalAction = null;
                
                // determine the type of install action to get

                if (databaseConnection is WhippetSqlServerConnection)
                {
                    dbCreateAction = new DBCreateAction.MSSQL();
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
                actions.Add(1, dbLoginAction);
                actions.Add(2, dbPrincipalAction);
                
                installer = new DatabaseInstaller(actions, updateProgressPercentage, errorHandler);
                installer.DatabaseName = String.IsNullOrWhiteSpace(databaseName) ? InstallerTokens.TOKEN_DBNAME__DEFAULT : databaseName?.Trim();
                installer.DatabaseUserPassword = SecurePasswordGenerator.GenerateRandomPassword(new PasswordOptions() { RequiredLength = 72 });
                installer.Connection = databaseConnection;

                return installer;
            }
        }
    }
}
