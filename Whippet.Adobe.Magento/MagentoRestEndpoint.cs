using System;
using System.Text;
using NodaTime;
using Athi.Whippet.Net.Rest;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento
{
    /// <summary>
    /// Represents a single instance of the Magento e-commerce product that is locally or remotely hosted. All <see cref="MagentoEntity"/> objects reference a single <see cref="MagentoRestEndpoint"/>.
    /// </summary>
    /// <remarks>See <a href="https://community.magento.com/t5/Magento-2-x-Programming/C-Updating-a-product-Magento-2-API-REST/td-p/458488">C# Updating a product Magento 2 API REST</a> for information on how to make REST calls.</remarks>
    public class MagentoRestEndpoint : WhippetAuditableEntity, IWhippetAuditableEntity, IWhippetActiveEntity, IWhippetSoftDeleteEntity, IMagentoRestEndpoint, IEqualityComparer<IMagentoRestEndpoint>, IRestEndpoint, IMagentoServer
    {
        private bool _active;

        private string _name;

        private WhippetTenant _tenant;

        /// <summary>
        /// Gets or sets the unique name of the endpoint profile.
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
        /// This property is not supported on this type.
        /// </summary>
        /// <exception cref="InvalidOperationException" />
        string IMagentoServer.Schema
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
        string IMagentoServer.ConnectionString
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
        IMagentoRestEndpoint IMagentoServer.AssociatedEndpoint
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
        /// Indicates the type of the current <see cref="IMagentoServer"/>. This property is read-only.
        /// </summary>
        ExternalDataSourceType IMagentoServer.ServerType
        {
            get
            {
                return ExternalDataSourceType.REST;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoRestEndpoint"/> class with no arguments.
        /// </summary>
        public MagentoRestEndpoint()
            : base()
        { }

        /// <summary>
        /// Creates a new instance of the <see cref="MagentoRestEndpoint"/> class.
        /// </summary>
        /// <param name="id">Unique ID to assign to the <see cref="MagentoRestEndpoint"/>.</param>
        /// <param name="name">Unique name of the endpoint profile.</param>
        /// <param name="username">Username used make the request.</param>
        /// <param name="password">Password used make the request.</param>
        /// <param name="restUrl">URL to the RESTful endpoint of the Magento endpoint.</param>
        /// <param name="tenant"><see cref="WhippetTenant"/> the endpoint is registered with.</param>
        /// <param name="active">Specifies whether the profile is currently active.</param>
        /// <param name="deleted">Specifies whether the profile has been deleted.</param>
        /// <param name="createdDateTime">Date and time the object was created.</param>
        /// <param name="createdBy"><see cref="Guid"/> representing the <see cref="MagentoRestEndpoint"/> who created the account.</param>
        /// <param name="lastModifiedDateTime">Date and time of when the object was last modified.</param>
        /// <param name="lastModifiedBy"><see cref="Guid"/> representing the <see cref="MagentoRestEndpoint"/> who last modified the account.</param>
        public MagentoRestEndpoint(Guid id, string name, string username, string password, string restUrl, WhippetTenant tenant, bool active, bool deleted, Instant? createdDateTime, Guid? createdBy, Instant? lastModifiedDateTime, Guid? lastModifiedBy)
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
            return Equals(obj as IMagentoRestEndpoint);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMagentoRestEndpoint obj)
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
        /// <param name="a">The first object of type <see cref="IMagentoRestEndpoint"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IMagentoRestEndpoint"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMagentoRestEndpoint a, IMagentoRestEndpoint b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals = String.Equals(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(((IMagentoServer)(a)).Username, ((IMagentoServer)(b)).Username, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(((IMagentoServer)(a)).Password, ((IMagentoServer)(b)).Password, StringComparison.InvariantCulture)     // don't ignore case -- passwords are case sensitive!
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
        /// <param name="a">The first object of type <see cref="IMagentoServer"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IMagentoServer"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        bool IEqualityComparer<IMagentoServer>.Equals(IMagentoServer x, IMagentoServer y)
        {
            return (x == null && y == null) || (x != null && x.Equals(y));
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
        public virtual int GetHashCode(IMagentoRestEndpoint obj)
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
        int IEqualityComparer<IMagentoServer>.GetHashCode(IMagentoServer obj)
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
        /// Gets the name of the of the <see cref="IMagentoRestEndpoint"/> object.
        /// </summary>
        /// <returns>String description of the <see cref="IMagentoRestEndpoint"/> object.</returns>
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

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be inherited.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public override string ToJson<T>()
        {
            return this.SerializeJson(this);
        }
    }
}
