
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.GiftCard
{
    /// <summary>
    /// Represents a Magento gift card.
    /// </summary>
    public interface IGiftCard : IMagentoEntity, IEqualityComparer<IGiftCard>, IMagentoRestEntity
    {
        /// <summary>
        /// Gets or sets the gift card code.
        /// </summary>
        string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the gift card amount.
        /// </summary>
        decimal Amount
        { get; set; }

        /// <summary>
        /// Gets or sets the gift card amount in base currency.
        /// </summary>
        decimal BaseAmount
        { get; set; }
    }
}
