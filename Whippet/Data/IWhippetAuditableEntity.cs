using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Represents a Whippet domain object that has an initial audit record on each data row.
    /// </summary>
    public interface IWhippetAuditableEntity : IWhippetEntity, IWhippetCloneable
    {
        /// <summary>
        /// Gets the <see cref="Instant"/> that the entity was created. This property is read-only.
        /// </summary>
        Instant CreatedDateTime
        { get; }

        /// <summary>
        /// Gets or sets the <see cref="Instant"/> that the entity was last modified.
        /// </summary>
        Instant? LastModifiedDateTime
        { get; set; }

        /// <summary>
        /// Gets the <see cref="Guid"/> of the user who created the entity, if any. This property is read-only.
        /// </summary>
        Guid? CreatedBy
        { get; }

        /// <summary>
        /// Gets the <see cref="Guid"/> of the user who last modified the entity, if any.
        /// </summary>
        Guid? LastModifiedBy
        { get; set; }
    }
}
