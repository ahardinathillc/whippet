using System;
using NodaTime;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Vault;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Represents a payment for an <see cref="ISalesOrder"/> in Magento.
    /// </summary>
    public interface ISalesOrderPayment : IMagentoEntity, IEqualityComparer<ISalesOrderPayment>, IMagentoRestEntity
    {
        /// <summary>
        /// Gets or sets the account status.
        /// </summary>
        string AccountStatus
        { get; set; }

        /// <summary>
        /// Gets or sets additional data about the payment.
        /// </summary>
        string AdditionalData
        { get; set; }

        /// <summary>
        /// Gets or sets additional information about the payment.
        /// </summary>
        IEnumerable<string> AdditionalInformation
        { get; set; }

        /// <summary>
        /// Gets or sets the address status.
        /// </summary>
        string AddressStatus
        { get; set; }

        /// <summary>
        /// Gets or sets the amount authorized.
        /// </summary>
        decimal AmountAuthorized
        { get; set; }

        /// <summary>
        /// Gets or sets the amount canceled.
        /// </summary>
        decimal AmountCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the amount ordered.
        /// </summary>
        decimal AmountOrdered
        { get; set; }

        /// <summary>
        /// Gets or sets the amount paid.
        /// </summary>
        decimal AmountPaid
        { get; set; }

        /// <summary>
        /// Gets or sets the amount refunded.
        /// </summary>
        decimal AmountRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the Authorize.NET transaction method.
        /// </summary>
        string AuthorizeNetTransactionMethod
        { get; set; }

        /// <summary>
        /// Gets or sets the amount authorized in base currency.
        /// </summary>
        decimal AmountAuthorizedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the amount canceled in base currency.
        /// </summary>
        decimal AmountCanceledBase
        { get; set; }

        /// <summary>
        /// Gets or sets the amount ordered in base currency.
        /// </summary>
        decimal AmountOrderedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the amount paid in base currency.
        /// </summary>
        decimal AmountPaidBase
        { get; set; }

        /// <summary>
        /// Gets or sets the amount paid online in base currency.
        /// </summary>
        decimal AmountPaidOnlineBase
        { get; set; }

        /// <summary>
        /// Gets or sets the amount refunded in base currency.
        /// </summary>
        decimal AmountRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the amount refunded online in base currency.
        /// </summary>
        decimal AmountRefundedOnlineBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount in base currency.
        /// </summary>
        decimal ShippingAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount captured in base currency.
        /// </summary>
        decimal ShippingAmountCaptured
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount refunded in base currency.
        /// </summary>
        decimal ShippingRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card approval number.
        /// </summary>
        string CreditCardApproval
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card Address Verification System (AVS) status.
        /// </summary>
        string CreditCardAddressVerificationSystemStatus
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card Card Identification (CID) verification status.
        /// </summary>
        string CreditCardIdentificationVerificationStatus
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card debug request body.
        /// </summary>
        string CreditCardDebugRequest
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card response body.
        /// </summary>
        string CreditCardResponseBody
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card debug response serialized.
        /// </summary>
        string CreditCardDebugResponseSerialized
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card's expiration date.
        /// </summary>
        LocalDate? CreditCardExpiration
        { get; set; }
        
        /// <summary>
        /// Gets or sets the last four digits of the credit card.
        /// </summary>
        string CreditCardLastFourDigits
        { get; set; }

        /// <summary>
        /// Gets or sets the (encrypted) credit card number.
        /// </summary>
        string CreditCardNumberEncrypted
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card number.
        /// </summary>
        string CreditCardNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card secure verify value.
        /// </summary>
        string CreditCardSecureVerify
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card's SS issue.
        /// </summary>
        string CreditCard_SS_Issue
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card's SS start date.
        /// </summary>
        LocalDate? CreditCard_SS_StartDate
        { get; set; }
        
        /// <summary>
        /// Gets or sets the credit card's status.
        /// </summary>
        string CreditCardStatus
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card's status description.
        /// </summary>
        string CreditCardStatusDescription
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card's transaction ID.
        /// </summary>
        string CreditCardTransactionID
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card type.
        /// </summary>
        string CreditCardType
        { get; set; }

        /// <summary>
        /// Gets or sets the eCheque account name.
        /// </summary>
        string ElectronicChequeAccountName
        { get; set; }

        /// <summary>
        /// Gets or sets the eCheque account type.
        /// </summary>
        string ElectronicChequeAccountType
        { get; set; }

        /// <summary>
        /// Gets or sets the eCheque bank name.
        /// </summary>
        string ElectronicChequeBankName
        { get; set; }

        /// <summary>
        /// Gets or sets the eCheque routing number.
        /// </summary>
        string ElectronicChequeRoutingNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the eCheque type.
        /// </summary>
        string ElectronicChequeType
        { get; set; }

        /// <summary>
        /// Gets or sets the last transaction ID.
        /// </summary>
        string LastTransactionID
        { get; set; }

        /// <summary>
        /// Gets or sets the payment method.
        /// </summary>
        string Method
        { get; set; }

        /// <summary>
        /// Gets or sets the payment's parent order.
        /// </summary>
        ISalesOrder ParentOrder
        { get; set; }
        
        /// <summary>
        /// Gets or sets the purchase order number.
        /// </summary>
        string PurchaseOrderNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the protection eligibility.
        /// </summary>
        string ProtectionEligibility
        { get; set; }

        /// <summary>
        /// Gets or sets the quote payment ID.
        /// </summary>
        int QuotePaymentID
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount.
        /// </summary>
        decimal ShippingAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount captured.
        /// </summary>
        decimal ShippingCaptured
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount refunded.
        /// </summary>
        decimal ShippingRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the payment notification message.
        /// </summary>
        string NotificationMessage
        { get; set; }
        
        /// <summary>
        /// Gets or sets the payment token.
        /// </summary>
        IVaultPaymentToken PaymentToken
        { get; set; }
    }
}
