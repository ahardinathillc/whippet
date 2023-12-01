using System;
using System.Linq;
using Newtonsoft.Json;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.EAV;
using Athi.Whippet.Adobe.Magento.Store;
using Athi.Whippet.Adobe.Magento.Categories;
using Athi.Whippet.Adobe.Magento.SalesRule;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Represents a stock item in Magento.
    /// </summary>
    public class Product : MagentoRestEntity<ProductInterface>, IMagentoEntity, IProduct, IEqualityComparer<IProduct>, IMagentoAuditableEntity, IMagentoCustomAttributesEntity
    {
        /// <summary>
        /// Gets or sets the SKU.
        /// </summary>
        public virtual string SKU
        { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public virtual string Name
        { get; set; }
        
        /// <summary>
        /// Gets or sets the attribute set of the product.
        /// </summary>
        public virtual AttributeSet AttributeSet
        { get; set; }

        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        public virtual decimal Price
        { get; set; }

        /// <summary>
        /// Gets or sets the product status flag.
        /// </summary>
        public virtual int Status
        { get; set; }

        /// <summary>
        /// Gets or sets the visibility option flag.
        /// </summary>
        public virtual int Visibility
        { get; set; }

        /// <summary>
        /// Gets or sets the product type.
        /// </summary>
        public virtual ProductType Type
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the product was created.
        /// </summary>
        public virtual Instant CreatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the product was last updated.
        /// </summary>
        public virtual Instant? UpdatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the product weight.
        /// </summary>
        public virtual decimal Weight
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="StoreWebsite"/> objects associated with the product.
        /// </summary>
        public virtual IEnumerable<StoreWebsite> Websites
        { get; set; }

        /// <summary>
        /// Gets or sets the category links associated with the product.
        /// </summary>
        public virtual IEnumerable<CategoryLink> CategoryLinks
        { get; set; }
        
        /// <summary>
        /// Gets or sets the discounts associated with the product.
        /// </summary>
        public virtual IEnumerable<SalesRuleDiscountData> Discounts
        { get; set; }
        
        public virtual 
    }
}
