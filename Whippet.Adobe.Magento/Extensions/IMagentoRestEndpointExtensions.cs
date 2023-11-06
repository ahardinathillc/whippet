using System;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.Adobe.Magento.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IMagentoRestEndpoint"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IMagentoRestEndpointExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IMagentoRestEndpoint"/> object to a <see cref="MagentoRestEndpoint"/> object.
        /// </summary>
        /// <param name="endpoint"><see cref="IMagentoRestEndpoint"/> object to convert.</param>
        /// <returns><see cref="MagentoRestEndpoint"/> object.</returns>
        public static MagentoRestEndpoint ToMagentoRestEndpoint(this IMagentoRestEndpoint endpoint)
        {
            MagentoRestEndpoint ep = null;

            if (endpoint != null)
            {
                if (endpoint is MagentoRestEndpoint)
                {
                    ep = (MagentoRestEndpoint)(endpoint);
                }
                else
                {
                    ep = new MagentoRestEndpoint(
                        endpoint.ID,
                        endpoint.Name,
                        ((IMagentoServer)(endpoint)).Username,
                        ((IMagentoServer)(endpoint)).Password,
                        endpoint.URL,
                        endpoint.Tenant.ToWhippetTenant(),
                        endpoint.Active,
                        endpoint.Deleted,
                        endpoint.CreatedDateTime,
                        endpoint.CreatedBy,
                        endpoint.LastModifiedDateTime,
                        endpoint.LastModifiedBy
                    );
                }
            }

            return ep;
        }
    }
}

