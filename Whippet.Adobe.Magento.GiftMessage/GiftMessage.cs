using System;
using Athi.Whippet.Adobe.Magento.Data;
using MagentoCustomer = Athi.Whippet.Adobe.Magento.Customer.Customer;

namespace Athi.Whippet.Adobe.Magento.GiftMessage
{
    /// <summary>
    /// Represents a gift message that is published with an item in an order.
    /// </summary>
    public struct GiftMessage : IEqualityComparer<GiftMessage>, IExtensionInterfaceMap<GiftMessageInterface>
    {
        /// <summary>
        /// Gets or sets the gift message ID.
        /// </summary>
        public int? ID
        { get; set; }
        
        /// <summary>
        /// Gets or sets the parent customer.
        /// </summary>
        public MagentoCustomer Customer
        { get; set; }

        /// <summary>
        /// Gets or sets the sender name.
        /// </summary>
        public string SenderName
        { get; set; }

        /// <summary>
        /// Gets or sets the recipient name.
        /// </summary>
        public string RecipientName
        { get; set; }

        /// <summary>
        /// Gets or sets the gift message.
        /// </summary>
        public string Message
        { get; set; }

        /// <summary>
        /// Gets or sets the entity ID.
        /// </summary>
        public string EntityID
        { get; set; }

        /// <summary>
        /// Gets or sets the entity type.
        /// </summary>
        public string EntityType
        { get; set; }

        /// <summary>
        /// Gets or sets the wrapping option ID.
        /// </summary>
        public int WrappingID
        { get; set; }

        /// <summary>
        /// Specifies whether the wrapping should allow a gift receipt.
        /// </summary>
        public bool AllowGiftReceipt
        { get; set; }

        /// <summary>
        /// Specifies whether the wrapping should include a printed card.
        /// </summary>
        public bool AddPrintedCard
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GiftMessage"/> class with no arguments.
        /// </summary>
        static GiftMessage()
        { }
          
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftMessage"/> struct with no arguments.
        /// </summary>
        public GiftMessage()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GiftMessage"/> struct with the specified <see cref="GiftMessageInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="GiftMessageInterface"/> object.</param>
        public GiftMessage(GiftMessageInterface model)
            : this()
        {
            FromModel(model);
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="GiftMessageInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="GiftMessageInterface"/>.</returns>
        public GiftMessageInterface ToInterface()
        {
            GiftMessageInterface gmInterface = new GiftMessageInterface();
            gmInterface.GiftMessageID = ID;
            gmInterface.CustomerID = (Customer == null) ? null : Customer.ID;
            gmInterface.Sender = SenderName;
            gmInterface.Recipient = RecipientName;
            gmInterface.Message = Message;
            gmInterface.ExtensionAttributes = new GiftMessageExtensionInterface();
            gmInterface.ExtensionAttributes.EntityID = EntityID;
            gmInterface.ExtensionAttributes.EntityType = EntityType;
            gmInterface.ExtensionAttributes.WrappingID = WrappingID;
            gmInterface.ExtensionAttributes.AllowGiftReceipt = AllowGiftReceipt;
            gmInterface.ExtensionAttributes.AddPrintedCard = AddPrintedCard;
            
            return gmInterface;
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="GiftMessageInterface"/> object used to populate the object.</param>
        public void FromModel(GiftMessageInterface model)
        {
            if (model != null)
            {
                ID = model.GiftMessageID;
                Customer = model.CustomerID.HasValue ? new MagentoCustomer(Convert.ToUInt32(model.CustomerID.Value)) : null;
                SenderName = model.Sender;
                RecipientName = model.Recipient;
                Message = model.Message;

                if (model.ExtensionAttributes != null)
                {
                    EntityID = model.ExtensionAttributes.EntityID;
                    EntityType = model.ExtensionAttributes.EntityType;
                    WrappingID = model.ExtensionAttributes.WrappingID;
                    AllowGiftReceipt = model.ExtensionAttributes.AllowGiftReceipt;
                    AddPrintedCard = model.ExtensionAttributes.AddPrintedCard;
                }
            }
        }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return (obj == null) || !(obj is GiftMessage) ? false : Equals((GiftMessage)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(GiftMessage obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(GiftMessage x, GiftMessage y)
        {
            return x.ID.GetValueOrDefault().Equals(y.ID.GetValueOrDefault())
                   && (((x.Customer == null) && (y.Customer == null)) || ((x.Customer != null) && x.Customer.Equals(y.Customer)))
                   && String.Equals(x.SenderName?.Trim(), y.SenderName?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && String.Equals(x.RecipientName?.Trim(), y.RecipientName?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && String.Equals(x.Message?.Trim(), y.Message?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && String.Equals(x.EntityID?.Trim(), y.EntityID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && String.Equals(x.EntityType?.Trim(), y.EntityType?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && x.WrappingID == y.WrappingID
                   && x.AllowGiftReceipt == y.AllowGiftReceipt
                   && x.AddPrintedCard == y.AddPrintedCard;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode code = new HashCode();

            code.Add(ID);
            code.Add(Customer);
            code.Add(SenderName);
            code.Add(RecipientName);
            code.Add(Message);
            code.Add(EntityID);
            code.Add(EntityType);
            code.Add(WrappingID);
            code.Add(AllowGiftReceipt);
            code.Add(AddPrintedCard);

            return code.ToHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get hash code for.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public int GetHashCode(GiftMessage obj)
        {
            return obj.GetHashCode();
        }
    }
}
