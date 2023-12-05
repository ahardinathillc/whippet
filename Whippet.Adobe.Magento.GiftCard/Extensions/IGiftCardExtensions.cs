using System;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.GiftCard.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IGiftCard"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IGiftCardExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IGiftCard"/> object to a <see cref="GiftCard"/> object.
        /// </summary>
        /// <param name="giftCard"><see cref="IGiftCard"/> object to convert.</param>
        /// <returns><see cref="GiftCard"/> object.</returns>
        public static GiftCard ToGiftCard(this IGiftCard giftCard)
        {
            GiftCard gc = null;

            if (giftCard is GiftCard)
            {
                gc = (GiftCard)(giftCard);
            }
            else if (giftCard != null)
            {
                gc = new GiftCard();
                gc.ID = giftCard.ID;
                gc.Amount = giftCard.Amount;
                gc.BaseAmount = giftCard.BaseAmount;
                gc.Code = giftCard.Code;
                gc.Server = giftCard.Server.ToMagentoServer();
                gc.RestEndpoint = giftCard.RestEndpoint.ToMagentoRestEndpoint();
            }

            return gc;
        }
    }
}
