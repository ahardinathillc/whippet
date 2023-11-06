using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Security.Tenants.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IWhippetTenant"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IWhippetTenantExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IWhippetTenant"/> object to a <see cref="WhippetTenant"/> object.
        /// </summary>
        /// <param name="tenantObj"><see cref="IWhippetTenant"/> object to convert.</param>
        /// <returns><see cref="WhippetTenant"/> object.</returns>
        public static WhippetTenant ToWhippetTenant(this IWhippetTenant tenantObj)
        {
            WhippetTenant tenant = null;

            if (tenantObj != null)
            {
                if (tenantObj is WhippetTenant)
                {
                    tenant = (WhippetTenant)(tenantObj);
                }
                else
                {
                    tenant = new WhippetTenant(
                        tenantObj.ID,
                        tenantObj.Name,
                        tenantObj.URL,
                        tenantObj.IsRootTenant,
                        tenantObj.CreatedDateTime,
                        tenantObj.CreatedBy,
                        tenantObj.LastModifiedDateTime,
                        tenantObj.LastModifiedBy,
                        tenantObj.Active,
                        tenantObj.Deleted
                    );
                }
            }

            return tenant;
        }
    }
}
