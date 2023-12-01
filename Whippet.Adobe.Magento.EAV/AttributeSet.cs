using System;
using Athi.Whippet.Adobe.Magento.Catalog.Products;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.EAV
{
    /// <summary>
    /// Represents a Magento collection of attributes.
    /// </summary>
    public class AttributeSet : MagentoRestEntity<AttributeSetInterface>, IMagentoEntity, IAttributeSet, IEqualityComparer<IAttributeSet>
    {
        /// <summary>
        /// Gets or sets the attribute set name.
        /// </summary>
        public virtual string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the sort order index.
        /// </summary>
        public virtual int SortOrder
        { get; set; }

        /// <summary>
        /// Gets or sets the entity type ID.
        /// </summary>
        public virtual int EntityTypeID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeSet"/> class with no arguments.
        /// </summary>
        public AttributeSet()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeSet"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public AttributeSet(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeSet"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public AttributeSet(AttributeSetInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is IAttributeSet)) ? false : Equals((IAttributeSet)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IAttributeSet obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IAttributeSet x, IAttributeSet y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = x.SortOrder == y.SortOrder
                         && x.EntityTypeID == y.EntityTypeID
                         && String.Equals(x.Name?.Trim(), y.Name?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && (((x.Server == null) && (y.Server == null)) || ((x.Server != null) && x.Server.Equals(y.Server)))
                         && (((x.RestEndpoint == null) && (y.RestEndpoint == null)) || ((x.RestEndpoint != null) && x.RestEndpoint.Equals(y.RestEndpoint)));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="AttributeSetInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="AttributeSetInterface"/>.</returns>
        public override AttributeSetInterface ToInterface()
        {
            AttributeSetInterface attribInterface = new AttributeSetInterface();
            attribInterface.ID = ID;
            attribInterface.Name = Name;
            attribInterface.SortOrder = SortOrder;
            attribInterface.EntityTypeID = EntityTypeID;
            attribInterface.ExtensionAttributes = new AttributeSetExtensionInterface();
            
            return attribInterface;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            AttributeSet attribute = new AttributeSet();

            attribute.ID = ID;
            attribute.Name = Name;
            attribute.SortOrder = SortOrder;
            attribute.EntityTypeID = EntityTypeID;
            attribute.Server = (Server == null) ? null : Server.Clone<MagentoServer>();
            attribute.RestEndpoint = (RestEndpoint == null) ? null : RestEndpoint.Clone<MagentoRestEndpoint>();

            return attribute;
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
            hash.Add(SortOrder);
            hash.Add(EntityTypeID);
            
            return hash.ToHashCode();
        }

        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(AttributeSetInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                Name = model.Name;
                SortOrder = model.SortOrder;
                EntityTypeID = model.EntityTypeID;
            }
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="attribute"><see cref="IAttributeSet"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IAttributeSet attribute)
        {
            ArgumentNullException.ThrowIfNull(attribute);
            return attribute.GetHashCode();
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
