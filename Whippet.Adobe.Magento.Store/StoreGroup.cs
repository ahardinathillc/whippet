using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Store
{
    /// <summary>
    /// Represents a logical grouping of Magento stores.
    /// </summary>
    public class StoreGroup : MagentoRestEntity<StoreGroupInterface>, IMagentoEntity, IStoreGroup, IEqualityComparer<IStoreGroup>
    {
        /// <summary>
        /// Gets or sets the group's <see cref="StoreWebsite"/> ID.
        /// </summary>
        public int WebsiteID
        { get; set; }
        
        public 
    }
}
