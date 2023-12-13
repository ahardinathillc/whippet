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
    /// Blacklist of IP addresses that are automatically denied login or access to the Whippet system.
    /// </summary>
    public class WhippetIpAddressBlacklist : WhippetAuditableEntity, IWhippetEntity, IWhippetIpAddressBlacklist, IWhippetActiveEntity, IWhippetSoftDeleteEntity, IWhippetAuditableEntity
    {
        private string _ipAddress;

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
                if (!String.IsNullOrWhiteSpace(value))
                {
                    NetIpAddress.Parse(value);
                }

                _ipAddress = value;
            }
        }

        /// <summary>
        /// Gets or sets the tenant that the IP address blacklist applies to.
        /// </summary>
        public virtual WhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Gets or sets the tenant that the IP address blacklist applies to.
        /// </summary>
        IWhippetTenant IWhippetIpAddressBlacklist.Tenant
        {
            get
            {
                return Tenant;
            }
            set
            {
                Tenant = (value == null ? null : value.ToWhippetTenant());
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetIpAddressBlacklist"/> class with no arguments.
        /// </summary>
        public WhippetIpAddressBlacklist()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetIpAddressBlacklist"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetIpAddressBlacklist"/> instance.</param>
        public WhippetIpAddressBlacklist(Guid id)
            : base(id, Instant.FromDateTimeUtc(DateTime.UtcNow), id, Instant.FromDateTimeUtc(DateTime.UtcNow), id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetIpAddressBlacklist"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetIpAddressBlacklist"/> instance.</param>
        /// <param name="ipAddress">IP address that is blacklisted.</param>
        /// <param name="tenant">Tenant that the IP address blacklist is to apply to.</param>
        /// <param name="createdDTTM">Date and time the user account was created or <see langword="null"/> to use the instant the <see cref="WhippetIpAddressBlacklist"/> object was created.</param>
        /// <param name="createdBy">ID of the user who created the <see cref="WhippetIpAddressBlacklist"/> account.</param>
        /// <param name="lastUpdatedDTTM">Date and time the user account was last updated or <see cref="null"/> to use the instant the <see cref="WhippetIpAddressBlacklist"/> object was created.</param>
        /// <param name="lastUpdatedBy">ID of the user who last updated the <see cref="WhippetIpAddressBlacklist"/> account.</param>
        /// <param name="active">Specifies whether the <see cref="WhippetIpAddressBlacklist"/> account is currently active.</param>
        /// <param name="deleted">Specifies whether the <see cref="WhippetIpAddressBlacklist"/> account is currently deleted.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        public WhippetIpAddressBlacklist(Guid id, string ipAddress, WhippetTenant tenant, Instant? createdDTTM, Guid? createdBy, Instant? lastUpdatedDTTM, Guid? lastUpdatedBy, bool active, bool deleted)
            : base(id, createdDTTM, createdBy, lastUpdatedDTTM, lastUpdatedBy)
        {
            IPAddress = String.IsNullOrWhiteSpace(ipAddress) ? NetIpAddress.None.ToString() : ipAddress;
            Tenant = tenant;
            Active = active;
            Deleted = deleted;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IWhippetIpAddressBlacklist);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetIpAddressBlacklist obj)
        {
            bool equals = false;

            if (obj != null)
            {
                equals =
                    String.Equals(IPAddress, obj.IPAddress, StringComparison.InvariantCultureIgnoreCase)
                        && ((Tenant == null && obj.Tenant == null) || (Tenant != null && Tenant.Equals(obj.Tenant)))
                        && CreatedDateTime.Equals(obj.CreatedDateTime)
                        && LastModifiedDateTime.Equals(obj.LastModifiedDateTime)
                        && CreatedBy.Equals(obj.CreatedBy)
                        && LastModifiedBy.Equals(obj.LastModifiedBy)
                        && Active == obj.Active
                        && Deleted == obj.Deleted;
            }

            return equals;
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="IWhippetIpAddressBlacklist"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IWhippetIpAddressBlacklist"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetIpAddressBlacklist a, IWhippetIpAddressBlacklist b)
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
        public virtual int GetHashCode(IWhippetIpAddressBlacklist obj)
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
        /// Gets the name of the username or e-mail of the <see cref="WhippetIpAddressBlacklist"/> object.
        /// </summary>
        /// <returns>String description of the <see cref="WhippetIpAddressBlacklist"/> object.</returns>
        public override string ToString()
        {
            return IPAddress;
        }
    }
}
