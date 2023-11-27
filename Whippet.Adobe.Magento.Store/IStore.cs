using System;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Store
{
    /// <summary>
    /// Represents a Magento store.
    /// </summary>
    public interface IStore : IMagentoEntity, IEqualityComparer<IStore>, IMagentoRestEntity, IWhippetActiveEntity
    {
        /// <summary>
        /// Gets or sets the store code.
        /// </summary>
        string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the store name.
        /// </summary>
        string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IStore"/> website.
        /// </summary>
        IStoreWebsite Website
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IStore"/> group.
        /// </summary>
        IStoreGroup Group
        { get; set; }
    }
}
