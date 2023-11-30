using System;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Represents an <see cref="IProduct"/> link between two SKUs.
    /// </summary>
    public struct ProductLink : IExtensionInterfaceMap<ProductLinkInterface>
    {
        /// <summary>
        /// Gets or sets the SKU of the base product.
        /// </summary>
        public string SKU
        { get; set; }
        
        /// <summary>
        /// Gets or sets the link type.
        /// </summary>
        public ProductLinkType LinkType
        { get; set; }
        
        /// <summary>
        /// Gets or sets the linked product SKU.
        /// </summary>
        public string LinkedSKU
        { get; set; }
        
        /// <summary>
        /// Gets or sets the linked product type.
        /// </summary>
        public ProductType ProductType
        { get; set; }
        
        /// <summary>
        /// Gets or sets the linked item position.
        /// </summary>
        public int Position
        { get; set; }
        
        /// <summary>
        /// Gets or sets the linked product quantity.
        /// </summary>
        public decimal Quantity
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductLink"/> struct with no arguments.
        /// </summary>
        static ProductLink()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductLink"/> struct with no arguments.
        /// </summary>
        public ProductLink()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductLink"/> struct with the specified parameters.
        /// </summary>
        /// <param name="sku">Base product SKU.</param>
        /// <param name="type">Link type.</param>
        /// <param name="linkedSku">Linked product SKU.</param>
        /// <param name="linkedProductType">Linked product type.</param>
        /// <param name="position">Linked item position.</param>
        /// <param name="quantity">Linked product quantity.</param>
        public ProductLink(string sku, ProductLinkType type, string linkedSku, ProductType linkedProductType, int position, decimal quantity)
            : this()
        {
            SKU = sku;
            LinkType = type;
            LinkedSKU = linkedSku;
            ProductType = linkedProductType;
            Position = position;
            Quantity = quantity;
        }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is ProductLink)) ? false : Equals((ProductLink)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ProductLink obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ProductLink x, ProductLink y)
        {
            return String.Equals(x.SKU?.Trim(), y.SKU?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && String.Equals(x.LinkedSKU?.Trim(), y.LinkedSKU?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && x.LinkType.Equals(y.LinkType)
                   && x.ProductType.Equals(y.ProductType)
                   && x.Position == y.Position
                   && x.Quantity == y.Quantity;
        }
        
        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(SKU, LinkedSKU, LinkType, ProductType, Position, Quantity);
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="obj"><see cref="ProductLink"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(ProductLink obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="ProductLinkInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="ProductLinkInterface"/>.</returns>
        public ProductLinkInterface ToInterface()
        {
            return new ProductLinkInterface()
            {
                SKU = SKU,
                LinkType = LinkType.Code,
                LinkedProductSKU = LinkedSKU,
                LinkedProductType = ProductType.Name,
                Position = Position,
                ExtensionAttributes = new ProductLinkExtensionInterface(Quantity)
            };
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="ProductLinkInterface"/> object used to populate the object.</param>
        public void FromModel(ProductLinkInterface model)
        {
            if (model != null)
            {
                SKU = model.SKU;
                LinkType = new ProductLinkType(model.LinkType, null);
                LinkedSKU = model.LinkedProductSKU;
                ProductType = new ProductType(model.LinkedProductType, null);
                Position = model.Position;
                Quantity = (model.ExtensionAttributes != null) ? model.ExtensionAttributes.Quantity : default(decimal);
            }
        }
        
        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(SKU) || String.IsNullOrWhiteSpace(LinkedSKU) ? base.ToString() : SKU + "::" + LinkedSKU;
        }
        
    }
}
