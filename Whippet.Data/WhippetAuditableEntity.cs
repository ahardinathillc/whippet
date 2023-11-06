using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Base class for all domain objets in Whippet that have an initial audit record on each data row. This class must be inherited.
    /// </summary>
    public abstract class WhippetAuditableEntity : WhippetEntity, IWhippetAuditableEntity, IWhippetCloneable
    {
        /// <summary>
        /// Gets the <see cref="Instant"/> that the entity was created. This property is read-only.
        /// </summary>
        public virtual Instant CreatedDateTime
        { get; protected set; }

        /// <summary>
        /// Gets or sets the <see cref="Instant"/> that the entity was last modified.
        /// </summary>
        public virtual Instant? LastModifiedDateTime
        { get; set; }

        /// <summary>
        /// Gets the <see cref="Guid"/> of the user who created the entity, if any. This property is read-only.
        /// </summary>
        public virtual Guid? CreatedBy
        { get; protected set; }

        /// <summary>
        /// Gets the <see cref="Guid"/> of the user who last modified the entity, if any. This property is read-only.
        /// </summary>
        public virtual Guid? LastModifiedBy
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetAuditableEntity"/> class with no arguments.
        /// </summary>
        protected WhippetAuditableEntity()
        {
            ID = Guid.Empty;
            CreatedDateTime = Instant.FromDateTimeUtc(DateTime.UtcNow);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetEntity"/> class with the specified <see cref="Guid"/>.
        /// </summary>
        /// <param name="id"><see cref="Guid"/> value that represents the unique identifier of the entity.</param>
        /// <param name="createdDateTime">Date/time the instance was created.</param>
        /// <param name="createdBy">Unique ID of the user who created the instance.</param>
        /// <param name="lastModifiedDateTime">Date/time the instance was last modified.</param>
        /// <param name="lastModifiedBy">Unique ID of the user who last modified the instance.</param>
        protected WhippetAuditableEntity(Guid id, Instant? createdDateTime, Guid? createdBy, Instant? lastModifiedDateTime, Guid? lastModifiedBy)
            : this()
        {
            ID = id;

            if (createdDateTime.HasValue)
            {
                CreatedDateTime = createdDateTime.Value;
            }

            CreatedBy = createdBy;
            LastModifiedDateTime = lastModifiedDateTime;
            LastModifiedBy = lastModifiedBy;
        }

        /// <summary>
        /// Determines if the auditing entries are equal based on the specified values.
        /// </summary>
        /// <param name="auditableEntity"><see cref="IWhippetAuditableEntity"/> object to check.</param>
        /// <returns><see langword="true"/> if the auditable properties are equal; otherwise, <see langword="false"/>.</returns>
        protected virtual bool AuditableEquals(IWhippetAuditableEntity auditableEntity)
        {
            bool equals = false;

            if (auditableEntity != null)
            {
                equals = CreatedDateTime.Equals(auditableEntity.CreatedDateTime);

                if (equals)
                {
                    equals = (!LastModifiedDateTime.HasValue && !auditableEntity.LastModifiedDateTime.HasValue) || 
                                (LastModifiedDateTime.HasValue && auditableEntity.LastModifiedDateTime.HasValue && LastModifiedDateTime.Value.Equals(auditableEntity.LastModifiedDateTime));

                    if (equals)
                    {
                        equals = (!CreatedBy.HasValue && !auditableEntity.CreatedBy.HasValue) || (CreatedBy.HasValue && auditableEntity.CreatedBy.HasValue && CreatedBy.Value.Equals(auditableEntity.CreatedBy.Value));

                        if (equals)
                        {
                            equals = (!LastModifiedDateTime.HasValue && !auditableEntity.LastModifiedDateTime.HasValue) || 
                                        (LastModifiedDateTime.HasValue && auditableEntity.LastModifiedDateTime.HasValue && LastModifiedDateTime.Value.Equals(auditableEntity.LastModifiedDateTime));
                        }
                    }
                }
            }

            return equals;
        }

        /// <summary>
        /// Creates a copy of the current object by invoking <see cref="Clone"/> and then assigning the specified <see cref="Guid"/> value (if present) to <see cref="CreatedBy"/> and updating <see cref="CreatedDateTime"/> on the new object.
        /// </summary>
        /// <typeparam name="TObject">Type of object to return.</typeparam>
        /// <param name="userId">User ID of the user who cloned this instance. The value (if not <see langword="null"/> will be assigned to <see cref="Createdby"/>.</param>
        /// <returns>Cloned instance of type <typeparamref name="TObject"/>.</returns>
        /// <exception cref="InvalidCastException" />
        public virtual TObject Clone<TObject>(Guid? userId = null)
        {
            object clonedObject = Clone();

            if (userId.HasValue)
            {
                ((WhippetAuditableEntity)(clonedObject)).CreatedBy = userId;
                ((WhippetAuditableEntity)(clonedObject)).CreatedDateTime = Instant.FromDateTimeUtc(DateTime.UtcNow);
            }

            return (TObject)(clonedObject);
        }

        /// <summary>
        /// Creates a shallow copy of the current <see cref="object"/>.
        /// </summary>
        /// <returns>Shallow copy of the current <see cref="object"/>.</returns>
        public virtual object Clone()
        {
            return MemberwiseClone();
        }
    }
}
