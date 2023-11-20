using System;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Store
{
    /// <summary>
    /// Represents a Magento store.
    /// </summary>
    public class Store : MagentoRestEntity<StoreInterface>, IMagentoEntity, IStore, IEqualityComparer<IStore>
    {
        
    }
}
