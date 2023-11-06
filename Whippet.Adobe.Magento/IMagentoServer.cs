using System;
using System.Text;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Data;

namespace Athi.Whippet.Adobe.Magento
{
    /// <summary>
    /// Represents a single instance of the Magento e-commerce product that is locally or remotely hosted. All <see cref="IMagentoEntity"/> objects reference a single <see cref="IMagentoServer"/>.
    /// </summary>
    public interface IMagentoServer : IWhippetAuditableEntity, IWhippetActiveEntity, IWhippetSoftDeleteEntity, IEqualityComparer<IMagentoServer>
    {
        /// <summary>
        /// Gets or sets the schema (database) where the Magento tables are stored.
        /// </summary>
        string Schema
        { get; set; }

        /// <summary>
        /// Gets or sets the unique name of the server profile.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the connection string to the server.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        string ConnectionString
        { get; set; }

        /// <summary>
        /// Gets or sets the (encrypted) username to access the server, if any. This value will be <see langword="null"/> or <see cref="String.Empty"/> if integrated security is used.
        /// </summary>
        string Username
        { get; set; }

        /// <summary>
        /// Gets or sets the (encrypted) password to access the server, if any. This value will be <see langword="null"/> or <see cref="String.Empty"/> if integrated security is used.
        /// </summary>
        string Password
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> that the server is registered with.
        /// </summary>
        IWhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Gets or sets the associated <see cref="IMagentoRestEndpoint"/> for the server (if any).
        /// </summary>
        IMagentoRestEndpoint AssociatedEndpoint
        { get; set; }

        /// <summary>
        /// Indicates the type of the current <see cref="IMagentoServer"/>. This property is read-only.
        /// </summary>
        ExternalDataSourceType ServerType
        { get; }
    }
}

