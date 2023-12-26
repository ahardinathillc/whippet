using System;
using SqlServer = Microsoft.SqlServer.Management.Smo.Server;
using Athi.Whippet.Security;
using Athi.Whippet.Data.Database.Microsoft;
using Microsoft.AspNetCore.Identity;

namespace Athi.Whippet.Installer.Framework.Database
{
    /// <summary>
    /// Performs a database creation for the appropriate RDBMS. This class must be inherited.
    /// </summary>
    internal class DBCreatePrincipalAction : InstallerActionBase, IInstallerAction
    {
        /// <summary>
        /// Indicates whether the action supports asynchronous execution. This property is read-only.
        /// </summary>
        public override bool SupportsAsync
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBCreatePrincipalAction"/> class with no arguments.
        /// </summary>
        protected DBCreatePrincipalAction()
            : base("Creating Principal")
        { }

        /// <summary>
        /// Executes the current action with the specified parameters.
        /// </summary>
        /// <param name="args">Parameters to pass to the action (if any).</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public override WhippetResultContainer<object> Execute(params object[] args)
        {
            // method needs to be overridden by child
            return new WhippetResultContainer<object>(WhippetResult.Success, null);
        }

        /// <summary>
        /// Represents a <see cref="DBCreatePrincipalAction"/> for Microsoft SQL Server database systems. This class cannot be inherited.
        /// </summary>
        internal sealed class MSSQL : DBCreatePrincipalAction, IInstallerAction
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="DBCreatePrincipalAction.MSSQL"/> class with no arguments.
            /// </summary>
            public MSSQL()
                : base()
            { }
            
            /// <summary>
            /// Executes the current action with the specified parameters.
            /// </summary>
            /// <param name="args">Parameters to pass to the action (if any).</param>
            /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
            public override WhippetResultContainer<object> Execute(params object[] args)
            {
                WhippetResultContainer<object> result = null;
                
                WhippetSqlServerConnection connection = null;
                SqlServer server = null;

                string databaseName = String.Empty;
                
                try
                {
                    VerifyParameters(typeof(WhippetSqlServerConnection), args);
                    VerifyParameters(typeof(string), args);

                    connection = (WhippetSqlServerConnection)(args.First(a => a is WhippetSqlServerConnection));
                    databaseName = Convert.ToString(args.First(a => a is String));
                    
                    server = connection.CreateServerInstance();
                    server.ConnectionContext.ExecuteNonQuery(
                        Scripts_MSSQL.DB_LOGIN
                            .Replace(InstallerTokens.TOKEN_DBNAME, databaseName, StringComparison.InvariantCultureIgnoreCase)
                        );
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<object>(e);
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
                
                return result;
            }
        }
    }
}
