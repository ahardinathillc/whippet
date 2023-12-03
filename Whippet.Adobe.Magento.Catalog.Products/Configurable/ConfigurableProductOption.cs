using System;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products.Configurable
{
    /// <summary>
    /// Represents a configurable option that can be applied to a Magento product. 
    /// </summary>
    public class ConfigurableProductOption : MagentoRestEntity<ConfigurableProductOptionInterface>, IMagentoEntity, IConfigurableProductOption, IEqualityComparer<IConfigurableProductOption>, IMagentoRestEntity<ConfigurableProductOptionInterface>
    {
        /// <summary>
        /// Gets or sets the attribute ID.
        /// </summary>
        public virtual string AttributeID
        { get; set; }

        /// <summary>
        /// Gets or sets the option label.
        /// </summary>
        public virtual string Label
        { get; set; }

        /// <summary>
        /// Gets or sets the position of the option.
        /// </summary>
        public virtual int Position
        { get; set; }

        /// <summary>
        /// Specifies whether the option should use the default value.
        /// </summary>
        public virtual bool UseDefault
        { get; set; }

        /// <summary>
        /// Gets or sets the product options.
        /// </summary>
        public virtual IEnumerable<ConfigurableProductOptionValue> Values
        { get; set; }
        
        /// <summary>
        /// Gets or sets the product ID.
        /// </summary>
        public virtual int ProductID
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurableProductOption"/> class with no arguments.
        /// </summary>
        public ConfigurableProductOption()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurableProductOption"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public ConfigurableProductOption(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurableProductOption"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public ConfigurableProductOption(ConfigurableProductOptionInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is IConfigurableProductOption)) ? false : Equals((IConfigurableProductOption)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IConfigurableProductOption obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IConfigurableProductOption x, IConfigurableProductOption y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = x.ID == y.ID
                    && String.Equals(x.AttributeID?.Trim(), y.AttributeID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Label?.Trim(), y.Label?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && x.Position == y.Position
                    && x.UseDefault == y.UseDefault
                    && (((x.Values == null) && (y.Values == null)) || ((x.Values != null) && x.Values.SequenceEqual(y.Values)))
                    && x.ProductID == y.ProductID
                    && (((x.RestEndpoint == null) && (y.RestEndpoint == null)) || ((x.RestEndpoint != null) && x.RestEndpoint.Equals(y.RestEndpoint)))
                    && (((x.Server == null) && (y.Server == null)) || ((x.Server != null) && x.Server.Equals(y.Server)));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="ConfigurableProductOptionInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="ConfigurableProductOptionInterface"/>.</returns>
        public override ConfigurableProductOptionInterface ToInterface()
        {
            ConfigurableProductOptionInterface optionInterface = new ConfigurableProductOptionInterface();

            optionInterface.ID = ID;
            optionInterface.AttributeID = AttributeID;
            optionInterface.Label = Label;
            optionInterface.Position = Position;
            optionInterface.UseDefault = UseDefault;
            optionInterface.Values = (Values == null) ? null : Values.Select(v => v.ToInterface()).ToArray();
            optionInterface.ProductID = ProductID;
            optionInterface.ExtensionAttributes = new ConfigurableProductOptionExtensionInterface();

            return optionInterface;
        }

        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(ConfigurableProductOptionInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                AttributeID = model.AttributeID;
                Label = model.Label;
                Position = model.Position;
                UseDefault = model.UseDefault;
                Values = (model.Values == null) ? null : model.Values.Select(v => new ConfigurableProductOptionValue(v));
                ProductID = model.ProductID;
            }
        }
        
        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            ConfigurableProductOption option = new ConfigurableProductOption();

            option.ID = ID;
            option.AttributeID = AttributeID;
            option.Label = Label;
            option.Position = Position;
            option.UseDefault = UseDefault;
            option.Values = (Values == null) ? null : Values.Select(v => v);
            option.ProductID = ProductID;
            option.Server = (Server == null) ? null : Server.Clone<MagentoServer>();
            option.RestEndpoint = (RestEndpoint == null) ? null : RestEndpoint.Clone<MagentoRestEndpoint>();

            return option;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(ID);
            hash.Add(AttributeID);
            hash.Add(Label);
            hash.Add(Position);
            hash.Add(UseDefault);
            hash.Add(Values);
            hash.Add(ProductID);
            hash.Add(Server);
            hash.Add(RestEndpoint);
            
            return hash.ToHashCode();
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="obj"><see cref="IConfigurableProductOption"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IConfigurableProductOption obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            return obj.GetHashCode();
        }
        
        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.Format("[Label: {0} | Product ID: {1}]", Label, ProductID);
        }
        
    }
}
