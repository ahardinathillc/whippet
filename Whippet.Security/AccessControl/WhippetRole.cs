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

namespace Athi.Whippet.Security.AccessControl
{
    /// <summary>
    /// Represents a role that is assigned to an <see cref="IWhippetUser"/>. Roles are used to restrict access to application functionality and areas.
    /// </summary>
    public class WhippetRole : WhippetAuditableEntity, IWhippetEntity, IWhippetSoftDeleteEntity, IWhippetAuditableEntity, IWhippetActiveEntity, IWhippetRole
    {
        private WhippetTenant _tenant;

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
                return Name;
            }
        }

        /// <summary>
        /// Gets a non-localized categorization of the object type (e.g., "Group", "User", etc.). This property is read-only.
        /// </summary>
        string IWhippetPrincipalObject.PrincipalType
        {
            get
            {
                return WhippetPrincipalObjectCommonTypes.ROLE;
            }
        }

        /// <summary>
        /// Name of the role.
        /// </summary>
        public virtual string Name
        { get; set; }

        /// <summary>
        /// Description of the role (if any).
        /// </summary>
        public virtual string Description
        { get; set; }

        /// <summary>
        /// Indicates whether the role has been deleted.
        /// </summary>
        public virtual bool Deleted
        { get; set; }

        /// <summary>
        /// Indicates whether the role is currently active.
        /// </summary>
        public virtual bool Active
        { get; set; }

        /// <summary>
        /// If <see langword="true"/>, the <see cref="WhippetRole"/> spans across all tenants in the Whippet ecosystem. No two system roles can have the same name or ID.
        /// </summary>
        public virtual bool IsSystem
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="WhippetTenant"/> that the <see cref="WhippetRole"/> is assigned to.
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
        /// Gets or sets the <see cref="IWhippetTenant"/> that the <see cref="IWhippetRole"/> is assigned to.
        /// </summary>
        IWhippetTenant IWhippetRole.Tenant
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
        /// Initializes a new instance of the <see cref="WhippetRole"/> class with no arguments.
        /// </summary>
        public WhippetRole()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRole"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetRole"/> instance.</param>
        public WhippetRole(Guid id)
            : base(id, Instant.FromDateTimeUtc(DateTime.UtcNow), id, Instant.FromDateTimeUtc(DateTime.UtcNow), id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRole"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetRole"/> instance.</param>
        /// <param name="name">Name of the role.</param>
        /// <param name="description">Description of the role (if any).</param>
        /// <param name="isSystem">If <see langword="true"/>, the <see cref="WhippetRole"/> spans across all tenants in the Whippet ecosystem. No two system roles can have the same name or ID.</param>
        /// <param name="tenant"><see cref="WhippetTenant"/> that the role is assigned to.</param>
        /// <param name="createdDTTM">Date and time the user account was created or <see langword="null"/> to use the instant the <see cref="WhippetRole"/> object was created.</param>
        /// <param name="createdBy">ID of the user who created the <see cref="WhippetRole"/> account.</param>
        /// <param name="lastUpdatedDTTM">Date and time the user account was last updated or <see cref="null"/> to use the instant the <see cref="WhippetRole"/> object was created.</param>
        /// <param name="lastUpdatedBy">ID of the user who last updated the <see cref="WhippetRole"/> account.</param>
        /// <param name="active">Specifies whether the <see cref="WhippetRole"/> account is currently active.</param>
        /// <param name="deleted">Specifies whether the <see cref="WhippetRole"/> account is currently deleted.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        public WhippetRole(Guid id, string name, string description, bool isSystem, WhippetTenant tenant, Instant? createdDTTM, Guid? createdBy, Instant? lastUpdatedDTTM, Guid? lastUpdatedBy, bool active, bool deleted)
            : base(id, createdDTTM, createdBy, lastUpdatedDTTM, lastUpdatedBy)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            else
            {
                Name = name;
                Description = description;
                IsSystem = isSystem;
                Active = active;
                Deleted = deleted;
                Tenant = tenant;
            }
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
            return new WhippetRole(Guid.Parse(Convert.ToString(principalId)), name, null, false, WhippetTenant.Root.ToWhippetTenant(), Instant.FromDateTimeUtc(DateTime.UtcNow), null, null, null, true, false);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IWhippetRole);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetRole obj)
        {
            bool equals = false;

            if (obj != null)
            {
                equals =
                    String.Equals(Name, obj.Name, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(Description, obj.Description, StringComparison.InvariantCultureIgnoreCase)
                        && CreatedDateTime.Equals(obj.CreatedDateTime)
                        && LastModifiedDateTime.Equals(obj.LastModifiedDateTime)
                        && CreatedBy.Equals(obj.CreatedBy)
                        && LastModifiedBy.Equals(obj.LastModifiedBy)
                        && Active == obj.Active
                        && Deleted == obj.Deleted
                        && IsSystem == obj.IsSystem
                        && Tenant.Equals(obj.Tenant);
            }

            return equals;
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="WhippetRole"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="WhippetRole"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetRole a, IWhippetRole b)
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
        public virtual int GetHashCode(IWhippetRole obj)
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
        /// Gets the name of the <see cref="WhippetRole"/> object.
        /// </summary>
        /// <returns>String description of the <see cref="WhippetRole"/> object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(Name) ? base.ToString() : Name;
        }
    }
}
