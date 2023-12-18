using System;
using NodaTime;
using Athi.Whippet.Data;

namespace Athi.Whippet.SuperDuper.Data
{
    /// <summary>
    /// Base class for all domain objets in Super Duper that have an initial audit record on each data row. This class must be inherited.
    /// </summary>
    public abstract class SuperDuperAuditableEntity : WhippetAuditableEntity, IWhippetAuditableEntity, IWhippetCloneable, ISuperDuperEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuperDuperAuditableEntity"/> class with no arguments.
        /// </summary>
        protected SuperDuperAuditableEntity()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetEntity"/> class with the specified <see cref="Guid"/>.
        /// </summary>
        /// <param name="id"><see cref="Guid"/> value that represents the unique identifier of the entity.</param>
        /// <param name="createdDateTime">Date/time the instance was created.</param>
        /// <param name="createdBy">Unique ID of the user who created the instance.</param>
        /// <param name="lastModifiedDateTime">Date/time the instance was last modified.</param>
        /// <param name="lastModifiedBy">Unique ID of the user who last modified the instance.</param>
        protected SuperDuperAuditableEntity(Guid id, Instant? createdDateTime, Guid? createdBy, Instant? lastModifiedDateTime, Guid? lastModifiedBy)
            : base(id, createdDateTime, createdBy, lastModifiedDateTime, lastModifiedBy)
        { }        
    }
}
