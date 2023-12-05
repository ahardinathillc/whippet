using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog.Inventory
{
    /// <summary>
    /// Interface that provides information about a Magento stock.
    /// </summary>
    public class StockInterface : IExtensionInterface, IExtensionAttributes<StockExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the stock ID.
        /// </summary>
        [JsonProperty("stock_id")]
        public int ID
        { get; set; }
        
        /// <summary>
        /// Gets or sets the stock name.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        { get; set; }
        
        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public StockExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="StockInterface"/> class with no arguments.
        /// </summary>
        public StockInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Stock ID.</param>
        /// <param name="name">Stock name.</param>
        /// <param name="attributes">Extension attributes.</param>
        public StockInterface(int id, string name, StockExtensionInterface attributes)
            : this()
        {
            ID = id;
            Name = name;
            ExtensionAttributes = attributes;
        }
    }
}
