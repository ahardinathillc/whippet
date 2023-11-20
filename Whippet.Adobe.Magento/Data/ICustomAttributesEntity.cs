using System;
using System.Collections.Generic;

namespace Athi.Whippet.Adobe.Magento.Data
{
    /// <summary>
    /// Represents an <see cref="IMagentoEntity"/> that supports custom attributes in Magento. 
    /// </summary>
    public interface ICustomAttributesEntity : IMagentoEntity
    {
        IDictionary<string, string>
    }
}
