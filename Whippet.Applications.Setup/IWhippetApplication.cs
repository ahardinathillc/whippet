using System;
using System.Data;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Applications.Setup
{
    /// <summary>
    /// Represents an application that is powered by the Whippet engine.
    /// </summary>
    public interface IWhippetApplication : IWhippetEntity, ICloneable, IWhippetCloneable, IEqualityComparer<IWhippetApplication>
    {
        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> that the application applies to.
        /// </summary>
        IWhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Gets the application name. This property is read-only.
        /// </summary>
        string Name
        { get; }

        /// <summary>
        /// Gets the application ID. This property is read-only.
        /// </summary>
        Guid ApplicationID
        { get; }
    }
}

