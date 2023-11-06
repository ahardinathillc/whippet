using System;
using LiteDB;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents a profile of a Microsoft SQL Server database server that hosts the Multichannel Order Manager (M.O.M.). 
    /// </summary>
    public interface IMultichannelOrderManagerServer : IWhippetAuditableEntity, IWhippetActiveEntity, IWhippetSoftDeleteEntity, IEqualityComparer<IMultichannelOrderManagerServer>
    {
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
        /// Specifies the schema where the M.O.M. database entities are stored.
        /// </summary>
        string Schema
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> that the server is registered with.
        /// </summary>
        IWhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Gets or sets the associated <see cref="IMultichannelOrderManagerRestEndpoint"/> for the server (if any).
        /// </summary>
        IMultichannelOrderManagerRestEndpoint AssociatedEndpoint
        { get; set; }

        /// <summary>
        /// Indicates the type of the current <see cref="IMultichannelOrderManagerServer"/>. This property is read-only.
        /// </summary>
        ExternalDataSourceType ServerType
        { get; }

        /// <summary>
        /// Indicates whether the <see cref="ServerType"/> is pointing to a custom database data source, such as a report server.
        /// </summary>
        bool CustomDatabase
        { get; set; }
    }
}

