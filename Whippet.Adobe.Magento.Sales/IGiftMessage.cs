using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Customer;
using MagentoCustomer = Athi.Whippet.Adobe.Magento.Customer.Customer;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Represents a gift message that is applied to an order in Magento.
    /// </summary>
    public interface IGiftMessage : IMagentoEntity, IEqualityComparer<IGiftMessage>
    {
        /// <summary>
        /// Gets or sets the unique entity ID of the object.
        /// </summary>
        uint GiftMessageID
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICustomer"/> that created the gift message.
        /// </summary>
        ICustomer Customer
        { get; set; }

        /// <summary>
        /// Gets or sets the gift message.
        /// </summary>
        string Message
        { get; set; }

        /// <summary>
        /// Gets or sets the message recipient.
        /// </summary>
        string Recipient
        { get; set; }

        /// <summary>
        /// Gets or sets the message sender.
        /// </summary>
        string Sender
        { get; set; }
    }
}

