using System;
using Athi.Whippet.Data;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents an individual order in the Multichannel Order Manager.
    /// </summary>
    public interface IMultichannelOrderManagerOrder : IMultichannelOrderManagerOrderSupport, IWhippetEntity, IMultichannelOrderManagerPurchaseOrderSupport, IWhippetEntityExternalDataRowImportMapper, IEqualityComparer<IMultichannelOrderManagerOrder>, IMultichannelOrderManagerEntity, IWhippetEntityDynamicImportMapper
    {
        /// <summary>
        /// Gets or sets the customer number.
        /// </summary>
        long CustomerNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the source key for the order.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SourceKey
        { get; set; }

        /// <summary>
        /// Specifies the entry date of the order.
        /// </summary>
        DateTime? OrderDate
        { get; set; }

        /// <summary>
        /// Specifies the type of hold on the order.
        /// </summary>
        char HoldType
        { get; set; }

        /// <summary>
        /// Indicates whether the order is on a permanent hold.
        /// </summary>
        bool PermanentHold
        { get; set; }

        /// <summary>
        /// Indicates whether the system has placed a hold on the order.
        /// </summary>
        bool SystemHold
        { get; set; }

        /// <summary>
        /// Specifies the date the order was held.
        /// </summary>
        DateTime? HoldDate
        { get; set; }

        /// <summary>
        /// Specifies the next release date of line items on hold.
        /// </summary>
        DateTime? ReleaseDate
        { get; set; }

        /// <summary>
        /// Specifies the check clearing date.
        /// </summary>
        DateTime? CheckClearDate
        { get; set; }

        /// <summary>
        /// Specifies the date the order is expected to be shipped.
        /// </summary>
        DateTime? ShipDate
        { get; set; }

        /// <summary>
        /// Payment control field for check and credit.
        /// </summary>
        char Check
        { get; set; }

        /// <summary>
        /// Method of payment.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string PaymentMethod
        { get; set; }

        /// <summary>
        /// Specifies that Cash On Delivery (COD) be cash only.
        /// </summary>
        bool CashOnly
        { get; set; }

        /// <summary>
        /// Specifies the credit card number.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string CreditCardNumber
        { get; set; }

        /// <summary>
        /// Specifies the credit card type.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string CreditCardType
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card expiration date in 'MM/YY' format.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string CreditCardExpirationDate
        { get; set; }

        /// <summary>
        /// Gets or sets the last approval number for the credit card.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string CreditCardApprovalNumber
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        bool CCCORR
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping method for the order.
        /// </summary>
        string ShippingMethod
        { get; set; }

        /// <summary>
        /// Total tax for the order.
        /// </summary>
        decimal Tax
        { get; set; }

        /// <summary>
        /// Total shipping costs for the order.
        /// </summary>
        decimal Shipping
        { get; set; }

        /// <summary>
        /// Total finance charges for the order.
        /// </summary>
        decimal OtherCosts
        { get; set; }

        /// <summary>
        /// Total amount of payments made on the order to date.
        /// </summary>
        decimal TotalPayments
        { get; set; }

        /// <summary>
        /// Total amount of order including all merchandise.
        /// </summary>
        decimal OrderTotal
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        decimal Charged
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        bool CORRECTIN
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        char CORRECTLC
        { get; set; }

        /// <summary>
        /// Specifies whether the order has been invoiced.
        /// </summary>
        bool Invoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the last invoice part code.
        /// </summary>
        char LastInvoicePartCode
        { get; set; }

        /// <summary>
        /// Specifies the total number of credit card vouchers generated.
        /// </summary>
        int CreditCardVouchers
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        bool Labeled
        { get; set; }

        /// <summary>
        /// Number of extra box labels to generate.
        /// </summary>
        int Labels
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        int DLABELS
        { get; set; }

        /// <summary>
        /// Indicates whether the order is fully paid for and all merchandise has been shipped.
        /// </summary>
        bool Completed
        { get; set; }

        /// <summary>
        /// Indicates whether the order has been cancelled.
        /// </summary>
        bool Cancelled
        { get; set; }

        /// <summary>
        /// Specifies whether some items have already been shipped.
        /// </summary>
        bool Multiship
        { get; set; }

        /// <summary>
        /// Specifies the number of items invoiced.
        /// </summary>
        decimal ItemsInvoicedCount
        { get; set; }

        /// <summary>
        /// Specifies the number of items filled.
        /// </summary>
        decimal ItemsFilled
        { get; set; }

        /// <summary>
        /// Specifies the number of items packed.
        /// </summary>
        decimal ItemsPacked
        { get; set; }

        /// <summary>
        /// Specifies the number of items shipped.
        /// </summary>
        decimal ItemsShipped
        { get; set; }

        /// <summary>
        /// Specifies the number of items backordered.
        /// </summary>
        decimal ItemsBackOrdered
        { get; set; }

        /// <summary>
        /// Specifies the value (in dollars) of back ordered merchandise.
        /// </summary>
        decimal BackorderedItemsValue
        { get; set; }

        /// <summary>
        /// Specifies the value (in dollars) of drop-shipped merchandise.
        /// </summary>
        decimal DropShippedItemsValue
        { get; set; }

        /// <summary>
        /// Specifies the value (in dollars) of items currently on hold.
        /// </summary>
        decimal OnHoldItemsValue
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of items in the order.
        /// </summary>
        decimal OrderItemCount
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of items currently on hold.
        /// </summary>
        decimal OnHoldItemsCount
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        decimal Extra
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping address customer number ID.
        /// </summary>
        long ShippingAddressID
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of drop-shipped items ordered.
        /// </summary>
        decimal DropShippedItemsCount
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of drop-shipped items not yet ordered.
        /// </summary>
        decimal DropShippedItemsOnHoldCount
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of drop-shipped items verified.
        /// </summary>
        decimal DropShippedItemsVerifiedCount
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of drop-shipped items packed.
        /// </summary>
        decimal DropShippedItemsPacked
        { get; set; }

        /// <summary>
        /// Specifies the number of drop-ship items shipped.
        /// </summary>
        decimal DropShippedItemsShipped
        { get; set; }

        /// <summary>
        /// Specifies the total number of drop-ship items.
        /// </summary>
        decimal DropShippedItemsTotalCount
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        bool Processed
        { get; set; }

        /// <summary>
        /// Gets or sets the user ID who created the order.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string User
        { get; set; }

        /// <summary>
        /// Gets or sets the user ID who last accessed the order.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string LastUser
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        string EXTRA2
        { get; set; }

        /// <summary>
        /// Gets or sets the check number used in payment for the order.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string CheckNumber
        { get; set; }

        /// <summary>
        /// Specifies the total number of previous orders placed.
        /// </summary>
        int PreviousOrdersPlaced
        { get; set; }

        /// <summary>
        /// System determined zone.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string Zone
        { get; set; }

        /// <summary>
        /// Gets or sets the cost table.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string CostTable
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        bool Picked
        { get; set; }

        /// <summary>
        /// Value (in dollars) of tax exempt merchandise.
        /// </summary>
        decimal TaxExemptValue
        { get; set; }

        /// <summary>
        /// Indicates the type of shipping address.
        /// </summary>
        char ShippingAddressType
        { get; set; }

        /// <summary>
        /// Gets or sets the national tax rate.
        /// </summary>
        decimal NationalTaxRate
        { get; set; }

        /// <summary>
        /// Gets or sets the state/province tax rate.
        /// </summary>
        decimal StateProvinceTaxRate
        { get; set; }

        /// <summary>
        /// Gets or sets the county tax rate.
        /// </summary>
        decimal CountyTaxRate
        { get; set; }

        /// <summary>
        /// Gets or sets the city tax rate.
        /// </summary>
        decimal CityTaxRate
        { get; set; }

        /// <summary>
        /// Indicates whether shipping charges should be taxed.
        /// </summary>
        bool TaxShipping
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        int DueDays
        { get; set; }

        /// <summary>
        /// Gets or sets the total number (in dollars) of billed merchandise.
        /// </summary>
        decimal BilledMerchandiseTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the salesperson ID for this order.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SalesID
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount (in dollars) of billed shipping charges.
        /// </summary>
        decimal BilledShippingChargesTotal
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        bool NOTYETUSED
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount (in dollars) of billed taxes.
        /// </summary>
        decimal BilledTaxesTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount (in dollars) of billed non-taxable merchandise.
        /// </summary>
        decimal BilledNonTaxableMerchandiseTotal
        { get; set; }

        /// <summary>
        /// Indicates whether shipping charges are modified outside of their system calculation.
        /// </summary>
        bool ShippingChargesModified
        { get; set; }

        /// <summary>
        /// Catalog code for the order.
        /// </summary>
        string CatalogCode
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        bool TaxModified
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string ORDER_ST2
        { get; set; }

        /// <summary>
        /// Indicates the interest level for a telemarketing call.
        /// </summary>
        int TelemarketingCallInterestLevel
        { get; set; }

        /// <summary>
        /// Indicates whether a telemarketing call was made for the current order.
        /// </summary>
        bool TelemarketingCall
        { get; set; }

        /// <summary>
        /// Gets or sets the overpayment amount.
        /// </summary>
        decimal OverpaymentAmount
        { get; set; }

        /// <summary>
        /// Indicates whether the order needs to be weighed.
        /// </summary>
        bool WeightNeeded
        { get; set; }

        /// <summary>
        /// Gets or sets the accounting state of the order.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string AccountingState
        { get; set; }

        /// <summary>
        /// Specifies the amount (in dollars) of the next payment.
        /// </summary>
        decimal NextPaymentAmount
        { get; set; }

        /// <summary>
        /// Specifies the total amount (in dollars) of billed finance charges.
        /// </summary>
        decimal FinanceChargesTotal
        { get; set; }

        /// <summary>
        /// Gets or sets an alternate order ID for the current order.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string AlternateOrderID
        { get; set; }

        /// <summary>
        /// Indicates that shipping charges will not be taxed at the national level.
        /// </summary>
        bool NoNationalTaxShippingCharges
        { get; set; }

        /// <summary>
        /// Indicates whether the current order is a quotation for a customer.
        /// </summary>
        bool IsQuote
        { get; set; }

        /// <summary>
        /// Specifies the order number assigned by SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string InternetID
        { get; set; }

        /// <summary>
        /// Indicates whether the current order is a point-of-sale order.
        /// </summary>
        bool PointOfSaleOrder
        { get; set; }

        /// <summary>
        /// Indicates whether the credit card is in the customer's list.
        /// </summary>
        bool CreditCardInCustomerList
        { get; set; }

        /// <summary>
        /// Gets or sets the note for why the order is on hold.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string HoldNote
        { get; set; }

        /// <summary>
        /// Gets or sets the "sold to" customer number.
        /// </summary>
        long SoldToCustomerID
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        decimal DiscountPercent
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        decimal DiscountDays
        { get; set; }

        /// <summary>
        /// Indicates whether the order has multiple payment methods.
        /// </summary>
        bool MultiplePaymentMethods
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string CID
        { get; set; }

        /// <summary>
        /// Gets or sets the total points used on the order.
        /// </summary>
        int PointsUsed
        { get; set; }

        /// <summary>
        /// Gets or sets the order type.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string OrderType
        { get; set; }

        /// <summary>
        /// Gets or sets the purchase order number associated with the order.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        new string PurchaseOrder
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string CardHolderName
        { get; set; }

        /// <summary>
        /// Indicates whether the order needs scanning.
        /// </summary>
        bool NeedsScanning
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        bool NEED_GC
        { get; set; }

        /// <summary>
        /// Indicates whether the order has been billed.
        /// </summary>
        bool Billed
        { get; set; }

        /// <summary>
        /// Specifies the total amount (in dollars) of merchandise ready to bill.
        /// </summary>
        decimal MerchandiseReadyToBill
        { get; set; }

        /// <summary>
        /// Specifies the total amount (in dollars) of taxes ready to bill.
        /// </summary>
        decimal TaxesReadyToBill
        { get; set; }

        /// <summary>
        /// Specifies the total amount (in dollars) of merchandise not ready to bill.
        /// </summary>
        decimal MerchandiseNotReadyToBill
        { get; set; }

        /// <summary>
        /// Specifies the total amount (in dollars) of taxes not ready to bill.
        /// </summary>
        decimal TaxesNotReadyToBill
        { get; set; }

        /// <summary>
        /// Specifies the total amount (in dollars) of merchandise packed.
        /// </summary>
        decimal MerchandisePackedTotal
        { get; set; }

        /// <summary>
        /// Specifies the total amount (in dollars) of taxes on packed merchandise.
        /// </summary>
        decimal MerchandisePackedTaxTotal
        { get; set; }

        /// <summary>
        /// Specifies the total amount (in dollars) of the shipping total on packed merchandise.
        /// </summary>
        decimal MerchandisePackedShippingTotal
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        int TPSHIPTYPE
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        char TPSHIPWHAT
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string TPSHIPACCT
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string TPSHIPCC
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string TPSHIPEXP
        { get; set; }

        /// <summary>
        /// Specifies the date and time the order was created.
        /// </summary>
        DateTime? OrderTimestamp
        { get; set; }

        /// <summary>
        /// Freight collected flag for UPS 3rd-party billing.
        /// </summary>
        bool FreightCollected
        { get; set; }

        /// <summary>
        /// Indicates whether the order was placed over the internet.
        /// </summary>
        bool InternetOrder
        { get; set; }

        /// <summary>
        /// Specifies the user who processed the order.
        /// </summary>
        string ProcessedBy
        { get; set; }

        /// <summary>
        /// Used by Authorize.net.
        /// </summary>
        bool CreditCardInquiryRequired
        { get; set; }

        /// <summary>
        /// Indicates that the credit card was removed from the customer's card list.
        /// </summary>
        bool CreditCardRemoved
        { get; set; }

        /// <summary>
        /// Gets or sets the item ID of the additional item added from order promotion.
        /// </summary>
        long ItemID
        { get; set; }

        /// <summary>
        /// Indicates whether a discount is applied to the order from an order promotion.
        /// </summary>
        bool DiscountOrder
        { get; set; }

        /// <summary>
        /// Specifies the order priority.
        /// </summary>
        char Priority
        { get; set; }

        /// <summary>
        /// For use in the United Kingdom only.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string IssueNumber
        { get; set; }

        /// <summary>
        /// For use in the United Kingdom only.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string FRDATE
        { get; set; }

        /// <summary>
        /// Gets or sets the order promotion code.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string PromotionCode
        { get; set; }

        /// <summary>
        /// Indicates whether the entire order--including backorder items--should be charged.
        /// </summary>
        bool ChargeEntireOrder
        { get; set; }

        /// <summary>
        /// Indicates whether an order promotion has not been applied.
        /// </summary>
        bool NoPromotionApplied
        { get; set; }

        /// <summary>
        /// Gets or sets the bank routing number for eCheck payment.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string BankRoutingNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the bank account number for eCheck payment.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string BankAccountNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the bank account type for eCheck payment.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string BankAccountType
        { get; set; }

        /// <summary>
        /// Gets or sets the bank name for eCheck payment.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string BankName
        { get; set; }

        /// <summary>
        /// Gets or sets the PayPal account ID for the order's payment method.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string PayPalID
        { get; set; }

        /// <summary>
        /// For use in the United Kingdom only.
        /// </summary>
        bool PinEntry
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        int EncryptionType
        { get; set; }

        /// <summary>
        /// Indicates that the order has produced an invalid UPS label.
        /// </summary>
        bool BadLabel
        { get; set; }

        /// <summary>
        /// For orders paid via invoice, indicates the date the order will be due for payment.
        /// </summary>
        DateTime? DueDate
        { get; set; }

        /// <summary>
        /// Specifies the order hold reason code selected.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string HoldReasonCode
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        bool OrderSet
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        int UrlID
        { get; set; }
    }
}

