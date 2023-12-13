using System;
using Athi.Whippet.Data;
using Athi.Whippet.Json;

namespace Athi.Whippet.Adobe.Magento.Data
{
    /// <summary>
    /// Represents an <see cref="IMagentoEntity"/> that has a REST API implementation.
    /// </summary>
    public interface IMagentoRestEntity : IMagentoEntity, IWhippetEntity
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
    public interface IMagentoRestEntity<TInterface> : IMagentoRestEntity, IMagentoEntity, IWhippetEntity, IExtensionInterfaceMap<TInterface> where TInterface : IExtensionInterface, new()
    { }
}
