using System;
using Athi.Whippet.Adobe.Magento.Catalog.Inventory.Sales;

namespace Athi.Whippet.Adobe.Magento.Catalog.Inventory
{
    /// <summary>
    /// Provides extra information about a Magento stock.
    /// </summary>
    public class StockExtensionInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the sales channels for the stock.
        /// </summary>
        public SalesChannelInterface[] SalesChannels
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="StockExtensionInterface"/> class with no arguments.
        /// </summary>
        public StockExtensionInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockExtensionInterface"/> class with the specified collection of <see cref="SalesChannelInterface"/> objects.
        /// </summary>
        /// <param name="channels"><see cref="SalesChannelInterface"/> objects to initialize with.</param>
        public StockExtensionInterface(IEnumerable<SalesChannelInterface> channels)
            : this()
        {
            SalesChannels = (channels == null) ? null : channels.ToArray();
        }
    }
}
