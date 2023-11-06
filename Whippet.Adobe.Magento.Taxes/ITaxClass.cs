using System;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Taxes
{
    /// <summary>
    /// Tax classification for customers in Magento.
    /// </summary>
    public interface ITaxClass : IMagentoEntity, IEqualityComparer<ITaxClass>
    {
        /// <summary>
        /// Gets or sets the unique ID of the tax class.
        /// </summary>
        new short ID
        { get; set; }

        /// <summary>
        /// Gets or sets the unique ID of the tax class.
        /// </summary>
        short ClassID
        { get; set; }

        /// <summary>
        /// Gets or sets the name of the tax class.
        /// </summary>
        string ClassName
        { get; set; }

        /// <summary>
        /// Gets or sets the tax class type.
        /// </summary>
        string ClassType
        { get; set; }
    }
}

