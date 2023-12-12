using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using NodaTime;
using Athi.Whippet.Json;
using Athi.Whippet.Data;
using Athi.Whippet.Localization;
using Athi.Whippet.Security.ResourceFiles;
using Athi.Whippet.Security.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Security.Tenants
{
    /// <summary>
    /// Represents a tenant in the Whippet hosting environment. All child <see cref="WhippetTenant"/> instances are hosted by the <see cref="WhippetTenant.Root"/> instance.
    /// </summary>
    public class WhippetTenant : WhippetAuditableEntity, IWhippetEntity, IWhippetAuditableEntity, IWhippetActiveEntity, IWhippetSoftDeleteEntity, IWhippetTenant
    {
        private bool _active;
        private bool _deleted;

        private static IWhippetTenant _root;

        /// <summary>
        /// Gets the root <see cref="IWhippetTenant"/> object which hosts all other tenants in the application. This property is read-only.
        /// </summary>
        public static IWhippetTenant Root
        {
            get
            {
                return (_root != null) ? _root.Clone<IWhippetTenant>() : null;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                else if (RootTenantEstablished)
                {
                    throw new InvalidOperationException(LocalizedStringResourceLoader.GetException<WhippetTenant>(ExceptionResourceIndex.RootTenantAlreadySetException, null, CultureInfo.CurrentCulture));
                }
                else
                {
                    _root = value;
                }
            }
        }

        /// <summary>
        /// Indicates whether the root tenant has been established for this instance. If no root tenant exists, a default one will be created.
        /// </summary>
        public static bool RootTenantEstablished
        { get; private set; }

        /// <summary>
        /// Indicates whether the tenant is the root (host) tenant.
        /// </summary>
        public virtual bool IsRootTenant
        { get; protected internal set; }

        /// <summary>
        /// Name of the tenant.
        /// </summary>
        public virtual string Name
        { get; set; }

        /// <summary>
        /// Tenant URL that points to the location where the tenant can be accessed publically.
        /// </summary>
        public virtual string URL
        { get; set; }

        /// <summary>
        /// Indicates whether the <see cref="WhippetTenant"/> is currently active.
        /// </summary>
        /// <exception cref="InvalidOperationException" />
        public virtual bool Active
        { 
            get
            {
                return _active;
            }
            set
            {
                if(IsRootTenant && !value)
                {
                    throw new InvalidOperationException(LocalizedStringResourceLoader.GetException<WhippetTenant>(ExceptionResourceIndex.RootTenantCannotBeInactiveException));
                }
                else
                {
                    _active = value;
                }
            }
        }

        /// <summary>
        /// Indicates whether the <see cref="WhippetTenant"/> is currently deleted.
        /// </summary>
        public virtual bool Deleted
        { 
            get
            {
                return _deleted;
            }
            set
            {
                if(IsRootTenant && value)
                {
                    throw new InvalidOperationException(LocalizedStringResourceLoader.GetException<WhippetTenant>(ExceptionResourceIndex.RootTenantCannotBeDeletedException));
                }
                else
                {
                    _deleted = value;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetTenant"/> class with no arguments.
        /// </summary>
        public WhippetTenant()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetTenant"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetTenant"/>.</param>
        public WhippetTenant(Guid id)
            : base(id, Instant.FromDateTimeUtc(DateTime.UtcNow), null, Instant.FromDateTimeUtc(DateTime.UtcNow), null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetTenant"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">ID of the tenant.</param>
        /// <param name="name">Name of the tenant.</param>
        /// <param name="url">URL of the tenant.</param>
        /// <param name="createdDTTM">Date/time the instance was created.</param>
        /// <param name="createdBy">Unique ID of the user who created the instance.</param>
        /// <param name="lastUpdatedDTTM">Date/time the instance was last modified.</param>
        /// <param name="lastUpdatedBy">Unique ID of the user who last modified the instance.</param>
        /// <param name="active">Indicates whether the tenant is currently active.</param>
        /// <param name="deleted">Indicates whether the tenant is currently deleted.</param>
        public WhippetTenant(Guid id, string name, string url, Instant? createdDTTM, Guid? createdBy, Instant? lastUpdatedDTTM, Guid? lastUpdatedBy, bool active, bool deleted)
            : this(id, name, url, false, createdDTTM, createdBy, lastUpdatedDTTM, lastUpdatedBy, active, deleted)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetTenant"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">ID of the tenant.</param>
        /// <param name="name">Name of the tenant.</param>
        /// <param name="url">URL of the tenant.</param>
        /// <param name="root">Indicates whether the tenant is the root instance.</param>
        /// <param name="createdDTTM">Date/time the instance was created.</param>
        /// <param name="createdBy">Unique ID of the user who created the instance.</param>
        /// <param name="lastUpdatedDTTM">Date/time the instance was last modified.</param>
        /// <param name="lastUpdatedBy">Unique ID of the user who last modified the instance.</param>
        /// <param name="active">Indicates whether the tenant is currently active.</param>
        /// <param name="deleted">Indicates whether the tenant is currently deleted.</param>
        internal WhippetTenant(Guid id, string name, string url, bool root, Instant? createdDTTM, Guid? createdBy, Instant? lastUpdatedDTTM, Guid? lastUpdatedBy, bool active, bool deleted)
            : base(id, createdDTTM, createdBy, lastUpdatedDTTM, lastUpdatedBy)
        {
            Name = name;
            URL = url;
            Active = active;
            Deleted = deleted;
            IsRootTenant = root;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IWhippetTenant);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetTenant obj)
        {
            bool equals = AuditableEquals(obj);

            if(equals)
            {
                equals = String.Equals(URL, obj.URL) && String.Equals(Name, obj.Name, StringComparison.InvariantCultureIgnoreCase) && (Active == obj.Active) && (Deleted == obj.Deleted);
            }

            return equals;
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="IWhippetTenant"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IWhippetTenant"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetTenant a, IWhippetTenant b)
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
        /// Serves as the default hash function for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="IWhippetTenant"/> object.</param>
        /// <returns>A hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IWhippetTenant obj)
        {
            if(obj == null)
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

            if(!String.IsNullOrWhiteSpace(Name))
            {
                builder.Append(Name);

                if(!String.IsNullOrWhiteSpace(URL))
                {
                    builder.Append(" (" + URL + ")");
                }
            }
            else
            {
                builder.Append("Not Configured");
            }

            return builder.ToString();
        }

        /// <summary>
        /// Sets the <see cref="Root"/> <see cref="IWhippetTenant"/> value.
        /// </summary>
        /// <param name="rootTenantId">Root tenant ID.</param>
        /// <param name="rootTenantName">Root tenant name.</param>
        /// <param name="rootTenantUrl">Root tenant URL.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException"></exception>
        public static void SetRootTenant(Guid rootTenantId, string rootTenantName, string rootTenantUrl)
        {
            if (rootTenantId == Guid.Empty)
            {
                throw new ArgumentException(null, nameof(rootTenantId));
            }
            else if (String.IsNullOrWhiteSpace(rootTenantName))
            {
                throw new ArgumentNullException(nameof(rootTenantName));
            }
            else if (String.IsNullOrWhiteSpace(rootTenantUrl))
            {
                throw new ArgumentNullException(nameof(rootTenantUrl));
            }
            else
            {
                IWhippetUser user = null;
                Root = new WhippetTenant(rootTenantId, rootTenantName, rootTenantUrl, Instant.FromDateTimeUtc(DateTime.UtcNow), user.CreateNonInteractiveSystemUser().ID, null, null, true, false) { IsRootTenant = true };
            }
        }
    }
}
