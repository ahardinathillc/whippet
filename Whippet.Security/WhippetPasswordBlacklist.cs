using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Security
{
    /// <summary>
    /// Represents a blacklist entry for a password. Blacklisted passwords are not allowed to be used.
    /// </summary>
    public class WhippetPasswordBlacklist : WhippetEntity, IWhippetEntity, IWhippetPasswordBlacklist, IEqualityComparer<IWhippetPasswordBlacklist>
    {
        private WhippetTenant _tenant;

        /// <summary>
        /// Gets or sets the password that is blacklisted.
        /// </summary>
        public virtual string Password
        { get; set; }

        /// <summary>
        /// Gets or sets the tenant that the password blacklist entry applies to.
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
        /// Gets or sets the tenant that the password blacklist entry applies to.
        /// </summary>
        IWhippetTenant IWhippetPasswordBlacklist.Tenant
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
        /// Initializes a new instance of the <see cref="WhippetPasswordBlacklist"/> class with no arguments.
        /// </summary>
        public WhippetPasswordBlacklist()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPasswordBlacklist"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetPasswordBlacklist"/> instance.</param>
        public WhippetPasswordBlacklist(Guid id)
            : base(id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPasswordBlacklist"/> class with the specified ID and password.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetPasswordBlacklist"/> instance or <see langword="null"/> to assign a new ID.</param>
        /// <param name="password">Password that is blacklisted.</param>
        public WhippetPasswordBlacklist(Guid? id, string password)
            : this(id.GetValueOrDefault(Guid.NewGuid()))
        {
            Password = password;
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
        public virtual bool Equals(IWhippetPasswordBlacklist obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="IWhippetPasswordBlacklist"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IWhippetPasswordBlacklist"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetPasswordBlacklist a, IWhippetPasswordBlacklist b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals = a.Tenant.Equals(b.Tenant) && String.Equals(a.Password, b.Password, StringComparison.InvariantCulture);
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
        /// <param name="obj">The <see cref="IWhippetPasswordBlacklist"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual int GetHashCode(IWhippetPasswordBlacklist obj)
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
        /// Gets the <see cref="Password"/> field value.
        /// </summary>
        /// <returns><see cref="String"/> representation of the current object.</returns>
        public override string ToString()
        {
            return Password;
        }
    }
}
