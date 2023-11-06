using System;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;
using Athi.Whippet.Adobe.Magento.Taxes.Extensions;
using Athi.Whippet.Adobe.Magento.EAV.Extensions;

namespace Athi.Whippet.Adobe.Magento.Sales.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IQuoteAddress"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IQuoteAddressExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IQuoteAddress"/> object to a <see cref="QuoteAddress"/> object.
        /// </summary>
        /// <param name="quote"><see cref="IQuoteAddress"/> object to convert.</param>
        /// <returns><see cref="QuoteAddress"/> object.</returns>
        public static QuoteAddress ToQuoteAddress(this IQuoteAddress quote)
        {
            QuoteAddress qt = null;

            if (quote != null)
            {
                if (quote is QuoteAddress)
                {
                    qt = (QuoteAddress)(quote);
                }
                else
                {
                    qt = new QuoteAddress();
                    qt.AddressID = quote.AddressID;
                    qt.AddressType = quote.AddressType;
                    qt.AppliedTaxes = quote.AppliedTaxes;
                    qt.BaseCustomerBalanceAmount = quote.BaseCustomerBalanceAmount;
                    qt.BaseDiscountAmount = quote.BaseDiscountAmount;
                    qt.BaseDiscountTaxCompensationAmount = quote.BaseDiscountTaxCompensationAmount;
                    qt.BaseGiftCardsAmount = quote.BaseGiftCardsAmount;
                    qt.BaseGrandTotal = quote.BaseGrandTotal;
                    qt.BaseRewardCurrencyAmount = quote.BaseRewardCurrencyAmount;
                    qt.BaseShippingAmount = quote.BaseShippingAmount;
                    qt.BaseShippingDiscountAmount = quote.BaseShippingDiscountAmount;
                    qt.BaseShippingDiscountTaxCompensationAmount = quote.BaseShippingDiscountTaxCompensationAmount;
                    qt.BaseShippingIncludingTax = quote.BaseShippingIncludingTax;
                    qt.BaseShippingTaxAmount = quote.BaseShippingTaxAmount;
                    qt.BaseSubtotal = quote.BaseSubtotal;
                    qt.BaseSubtotalIncludingTax = quote.BaseSubtotalIncludingTax;
                    qt.BaseSubtotalWithDiscount = quote.BaseSubtotalWithDiscount;
                    qt.BaseTaxAmount = quote.BaseTaxAmount;
                    qt.City = quote.City;
                    qt.CollectShippingRates = quote.CollectShippingRates;
                    qt.Company = quote.Company;
                    qt.CountryID = quote.CountryID;
                    qt.CreatedAt = quote.CreatedAt;
                    qt.Customer = quote.Customer.ToCustomer();
                    qt.CustomerAddress = quote.CustomerAddress.ToCustomerAddress();
                    qt.CustomerBalanceAmount = quote.CustomerBalanceAmount;
                    qt.CustomerNotes = quote.CustomerNotes;
                    qt.DiscountAmount = quote.DiscountAmount;
                    qt.DiscountDescription = quote.DiscountDescription;
                    qt.DiscountTaxCompensationAmount = quote.DiscountTaxCompensationAmount;
                    qt.Email = quote.Email;
                    qt.Fax = quote.Fax;
                    qt.FirstName = quote.FirstName;
                    qt.FreeShipping = quote.FreeShipping;
                    qt.GiftCards = quote.GiftCards;
                    qt.GiftCardsAmount = quote.GiftCardsAmount;
                    qt.GiftMessage = quote.GiftMessage.ToGiftMessage();
                    qt.GiftRegistryItemID = quote.GiftRegistryItemID;
                    qt.GrandTotal = quote.GrandTotal;
                    qt.LastName = quote.LastName;
                    qt.MiddleName = quote.MiddleName;
                    qt.PostalCode = quote.PostalCode;
                    qt.Prefix = quote.Prefix;
                    qt.Quote = quote.Quote.ToQuote();
                    qt.Region = quote.Region;
                    qt.RegionID = quote.RegionID;
                    qt.RewardCurrencyAmount = quote.RewardCurrencyAmount;
                    qt.RewardPointsBalance = quote.RewardPointsBalance;
                    qt.SameAsBilling = quote.SameAsBilling;
                    qt.SaveInAddressBook = quote.SaveInAddressBook;
                    qt.Server = quote.Server.ToMagentoServer();
                    qt.ShippingAmount = quote.ShippingAmount;
                    qt.ShippingDescription = quote.ShippingDescription;
                    qt.ShippingDiscountAmount = quote.ShippingDiscountAmount;
                    qt.ShippingDiscountTaxCompensationAmount = quote.ShippingDiscountTaxCompensationAmount;
                    qt.ShippingIncludingTax = quote.ShippingIncludingTax;
                    qt.ShippingMethod = quote.ShippingMethod;
                    qt.ShippingTaxAmount = quote.ShippingTaxAmount;
                    qt.Street = quote.Street;
                    qt.Subtotal = quote.Subtotal;
                    qt.SubtotalIncludingTax = quote.SubtotalIncludingTax;
                    qt.SubtotalWithDiscount = quote.SubtotalWithDiscount;
                    qt.Suffix = quote.Suffix;
                    qt.TaxAmount = quote.TaxAmount;
                    qt.Telephone = quote.Telephone;
                    qt.UpdatedAt = quote.UpdatedAt;
                    qt.UsedGiftCards = quote.UsedGiftCards;
                    qt.ValidatedValueAddedTaxNumber = quote.ValidatedValueAddedTaxNumber;
                    qt.ValueAddedTaxID = quote.ValueAddedTaxID;
                    qt.ValueAddedTaxIsValid = quote.ValueAddedTaxIsValid;
                    qt.ValueAddedTaxRequestDate = quote.ValueAddedTaxRequestDate;
                    qt.ValueAddedTaxRequestID = quote.ValueAddedTaxRequestID;
                    qt.ValueAddedTaxRequestSuccess = quote.ValueAddedTaxRequestSuccess;
                    qt.Weight = quote.Weight;
                }
            }

            return qt;
        }
    }
}
