using System;
using SqlServer = Microsoft.SqlServer.Management.Smo.Server;
using Athi.Whippet.Data.Database.Microsoft;

namespace Athi.Whippet.Installer.Framework.Database
{
    /// <summary>
    /// Performs a database update for the appropriate RDBMS. This class must be inherited.
    /// </summary>
    internal class DBUpdateAction : InstallerActionBase, IInstallerAction
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
        /// Initializes a new instance of the <see cref="DBUpdateAction"/> class with no arguments.
        /// </summary>
        protected DBUpdateAction()
            : base("Updating Database")
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
        /// Represents a <see cref="DBUpdateAction"/> for Microsoft SQL Server database systems. This class cannot be inherited.
        /// </summary>
        internal sealed class MSSQL : DBUpdateAction, IInstallerAction
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="DBUpdateAction.MSSQL"/> class with no arguments.
            /// </summary>
            public MSSQL()
                : base()
            { }
            
            /// <summary>
            /// Executes the current action with the specified parameters.
            /// </summary>
            /// <param name="args">Parameters to pass to the action (if any).</param>
            /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
            /// <remarks>Argument order is [connection string] [update query 1] ... [update query n]</remarks>
            public override WhippetResultContainer<object> Execute(params object[] args)
            {
                WhippetResultContainer<object> result = null;
                
                WhippetSqlServerConnection connection = null;
                SqlServer server = null;

                try
                {
                    VerifyParameters(typeof(WhippetSqlServerConnection), args);
                    VerifyParameters(typeof(string), args);
                    
                    connection = (WhippetSqlServerConnection)(args.First(a => a is WhippetSqlServerConnection));
                    
                    server = connection.CreateServerInstance();

                    for (int i = 1; i < args.Length; i++)
                    {
                        if (args[i] is string)
                        {
                            server.ConnectionContext.ExecuteNonQuery(Convert.ToString(args[i]));
                        }
                    }

                    result = new WhippetResultContainer<object>(WhippetResult.Success, null);
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
