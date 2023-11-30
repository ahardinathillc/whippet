using System;
using System.Linq;
using Newtonsoft.Json;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Extensions;

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
        
        public virtual int Att
    }
}
