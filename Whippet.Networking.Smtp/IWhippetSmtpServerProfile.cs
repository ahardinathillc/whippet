using System;
using System.Text;
using System.ComponentModel;
using NodaTime;
using MailKit.Security;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Networking.Smtp
{
    /// <summary>
    /// Represents an SMTP server profile, containing the server's address, name, and other configuration attributes.
    /// </summary>
    public interface IWhippetSmtpServerProfile : IWhippetAuditableEntity, IWhippetActiveEntity, IWhippetSoftDeleteEntity, IEqualityComparer<IWhippetSmtpServerProfile>, IWhippetCloneable
    {
        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> that the <see cref="IWhippetSmtpServerProfile"/> belongs to.
        /// </summary>
        IWhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Gets or sets the server name.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        string ServerName
        { get; set; }

        /// <summary>
        /// Gets or sets the server address.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        string ServerAddress
        { get; set; }

        /// <summary>
        /// Gets or sets the port number of the SMTP server.
        /// </summary>
        int PortNumber
        { get; set; }

        /// <summary>
        /// Provides a way of specifying the SSL and/or TLS encryption that should be used for a connection.
        /// </summary>
        SecureSocketOptions SecureSocketOption
        { get; set; }

        /// <summary>
        /// Indicates whether the <see cref="IWhippetSmtpServerProfile"/> is the default profile to use when sending messages.
        /// </summary>
        bool IsDefault
        { get; set; }

        /// <summary>
        /// Gets or sets the username used to log into the SMTP server.
        /// </summary>
        string Username
        { get; set; }

        /// <summary>
        /// Gets or sets the password used to log into the SMTP server.
        /// </summary>
        string Password
        { get; set; }
    }
}

