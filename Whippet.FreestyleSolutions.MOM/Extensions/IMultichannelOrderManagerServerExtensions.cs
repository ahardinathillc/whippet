using System;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IMultichannelOrderManagerServer"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IMultichannelOrderManagerServerExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IMultichannelOrderManagerServer"/> object to a <see cref="MultichannelOrderManagerServer"/> object.
        /// </summary>
        /// <param name="server"><see cref="IMultichannelOrderManagerServer"/> object to convert.</param>
        /// <returns><see cref="MultichannelOrderManagerServer"/> object.</returns>
        public static MultichannelOrderManagerServer ToMultichannelOrderManagerServer(this IMultichannelOrderManagerServer server)
        {
            MultichannelOrderManagerServer momServer = null;

            if (server != null)
            {
                if (server is MultichannelOrderManagerServer)
                {
                    momServer = (MultichannelOrderManagerServer)(server);
                }
                else
                {
                    momServer = new MultichannelOrderManagerServer(
                        server.ID,
                        server.Name,
                        server.ConnectionString,
                        server.Username,
                        server.Password,
                        server.Schema,
                        server.Tenant.ToWhippetTenant(),
                        server.Active,
                        server.Deleted,
                        server.CreatedDateTime,
                        server.CreatedBy,
                        server.LastModifiedDateTime,
                        server.LastModifiedBy
                        );

                    momServer.CustomDatabase = server.CustomDatabase;
                }
            }

            return momServer;
        }
    }
}
