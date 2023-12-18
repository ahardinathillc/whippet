using System;
using NodaTime;
using Athi.Whippet.Data;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Data
{
    /// <summary>
    /// Base class for all domain objects in Freestyle Solutions Multichannel Order Manager that are auditable. This class must be inherited.
    /// </summary>
    public abstract class MultichannelOrderManagerAuditableEntity : MultichannelOrderManagerEntity, IWhippetEntity, IMultichannelOrderManagerEntity, IMultichannelOrderManagerAuditableEntity
    {
        /// <summary>
        /// Gets or sets the date and time the entity was last accessed.
        /// </summary>
        public virtual Instant? LastAccessed
        { get; set; }
        
        /// <summary>
        /// Gets or sets the three character username who accessed the entity.
        /// </summary>
        public virtual string LastAccessedBy
        { get; set; }
        
        /// <summary>
        /// Gets or sets the date and time the entity was last modified. Note that some entities do not support this field and may be left <see langword="null"/>.
        /// </summary>
        public virtual Instant? LastModified
        { get; set; }
        
        /// <summary>
        /// Gets or sets the three character username who modified the entity. Note that some entities do not support this field and may be left <see langword="null"/>.
        /// </summary>
        public virtual string LastModifiedBy
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerAuditableEntity"/> class with no arguments.
        /// </summary>
        protected MultichannelOrderManagerAuditableEntity()
            : this(null, null, null, null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerAuditableEntity"/> class with the specified ID.
        /// </summary>
        /// <param name="id">Unique identifier of the entity.</param>
        /// <param name="lastAccessed">Date and time the entity was last accessed.</param>
        /// <param name="lastAccessedBy">Username who last accessed the entity.</param>
        protected MultichannelOrderManagerAuditableEntity(IMultichannelOrderManagerEntityKey id, Instant? lastAccessed = null, string lastAccessedBy = null)
            : this(id, lastAccessed, lastAccessedBy, null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerAuditableEntity"/> class with the specified ID.
        /// </summary>
        /// <param name="id">Unique identifier of the entity.</param>
        /// <param name="lastAccessed">Date and time the entity was last accessed.</param>
        /// <param name="lastAccessedBy">Username who last accessed the entity.</param>
        /// <param name="lastModified">Date and time the entity was last modified.</param>
        /// <param name="lastModifiedBy">Username who last modified the entity.</param>
        protected MultichannelOrderManagerAuditableEntity(IMultichannelOrderManagerEntityKey id, Instant? lastAccessed, string lastAccessedBy, Instant? lastModified, string lastModifiedBy)
            : base(id)
        {
            LastAccessed = lastAccessed;
            LastAccessedBy = lastAccessedBy;
            LastModified = lastModified;
            LastModifiedBy = lastModifiedBy;
        }
        
        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(ID, LastAccessed, LastAccessedBy, LastModified, LastModifiedBy);
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IMultichannelOrderManagerAuditableEntity obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            return obj.GetHashCode();
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return (obj == null) || !(obj is IMultichannelOrderManagerAuditableEntity) ? false : Equals((IMultichannelOrderManagerAuditableEntity)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerAuditableEntity obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }
        
        /// <summary>
        /// Compares the two specified objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerAuditableEntity x, IMultichannelOrderManagerAuditableEntity y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.LastAccessedBy?.Trim(), y.LastAccessedBy?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.LastModifiedBy?.Trim(), y.LastAccessedBy?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.LastAccessed.GetValueOrDefault().Equals(y.LastAccessed.GetValueOrDefault())
                         && x.LastModified.GetValueOrDefault().Equals(y.LastModified.GetValueOrDefault());
            }

            return equals;
        }
    }
}
