using System;
using NodaTime;
using Athi.Whippet.Data;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Data
{
    /// <summary>
    /// Base class for all domain objects in Freestyle Solutions Multichannel Order Manager that are auditable. This class must be inherited.
    /// </summary>
    public abstract class MultichannelOrderManagerAuditableEntity : MultichannelOrderManagerEntity, IWhippetEntity, IMultichannelOrderManagerEntity
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
    }
}
