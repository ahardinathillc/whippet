using System;
using Newtonsoft.Json;
using Athi.Whippet.Json;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Taxes
{
    /// <summary>
    /// Tax classification for customers in Magento.
    /// </summary>
    public class TaxClass : MagentoRestEntity<TaxClassInterface>, IMagentoEntity, ITaxClass, IEqualityComparer<ITaxClass>, IMagentoRestEntity, IMagentoRestEntity<TaxClassInterface>
    {
        /// <summary>
        /// Gets or sets the tax class name. 
        /// </summary>
        public string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the tax class type.
        /// </summary>
        public string Type
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxClass"/> class with no arguments.
        /// </summary>
        protected TaxClass()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxClass"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="TaxClass"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        protected TaxClass(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxClass"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        protected TaxClass(TaxClassInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return (obj == null || !(obj is ITaxClass)) ? false : Equals((ITaxClass)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ITaxClass obj)
        {
            return Equals(this, obj);
        }
        
        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ITaxClass x, ITaxClass y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.Name?.Trim(), y.Name?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Type?.Trim(), y.Type?.Trim(), StringComparison.InvariantCultureIgnoreCase);
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            int hashCode = ID.GetHashCode();

            if (!String.IsNullOrWhiteSpace(Name))
            {
                hashCode = hashCode & Name.GetHashCode();
            }

            if (!String.IsNullOrWhiteSpace(Type))
            {
                hashCode = hashCode & Type.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        public int GetHashCode(ITaxClass obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            return obj.GetHashCode();
        }
        
        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(TaxClassInterface model)
        {
            ArgumentNullException.ThrowIfNull(model);

            ID = model.ID;
            Name = model.Name;
            Type = model.Type;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="TaxClassInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="TaxClassInterface"/>.</returns>
        public override TaxClassInterface ToInterface()
        {
            return new TaxClassInterface(ID, Name, Type, new TaxClassExtensionInterface());
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.Format("[Class Name: {0} | Class Type: {1}]", Name, Type);
        }
    }
}
