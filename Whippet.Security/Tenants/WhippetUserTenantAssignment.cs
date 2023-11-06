using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.Security.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Security.Tenants
{
    /// <summary>
    /// Provides a mapping between a <see cref="WhippetTenant"/> and a <see cref="WhippetUser"/>. 
    /// </summary>
    public class WhippetUserTenantAssignment : WhippetEntity, IWhippetEntity, IWhippetUserTenantAssignment, IEqualityComparer<IWhippetUserTenantAssignment>
    {
        private WhippetTenant _tenant;
        private WhippetUser _user;

        /// <summary>
        /// Gets or sets the <see cref="WhippetTenant"/> that the <see cref="WhippetUser"/> is assigned to.
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
        /// Gets or sets the <see cref="IWhippetTenant"/> that the <see cref="IWhippetUser"/> is assigned to.
        /// </summary>
        IWhippetTenant IWhippetUserTenantAssignment.Tenant
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
        /// Gets or sets the <see cref="WhippetUser"/> that is assigned to <see cref="Tenant"/>.
        /// </summary>
        public virtual WhippetUser User
        {
            get
            {
                if (_user == null)
                {
                    _user = new WhippetUser();
                }

                return _user;
            }
            set
            {
                _user = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IWhippetUser"/> that is assigned to <see cref="Tenant"/>.
        /// </summary>
        IWhippetUser IWhippetUserTenantAssignment.User
        {
            get
            {
                return User;
            }
            set
            {
                User = value?.ToWhippetUser();
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserTenantAssignment"/> class with no arguments.
        /// </summary>
        public WhippetUserTenantAssignment()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserTenantAssignment"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetUserTenantAssignment"/> instance.</param>
        public WhippetUserTenantAssignment(Guid id)
            : base(id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserTenantAssignment"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetUserTenantAssignment"/> instance.</param>
        /// <param name="user"><see cref="WhippetUser"/> object</param>
        /// <param name="tenant"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetUserTenantAssignment(Guid id, WhippetUser user, WhippetTenant tenant)
            : this(id)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                User = user;
                Tenant = tenant;
            }
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IWhippetUserTenantAssignment);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetUserTenantAssignment obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="IWhippetUserTenantAssignment"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IWhippetUserTenantAssignment"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetUserTenantAssignment a, IWhippetUserTenantAssignment b)
        {
            bool equals = (a == null && b == null);

            if (!equals)
            {
                equals = ((a.User == null && b.User == null) || (a.User != null && a.User.Equals(b.User)))
                    && ((a.Tenant == null && b.Tenant == null) || (a.Tenant != null && a.Tenant.Equals(b.Tenant)));
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
        public virtual int GetHashCode(IWhippetUserTenantAssignment obj)
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
        /// Gets the name of the username or e-mail of the <see cref="WhippetUserTenantAssignment"/> object.
        /// </summary>
        /// <returns>String description of the <see cref="WhippetUserTenantAssignment"/> object.</returns>
        public override string ToString()
        {
            return "[" + User.ToString() + " | " + Tenant.ToString() + "]";
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
