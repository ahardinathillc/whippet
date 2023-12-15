using System;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents a server for connecting to Multichannel Order Manager applications (database or application).
    /// </summary>
    public interface IMultichannelOrderManagerServer : IWhippetSoftDeleteEntity, IWhippetActiveEntity, IWhippetEntity, IWhippetAuditableEntity, IEqualityComparer<IMultichannelOrderManagerServer>, IDataServer
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
