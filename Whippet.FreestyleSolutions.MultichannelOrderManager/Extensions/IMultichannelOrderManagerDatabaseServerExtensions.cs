using System;
using Athi.Whippet.Data.Database.Microsoft.Extensions;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IMultichannelOrderManagerDatabaseServer"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IMultichannelOrderManagerDatabaseServerExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IMultichannelOrderManagerDatabaseServer"/> instance to a <see cref="MultichannelOrderManagerDatabaseServer"/> object.
        /// </summary>
        /// <param name="server"><see cref="IMultichannelOrderManagerDatabaseServer"/> object to convert.</param>
        /// <returns><see cref="MultichannelOrderManagerDatabaseServer"/> object.</returns>
        public static MultichannelOrderManagerDatabaseServer ToMultichannelOrderManagerDatabaseServer(this IMultichannelOrderManagerDatabaseServer server)
        {
            MultichannelOrderManagerDatabaseServer momServer = null;

            if (server != null)
            {
                momServer = new MultichannelOrderManagerDatabaseServer(
                    server.ID, 
                    server.Name, 
                    server.Username, 
                    server.Password, 
                    server.Tenant.ToWhippetTenant(), 
                    server.Active, 
                    server.Deleted, 
                    server.CreatedDateTime, 
                    server.CreatedBy, 
                    server.LastModifiedDateTime, 
                    server.LastModifiedBy
                );

                momServer.ImportWhippetSqlServerDatabaseServer(server);
            }

            return momServer;
        }
    }
}
