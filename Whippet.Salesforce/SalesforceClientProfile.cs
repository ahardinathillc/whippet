using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Represents an individual client connection to Salesforce Cloud.
    /// </summary>
    /// <remarks>See <a href="https://github.com/wadewegner/Force.com-Toolkit-for-NET">Force.com Toolkit for .NET</a> for more information.</remarks>
    public class SalesforceClientProfile : WhippetAuditableEntity, IWhippetAuditableEntity, IWhippetActiveEntity, IWhippetSoftDeleteEntity, ISalesforceClientProfile, IEqualityComparer<ISalesforceClientProfile>
    {
        private bool _active;

        private string _name;
        private string _url;
        private string _consumerKey;
        private string _consumerSecret;

        private WhippetTenant _tenant;

        /// <summary>
        /// Gets or sets the unique name of the Salesforce profile.
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
        /// Gets or sets the URL to the Salesforce instance.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        public virtual string Url
        {
            get
            {
                return _url;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                else
                {
                    _url = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the consumer key which uniquely identifies the application to Salesforce for authentication.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        public virtual string ConsumerKey
        {
            get
            {
                return _consumerKey;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                else
                {
                    _consumerKey = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the consumer secret value.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        public virtual string ConsumerSecret
        {
            get
            {
                return _consumerSecret;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                else
                {
                    _consumerSecret = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the API token.
        /// </summary>
        public virtual string ApiToken
        { get; set; }

        /// <summary>
        /// Gets or sets the user name used to authenticate the request.
        /// </summary>
        public virtual string Username
        { get; set; }

        /// <summary>
        /// Gets or sets the password used to authenticate the request.
        /// </summary>
        public virtual string Password
        { get; set; }

        /// <summary>
        /// Specifies the <see cref="WhippetTenant"/> that the Salesforce instance is registered with.
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
        /// Specifies whether the web-server authentication flow should be used.
        /// </summary>
        public virtual bool UseWebServerAuthenticationFlow
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> that the server is registered with.
        /// </summary>
        IWhippetTenant ISalesforceClientProfile.Tenant
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
        /// Initializes a new instance of the <see cref="SalesforceClientProfile"/> class with no arguments.
        /// </summary>
        public SalesforceClientProfile()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceClientProfile"/> with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="SalesforceClientProfile"/>.</param>
        public SalesforceClientProfile(Guid id)
            : base(id, Instant.FromDateTimeUtc(DateTime.UtcNow), null, null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceClientProfile"/> class.
        /// </summary>
        /// <param name="id">Unique ID to assign to the <see cref="SalesforceClientProfile"/>.</param>
        /// <param name="name">Unique name of the Salesforce profile.</param>
        /// <param name="url">Root URL to the Salesforce instance.</param>
        /// <param name="apiToken">API token used to make external Salesforce requests.</param>
        /// <param name="consumerKey">Consumer key that identifies the application to the Salesforce instance.</param>
        /// <param name="consumerSecret">Consumer secret used in authentication.</param>
        /// <param name="useWebServerAuthenticationFlow">If <see langword="true"/>, will use the web-server authentication flow.</param>
        /// <param name="tenant"><see cref="WhippetTenant"/> the profile is registered with.</param>
        /// <param name="active">Specifies whether the profile is currently active.</param>
        /// <param name="deleted">Specifies whether the profile has been deleted.</param>
        /// <param name="createdDateTime">Date and time the object was created.</param>
        /// <param name="createdBy"><see cref="Guid"/> representing the <see cref="SalesforceClientProfile"/> who created the account.</param>
        /// <param name="lastModifiedDateTime">Date and time of when the object was last modified.</param>
        /// <param name="lastModifiedBy"><see cref="Guid"/> representing the <see cref="MultichannelOrderManagerServer"/> who last modified the account.</param>
        public SalesforceClientProfile(Guid id, string name, string url, string apiToken, string consumerKey, string consumerSecret, bool useWebServerAuthenticationFlow, WhippetTenant tenant, bool active, bool deleted, Instant? createdDateTime, Guid? createdBy, Instant? lastModifiedDateTime, Guid? lastModifiedBy)
            : base(id, createdDateTime, createdBy, lastModifiedDateTime, lastModifiedBy)
        {
            Name = name;
            Url = url;
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            UseWebServerAuthenticationFlow = useWebServerAuthenticationFlow;
            Tenant = tenant;
            Active = active;
            Deleted = deleted;
            ApiToken = apiToken;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as ISalesforceClientProfile);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ISalesforceClientProfile obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="ISalesforceClientProfile"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="ISalesforceClientProfile"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ISalesforceClientProfile a, ISalesforceClientProfile b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals = String.Equals(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.ConsumerKey, b.ConsumerKey, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.Url, b.Url, StringComparison.InvariantCultureIgnoreCase)
                    && a.Active.Equals(b.Active)
                    && a.Deleted.Equals(b.Deleted)
                    && (((a.Tenant != null && b.Tenant != null) && (a.Tenant.Equals(b.Tenant))) || (a.Tenant == null && b.Tenant == null))
                    && String.Equals(a.ApiToken, b.ApiToken, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.ConsumerSecret, b.ConsumerSecret, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.Password, b.Password, StringComparison.InvariantCulture)     // passwords are case-sensitive
                    && String.Equals(a.Username, b.Username, StringComparison.InvariantCultureIgnoreCase)
                    && (a.UseWebServerAuthenticationFlow == b.UseWebServerAuthenticationFlow);
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
        public virtual int GetHashCode(ISalesforceClientProfile obj)
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
        /// Gets the name of the of the <see cref="ISalesforceClientProfile"/> object.
        /// </summary>
        /// <returns>String description of the <see cref="ISalesforceClientProfile"/> object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            if (!String.IsNullOrWhiteSpace(Name))
            {
                builder.Append(Name);

                if (!String.IsNullOrWhiteSpace(Url))
                {
                    builder.Append(" ");
                    builder.Append('[');
                    builder.Append(Url);
                    builder.Append(']');
                }
            }
            else if (!String.IsNullOrWhiteSpace(Url))
            {
                builder.Append(Url);
            }
            else
            {
                builder.Append(base.ToString());
            }

            return builder.ToString();
        }
    }
}
