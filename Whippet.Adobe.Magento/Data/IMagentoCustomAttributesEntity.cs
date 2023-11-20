using System;
using System.Collections.Generic;

namespace Athi.Whippet.Adobe.Magento.Data
{
    /// <summary>
    /// Represents an <see cref="IMagentoEntity"/> that supports custom attributes in Magento. 
    /// </summary>
    public interface IMagentoCustomAttributesEntity : IMagentoEntity
    {
        /// <summary>
        /// Gets the entity's <see cref="MagentoCustomAttributeCollection"/> that contains all <see cref="MagentoCustomAttribute"/> entries. This property is read-only.
        /// </summary>
        MagentoCustomAttributeCollection CustomAttributes
        { get; }
    }
}
