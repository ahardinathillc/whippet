using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.Security
{
    /// <summary>
    /// Represents a blacklist entry for a password. Blacklisted passwords are not allowed to be used.
    /// </summary>
    public interface IWhippetPasswordBlacklist : IWhippetEntity, IEqualityComparer<IWhippetPasswordBlacklist>
    {
        /// <summary>
        /// Gets or sets the password that is blacklisted.
        /// </summary>
        string Password
        { get; set; }

        /// <summary>
        /// Gets or sets the tenant that the password blacklist entry applies to.
        /// </summary>
        IWhippetTenant Tenant
        { get; set; }
    }
}

