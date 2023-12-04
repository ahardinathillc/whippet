using System;

namespace Athi.Whippet.Adobe.Magento.GiftCard
{
    /// <summary>
    /// Represents a link type for an <see cref="ICategory"/>. 
    /// </summary>
    public struct GiftCardOption : IEqualityComparer<GiftCardOption>, IExtensionInterfaceMap<GiftCardOptionInterface>
    {
        /// <summary>
        /// Gets or sets the gift card amount formatted with the appropriate currency sign.
        /// </summary>
        public string Amount
        { get; set; }

        /// <summary>
        /// Gets or sets the custom gift card amount.
        /// </summary>
        public decimal CustomAmount
        { get; set; }
        
        /// <summary>
        /// Gets or sets the sender's name.
        /// </summary>
        public string SenderName
        { get; set; }
        
        /// <summary>
        /// Gets or sets the recipient name.
        /// </summary>
        public string RecipientName
        { get; set; }

        /// <summary>
        /// Gets or sets the sender's e-mail.
        /// </summary>
        public string SenderEmail
        { get; set; }

        /// <summary>
        /// Gets or sets the recipient's e-mail.
        /// </summary>
        public string RecipientEmail
        { get; set; }

        /// <summary>
        /// Gets or sets the gift card message.
        /// </summary>
        public string Message
        { get; set; }

        /// <summary>
        /// Gets or sets the collection of created codes.
        /// </summary>
        public IEnumerable<string> Codes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardOption"/> class with no arguments.
        /// </summary>
        public GiftCardOption()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardOption"/> class with the specified <see cref="GiftCardOptionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="GiftCardOptionInterface"/> object.</param>
        public GiftCardOption(GiftCardOptionInterface model)
            : this()
        {
            FromModel(model);
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardOption"/> class with the specified parameters.
        /// </summary>
        /// <param name="amount">Gift card amount with appropriate currency sign.</param>
        /// <param name="customAmount">Custom gift card amount.</param>
        /// <param name="senderName">Sender name.</param>
        /// <param name="recipientName">Recipient name.</param>
        /// <param name="senderEmail">Sender e-mail.</param>
        /// <param name="recipientEmail">Recipient e-mail.</param>
        /// <param name="message">Gift card message.</param>
        /// <param name="codes">Gift card codes.</param>
        public GiftCardOption(string amount, decimal customAmount, string senderName, string recipientName, string senderEmail, string recipientEmail, string message, IEnumerable<string> codes)
            : this()
        {
            Amount = amount;
            CustomAmount = customAmount;
            SenderName = senderName;
            RecipientName = recipientName;
            SenderEmail = senderEmail;
            RecipientEmail = recipientEmail;
            Message = message;
            Codes = codes;
        }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is GiftCardOption)) ? false : Equals((GiftCardOption)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(GiftCardOption obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(GiftCardOption x, GiftCardOption y)
        {
            return String.Equals(x.Amount.Trim(), y.Amount?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && x.CustomAmount == y.CustomAmount
                   && String.Equals(x.SenderName?.Trim(), y.SenderName?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && String.Equals(x.RecipientName?.Trim(), y.RecipientName?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && String.Equals(x.SenderEmail?.Trim(), y.RecipientEmail?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && String.Equals(x.Message?.Trim(), y.Message?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && (((x.Codes == null) && (y.Codes == null)) || ((x.Codes != null) && x.Codes.SequenceEqual(y.Codes)));
        }
        
        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, CustomAmount, SenderName, RecipientName, SenderEmail, Message, Codes);
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="obj"><see cref="GiftCardOption"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(GiftCardOption obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="GiftCardOptionInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="GiftCardOptionInterface"/>.</returns>
        public GiftCardOptionInterface ToInterface()
        {
            GiftCardOptionInterface gcInterface = new GiftCardOptionInterface();

            gcInterface.Amount = Amount;
            gcInterface.CustomGiftCardAmount = CustomAmount;
            gcInterface.SenderName = SenderName;
            gcInterface.RecipientName = RecipientName;
            gcInterface.SenderEmail = SenderEmail;
            gcInterface.Message = Message;
            gcInterface.ExtensionAttributes = new GiftCardOptionExtensionInterface();
            gcInterface.ExtensionAttributes.CreatedCodes = (Codes == null) ? null : Codes.ToArray();
            
            return gcInterface;
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="GiftCardOptionInterface"/> object used to populate the object.</param>
        public void FromModel(GiftCardOptionInterface model)
        {
            if (model != null)
            {
                Amount = model.Amount; 
                CustomAmount = model.CustomGiftCardAmount;
                SenderName = model.SenderName;
                RecipientName = model.RecipientName;
                SenderEmail = model.SenderEmail;
                Message = model.Message;
                Codes = (model.ExtensionAttributes == null) ? null : model.ExtensionAttributes.CreatedCodes;
            }
        }
    }
}
