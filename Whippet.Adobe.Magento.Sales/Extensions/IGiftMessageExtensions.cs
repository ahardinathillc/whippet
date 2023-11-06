using System;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;

namespace Athi.Whippet.Adobe.Magento.Sales.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IGiftMessage"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IGiftMessageExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IGiftMessage"/> object to a <see cref="GiftMessage"/> object.
        /// </summary>
        /// <param name="giftMessage"><see cref="IGiftMessage"/> object to convert.</param>
        /// <returns><see cref="GiftMessage"/> object.</returns>
        public static GiftMessage ToGiftMessage(this IGiftMessage giftMessage)
        {
            GiftMessage gm = null;

            if (giftMessage != null)
            {
                if (giftMessage is GiftMessage)
                {
                    gm = (GiftMessage)(giftMessage);
                }
                else
                {
                    gm = new GiftMessage();
                    gm.Customer = giftMessage.Customer.ToCustomer();
                    gm.GiftMessageID = giftMessage.GiftMessageID;
                    gm.Message = giftMessage.Message;
                    gm.Recipient = giftMessage.Recipient;
                    gm.Sender = giftMessage.Sender;
                    gm.Server = giftMessage.Server.ToMagentoServer();
                }
            }

            return gm;
        }
    }
}
