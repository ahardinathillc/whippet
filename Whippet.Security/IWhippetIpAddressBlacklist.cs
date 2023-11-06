using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Security
{
    /// <summary>
    /// Blacklist of IP addresses that are automatically denied login or access to the Whippet system.
    /// </summary>
    public interface IWhippetIpAddressBlacklist : IWhippetEntity, IEqualityComparer<IWhippetIpAddressBlacklist>, IWhippetActiveEntity, IWhippetSoftDeleteEntity, IWhippetAuditableEntity
    {
        /// <summary>
        /// Gets or sets the IP address of the last login from the user account.
        /// </summary>
        /// <exception cref="FormatException" />
        string IPAddress
        { get; set; }

        /// <summary>
        /// Gets or sets the tenant that the IP address blacklist applies to.
        /// </summary>
        IWhippetTenant Tenant
        { get; set; }
    }
}
