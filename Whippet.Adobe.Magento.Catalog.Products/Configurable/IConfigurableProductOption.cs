using System;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products.Configurable
{
    /// <summary>
    /// Represents a configurable option that can be applied to a Magento product. 
    /// </summary>
    public interface IConfigurableProductOption : IMagentoEntity, IEqualityComparer<IConfigurableProductOption>, IMagentoRestEntity
    {
        /// <summary>
        /// Gets or sets the attribute ID.
        /// </summary>
        string AttributeID
        { get; set; }

        /// <summary>
        /// Gets or sets the option label.
        /// </summary>
        string Label
        { get; set; }

        /// <summary>
        /// Gets or sets the position of the option.
        /// </summary>
        int Position
        { get; set; }

        /// <summary>
        /// Specifies whether the option should use the default value.
        /// </summary>
        bool UseDefault
        { get; set; }

        /// <summary>
        /// Gets or sets the product options.
        /// </summary>
        IEnumerable<ConfigurableProductOptionValue> Values
        { get; set; }
        
        /// <summary>
        /// Gets or sets the product ID.
        /// </summary>
        int ProductID
        { get; set; }
   }
}
