using System;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Catalog.Inventory.Sales;

namespace Athi.Whippet.Adobe.Magento.Catalog.Inventory
{
    /// <summary>
    /// Represents a Magento stock.
    /// </summary>
    public interface IStock : IMagentoEntity, IEqualityComparer<IStock>, IMagentoRestEntity
    {
        /// <summary>
        /// Gets or sets the stock name.
        /// </summary>
        string Name
        { get; set; }
        
        /// <summary>
        /// Gets or sets the sales channels for the stock.
        /// </summary>
        IEnumerable<SalesChannel> SalesChannels
        { get; set; }
    }
}
