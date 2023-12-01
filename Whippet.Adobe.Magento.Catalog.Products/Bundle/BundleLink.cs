using System;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products.Bundle
{
    /// <summary>
    /// Represents a bundle link for a <see cref="BundleLink"/>. 
    /// </summary>
    public struct BundleLink : IExtensionInterfaceMap<BundleLinkInterface>
    {
        /// <summary>
        /// Gets or sets the bundle link ID.
        /// </summary>
        public string ID
        { get; set; }

        /// <summary>
        /// Gets or sets the product SKU.
        /// </summary>
        public string SKU
        { get; set; }

        /// <summary>
        /// Gets or sets the option ID.
        /// </summary>
        public int OptionID
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public decimal Quantity
        { get; set; }

        /// <summary>
        /// Gets or sets the bundle link position.
        /// </summary>
        public int Position
        { get; set; }

        /// <summary>
        /// Specifies whether the linked product is the default bundle.
        /// </summary>
        public bool IsDefault
        { get; set; }

        /// <summary>
        /// Specifies the price of the bundle.
        /// </summary>
        public decimal Price
        { get; set; }

        /// <summary>
        /// Gets or sets the price type.
        /// </summary>
        public int PriceType
        { get; set; }

        /// <summary>
        /// Specifies whether the quantity can be changed.
        /// </summary>
        public bool CanChangeQuantity
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BundleLink"/> struct with no arguments.
        /// </summary>
        public BundleLink()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BundleLink"/> struct with the specified parameters.
        /// </summary>
        /// <param name="id">Link identifier.</param>
        /// <param name="sku">Product SKU.</param>
        /// <param name="optionId">Option ID.</param>
        /// <param name="quantity">Product quantity.</param>
        /// <param name="position">Bundle position.</param>
        /// <param name="isDefault">Specifies whether the bundle is the default option.</param>
        /// <param name="price">Price of the bundle.</param>
        /// <param name="priceType">Price type.</param>
        /// <param name="canChangeQuantity">Specifies whether the quantity can be changed.</param>
        public BundleLink(string id, string sku, int optionId, decimal quantity, int position, bool isDefault, decimal price, int priceType, bool canChangeQuantity)
            : this()
        {
            ID = id;
            SKU = sku;
            OptionID = optionId;
            Quantity = quantity;
            Position = position;
            IsDefault = isDefault;
            Price = price;
            PriceType = priceType;
            CanChangeQuantity = canChangeQuantity;
        }

        public BundleLink(BundleLinkInterface model)
            : this()
        {
            
        }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is BundleLink)) ? false : Equals((BundleLink)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(BundleLink obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(BundleLink x, BundleLink y)
        {
            return String.Equals(x.ID?.Trim(), y.ID?.Trim())
                   && String.Equals(x.SKU?.Trim(), y.SKU?.Trim())
                   && x.OptionID == y.OptionID
                   && x.Quantity == y.Quantity
                   && x.Position == y.Position
                   && x.IsDefault == y.IsDefault
                   && x.Price == y.Price
                   && x.PriceType == y.PriceType
                   && x.CanChangeQuantity == y.CanChangeQuantity;
        }
        
        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode code = new HashCode();
            code.Add(ID);
            code.Add(SKU);
            code.Add(OptionID);
            code.Add(Quantity);
            code.Add(Position);
            code.Add(IsDefault);
            code.Add(Price);
            code.Add(PriceType);
            code.Add(CanChangeQuantity);

            return code.ToHashCode();
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="obj"><see cref="BundleLink"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(BundleLink obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="BundleLinkInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="BundleLinkInterface"/>.</returns>
        public BundleLinkInterface ToInterface()
        {
            BundleLinkInterface linkInterface = new BundleLinkInterface();

            linkInterface.ID = ID;
            linkInterface.Quantity = Quantity;
            linkInterface.Position = Position;
            linkInterface.IsDefault = IsDefault;
            linkInterface.Price = Price;
            linkInterface.PriceType = PriceType;
            linkInterface.CanChangeQuantity = CanChangeQuantity.ToMagentoBoolean();
            linkInterface.OptionID = OptionID;
            linkInterface.SKU = SKU;

            return linkInterface;
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="BundleLinkInterface"/> object used to populate the object.</param>
        public void FromModel(BundleLinkInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                Quantity = model.Quantity;
                Position = model.Position;
                IsDefault = model.IsDefault;
                Price = model.Price;
                PriceType = model.PriceType;
                CanChangeQuantity = model.CanChangeQuantity.FromMagentoBoolean();
                OptionID = model.OptionID;
                SKU = model.SKU;
            }
        }
    }
}
