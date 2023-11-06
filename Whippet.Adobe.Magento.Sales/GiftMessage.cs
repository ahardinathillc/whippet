using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Customer;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;
using MagentoCustomer = Athi.Whippet.Adobe.Magento.Customer.Customer;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Represents a gift message that is applied to an order in Magento.
    /// </summary>
    public class GiftMessage : MagentoEntity, IMagentoEntity, IGiftMessage, IEqualityComparer<IGiftMessage>
    {
        private MagentoCustomer _customer;

        /// <summary>
        /// Gets or sets the unique entity ID of the object.
        /// </summary>
        public virtual uint GiftMessageID
        {
            get
            {
                return base.ID;
            }
            set
            {
                base.ID = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Magento.Customer.Customer"/> that created the gift message.
        /// </summary>
        public virtual MagentoCustomer Customer
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new MagentoCustomer();
                }

                return _customer;
            }
            set
            {
                _customer = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="ICustomer"/> that created the gift message.
        /// </summary>
        ICustomer IGiftMessage.Customer
        {
            get
            {
                return Customer;
            }
            set
            {
                Customer = value.ToCustomer();
            }
        }

        /// <summary>
        /// Gets or sets the gift message.
        /// </summary>
        public virtual string Message
        { get; set; }

        /// <summary>
        /// Gets or sets the message recipient.
        /// </summary>
        public virtual string Recipient
        { get; set; }

        /// <summary>
        /// Gets or sets the message sender.
        /// </summary>
        public virtual string Sender
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GiftMessage"/> class with no arguments.
        /// </summary>
        public GiftMessage()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GiftMessage"/> class with the specified message ID and <see cref="MagentoServer"/>.
        /// </summary>
        /// <param name="messageId">Gift message ID.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        public GiftMessage(uint messageId, MagentoServer server)
            : base(messageId, server)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return (obj == null || !(obj is IGiftMessage)) ? false : Equals(obj as IGiftMessage);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IGiftMessage obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IGiftMessage x, IGiftMessage y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = ((x.Customer == null && y.Customer == null) || (x.Customer != null && x.Customer.Equals(y.Customer)))
                    && String.Equals(x.Message, y.Message, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Recipient, y.Recipient, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Sender, y.Sender, StringComparison.InvariantCultureIgnoreCase);
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="IGiftMessage"/> object.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IGiftMessage obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else
            {
                return obj.GetHashCode();
            }
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(Message) ? base.ToString() : Message;
        }

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be inherited.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public override string ToJson<T>()
        {
            return this.SerializeJson(this);
        }
    }
}

