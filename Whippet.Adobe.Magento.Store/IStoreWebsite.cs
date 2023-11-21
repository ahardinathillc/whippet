using System;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Store
{
    /// <summary>
    /// Represents a Magento store's front-facing website.
    /// </summary>
    public interface IStoreWebsite: IMagentoEntity, IEqualityComparer<IStoreWebsite>, IMagentoRestEntity
    {
        /// <summary>
        /// Gets or sets the website code.
        /// </summary>
        string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the website name.
        /// </summary>
        string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the default <see cref="IStoreGroup"/> that the website is associated with.
        /// </summary>
        int DefaultGroupID
        { get; set; }
    }
}
