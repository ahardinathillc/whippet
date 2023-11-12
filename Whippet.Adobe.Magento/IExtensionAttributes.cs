using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento
{
    /// <summary>
    /// Provides support to <see cref="IExtensionInterface"/> objects who contain extension attributes.
    /// </summary>
    public interface IExtensionAttributes<T> where T : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the extension attributes that are applied to the Magento object.
        /// </summary>
        T ExtensionAttributes
        { get; set; }
    }
}
