using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Interface that provides payment information for a Magento sales order.
    /// </summary>
    public class SalesOrderPaymentInterface : IExtensionInterface, IExtensionAttributes<SalesOrderPaymentExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the account status.
        /// </summary>
        [JsonProperty("account_status")]
        public string AccountStatus
        { get; set; }

        /// <summary>
        /// Gets or sets additional data about the payment.
        /// </summary>
        [JsonProperty("additional_data")]
        public string AdditionalData
        { get; set; }

        /// <summary>
        /// Gets or sets additional information about the payment.
        /// </summary>
        [JsonProperty("additional_information")]
        public string[] AdditionalInformation
        { get; set; }

        /// <summary>
        /// Gets or sets the address status.
        /// </summary>
        [JsonProperty("address_status")]
        public string AddressStatus
        { get; set; }

        /// <summary>
        /// Gets or sets the amount authorized.
        /// </summary>
        [JsonProperty("amount_authorized")]
        public decimal AmountAuthorized
        { get; set; }

        /// <summary>
        /// Gets or sets the amount canceled.
        /// </summary>
        [JsonProperty("amount_canceled")]
        public decimal AmountCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the amount ordered.
        /// </summary>
        [JsonProperty("amount_ordered")]
        public decimal AmountOrdered
        { get; set; }

        /// <summary>
        /// Gets or sets the amount paid.
        /// </summary>
        [JsonProperty("amount_paid")]
        public decimal AmountPaid
        { get; set; }

        /// <summary>
        /// Gets or sets the amount refunded.
        /// </summary>
        [JsonProperty("amount_refunded")]
        public decimal AmountRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the Authorize.NET transaction method.
        /// </summary>
        [JsonProperty("anet_trans_method")]
        public string AuthorizeNetTransactionMethod
        { get; set; }

        /// <summary>
        /// Gets or sets the amount authorized in base currency.
        /// </summary>
        [JsonProperty("base_amount_authorized")]
        public decimal AmountAuthorizedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the amount canceled in base currency.
        /// </summary>
        [JsonProperty("base_amount_canceled")]
        public decimal AmountCanceledBase
        { get; set; }

        /// <summary>
        /// Gets or sets the amount ordered in base currency.
        /// </summary>
        [JsonProperty("base_amount_ordered")]
        public decimal AmountOrderedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the amount paid in base currency.
        /// </summary>
        [JsonProperty("base_amount_paid")]
        public decimal AmountPaidBase
        { get; set; }

        /// <summary>
        /// Gets or sets the amount paid online in base currency.
        /// </summary>
        [JsonProperty("base_amount_paid_online")]
        public decimal AmountPaidOnlineBase
        { get; set; }

        /// <summary>
        /// Gets or sets the amount refunded in base currency.
        /// </summary>
        [JsonProperty("base_amount_refunded")]
        public decimal AmountRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the amount refunded online in base currency.
        /// </summary>
        [JsonProperty("base_amount_refunded_online")]
        public decimal AmountRefundedOnlineBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount in base currency.
        /// </summary>
        [JsonProperty("base_shipping_amount")]
        public decimal ShippingAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount captured in base currency.
        /// </summary>
        [JsonProperty("base_shipping_captured")]
        public decimal ShippingAmountCaptured
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount refunded in base currency.
        /// </summary>
        [JsonProperty("base_shipping_refunded")]
        public decimal ShippingRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card approval number.
        /// </summary>
        [JsonProperty("cc_approval")]
        public string CreditCardApproval
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card Address Verification System (AVS) status.
        /// </summary>
        [JsonProperty("cc_avs_status")]
        public string CreditCardAddressVerificationSystemStatus
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card Card Identification (CID) verification status.
        /// </summary>
        [JsonProperty("cc_cid_status")]
        public string CreditCardIdentificationVerificationStatus
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card debug request body.
        /// </summary>
        [JsonProperty("cc_debug_request_body")]
        public string CreditCardDebugRequest
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card response body.
        /// </summary>
        [JsonProperty("cc_debug_response_body")]
        public string CreditCardResponseBody
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card debug response serialized.
        /// </summary>
        [JsonProperty("cc_debug_response_serialized")]
        public string CreditCardDebugResponseSerialized
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card's expiration month.
        /// </summary>
        [JsonProperty("cc_exp_month")]
        public string CreditCardExpirationMonth
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card's expiration year.
        /// </summary>
        [JsonProperty("cc_exp_year")]
        public string CreditCardExpirationYear
        { get; set; }

        /// <summary>
        /// Gets or sets the last four digits of the credit card.
        /// </summary>
        [JsonProperty("cc_last4")]
        public string CreditCardLastFourDigits
        { get; set; }

        /// <summary>
        /// Gets or sets the (encrypted) credit card number.
        /// </summary>
        [JsonProperty("cc_number_enc")]
        public string CreditCardNumberEncrypted
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card number.
        /// </summary>
        [JsonProperty("cc_owner")]
        public string CreditCardNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card secure verify value.
        /// </summary>
        [JsonProperty("cc_secure_verify")]
        public string CreditCardSecureVerify
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card's SS issue.
        /// </summary>
        [JsonProperty("cc_ss_issue")]
        public string CreditCard_SS_Issue
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card's SS start month.
        /// </summary>
        [JsonProperty("cc_ss_start_month")]
        public string CreditCard_SS_StartMonth
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card's SS start year.
        /// </summary>
        [JsonProperty("cc_ss_start_year")]
        public string CreditCard_SS_StartYear
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card's status.
        /// </summary>
        [JsonProperty("cc_status")]
        public string CreditCardStatus
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card's status description.
        /// </summary>
        [JsonProperty("cc_status_description")]
        public string CreditCardStatusDescription
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card's transaction ID.
        /// </summary>
        [JsonProperty("cc_trans_id")]
        public string CreditCardTransactionID
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card type.
        /// </summary>
        [JsonProperty("cc_type")]
        public string CreditCardType
        { get; set; }

        /// <summary>
        /// Gets or sets the eCheque account name.
        /// </summary>
        [JsonProperty("echeck_account_name")]
        public string ElectronicChequeAccountName
        { get; set; }

        /// <summary>
        /// Gets or sets the eCheque account type.
        /// </summary>
        [JsonProperty("echeck_account_type")]
        public string ElectronicChequeAccountType
        { get; set; }

        /// <summary>
        /// Gets or sets the eCheque bank name.
        /// </summary>
        [JsonProperty("echeck_bank_name")]
        public string ElectronicChequeBankName
        { get; set; }

        /// <summary>
        /// Gets or sets the eCheque routing number.
        /// </summary>
        [JsonProperty("echeck_routing_number")]
        public string ElectronicChequeRoutingNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the eCheque type.
        /// </summary>
        [JsonProperty("echeck_type")]
        public string ElectronicChequeType
        { get; set; }

        /// <summary>
        /// Gets or sets the entity ID.
        /// </summary>
        [JsonProperty("entity_id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the last transaction ID.
        /// </summary>
        [JsonProperty("last_trans_id")]
        public string LastTransactionID
        { get; set; }

        /// <summary>
        /// Gets or sets the payment method.
        /// </summary>
        [JsonProperty("method")]
        public string Method
        { get; set; }

        /// <summary>
        /// Gets or sets the parent ID.
        /// </summary>
        [JsonProperty("parent_id")]
        public int ParentID
        { get; set; }

        /// <summary>
        /// Gets or sets the purchase order number.
        /// </summary>
        [JsonProperty("po_number")]
        public string PurchaseOrderNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the protection elegibility.
        /// </summary>
        [JsonProperty("protection_eligibility")]
        public string ProtectionEligibility
        { get; set; }

        /// <summary>
        /// Gets or sets the quote payment ID.
        /// </summary>
        [JsonProperty("quote_payment_id")]
        public int QuotePaymentID
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount.
        /// </summary>
        [JsonProperty("shipping_amount")]
        public decimal ShippingAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount captured.
        /// </summary>
        [JsonProperty("shipping_captured")]
        public decimal ShippingCaptured
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount refunded.
        /// </summary>
        [JsonProperty("shipping_refunded")]
        public decimal ShippingRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public SalesOrderPaymentExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderPaymentInterface"/> class with no arguments.
        /// </summary>
        public SalesOrderPaymentInterface()
        { }
    }
}
