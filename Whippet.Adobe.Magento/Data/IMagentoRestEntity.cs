using System;
using Athi.Whippet.Data;
using Athi.Whippet.Json;

namespace Athi.Whippet.Adobe.Magento.Data
{
    /// <summary>
    /// Represents an <see cref="IMagentoEntity"/> that has a REST API implementation.
    /// </summary>
    public interface IMagentoRestEntity : IMagentoEntity, IWhippetEntity, IJsonObject
    {
        /// <summary>
        /// Gets or sets the unique ID of the <see cref="IMagentoEntity"/>.
        /// </summary>
        new int ID
        { get; set; }
    }

    /// <summary>
    /// Represents an <see cref="IMagentoEntity"/> that has a REST API implementation.
    /// </summary>
    /// <typeparam name="TInterface"><see cref="IExtensionInterface"/> of the corresponding REST model.</typeparam>
    public interface IMagentoRestEntity<TInterface> : IMagentoRestEntity, IMagentoEntity, IWhippetEntity, IJsonObject where TInterface : IExtensionInterface, new()
    {
        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <typeparamref name="TInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <typeparamref name="TInterface"/>.</returns>
        TInterface ToInterface();
    }
}
