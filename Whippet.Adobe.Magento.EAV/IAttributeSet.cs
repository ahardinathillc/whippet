using System;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.EAV
{
    /// <summary>
    /// Represents a Magento collection of attributes.
    /// </summary>
    public interface IAttributeSet : IMagentoEntity, IEqualityComparer<IAttributeSet>, IMagentoRestEntity
    {
        /// <summary>
        /// Gets or sets the attribute set name.
        /// </summary>
        string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the sort order index.
        /// </summary>
        int SortOrder
        { get; set; }

        /// <summary>
        /// Gets or sets the entity type ID.
        /// </summary>
        int EntityTypeID
        { get; set; }
    }
}
