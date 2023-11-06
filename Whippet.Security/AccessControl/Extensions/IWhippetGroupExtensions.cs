using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.Security.AccessControl.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IWhippetGroup"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IWhippetGroupExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IWhippetGroup"/> object to a <see cref="WhippetGroup"/> object.
        /// </summary>
        /// <param name="groupObj"><see cref="IWhippetGroup"/> object to convert.</param>
        /// <returns><see cref="WhippetGroup"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static WhippetGroup ToWhippetGroup(this IWhippetGroup groupObj)
        {
            if (groupObj == null)
            {
                throw new ArgumentNullException(nameof(groupObj));
            }
            else
            {
                return (groupObj is WhippetGroup) ? ((WhippetGroup)(groupObj)) : new WhippetGroup(
                    groupObj.ID,
                    groupObj.Name,
                    groupObj.Description,
                    groupObj.IsSystem,
                    groupObj.Tenant.ToWhippetTenant(),
                    groupObj.CreatedDateTime,
                    groupObj.CreatedBy,
                    groupObj.LastModifiedDateTime,
                    groupObj.LastModifiedBy,
                    groupObj.Active,
                    groupObj.Deleted
                    );
            }
        }
    }
}
