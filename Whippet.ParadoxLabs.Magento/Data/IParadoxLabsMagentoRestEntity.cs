using System;
using Athi.Whippet.Adobe.Magento;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.ParadoxLabs.Magento.Data
{
    /// <summary>
    /// Marker interface for Paradox Lab entities.
    /// </summary>
    public interface IParadoxLabsMagentoRestEntity : IMagentoRestEntity
    { }
    
    /// <summary>
    /// Represents an <see cref="IParadoxLabsMagentoRestEntity"/> that has a REST API implementation.
    /// </summary>
    /// <typeparam name="TInterface"><see cref="IExtensionInterface"/> of the corresponding REST model.</typeparam>
    public interface IParadoxLabsMagentoRestEntity<TInterface> : IParadoxLabsMagentoRestEntity, IMagentoEntity, IExtensionInterfaceMap<TInterface> 
        where TInterface : IParadoxLabsExtensionInterface, new()
    { }
}
