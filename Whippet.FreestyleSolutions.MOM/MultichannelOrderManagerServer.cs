using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NodaTime;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents a profile of a Microsoft SQL Server database server that hosts the Multichannel Order Manager (M.O.M.). 
    /// </summary>
    public class MultichannelOrderManagerServer : WhippetAuditableEntity, IWhippetAuditableEntity, IWhippetActiveEntity, IWhippetSoftDeleteEntity, IMultichannelOrderManagerServer, IEqualityComparer<IMultichannelOrderManagerServer>, IJsonObject
    {
        private const string DEFAULT_SCHEMA = "dbo";

        private bool _active;

        private WhippetTenant _tenant;

        private MultichannelOrderManagerRestEndpoint _endpoint;

        /// <summary>
        /// Gets or sets the unique name of the server profile.
        /// </summary>
        public virtual string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the connection string to the server.
        /// </summary>
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
        /// Specifies the schema where the M.O.M. database entities are stored.
        /// </summary>
        public virtual string Schema
        { get; set; } = DEFAULT_SCHEMA; 

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
        /// Gets or sets the associated <see cref="MultichannelOrderManagerRestEndpoint"/> for the server (if any).
        /// </summary>
        public virtual MultichannelOrderManagerRestEndpoint AssociatedEndpoint
        {
            get
            {
                if (_endpoint == null)
                {
                    _endpoint = new MultichannelOrderManagerRestEndpoint();
                }

                return _endpoint;
            }
            set
            {
                _endpoint = value;
            }
        }

        /// <summary>
        /// Gets or sets the associated <see cref="IMultichannelOrderManagerRestEndpoint"/> for the server (if any).
        /// </summary>
        IMultichannelOrderManagerRestEndpoint IMultichannelOrderManagerServer.AssociatedEndpoint
        {
            get
            {
                return AssociatedEndpoint;
            }
            set
            {
                AssociatedEndpoint = value.ToMultichannelOrderManagerRestEndpoint();
            }
        }

        /// <summary>
        /// Indicates the type of the current <see cref="IMultichannelOrderManagerServer"/>. This property is read-only.
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
        /// Indicates whether the <see cref="ServerType"/> is pointing to a custom database data source, such as a report server.
        /// </summary>
        public virtual bool CustomDatabase
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerServer"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerServer()
            : base()
        { }

        /// <summary>
        /// Creates a new instance of the <see cref="MultichannelOrderManagerServer"/> class.
        /// </summary>
        /// <param name="id">Unique ID to assign to the <see cref="MultichannelOrderManagerServer"/>.</param>
        /// <param name="name">Unique name of the server profile.</param>
        /// <param name="connectionString">Connection string to the Microsoft SQL Server where the M.O.M. database is located.</param>
        /// <param name="username">Username used to connect to the database.</param>
        /// <param name="password">Password used to connect to the database.</param>
        /// <param name="schema">Schema name where the M.O.M. database entities are stored.</param>
        /// <param name="tenant"><see cref="WhippetTenant"/> the server is registered with.</param>
        /// <param name="active">Specifies whether the profile is currently active.</param>
        /// <param name="deleted">Specifies whether the profile has been deleted.</param>
        /// <param name="createdDateTime">Date and time the object was created.</param>
        /// <param name="createdBy"><see cref="Guid"/> representing the <see cref="MultichannelOrderManagerServer"/> who created the account.</param>
        /// <param name="lastModifiedDateTime">Date and time of when the object was last modified.</param>
        /// <param name="lastModifiedBy"><see cref="Guid"/> representing the <see cref="MultichannelOrderManagerServer"/> who last modified the account.</param>
        public MultichannelOrderManagerServer(Guid id, string name, string connectionString, string username, string password, string schema, WhippetTenant tenant, bool active, bool deleted, Instant? createdDateTime, Guid? createdBy, Instant? lastModifiedDateTime, Guid? lastModifiedBy)
            : this(id, name, connectionString, username, password, schema, null, tenant, active, deleted, createdDateTime, createdBy, lastModifiedDateTime, lastModifiedBy)
        { }

        /// <summary>
        /// Creates a new instance of the <see cref="MultichannelOrderManagerServer"/> class.
        /// </summary>
        /// <param name="id">Unique ID to assign to the <see cref="MultichannelOrderManagerServer"/>.</param>
        /// <param name="name">Unique name of the server profile.</param>
        /// <param name="connectionString">Connection string to the Microsoft SQL Server where the M.O.M. database is located.</param>
        /// <param name="username">Username used to connect to the database.</param>
        /// <param name="password">Password used to connect to the database.</param>
        /// <param name="schema">Schema name where the M.O.M. database entities are stored.</param>
        /// <param name="endpoint">Associated <see cref="MultichannelOrderManagerRestEndpoint"/> that acts as a rollover or primary point of contact for the server.</param>
        /// <param name="tenant"><see cref="WhippetTenant"/> the server is registered with.</param>
        /// <param name="active">Specifies whether the profile is currently active.</param>
        /// <param name="deleted">Specifies whether the profile has been deleted.</param>
        /// <param name="createdDateTime">Date and time the object was created.</param>
        /// <param name="createdBy"><see cref="Guid"/> representing the <see cref="MultichannelOrderManagerServer"/> who created the account.</param>
        /// <param name="lastModifiedDateTime">Date and time of when the object was last modified.</param>
        /// <param name="lastModifiedBy"><see cref="Guid"/> representing the <see cref="MultichannelOrderManagerServer"/> who last modified the account.</param>
        public MultichannelOrderManagerServer(Guid id, string name, string connectionString, string username, string password, string schema, MultichannelOrderManagerRestEndpoint endpoint, WhippetTenant tenant, bool active, bool deleted, Instant? createdDateTime, Guid? createdBy, Instant? lastModifiedDateTime, Guid? lastModifiedBy)
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
                    && String.Equals(a.ConnectionString, b.ConnectionString, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.Username, b.Username, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.Password, b.Password, StringComparison.InvariantCulture)     // don't ignore case -- passwords are case sensitive!
                    && a.Active.Equals(b.Active)
                    && a.Deleted.Equals(b.Deleted)
                    && String.Equals(a.Schema, b.Schema, StringComparison.InvariantCultureIgnoreCase)
                    && (((a.Tenant != null && b.Tenant != null) && (a.Tenant.Equals(b.Tenant))) || (a.Tenant == null && b.Tenant == null))
                    && ((a.AssociatedEndpoint == null && b.AssociatedEndpoint == null) || (a.AssociatedEndpoint != null && a.AssociatedEndpoint.Equals(b.AssociatedEndpoint)))
                    && a.CustomDatabase == b.CustomDatabase;
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
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            MultichannelOrderManagerServer server = new MultichannelOrderManagerServer();

            server.ID = ID;

            if (!String.IsNullOrWhiteSpace(Name))
            {
                server.Name = Name;
            }

            server.Username = Username;
            server.Password = Password;
            server.Schema = Schema;
            server.Tenant = Tenant.Clone<WhippetTenant>();
            server.Active = Active;
            server.Deleted = Deleted;
            server.CreatedDateTime = CreatedDateTime;
            server.CreatedBy = CreatedBy;
            server.LastModifiedDateTime = LastModifiedDateTime;
            server.LastModifiedBy = LastModifiedBy;
            server.AssociatedEndpoint = AssociatedEndpoint.Clone<MultichannelOrderManagerRestEndpoint>();
            server.CustomDatabase = CustomDatabase;

            return server;
        }

        /// <summary>
        /// Gets the name of the of the <see cref="IMultichannelOrderManagerServer"/> object.
        /// </summary>
        /// <returns>String description of the <see cref="IMultichannelOrderManagerServer"/> object.</returns>
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

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be overridden.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public override string ToJson<T>()
        {
            return this.SerializeJson(this);
        }
    }
}