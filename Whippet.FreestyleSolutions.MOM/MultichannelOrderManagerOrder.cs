using System;
using System.Data;
using System.Text;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Extensions;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Json.Newtonsoft.Extensions;
using Athi.Whippet.Json;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents an individual order in the Multichannel Order Manager.
    /// </summary>
    public class MultichannelOrderManagerOrder : MultichannelOrderManagerEntity, IMultichannelOrderManagerOrderSupport, IWhippetEntity, IMultichannelOrderManagerPurchaseOrderSupport, IWhippetEntityExternalDataRowImportMapper, IEqualityComparer<IMultichannelOrderManagerOrder>, IMultichannelOrderManagerEntity, IMultichannelOrderManagerOrder, IWhippetEntityDynamicImportMapper
    {
        private string _clKey;
        private string _paymentMethod;
        private string _cardNum;
        private string _cardType;
        private string _expiration;
        private string _approval;
        private string _shipList;
        private string _userId;
        private string _lastUser;
        private string _extra2;
        private string _checkNumber;
        private string _cZone;
        private string _salesId;
        private string _catalogCode;
        private string _orderStatus2;
        private string _accountState;
        private string _alternateOrderNumber;
        private string _internetId;
        private string _creditCardCID;
        private string _orderType;
        private string _purchaseOrderNumber;
        private string _cardHolder;
        private string _holdNote;
        private string _tpShipAccount;
        private string _tpShipCreditCard;
        private string _tpShipExp;
        private string _processedBy;
        private string _issueNumber;
        private string _frDate;
        private string _orderPromo;
        private string _routingNumber;
        private string _accountNumber;
        private string _accountType;
        private string _bankName;
        private string _paypalId;
        private string _holdCode;
        private string _costTable;

        /// <summary>
        /// Gets or sets the unique ID of the object.
        /// </summary>
        public new long ID
        {
            get
            {
                return MomObjectID;
            }
            set
            {
                MomObjectID = value;
            }
        }

        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        [JsonProperty("orderNumber")]
        public virtual long OrderNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the customer number.
        /// </summary>
        [JsonProperty("customerNumber")]
        public virtual long CustomerNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the source key for the order.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("sourceKey")]
        public virtual string SourceKey
        {
            get
            {
                return _clKey;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(SourceKey)].Column);
                _clKey = value;
            }
        }

        /// <summary>
        /// Specifies the entry date of the order.
        /// </summary>
        [JsonProperty("orderDate")]
        public virtual DateTime? OrderDate
        { get; set; }

        /// <summary>
        /// Specifies the type of hold on the order.
        /// </summary>
        [JsonProperty("holdType")]
        public virtual char HoldType
        { get; set; }

        /// <summary>
        /// Indicates whether the order is on a permanent hold.
        /// </summary>
        [JsonProperty("permanentHold")]
        public virtual bool PermanentHold
        { get; set; }

        /// <summary>
        /// Indicates whether the system has placed a hold on the order.
        /// </summary>
        [JsonProperty("systemHold")]
        public virtual bool SystemHold
        { get; set; }

        /// <summary>
        /// Specifies the date the order was held.
        /// </summary>
        [JsonProperty("holdDate")]
        public virtual DateTime? HoldDate
        { get; set; }

        /// <summary>
        /// Specifies the next release date of line items on hold.
        /// </summary>
        [JsonProperty("releaseDate")]
        public virtual DateTime? ReleaseDate
        { get; set; }

        /// <summary>
        /// Specifies the check clearing date.
        /// </summary>
        [JsonProperty("checkClearDate")]
        public virtual DateTime? CheckClearDate
        { get; set; }

        /// <summary>
        /// Specifies the date the order is expected to be shipped.
        /// </summary>
        [JsonProperty("shipDate")]
        public virtual DateTime? ShipDate
        { get; set; }

        /// <summary>
        /// Payment control field for check and credit.
        /// </summary>
        [JsonProperty("check")]
        public virtual char Check
        { get; set; }

        /// <summary>
        /// Method of payment.
        /// </summary>
        [JsonProperty("paymentMethod")]
        public virtual string PaymentMethod
        {
            get
            {
                return _paymentMethod;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(PaymentMethod)].Column);
                _paymentMethod = value;
            }
        }

        /// <summary>
        /// Specifies that Cash On Delivery (COD) be cash only.
        /// </summary>
        [JsonProperty("cashOnly")]
        public virtual bool CashOnly
        { get; set; }

        /// <summary>
        /// Specifies the credit card number.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("creditCardNumber")]
        public virtual string CreditCardNumber
        {
            get
            {
                return _cardNum;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(CreditCardNumber)].Column);
                _cardNum = value;
            }
        }

        /// <summary>
        /// Specifies the credit card type.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("creditCardType")]
        public virtual string CreditCardType
        {
            get
            {
                return _cardType;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(CreditCardType)].Column);
                _cardType = value;
            }
        }

        /// <summary>
        /// Gets or sets the credit card expiration date in 'MM/YY' format.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("creditCardExpirationDate")]
        public virtual string CreditCardExpirationDate
        {
            get
            {
                return _expiration;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(CreditCardExpirationDate)].Column);
                _expiration = value;
            }
        }

        /// <summary>
        /// Gets or sets the last approval number for the credit card.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("creditCardApprovalNumber")]
        public virtual string CreditCardApprovalNumber
        {
            get
            {
                return _approval;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(CreditCardApprovalNumber)].Column);
                _approval = value;
            }
        }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        [JsonProperty("cccorr")]
        public virtual bool CCCORR
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping method for the order.
        /// </summary>
        [JsonProperty("shippingMethod")]
        public virtual string ShippingMethod
        {
            get
            {
                return _shipList;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(ShippingMethod)].Column);
                _shipList = value;
            }
        }

        /// <summary>
        /// Total tax for the order.
        /// </summary>
        [JsonProperty("tax")]
        public virtual decimal Tax
        { get; set; }

        /// <summary>
        /// Total shipping costs for the order.
        /// </summary>
        [JsonProperty("shipping")]
        public virtual decimal Shipping
        { get; set; }

        /// <summary>
        /// Total finance charges for the order.
        /// </summary>
        [JsonProperty("otherCosts")]
        public virtual decimal OtherCosts
        { get; set; }

        /// <summary>
        /// Total amount of payments made on the order to date.
        /// </summary>
        [JsonProperty("totalPayments")]
        public virtual decimal TotalPayments
        { get; set; }

        /// <summary>
        /// Total amount of order including all merchandise.
        /// </summary>
        [JsonProperty("orderTotal")]
        public virtual decimal OrderTotal
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        [JsonProperty("charged")]
        public virtual decimal Charged
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        [JsonProperty("correctin")]
        public virtual bool CORRECTIN
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        [JsonProperty("correctlc")]
        public virtual char CORRECTLC
        { get; set; }

        /// <summary>
        /// Specifies whether the order has been invoiced.
        /// </summary>
        [JsonProperty("invoiced")]
        public virtual bool Invoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the last invoice part code.
        /// </summary>
        [JsonProperty("lastInvoicePartCode")]
        public virtual char LastInvoicePartCode
        { get; set; }

        /// <summary>
        /// Specifies the total number of credit card vouchers generated.
        /// </summary>
        [JsonProperty("creditCardVouchers")]
        public virtual int CreditCardVouchers
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        [JsonProperty("labeled")]
        public virtual bool Labeled
        { get; set; }

        /// <summary>
        /// Number of extra box labels to generate.
        /// </summary>
        [JsonProperty("labels")]
        public virtual int Labels
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        [JsonProperty("dlabels")]
        public virtual int DLABELS
        { get; set; }

        /// <summary>
        /// Indicates whether the order is fully paid for and all merchandise has been shipped.
        /// </summary>
        [JsonProperty("completed")]
        public virtual bool Completed
        { get; set; }

        /// <summary>
        /// Indicates whether the order has been cancelled.
        /// </summary>
        [JsonProperty("cancelled")]
        public virtual bool Cancelled
        { get; set; }

        /// <summary>
        /// Specifies whether some items have already been shipped.
        /// </summary>
        [JsonProperty("multiship")]
        public virtual bool Multiship
        { get; set; }

        /// <summary>
        /// Specifies the number of items invoiced.
        /// </summary>
        [JsonProperty("itemsInvoicedCount")]
        public virtual decimal ItemsInvoicedCount
        { get; set; }

        /// <summary>
        /// Specifies the number of items filled.
        /// </summary>
        [JsonProperty("itemsFilled")]
        public virtual decimal ItemsFilled
        { get; set; }

        /// <summary>
        /// Specifies the number of items packed.
        /// </summary>
        [JsonProperty("itemsPacked")]
        public virtual decimal ItemsPacked
        { get; set; }

        /// <summary>
        /// Specifies the number of items shipped.
        /// </summary>
        [JsonProperty("itemsShipped")]
        public virtual decimal ItemsShipped
        { get; set; }

        /// <summary>
        /// Specifies the number of items backordered.
        /// </summary>
        [JsonProperty("itemsBackOrdered")]
        public virtual decimal ItemsBackOrdered
        { get; set; }

        /// <summary>
        /// Specifies the value (in dollars) of back ordered merchandise.
        /// </summary>
        [JsonProperty("backorderedItemseValue")]
        public virtual decimal BackorderedItemsValue
        { get; set; }

        /// <summary>
        /// Specifies the value (in dollars) of drop-shipped merchandise.
        /// </summary>
        [JsonProperty("dropShippedItemsValue")]
        public virtual decimal DropShippedItemsValue
        { get; set; }

        /// <summary>
        /// Specifies the value (in dollars) of items currently on hold.
        /// </summary>
        [JsonProperty("onHoldItemsValue")]
        public virtual decimal OnHoldItemsValue
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of items in the order.
        /// </summary>
        [JsonProperty("orderItemCount")]
        public virtual decimal OrderItemCount
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of items currently on hold.
        /// </summary>
        [JsonProperty("onHoldItemsCount")]
        public virtual decimal OnHoldItemsCount
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        [JsonProperty("extra")]
        public virtual decimal Extra
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping address customer number ID.
        /// </summary>
        [JsonProperty("shippingAddressID")]
        public virtual long ShippingAddressID
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of drop-shipped items ordered.
        /// </summary>
        [JsonProperty("dropShippedItemsCount")]
        public virtual decimal DropShippedItemsCount
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of drop-shipped items not yet ordered.
        /// </summary>
        [JsonProperty("dropShippedItemsOnHoldCount")]
        public virtual decimal DropShippedItemsOnHoldCount
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of drop-shipped items verified.
        /// </summary>
        [JsonProperty("dropShippedItemsVerifiedCount")]
        public virtual decimal DropShippedItemsVerifiedCount
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of drop-shipped items packed.
        /// </summary>
        [JsonProperty("dropShippedItemsPacked")]
        public virtual decimal DropShippedItemsPacked
        { get; set; }

        /// <summary>
        /// Specifies the number of drop-ship items shipped.
        /// </summary>
        [JsonProperty("dropShippedItemsShipped")]
        public virtual decimal DropShippedItemsShipped
        { get; set; }

        /// <summary>
        /// Specifies the total number of drop-ship items.
        /// </summary>
        [JsonProperty("dropShippedItemsTotalCount")]
        public virtual decimal DropShippedItemsTotalCount
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        [JsonProperty("processed")]
        public virtual bool Processed
        { get; set; }

        /// <summary>
        /// Gets or sets the user ID who created the order.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("user")]
        public virtual string User
        {
            get
            {
                return _userId;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(User)].Column);
                _userId = value;
            }
        }

        /// <summary>
        /// Gets or sets the user ID who last accessed the order.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("lastUser")]
        public virtual string LastUser
        {
            get
            {
                return _lastUser;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(LastUser)].Column);
                _lastUser = value;
            }
        }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        [JsonProperty("extra2")]
        public virtual string EXTRA2
        {
            get
            {
                return _extra2;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(EXTRA2)].Column);
                _extra2 = value;
            }
        }

        /// <summary>
        /// Gets or sets the check number used in payment for the order.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("checkNumber")]
        public virtual string CheckNumber
        {
            get
            {
                return _checkNumber;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(CheckNumber)].Column);
                _checkNumber = value;
            }
        }

        /// <summary>
        /// Specifies the total number of previous orders placed.
        /// </summary>
        [JsonProperty("previousOrdersPlaced")]
        public virtual int PreviousOrdersPlaced
        { get; set; }

        /// <summary>
        /// System determined zone.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("zone")]
        public virtual string Zone
        {
            get
            {
                return _cZone;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(Zone)].Column);
                _cZone = value;
            }
        }

        /// <summary>
        /// Gets or sets the cost table.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("costTable")]
        public virtual string CostTable
        {
            get
            {
                return _costTable;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(CostTable)].Column);
                _costTable = value;
            }
        }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        [JsonProperty("picked")]
        public virtual bool Picked
        { get; set; }

        /// <summary>
        /// Value (in dollars) of tax exempt merchandise.
        /// </summary>
        [JsonProperty("taxExemptValue")]
        public virtual decimal TaxExemptValue
        { get; set; }

        /// <summary>
        /// Indicates the type of shipping address.
        /// </summary>
        [JsonProperty("shippingAddressType")]
        public virtual char ShippingAddressType
        { get; set; }

        /// <summary>
        /// Gets or sets the national tax rate.
        /// </summary>
        [JsonProperty("nationalTaxRate")]
        public virtual decimal NationalTaxRate
        { get; set; }

        /// <summary>
        /// Gets or sets the state/province tax rate.
        /// </summary>
        [JsonProperty("stateProvinceTaxRate")]
        public virtual decimal StateProvinceTaxRate
        { get; set; }

        /// <summary>
        /// Gets or sets the county tax rate.
        /// </summary>
        [JsonProperty("countyTaxRate")]
        public virtual decimal CountyTaxRate
        { get; set; }

        /// <summary>
        /// Gets or sets the city tax rate.
        /// </summary>
        [JsonProperty("cityTaxRate")]
        public virtual decimal CityTaxRate
        { get; set; }

        /// <summary>
        /// Indicates whether shipping charges should be taxed.
        /// </summary>
        [JsonProperty("taxShipping")]
        public virtual bool TaxShipping
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        [JsonProperty("dueDays")]
        public virtual int DueDays
        { get; set; }

        /// <summary>
        /// Gets or sets the total number (in dollars) of billed merchandise.
        /// </summary>
        [JsonProperty("billedMerchandiseTotal")]
        public virtual decimal BilledMerchandiseTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the salesperson ID for this order.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("salesID")]
        public virtual string SalesID
        {
            get
            {
                return _salesId;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(SalesID)].Column);
                _salesId = value;
            }
        }

        /// <summary>
        /// Gets or sets the total amount (in dollars) of billed shipping charges.
        /// </summary>
        [JsonProperty("billedShippingChargesTotal")]
        public virtual decimal BilledShippingChargesTotal
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        [JsonProperty("notyetused")]
        public virtual bool NOTYETUSED
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount (in dollars) of billed taxes.
        /// </summary>
        [JsonProperty("billedTaxesTotal")]
        public virtual decimal BilledTaxesTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount (in dollars) of billed non-taxable merchandise.
        /// </summary>
        [JsonProperty("billedNonTaxableMerchandiseTotal")]
        public virtual decimal BilledNonTaxableMerchandiseTotal
        { get; set; }

        /// <summary>
        /// Indicates whether shipping charges are modified outside of their system calculation.
        /// </summary>
        [JsonProperty("shippingChargesModified")]
        public virtual bool ShippingChargesModified
        { get; set; }

        /// <summary>
        /// Catalog code for the order.
        /// </summary>
        [JsonProperty("catalogCode")]
        public virtual string CatalogCode
        {
            get
            {
                return _catalogCode;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(CatalogCode)].Column);
                _catalogCode = value;
            }
        }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        [JsonProperty("taxModified")]
        public virtual bool TaxModified
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("order_st2")]
        public virtual string ORDER_ST2
        {
            get
            {
                return _orderStatus2;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(ORDER_ST2)].Column);
                _orderStatus2 = value;
            }
        }

        /// <summary>
        /// Indicates the interest level for a telemarketing call.
        /// </summary>
        [JsonProperty("telemarketingCallInterestLevel")]
        public virtual int TelemarketingCallInterestLevel
        { get; set; }

        /// <summary>
        /// Indicates whether a telemarketing call was made for the current order.
        /// </summary>
        [JsonProperty("telemarketingCall")]
        public virtual bool TelemarketingCall
        { get; set; }

        /// <summary>
        /// Gets or sets the overpayment amount on the order.
        /// </summary>
        [JsonProperty("overpaymentAmount")]
        public virtual decimal OverpaymentAmount
        { get; set; }

        /// <summary>
        /// Indicates whether the order needs to be weighed.
        /// </summary>
        [JsonProperty("weightNeeded")]
        public virtual bool WeightNeeded
        { get; set; }

        /// <summary>
        /// Gets or sets the accounting state of the order.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("accountingState")]
        public virtual string AccountingState
        {
            get
            {
                return _accountState;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(AccountingState)].Column);
                _accountState = value;
            }
        }

        /// <summary>
        /// Specifies the amount (in dollars) of the next payment.
        /// </summary>
        [JsonProperty("nextPaymentAmount")]
        public virtual decimal NextPaymentAmount
        { get; set; }

        /// <summary>
        /// Specifies the total amount (in dollars) of billed finance charges.
        /// </summary>
        [JsonProperty("financeChargesTotal")]
        public virtual decimal FinanceChargesTotal
        { get; set; }

        /// <summary>
        /// Gets or sets an alternate order ID for the current order.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("alternateOrderID")]
        public virtual string AlternateOrderID
        {
            get
            {
                return _alternateOrderNumber;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(AlternateOrderID)].Column);
                _alternateOrderNumber = value;
            }
        }

        /// <summary>
        /// Indicates that shipping charges will not be taxed at the national level.
        /// </summary>
        [JsonProperty("noNationalTaxShippingCharges")]
        public virtual bool NoNationalTaxShippingCharges
        { get; set; }

        /// <summary>
        /// Indicates whether the current order is a quotation for a customer.
        /// </summary>
        [JsonProperty("isQuote")]
        public virtual bool IsQuote
        { get; set; }

        /// <summary>
        /// Specifies the order number assigned by SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("internetID")]
        public virtual string InternetID
        {
            get
            {
                return _internetId;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(InternetID)].Column);
                _internetId = value;
            }
        }

        /// <summary>
        /// Indicates whether the current order is a point-of-sale order.
        /// </summary>
        [JsonProperty("pointOfSaleOrder")]
        public virtual bool PointOfSaleOrder
        { get; set; }

        /// <summary>
        /// Indicates whether the credit card is in the customer's list.
        /// </summary>
        [JsonProperty("creditCardInCustomerList")]
        public virtual bool CreditCardInCustomerList
        { get; set; }

        /// <summary>
        /// Gets or sets the note for why the order is on hold.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("holdNote")]
        public virtual string HoldNote
        {
            get
            {
                return _holdNote;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(HoldNote)].Column);
                _holdNote = value;
            }
        }

        /// <summary>
        /// Gets or sets the "sold to" customer number.
        /// </summary>
        [JsonProperty("soldToCustomerID")]
        public virtual long SoldToCustomerID
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        [JsonProperty("discountPercent")]
        public virtual decimal DiscountPercent
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        [JsonProperty("discountDays")]
        public virtual decimal DiscountDays
        { get; set; }

        /// <summary>
        /// Indicates whether the order has multiple payment methods.
        /// </summary>
        [JsonProperty("multiplePaymentMethods")]
        public virtual bool MultiplePaymentMethods
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("cid")]
        public virtual string CID
        {
            get
            {
                return _creditCardCID;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(CID)].Column);
                _creditCardCID = value;
            }
        }

        /// <summary>
        /// Gets or sets the total points used on the order.
        /// </summary>
        [JsonProperty("pointsUsed")]
        public virtual int PointsUsed
        { get; set; }

        /// <summary>
        /// Gets or sets the order type.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("orderType")]
        public virtual string OrderType
        {
            get
            {
                return _orderType;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(OrderType)].Column);
                _orderType = value;
            }
        }

        /// <summary>
        /// Gets or sets the purchase order number associated with the order.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("purchaseOrder")]
        public virtual string PurchaseOrder
        {
            get
            {
                return _purchaseOrderNumber;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(PurchaseOrder)].Column);
                _purchaseOrderNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the purchase order number associated with the order.
        /// </summary>
        long IMultichannelOrderManagerPurchaseOrderSupport.PurchaseOrder
        {
            get
            {
                long poNumber = -1;

                if (!Int64.TryParse(PurchaseOrder, out poNumber))
                {
                    poNumber = 0;
                }

                return poNumber;
            }
            set
            {
                PurchaseOrder = Convert.ToString(value);
            }
        }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("cardHolderName")]
        public virtual string CardHolderName
        {
            get
            {
                return _cardHolder;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(CardHolderName)].Column);
                _cardHolder = value;
            }
        }

        /// <summary>
        /// Indicates whether the order needs scanning.
        /// </summary>
        [JsonProperty("needsScanning")]
        public virtual bool NeedsScanning
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        [JsonProperty("need_gc")]
        public virtual bool NEED_GC
        { get; set; }

        /// <summary>
        /// Indicates whether the order has been billed.
        /// </summary>
        [JsonProperty("billed")]
        public virtual bool Billed
        { get; set; }

        /// <summary>
        /// Specifies the total amount (in dollars) of merchandise ready to bill.
        /// </summary>
        [JsonProperty("merchandiseReadyToBill")]
        public virtual decimal MerchandiseReadyToBill
        { get; set; }

        /// <summary>
        /// Specifies the total amount (in dollars) of taxes ready to bill.
        /// </summary>
        [JsonProperty("taxesReadyToBill")]
        public virtual decimal TaxesReadyToBill
        { get; set; }

        /// <summary>
        /// Specifies the total amount (in dollars) of merchandise not ready to bill.
        /// </summary>
        [JsonProperty("merchandiseNotReadyToBill")]
        public virtual decimal MerchandiseNotReadyToBill
        { get; set; }

        /// <summary>
        /// Specifies the total amount (in dollars) of taxes not ready to bill.
        /// </summary>
        [JsonProperty("taxesNotReadyToBill")]
        public virtual decimal TaxesNotReadyToBill
        { get; set; }

        /// <summary>
        /// Specifies the total amount (in dollars) of merchandise packed.
        /// </summary>
        [JsonProperty("merchandisePackedTotal")]
        public virtual decimal MerchandisePackedTotal
        { get; set; }

        /// <summary>
        /// Specifies the total amount (in dollars) of taxes on packed merchandise.
        /// </summary>
        [JsonProperty("merchandisePackedTaxTotal")]
        public virtual decimal MerchandisePackedTaxTotal
        { get; set; }

        /// <summary>
        /// Specifies the total amount (in dollars) of the shipping total on packed merchandise.
        /// </summary>
        [JsonProperty("merchandisePackedShippingTotal")]
        public virtual decimal MerchandisePackedShippingTotal
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        [JsonProperty("tpshiptype")]
        public virtual int TPSHIPTYPE
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        [JsonProperty("tpshipwhat")]
        public virtual char TPSHIPWHAT
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("tpshipacct")]
        public virtual string TPSHIPACCT
        {
            get
            {
                return _tpShipAccount;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(TPSHIPACCT)].Column);
                _tpShipAccount = value;
            }
        }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("tpshipcc")]
        public virtual string TPSHIPCC
        {
            get
            {
                return _tpShipCreditCard;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(TPSHIPCC)].Column);
                _tpShipCreditCard = value;
            }
        }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("tpshipexp")]
        public virtual string TPSHIPEXP
        {
            get
            {
                return _tpShipExp;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(TPSHIPEXP)].Column);
                _tpShipExp = value;
            }
        }

        /// <summary>
        /// Specifies the date and time the order was created.
        /// </summary>
        [JsonProperty("orderTimestamp")]
        public virtual DateTime? OrderTimestamp
        { get; set; }

        /// <summary>
        /// Freight collected flag for UPS 3rd-party billing.
        /// </summary>
        [JsonProperty("freightCollected")]
        public virtual bool FreightCollected
        { get; set; }

        /// <summary>
        /// Indicates whether the order was placed over the internet.
        /// </summary>
        [JsonProperty("internetOrder")]
        public virtual bool InternetOrder
        { get; set; }

        /// <summary>
        /// Specifies the user who processed the order.
        /// </summary>
        [JsonProperty("processedBy")]
        public virtual string ProcessedBy
        {
            get
            {
                return _processedBy;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(ProcessedBy)].Column);
                _processedBy = value;
            }
        }

        /// <summary>
        /// Used by Authorize.net.
        /// </summary>
        [JsonProperty("creditCardInquiryRequired")]
        public virtual bool CreditCardInquiryRequired
        { get; set; }

        /// <summary>
        /// Indicates that the credit card was removed from the customer's card list.
        /// </summary>
        [JsonProperty("creditCardRemoved")]
        public virtual bool CreditCardRemoved
        { get; set; }

        /// <summary>
        /// Gets or sets the item ID of the additional item added from order promotion.
        /// </summary>
        [JsonProperty("itemID")]
        public virtual long ItemID
        { get; set; }

        /// <summary>
        /// Indicates whether a discount is applied to the order from an order promotion.
        /// </summary>
        [JsonProperty("discountOrder")]
        public virtual bool DiscountOrder
        { get; set; }

        /// <summary>
        /// Specifies the order priority.
        /// </summary>
        [JsonProperty("priority")]
        public virtual char Priority
        { get; set; }

        /// <summary>
        /// For use in the United Kingdom only.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("issueNumber")]
        public virtual string IssueNumber
        {
            get
            {
                return _issueNumber;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(IssueNumber)].Column);
                _issueNumber = value;
            }
        }

        /// <summary>
        /// For use in the United Kingdom only.
        /// </summary>
        [JsonProperty("frdate")]
        public virtual string FRDATE
        {
            get
            {
                return _frDate;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(FRDATE)].Column);
                _frDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the order promotion code.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("promotionCode")]
        public virtual string PromotionCode
        {
            get
            {
                return _orderPromo;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(PromotionCode)].Column);
                _orderPromo = value;
            }
        }

        /// <summary>
        /// Indicates whether the entire order--including backorder items--should be charged.
        /// </summary>
        [JsonProperty("chargeEntireOrder")]
        public virtual bool ChargeEntireOrder
        { get; set; }

        /// <summary>
        /// Indicates whether an order promotion has not been applied.
        /// </summary>
        [JsonProperty("noPromotionApplied")]
        public virtual bool NoPromotionApplied
        { get; set; }

        /// <summary>
        /// Gets or sets the bank routing number for eCheck payment.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("bankRoutingNumber")]
        public virtual string BankRoutingNumber
        {
            get
            {
                return _routingNumber;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(BankRoutingNumber)].Column);
                _routingNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the bank account number for eCheck payment.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("bankAccountNumber")]
        public virtual string BankAccountNumber
        {
            get
            {
                return _accountNumber;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(BankAccountNumber)].Column);
                _accountNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the bank account type for eCheck payment.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("bankAccountType")]
        public virtual string BankAccountType
        {
            get
            {
                return _accountType;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(BankAccountType)].Column);
                _accountType = value;
            }
        }

        /// <summary>
        /// Gets or sets the bank name for eCheck payment.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("bankName")]
        public virtual string BankName
        {
            get
            {
                return _bankName;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(BankName)].Column);
                _bankName = value;
            }
        }

        /// <summary>
        /// Gets or sets the PayPal account ID for the order's payment method.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("payPalID")]
        public virtual string PayPalID
        {
            get
            {
                return _paypalId;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(PayPalID)].Column);
                _paypalId = value;
            }
        }

        /// <summary>
        /// For use in the United Kingdom only.
        /// </summary>
        [JsonProperty("pinEntry")]
        public virtual bool PinEntry
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        [JsonProperty("encryptionType")]
        public virtual int EncryptionType
        { get; set; }

        /// <summary>
        /// Indicates that the order has produced an invalid UPS label.
        /// </summary>
        [JsonProperty("badLabel")]
        public virtual bool BadLabel
        { get; set; }

        /// <summary>
        /// For orders paid via invoice, indicates the date the order will be due for payment.
        /// </summary>
        [JsonProperty("dueDate")]
        public virtual DateTime? DueDate
        { get; set; }

        /// <summary>
        /// Specifies the order hold reason code selected.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("holdReasonCode")]
        public virtual string HoldReasonCode
        {
            get
            {
                return _holdCode;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(HoldReasonCode)].Column);
                _holdCode = value;
            }
        }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        [JsonProperty("orderSet")]
        public virtual bool OrderSet
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        [JsonProperty("urlID")]
        public virtual int UrlID
        { get; set; }

        /// <summary>
        /// Gets the external table name or <see langword="null"/> if the data source is not stored in a database. This property is read-only.
        /// </summary>
        protected override string ExternalTableName
        {
            get
            {
                return MultichannelOrderManagerDatabaseConstants.Tables.ORDERS;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerOrder"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerOrder()
            : base()
        { }

        /// <summary>
        /// Creates a <see cref="WhippetDataRowImportMap"/> object that contains a mapping for the current entity.
        /// </summary>
        /// <returns><see cref="WhippetDataRowImportMap"/> object.</returns>
        public override WhippetDataRowImportMap CreateImportMap()
        {
            return new WhippetDataRowImportMap(new[] {
                new WhippetDataRowImportMapEntry(nameof(OrderNumber), MultichannelOrderManagerDatabaseConstants.Columns.ORDERNO),
                new WhippetDataRowImportMapEntry(nameof(CustomerNumber), MultichannelOrderManagerDatabaseConstants.Columns.CUSTNUM),
                new WhippetDataRowImportMapEntry(nameof(SourceKey), MultichannelOrderManagerDatabaseConstants.Columns.CL_KEY),
                new WhippetDataRowImportMapEntry(nameof(OrderDate), MultichannelOrderManagerDatabaseConstants.Columns.ODR_DATE),
                new WhippetDataRowImportMapEntry(nameof(HoldType), MultichannelOrderManagerDatabaseConstants.Columns.HOLD_TYPE),
                new WhippetDataRowImportMapEntry(nameof(PermanentHold), MultichannelOrderManagerDatabaseConstants.Columns.PERM_HOLD),
                new WhippetDataRowImportMapEntry(nameof(SystemHold), MultichannelOrderManagerDatabaseConstants.Columns.SYS_HOLD),
                new WhippetDataRowImportMapEntry(nameof(HoldDate), MultichannelOrderManagerDatabaseConstants.Columns.HOLD_DATE),
                new WhippetDataRowImportMapEntry(nameof(ReleaseDate), MultichannelOrderManagerDatabaseConstants.Columns.REL_DATE),
                new WhippetDataRowImportMapEntry(nameof(CheckClearDate), MultichannelOrderManagerDatabaseConstants.Columns.CLEAR_DATE),
                new WhippetDataRowImportMapEntry(nameof(ShipDate), MultichannelOrderManagerDatabaseConstants.Columns.SHIP_DATE),
                new WhippetDataRowImportMapEntry(nameof(Check), MultichannelOrderManagerDatabaseConstants.Columns.CHECK),
                new WhippetDataRowImportMapEntry(nameof(PaymentMethod), MultichannelOrderManagerDatabaseConstants.Columns.PAYMETHOD),
                new WhippetDataRowImportMapEntry(nameof(CashOnly), MultichannelOrderManagerDatabaseConstants.Columns.CASHONLY),
                new WhippetDataRowImportMapEntry(nameof(CreditCardNumber), MultichannelOrderManagerDatabaseConstants.Columns.CARDNUM),
                new WhippetDataRowImportMapEntry(nameof(CreditCardType), MultichannelOrderManagerDatabaseConstants.Columns.CARDTYPE),
                new WhippetDataRowImportMapEntry(nameof(CreditCardExpirationDate), MultichannelOrderManagerDatabaseConstants.Columns.EXP),
                new WhippetDataRowImportMapEntry(nameof(CreditCardApprovalNumber), MultichannelOrderManagerDatabaseConstants.Columns.APPROVAL),
                new WhippetDataRowImportMapEntry(nameof(CCCORR), MultichannelOrderManagerDatabaseConstants.Columns.CCCORR),
                new WhippetDataRowImportMapEntry(nameof(ShippingMethod), MultichannelOrderManagerDatabaseConstants.Columns.SHIPLIST),
                new WhippetDataRowImportMapEntry(nameof(Tax), MultichannelOrderManagerDatabaseConstants.Columns.TAX),
                new WhippetDataRowImportMapEntry(nameof(Shipping), MultichannelOrderManagerDatabaseConstants.Columns.SHIPPING),
                new WhippetDataRowImportMapEntry(nameof(OtherCosts), MultichannelOrderManagerDatabaseConstants.Columns.OTHERCOST),
                new WhippetDataRowImportMapEntry(nameof(TotalPayments), MultichannelOrderManagerDatabaseConstants.Columns.CHECKAMOUN),
                new WhippetDataRowImportMapEntry(nameof(OrderTotal), MultichannelOrderManagerDatabaseConstants.Columns.ORD_TOTAL),
                new WhippetDataRowImportMapEntry(nameof(Charged), MultichannelOrderManagerDatabaseConstants.Columns.CHARGED),
                new WhippetDataRowImportMapEntry(nameof(CORRECTIN), MultichannelOrderManagerDatabaseConstants.Columns.CORRECTIN),
                new WhippetDataRowImportMapEntry(nameof(CORRECTLC), MultichannelOrderManagerDatabaseConstants.Columns.CORRECTLC),
                new WhippetDataRowImportMapEntry(nameof(Invoiced), MultichannelOrderManagerDatabaseConstants.Columns.INVOICED),
                new WhippetDataRowImportMapEntry(nameof(LastInvoicePartCode), MultichannelOrderManagerDatabaseConstants.Columns.LASTINV),
                new WhippetDataRowImportMapEntry(nameof(CreditCardVouchers), MultichannelOrderManagerDatabaseConstants.Columns.VCOUNT),
                new WhippetDataRowImportMapEntry(nameof(Labeled), MultichannelOrderManagerDatabaseConstants.Columns.LABELED),
                new WhippetDataRowImportMapEntry(nameof(Labels), MultichannelOrderManagerDatabaseConstants.Columns.LABELS),
                new WhippetDataRowImportMapEntry(nameof(DLABELS), MultichannelOrderManagerDatabaseConstants.Columns.DLABELS),
                new WhippetDataRowImportMapEntry(nameof(Completed), MultichannelOrderManagerDatabaseConstants.Columns.COMPLETED),
                new WhippetDataRowImportMapEntry(nameof(Cancelled), MultichannelOrderManagerDatabaseConstants.Columns.CAN_ORD),
                new WhippetDataRowImportMapEntry(nameof(Multiship), MultichannelOrderManagerDatabaseConstants.Columns.MULTISHIP),
                new WhippetDataRowImportMapEntry(nameof(ItemsInvoicedCount), MultichannelOrderManagerDatabaseConstants.Columns.NINV),
                new WhippetDataRowImportMapEntry(nameof(ItemsFilled), MultichannelOrderManagerDatabaseConstants.Columns.NFILL),
                new WhippetDataRowImportMapEntry(nameof(ItemsPacked), MultichannelOrderManagerDatabaseConstants.Columns.NPACK),
                new WhippetDataRowImportMapEntry(nameof(ItemsShipped), MultichannelOrderManagerDatabaseConstants.Columns.NSHIP),
                new WhippetDataRowImportMapEntry(nameof(ItemsBackOrdered), MultichannelOrderManagerDatabaseConstants.Columns.NBOR),
                new WhippetDataRowImportMapEntry(nameof(BackorderedItemsValue), MultichannelOrderManagerDatabaseConstants.Columns.VBOR),
                new WhippetDataRowImportMapEntry(nameof(DropShippedItemsValue), MultichannelOrderManagerDatabaseConstants.Columns.VDSB),
                new WhippetDataRowImportMapEntry(nameof(OnHoldItemsValue), MultichannelOrderManagerDatabaseConstants.Columns.VITEMHOLDS),
                new WhippetDataRowImportMapEntry(nameof(OrderItemCount), MultichannelOrderManagerDatabaseConstants.Columns.NALL),
                new WhippetDataRowImportMapEntry(nameof(OnHoldItemsCount), MultichannelOrderManagerDatabaseConstants.Columns.NITEMHOLDS),
                new WhippetDataRowImportMapEntry(nameof(Extra), MultichannelOrderManagerDatabaseConstants.Columns.EXTRA),
                new WhippetDataRowImportMapEntry(nameof(ShippingAddressID), MultichannelOrderManagerDatabaseConstants.Columns.SHIPNUM),
                new WhippetDataRowImportMapEntry(nameof(DropShippedItemsCount), MultichannelOrderManagerDatabaseConstants.Columns.DORD),
                new WhippetDataRowImportMapEntry(nameof(DropShippedItemsOnHoldCount), MultichannelOrderManagerDatabaseConstants.Columns.DBOR),
                new WhippetDataRowImportMapEntry(nameof(DropShippedItemsVerifiedCount), MultichannelOrderManagerDatabaseConstants.Columns.DFILL),
                new WhippetDataRowImportMapEntry(nameof(DropShippedItemsPacked), MultichannelOrderManagerDatabaseConstants.Columns.DPACK),
                new WhippetDataRowImportMapEntry(nameof(DropShippedItemsShipped), MultichannelOrderManagerDatabaseConstants.Columns.DSHIP),
                new WhippetDataRowImportMapEntry(nameof(DropShippedItemsTotalCount), MultichannelOrderManagerDatabaseConstants.Columns.DALL),
                new WhippetDataRowImportMapEntry(nameof(Processed), MultichannelOrderManagerDatabaseConstants.Columns.PROCSSD),
                new WhippetDataRowImportMapEntry(nameof(User), MultichannelOrderManagerDatabaseConstants.Columns.USERID),
                new WhippetDataRowImportMapEntry(nameof(LastUser), MultichannelOrderManagerDatabaseConstants.Columns.LAST_USER),
                new WhippetDataRowImportMapEntry(nameof(EXTRA2), MultichannelOrderManagerDatabaseConstants.Columns.EXTRA2),
                new WhippetDataRowImportMapEntry(nameof(CheckNumber), MultichannelOrderManagerDatabaseConstants.Columns.CHECKNUM),
                new WhippetDataRowImportMapEntry(nameof(PreviousOrdersPlaced), MultichannelOrderManagerDatabaseConstants.Columns.PREVORD),
                new WhippetDataRowImportMapEntry(nameof(Zone), MultichannelOrderManagerDatabaseConstants.Columns.ZONE),
                new WhippetDataRowImportMapEntry(nameof(CostTable), MultichannelOrderManagerDatabaseConstants.Columns.C_TABLE),
                new WhippetDataRowImportMapEntry(nameof(Picked), MultichannelOrderManagerDatabaseConstants.Columns.PICKED),
                new WhippetDataRowImportMapEntry(nameof(TaxExemptValue), MultichannelOrderManagerDatabaseConstants.Columns.VNTM),
                new WhippetDataRowImportMapEntry(nameof(ShippingAddressType), MultichannelOrderManagerDatabaseConstants.Columns.SHIPTYPE),
                new WhippetDataRowImportMapEntry(nameof(NationalTaxRate), MultichannelOrderManagerDatabaseConstants.Columns.NTAXRATE),
                new WhippetDataRowImportMapEntry(nameof(StateProvinceTaxRate), MultichannelOrderManagerDatabaseConstants.Columns.STAXRATE),
                new WhippetDataRowImportMapEntry(nameof(CountyTaxRate), MultichannelOrderManagerDatabaseConstants.Columns.CTAXRATE),
                new WhippetDataRowImportMapEntry(nameof(CityTaxRate), MultichannelOrderManagerDatabaseConstants.Columns.ITAXRATE),
                new WhippetDataRowImportMapEntry(nameof(TaxShipping), MultichannelOrderManagerDatabaseConstants.Columns.TAXSHIP),
                new WhippetDataRowImportMapEntry(nameof(DueDays), MultichannelOrderManagerDatabaseConstants.Columns.DUE_DAYS),
                new WhippetDataRowImportMapEntry(nameof(BilledMerchandiseTotal), MultichannelOrderManagerDatabaseConstants.Columns.TB_MERCH),
                new WhippetDataRowImportMapEntry(nameof(SalesID), MultichannelOrderManagerDatabaseConstants.Columns.SALES_ID),
                new WhippetDataRowImportMapEntry(nameof(BilledShippingChargesTotal), MultichannelOrderManagerDatabaseConstants.Columns.TB_SHIP),
                new WhippetDataRowImportMapEntry(nameof(NOTYETUSED), MultichannelOrderManagerDatabaseConstants.Columns.NOTYETUSED),
                new WhippetDataRowImportMapEntry(nameof(BilledTaxesTotal), MultichannelOrderManagerDatabaseConstants.Columns.TB_TAX),
                new WhippetDataRowImportMapEntry(nameof(BilledNonTaxableMerchandiseTotal), MultichannelOrderManagerDatabaseConstants.Columns.TB_NONTAX),
                new WhippetDataRowImportMapEntry(nameof(ShippingChargesModified), MultichannelOrderManagerDatabaseConstants.Columns.SHIPMODIFY),
                new WhippetDataRowImportMapEntry(nameof(CatalogCode), MultichannelOrderManagerDatabaseConstants.Columns.CATCODE),
                new WhippetDataRowImportMapEntry(nameof(WeightNeeded), MultichannelOrderManagerDatabaseConstants.Columns.NEEDWEIGHT),
                new WhippetDataRowImportMapEntry(nameof(TaxModified), MultichannelOrderManagerDatabaseConstants.Columns.TAXMODIFY),
                new WhippetDataRowImportMapEntry(nameof(ORDER_ST2), MultichannelOrderManagerDatabaseConstants.Columns.ORDER_ST2),
                new WhippetDataRowImportMapEntry(nameof(TelemarketingCallInterestLevel), MultichannelOrderManagerDatabaseConstants.Columns.TELE_CODE),
                new WhippetDataRowImportMapEntry(nameof(TelemarketingCall), MultichannelOrderManagerDatabaseConstants.Columns.TELEDONE),
                new WhippetDataRowImportMapEntry(nameof(OverpaymentAmount), MultichannelOrderManagerDatabaseConstants.Columns.OVERPAY),
                new WhippetDataRowImportMapEntry(nameof(AccountingState), MultichannelOrderManagerDatabaseConstants.Columns.ACC_STATE),
                new WhippetDataRowImportMapEntry(nameof(NextPaymentAmount), MultichannelOrderManagerDatabaseConstants.Columns.NEXT_PAY),
                new WhippetDataRowImportMapEntry(nameof(FinanceChargesTotal), MultichannelOrderManagerDatabaseConstants.Columns.TB_FINCHAR),
                new WhippetDataRowImportMapEntry(nameof(AlternateOrderID), MultichannelOrderManagerDatabaseConstants.Columns.ALT_ORDER),
                new WhippetDataRowImportMapEntry(nameof(NoNationalTaxShippingCharges), MultichannelOrderManagerDatabaseConstants.Columns.NTAXSHIP),
                new WhippetDataRowImportMapEntry(nameof(IsQuote), MultichannelOrderManagerDatabaseConstants.Columns.QUOTATION),
                new WhippetDataRowImportMapEntry(nameof(InternetID), MultichannelOrderManagerDatabaseConstants.Columns.INTERNETID),
                new WhippetDataRowImportMapEntry(nameof(PointOfSaleOrder), MultichannelOrderManagerDatabaseConstants.Columns.POPENTRY),
                new WhippetDataRowImportMapEntry(nameof(CreditCardInCustomerList), MultichannelOrderManagerDatabaseConstants.Columns.CARDINLIST),
                new WhippetDataRowImportMapEntry(nameof(HoldNote), MultichannelOrderManagerDatabaseConstants.Columns.HOLDNOTE),
                new WhippetDataRowImportMapEntry(nameof(SoldToCustomerID), MultichannelOrderManagerDatabaseConstants.Columns.SOLDNUM),
                new WhippetDataRowImportMapEntry(nameof(DiscountPercent), MultichannelOrderManagerDatabaseConstants.Columns.DISCT_PCT),
                new WhippetDataRowImportMapEntry(nameof(DiscountDays), MultichannelOrderManagerDatabaseConstants.Columns.DISCT_DAYS),
                new WhippetDataRowImportMapEntry(nameof(MultiplePaymentMethods), MultichannelOrderManagerDatabaseConstants.Columns.MULTIPAY),
                new WhippetDataRowImportMapEntry(nameof(CID), MultichannelOrderManagerDatabaseConstants.Columns.CC_CID),
                new WhippetDataRowImportMapEntry(nameof(PointsUsed), MultichannelOrderManagerDatabaseConstants.Columns.POINTS_USD),
                new WhippetDataRowImportMapEntry(nameof(OrderType), MultichannelOrderManagerDatabaseConstants.Columns.ORDERTYPE),
                new WhippetDataRowImportMapEntry(nameof(PurchaseOrder), MultichannelOrderManagerDatabaseConstants.Columns.PONUMBER),
                new WhippetDataRowImportMapEntry(nameof(CardHolderName), MultichannelOrderManagerDatabaseConstants.Columns.CARDHOLDER),
                new WhippetDataRowImportMapEntry(nameof(NeedsScanning), MultichannelOrderManagerDatabaseConstants.Columns.NEEDSCAN),
                new WhippetDataRowImportMapEntry(nameof(NEED_GC), MultichannelOrderManagerDatabaseConstants.Columns.NEED_GC),
                new WhippetDataRowImportMapEntry(nameof(Billed), MultichannelOrderManagerDatabaseConstants.Columns.BILLED),
                new WhippetDataRowImportMapEntry(nameof(MerchandiseReadyToBill), MultichannelOrderManagerDatabaseConstants.Columns.R_MERCH),
                new WhippetDataRowImportMapEntry(nameof(TaxesReadyToBill), MultichannelOrderManagerDatabaseConstants.Columns.R_TAX),
                new WhippetDataRowImportMapEntry(nameof(MerchandiseNotReadyToBill), MultichannelOrderManagerDatabaseConstants.Columns.NR_MERCH),
                new WhippetDataRowImportMapEntry(nameof(TaxesNotReadyToBill), MultichannelOrderManagerDatabaseConstants.Columns.NR_TAX),
                new WhippetDataRowImportMapEntry(nameof(MerchandisePackedTotal), MultichannelOrderManagerDatabaseConstants.Columns.P_MERCH),
                new WhippetDataRowImportMapEntry(nameof(MerchandisePackedTaxTotal), MultichannelOrderManagerDatabaseConstants.Columns.P_TAX),
                new WhippetDataRowImportMapEntry(nameof(MerchandisePackedShippingTotal), MultichannelOrderManagerDatabaseConstants.Columns.P_SHIP),
                new WhippetDataRowImportMapEntry(nameof(TPSHIPTYPE), MultichannelOrderManagerDatabaseConstants.Columns.TPSHIPTYPE),
                new WhippetDataRowImportMapEntry(nameof(TPSHIPWHAT), MultichannelOrderManagerDatabaseConstants.Columns.TPSHIPWHAT),
                new WhippetDataRowImportMapEntry(nameof(TPSHIPACCT), MultichannelOrderManagerDatabaseConstants.Columns.TPSHIPACCT),
                new WhippetDataRowImportMapEntry(nameof(TPSHIPCC), MultichannelOrderManagerDatabaseConstants.Columns.TPSHIPCC),
                new WhippetDataRowImportMapEntry(nameof(TPSHIPEXP), MultichannelOrderManagerDatabaseConstants.Columns.TPSHIPEXP),
                new WhippetDataRowImportMapEntry(nameof(OrderTimestamp), MultichannelOrderManagerDatabaseConstants.Columns.ENTRYTIME),
                new WhippetDataRowImportMapEntry(nameof(FreightCollected), MultichannelOrderManagerDatabaseConstants.Columns.FREIGHTCOL),
                new WhippetDataRowImportMapEntry(nameof(InternetOrder), MultichannelOrderManagerDatabaseConstants.Columns.INTERNET),
                new WhippetDataRowImportMapEntry(nameof(ProcessedBy), MultichannelOrderManagerDatabaseConstants.Columns.PROCSSBY),
                new WhippetDataRowImportMapEntry(nameof(CreditCardInquiryRequired), MultichannelOrderManagerDatabaseConstants.Columns.CCINQ_REQ),
                new WhippetDataRowImportMapEntry(nameof(CreditCardRemoved), MultichannelOrderManagerDatabaseConstants.Columns.REMOVECC),
                new WhippetDataRowImportMapEntry(nameof(ItemID), MultichannelOrderManagerDatabaseConstants.Columns.ITEM_ID),
                new WhippetDataRowImportMapEntry(nameof(DiscountOrder), MultichannelOrderManagerDatabaseConstants.Columns.ORD_DISCT),
                new WhippetDataRowImportMapEntry(nameof(Priority), MultichannelOrderManagerDatabaseConstants.Columns.PRIORITY),
                new WhippetDataRowImportMapEntry(nameof(IssueNumber), MultichannelOrderManagerDatabaseConstants.Columns.ISSUE_NUM),
                new WhippetDataRowImportMapEntry(nameof(FRDATE), MultichannelOrderManagerDatabaseConstants.Columns.FRDATE),
                new WhippetDataRowImportMapEntry(nameof(PromotionCode), MultichannelOrderManagerDatabaseConstants.Columns.ORDPROMO),
                new WhippetDataRowImportMapEntry(nameof(ChargeEntireOrder), MultichannelOrderManagerDatabaseConstants.Columns.CHARGE_ALL),
                new WhippetDataRowImportMapEntry(nameof(NoPromotionApplied), MultichannelOrderManagerDatabaseConstants.Columns.NO_PROMO),
                new WhippetDataRowImportMapEntry(nameof(BankRoutingNumber), MultichannelOrderManagerDatabaseConstants.Columns.ROUTINGNUM),
                new WhippetDataRowImportMapEntry(nameof(BankAccountNumber), MultichannelOrderManagerDatabaseConstants.Columns.ACCOUNTNUM),
                new WhippetDataRowImportMapEntry(nameof(BankAccountType), MultichannelOrderManagerDatabaseConstants.Columns.ACCTTYPE),
                new WhippetDataRowImportMapEntry(nameof(BankName), MultichannelOrderManagerDatabaseConstants.Columns.BANKNAME),
                new WhippetDataRowImportMapEntry(nameof(PayPalID), MultichannelOrderManagerDatabaseConstants.Columns.PAYPALID),
                new WhippetDataRowImportMapEntry(nameof(PinEntry), MultichannelOrderManagerDatabaseConstants.Columns.PINENTRY),
                new WhippetDataRowImportMapEntry(nameof(EncryptionType), MultichannelOrderManagerDatabaseConstants.Columns.ENCTYPE),
                new WhippetDataRowImportMapEntry(nameof(BadLabel), MultichannelOrderManagerDatabaseConstants.Columns.BADLABEL),
                new WhippetDataRowImportMapEntry(nameof(DueDate), MultichannelOrderManagerDatabaseConstants.Columns.DUE_ONDATE),
                new WhippetDataRowImportMapEntry(nameof(HoldReasonCode), MultichannelOrderManagerDatabaseConstants.Columns.HOLDCODE),
                new WhippetDataRowImportMapEntry(nameof(OrderSet), MultichannelOrderManagerDatabaseConstants.Columns.ORDERSET),
                new WhippetDataRowImportMapEntry(nameof(UrlID), MultichannelOrderManagerDatabaseConstants.Columns.URL_ID)
            });
        }

        /// <summary>
        /// Imports the specified <see cref="DataRow"/> containing the information needed to populate the <see cref="IWhippetEntity"/>. This method must be overridden.
        /// </summary>
        /// <param name="dataRow"><see cref="DataRow"/> containing the data to import.</param>
        /// <param name="importMap">External <see cref="WhippetDataRowImportMap"/>. If <see langword="null"/>, then the one generated by <see cref="CreateImportMap"/> will be used.</param>
        /// <exception cref="ArgumentNullException" />
        public override void ImportDataRow(DataRow dataRow, WhippetDataRowImportMap importMap = null)
        {
            if (dataRow == null)
            {
                throw new ArgumentNullException(nameof(dataRow));
            }
            else
            {
                WhippetDataRowImportMap map = (importMap == null ? CreateImportMap() : importMap);

                AccountingState = dataRow.Field<string>(map[nameof(AccountingState)].Column);
                AlternateOrderID = dataRow.Field<string>(map[nameof(AlternateOrderID)].Column);
                BackorderedItemsValue = dataRow.Field<decimal>(map[nameof(BackorderedItemsValue)].Column);
                BadLabel = dataRow.Field<bool>(map[nameof(BadLabel)].Column);
                BankAccountNumber = dataRow.Field<string>(map[nameof(BankAccountNumber)].Column);
                BankAccountType = dataRow.Field<string>(map[nameof(BankAccountType)].Column);
                BankName = dataRow.Field<string>(map[nameof(BankName)].Column);
                BankRoutingNumber = dataRow.Field<string>(map[nameof(BankRoutingNumber)].Column);
                Billed = dataRow.Field<bool>(map[nameof(Billed)].Column);
                BilledMerchandiseTotal = dataRow.Field<decimal>(map[nameof(BilledMerchandiseTotal)].Column);
                BilledNonTaxableMerchandiseTotal = dataRow.Field<decimal>(map[nameof(BilledNonTaxableMerchandiseTotal)].Column);
                BilledShippingChargesTotal = dataRow.Field<decimal>(map[nameof(BilledShippingChargesTotal)].Column);
                BilledTaxesTotal = dataRow.Field<decimal>(map[nameof(BilledTaxesTotal)].Column);
                Cancelled = dataRow.Field<bool>(map[nameof(Cancelled)].Column);
                CardHolderName = dataRow.Field<string>(map[nameof(CardHolderName)].Column);
                CashOnly = dataRow.Field<bool>(map[nameof(CashOnly)].Column);
                CatalogCode = dataRow.Field<string>(map[nameof(CatalogCode)].Column);
                CCCORR = dataRow.Field<bool>(map[nameof(CCCORR)].Column);
                Charged = dataRow.Field<decimal>(map[nameof(Charged)].Column);
                ChargeEntireOrder = dataRow.Field<bool>(map[nameof(ChargeEntireOrder)].Column);
                Check = dataRow.Field<char>(map[nameof(Check)].Column);
                CheckClearDate = dataRow.Field<DateTime?>(map[nameof(CheckClearDate)].Column);
                CheckNumber = dataRow.Field<string>(map[nameof(CheckNumber)].Column);
                CID = dataRow.Field<string>(map[nameof(CID)].Column);
                CityTaxRate = dataRow.Field<decimal>(map[nameof(CityTaxRate)].Column);
                Completed = dataRow.Field<bool>(map[nameof(Completed)].Column);
                CORRECTIN = dataRow.Field<bool>(map[nameof(CORRECTIN)].Column);
                CORRECTLC = dataRow.Field<char>(map[nameof(CORRECTLC)].Column);
                CostTable = dataRow.Field<string>(map[nameof(CostTable)].Column);
                CountyTaxRate = dataRow.Field<decimal>(map[nameof(CountyTaxRate)].Column);
                CreditCardApprovalNumber = dataRow.Field<string>(map[nameof(CreditCardApprovalNumber)].Column);
                CreditCardExpirationDate = dataRow.Field<string>(map[nameof(CreditCardExpirationDate)].Column);
                CreditCardInCustomerList = dataRow.Field<bool>(map[nameof(CreditCardInCustomerList)].Column);
                CreditCardInquiryRequired = dataRow.Field<bool>(map[nameof(CreditCardInquiryRequired)].Column);
                CreditCardNumber = dataRow.Field<string>(map[nameof(CreditCardNumber)].Column);
                CreditCardRemoved = dataRow.Field<bool>(map[nameof(CreditCardRemoved)].Column);
                CreditCardType = dataRow.Field<string>(map[nameof(CreditCardType)].Column);
                CreditCardVouchers = dataRow.Field<int>(map[nameof(CreditCardVouchers)].Column);
                CustomerNumber = dataRow.Field<long>(map[nameof(CustomerNumber)].Column);
                DiscountDays = dataRow.Field<decimal>(map[nameof(DiscountDays)].Column);
                DiscountOrder = dataRow.Field<bool>(map[nameof(DiscountOrder)].Column);
                DiscountPercent = dataRow.Field<decimal>(map[nameof(DiscountPercent)].Column);
                DLABELS = dataRow.Field<int>(map[nameof(DLABELS)].Column);
                DropShippedItemsCount = dataRow.Field<decimal>(map[nameof(DropShippedItemsCount)].Column);
                DropShippedItemsOnHoldCount = dataRow.Field<decimal>(map[nameof(DropShippedItemsOnHoldCount)].Column);
                DropShippedItemsPacked = dataRow.Field<decimal>(map[nameof(DropShippedItemsPacked)].Column);
                DropShippedItemsShipped = dataRow.Field<decimal>(map[nameof(DropShippedItemsShipped)].Column);
                DropShippedItemsTotalCount = dataRow.Field<decimal>(map[nameof(DropShippedItemsTotalCount)].Column);
                DropShippedItemsValue = dataRow.Field<decimal>(map[nameof(DropShippedItemsValue)].Column);
                DropShippedItemsVerifiedCount = dataRow.Field<decimal>(map[nameof(DropShippedItemsVerifiedCount)].Column);
                DueDate = dataRow.Field<DateTime?>(map[nameof(DueDate)].Column);
                DueDays = dataRow.Field<int>(map[nameof(DueDays)].Column);
                EncryptionType = dataRow.Field<int>(map[nameof(EncryptionType)].Column);
                Extra = dataRow.Field<decimal>(map[nameof(Extra)].Column);
                EXTRA2 = dataRow.Field<string>(map[nameof(EXTRA2)].Column);
                FinanceChargesTotal = dataRow.Field<decimal>(map[nameof(FinanceChargesTotal)].Column);
                FRDATE = dataRow.Field<string>(map[nameof(FRDATE)].Column);
                FreightCollected = dataRow.Field<bool>(map[nameof(FreightCollected)].Column);
                HoldDate = dataRow.Field<DateTime?>(map[nameof(HoldDate)].Column);
                HoldNote = dataRow.Field<string>(map[nameof(AccountingState)].Column);
                HoldReasonCode = dataRow.Field<string>(map[nameof(AccountingState)].Column);
                HoldType = dataRow.Field<char>(map[nameof(HoldType)].Column);
                InternetID = dataRow.Field<string>(map[nameof(InternetID)].Column);
                InternetOrder = dataRow.Field<bool>(map[nameof(InternetOrder)].Column);
                Invoiced = dataRow.Field<bool>(map[nameof(Invoiced)].Column);
                IsQuote = dataRow.Field<bool>(map[nameof(IsQuote)].Column);
                IssueNumber = dataRow.Field<string>(map[nameof(IssueNumber)].Column);
                ItemID = dataRow.Field<long>(map[nameof(ItemID)].Column);
                ItemsBackOrdered = dataRow.Field<decimal>(map[nameof(ItemsBackOrdered)].Column);
                ItemsFilled = dataRow.Field<decimal>(map[nameof(ItemsFilled)].Column);
                ItemsInvoicedCount = dataRow.Field<decimal>(map[nameof(ItemsInvoicedCount)].Column);
                ItemsPacked = dataRow.Field<decimal>(map[nameof(ItemsPacked)].Column);
                ItemsShipped = dataRow.Field<decimal>(map[nameof(ItemsShipped)].Column);
                Labeled = dataRow.Field<bool>(map[nameof(Labeled)].Column);
                Labels = dataRow.Field<int>(map[nameof(Labels)].Column);
                LastInvoicePartCode = dataRow.Field<char>(map[nameof(LastInvoicePartCode)].Column);
                LastUser = dataRow.Field<string>(map[nameof(LastUser)].Column);
                MerchandiseNotReadyToBill = dataRow.Field<decimal>(map[nameof(MerchandiseNotReadyToBill)].Column);
                MerchandisePackedShippingTotal = dataRow.Field<decimal>(map[nameof(MerchandisePackedShippingTotal)].Column);
                MerchandisePackedTaxTotal = dataRow.Field<decimal>(map[nameof(MerchandisePackedTaxTotal)].Column);
                MerchandisePackedTotal = dataRow.Field<decimal>(map[nameof(MerchandisePackedTotal)].Column);
                MerchandiseReadyToBill = dataRow.Field<decimal>(map[nameof(MerchandiseReadyToBill)].Column);
                MultiplePaymentMethods = dataRow.Field<bool>(map[nameof(MultiplePaymentMethods)].Column);
                Multiship = dataRow.Field<bool>(map[nameof(Multiship)].Column);
                NationalTaxRate = dataRow.Field<decimal>(map[nameof(NationalTaxRate)].Column);
                NeedsScanning = dataRow.Field<bool>(map[nameof(NeedsScanning)].Column);
                NEED_GC = dataRow.Field<bool>(map[nameof(NEED_GC)].Column);
                NextPaymentAmount = dataRow.Field<decimal>(map[nameof(NextPaymentAmount)].Column);
                NoNationalTaxShippingCharges = dataRow.Field<bool>(map[nameof(NoNationalTaxShippingCharges)].Column);
                NoPromotionApplied = dataRow.Field<bool>(map[nameof(NoPromotionApplied)].Column);
                NOTYETUSED = dataRow.Field<bool>(map[nameof(NOTYETUSED)].Column);
                OnHoldItemsCount = dataRow.Field<decimal>(map[nameof(OnHoldItemsCount)].Column);
                OnHoldItemsValue = dataRow.Field<decimal>(map[nameof(OnHoldItemsValue)].Column);
                OrderDate = dataRow.Field<DateTime?>(map[nameof(OrderDate)].Column);
                OrderItemCount = dataRow.Field<decimal>(map[nameof(OrderItemCount)].Column);
                OrderNumber = dataRow.Field<long>(map[nameof(OrderNumber)].Column);
                OrderSet = dataRow.Field<bool>(map[nameof(OrderSet)].Column);
                OrderTimestamp = dataRow.Field<DateTime?>(map[nameof(OrderTimestamp)].Column);
                OrderTotal = dataRow.Field<decimal>(map[nameof(OrderTotal)].Column);
                OrderType = dataRow.Field<string>(map[nameof(OrderType)].Column);
                ORDER_ST2 = dataRow.Field<string>(map[nameof(ORDER_ST2)].Column);
                OtherCosts = dataRow.Field<decimal>(map[nameof(OtherCosts)].Column);
                OverpaymentAmount = dataRow.Field<decimal>(map[nameof(OverpaymentAmount)].Column);
                PaymentMethod = dataRow.Field<string>(map[nameof(PaymentMethod)].Column);
                PayPalID = dataRow.Field<string>(map[nameof(PayPalID)].Column);
                PermanentHold = dataRow.Field<bool>(map[nameof(PermanentHold)].Column);
                Picked = dataRow.Field<bool>(map[nameof(Picked)].Column);
                PinEntry = dataRow.Field<bool>(map[nameof(PinEntry)].Column);
                PointOfSaleOrder = dataRow.Field<bool>(map[nameof(PointOfSaleOrder)].Column);
                PointsUsed = dataRow.Field<int>(map[nameof(PointsUsed)].Column);
                PreviousOrdersPlaced = dataRow.Field<int>(map[nameof(PreviousOrdersPlaced)].Column);
                Priority = dataRow.Field<char>(map[nameof(Priority)].Column);
                Processed = dataRow.Field<bool>(map[nameof(Processed)].Column);
                ProcessedBy = dataRow.Field<string>(map[nameof(ProcessedBy)].Column);
                PromotionCode = dataRow.Field<string>(map[nameof(PromotionCode)].Column);
                PurchaseOrder = dataRow.Field<string>(map[nameof(PurchaseOrder)].Column);
                ReleaseDate = dataRow.Field<DateTime?>(map[nameof(ReleaseDate)].Column);
                SalesID = dataRow.Field<string>(map[nameof(SalesID)].Column);
                ShipDate = dataRow.Field<DateTime?>(map[nameof(ShipDate)].Column);
                Shipping = dataRow.Field<decimal>(map[nameof(Shipping)].Column);
                ShippingAddressID = dataRow.Field<long>(map[nameof(ShippingAddressID)].Column);
                ShippingAddressType = dataRow.Field<char>(map[nameof(ShippingAddressType)].Column);
                ShippingChargesModified = dataRow.Field<bool>(map[nameof(ShippingChargesModified)].Column);
                ShippingMethod = dataRow.Field<string>(map[nameof(ShippingMethod)].Column);
                SoldToCustomerID = dataRow.Field<long>(map[nameof(SoldToCustomerID)].Column);
                SourceKey = dataRow.Field<string>(map[nameof(SourceKey)].Column);
                StateProvinceTaxRate = dataRow.Field<decimal>(map[nameof(StateProvinceTaxRate)].Column);
                SystemHold = dataRow.Field<bool>(map[nameof(SystemHold)].Column);
                Tax = dataRow.Field<decimal>(map[nameof(Tax)].Column);
                TaxesNotReadyToBill = dataRow.Field<decimal>(map[nameof(TaxesNotReadyToBill)].Column);
                TaxesReadyToBill = dataRow.Field<decimal>(map[nameof(TaxesReadyToBill)].Column);
                TaxExemptValue = dataRow.Field<decimal>(map[nameof(TaxExemptValue)].Column);
                TaxModified = dataRow.Field<bool>(map[nameof(TaxModified)].Column);
                TaxShipping = dataRow.Field<bool>(map[nameof(TaxShipping)].Column);
                TelemarketingCall = dataRow.Field<bool>(map[nameof(TelemarketingCall)].Column);
                TelemarketingCallInterestLevel = dataRow.Field<int>(map[nameof(TelemarketingCallInterestLevel)].Column);
                TotalPayments = dataRow.Field<decimal>(map[nameof(TotalPayments)].Column);
                TPSHIPACCT = dataRow.Field<string>(map[nameof(TPSHIPACCT)].Column);
                TPSHIPCC = dataRow.Field<string>(map[nameof(TPSHIPCC)].Column);
                TPSHIPEXP = dataRow.Field<string>(map[nameof(TPSHIPEXP)].Column);
                TPSHIPTYPE = dataRow.Field<int>(map[nameof(TPSHIPTYPE)].Column);
                TPSHIPWHAT = dataRow.Field<char>(map[nameof(TPSHIPWHAT)].Column);
                UrlID = dataRow.Field<int>(map[nameof(UrlID)].Column);
                User = dataRow.Field<string>(map[nameof(User)].Column);
                WeightNeeded = dataRow.Field<bool>(map[nameof(WeightNeeded)].Column);
                Zone = dataRow.Field<string>(map[nameof(Zone)].Column);
            }
        }

        /// <summary>
        /// Creates a <see cref="DataTable"/> that represents the database table of the current entity.
        /// </summary>
        /// <returns><see cref="DataTable"/> containing the columns and respective definitions of the associated external database table for the current entity.</returns>
        public override DataTable CreateDataTable()
        {
            WhippetDataRowImportMap map = CreateImportMap();
            DataTable table = new DataTable(((IWhippetEntityExternalDataRowImportMapper)(this)).ExternalTableName);

            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(AccountingState)].Column, false, 2));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(AlternateOrderID)].Column, false, 25));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(BackorderedItemsValue)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(BadLabel)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(BankAccountNumber)].Column, false, 60));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(BankAccountType)].Column, false, 10));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(BankName)].Column, false, 30));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(BankRoutingNumber)].Column, false, 32));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Billed)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(BilledMerchandiseTotal)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(BilledNonTaxableMerchandiseTotal)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(BilledShippingChargesTotal)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(BilledTaxesTotal)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Cancelled)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CardHolderName)].Column, false, 30));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(CashOnly)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CatalogCode)].Column, false, 6));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(CCCORR)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(Charged)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(ChargeEntireOrder)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(Check)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(CheckClearDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CheckNumber)].Column, false, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CID)].Column, false, 32));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(CityTaxRate)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Completed)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(CORRECTIN)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(CORRECTLC)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CostTable)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(CountyTaxRate)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CreditCardApprovalNumber)].Column, false, 10));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CreditCardExpirationDate)].Column, false, 5));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(CreditCardInCustomerList)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(CreditCardInquiryRequired)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CreditCardNumber)].Column, false, 60));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(CreditCardRemoved)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CreditCardType)].Column, false, 2));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(CreditCardVouchers)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<long>(map[nameof(CustomerNumber)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(DiscountDays)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(DiscountOrder)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(DiscountPercent)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(DLABELS)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(DropShippedItemsCount)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(DropShippedItemsOnHoldCount)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(DropShippedItemsPacked)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(DropShippedItemsShipped)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(DropShippedItemsTotalCount)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(DropShippedItemsValue)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(DropShippedItemsVerifiedCount)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(DueDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(DueDays)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(EncryptionType)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(Extra)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(EXTRA2)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(FinanceChargesTotal)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(FRDATE)].Column, false, 5));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(FreightCollected)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(HoldDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(HoldNote)].Column, false, 50));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(HoldReasonCode)].Column, false, 10));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(HoldType)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(InternetID)].Column, false, 32));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(InternetOrder)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Invoiced)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsQuote)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(IssueNumber)].Column, false, 2));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<long>(map[nameof(ItemID)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(ItemsBackOrdered)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(ItemsFilled)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(ItemsInvoicedCount)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(ItemsPacked)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(ItemsShipped)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Labeled)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(Labels)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(LastInvoicePartCode)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(LastUser)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(MerchandiseNotReadyToBill)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(MerchandisePackedShippingTotal)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(MerchandisePackedTaxTotal)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(MerchandisePackedTotal)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(MerchandiseReadyToBill)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(MultiplePaymentMethods)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Multiship)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(NationalTaxRate)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(NeedsScanning)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(NEED_GC)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(NextPaymentAmount)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(NoNationalTaxShippingCharges)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(NoPromotionApplied)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(NOTYETUSED)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(OnHoldItemsCount)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(OnHoldItemsValue)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(OrderDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(OrderItemCount)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<long>(map[nameof(OrderNumber)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(OrderSet)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(OrderTimestamp)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(OrderTotal)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OrderType)].Column, false, 6));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ORDER_ST2)].Column, false, 2));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(OtherCosts)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(OverpaymentAmount)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(PaymentMethod)].Column, false, 2));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(PayPalID)].Column, false, 90));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(PermanentHold)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Picked)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(PinEntry)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(PointOfSaleOrder)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(PointsUsed)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(PreviousOrdersPlaced)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(Priority)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Processed)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ProcessedBy)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(PromotionCode)].Column, false, 10));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(PurchaseOrder)].Column, false, 25));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(ReleaseDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SalesID)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(ShipDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(Shipping)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<long>(map[nameof(ShippingAddressID)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(ShippingAddressType)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(ShippingChargesModified)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ShippingMethod)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<long>(map[nameof(SoldToCustomerID)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SourceKey)].Column, false, 9));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(StateProvinceTaxRate)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(SystemHold)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(Tax)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(TaxesNotReadyToBill)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(TaxesReadyToBill)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(TaxExemptValue)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(TaxModified)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(TaxShipping)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(TelemarketingCall)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(TelemarketingCallInterestLevel)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(TotalPayments)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(TPSHIPACCT)].Column, false, 14));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(TPSHIPCC)].Column, false, 19));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(TPSHIPEXP)].Column, false, 5));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(TPSHIPTYPE)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(TPSHIPWHAT)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(UrlID)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(User)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(WeightNeeded)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Zone)].Column, false, 3));

            table.PrimaryKey = new[] { table.Columns[map[nameof(OrderNumber)].Column] };

            return table;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IMultichannelOrderManagerOrder);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerOrder obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="IMultichannelOrderManagerOrder"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IMultichannelOrderManagerOrder"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerOrder a, IMultichannelOrderManagerOrder b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals =
                    a.Server.Equals(b.Server)
                        && String.Equals(a.AccountingState, b.AccountingState, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.AlternateOrderID, b.AlternateOrderID, StringComparison.InvariantCultureIgnoreCase)
                        && a.BackorderedItemsValue.Equals(b.BackorderedItemsValue)
                        && a.BadLabel.Equals(b.BadLabel)
                        && String.Equals(a.BankAccountNumber, b.BankAccountNumber, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.BankAccountType, b.BankAccountType, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.BankName, b.BankName, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.BankRoutingNumber, b.BankRoutingNumber, StringComparison.InvariantCultureIgnoreCase)
                        && a.Billed.Equals(b.Billed)
                        && a.BilledMerchandiseTotal.Equals(b.BilledMerchandiseTotal)
                        && a.BilledNonTaxableMerchandiseTotal.Equals(b.BilledNonTaxableMerchandiseTotal)
                        && a.BilledShippingChargesTotal.Equals(b.BilledShippingChargesTotal)
                        && a.BilledTaxesTotal.Equals(b.BilledTaxesTotal)
                        && a.Cancelled.Equals(b.Cancelled)
                        && String.Equals(a.CardHolderName, b.CardHolderName, StringComparison.InvariantCultureIgnoreCase)
                        && a.CashOnly.Equals(b.CashOnly)
                        && String.Equals(a.CatalogCode, b.CatalogCode, StringComparison.InvariantCultureIgnoreCase)
                        && a.CCCORR.Equals(b.CCCORR)
                        && a.Charged.Equals(b.Charged)
                        && a.ChargeEntireOrder.Equals(b.ChargeEntireOrder)
                        && a.Check.Equals(b.Check)
                        && a.CheckClearDate.GetValueOrDefault().Equals(b.CheckClearDate.GetValueOrDefault())
                        && String.Equals(a.CheckNumber, b.CheckNumber, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.CID, b.CID, StringComparison.InvariantCultureIgnoreCase)
                        && a.CityTaxRate.Equals(b.CityTaxRate)
                        && a.Completed.Equals(b.Completed)
                        && a.CORRECTIN.Equals(b.CORRECTIN)
                        && a.CORRECTLC.Equals(b.CORRECTLC)
                        && a.CostTable.Equals(b.CostTable)
                        && a.CountyTaxRate.Equals(b.CountyTaxRate)
                        && String.Equals(a.CreditCardApprovalNumber, b.CreditCardApprovalNumber, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.CreditCardExpirationDate, b.CreditCardExpirationDate, StringComparison.InvariantCultureIgnoreCase)
                        && a.CreditCardInCustomerList.Equals(b.CreditCardInCustomerList)
                        && a.CreditCardInquiryRequired.Equals(b.CreditCardInquiryRequired)
                        && String.Equals(a.CreditCardNumber, b.CreditCardNumber, StringComparison.InvariantCultureIgnoreCase)
                        && a.CreditCardRemoved.Equals(b.CreditCardRemoved)
                        && String.Equals(a.CreditCardType, b.CreditCardType, StringComparison.InvariantCultureIgnoreCase)
                        && a.CreditCardVouchers.Equals(b.CreditCardVouchers)
                        && a.CustomerNumber.Equals(b.CustomerNumber)
                        && a.DiscountDays.Equals(b.DiscountDays)
                        && a.DiscountOrder.Equals(b.DiscountOrder)
                        && a.DiscountPercent.Equals(b.DiscountPercent)
                        && a.DLABELS.Equals(b.DLABELS)
                        && a.DropShippedItemsCount.Equals(b.DropShippedItemsCount)
                        && a.DropShippedItemsOnHoldCount.Equals(b.DropShippedItemsOnHoldCount)
                        && a.DropShippedItemsPacked.Equals(b.DropShippedItemsPacked)
                        && a.DropShippedItemsShipped.Equals(b.DropShippedItemsShipped)
                        && a.DropShippedItemsTotalCount.Equals(b.DropShippedItemsTotalCount)
                        && a.DropShippedItemsValue.Equals(b.DropShippedItemsValue)
                        && a.DropShippedItemsVerifiedCount.Equals(b.DropShippedItemsVerifiedCount)
                        && a.DueDate.GetValueOrDefault().Equals(b.DueDate.GetValueOrDefault())
                        && a.DueDays.Equals(b.DueDays)
                        && a.EncryptionType.Equals(b.EncryptionType)
                        && a.Extra.Equals(b.Extra)
                        && String.Equals(a.EXTRA2, b.EXTRA2, StringComparison.InvariantCultureIgnoreCase)
                        && a.FinanceChargesTotal.Equals(b.FinanceChargesTotal)
                        && a.FRDATE.Equals(b.FRDATE)
                        && a.FreightCollected.Equals(b.FreightCollected)
                        && a.HoldDate.GetValueOrDefault().Equals(b.HoldDate.GetValueOrDefault())
                        && String.Equals(a.HoldNote, b.HoldNote, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.HoldReasonCode, b.HoldReasonCode, StringComparison.InvariantCultureIgnoreCase)
                        && a.HoldType.Equals(b.HoldType)
                        && String.Equals(a.InternetID, b.InternetID, StringComparison.InvariantCultureIgnoreCase)
                        && a.InternetOrder.Equals(b.InternetOrder)
                        && a.Invoiced.Equals(b.Invoiced)
                        && a.IsQuote.Equals(b.IsQuote)
                        && String.Equals(a.IssueNumber, b.IssueNumber, StringComparison.InvariantCultureIgnoreCase)
                        && a.ItemID.Equals(b.ItemID)
                        && a.ItemsBackOrdered.Equals(b.ItemsBackOrdered)
                        && a.ItemsFilled.Equals(b.ItemsFilled)
                        && a.ItemsInvoicedCount.Equals(b.ItemsInvoicedCount)
                        && a.ItemsPacked.Equals(b.ItemsPacked)
                        && a.ItemsShipped.Equals(b.ItemsShipped)
                        && a.Labeled.Equals(b.Labeled)
                        && a.Labels.Equals(b.Labels)
                        && a.LastInvoicePartCode.Equals(b.LastInvoicePartCode)
                        && String.Equals(a.LastUser, b.LastUser, StringComparison.InvariantCultureIgnoreCase)
                        && a.MerchandiseNotReadyToBill.Equals(b.MerchandiseNotReadyToBill)
                        && a.MerchandisePackedShippingTotal.Equals(b.MerchandisePackedShippingTotal)
                        && a.MerchandisePackedTaxTotal.Equals(b.MerchandisePackedTaxTotal)
                        && a.MerchandisePackedTotal.Equals(b.MerchandisePackedTotal)
                        && a.MerchandiseReadyToBill.Equals(b.MerchandiseReadyToBill)
                        && a.MultiplePaymentMethods.Equals(b.MultiplePaymentMethods)
                        && a.Multiship.Equals(b.Multiship)
                        && a.NationalTaxRate.Equals(b.NationalTaxRate)
                        && a.NeedsScanning.Equals(b.NeedsScanning)
                        && a.NEED_GC.Equals(b.NEED_GC)
                        && a.NextPaymentAmount.Equals(b.NextPaymentAmount)
                        && a.NoNationalTaxShippingCharges.Equals(b.NoNationalTaxShippingCharges)
                        && a.NoPromotionApplied.Equals(b.NoPromotionApplied)
                        && a.NOTYETUSED.Equals(b.NOTYETUSED)
                        && a.OnHoldItemsCount.Equals(b.OnHoldItemsCount)
                        && a.OnHoldItemsValue.Equals(b.OnHoldItemsValue)
                        && a.OrderDate.GetValueOrDefault().Equals(b.OrderDate.GetValueOrDefault())
                        && a.OrderItemCount.Equals(b.OrderItemCount)
                        && a.OrderNumber.Equals(b.OrderNumber)
                        && a.OrderSet.Equals(b.OrderSet)
                        && a.OrderTimestamp.GetValueOrDefault().Equals(b.OrderTimestamp.GetValueOrDefault())
                        && a.OrderTotal.Equals(b.OrderTotal)
                        && String.Equals(a.OrderType, b.OrderType, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.ORDER_ST2, b.ORDER_ST2, StringComparison.InvariantCultureIgnoreCase)
                        && a.OtherCosts.Equals(b.OtherCosts)
                        && a.OverpaymentAmount.Equals(b.OverpaymentAmount)
                        && String.Equals(a.PaymentMethod, b.PaymentMethod, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.PayPalID, b.PayPalID, StringComparison.InvariantCultureIgnoreCase)
                        && a.PermanentHold.Equals(b.PermanentHold)
                        && a.Picked.Equals(b.Picked)
                        && a.PinEntry.Equals(b.PinEntry)
                        && a.PointOfSaleOrder.Equals(b.PointOfSaleOrder)
                        && a.PointsUsed.Equals(b.PointsUsed)
                        && a.PreviousOrdersPlaced.Equals(b.PreviousOrdersPlaced)
                        && a.Priority.Equals(b.Priority)
                        && a.Processed.Equals(b.Processed)
                        && String.Equals(a.ProcessedBy, b.ProcessedBy, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.PromotionCode, b.PromotionCode, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.PurchaseOrder, b.PurchaseOrder, StringComparison.InvariantCultureIgnoreCase)
                        && a.ReleaseDate.GetValueOrDefault().Equals(b.ReleaseDate.GetValueOrDefault())
                        && String.Equals(a.SalesID, b.SalesID, StringComparison.InvariantCultureIgnoreCase)
                        && a.ShipDate.GetValueOrDefault().Equals(b.ShipDate.GetValueOrDefault())
                        && a.Shipping.Equals(b.Shipping)
                        && a.ShippingAddressID.Equals(b.ShippingAddressID)
                        && a.ShippingAddressType.Equals(b.ShippingAddressType)
                        && a.ShippingChargesModified.Equals(b.ShippingChargesModified)
                        && String.Equals(a.ShippingMethod, b.ShippingMethod, StringComparison.InvariantCultureIgnoreCase)
                        && a.SoldToCustomerID.Equals(b.SoldToCustomerID)
                        && String.Equals(a.SourceKey, b.SourceKey, StringComparison.InvariantCultureIgnoreCase)
                        && a.StateProvinceTaxRate.Equals(b.StateProvinceTaxRate)
                        && a.SystemHold.Equals(b.SystemHold)
                        && a.Tax.Equals(b.Tax)
                        && a.TaxesNotReadyToBill.Equals(b.TaxesNotReadyToBill)
                        && a.TaxesReadyToBill.Equals(b.TaxesReadyToBill)
                        && a.TaxExemptValue.Equals(b.TaxExemptValue)
                        && a.TaxModified.Equals(b.TaxModified)
                        && a.TaxShipping.Equals(b.TaxShipping)
                        && a.TelemarketingCall.Equals(b.TelemarketingCall)
                        && a.TelemarketingCallInterestLevel.Equals(b.TelemarketingCallInterestLevel)
                        && a.TotalPayments.Equals(b.TotalPayments)
                        && String.Equals(a.TPSHIPACCT, b.TPSHIPACCT, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.TPSHIPCC, b.TPSHIPCC, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.TPSHIPEXP, b.TPSHIPEXP, StringComparison.InvariantCultureIgnoreCase)
                        && a.TPSHIPTYPE.Equals(b.TPSHIPTYPE)
                        && a.TPSHIPWHAT.Equals(b.TPSHIPWHAT)
                        && a.UrlID.Equals(b.UrlID)
                        && String.Equals(a.User, b.User, StringComparison.InvariantCultureIgnoreCase)
                        && a.WeightNeeded.Equals(b.WeightNeeded)
                        && String.Equals(a.Zone, b.Zone, StringComparison.InvariantCultureIgnoreCase);
            }

            return equals;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual int GetHashCode(IMultichannelOrderManagerOrder obj)
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
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(OrderNumber);
            builder.Append(" [");

            if (IsQuote)
            {
                builder.Append(" Quote ");
            }
            else
            {
                builder.Append(" Order ");
            }
               
            builder.Append("]");

            return builder.ToString();
        }

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be overridden.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public override string ToJson<T>()
        {
            return this.SerializeJson(this);
        }
    }
}

