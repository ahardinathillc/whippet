using System;
using System.Text;
using System.ComponentModel;
using NodaTime;
using MailKit.Security;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Networking.Smtp
{
    /// <summary>
    /// Represents an SMTP server profile, containing the server's address, name, and other configuration attributes.
    /// </summary>
    public class WhippetSmtpServerProfile : WhippetAuditableEntity, IWhippetAuditableEntity, IWhippetActiveEntity, IWhippetSoftDeleteEntity, IWhippetSmtpServerProfile, IEqualityComparer<IWhippetSmtpServerProfile>, IWhippetCloneable
    {
        private WhippetTenant _tenant;

        private string _serverName;
        private string _serverAddress;

        /// <summary>
        /// Gets or sets the <see cref="WhippetTenant"/> that the <see cref="WhippetSmtpServerProfile"/> belongs to.
        /// </summary>
        public virtual WhippetTenant Tenant
        {
            get
            {
                if (_tenant == null)
                {
                    _tenant = new WhippetTenant();
                }

                return _tenant;
            }
            set
            {
                _tenant = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> that the <see cref="IWhippetSmtpServerProfile"/> belongs to.
        /// </summary>
        IWhippetTenant IWhippetSmtpServerProfile.Tenant
        {
            get
            {
                return Tenant;
            }
            set
            {
                Tenant = value?.ToWhippetTenant();
            }
        }

        /// <summary>
        /// Gets or sets the server name.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        public virtual string ServerName
        {
            get
            {
                return _serverName;
            }
            set
            {
                ArgumentNullException.ThrowIfNullOrWhiteSpace(value);
                _serverName = value;
            }
        }

        /// <summary>
        /// Gets or sets the server address.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        public virtual string ServerAddress
        {
            get
            {
                return _serverAddress;
            }
            set
            {
                ArgumentNullException.ThrowIfNullOrWhiteSpace(value);
                _serverAddress = value;
            }
        }

        /// <summary>
        /// Gets or sets the port number of the SMTP server.
        /// </summary>
        public virtual int PortNumber
        { get; set; }

        /// <summary>
        /// Provides a way of specifying the SSL and/or TLS encryption that should be used for a connection.
        /// </summary>
        public virtual SecureSocketOptions SecureSocketOption
        { get; set; }

        /// <summary>
        /// Indicates whether the <see cref="WhippetSmtpServerProfile"/> is the default profile to use when sending messages.
        /// </summary>
        public virtual bool IsDefault
        { get; set; }

        /// <summary>
        /// Indicates whether the current <see cref="WhippetSmtpServerProfile"/> is active.
        /// </summary>
        public virtual bool Active
        { get; set; }

        /// <summary>
        /// Indicates whether the current <see cref="WhippetSmtpServerProfile"/> is deleted.
        /// </summary>
        public virtual bool Deleted
        { get; set; }

        /// <summary>
        /// Gets or sets the username used to log into the SMTP server.
        /// </summary>
        public virtual string Username
        { get; set; }

        /// <summary>
        /// Gets or sets the password used to log into the SMTP server.
        /// </summary>
        public virtual string Password
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSmtpServerProfile"/> class with no arguments.
        /// </summary>
        public WhippetSmtpServerProfile()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSmtpServerProfile"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetSmtpServerProfile"/> to initialize with.</param>
        public WhippetSmtpServerProfile(Guid id)
            : base(id, Instant.FromDateTimeUtc(DateTime.UtcNow), null, Instant.FromDateTimeUtc(DateTime.UtcNow), null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSmtpServerProfile"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetSmtpServerProfile"/> to initialize with.</param>
        /// <param name="serverName">Name of the SMTP server profile.</param>
        /// <param name="serverAddress">Address of the SMTP server.</param>
        /// <param name="portNumber">Port number of the SMTP server.</param>
        /// <param name="options">Secure socket options to apply when connecting.</param>
        /// <param name="isDefault">Specifies whether the profile should be marked as the default SMTP profile to use when sending messages.</param>
        /// <param name="tenant"><see cref="WhippetTenant"/> that the server belongs to.</param>
        /// <param name="createdDTTM">Date and time the instance was created.</param>
        /// <param name="createdBy">User ID of the user who created the instance.</param>
        /// <param name="lastUpdatedDTTM">Date and time the instance was last updated.</param>
        /// <param name="lastUpdatedBy">User ID of the user who updated the instance.</param>
        /// <param name="active">Indicates whether the <see cref="WhippetSmtpServerProfile"/> is active.</param>
        /// <param name="deleted">Indicates whether the <see cref="WhippetSmtpServerProfile"/> is deleted.</param>
        public WhippetSmtpServerProfile(Guid id, string serverName, string serverAddress, int portNumber, SecureSocketOptions options, bool isDefault, WhippetTenant tenant, Instant? createdDTTM, Guid? createdBy, Instant? lastUpdatedDTTM, Guid? lastUpdatedBy, bool active, bool deleted)
            : this(id, serverName, serverAddress, portNumber, options, isDefault, String.Empty, String.Empty, tenant, createdDTTM, createdBy, lastUpdatedDTTM, lastUpdatedBy, active, deleted)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSmtpServerProfile"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetSmtpServerProfile"/> to initialize with.</param>
        /// <param name="serverName">Name of the SMTP server profile.</param>
        /// <param name="serverAddress">Address of the SMTP server.</param>
        /// <param name="portNumber">Port number of the SMTP server.</param>
        /// <param name="options">Secure socket options to apply when connecting.</param>
        /// <param name="isDefault">Specifies whether the profile should be marked as the default SMTP profile to use when sending messages.</param>
        /// <param name="username">Username used to log into the SMTP server.</param>
        /// <param name="password">Password used to log into the SMTP server.</param>
        /// <param name="tenant"><see cref="WhippetTenant"/> that the server belongs to.</param>
        /// <param name="createdDTTM">Date and time the instance was created.</param>
        /// <param name="createdBy">User ID of the user who created the instance.</param>
        /// <param name="lastUpdatedDTTM">Date and time the instance was last updated.</param>
        /// <param name="lastUpdatedBy">User ID of the user who updated the instance.</param>
        /// <param name="active">Indicates whether the <see cref="WhippetSmtpServerProfile"/> is active.</param>
        /// <param name="deleted">Indicates whether the <see cref="WhippetSmtpServerProfile"/> is deleted.</param>
        public WhippetSmtpServerProfile(Guid id, string serverName, string serverAddress, int portNumber, SecureSocketOptions options, bool isDefault, string username, string password, WhippetTenant tenant, Instant? createdDTTM, Guid? createdBy, Instant? lastUpdatedDTTM, Guid? lastUpdatedBy, bool active, bool deleted)
            : base(id, createdDTTM, createdBy, lastUpdatedDTTM, lastUpdatedBy)
        {
            ID = id;
            ServerName = serverName;
            ServerAddress = serverAddress;
            PortNumber = portNumber;
            SecureSocketOption = options;
            IsDefault = isDefault;
            Active = active;
            Deleted = deleted;
            Username = username;
            Password = password;
            Tenant = tenant;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IWhippetSmtpServerProfile);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetSmtpServerProfile obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="a">First object to compare.</param>
        /// <param name="b">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetSmtpServerProfile a, IWhippetSmtpServerProfile b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals = (a.Active == b.Active)
                    && a.CreatedBy.GetValueOrDefault().Equals(b.CreatedBy.GetValueOrDefault())
                    && a.CreatedDateTime.Equals(b.CreatedDateTime)
                    && (a.Deleted == b.Deleted)
                    && a.LastModifiedBy.GetValueOrDefault().Equals(b.LastModifiedBy.GetValueOrDefault())
                    && a.LastModifiedDateTime.GetValueOrDefault().Equals(b.LastModifiedDateTime.GetValueOrDefault())
                    && String.Equals(a.ServerName, b.ServerName, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.ServerAddress, b.ServerAddress, StringComparison.InvariantCultureIgnoreCase)
                    && a.PortNumber == b.PortNumber
                    && a.IsDefault == b.IsDefault
                    && a.SecureSocketOption == b.SecureSocketOption
                    && String.Equals(a.Username, b.Username, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.Password, b.Password, StringComparison.InvariantCultureIgnoreCase)
                    && ((a.Tenant == null && b.Tenant == null) || (a.Tenant != null && a.Tenant.Equals(b.Tenant)));
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IWhippetSmtpServerProfile obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else
            {
                return obj.GetHashCode();
            }
        }

        /// <summary>
        /// Creates a deep copy of the current object.
        /// </summary>
        /// <returns>Deep copy of the current object.</returns>
        public override object Clone()
        {
            return new WhippetSmtpServerProfile(ID, ServerName, ServerAddress, PortNumber, SecureSocketOption, IsDefault, Username, Password, Tenant, CreatedDateTime, CreatedBy, LastModifiedDateTime, LastModifiedBy, Active, Deleted);
        }

        /// <summary>
        /// Creates a deep copy of the current object.
        /// </summary>
        /// <typeparam name="TObject">Type of object to cast the cloned instance to.</typeparam>
        /// <returns>Cloned objection of type <typeparamref name="TObject"/>.</returns>
        /// <exception cref="InvalidCastException" />
        public virtual TObject Clone<TObject>()
        {
            return (TObject)(Clone());
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current objext.</returns>
        public override string ToString()
        {
            return ServerName + " [" + ServerAddress + "]";
        }
    }
}
