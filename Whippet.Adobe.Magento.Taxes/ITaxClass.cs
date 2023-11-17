using System;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Taxes
{
    /// <summary>
    /// Tax classification for customers in Magento.
    /// </summary>
    public interface ITaxClass : IMagentoEntity, IEqualityComparer<ITaxClass>, IMagentoRestEntity, IMagentoRestEntity<TaxClassInterface>
    {
        /// <summary>
        /// Gets or sets the tax class name. 
        /// </summary>
        string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the tax class type.
        /// </summary>
        string Type
        { get; set; }
    }
}
