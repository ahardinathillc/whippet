using System;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Catalog.Products.Bundle;
using Athi.Whippet.Adobe.Magento.Catalog.Products.Configurable;
using Athi.Whippet.Adobe.Magento.GiftCard;
using Athi.Whippet.Adobe.Magento.Downloads;

namespace Athi.Whippet.Adobe.Magento.Catalog.Inventory.Sales
{
    /// <summary>
    /// Provides information about a sales channel (venue from which products can be seen and purchased) in Magento.
    /// </summary>
    public struct SalesChannel : IEqualityComparer<SalesChannel>, IExtensionInterfaceMap<SalesChannelInterface>
    {
        /// <summary>
        /// Gets or sets the sales channel type.
        /// </summary>
        public string Type
        { get; set; }
        
        /// <summary>
        /// Gets or sets the sales channel code.
        /// </summary>
        public string Code
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesChannel"/> class with no arguments.
        /// </summary>
        static SalesChannel()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesChannel"/> class with no arguments.
        /// </summary>
        public SalesChannel()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesChannel"/> class with the specified <see cref="SalesChannelInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="SalesChannelInterface"/> object.</param>
        public SalesChannel(SalesChannelInterface model)
            : this()
        {
            FromModel(model);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesChannel"/> class with the specified parameters.
        /// </summary>
        /// <param name="type">Sales channel type.</param>
        /// <param name="code">Sales channel code.</param>
        public SalesChannel(string type, string code)
            : this()
        {
            Type = type;
            Code = code;
        }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is SalesChannel)) ? false : Equals((SalesChannel)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(SalesChannel obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(SalesChannel x, SalesChannel y)
        {
            return String.Equals(x.Type?.Trim(), y.Type?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && String.Equals(x.Code?.Trim(), y.Code?.Trim(), StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="SalesChannelInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="SalesChannelInterface"/>.</returns>
        public SalesChannelInterface ToInterface()
        {
            SalesChannelInterface scInterface = new SalesChannelInterface();
            scInterface.Type = Type;
            scInterface.Code = Code;

            return scInterface;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Type, Code);
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="channel"><see cref="SalesChannel"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(SalesChannel channel)
        {
            ArgumentNullException.ThrowIfNull(channel);
            return channel.GetHashCode();
        }

        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        public void FromModel(SalesChannelInterface model)
        {
            if (model != null)
            {
                Type = model.Type;
                Code = model.Code;
            }
        }
    }
}
