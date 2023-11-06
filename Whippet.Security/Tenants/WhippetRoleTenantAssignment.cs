using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Extensions;
using Athi.Whippet.Security.AccessControl.Extensions;
using Athi.Whippet.Security.AccessControl;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Security.Tenants
{
    /// <summary>
    /// <see cref="WhippetTenant"/> role association to a respective <see cref="WhippetRole"/>.
    /// </summary>
    public class WhippetRoleTenantAssignment : WhippetAuditableEntity, IWhippetEntity, IWhippetSoftDeleteEntity, IWhippetAuditableEntity, IWhippetActiveEntity
    {
        /// <summary>
        /// <see cref="WhippetTenant"/> who the <see cref="WhippetRole"/> is associated with. This property is read-only.
        /// </summary>
        public virtual WhippetTenant Tenant
        { get; protected set; }

        /// <summary>
        /// <see cref="WhippetRole"/> that is assigned to the <see cref="WhippetTenant"/>. This property is read-only.
        /// </summary>
        public virtual WhippetRole Role
        { get; protected set; }

        /// <summary>
        /// Indicates whether the role assignment has been deleted.
        /// </summary>
        public virtual bool Deleted
        { get; set; }

        /// <summary>
        /// Indicates whether the role assignment is currently active.
        /// </summary>
        public virtual bool Active
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRoleTenantAssignment"/> class with no arguments.
        /// </summary>
        public WhippetRoleTenantAssignment()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRoleTenantAssignment"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetRoleTenantAssignment"/> instance.</param>
        public WhippetRoleTenantAssignment(Guid id)
            : base(id, Instant.FromDateTimeUtc(DateTime.UtcNow), id, Instant.FromDateTimeUtc(DateTime.UtcNow), id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRoleTenantAssignment"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetRoleTenantAssignment"/> instance.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to assign to the role.</param>
        /// <param name="role"><see cref="IWhippetRole"/> to assign to the tenant.</param>
        /// <param name="createdDTTM">Date and time the assignment was created or <see langword="null"/> to use the instant the <see cref="WhippetRoleTenantAssignment"/> object was created.</param>
        /// <param name="createdBy">ID of the user who created the <see cref="WhippetRoleTenantAssignment"/> account.</param>
        /// <param name="lastUpdatedDTTM">Date and time the assignment was last updated or <see cref="null"/> to use the instant the <see cref="WhippetRoleTenantAssignment"/> object was created.</param>
        /// <param name="lastUpdatedBy">ID of the user who last updated the <see cref="WhippetRoleTenantAssignment"/> account.</param>
        /// <param name="active">Specifies whether the <see cref="WhippetRoleTenantAssignment"/> association is currently active.</param>
        /// <param name="deleted">Specifies whether the <see cref="WhippetRoleTenantAssignment"/> association is currently deleted.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        public WhippetRoleTenantAssignment(Guid id, IWhippetTenant tenant, IWhippetRole role, Instant? createdDTTM, Guid? createdBy, Instant? lastUpdatedDTTM, Guid? lastUpdatedBy, bool active, bool deleted)
            : base(id, createdDTTM, createdBy, lastUpdatedDTTM, lastUpdatedBy)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            else
            {
                Tenant = tenant.ToWhippetTenant();
                Role = Role.ToWhippetRole();
                Active = active;
                Deleted = deleted;
            }
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as WhippetRoleTenantAssignment);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(WhippetRoleTenantAssignment obj)
        {
            bool equals = false;

            if (obj != null)
            {
                equals = Tenant.Equals(obj.Tenant)
                        && Role.Equals(obj.Role)
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
        /// <param name="a">The first object of type <see cref="WhippetRoleTenantAssignment"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="WhippetRoleTenantAssignment"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(WhippetRoleTenantAssignment a, WhippetRoleTenantAssignment b)
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
        public virtual int GetHashCode(WhippetRoleTenantAssignment obj)
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
        /// Gets the name of the tenantname or e-mail of the <see cref="WhippetRoleTenantAssignment"/> object.
        /// </summary>
        /// <returns>String description of the <see cref="WhippetRoleTenantAssignment"/> object.</returns>
        public override string ToString()
        {
            return Role.ToString() + " (" + Tenant.ToString() + ")";
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
