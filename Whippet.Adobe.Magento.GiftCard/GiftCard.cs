using System;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.GiftCard
{
    /// <summary>
    /// Represents a Magento gift card.
    /// </summary>
    public class GiftCard : MagentoRestEntity<GiftCardInterface>, IMagentoEntity, IGiftCard, IEqualityComparer<IGiftCard>, IMagentoRestEntity<GiftCardInterface>
    {
        /// <summary>
        /// Gets or sets the gift card code.
        /// </summary>
        public virtual string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the gift card amount.
        /// </summary>
        public virtual decimal Amount
        { get; set; }

        /// <summary>
        /// Gets or sets the gift card amount in base currency.
        /// </summary>
        public virtual decimal BaseAmount
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCard"/> class with no arguments.
        /// </summary>
        public GiftCard()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCard"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public GiftCard(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCard"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public GiftCard(GiftCardInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is IGiftCard)) ? false : Equals((IGiftCard)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IGiftCard obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IGiftCard x, IGiftCard y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = x.ID == y.ID
                            && String.Equals(x.Code?.Trim(), y.Code?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                            && x.Amount == y.Amount
                            && x.BaseAmount == y.BaseAmount
                            && (((x.Server == null) && (y.Server == null)) || ((x.Server != null) && x.Server.Equals(y.Server)))
                            && (((x.RestEndpoint == null) && (y.RestEndpoint == null)) || ((x.RestEndpoint != null) && x.RestEndpoint.Equals(y.RestEndpoint)));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="GiftCardInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="GiftCardInterface"/>.</returns>
        public override GiftCardInterface ToInterface()
        {
            GiftCardInterface gcInterface = new GiftCardInterface();

            gcInterface.ID = ID;
            gcInterface.Code = Code;
            gcInterface.Amount = Amount;
            gcInterface.AmountBase = BaseAmount;
            
            return gcInterface;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            GiftCard giftCard = new GiftCard();
            giftCard.ID = ID;
            giftCard.Code = Code;
            giftCard.Amount = Amount;
            giftCard.BaseAmount = BaseAmount;
            
            return giftCard;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Code, Amount, BaseAmount);
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="giftCard"><see cref="IGiftCard"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IGiftCard giftCard)
        {
            ArgumentNullException.ThrowIfNull(giftCard);
            return giftCard.GetHashCode();
        }
        
        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(GiftCardInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                Code = model.Code;
                Amount = model.Amount;
                BaseAmount = model.AmountBase;
            }
        }
    }
}
