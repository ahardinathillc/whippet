using System;
using NodaTime;

namespace Athi.Whippet.Adobe.Magento.Data
{
    /// <summary>
    /// Provides additional support concerning the creation date and time as well as last updated date and time for an <see cref="IMagentoEntity"/>.
    /// </summary>
    public interface IMagentoAuditableEntity : IMagentoEntity
    {
        /// <summary>
        /// Gets or sets the date and time the entity was created.
        /// </summary>
        Instant CreatedTimestamp
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the entity was last updated (if any).
        /// </summary>
        Instant? UpdatedTimestamp
        { get; set; }
    }
}
