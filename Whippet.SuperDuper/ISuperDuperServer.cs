using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.SuperDuper
{
    /// <summary>
    /// Represents a server for connecting to Super Duper applications (database or application).
    /// </summary>
    public interface ISuperDuperServer  : IWhippetSoftDeleteEntity, IWhippetActiveEntity, IWhippetEntity, IWhippetAuditableEntity, IEqualityComparer<ISuperDuperServer>
    {
        /// <summary>
        /// Gets or sets the unique name of the server profile.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        string Name
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
        /// Specifies whether the profile has been deleted.
        /// </summary>
        bool Deleted
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> that the server is registered with.
        /// </summary>
        IWhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Indicates the type of the current <see cref="ISuperDuperServer"/>. This property is read-only.
        /// </summary>
        ExternalDataSourceType ServerType
        { get; }
    }
}
