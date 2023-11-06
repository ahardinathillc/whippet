using System;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;
using Athi.Whippet.Adobe.Magento.Taxes.Extensions;
using Athi.Whippet.Adobe.Magento.EAV.Extensions;

namespace Athi.Whippet.Adobe.Magento.Sales.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IQuote"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IQuoteExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IQuote"/> object to a <see cref="Quote"/> object.
        /// </summary>
        /// <param name="quote"><see cref="IQuote"/> object to convert.</param>
        /// <returns><see cref="Quote"/> object.</returns>
        public static Quote ToQuote(this IQuote quote)
        {
            Quote qt = null;

            if (quote != null)
            {
                if (quote is Quote)
                {
                    qt = (Quote)(quote);
                }
                else
                {
                    qt = new Quote();
                    qt.Active = quote.Active;
                    qt.AppliedRuleIDs = quote.AppliedRuleIDs;
                    qt.BaseCurrencyCode = quote.BaseCurrencyCode;
                    qt.BaseCustomerBalanceAmountUsed = quote.BaseCustomerBalanceAmountUsed;
                    qt.BaseGiftCardsAmount = quote.BaseGiftCardsAmount;
                    qt.BaseGiftCardsAmountUsed = quote.BaseCustomerBalanceAmountUsed;
                    qt.BaseGrandTotal = quote.BaseGrandTotal;
                    qt.BaseRewardCurrencyAmount = quote.BaseRewardCurrencyAmount;
                    qt.BaseSubtotal = quote.BaseSubtotal;
                    qt.BaseSubtotalWithDiscount = quote.BaseSubtotalWithDiscount;
                    qt.BaseToGlobalRate = quote.BaseToGlobalRate;
                    qt.BaseToQuoteRate = quote.BaseToQuoteRate;
                    qt.CheckoutMethod = quote.CheckoutMethod;
                    qt.ConvertedAt = quote.ConvertedAt;
                    qt.CouponCode = quote.CouponCode;
                    qt.CreatedAt = quote.CreatedAt;
                    qt.Customer = quote.Customer.ToCustomer();
                    qt.CustomerBalanceAmountUsed = quote.CustomerBalanceAmountUsed;
                    qt.CustomerDateOfBirth = quote.CustomerDateOfBirth;
                    qt.CustomerEmail = quote.CustomerEmail;
                    qt.CustomerFirstName = quote.CustomerFirstName;
                    qt.CustomerGender = quote.CustomerGender;
                    qt.CustomerGroup = quote.CustomerGroup.ToCustomerGroup();
                    qt.CustomerIsGuest = quote.CustomerIsGuest;
                    qt.CustomerLastName = quote.CustomerLastName;
                    qt.CustomerMiddleName = quote.CustomerMiddleName;
                    qt.CustomerNote = quote.CustomerNote;
                    qt.CustomerPrefix = quote.CustomerPrefix;
                    qt.CustomerSuffix = quote.CustomerSuffix;
                    qt.CustomerTaxClass = quote.CustomerTaxClass.ToTaxClass();
                    qt.CustomerValueAddedTax = quote.CustomerValueAddedTax;
                    qt.EntityID = quote.EntityID;
                    qt.ExternalShippingInfo = quote.ExternalShippingInfo;
                    qt.GiftCards = quote.GiftCards;
                    qt.GiftCardsAmount = quote.GiftCardsAmount;
                    qt.GiftCardsAmountUsed = quote.GiftCardsAmountUsed;
                    qt.GiftMessage = quote.GiftMessage.ToGiftMessage();
                    qt.GlobalCurrencyCode = quote.GlobalCurrencyCode;
                    qt.GrandTotal = quote.GrandTotal;
                    qt.IsChanged = quote.IsChanged;
                    qt.IsHighestItemPriceRule = quote.IsHighestItemPriceRule;
                    qt.IsMultiShipping = quote.IsMultiShipping;
                    qt.IsPersistent = quote.IsPersistent;
                    qt.IsVirtual = quote.IsVirtual;
                    qt.ItemsCount = quote.ItemsCount;
                    qt.ItemsQuantity = quote.ItemsQuantity;
                    qt.NotifyCustomerNote = quote.NotifyCustomerNote;
                    qt.OriginalOrder = quote.OriginalOrder.ToSalesOrder();
                    qt.PasswordHash = quote.PasswordHash;
                    qt.QuoteCurrencyCode = quote.QuoteCurrencyCode;
                    qt.RemoteIP = quote.RemoteIP;
                    qt.ReservedOrderID = quote.ReservedOrderID;
                    qt.RewardCurrencyAmount = quote.RewardCurrencyAmount;
                    qt.RewardPointsBalance = quote.RewardPointsBalance;
                    qt.Server = quote.Server.ToMagentoServer();
                    qt.Store = quote.Store.ToStore();
                    qt.StoreCurrencyCode = quote.StoreCurrencyCode;
                    qt.StoreToBaseRate = quote.StoreToBaseRate;
                    qt.StoreToQuoteRate = quote.StoreToQuoteRate;
                    qt.Subtotal = quote.Subtotal;
                    qt.SubtotalWithDiscount = quote.SubtotalWithDiscount;
                    qt.TriggerRecollect = quote.TriggerRecollect;
                    qt.UpdatedAt = quote.UpdatedAt;
                    qt.UseCustomerBalance = quote.UseCustomerBalance;
                    qt.UseRewardPoints = quote.UseRewardPoints;
                }
            }

            return qt;
        }
    }
}
