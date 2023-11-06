using System;
using System.Collections.Generic;
using Athi.Whippet.Data;

namespace Athi.Whippet.Security.Tenants
{
    /// <summary>
    /// Provides a mapping between a <see cref="IWhippetTenant"/> and a <see cref="IWhippetUser"/>. 
    /// </summary>
    public interface IWhippetUserTenantAssignment : IWhippetEntity, IEqualityComparer<IWhippetUserTenantAssignment>
    {
        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> that the <see cref="IWhippetUser"/> is assigned to.
        /// </summary>
        IWhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IWhippetUser"/> that is assigned to <see cref="Tenant"/>.
        /// </summary>
        IWhippetUser User
        { get; set; }
    }
}

