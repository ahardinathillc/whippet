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
    /// <see cref="WhippetTenant"/> group association to a respective <see cref="WhippetGroup"/>.
    /// </summary>
    public class WhippetGroupTenantAssignment : WhippetAuditableEntity, IWhippetEntity, IWhippetSoftDeleteEntity, IWhippetAuditableEntity, IWhippetActiveEntity
    {
        /// <summary>
        /// <see cref="WhippetTenant"/> who the <see cref="WhippetGroup"/> is associated with. This property is read-only.
        /// </summary>
        public virtual WhippetTenant Tenant
        { get; protected set; }

        /// <summary>
        /// <see cref="WhippetGroup"/> that is assigned to the <see cref="WhippetTenant"/>. This property is read-only.
        /// </summary>
        public virtual WhippetGroup Group
        { get; protected set; }

        /// <summary>
        /// Indicates whether the group assignment has been deleted.
        /// </summary>
        public virtual bool Deleted
        { get; set; }

        /// <summary>
        /// Indicates whether the group assignment is currently active.
        /// </summary>
        public virtual bool Active
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetGroupTenantAssignment"/> class with no arguments.
        /// </summary>
        public WhippetGroupTenantAssignment()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetGroupTenantAssignment"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetGroupTenantAssignment"/> instance.</param>
        public WhippetGroupTenantAssignment(Guid id)
            : base(id, Instant.FromDateTimeUtc(DateTime.UtcNow), id, Instant.FromDateTimeUtc(DateTime.UtcNow), id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetGroupTenantAssignment"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetGroupTenantAssignment"/> instance.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to assign to the group.</param>
        /// <param name="group"><see cref="IWhippetGroup"/> to assign to the tenant.</param>
        /// <param name="createdDTTM">Date and time the assignment was created or <see langword="null"/> to use the instant the <see cref="WhippetGroupTenantAssignment"/> object was created.</param>
        /// <param name="createdBy">ID of the user who created the <see cref="WhippetGroupTenantAssignment"/> account.</param>
        /// <param name="lastUpdatedDTTM">Date and time the assignment was last updated or <see cref="null"/> to use the instant the <see cref="WhippetGroupTenantAssignment"/> object was created.</param>
        /// <param name="lastUpdatedBy">ID of the user who last updated the <see cref="WhippetGroupTenantAssignment"/> account.</param>
        /// <param name="active">Specifies whether the <see cref="WhippetGroupTenantAssignment"/> association is currently active.</param>
        /// <param name="deleted">Specifies whether the <see cref="WhippetGroupTenantAssignment"/> association is currently deleted.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        public WhippetGroupTenantAssignment(Guid id, IWhippetTenant tenant, IWhippetGroup group, Instant? createdDTTM, Guid? createdBy, Instant? lastUpdatedDTTM, Guid? lastUpdatedBy, bool active, bool deleted)
            : base(id, createdDTTM, createdBy, lastUpdatedDTTM, lastUpdatedBy)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            else
            {
                Tenant = tenant.ToWhippetTenant();
                Group = Group.ToWhippetGroup();
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
            return Equals(obj as WhippetGroupTenantAssignment);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(WhippetGroupTenantAssignment obj)
        {
            bool equals = false;

            if (obj != null)
            {
                equals = Tenant.Equals(obj.Tenant)
                        && Group.Equals(obj.Group)
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
        /// <param name="a">The first object of type <see cref="WhippetGroupTenantAssignment"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="WhippetGroupTenantAssignment"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(WhippetGroupTenantAssignment a, WhippetGroupTenantAssignment b)
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
        public virtual int GetHashCode(WhippetGroupTenantAssignment obj)
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
        /// Gets the name of the tenantname or e-mail of the <see cref="WhippetGroupTenantAssignment"/> object.
        /// </summary>
        /// <returns>String description of the <see cref="WhippetGroupTenantAssignment"/> object.</returns>
        public override string ToString()
        {
            return Group.ToString() + " (" + Tenant.ToString() + ")";
        }
    }
}
