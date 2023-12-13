using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.SuperDuper
{
    /// <summary>
    /// Represents a server for connecting to Super Duper applications (database or application).
    /// </summary>
    public interface ISuperDuperServer : IWhippetSoftDeleteEntity, IWhippetActiveEntity, IWhippetEntity, IWhippetAuditableEntity, IEqualityComparer<ISuperDuperServer>, IDataServer
    {
        /// <summary>
        /// Gets or sets the unique name of the server profile.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> that the server is registered with.
        /// </summary>
        IWhippetTenant Tenant
        { get; set; }
    }
}
