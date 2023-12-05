using System;
using Newtonsoft.Json;
using Athi.Whippet.Data;
using Athi.Whippet.Json;
using Athi.Whippet.Adobe.Magento;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.ParadoxLabs.Magento.Data
{
    /// <summary>
    /// Base class for all <see cref="MagentoEntity"/> objects that have a corresponding REST API model and are part of the Paradox Labs plug-in. This class must be inherited.
    /// </summary>
    /// <typeparam name="TInterface"><see cref="IParadoxLabsExtensionInterface"/> of the corresponding REST model.</typeparam>
    public abstract class ParadoxLabsMagentoRestEntity<TInterface> : MagentoRestEntity<TInterface>, IWhippetEntity, IMagentoEntity, IJsonObject, IMagentoRestEntity, IMagentoRestEntity<TInterface>, IEqualityComparer<IMagentoRestEntity>, IExtensionInterfaceMap<TInterface>
        where TInterface : IParadoxLabsExtensionInterface, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParadoxLabsMagentoRestEntity{TInterface}"/> class with no arguments.
        /// </summary>
        protected ParadoxLabsMagentoRestEntity()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoRestEntity{TInterface}"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        protected ParadoxLabsMagentoRestEntity(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoRestEntity{TInterface}"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        protected ParadoxLabsMagentoRestEntity(TInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(default(uint), server, restEndpoint)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            else
            {
                ImportFromModel(model);
            }
        }
    }
}
