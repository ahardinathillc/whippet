using System;
using System.Text;
using NodaTime;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento
{
    /// <summary>
    /// Represents a single instance of the Magento e-commerce product that is locally or remotely hosted. All Magento objects reference a single <see cref="MagentoServer"/>.
    /// </summary>
    /// <remarks>See <a href="https://community.magento.com/t5/Magento-2-x-Programming/C-Updating-a-product-Magento-2-API-REST/td-p/458488">C# Updating a product Magento 2 API REST</a> for information on how to make REST calls.</remarks>
    public class MagentoServer : WhippetAuditableEntity, IWhippetAuditableEntity, IWhippetActiveEntity, IWhippetSoftDeleteEntity, IMagentoServer, IEqualityComparer<IMagentoServer>
    {
        private bool _active;

        private string _name;

        private WhippetTenant _tenant;

        private MagentoRestEndpoint _endpoint;

        /// <summary>
        /// Gets or sets the schema (database) where the Magento tables are stored.
        /// </summary>
        public virtual string Schema
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
        /// Gets or sets the connection string to the server.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        public virtual string ConnectionString
        { get; set; }

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
        IWhippetTenant IMagentoServer.Tenant
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
        /// Gets or sets the associated <see cref="MagentoRestEndpoint"/> for the server (if any).
        /// </summary>
        public virtual MagentoRestEndpoint AssociatedEndpoint
        {
            get
            {
                if (_endpoint == null)
                {
                    _endpoint = new MagentoRestEndpoint();
                }

                return _endpoint;
            }
            set
            {
                _endpoint = value;
            }
        }

        /// <summary>
        /// Gets or sets the associated <see cref="IMagentoRestEndpoint"/> for the server (if any).
        /// </summary>
        IMagentoRestEndpoint IMagentoServer.AssociatedEndpoint
        {
            get
            {
                return AssociatedEndpoint;
            }
            set
            {
                AssociatedEndpoint = value.ToMagentoRestEndpoint();
            }
        }

        /// <summary>
        /// Indicates the type of the current <see cref="IMagentoServer"/>. This property is read-only.
        /// </summary>
        public virtual ExternalDataSourceType ServerType
        {
            get
            {
                ExternalDataSourceType type = ExternalDataSourceType.Database;

                if (AssociatedEndpoint != null && !String.IsNullOrWhiteSpace(AssociatedEndpoint.URL))
                {
                    if (String.IsNullOrWhiteSpace(ConnectionString))
                    {
                        type = ExternalDataSourceType.REST;
                    }
                    else
                    {
                        type = ExternalDataSourceType.Database | ExternalDataSourceType.REST;
                    }
                }

                return type;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoServer"/> class with no arguments.
        /// </summary>
        public MagentoServer()
            : base()
        { }

        /// <summary>
        /// Creates a new instance of the <see cref="MagentoServer"/> class.
        /// </summary>
        /// <param name="id">Unique ID to assign to the <see cref="MagentoServer"/>.</param>
        /// <param name="name">Unique name of the server profile.</param>
        /// <param name="connectionString">Connection string to the MySQL database is located.</param>
        /// <param name="username">Username used to connect to the database.</param>
        /// <param name="password">Password used to connect to the database.</param>
        /// <param name="schema">Schema name where the Magento database entities are stored.</param>
        /// <param name="endpoint">Associated <see cref="MagentoRestEndpoint"/> that acts as a rollover or primary point of contact for the server.</param>
        /// <param name="tenant"><see cref="WhippetTenant"/> the server is registered with.</param>
        /// <param name="active">Specifies whether the profile is currently active.</param>
        /// <param name="deleted">Specifies whether the profile has been deleted.</param>
        /// <param name="createdDateTime">Date and time the object was created.</param>
        /// <param name="createdBy"><see cref="Guid"/> representing the <see cref="MagentoServer"/> who created the account.</param>
        /// <param name="lastModifiedDateTime">Date and time of when the object was last modified.</param>
        /// <param name="lastModifiedBy"><see cref="Guid"/> representing the <see cref="MagentoServer"/> who last modified the account.</param>
        public MagentoServer(Guid id, string name, string connectionString, string username, string password, string schema, MagentoRestEndpoint endpoint, WhippetTenant tenant, bool active, bool deleted, Instant? createdDateTime, Guid? createdBy, Instant? lastModifiedDateTime, Guid? lastModifiedBy)
            : base(id, createdDateTime, createdBy, lastModifiedDateTime, lastModifiedBy)
        {
            Name = name;
            ConnectionString = connectionString;
            Username = username;
            Password = password;
            Active = active;
            Deleted = deleted;
            Schema = schema;
            Tenant = tenant;
            AssociatedEndpoint = endpoint;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IMagentoServer);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMagentoServer obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="IMagentoServer"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IMagentoServer"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMagentoServer a, IMagentoServer b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals = String.Equals(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.ConnectionString, b.ConnectionString, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.Username, b.Username, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.Password, b.Password, StringComparison.InvariantCulture)     // don't ignore case -- passwords are case sensitive!
                    && a.Active.Equals(b.Active)
                    && a.Deleted.Equals(b.Deleted)
                    && String.Equals(a.Schema, b.Schema, StringComparison.InvariantCultureIgnoreCase)
                    && (((a.Tenant != null && b.Tenant != null) && (a.Tenant.Equals(b.Tenant))) || (a.Tenant == null && b.Tenant == null))
                    && ((a.AssociatedEndpoint == null && b.AssociatedEndpoint == null) || (a.AssociatedEndpoint != null && a.AssociatedEndpoint.Equals(b.AssociatedEndpoint)))
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
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual int GetHashCode(IMagentoServer obj)
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
        /// Gets the name of the of the <see cref="IMagentoServer"/> object.
        /// </summary>
        /// <returns>String description of the <see cref="IMagentoServer"/> object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            if (!String.IsNullOrWhiteSpace(Name))
            {
                builder.Append(Name);

                if (!String.IsNullOrWhiteSpace(ConnectionString))
                {
                    builder.Append(" ");
                    builder.Append('[');
                    builder.Append(ConnectionString);
                    builder.Append(']');
                }
                else
                {
                    builder.Append(AssociatedEndpoint.ToString());
                }
            }
            else if (!String.IsNullOrWhiteSpace(ConnectionString))
            {
                builder.Append(ConnectionString);
            }
            else
            {
                builder.Append(base.ToString());
            }

            return builder.ToString();
        }

    }
}
