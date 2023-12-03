using System;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Store;

namespace Athi.Whippet.Adobe.Magento.GiftCard
{
    /// <summary>
    /// Represents a Magento gift card amount.
    /// </summary>
    public struct GiftCardAmount : IExtensionInterfaceMap<GiftCardAmountInterface>, IEqualityComparer<GiftCardAmount>
    {
        private StoreWebsite _website;
        
        /// <summary>
        /// Gets or sets the attribute ID.
        /// </summary>
        public int AttributeID
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="StoreWebsite"/> the gift card is registered with.
        /// </summary>
        public StoreWebsite Website
        {
            get
            {
                if (_website == null)
                {
                    _website = new StoreWebsite();
                }

                return _website;
            }
            set
            {
                _website = value;
            }
        }

        /// <summary>
        /// Gets or sets the gift card value.
        /// </summary>
        public decimal Value
        { get; set; }

        /// <summary>
        /// Gets or sets the value as it appears on <see cref="Website"/>.
        /// </summary>
        public decimal WebsiteValue
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardAmount"/> struct with no arguments.
        /// </summary>
        static GiftCardAmount()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardAmount"/> struct with no arguments.
        /// </summary>
        public GiftCardAmount()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardAmount"/> struct with the specified <see cref="GiftCardAmountInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="GiftCardAmountInterface"/> object to initialize with.</param>
        public GiftCardAmount(GiftCardAmountInterface model)
            : this()
        {
            FromModel(model);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardAmount"/> struct with the specified parameters.
        /// </summary>
        /// <param name="attributeId">Attribute ID.</param>
        /// <param name="website">Website the gift card is associated with.</param>
        /// <param name="value">Gift card amount.</param>
        /// <param name="websiteValue">Gift card amount as it appears on <param name="website" />.</param>
        public GiftCardAmount(int attributeId, StoreWebsite website, decimal value, decimal websiteValue)
            : this()
        {
            AttributeID = attributeId;
            Website = website;
            Value = value;
            WebsiteValue = websiteValue;
        }
        
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is GiftCardAmount)) ? false : Equals((GiftCardAmount)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(GiftCardAmount obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(GiftCardAmount x, GiftCardAmount y)
        {
            return x.AttributeID == y.AttributeID
                && (((x.Website == null) && (y.Website == null)) || ((x.Website != null) && (x.Website.Equals(y.Website))))
                && x.Value == y.Value
                && x.WebsiteValue == y.WebsiteValue;
        }
        
        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(AttributeID, Website, Value, WebsiteValue);
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="obj"><see cref="GiftCardAmount"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(GiftCardAmount obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="GiftCardAmountInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="GiftCardAmountInterface"/>.</returns>
        public GiftCardAmountInterface ToInterface()
        {
            return new GiftCardAmountInterface(AttributeID, (Website == null) ? default(int) : Website.ID, Value, WebsiteValue, new GiftCardAmountExtensionInterface());
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="GiftCardAmountInterface"/> object used to populate the object.</param>
        public void FromModel(GiftCardAmountInterface model)
        {
            if (model != null)
            {
                AttributeID = model.AttributeID;
                Website = new StoreWebsite(Convert.ToUInt32(model.WebsiteID));
                WebsiteValue = model.WebsiteValue;
                Value = model.Value;
            }
        }
    }
}
