using System;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Store;

namespace Athi.Whippet.Adobe.Magento.Taxes
{
    /// <summary>
    /// Represents a tax rate title in Magento.
    /// </summary>
    public interface ITaxRateTitle : IMagentoEntity, IEqualityComparer<ITaxRateTitle>, IMagentoRestEntity
    {
        /// <summary>
        /// Gets or sets the <see cref="IStore"/> that the title applies to.
        /// </summary>
        IStore Store
        { get; set; }

        /// <summary>
        /// Gets or sets the title value.
        /// </summary>
        string Value
        { get; set; }
    }
}
