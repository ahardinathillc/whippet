using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Localization;
using Athi.Whippet.Security.ResourceFiles;

namespace Athi.Whippet.Security.Tenants
{
    /// <summary>
    /// Represents a tenant in the Whippet hosting environment. All child <see cref="IWhippetTenant"/> instances are hosted by a root instance.
    /// </summary>
    public interface IWhippetTenant : IWhippetEntity, IWhippetAuditableEntity, IWhippetActiveEntity, IWhippetSoftDeleteEntity, IEqualityComparer<IWhippetTenant>
    {
        /// <summary>
        /// Indicates whether the tenant is the root (host) tenant. This property is read-only.
        /// </summary>
        bool IsRootTenant
        { get; }

        /// <summary>
        /// Name of the tenant.
        /// </summary>
        string Name
        { get; set; }

        /// <summary>
        /// Tenant URL that points to the location where the tenant can be accessed publically.
        /// </summary>
        string URL
        { get; set; }
    }
}
