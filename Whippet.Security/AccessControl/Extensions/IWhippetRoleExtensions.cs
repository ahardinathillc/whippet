using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.Security.AccessControl.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IWhippetRole"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IWhippetRoleExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IWhippetRole"/> object to a <see cref="WhippetRole"/> object.
        /// </summary>
        /// <param name="roleObj"><see cref="IWhippetRole"/> object to convert.</param>
        /// <returns><see cref="WhippetRole"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static WhippetRole ToWhippetRole(this IWhippetRole roleObj)
        {
            if(roleObj == null)
            {
                throw new ArgumentNullException(nameof(roleObj));
            }
            else
            {
                return (roleObj is WhippetRole) ? ((WhippetRole)(roleObj)) : new WhippetRole(
                    roleObj.ID, 
                    roleObj.Name, 
                    roleObj.Description, 
                    roleObj.IsSystem,
                    roleObj.Tenant.ToWhippetTenant(),
                    roleObj.CreatedDateTime, 
                    roleObj.CreatedBy, 
                    roleObj.LastModifiedDateTime, 
                    roleObj.LastModifiedBy, 
                    roleObj.Active, 
                    roleObj.Deleted
                    );
            }
        }
    }
}
