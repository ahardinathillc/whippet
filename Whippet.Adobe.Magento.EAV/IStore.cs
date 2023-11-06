using System;
using System.ComponentModel;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.EAV
{
    /// <summary>
    /// Represents an individual store in Magento.
    /// </summary>
    public interface IStore : IMagentoEntity, IEqualityComparer<IStore>, ICloneable, IWhippetCloneable
    {
        /// <summary>
        /// Gets or sets the unique store ID.
        /// </summary>
        ushort StoreID
        { get; set; }

        /// <summary>
        /// Gets or sets the store code that identifies it in Magento.
        /// </summary>
        string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the website associated with the store.
        /// </summary>
        IStoreWebsite Website
        { get; set; }

        /// <summary>
        /// Gets or sets the group the store belongs to.
        /// </summary>
        IStoreGroup Group
        { get; set; }

        /// <summary>
        /// Gets or sets the store name.
        /// </summary>
        string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the store sort order.
        /// </summary>
        ushort SortOrder
        { get; set; }
    }
}
