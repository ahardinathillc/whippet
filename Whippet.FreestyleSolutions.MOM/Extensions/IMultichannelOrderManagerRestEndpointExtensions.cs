using System;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IMultichannelOrderManagerRestEndpoint"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IMultichannelOrderManagerRestEndpointExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IMultichannelOrderManagerRestEndpoint"/> object to a <see cref="MultichannelOrderManagerRestEndpoint"/> object.
        /// </summary>
        /// <param name="endpoint"><see cref="IMultichannelOrderManagerRestEndpoint"/> object to convert.</param>
        /// <returns><see cref="MultichannelOrderManagerRestEndpoint"/> object.</returns>
        public static MultichannelOrderManagerRestEndpoint ToMultichannelOrderManagerRestEndpoint(this IMultichannelOrderManagerRestEndpoint endpoint)
        {
            MultichannelOrderManagerRestEndpoint ep = null;

            if (endpoint != null)
            {
                if (endpoint is MultichannelOrderManagerRestEndpoint)
                {
                    ep = (MultichannelOrderManagerRestEndpoint)(endpoint);
                }
                else
                {
                    ep = new MultichannelOrderManagerRestEndpoint(
                        endpoint.ID,
                        endpoint.Name,
                        ((IMultichannelOrderManagerServer)(endpoint)).Username,
                        ((IMultichannelOrderManagerServer)(endpoint)).Password,
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
