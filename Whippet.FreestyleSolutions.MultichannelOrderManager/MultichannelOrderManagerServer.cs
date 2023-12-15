using System;
using System.Text;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Base class for servers connecting to Multichannel Order Manager applications (database or application). This class must be inherited.
    /// </summary>
    public abstract class MultichannelOrderManagerServer : WhippetAuditableEntity, IWhippetSoftDeleteEntity, IWhippetActiveEntity, IWhippetEntity, IWhippetAuditableEntity, IMultichannelOrderManagerServer, IEqualityComparer<IMultichannelOrderManagerServer>, IDataServer
    {
        private bool _active;

        private string _name;

        private WhippetTenant _tenant;

        /// <summary>
        /// Gets or sets the server address (URL, host name, IP address, or network share).
        /// </summary>
        public virtual string DataSource
        { get; set; }
        
        /// <summary>
        /// Gets or sets the unique name of the server profile.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        public virtual string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                else
                {
                    _name = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the (encrypted) username to access the server, if any. This value will be <see langword="null"/> or <see cref="String.Empty"/> if integrated security is used.
        /// </summary>
        public virtual string Username
        { get; set; }

        /// <summary>
        /// Gets or sets the (encrypted) password to access the server, if any. This value will be <see langword="null"/> or <see cref="String.Empty"/> if integrated security is used.
        /// </summary>
        public virtual string Password
        { get; set; }

        /// <summary>
        /// Specifies whether the profile has been deleted.
        /// </summary>
        public virtual bool Deleted
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="WhippetTenant"/> that the server is registered with.
        /// </summary>
        public virtual WhippetTenant Tenant
        {
            get
            {
                if (_tenant == null)
                {
                    _tenant = WhippetTenant.Root.ToWhippetTenant();
                }

                return _tenant;
            }
            set
            {
                _tenant = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> that the server is registered with.
        /// </summary>
        IWhippetTenant IMultichannelOrderManagerServer.Tenant
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
        /// Specifies whether the profile is currently active.
        /// </summary>
        public virtual bool Active
        {
            get
            {
                return _active && !Deleted;
            }
            set
            {
                _active = value;
            }
        }

        /// <summary>
        /// Indicates the type of the current <see cref="IMultichannelOrderManagerServer"/>. This property is read-only.
        /// </summary>
        public virtual ExternalDataSourceType ServerType
        { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerServer"/> class with no arguments.
        /// </summary>
        protected MultichannelOrderManagerServer()
            : base()
        { }

        /// <summary>
        /// Creates a new instance of the <see cref="MultichannelOrderManagerServer"/> class.
        /// </summary>
        /// <param name="id">Unique ID to assign to the <see cref="MultichannelOrderManagerServer"/>.</param>
        /// <param name="name">Unique name of the server profile.</param>
        /// <param name="username">Username used to connect to the database.</param>
        /// <param name="password">Password used to connect to the database.</param>
        /// <param name="tenant"><see cref="WhippetTenant"/> the server is registered with.</param>
        /// <param name="active">Specifies whether the profile is currently active.</param>
        /// <param name="deleted">Specifies whether the profile has been deleted.</param>
        /// <param name="createdDateTime">Date and time the object was created.</param>
        /// <param name="createdBy"><see cref="Guid"/> representing the <see cref="MultichannelOrderManagerServer"/> who created the account.</param>
        /// <param name="lastModifiedDateTime">Date and time of when the object was last modified.</param>
        /// <param name="lastModifiedBy"><see cref="Guid"/> representing the <see cref="MultichannelOrderManagerServer"/> who last modified the account.</param>
        /// <param name="serverType"><see cref="ExternalDataSourceType"/> of the server.</param>
        protected MultichannelOrderManagerServer(Guid id, string name, string username, string password, WhippetTenant tenant, bool active, bool deleted, Instant? createdDateTime, Guid? createdBy, Instant? lastModifiedDateTime, Guid? lastModifiedBy, ExternalDataSourceType serverType = ExternalDataSourceType.Database)
            : base(id, createdDateTime, createdBy, lastModifiedDateTime, lastModifiedBy)
        {
            Name = name;
            Username = username;
            Password = password;
            Active = active;
            Deleted = deleted;
            Tenant = tenant;
            ServerType = serverType;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IMultichannelOrderManagerServer);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerServer obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="IMultichannelOrderManagerServer"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IMultichannelOrderManagerServer"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerServer a, IMultichannelOrderManagerServer b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals = String.Equals(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.Username, b.Username, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.Password, b.Password, StringComparison.InvariantCulture)     // don't ignore case -- passwords are case sensitive!
                    && a.Active.Equals(b.Active)
                    && a.Deleted.Equals(b.Deleted)
                    && (((a.Tenant != null && b.Tenant != null) && (a.Tenant.Equals(b.Tenant))) || (a.Tenant == null && b.Tenant == null))
                    && a.ServerType == b.ServerType;
            }

            return equals;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Username, Password, Active, Deleted, Tenant, ServerType);
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual int GetHashCode(IMultichannelOrderManagerServer obj)
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
        /// Gets the name of the of the <see cref="IMultichannelOrderManagerServer"/> object.
        /// </summary>
        /// <returns>String description of the <see cref="IMultichannelOrderManagerServer"/> object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(Name) ? base.ToString() : Name;
        }    
    }
}
