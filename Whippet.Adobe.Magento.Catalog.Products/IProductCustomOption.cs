using System;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Represents an <see cref="IProduct"/> configuration or customization option that can be applied.
    /// </summary>
    public interface IProductCustomOption : IMagentoEntity, IEqualityComparer<IProductCustomOption>, IMagentoRestEntity<ProductCustomOptionInterface>, IMagentoRestEntity
    {
        /// <summary>
        /// Gets or sets the product SKU that the option applies to.
        /// </summary>
        string ProductSKU
        { get; set; }
        
        /// <summary>
        /// Gets or sets the option title.
        /// </summary>
        string Title
        { get; set; }
        
        /// <summary>
        /// Gets or sets the custom option type.
        /// </summary>
        ProductCustomOptionType Type
        { get; set; }

        /// <summary>
        /// Gets or sets the sort order of the option.
        /// </summary>
        int SortOrder
        { get; set; }

        /// <summary>
        /// Specifies whether the option is required.
        /// </summary>
        bool Required
        { get; set; }

        /// <summary>
        /// Gets or sets the option SKU.
        /// </summary>
        string SKU
        { get; set; }

        /// <summary>
        /// Gets or sets the option price.
        /// </summary>
        decimal Price
        { get; set; }

        /// <summary>
        /// Gets or sets the option price type.
        /// </summary>
        string PriceType
        { get; set; }

        /// <summary>
        /// Gets or sets the option image file name.
        /// </summary>
        string FileExtension
        { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of characters that the file name can be.
        /// </summary>
        int MaxCharacters
        { get; set; }

        /// <summary>
        /// Gets or sets the horizontal image size (in pixels).
        /// </summary>
        int ImageWidth
        { get; set; }

        /// <summary>
        /// Gets or sets the vertical image size (in pixels).
        /// </summary>
        int ImageHeight
        { get; set; }

        /// <summary>
        /// Gets or sets the custom option values. 
        /// </summary>
        IEnumerable<ProductCustomOptionValue> Values
        { get; set; }        
    }
}
