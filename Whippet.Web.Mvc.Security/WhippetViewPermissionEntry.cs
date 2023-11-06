using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Security;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Web.Mvc.Security
{
    /// <summary>
    /// Represents a permission entry for an <see cref="IWhippetPrincipalObject"/> for a specific <see cref="WhippetViewProfile"/>.
    /// </summary>
    public class WhippetViewPermissionEntry : WhippetAuditableEntity, IWhippetEntity, IWhippetAuditableEntity, IWhippetSoftDeleteEntity, IWhippetViewPermissionEntry, IEqualityComparer<IWhippetViewPermissionEntry>, IWhippetCloneable
    {
        private WhippetTenant _tenant;

        /// <summary>
        /// Gets or sets the <see cref="WhippetTenant"/> that the principal is assigned to.
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
        /// Gets or sets the <see cref="IWhippetTenant"/> that the principal is assigned to.
        /// </summary>
        IWhippetTenant IWhippetViewPermissionEntry.Tenant
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
        /// Gets or sets the <see cref="WhippetMvcSecurityPermission"/> that is stored in the entry.
        /// </summary>
        public virtual WhippetMvcSecurityPermission Permission
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IWhippetPrincipalObject"/> that <see cref="Permission"/> applies to.
        /// </summary>
        public virtual IWhippetPrincipalObject Principal
        { get; set; }

        /// <summary>
        /// Indicates whether the <see cref="WhippetViewPermissionEntry"/> is deleted.
        /// </summary>
        public virtual bool Deleted
        { get; set; }

        /// <summary>
        /// Gets the unique ID of <see cref="Permission"/>. This property is read-only.
        /// </summary>
        public virtual Guid PermissionID
        {
            get
            {
                return (Permission == null) ? Guid.Empty : Permission.ID;
            }
            protected set
            {
                if (Permission != null)
                {
                    Permission = new WhippetMvcSecurityPermission(value, Permission.Type, Permission.Name, Permission.View);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetViewPermissionEntry"/> class with no arguments.
        /// </summary>
        public WhippetViewPermissionEntry()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetViewPermissionEntry"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetViewPermissionEntry"/> instance.</param>
        public WhippetViewPermissionEntry(Guid id)
            : base(id, Instant.FromDateTimeUtc(DateTime.UtcNow), id, Instant.FromDateTimeUtc(DateTime.UtcNow), id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetViewPermissionEntry"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetViewPermissionEntry"/> instance.</param>
        /// <param name="permission"><see cref="WhippetMvcSecurityPermission"/> object.</param>
        /// <param name="principal"><see cref="IWhippetPrincipalObject"/> that <paramref name="permission"/> applies to.</param>
        /// <param name="tenant"><see cref="WhippetTenant"/> object.</param>
        /// <param name="createdDTTM">Date and time the user account was created or <see langword="null"/> to use the instant the <see cref="WhippetViewPermissionEntry"/> object was created.</param>
        /// <param name="createdBy">ID of the user who created the <see cref="WhippetViewPermissionEntry"/> account.</param>
        /// <param name="lastUpdatedDTTM">Date and time the user account was last updated or <see cref="null"/> to use the instant the <see cref="WhippetViewPermissionEntry"/> object was created.</param>
        /// <param name="lastUpdatedBy">ID of the user who last updated the <see cref="WhippetViewPermissionEntry"/> account.</param>
        /// <param name="deleted">Specifies whether the <see cref="WhippetViewPermissionEntry"/> account is currently deleted.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        public WhippetViewPermissionEntry(Guid id, WhippetMvcSecurityPermission permission, IWhippetPrincipalObject principal, WhippetTenant tenant, Instant? createdDTTM, Guid? createdBy, Instant? lastUpdatedDTTM, Guid? lastUpdatedBy, bool deleted)
            : base(id, createdDTTM, createdBy, lastUpdatedDTTM, lastUpdatedBy)
        {
            Permission = permission;
            Principal = principal;
            Tenant = tenant;
            Deleted = deleted;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            WhippetViewPermissionEntry permissionEntry = new WhippetViewPermissionEntry();
            permissionEntry.ID = ID;
            permissionEntry.CreatedBy = CreatedBy;
            permissionEntry.CreatedDateTime = CreatedDateTime;
            permissionEntry.Deleted = Deleted;
            permissionEntry.LastModifiedBy = LastModifiedBy;
            permissionEntry.LastModifiedDateTime = LastModifiedDateTime;
            permissionEntry.Permission = (Permission == null ? null : Permission.Clone<WhippetMvcSecurityPermission>());
            permissionEntry.Principal = (Principal == null ? null : Principal.Clone<IWhippetPrincipalObject>());
            permissionEntry.Tenant = (Tenant == null ? null : Tenant.Clone<WhippetTenant>());

            return permissionEntry;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IWhippetViewPermissionEntry);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetViewPermissionEntry obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="IWhippetViewPermissionEntry"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IWhippetViewPermissionEntry"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetViewPermissionEntry a, IWhippetViewPermissionEntry b)
        {
            bool equals = (a == null) && (b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals = (((a.Tenant == null) && (b.Tenant == null)) || ((a.Tenant != null) && a.Tenant.Equals(b.Tenant)))
                    && (((a.Permission == null) && (b.Permission == null)) || (a.Permission != null && a.Permission.Equals(b.Permission)))
                    && (((a.Principal == null) && (b.Principal == null)) || (a.Principal != null && a.Principal.Equals(b.Principal)));
            }

            return equals;
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
        public virtual int GetHashCode(IWhippetViewPermissionEntry obj)
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
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            if (Principal != null)
            {
                builder.Append("{ " + Principal.ToString() + " } ");
            }

            if (Permission != null)
            {
                builder.Append(Permission.ToString());
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
