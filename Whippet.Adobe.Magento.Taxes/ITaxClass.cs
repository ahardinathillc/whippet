using System;
using System.Linq;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Taxes
{
    /// <summary>
    /// Represents a tax classification in Magento.
    /// </summary>
    public interface ITaxClass : IMagentoEntity, IEqualityComparer<ITaxClass>, IMagentoRestEntity
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
