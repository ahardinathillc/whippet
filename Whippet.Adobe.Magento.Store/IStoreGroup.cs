using System;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Categories;

namespace Athi.Whippet.Adobe.Magento.Store
{
    /// <summary>
    /// Provides a logical grouping of related Magento stores.
    /// </summary>
    public interface IStoreGroup: IMagentoEntity, IEqualityComparer<IStoreGroup>, IMagentoRestEntity
    {
        /// <summary>
        /// Gets or sets the <see cref="IStoreWebsite"/> that the group belongs to.
        /// </summary>
        IStoreWebsite Website
        { get; set; }
        
        /// <summary>
        /// Gets or sets the group's root category.
        /// </summary>
        ICategory RootCategory
        { get; set; }

        /// <summary>
        /// Gets or sets the default store ID.
        /// </summary>
        int DefaultStoreID
        { get; set; }

        /// <summary>
        /// Gets or sets the group name.
        /// </summary>
        string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the group code.
        /// </summary>
        string Code
        { get; set; }
    }
}
