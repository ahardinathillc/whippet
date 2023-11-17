using System;
using Newtonsoft.Json;
using Athi.Whippet.Data;
using Athi.Whippet.Json;

namespace Athi.Whippet.Adobe.Magento.Data
{
    /// <summary>
    /// Base class for all <see cref="MagentoEntity"/> objects that have a corresponding REST API model. This class must be inherited.
    /// </summary>
    /// <typeparam name="TInterface"><see cref="IExtensionInterface"/> of the corresponding REST model.</typeparam>
    public abstract class MagentoRestEntity<TInterface> : MagentoEntity, IWhippetEntity, IMagentoEntity, IJsonObject, IMagentoRestEntity, IMagentoRestEntity<TInterface>
        where TInterface : IExtensionInterface, new()
    {
        /// <summary>
        /// Gets or sets the unique ID of the <see cref="MagentoEntity"/>.
        /// </summary>
        public new virtual int ID
        {
            get
            {
                return Convert.ToInt32(base.ID);
            }
            set
            {
                base.ID = Convert.ToUInt32(value);
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoEntity"/> class with no arguments.
        /// </summary>
        protected MagentoRestEntity()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoRestEntity{TInterface}"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        protected MagentoRestEntity(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoRestEntity{TInterface}"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        protected MagentoRestEntity(TInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
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

        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected abstract void ImportFromModel(TInterface model);

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <typeparamref name="TInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <typeparamref name="TInterface"/>.</returns>
        public abstract TInterface ToInterface();

        /// <summary>
        /// Serializes the current object and returns the generated JSON.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON representing the serialized object.</returns>
        public override string ToJson<T>()
        {
            return JsonConvert.SerializeObject(ToInterface(), Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }
    }
}
