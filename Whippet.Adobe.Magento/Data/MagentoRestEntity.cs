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
    public abstract class MagentoRestEntity<TInterface> : MagentoEntity, IWhippetEntity, IMagentoEntity, IMagentoRestEntity, IMagentoRestEntity<TInterface>, IEqualityComparer<IMagentoRestEntity>, IExtensionInterfaceMap<TInterface>
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
        /// Initializes a new instance of the <see cref="MagentoRestEntity{TInterface}"/> class with no arguments.
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
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return (obj == null) || !(obj is IMagentoRestEntity) ? false : Equals((IMagentoRestEntity)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMagentoRestEntity obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }
        
        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMagentoRestEntity x, IMagentoRestEntity y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = (((x.Server == null) && (y.Server == null)) || ((x.Server != null) && x.Server.Equals(y.Server)))
                         && (((x.RestEndpoint == null) && (y.RestEndpoint == null)) || ((x.RestEndpoint != null) && x.RestEndpoint.Equals(y.RestEndpoint)));
            }

            return equals;
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><typeparamref name="TInterface"/> object used to populate the object.</param>
        void IExtensionInterfaceMap<TInterface>.FromModel(TInterface model)
        {
            ImportFromModel(model);
        }

        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object. This method must be overridden.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected abstract void ImportFromModel(TInterface model);

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <typeparamref name="TInterface"/>. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <typeparamref name="TInterface"/>.</returns>
        public abstract TInterface ToInterface();

        /// <summary>
        /// Gets the hash code for the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Server, RestEndpoint, ID);
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        public virtual int GetHashCode(IMagentoRestEntity obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            return obj.GetHashCode();
        }
    }
}
