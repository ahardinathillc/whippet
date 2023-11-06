using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Customer;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;
using Athi.Whippet.Adobe.Magento.Taxes;
using Athi.Whippet.Adobe.Magento.Taxes.Extensions;
using Athi.Whippet.Adobe.Magento.Sales.Extensions;
using Athi.Whippet.Adobe.Magento.EAV;
using Athi.Whippet.Adobe.Magento.EAV.Extensions;
using MagentoCustomer = Athi.Whippet.Adobe.Magento.Customer.Customer;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Represents a sales quote in Magento.
    /// </summary>
    public class Quote : MagentoEntity, IMagentoEntity, IQuote, IEqualityComparer<IQuote>, IWhippetActiveEntity
    {
        private CustomerGroup _group;
        private MagentoCustomer _customer;
        private TaxClass _taxClass;
        private GiftMessage _giftMessage;
        private SalesOrder _order;
        private Store _store;

        /// <summary>
        /// Gets or sets the quote's unique entity ID.
        /// </summary>
        public virtual uint EntityID
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
        /// Gets or sets a delimited list of applied sales rules.
        /// </summary>
        public virtual string AppliedRuleIDs
        { get; set; }

        /// <summary>
        /// Gets or sets the base currency code.
        /// </summary>
        public virtual string BaseCurrencyCode
        { get; set; }

        /// <summary>
        /// Specifies the base customer amount balance used.
        /// </summary>
        public virtual decimal? BaseCustomerBalanceAmountUsed
        { get; set; }

        /// <summary>
        /// Gets or sets the base gift cards amount.
        /// </summary>
        public virtual decimal? BaseGiftCardsAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base gift cards amount used.
        /// </summary>
        public virtual decimal? BaseGiftCardsAmountUsed
        { get; set; }

        /// <summary>
        /// Gets or sets the base grand total.
        /// </summary>
        public virtual decimal? BaseGrandTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the base reward currency amount.
        /// </summary>
        public virtual decimal? BaseRewardCurrencyAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base subtotal.
        /// </summary>
        public virtual decimal? BaseSubtotal
        { get; set; }

        /// <summary>
        /// Gets or sets the base subtotal with discounts applied.
        /// </summary>
        public virtual decimal? BaseSubtotalWithDiscount
        { get; set; }

        /// <summary>
        /// Gets or sets the base amount converted to the global rate.
        /// </summary>
        public virtual decimal? BaseToGlobalRate
        { get; set; }

        /// <summary>
        /// Gets or sets the base amount converted to the quote rate.
        /// </summary>
        public virtual decimal? BaseToQuoteRate
        { get; set; }

        /// <summary>
        /// Gets or sets the checkout method.
        /// </summary>
        public virtual string CheckoutMethod
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the quote was converted.
        /// </summary>
        public virtual Instant? ConvertedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the coupon code used on the quote.
        /// </summary>
        public virtual string CouponCode
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the quote was created.
        /// </summary>
        public virtual Instant CreatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the customer balance amount used towards the quote.
        /// </summary>
        public virtual decimal? CustomerBalanceAmountUsed
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's date of birth.
        /// </summary>
        public virtual Instant? CustomerDateOfBirth
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's e-mail address.
        /// </summary>
        public virtual string CustomerEmail
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's first name.
        /// </summary>
        public virtual string CustomerFirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's gender.
        /// </summary>
        public virtual string CustomerGender
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's group.
        /// </summary>
        public virtual CustomerGroup CustomerGroup
        {
            get
            {
                if (_group == null)
                {
                    _group = new CustomerGroup();
                }

                return _group;
            }
            set
            {
                _group = value;
            }
        }

        /// <summary>
        /// Gets or sets the customer's group.
        /// </summary>
        ICustomerGroup IQuote.CustomerGroup
        {
            get
            {
                return CustomerGroup;
            }
            set
            {
                CustomerGroup = value.ToCustomerGroup();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Magento.Customer.Customer"/> that the quote is for.
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
        /// Gets or sets the <see cref="ICustomer"/> that the quote is for.
        /// </summary>
        ICustomer IQuote.Customer
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
        /// Indicates whether the customer is a guest.
        /// </summary>
        public virtual bool? CustomerIsGuest
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's last name.
        /// </summary>
        public virtual string CustomerLastName
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's middle name.
        /// </summary>
        public virtual string CustomerMiddleName
        { get; set; }

        /// <summary>
        /// Gets or sets the note to apply to the customer's quote.
        /// </summary>
        public virtual string CustomerNote
        { get; set; }

        /// <summary>
        /// Indicates whether the customer's note should be flagged.
        /// </summary>
        public virtual bool? NotifyCustomerNote
        { get; set; }

        /// <summary>
        /// Gets or sets the customer prefix.
        /// </summary>
        public virtual string CustomerPrefix
        { get; set; }

        /// <summary>
        /// Gets or sets the customer suffix.
        /// </summary>
        public virtual string CustomerSuffix
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's tax class.
        /// </summary>
        public virtual TaxClass CustomerTaxClass
        {
            get
            {
                if (_taxClass == null)
                {
                    _taxClass = new TaxClass();
                }

                return _taxClass;
            }
            set
            {
                _taxClass = value;
            }
        }

        /// <summary>
        /// Gets or sets the customer's tax class.
        /// </summary>
        ITaxClass IQuote.CustomerTaxClass
        {
            get
            {
                return CustomerTaxClass;
            }
            set
            {
                CustomerTaxClass = value.ToTaxClass();
            }
        }

        /// <summary>
        /// Gets or sets the customer's VAT number.
        /// </summary>
        public virtual string CustomerValueAddedTax
        { get; set; }

        /// <summary>
        /// Gets or sets external shipping information for the quote.
        /// </summary>
        public virtual string ExternalShippingInfo
        { get; set; }

        /// <summary>
        /// Gets or sets the gift cards that are applied to the quote.
        /// </summary>
        public virtual string GiftCards
        { get; set; }

        /// <summary>
        /// Gets or sets the total gift cards amount.
        /// </summary>
        public virtual decimal? GiftCardsAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the total gift cards amount that was applied to the quote.
        /// </summary>
        public virtual decimal? GiftCardsAmountUsed
        { get; set; }

        /// <summary>
        /// Gets or sets the gift message to apply to the quote.
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
        /// Gets or sets the gift message to apply to the quote.
        /// </summary>
        IGiftMessage IQuote.GiftMessage
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
        /// Gets or sets the global currency code for the quote.
        /// </summary>
        public virtual string GlobalCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the grand total for the quote.
        /// </summary>
        public virtual decimal? GrandTotal
        { get; set; }

        // Note from Adam (3/6/23):
        //
        // In the Magento database, there are a couple of columns prefixed with "gw_". According to the schema, however,
        // these seem to be deprecated and skipped over. Unless otherwise needed, they will not be mapped in the domain
        // object or in the Fluent mappings.

        /// <summary>
        /// Indicates whether the quote is currently active.
        /// </summary>
        public virtual bool Active
        { get; set; }

        /// <summary>
        /// Indicates whether the quote has been changed.
        /// </summary>
        public virtual bool? IsChanged
        { get; set; }

        /// <summary>
        /// Indicates whether the highest item price rule is in effect.
        /// </summary>
        public virtual bool IsHighestItemPriceRule
        { get; set; }

        /// <summary>
        /// Indicates whether the quote is for a multi-shipment order.
        /// </summary>
        public virtual bool? IsMultiShipping
        { get; set; }

        /// <summary>
        /// Indicates whether the quote is persistent.
        /// </summary>
        public virtual bool? IsPersistent
        { get; set; }

        /// <summary>
        /// Indicates whether the quote is virtual.
        /// </summary>
        public virtual bool? IsVirtual
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of items on the quote.
        /// </summary>
        public virtual uint? ItemsCount
        { get; set; }

        /// <summary>
        /// Gets or sets the total quantity of items on the quote.
        /// </summary>
        public virtual decimal? ItemsQuantity
        { get; set; }

        /// <summary>
        /// Gets or sets the original sales order that the quote was for.
        /// </summary>
        public virtual SalesOrder OriginalOrder
        {
            get
            {
                if (_order == null)
                {
                    _order = new SalesOrder();
                }

                return _order;
            }
            set
            {
                _order = value;
            }
        }

        /// <summary>
        /// Gets or sets the original sales order that the quote was for.
        /// </summary>
        ISalesOrder IQuote.OriginalOrder
        {
            get
            {
                return OriginalOrder;
            }
            set
            {
                OriginalOrder = value.ToSalesOrder();
            }
        }

        /// <summary>
        /// Gets or sets the password hash for the quote.
        /// </summary>
        public virtual string PasswordHash
        { get; set; }

        /// <summary>
        /// Gets or sets the currency code for the quote.
        /// </summary>
        public virtual string QuoteCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the IP address of the machine that generated the quote.
        /// </summary>
        public virtual string RemoteIP
        { get; set; }

        /// <summary>
        /// Gets or sets the reserved order ID.
        /// </summary>
        public virtual string ReservedOrderID
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
        /// Gets or sets the store's currency code with respect to the quote.
        /// </summary>
        public virtual string StoreCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the parent store that the quote applies to.
        /// </summary>
        public virtual Store Store
        {
            get
            {
                if (_store == null)
                {
                    _store = new Store();
                }

                return _store;
            }
            set
            {
                _store = value;
            }
        }

        /// <summary>
        /// Gets or sets the parent store that the quote applies to.
        /// </summary>
        IStore IQuote.Store
        {
            get
            {
                return Store;
            }
            set
            {
                Store = value.ToStore();
            }
        }

        /// <summary>
        /// Gets or sets the store-to-base conversion rate.
        /// </summary>
        public virtual decimal? StoreToBaseRate
        { get; set; }

        /// <summary>
        /// Gets or sets the store-to-quote conversion rate.
        /// </summary>
        public virtual decimal? StoreToQuoteRate
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal of the quote.
        /// </summary>
        public virtual decimal? Subtotal
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal with applied discounts.
        /// </summary>
        public virtual decimal? SubtotalWithDiscount
        { get; set; }

        /// <summary>
        /// Indicates whether the quote triggers a recollection in Magento.
        /// </summary>
        public virtual bool TriggerRecollect
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the quote was updated.
        /// </summary>
        public virtual Instant UpdatedAt
        { get; set; }

        /// <summary>
        /// Indicates whether the customer's balance should be used.
        /// </summary>
        public virtual bool? UseCustomerBalance
        { get; set; }

        /// <summary>
        /// Indicates whether the customer's reward points should be used.
        /// </summary>
        public virtual bool? UseRewardPoints
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Quote"/> class with no arguments.
        /// </summary>
        public Quote()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Quote"/> class with the specified rule ID and <see cref="MagentoServer"/>.
        /// </summary>
        /// <param name="quoteId">Quote ID.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        public Quote(uint quoteId, MagentoServer server)
            : base(quoteId, server)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return (obj == null || !(obj is IQuote)) ? false : Equals(obj as IQuote);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IQuote obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IQuote x, IQuote y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = x.Active == y.Active
                    && String.Equals(x.AppliedRuleIDs, y.AppliedRuleIDs, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.BaseCurrencyCode, y.BaseCurrencyCode, StringComparison.InvariantCultureIgnoreCase)
                    && x.BaseCustomerBalanceAmountUsed.GetValueOrDefault().Equals(y.BaseCustomerBalanceAmountUsed.GetValueOrDefault())
                    && x.BaseGiftCardsAmount.GetValueOrDefault().Equals(y.BaseGiftCardsAmount.GetValueOrDefault())
                    && x.BaseGiftCardsAmountUsed.GetValueOrDefault().Equals(y.BaseGiftCardsAmountUsed.GetValueOrDefault())
                    && x.BaseGrandTotal.GetValueOrDefault().Equals(y.BaseGrandTotal.GetValueOrDefault())
                    && x.BaseRewardCurrencyAmount.GetValueOrDefault().Equals(y.BaseRewardCurrencyAmount.GetValueOrDefault())
                    && x.BaseSubtotal.GetValueOrDefault().Equals(y.BaseSubtotal.GetValueOrDefault())
                    && x.BaseSubtotalWithDiscount.GetValueOrDefault().Equals(y.BaseSubtotalWithDiscount.GetValueOrDefault())
                    && x.BaseToGlobalRate.GetValueOrDefault().Equals(y.BaseToGlobalRate.GetValueOrDefault())
                    && x.BaseToQuoteRate.GetValueOrDefault().Equals(y.BaseToQuoteRate.GetValueOrDefault())
                    && String.Equals(x.CheckoutMethod, y.CheckoutMethod, StringComparison.InvariantCultureIgnoreCase)
                    && x.ConvertedAt.GetValueOrDefault().Equals(y.ConvertedAt.GetValueOrDefault())
                    && String.Equals(x.CouponCode, y.CouponCode, StringComparison.InvariantCultureIgnoreCase)
                    && x.CreatedAt.Equals(y.CreatedAt)
                    && ((x.Customer == null && y.Customer == null) || (x.Customer != null && x.Customer.Equals(y.Customer)))
                    && x.CustomerBalanceAmountUsed.GetValueOrDefault().Equals(y.BaseCustomerBalanceAmountUsed.GetValueOrDefault())
                    && x.CustomerDateOfBirth.GetValueOrDefault().Equals(y.CustomerDateOfBirth.GetValueOrDefault())
                    && String.Equals(x.CustomerEmail, y.CustomerEmail, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.CustomerFirstName, y.CustomerFirstName, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.CustomerGender, y.CustomerGender, StringComparison.InvariantCultureIgnoreCase)
                    && ((x.CustomerGroup == null && y.CustomerGroup == null) || (x.CustomerGroup != null && x.CustomerGroup.Equals(y.CustomerGroup)))
                    && x.CustomerIsGuest.GetValueOrDefault().Equals(y.CustomerIsGuest.GetValueOrDefault())
                    && String.Equals(x.CustomerLastName, y.CustomerLastName, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.CustomerMiddleName, y.CustomerMiddleName, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.CustomerNote, y.CustomerNote, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.CustomerPrefix, y.CustomerPrefix, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.CustomerSuffix, y.CustomerSuffix, StringComparison.InvariantCultureIgnoreCase)
                    && ((x.CustomerTaxClass == null && y.CustomerTaxClass == null) || (x.CustomerTaxClass != null && x.CustomerTaxClass.Equals(y.CustomerTaxClass)))
                    && String.Equals(x.CustomerValueAddedTax, y.CustomerValueAddedTax, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.ExternalShippingInfo, y.ExternalShippingInfo, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.GiftCards, y.GiftCards, StringComparison.InvariantCultureIgnoreCase)
                    && x.GiftCardsAmount.GetValueOrDefault().Equals(y.GiftCardsAmount.GetValueOrDefault())
                    && x.GiftCardsAmountUsed.GetValueOrDefault().Equals(y.GiftCardsAmountUsed.GetValueOrDefault())
                    && ((x.GiftMessage == null && y.GiftMessage == null) || (x.GiftMessage != null && x.GiftMessage.Equals(y.GiftMessage)))
                    && String.Equals(x.GlobalCurrencyCode, y.GlobalCurrencyCode, StringComparison.InvariantCultureIgnoreCase)
                    && x.GrandTotal.GetValueOrDefault().Equals(y.GrandTotal.GetValueOrDefault())
                    && x.IsChanged.GetValueOrDefault().Equals(y.IsChanged.GetValueOrDefault())
                    && x.IsHighestItemPriceRule == y.IsHighestItemPriceRule
                    && x.IsMultiShipping.GetValueOrDefault().Equals(y.IsMultiShipping.GetValueOrDefault())
                    && x.IsPersistent.GetValueOrDefault().Equals(y.IsPersistent.GetValueOrDefault())
                    && x.IsVirtual.GetValueOrDefault().Equals(y.IsVirtual.GetValueOrDefault())
                    && x.ItemsCount.GetValueOrDefault().Equals(y.ItemsCount.GetValueOrDefault())
                    && x.ItemsQuantity.GetValueOrDefault().Equals(y.ItemsQuantity.GetValueOrDefault())
                    && x.NotifyCustomerNote.GetValueOrDefault().Equals(y.NotifyCustomerNote.GetValueOrDefault())
                    && ((x.OriginalOrder == null && y.OriginalOrder == null) || (x.OriginalOrder != null && x.OriginalOrder.Equals(y.OriginalOrder)))
                    && String.Equals(x.PasswordHash, y.PasswordHash, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.QuoteCurrencyCode, y.QuoteCurrencyCode, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.RemoteIP, y.RemoteIP, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.ReservedOrderID, y.ReservedOrderID, StringComparison.InvariantCultureIgnoreCase)
                    && x.RewardCurrencyAmount.GetValueOrDefault().Equals(y.RewardCurrencyAmount.GetValueOrDefault())
                    && x.RewardPointsBalance.GetValueOrDefault().Equals(y.RewardPointsBalance.GetValueOrDefault())
                    && ((x.Store == null && y.Store == null) || (x.Store != null && x.Store.Equals(y.Store)))
                    && String.Equals(x.StoreCurrencyCode, y.StoreCurrencyCode, StringComparison.InvariantCultureIgnoreCase)
                    && x.StoreToBaseRate.GetValueOrDefault().Equals(y.StoreToBaseRate.GetValueOrDefault())
                    && x.StoreToQuoteRate.GetValueOrDefault().Equals(y.StoreToQuoteRate.GetValueOrDefault())
                    && x.Subtotal.GetValueOrDefault().Equals(y.Subtotal.GetValueOrDefault())
                    && x.SubtotalWithDiscount.GetValueOrDefault().Equals(y.SubtotalWithDiscount.GetValueOrDefault())
                    && x.TriggerRecollect == y.TriggerRecollect
                    && x.UpdatedAt.Equals(y.UpdatedAt)
                    && x.UseCustomerBalance.GetValueOrDefault().Equals(y.UseCustomerBalance.GetValueOrDefault())
                    && x.UseRewardPoints.GetValueOrDefault().Equals(y.UseRewardPoints.GetValueOrDefault());
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
        public virtual int GetHashCode(IQuote obj)
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

