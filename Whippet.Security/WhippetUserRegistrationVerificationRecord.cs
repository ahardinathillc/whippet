using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetIpAddress = System.Net.IPAddress;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Security
{
    /// <summary>
    /// Provides a staging process for newly registered users. Users are sent a verification e-mail or SMS message to authenticate their request to create a new account.
    /// </summary>
    public class WhippetUserRegistrationVerificationRecord : WhippetAuditableEntity, IWhippetEntity, IWhippetSoftDeleteEntity, IWhippetAuditableEntity, IWhippetUserRegistrationVerificationRecord
    {
        private string _ipAddress;

        /// <summary>
        /// Gets or sets the name (e-mail address) of the <see cref="WhippetUser"/> that is requesting to register an account.
        /// </summary>
        public virtual string UserName
        { get; set; }

        /// <summary>
        /// Gets or sets the authentication key used to authorize the request and create the account or allow access.
        /// </summary>
        public virtual string AuthenticationKey
        { get; set; }

        /// <summary>
        /// URL that the user can go directly to in order to authenticate their request.
        /// </summary>
        public virtual string AuthenticationUrl
        { get; set; }

        /// <summary>
        /// The expiration date indicates when the request is considered stale. Once this state is reached, the user will need to resubmit a new request to register an account.
        /// </summary>
        public virtual Instant RequestExpirationDate
        { get; set; }

        /// <summary>
        /// The date the request was authenticated. If <see langword="null"/>, the request has not been authenticated.
        /// </summary>
        public virtual Instant? DateAuthenticated
        { get; set; }

        /// <summary>
        /// Indicates whether the current <see cref="WhippetUserRegistrationVerificationRecord"/> is deleted.
        /// </summary>
        public virtual bool Deleted
        { get; set; }

        /// <summary>
        /// Gets or sets the IP address that the request originated from.
        /// </summary>
        /// <exception cref="FormatException" />
        public virtual string IPAddress
        {
            get
            {
                return _ipAddress;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    NetIpAddress.Parse(value);
                }

                _ipAddress = value;
            }
        }

        /// <summary>
        /// Associates the record with the appropriate <see cref="WhippetTenant"/>.
        /// </summary>
        public virtual WhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Gets or sets the ID of the <see cref="IWhippetUser"/> account that the verification record is associated with. If <see langword="null"/>, the record has not been authenticated yet and no user record has been associated.
        /// </summary>
        public virtual Guid? UserId
        { get; set; }

        /// <summary>
        /// Associates the record with the appropriate <see cref="IWhippetTenant"/>.
        /// </summary>
        IWhippetTenant IWhippetUserRegistrationVerificationRecord.Tenant
        { 
            get
            {
                return Tenant;
            }
            set
            {
                Tenant = (value == null) ? null : value.ToWhippetTenant();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserRegistrationVerificationRecord"/> class with no arguments.
        /// </summary>
        public WhippetUserRegistrationVerificationRecord()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserRegistrationVerificationRecord"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetUserRegistrationVerificationRecord"/> instance.</param>
        public WhippetUserRegistrationVerificationRecord(Guid id)
            : base(id, Instant.FromDateTimeUtc(DateTime.UtcNow), id, Instant.FromDateTimeUtc(DateTime.UtcNow), id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserRegistrationVerificationRecord"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetUserRegistrationVerificationRecord"/> instance.</param>
        /// <param name="userName">Username associated with the <see cref="WhippetUserRegistrationVerificationRecord"/>.</param>
        /// <param name="authenticationKey">Authentication key used to authorize the request.</param>
        /// <param name="authenticationUrl">URL that the user can go directly to in order to authenticate their request.</param>
        /// <param name="requestExpirationDate">Expiration date that indicates when the request is considered stale.</param>
        /// <param name="requestAuthenticatedDate">Date that the request was authenticated (if any).</param>
        /// <param name="ipAddress">IP address that the request originated from.</param>
        /// <param name="createdDTTM">Date and time the request was submitted or <see langword="null"/> to use the instant the <see cref="WhippetUserRegistrationVerificationRecord"/> object was created.</param>
        /// <param name="createdBy">ID of the user who created the <see cref="WhippetUserRegistrationVerificationRecord"/> account.</param>
        /// <param name="lastUpdatedDTTM">Date and time the record was last updated or <see cref="null"/> to use the instant the <see cref="WhippetUserRegistrationVerificationRecord"/> object was created.</param>
        /// <param name="lastUpdatedBy">ID of the user who last updated the <see cref="WhippetUserRegistrationVerificationRecord"/> account.</param>
        /// <param name="deleted">Specifies whether the <see cref="WhippetUserRegistrationVerificationRecord"/> account is currently deleted.</param>
        /// <param name="tenant"><see cref="WhippetTenant"/> that the registration record is associated with.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        public WhippetUserRegistrationVerificationRecord(Guid id, string userName, string authenticationKey, string authenticationUrl, Instant requestExpirationDate, Instant? requestAuthenticatedDate, string ipAddress, Instant? createdDTTM, Guid? createdBy, Instant? lastUpdatedDTTM, Guid? lastUpdatedBy, bool deleted, WhippetTenant tenant)
            : base(id, createdDTTM, createdBy, lastUpdatedDTTM, lastUpdatedBy)
        {
            UserName = userName;
            AuthenticationKey = authenticationKey;
            AuthenticationUrl = authenticationUrl;
            RequestExpirationDate = requestExpirationDate;
            IPAddress = ipAddress;
            Deleted = deleted;
            DateAuthenticated = requestAuthenticatedDate;
            Tenant = tenant;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IWhippetUserRegistrationVerificationRecord);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetUserRegistrationVerificationRecord obj)
        {
            bool equals = false;

            if (obj != null)
            {
                equals =
                    String.Equals(UserName, obj.UserName, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(AuthenticationKey, obj.AuthenticationKey, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(AuthenticationUrl, obj.AuthenticationUrl, StringComparison.InvariantCultureIgnoreCase)
                        && RequestExpirationDate.Equals(obj.RequestExpirationDate)
                        && (!String.IsNullOrWhiteSpace(IPAddress) && !String.IsNullOrWhiteSpace(obj.IPAddress) && NetIpAddress.Parse(IPAddress).Equals(NetIpAddress.Parse(obj.IPAddress)))
                        && CreatedDateTime.Equals(obj.CreatedDateTime)
                        && LastModifiedDateTime.Equals(obj.LastModifiedDateTime)
                        && CreatedBy.Equals(obj.CreatedBy)
                        && LastModifiedBy.Equals(obj.LastModifiedBy)
                        && Deleted == obj.Deleted
                        && DateAuthenticated.GetValueOrDefault().Equals(obj.DateAuthenticated.GetValueOrDefault())
                        && ((Tenant == null && obj.Tenant == null) || (Tenant != null && Tenant.Equals(obj.Tenant)));
            }

            return equals;
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="WhippetUser"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="WhippetUser"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetUserRegistrationVerificationRecord a, IWhippetUserRegistrationVerificationRecord b)
        {
            return ((a != null) && (b != null) && (a.Equals(b))) || (a == null && b == null);
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
        public virtual int GetHashCode(IWhippetUserRegistrationVerificationRecord obj)
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
        /// Gets the string representation of the <see cref="WhippetUserRegistrationVerificationRecord"/>.
        /// </summary>
        /// <returns>String description of the <see cref="WhippetUserRegistrationVerificationRecord"/> object.</returns>
        public override string ToString()
        {
            string sRetVal = String.Empty;

            if (!String.IsNullOrWhiteSpace(UserName))
            {
                sRetVal = UserName;

                if(DateAuthenticated.HasValue)
                {
                    sRetVal = sRetVal + " (Authenticated " + DateAuthenticated.Value.ToString() + ")";
                }

            }
            else
            {
                sRetVal = base.ToString();
            }

            return sRetVal;
        }
    }
}
