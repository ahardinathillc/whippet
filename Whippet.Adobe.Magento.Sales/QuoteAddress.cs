using System;
using NodaTime;
using Athi.Whippet.Extensions;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Customer;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;
using Athi.Whippet.Adobe.Magento.Sales.Extensions;
using MagentoCustomer = Athi.Whippet.Adobe.Magento.Customer.Customer;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Represents the address associated with a <see cref="Sales.Quote"/>.
    /// </summary>
    public class QuoteAddress : MagentoEntity, IMagentoEntity, IQuoteAddress, IEqualityComparer<IQuoteAddress>
    {
        private CustomerAddress _custAddress;
        private MagentoCustomer _customer;
        private GiftMessage _giftMessage;
        private Quote _quote;

        /// <summary>
        /// Gets or sets the unique ID of the entity.
        /// </summary>
        public virtual uint AddressID
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
        /// Gets or sets the address type.
        /// </summary>
        public virtual string AddressType
        { get; set; }

        /// <summary>
        /// Gets or sets the applied taxes.
        /// </summary>
        public virtual string AppliedTaxes
        { get; set; }

        /// <summary>
        /// Gets or sets the base customer balance.
        /// </summary>
        public virtual decimal? BaseCustomerBalanceAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base discount amount.
        /// </summary>
        public virtual decimal BaseDiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base discount tax compensation amount.
        /// </summary>
        public virtual decimal? BaseDiscountTaxCompensationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base gift cards amount.
        /// </summary>
        public virtual decimal? BaseGiftCardsAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base grand total.
        /// </summary>
        public virtual decimal BaseGrandTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the base reward currency amount.
        /// </summary>
        public virtual decimal? BaseRewardCurrencyAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base shipping amount.
        /// </summary>
        public virtual decimal BaseShippingAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base shipping discount amount.
        /// </summary>
        public virtual decimal? BaseShippingDiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base shipping discount tax compensation amount.
        /// </summary>
        public virtual decimal? BaseShippingDiscountTaxCompensationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base shipping amount including tax.
        /// </summary>
        public virtual decimal? BaseShippingIncludingTax
        { get; set; }

        /// <summary>
        /// Gets or sets the base shipping tax amount.
        /// </summary>
        public virtual decimal? BaseShippingTaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base subtotal amount.
        /// </summary>
        public virtual decimal BaseSubtotal
        { get; set; }

        /// <summary>
        /// Gets or sets the base subtotal including tax amount.
        /// </summary>
        public virtual decimal? BaseSubtotalIncludingTax
        { get; set; }

        /// <summary>
        /// Gets or sets the base subtotal including discount amount.
        /// </summary>
        public virtual decimal BaseSubtotalWithDiscount
        { get; set; }

        /// <summary>
        /// Gets or sets the base tax amount.
        /// </summary>
        public virtual decimal BaseTaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the city portion of the address.
        /// </summary>
        public virtual string City
        { get; set; }

        /// <summary>
        /// Indicates whether shipping rates should be collected for the quote.
        /// </summary>
        public virtual bool CollectShippingRates
        { get; set; }

        /// <summary>
        /// Gets or sets the company portion of the address.
        /// </summary>
        public virtual string Company
        { get; set; }

        /// <summary>
        /// Gets or sets the country ID. Countries are stored in Magento configuration.
        /// </summary>
        public virtual string CountryID
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the entity was created.
        /// </summary>
        public virtual Instant CreatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the associated customer address for the quote.
        /// </summary>
        public virtual CustomerAddress CustomerAddress
        {
            get
            {
                if (_custAddress == null)
                {
                    _custAddress = new CustomerAddress();
                }

                return _custAddress;
            }
            set
            {
                _custAddress = value;
            }
        }

        /// <summary>
        /// Gets or sets the associated customer address for the quote.
        /// </summary>
        ICustomerAddress IQuoteAddress.CustomerAddress
        {
            get
            {
                return CustomerAddress;
            }
            set
            {
                CustomerAddress = value.ToCustomerAddress();
            }
        }

        /// <summary>
        /// Gets or sets the customer balance amount.
        /// </summary>
        public virtual decimal? CustomerBalanceAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the customer associated with the quote address.
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
        /// Gets or sets the customer associated with the quote address.
        /// </summary>
        ICustomer IQuoteAddress.Customer
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
        /// Gets or sets the customer notes.
        /// </summary>
        public virtual string CustomerNotes
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount.
        /// </summary>
        public virtual decimal DiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the discount description.
        /// </summary>
        public virtual string DiscountDescription
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation amount.
        /// </summary>
        public virtual decimal? DiscountTaxCompensationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the e-mail address associated with the quote address.
        /// </summary>
        public virtual string Email
        { get; set; }

        /// <summary>
        /// Gets or sets the fax phone number associated with the quote address.
        /// </summary>
        public virtual string Fax
        { get; set; }

        /// <summary>
        /// Gets or sets the first name portion of the address.
        /// </summary>
        public virtual string FirstName
        { get; set; }

        /// <summary>
        /// Indicates whether free shipping is applied to the address.
        /// </summary>
        public virtual bool FreeShipping
        { get; set; }

        /// <summary>
        /// Gets or sets the list of gift cards applied to the quote.
        /// </summary>
        public virtual string GiftCards
        { get; set; }

        /// <summary>
        /// Gets or sets the gift cards amount.
        /// </summary>
        public virtual decimal? GiftCardsAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the associated gift message.
        /// </summary>
        public virtual GiftMessage GiftMessage
        {
            get
            {
                if (_giftMessage == null)
                {
                    _giftMessage = new GiftMessage();
                }

                return _giftMessage;
            }
            set
            {
                _giftMessage = value;
            }
        }

        /// <summary>
        /// Gets or sets the associated gift message.
        /// </summary>
        IGiftMessage IQuoteAddress.GiftMessage
        {
            get
            {
                return GiftMessage;
            }
            set
            {
                GiftMessage = value.ToGiftMessage();
            }
        }

        /// <summary>
        /// Gets or sets the gift registry item ID.
        /// </summary>
        public virtual int? GiftRegistryItemID
        { get; set; }

        /// <summary>
        /// Gets or sets the grand total.
        /// </summary>
        public virtual decimal GrandTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the last name portion of the quote address.
        /// </summary>
        public virtual string LastName
        { get; set; }

        /// <summary>
        /// Gets or sets the middle name portion of the quote address.
        /// </summary>
        public virtual string MiddleName
        { get; set; }

        /// <summary>
        /// Gets or sets the postal code portion of the quote address.
        /// </summary>
        public virtual string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or sets the prefix of the customer.
        /// </summary>
        public virtual string Prefix
        { get; set; }

        /// <summary>
        /// Gets or sets the parent quote that the address is associated with.
        /// </summary>
        public virtual Quote Quote
        {
            get
            {
                if (_quote == null)
                {
                    _quote = new Quote();
                }

                return _quote;
            }
            set
            {
                _quote = value;
            }
        }

        /// <summary>
        /// Gets or sets the parent quote that the address is associated with.
        /// </summary>
        IQuote IQuoteAddress.Quote
        {
            get
            {
                return Quote;
            }
            set
            {
                Quote = value.ToQuote();
            }
        }

        /// <summary>
        /// Gets or sets the address region.
        /// </summary>
        public virtual string Region
        { get; set; }

        /// <summary>
        /// Gets or sets the region ID. The region ID is stored in Magento configuration.
        /// </summary>
        public virtual string RegionID
        { get; set; }

        /// <summary>
        /// Gets or sets the reward currency amount.
        /// </summary>
        public virtual decimal? RewardCurrencyAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the reward points balance.
        /// </summary>
        public virtual int? RewardPointsBalance
        { get; set; }

        /// <summary>
        /// Indicates if the quote address is the same as the billing address.
        /// </summary>
        public virtual bool SameAsBilling
        { get; set; }

        /// <summary>
        /// Indicates whether the address should be saved in the customer's address book.
        /// </summary>
        public virtual bool? SaveInAddressBook
        { get; set; }

        /// <summary>
        /// Gets or sets the total shipping amount.
        /// </summary>
        public virtual decimal ShippingAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping description.
        /// </summary>
        public virtual string ShippingDescription
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping discount amount.
        /// </summary>
        public virtual decimal? ShippingDiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping discount tax compensation amount.
        /// </summary>
        public virtual decimal? ShippingDiscountTaxCompensationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the total shipping cost including tax.
        /// </summary>
        public virtual decimal? ShippingIncludingTax
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping method.
        /// </summary>
        public virtual string ShippingMethod
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping tax amount.
        /// </summary>
        public virtual decimal ShippingTaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the street portion of the address.
        /// </summary>
        public virtual string Street
        { get; set; }

        /// <summary>
        /// Gets or sets the quote subtotal.
        /// </summary>
        public virtual decimal Subtotal
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal including tax.
        /// </summary>
        public virtual decimal? SubtotalIncludingTax
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal including applied discounts.
        /// </summary>
        public virtual decimal SubtotalWithDiscount
        { get; set; }

        /// <summary>
        /// Gets or sets the customer suffix.
        /// </summary>
        public virtual string Suffix
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount.
        /// </summary>
        public virtual decimal TaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the address telephone number.
        /// </summary>
        public virtual string Telephone
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the entity was last updated.
        /// </summary>
        public virtual Instant UpdatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the list of used gift card codes.
        /// </summary>
        public virtual string UsedGiftCards
        { get; set; }

        /// <summary>
        /// Gets or sets the validated VAT number for the customer.
        /// </summary>
        public virtual string ValidatedValueAddedTaxNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the VAT ID.
        /// </summary>
        public virtual string ValueAddedTaxID
        { get; set; }

        /// <summary>
        /// Indicates whether the VAT supplied is valid.
        /// </summary>
        public virtual bool? ValueAddedTaxIsValid
        { get; set; }

        /// <summary>
        /// Gets or sets the date the VAT was requested.
        /// </summary>
        public virtual string ValueAddedTaxRequestDate
        { get; set; }

        /// <summary>
        /// Gets or sets the unique ID of the VAT request.
        /// </summary>
        public virtual string ValueAddedTaxRequestID
        { get; set; }

        /// <summary>
        /// Indicates whether the VAT request was successful.
        /// </summary>
        public virtual bool? ValueAddedTaxRequestSuccess
        { get; set; }

        /// <summary>
        /// Gets or sets the weight of the shipment.
        /// </summary>
        public virtual decimal Weight
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuoteAddress"/> class with no arguments.
        /// </summary>
        public QuoteAddress()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuoteAddress"/> class with the specified rule ID and <see cref="MagentoServer"/>.
        /// </summary>
        /// <param name="quoteId">Quote address ID.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        public QuoteAddress(uint quoteId, MagentoServer server)
            : base(quoteId, server)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return (obj == null || !(obj is IQuoteAddress)) ? false : Equals(obj as IQuoteAddress);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IQuoteAddress obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IQuoteAddress x, IQuoteAddress y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.AddressType, y.AddressType, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.AppliedTaxes, y.AppliedTaxes, StringComparison.InvariantCultureIgnoreCase)
                    && x.BaseCustomerBalanceAmount.GetValueOrDefault().Equals(y.BaseCustomerBalanceAmount.GetValueOrDefault())
                    && x.BaseDiscountAmount.Equals(y.BaseDiscountAmount)
                    && x.BaseDiscountTaxCompensationAmount.GetValueOrDefault().Equals(y.BaseDiscountTaxCompensationAmount.GetValueOrDefault())
                    && x.BaseGiftCardsAmount.GetValueOrDefault().Equals(y.BaseGiftCardsAmount.GetValueOrDefault())
                    && x.BaseGrandTotal.Equals(y.BaseGrandTotal)
                    && x.BaseRewardCurrencyAmount.GetValueOrDefault().Equals(y.BaseRewardCurrencyAmount.GetValueOrDefault())
                    && x.BaseShippingAmount.Equals(y.BaseShippingAmount)
                    && x.BaseShippingDiscountTaxCompensationAmount.GetValueOrDefault().Equals(y.BaseShippingDiscountTaxCompensationAmount.GetValueOrDefault())
                    && x.BaseShippingIncludingTax.GetValueOrDefault().Equals(y.BaseShippingIncludingTax.GetValueOrDefault())
                    && x.BaseShippingTaxAmount.GetValueOrDefault().Equals(y.BaseShippingTaxAmount.GetValueOrDefault())
                    && x.BaseSubtotal.Equals(y.BaseSubtotal)
                    && x.BaseSubtotalIncludingTax.GetValueOrDefault().Equals(y.BaseSubtotalIncludingTax.GetValueOrDefault())
                    && x.BaseSubtotalWithDiscount.Equals(y.BaseSubtotalWithDiscount)
                    && x.BaseTaxAmount.Equals(y.BaseTaxAmount)
                    && String.Equals(x.City, y.City, StringComparison.InvariantCultureIgnoreCase)
                    && x.CollectShippingRates.Equals(y.CollectShippingRates)
                    && String.Equals(x.Company, y.Company, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.CountryID, y.CountryID, StringComparison.InvariantCultureIgnoreCase)
                    && x.CreatedAt.Equals(y.CreatedAt)
                    && ((x.Customer == null && y.Customer == null) || (x.Customer != null && x.Customer.Equals(y.Customer)))
                    && ((x.CustomerAddress == null && y.CustomerAddress == null) || (x.CustomerAddress != null && x.CustomerAddress.Equals(y.CustomerAddress)))
                    && x.CustomerBalanceAmount.GetValueOrDefault().Equals(y.CustomerBalanceAmount.GetValueOrDefault())
                    && String.Equals(x.CustomerNotes, y.CustomerNotes, StringComparison.InvariantCultureIgnoreCase)
                    && x.DiscountAmount.Equals(y.DiscountAmount)
                    && String.Equals(x.DiscountDescription, y.DiscountDescription, StringComparison.InvariantCultureIgnoreCase)
                    && x.DiscountTaxCompensationAmount.GetValueOrDefault().Equals(y.DiscountTaxCompensationAmount.GetValueOrDefault())
                    && String.Equals(x.Email, y.Email, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Fax, y.Fax, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.FirstName, y.FirstName, StringComparison.InvariantCultureIgnoreCase)
                    && x.FreeShipping.Equals(y.FreeShipping)
                    && String.Equals(x.GiftCards, y.GiftCards, StringComparison.InvariantCultureIgnoreCase)
                    && x.GiftCardsAmount.GetValueOrDefault().Equals(y.GiftCardsAmount.GetValueOrDefault())
                    && ((x.GiftMessage == null && y.GiftMessage == null) || (x.GiftMessage != null && x.GiftMessage.Equals(y.GiftMessage)))
                    && x.GiftRegistryItemID.GetValueOrDefault().Equals(y.GiftRegistryItemID.GetValueOrDefault())
                    && x.GrandTotal.Equals(y.GrandTotal)
                    && String.Equals(x.LastName, y.LastName, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.MiddleName, y.MiddleName, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.PostalCode, y.PostalCode, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Prefix, y.Prefix, StringComparison.InvariantCultureIgnoreCase)
                    && ((x.Quote == null && y.Quote == null) || (x.Quote != null && x.Quote.Equals(y.Quote)))
                    && String.Equals(x.Region, y.Region, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.RegionID, y.RegionID, StringComparison.InvariantCultureIgnoreCase)
                    && x.RewardCurrencyAmount.GetValueOrDefault().Equals(y.RewardCurrencyAmount.GetValueOrDefault())
                    && x.RewardPointsBalance.GetValueOrDefault().Equals(y.RewardPointsBalance.GetValueOrDefault())
                    && x.SameAsBilling.Equals(y.SameAsBilling)
                    && x.SaveInAddressBook.GetValueOrDefault().Equals(y.SaveInAddressBook.GetValueOrDefault())
                    && x.ShippingAmount.Equals(y.ShippingAmount)
                    && String.Equals(x.ShippingDescription, y.ShippingDescription, StringComparison.InvariantCultureIgnoreCase)
                    && x.ShippingDiscountAmount.GetValueOrDefault().Equals(y.ShippingDiscountAmount.GetValueOrDefault())
                    && x.ShippingDiscountTaxCompensationAmount.GetValueOrDefault().Equals(y.ShippingDiscountTaxCompensationAmount.GetValueOrDefault())
                    && x.ShippingIncludingTax.GetValueOrDefault().Equals(y.ShippingIncludingTax.GetValueOrDefault())
                    && String.Equals(x.ShippingMethod, y.ShippingMethod, StringComparison.InvariantCultureIgnoreCase)
                    && x.ShippingTaxAmount.Equals(y.ShippingTaxAmount)
                    && String.Equals(x.Street, y.Street, StringComparison.InvariantCultureIgnoreCase)
                    && x.Subtotal.Equals(y.Subtotal)
                    && x.SubtotalIncludingTax.GetValueOrDefault().Equals(y.SubtotalIncludingTax.GetValueOrDefault())
                    && x.SubtotalWithDiscount.Equals(y.SubtotalWithDiscount)
                    && String.Equals(x.Suffix, y.Suffix, StringComparison.InvariantCultureIgnoreCase)
                    && x.TaxAmount.Equals(y.TaxAmount)
                    && String.Equals(x.Telephone, y.Telephone, StringComparison.InvariantCultureIgnoreCase)
                    && x.UpdatedAt.Equals(y.UpdatedAt)
                    && String.Equals(x.UsedGiftCards, y.UsedGiftCards, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.ValidatedValueAddedTaxNumber, y.ValidatedValueAddedTaxNumber, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.ValueAddedTaxID, y.ValueAddedTaxID, StringComparison.InvariantCultureIgnoreCase)
                    && x.ValueAddedTaxIsValid.GetValueOrDefault().Equals(y.ValueAddedTaxIsValid.GetValueOrDefault())
                    && String.Equals(x.ValueAddedTaxRequestDate, y.ValueAddedTaxRequestDate, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.ValueAddedTaxRequestID, y.ValueAddedTaxRequestID, StringComparison.InvariantCultureIgnoreCase)
                    && x.ValueAddedTaxRequestSuccess.GetValueOrDefault().Equals(y.ValueAddedTaxRequestSuccess.GetValueOrDefault())
                    && x.Weight.Equals(y.Weight);
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
        /// <param name="obj"><see cref="IQuote"/> object.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IQuoteAddress obj)
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

