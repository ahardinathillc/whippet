using System;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.Adobe.Magento.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IMagentoServer"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IMagentoServerExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IMagentoServer"/> object to a <see cref="MagentoServer"/> object.
        /// </summary>
        /// <param name="server"><see cref="IMagentoServer"/> object to convert.</param>
        /// <returns><see cref="MagentoServer"/> object.</returns>
        public static MagentoServer ToMagentoServer(this IMagentoServer server)
        {
            MagentoServer ms = null;

            if (server != null)
            {
                if (server is MagentoServer)
                {
                    ms = (MagentoServer)(server);
                }
                else
                {
                    ms = new MagentoServer(
                        server.ID,
                        server.Name,
                        server.ConnectionString,
                        server.Username,
                        server.Password,
                        server.Schema,
                        server.AssociatedEndpoint.ToMagentoRestEndpoint(),
                        server.Tenant.ToWhippetTenant(),
                        server.Active,
                        server.Deleted,
                        server.CreatedDateTime,
                        server.CreatedBy,
                        server.LastModifiedDateTime,
                        server.LastModifiedBy
                    );
                }
            }

            return ms;
        }
    }
}

