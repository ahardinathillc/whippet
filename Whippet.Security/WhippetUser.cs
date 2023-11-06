using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetIpAddress = System.Net.IPAddress;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Security
{
    /// <summary>
    /// Represents a very basic user in the Whippet domain independent of any tenant or application.
    /// </summary>
    public class WhippetUser : WhippetAuditableEntity, IWhippetEntity, IWhippetUser, IWhippetActiveEntity, IWhippetSoftDeleteEntity, IWhippetAuditableEntity, IWhippetPrincipalObject
    {
        private const string DEFAULT_TZ_ID = "Etc/GMT";

        private string _userName;
        private string _password;
        private string _ipAddress;
        private string _timeZoneId;

        /// <summary>
        /// Gets a unique identifier for the object. This property is read-only.
        /// </summary>
        object IWhippetPrincipalObject.PrincipalID
        {
            get
            {
                return ID;
            }
        }

        /// <summary>
        /// Gets the representative name of the object. This property is read-only.
        /// </summary>
        string IWhippetPrincipalObject.Name
        {
            get
            {
                return UserName;
            }
        }

        /// <summary>
        /// Gets a non-localized categorization of the object type (e.g., "Group", "User", etc.). This property is read-only.
        /// </summary>
        string IWhippetPrincipalObject.PrincipalType
        {
            get
            {
                return WhippetPrincipalObjectCommonTypes.USER;
            }
        }

        /// <summary>
        /// Gets or sets the username of the <see cref="WhippetUser"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        public virtual string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                else
                {
                    _userName = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the password of the <see cref="WhippetUser"/>. The value can be encrypted or decrypted depending on implementation of the service.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        public virtual string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                else
                {
                    _password = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the time zone identifier which determines the user account's relative time zone. 
        /// </summary>
        public virtual string TimeZoneIdentifier
        {
            get
            {
                return String.IsNullOrWhiteSpace(_timeZoneId) ? DEFAULT_TZ_ID : _timeZoneId;
            }
            set
            {
                _timeZoneId = value;
            }
        }

        /// <summary>
        /// Indicates whether the current <see cref="IWhippetEntity"/> is currently active.
        /// </summary>
        public virtual bool Active
        { get; set; }

        /// <summary>
        /// Indicates whether the current <see cref="IWhippetEntity"/> is deleted.
        /// </summary>
        public virtual bool Deleted
        { get; set; }

        /// <summary>
        /// Gets or sets the e-mail address associated with the account.
        /// </summary>
        public virtual string Email
        { get; set; }

        /// <summary>
        /// Gets or sets the IP address of the last login from the user account.
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
                if(!String.IsNullOrWhiteSpace(value))
                {
                    NetIpAddress.Parse(value);
                }

                _ipAddress = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUser"/> class with no arguments.
        /// </summary>
        public WhippetUser()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUser"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetUser"/> instance.</param>
        public WhippetUser(Guid id)
            : base(id, Instant.FromDateTimeUtc(DateTime.UtcNow), id, Instant.FromDateTimeUtc(DateTime.UtcNow), id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUser"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetUser"/> instance.</param>
        /// <param name="userName">Username of the <see cref="WhippetUser"/> used to identify them within the environment irrespective of tenant.</param>
        /// <param name="password">Password associated with the <see cref="WhippetUser"/>. This value can be encrypted or decrypted.</param>
        /// <param name="createdDTTM">Date and time the user account was created or <see langword="null"/> to use the instant the <see cref="WhippetUser"/> object was created.</param>
        /// <param name="createdBy">ID of the user who created the <see cref="WhippetUser"/> account.</param>
        /// <param name="lastUpdatedDTTM">Date and time the user account was last updated or <see cref="null"/> to use the instant the <see cref="WhippetUser"/> object was created.</param>
        /// <param name="lastUpdatedBy">ID of the user who last updated the <see cref="WhippetUser"/> account.</param>
        /// <param name="tzIdentifier">Time zone identifier of the user or <see langword="null"/> or <see cref="String.Empty"/> to use the server's time zone ID.</param>
        /// <param name="active">Specifies whether the <see cref="WhippetUser"/> account is currently active.</param>
        /// <param name="deleted">Specifies whether the <see cref="WhippetUser"/> account is currently deleted.</param>
        /// <param name="email">E-mail address associated with the <see cref="WhippetUser"/> account.</param>
        /// <param name="ipAddress">IP address of the last login for the <see cref="WhippetUser"/> account or <see langword="null"/> or <see cref="String.Empty"/> to use <see cref="NetIpAddress.None"/>.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        public WhippetUser(Guid id, string userName, string password, Instant? createdDTTM, Guid? createdBy, Instant? lastUpdatedDTTM, Guid? lastUpdatedBy, string tzIdentifier, bool active, bool deleted, string email, string ipAddress)
            : this(id, userName, createdDTTM, createdBy, lastUpdatedDTTM, lastUpdatedBy, active, deleted)
        {
            Password = password;
            TimeZoneIdentifier = String.IsNullOrWhiteSpace(tzIdentifier) ? TimeZoneInfo.Local.Id : tzIdentifier;
            Email = email;
            IPAddress = String.IsNullOrWhiteSpace(ipAddress) ? NetIpAddress.None.ToString() : ipAddress;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUser"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetUser"/> instance.</param>
        /// <param name="userName">Username of the <see cref="WhippetUser"/> used to identify them within the environment irrespective of tenant.</param>
        /// <param name="createdDTTM">Date and time the user account was created or <see langword="null"/> to use the instant the <see cref="WhippetUser"/> object was created.</param>
        /// <param name="createdBy">ID of the user who created the <see cref="WhippetUser"/> account.</param>
        /// <param name="lastUpdatedDTTM">Date and time the user account was last updated or <see cref="null"/> to use the instant the <see cref="WhippetUser"/> object was created.</param>
        /// <param name="lastUpdatedBy">ID of the user who last updated the <see cref="WhippetUser"/> account.</param>
        /// <param name="active">Specifies whether the <see cref="WhippetUser"/> account is currently active.</param>
        /// <param name="deleted">Specifies whether the <see cref="WhippetUser"/> account is currently deleted.</param>
        internal WhippetUser(Guid id, string userName, Instant? createdDTTM, Guid? createdBy, Instant? lastUpdatedDTTM, Guid? lastUpdatedBy, bool active, bool deleted)
            : base(id, createdDTTM, createdBy, lastUpdatedDTTM, lastUpdatedBy)
        {
            UserName = userName;
            Active = active;
            Deleted = deleted;
        }

        /// <summary>
        /// Creates a new instance of the current <see cref="IWhippetPrincipalObject"/>.
        /// </summary>
        /// <param name="principalId">Unique identifier for the object.</param>
        /// <param name="name">Representative name of the object (if any).</param>
        /// <param name="principalType">Non-localized categorization of the object type (e.g., "Group", "User", etc.) or <see cref="String.Empty"/> or <see langword="null"/> to use the object's default.</param>
        /// <returns><see cref="IWhippetPrincipalObject"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        IWhippetPrincipalObject IWhippetPrincipalObject.CreateInstance(object principalId, string name, string principalType)
        {
            return new WhippetUser(Guid.Parse(Convert.ToString(principalId)), name, Instant.FromDateTimeUtc(DateTime.UtcNow), null, null, null, true, false);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IWhippetUser);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetUser obj)
        {
            bool equals = false;

            if (obj != null)
            {
                equals =
                    String.Equals(UserName, obj.UserName, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(Password, obj.Password, StringComparison.InvariantCultureIgnoreCase)
                        && CreatedDateTime.Equals(obj.CreatedDateTime)
                        && LastModifiedDateTime.Equals(obj.LastModifiedDateTime)
                        && CreatedBy.Equals(obj.CreatedBy)
                        && LastModifiedBy.Equals(obj.LastModifiedBy)
                        && String.Equals(TimeZoneIdentifier, obj.TimeZoneIdentifier, StringComparison.InvariantCultureIgnoreCase)
                        && Active == obj.Active
                        && Deleted == obj.Deleted
                        && String.Equals(Email, obj.Email, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(IPAddress, obj.IPAddress, StringComparison.InvariantCultureIgnoreCase);
            }

            return equals;
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="IWhippetUser"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IWhippetUser"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetUser a, IWhippetUser b)
        {
            return ((a != null) && (b != null) && (a.Equals(b))) || (a == null && b == null);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual int GetHashCode(IWhippetUser obj)
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
        /// Gets the name of the username or e-mail of the <see cref="WhippetUser"/> object.
        /// </summary>
        /// <returns>String description of the <see cref="WhippetUser"/> object.</returns>
        public override string ToString()
        {
            string sRetVal = String.Empty;

            if(!String.IsNullOrWhiteSpace(UserName) || !String.IsNullOrWhiteSpace(Email))
            {
                sRetVal = String.IsNullOrWhiteSpace(UserName) ? Email : UserName;
            }
            else
            {
                sRetVal = base.ToString();
            }

            return sRetVal;
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
