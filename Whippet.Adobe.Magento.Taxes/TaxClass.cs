using System;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Taxes
{
    /// <summary>
    /// Represents a tax classification in Magento.
    /// </summary>
    public class TaxClass : MagentoRestEntity<TaxClassInterface>, IMagentoEntity, ITaxClass, IEqualityComparer<ITaxClass>, IMagentoRestEntity<TaxClassInterface>, IMagentoRestEntity
    {
        /// <summary>
        /// Gets or sets the tax class name.
        /// </summary>
        public virtual string Name
        { get; set; }
        
        /// <summary>
        /// Gets or sets the tax class type.
        /// </summary>
        public virtual string Type
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxClass"/> class with no arguments.
        /// </summary>
        public TaxClass()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxClass"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public TaxClass(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxClass"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public TaxClass(TaxClassInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is ITaxClass)) ? false : Equals((ITaxClass)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ITaxClass obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ITaxClass x, ITaxClass y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.Name?.Trim(), y.Name?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.Type?.Trim(), y.Type?.Trim(), StringComparison.InvariantCultureIgnoreCase);
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="TaxClassInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="TaxClassInterface"/>.</returns>
        public override TaxClassInterface ToInterface()
        {
            TaxClassInterface taxInterface = new TaxClassInterface();
            taxInterface.ID = ID;
            taxInterface.Name = Name;
            taxInterface.Type = Type;
            
            return taxInterface;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            TaxClass taxClass = new TaxClass();

            taxClass.ID = ID;
            taxClass.Name = Name;
            taxClass.Type = Type;
            taxClass.Server = Server.Clone<MagentoServer>();
            taxClass.RestEndpoint = RestEndpoint.Clone<MagentoRestEndpoint>();

            return taxClass;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(ID);
            hash.Add(Name);
            hash.Add(Type);
            
            return hash.ToHashCode();
        }

        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(TaxClassInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                Name = model.Name;
                Type = model.Type;
            }
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="taxClass"><see cref="ITaxClass"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ITaxClass taxClass)
        {
            ArgumentNullException.ThrowIfNull(taxClass);
            return taxClass.GetHashCode();
        }
        
        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(Name) ? base.ToString() : Name;
        }
    }
}
