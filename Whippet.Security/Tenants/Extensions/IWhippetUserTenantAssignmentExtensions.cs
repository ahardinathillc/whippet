using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Security.Extensions;

namespace Athi.Whippet.Security.Tenants.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IWhippetUserTenantAssignment"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IWhippetUserTenantAssignmentExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IWhippetUserTenantAssignment"/> object to a <see cref="WhippetUserTenantAssignment"/> object.
        /// </summary>
        /// <param name="tenantObj"><see cref="IWhippetUserTenantAssignment"/> object to convert.</param>
        /// <returns><see cref="WhippetUserTenantAssignment"/> object.</returns>
        public static WhippetUserTenantAssignment ToWhippetUserTenantAssignment(this IWhippetUserTenantAssignment tenantObj)
        {
            WhippetUserTenantAssignment tenant = null;

            if (tenantObj != null)
            {
                if (tenantObj is WhippetUserTenantAssignment)
                {
                    tenant = (WhippetUserTenantAssignment)(tenantObj);
                }
                else
                {
                    tenant = new WhippetUserTenantAssignment(tenantObj.ID, tenantObj.User.ToWhippetUser(), tenantObj.Tenant.ToWhippetTenant());
                }
            }

            return tenant;
        }
    }
}
