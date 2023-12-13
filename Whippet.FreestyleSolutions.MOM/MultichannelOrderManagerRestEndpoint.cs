using System;
using System.Text;
using NodaTime;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Net.Rest;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents a single instance of the Multichannel Order Manager product that is locally or remotely hosted.
    /// </summary>
    public class MultichannelOrderManagerRestEndpoint : WhippetAuditableEntity, IWhippetAuditableEntity, IWhippetActiveEntity, IWhippetSoftDeleteEntity, IMultichannelOrderManagerRestEndpoint, IEqualityComparer<IMultichannelOrderManagerRestEndpoint>, IRestEndpoint, IMultichannelOrderManagerServer
    {
        private bool _active;


        private WhippetTenant _tenant;

        private bool _custom;

        /// <summary>
        /// Gets or sets the unique name of the endpoint profile.
        /// </summary>
        public virtual string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the (encrypted) username to access the endpoint, if any.
        /// </summary>
        public virtual string Username
        { get; set; }

        /// <summary>
        /// Gets or sets the (encrypted) password to access the endpoint, if any.
        /// </summary>
        public virtual string Password
        { get; set; }

        /// <summary>
        /// Gets or sets the REST endpoint URL.
        /// </summary>
        public virtual string URL
        { get; set; }

        /// <summary>
        /// Specifies whether the profile has been deleted.
        /// </summary>
        public virtual bool Deleted
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="WhippetTenant"/> that the endpoint is registered with.
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
        /// Gets or sets the <see cref="IWhippetTenant"/> that the endpoint is registered with.
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
        /// This property is not supported on this type.
        /// </summary>
        /// <exception cref="InvalidOperationException" />
        string IMultichannelOrderManagerServer.Schema
        {
            get
            {
                return null;
            }
            set
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Gets or sets the REST endpoint URL.
        /// </summary>
        string IMultichannelOrderManagerServer.ConnectionString
        {
            get
            {
                return URL;
            }
            set
            {
                URL = value;
            }
        }

        /// <summary>
        /// Gets the current instance. This property is read-only.
        /// </summary>
        /// <exception cref="InvalidOperationException" />
        IMultichannelOrderManagerRestEndpoint IMultichannelOrderManagerServer.AssociatedEndpoint
        {
            get
            {
                return this;
            }
            set
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Indicates the type of the current <see cref="IMultichannelOrderManagerServer"/>. This property is read-only.
        /// </summary>
        ExternalDataSourceType IMultichannelOrderManagerServer.ServerType
        {
            get
            {
                return ExternalDataSourceType.REST;
            }
        }

        /// <summary>
        /// This property is not applicable to the current type. This property is read-only.
        /// </summary>
        bool IMultichannelOrderManagerServer.CustomDatabase
        {
            get
            {
                return false;
            }
            set
            {
                _custom = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerRestEndpoint"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerRestEndpoint()
            : base()
        { }

        /// <summary>
        /// Creates a new instance of the <see cref="MultichannelOrderManagerRestEndpoint"/> class.
        /// </summary>
        /// <param name="id">Unique ID to assign to the <see cref="MultichannelOrderManagerRestEndpoint"/>.</param>
        /// <param name="name">Unique name of the endpoint profile.</param>
        /// <param name="username">Username used make the request.</param>
        /// <param name="password">Password used make the request.</param>
        /// <param name="restUrl">URL to the RESTful endpoint of the MultichannelOrderManager endpoint.</param>
        /// <param name="tenant"><see cref="WhippetTenant"/> the endpoint is registered with.</param>
        /// <param name="active">Specifies whether the profile is currently active.</param>
        /// <param name="deleted">Specifies whether the profile has been deleted.</param>
        /// <param name="createdDateTime">Date and time the object was created.</param>
        /// <param name="createdBy"><see cref="Guid"/> representing the <see cref="MultichannelOrderManagerRestEndpoint"/> who created the account.</param>
        /// <param name="lastModifiedDateTime">Date and time of when the object was last modified.</param>
        /// <param name="lastModifiedBy"><see cref="Guid"/> representing the <see cref="MultichannelOrderManagerRestEndpoint"/> who last modified the account.</param>
        public MultichannelOrderManagerRestEndpoint(Guid id, string name, string username, string password, string restUrl, WhippetTenant tenant, bool active, bool deleted, Instant? createdDateTime, Guid? createdBy, Instant? lastModifiedDateTime, Guid? lastModifiedBy)
            : base(id, createdDateTime, createdBy, lastModifiedDateTime, lastModifiedBy)
        {
            Name = name;
            Username = username;
            Password = password;
            Active = active;
            Deleted = deleted;
            Tenant = tenant;
            URL = restUrl;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IMultichannelOrderManagerRestEndpoint);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerRestEndpoint obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IRestEndpoint obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="IRestEndpoint"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IRestEndpoint"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IRestEndpoint a, IRestEndpoint b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals = String.Equals(a.Username, b.Username, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.Password, b.Password, StringComparison.InvariantCulture)     // don't ignore case -- passwords are case sensitive!
                    && String.Equals(a.URL, b.URL, StringComparison.InvariantCultureIgnoreCase);
            }

            return equals;
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="IMultichannelOrderManagerRestEndpoint"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IMultichannelOrderManagerRestEndpoint"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerRestEndpoint a, IMultichannelOrderManagerRestEndpoint b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals = String.Equals(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(((IMultichannelOrderManagerServer)(a)).Username, ((IMultichannelOrderManagerServer)(b)).Username, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(((IMultichannelOrderManagerServer)(a)).Password, ((IMultichannelOrderManagerServer)(b)).Password, StringComparison.InvariantCulture)     // don't ignore case -- passwords are case sensitive!
                    && a.Active.Equals(b.Active)
                    && a.Deleted.Equals(b.Deleted)
                    && (((a.Tenant != null && b.Tenant != null) && (a.Tenant.Equals(b.Tenant))) || (a.Tenant == null && b.Tenant == null))
                    && String.Equals(a.URL, b.URL, StringComparison.InvariantCultureIgnoreCase);
            }

            return equals;
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="IMultichannelOrderManagerServer"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IMultichannelOrderManagerServer"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        bool IEqualityComparer<IMultichannelOrderManagerServer>.Equals(IMultichannelOrderManagerServer x, IMultichannelOrderManagerServer y)
        {
            return (x == null && y == null) || (x != null && x.Equals(y));
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            MultichannelOrderManagerRestEndpoint endpoint = new MultichannelOrderManagerRestEndpoint();

            endpoint.ID = ID;

            if (!String.IsNullOrWhiteSpace(Name))
            {
                endpoint.Name = Name;
            }

            endpoint.Username = Username;
            endpoint.Password = Password;
            endpoint.URL = URL;
            endpoint.Tenant = Tenant.Clone<WhippetTenant>();
            endpoint.Active = Active;
            endpoint.Deleted = Deleted;
            endpoint.CreatedDateTime = CreatedDateTime;
            endpoint.CreatedBy = CreatedBy;
            endpoint.LastModifiedBy = LastModifiedBy;
            endpoint.LastModifiedDateTime = LastModifiedDateTime;

            return endpoint;
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
        public virtual int GetHashCode(IMultichannelOrderManagerRestEndpoint obj)
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
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual int GetHashCode(IRestEndpoint obj)
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
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException" />
        int IEqualityComparer<IMultichannelOrderManagerServer>.GetHashCode(IMultichannelOrderManagerServer obj)
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
        /// Gets the name of the of the <see cref="IMultichannelOrderManagerRestEndpoint"/> object.
        /// </summary>
        /// <returns>String description of the <see cref="IMultichannelOrderManagerRestEndpoint"/> object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            if (!String.IsNullOrWhiteSpace(Name))
            {
                builder.Append(Name);

                if (!String.IsNullOrWhiteSpace(URL))
                {
                    builder.Append(" ");
                    builder.Append('[');
                    builder.Append(URL);
                    builder.Append(']');
                }
            }
            else if (!String.IsNullOrWhiteSpace(URL))
            {
                builder.Append(URL);
            }
            else
            {
                builder.Append(base.ToString());
            }

            return builder.ToString();
        }

    }
}
