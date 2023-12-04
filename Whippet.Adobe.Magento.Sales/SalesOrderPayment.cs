using System;
using System.Text;
using NodaTime;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Vault;
using Athi.Whippet.Adobe.Magento.Sales.Extensions;
using Athi.Whippet.Adobe.Magento.Vault.Extensions;
using MagentoCustomer = Athi.Whippet.Adobe.Magento.Customer.Customer;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Represents a payment for a <see cref="SalesOrder"/> in Magento.
    /// </summary>
    public class SalesOrderPayment : MagentoRestEntity<SalesOrderPaymentInterface>, IMagentoEntity, ISalesOrderPayment, IEqualityComparer<ISalesOrderPayment>, IMagentoRestEntity, IMagentoRestEntity<SalesOrderPaymentInterface>
    {
        private SalesOrder _order;
        private VaultPaymentToken _token;
        
        /// <summary>
        /// Gets or sets the account status.
        /// </summary>
        public virtual string AccountStatus
        { get; set; }

        /// <summary>
        /// Gets or sets additional data about the payment.
        /// </summary>
        public virtual string AdditionalData
        { get; set; }

        /// <summary>
        /// Gets or sets additional information about the payment.
        /// </summary>
        public virtual IEnumerable<string> AdditionalInformation
        { get; set; }

        /// <summary>
        /// Gets or sets the address status.
        /// </summary>
        public virtual string AddressStatus
        { get; set; }

        /// <summary>
        /// Gets or sets the amount authorized.
        /// </summary>
        public virtual decimal AmountAuthorized
        { get; set; }

        /// <summary>
        /// Gets or sets the amount canceled.
        /// </summary>
        public virtual decimal AmountCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the amount ordered.
        /// </summary>
        public virtual decimal AmountOrdered
        { get; set; }

        /// <summary>
        /// Gets or sets the amount paid.
        /// </summary>
        public virtual decimal AmountPaid
        { get; set; }

        /// <summary>
        /// Gets or sets the amount refunded.
        /// </summary>
        public virtual decimal AmountRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the Authorize.NET transaction method.
        /// </summary>
        public virtual string AuthorizeNetTransactionMethod
        { get; set; }

        /// <summary>
        /// Gets or sets the amount authorized in base currency.
        /// </summary>
        public virtual decimal AmountAuthorizedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the amount canceled in base currency.
        /// </summary>
        public virtual decimal AmountCanceledBase
        { get; set; }

        /// <summary>
        /// Gets or sets the amount ordered in base currency.
        /// </summary>
        public virtual decimal AmountOrderedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the amount paid in base currency.
        /// </summary>
        public virtual decimal AmountPaidBase
        { get; set; }

        /// <summary>
        /// Gets or sets the amount paid online in base currency.
        /// </summary>
        public virtual decimal AmountPaidOnlineBase
        { get; set; }

        /// <summary>
        /// Gets or sets the amount refunded in base currency.
        /// </summary>
        public virtual decimal AmountRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the amount refunded online in base currency.
        /// </summary>
        public virtual decimal AmountRefundedOnlineBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount in base currency.
        /// </summary>
        public virtual decimal ShippingAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount captured in base currency.
        /// </summary>
        public virtual decimal ShippingAmountCaptured
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount refunded in base currency.
        /// </summary>
        public virtual decimal ShippingRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card approval number.
        /// </summary>
        public virtual string CreditCardApproval
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card Address Verification System (AVS) status.
        /// </summary>
        public virtual string CreditCardAddressVerificationSystemStatus
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card Card Identification (CID) verification status.
        /// </summary>
        public virtual string CreditCardIdentificationVerificationStatus
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card debug request body.
        /// </summary>
        public virtual string CreditCardDebugRequest
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card response body.
        /// </summary>
        public virtual string CreditCardResponseBody
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card debug response serialized.
        /// </summary>
        public virtual string CreditCardDebugResponseSerialized
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card's expiration date.
        /// </summary>
        public virtual LocalDate? CreditCardExpiration
        { get; set; }
        
        /// <summary>
        /// Gets or sets the last four digits of the credit card.
        /// </summary>
        public virtual string CreditCardLastFourDigits
        { get; set; }

        /// <summary>
        /// Gets or sets the (encrypted) credit card number.
        /// </summary>
        public virtual string CreditCardNumberEncrypted
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card number.
        /// </summary>
        public virtual string CreditCardNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card secure verify value.
        /// </summary>
        public virtual string CreditCardSecureVerify
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card's SS issue.
        /// </summary>
        public virtual string CreditCard_SS_Issue
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card's SS start date.
        /// </summary>
        public virtual LocalDate? CreditCard_SS_StartDate
        { get; set; }
        
        /// <summary>
        /// Gets or sets the credit card's status.
        /// </summary>
        public virtual string CreditCardStatus
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card's status description.
        /// </summary>
        public virtual string CreditCardStatusDescription
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card's transaction ID.
        /// </summary>
        public virtual string CreditCardTransactionID
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card type.
        /// </summary>
        public virtual string CreditCardType
        { get; set; }

        /// <summary>
        /// Gets or sets the eCheque account name.
        /// </summary>
        public virtual string ElectronicChequeAccountName
        { get; set; }

        /// <summary>
        /// Gets or sets the eCheque account type.
        /// </summary>
        public virtual string ElectronicChequeAccountType
        { get; set; }

        /// <summary>
        /// Gets or sets the eCheque bank name.
        /// </summary>
        public virtual string ElectronicChequeBankName
        { get; set; }

        /// <summary>
        /// Gets or sets the eCheque routing number.
        /// </summary>
        public virtual string ElectronicChequeRoutingNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the eCheque type.
        /// </summary>
        public virtual string ElectronicChequeType
        { get; set; }

        /// <summary>
        /// Gets or sets the last transaction ID.
        /// </summary>
        public virtual string LastTransactionID
        { get; set; }

        /// <summary>
        /// Gets or sets the payment method.
        /// </summary>
        public virtual string Method
        { get; set; }

        /// <summary>
        /// Gets or sets the payment's parent order.
        /// </summary>
        public virtual SalesOrder ParentOrder
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
        /// Gets or sets the payment's parent order.
        /// </summary>
        ISalesOrder ISalesOrderPayment.ParentOrder
        {
            get
            {
                return ParentOrder;
            }
            set
            {
                ParentOrder = value.ToSalesOrder();
            }
        }
        
        /// <summary>
        /// Gets or sets the purchase order number.
        /// </summary>
        public virtual string PurchaseOrderNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the protection eligibility.
        /// </summary>
        public virtual string ProtectionEligibility
        { get; set; }

        /// <summary>
        /// Gets or sets the quote payment ID.
        /// </summary>
        public virtual int QuotePaymentID
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount.
        /// </summary>
        public virtual decimal ShippingAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount captured.
        /// </summary>
        public virtual decimal ShippingCaptured
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount refunded.
        /// </summary>
        public virtual decimal ShippingRefunded
        { get; set; }
        
        /// <summary>
        /// Gets or sets the payment notification message.
        /// </summary>
        public virtual string NotificationMessage
        { get; set; }

        /// <summary>
        /// Gets or sets the payment token.
        /// </summary>
        public virtual VaultPaymentToken PaymentToken
        {
            get
            {
                if (_token == null)
                {
                    _token = new VaultPaymentToken();
                }

                return _token;
            }
            set
            {
                _token = value;
            }
        }

        /// <summary>
        /// Gets or sets the payment token.
        /// </summary>
        IVaultPaymentToken ISalesOrderPayment.PaymentToken
        {
            get
            {
                return PaymentToken;
            }
            set
            {
                PaymentToken = value.ToVaultPaymentToken();
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderPayment"/> class with no arguments.
        /// </summary>
        public SalesOrderPayment()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderPayment"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public SalesOrderPayment(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderPayment"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public SalesOrderPayment(SalesOrderPaymentInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is ISalesOrderPayment)) ? false : Equals((ISalesOrderPayment)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ISalesOrderPayment obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ISalesOrderPayment x, ISalesOrderPayment y)
        {
            bool equals = base.Equals(x, y);

            if (equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.AccountStatus?.Trim(), y.AccountStatus?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.AdditionalData?.Trim(), y.AdditionalData?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && (((x.AdditionalInformation == null) && (y.AdditionalInformation == null)) || ((x.AdditionalInformation != null) && x.AdditionalInformation.SequenceEqual(y.AdditionalInformation)))
                         && String.Equals(x.AddressStatus?.Trim(), y.AddressStatus?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.AmountAuthorized == y.AmountAuthorized
                         && x.AmountCanceled == y.AmountCanceled
                         && x.AmountOrdered == y.AmountOrdered
                         && x.AmountPaid == y.AmountPaid
                         && x.AmountRefunded == y.AmountRefunded
                         && String.Equals(x.AuthorizeNetTransactionMethod?.Trim(), y.AuthorizeNetTransactionMethod?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.AmountAuthorizedBase == y.AmountAuthorizedBase
                         && x.AmountCanceledBase == y.AmountCanceledBase
                         && x.AmountOrderedBase == y.AmountOrderedBase
                         && x.AmountPaidBase == y.AmountPaidBase
                         && x.AmountPaidOnlineBase == y.AmountPaidOnlineBase
                         && x.AmountRefundedBase == y.AmountRefundedBase
                         && x.AmountRefundedOnlineBase == y.AmountRefundedOnlineBase
                         && x.ShippingAmountBase == y.ShippingAmountBase
                         && x.ShippingAmountCaptured == y.ShippingAmountCaptured
                         && x.ShippingRefundedBase == y.ShippingRefundedBase
                         && String.Equals(x.CreditCardApproval?.Trim(), y.CreditCardApproval?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.CreditCardAddressVerificationSystemStatus?.Trim(), y.CreditCardAddressVerificationSystemStatus?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.CreditCardDebugRequest?.Trim(), y.CreditCardDebugRequest?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.CreditCardResponseBody?.Trim(), y.CreditCardResponseBody?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.CreditCardDebugResponseSerialized?.Trim(), y.CreditCardDebugResponseSerialized?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.CreditCardExpiration.GetValueOrDefault().Equals(y.CreditCardExpiration.GetValueOrDefault())
                         && String.Equals(x.CreditCardLastFourDigits?.Trim(), y.CreditCardLastFourDigits?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.CreditCardNumberEncrypted?.Trim(), y.CreditCardNumberEncrypted?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.CreditCardNumber?.Trim(), y.CreditCardNumber?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.CreditCardSecureVerify?.Trim(), y.CreditCardSecureVerify?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.CreditCard_SS_Issue?.Trim(), y.CreditCard_SS_Issue?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.CreditCard_SS_StartDate.GetValueOrDefault().Equals(y.CreditCard_SS_StartDate.GetValueOrDefault())
                         && String.Equals(x.CreditCardStatus?.Trim(), y.CreditCardStatus?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.CreditCardStatusDescription?.Trim(), y.CreditCardStatusDescription?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.CreditCardTransactionID?.Trim(), y.CreditCardTransactionID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.CreditCardType?.Trim(), y.CreditCardType?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.ElectronicChequeAccountName?.Trim(), y.ElectronicChequeAccountName?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.ElectronicChequeAccountType?.Trim(), y.ElectronicChequeAccountType?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.ElectronicChequeBankName?.Trim(), y.ElectronicChequeBankName?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.ElectronicChequeRoutingNumber?.Trim(), y.ElectronicChequeRoutingNumber?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.ElectronicChequeType?.Trim(), y.ElectronicChequeType?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.LastTransactionID?.Trim(), y.LastTransactionID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.Method?.Trim(), y.Method?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && (((x.ParentOrder == null) && (y.ParentOrder == null)) || ((x.ParentOrder != null) && x.ParentOrder.Equals(y.AdditionalInformation)))
                         && String.Equals(x.PurchaseOrderNumber?.Trim(), y.PurchaseOrderNumber?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.ProtectionEligibility?.Trim(), y.ProtectionEligibility?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.QuotePaymentID == y.QuotePaymentID
                         && x.ShippingAmount == y.ShippingAmount
                         && x.ShippingCaptured == y.ShippingCaptured
                         && x.ShippingRefunded == y.ShippingRefunded;
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="SalesOrderPaymentInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="SalesOrderPaymentInterface"/>.</returns>
        public override SalesOrderPaymentInterface ToInterface()
        {
            SalesOrderPaymentInterface paymentInterface = new SalesOrderPaymentInterface();
            
            paymentInterface.AccountStatus = AccountStatus;
            paymentInterface.AdditionalData = AdditionalData;
            paymentInterface.AdditionalInformation = (AdditionalInformation == null) ? null : AdditionalInformation.ToArray();
            paymentInterface.AddressStatus = AddressStatus;
            paymentInterface.AmountAuthorized = AmountAuthorized;
            paymentInterface.AmountCanceled = AmountCanceled;
            paymentInterface.AmountOrdered = AmountOrdered;
            paymentInterface.AmountPaid = AmountPaid;
            paymentInterface.AmountRefunded = AmountRefunded;
            paymentInterface.AuthorizeNetTransactionMethod = AuthorizeNetTransactionMethod;
            paymentInterface.AmountAuthorizedBase = AmountAuthorizedBase;
            paymentInterface.AmountCanceledBase = AmountCanceledBase;
            paymentInterface.AmountOrderedBase = AmountOrderedBase;
            paymentInterface.AmountPaidBase = AmountPaidBase;
            paymentInterface.AmountPaidOnlineBase = AmountPaidOnlineBase;
            paymentInterface.AmountRefundedBase = AmountRefundedBase;
            paymentInterface.AmountRefundedOnlineBase = AmountRefundedOnlineBase;
            paymentInterface.ShippingAmountBase = ShippingAmountBase;
            paymentInterface.ShippingAmountCaptured = ShippingAmountCaptured;
            paymentInterface.ShippingRefundedBase = ShippingRefundedBase;
            paymentInterface.CreditCardApproval = CreditCardApproval;
            paymentInterface.CreditCardAddressVerificationSystemStatus = CreditCardAddressVerificationSystemStatus;
            paymentInterface.CreditCardIdentificationVerificationStatus = CreditCardIdentificationVerificationStatus;
            paymentInterface.CreditCardDebugRequest = CreditCardDebugRequest;
            paymentInterface.CreditCardResponseBody = CreditCardResponseBody;
            paymentInterface.CreditCardDebugResponseSerialized = CreditCardDebugResponseSerialized;

            if (CreditCardExpiration.HasValue)
            {
                paymentInterface.CreditCardExpirationMonth = CreditCardExpiration.GetValueOrDefault().Month.ToString();
                paymentInterface.CreditCardExpirationYear = CreditCardExpiration.GetValueOrDefault().Year.ToString();
            }

            paymentInterface.CreditCardLastFourDigits = CreditCardLastFourDigits;
            paymentInterface.CreditCardNumberEncrypted = CreditCardNumberEncrypted;
            paymentInterface.CreditCardNumber = CreditCardNumber;
            paymentInterface.CreditCardSecureVerify = CreditCardSecureVerify;
            paymentInterface.CreditCard_SS_Issue = CreditCard_SS_Issue;

            if (CreditCard_SS_StartDate.HasValue)
            {
                paymentInterface.CreditCard_SS_StartMonth = CreditCard_SS_StartDate.GetValueOrDefault().Month.ToString();
                paymentInterface.CreditCard_SS_StartYear = CreditCard_SS_StartDate.GetValueOrDefault().Year.ToString();
            }

            paymentInterface.CreditCardStatus = CreditCardStatus;
            paymentInterface.CreditCardStatusDescription = CreditCardStatusDescription;
            paymentInterface.CreditCardTransactionID = CreditCardTransactionID;
            paymentInterface.CreditCardType = CreditCardType;
            paymentInterface.ElectronicChequeAccountName = ElectronicChequeAccountName;
            paymentInterface.ElectronicChequeAccountType = ElectronicChequeAccountType;
            paymentInterface.ElectronicChequeBankName = ElectronicChequeBankName;
            paymentInterface.ElectronicChequeRoutingNumber = ElectronicChequeRoutingNumber;
            paymentInterface.ElectronicChequeType = ElectronicChequeType;
            paymentInterface.ID = ID;
            paymentInterface.LastTransactionID = LastTransactionID;
            paymentInterface.Method = Method;
            paymentInterface.ParentID = (ParentOrder == null) ? default(int) : ParentOrder.ID;
            paymentInterface.PurchaseOrderNumber = PurchaseOrderNumber;
            paymentInterface.ProtectionEligibility = ProtectionEligibility;
            paymentInterface.QuotePaymentID = QuotePaymentID;
            paymentInterface.ShippingAmount = ShippingAmount;
            paymentInterface.ShippingCaptured = ShippingCaptured;
            paymentInterface.ShippingRefunded = ShippingRefunded;
            paymentInterface.ExtensionAttributes = new SalesOrderPaymentExtensionInterface(NotificationMessage, PaymentToken.ToInterface());

            return paymentInterface;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            SalesOrderPayment payment = new SalesOrderPayment();

            payment.AccountStatus = AccountStatus;
            payment.AdditionalData = AdditionalData;
            payment.AdditionalInformation = (AdditionalInformation == null) ? null : AdditionalInformation.Select(i => i);
            payment.AddressStatus = AddressStatus;
            payment.AmountAuthorized = AmountAuthorized;
            payment.AmountCanceled = AmountCanceled;
            payment.AmountOrdered = AmountOrdered;
            payment.AmountPaid = AmountPaid;
            payment.AmountRefunded = AmountRefunded;
            payment.AuthorizeNetTransactionMethod = AuthorizeNetTransactionMethod;
            payment.AmountAuthorizedBase = AmountAuthorizedBase;
            payment.AmountCanceledBase = AmountCanceledBase;
            payment.AmountOrderedBase = AmountOrderedBase;
            payment.AmountPaidBase = AmountPaidBase;
            payment.AmountPaidOnlineBase = AmountPaidOnlineBase;
            payment.ShippingAmountBase = ShippingAmountBase;
            payment.ShippingAmountCaptured = ShippingAmountCaptured;
            payment.ShippingRefundedBase = ShippingRefundedBase;
            payment.CreditCardApproval = CreditCardApproval;
            payment.CreditCardAddressVerificationSystemStatus = CreditCardAddressVerificationSystemStatus;
            payment.CreditCardIdentificationVerificationStatus = CreditCardIdentificationVerificationStatus;
            payment.CreditCardDebugRequest = CreditCardDebugRequest;
            payment.CreditCardResponseBody = CreditCardResponseBody;
            payment.CreditCardDebugResponseSerialized = CreditCardDebugResponseSerialized;
            payment.CreditCardExpiration = CreditCardExpiration;
            payment.CreditCardLastFourDigits = CreditCardLastFourDigits;
            payment.CreditCardNumberEncrypted = CreditCardNumberEncrypted;
            payment.CreditCardNumber = CreditCardNumber;
            payment.CreditCardSecureVerify = CreditCardSecureVerify;
            payment.CreditCard_SS_Issue = CreditCard_SS_Issue;
            payment.CreditCard_SS_StartDate = CreditCard_SS_StartDate;
            payment.CreditCardStatus = CreditCardStatus;
            payment.CreditCardStatusDescription = CreditCardStatusDescription;
            payment.CreditCardTransactionID = CreditCardTransactionID;
            payment.CreditCardType = CreditCardType;
            payment.ElectronicChequeAccountName = ElectronicChequeAccountName;
            payment.ElectronicChequeBankName = ElectronicChequeBankName;
            payment.ElectronicChequeRoutingNumber = ElectronicChequeRoutingNumber;
            payment.ElectronicChequeType = ElectronicChequeType;
            payment.ID = ID;
            payment.LastTransactionID = LastTransactionID;
            payment.Method = Method;
            payment.ParentOrder = ParentOrder.Clone<SalesOrder>();
            payment.PurchaseOrderNumber = PurchaseOrderNumber;
            payment.ProtectionEligibility = ProtectionEligibility;
            payment.QuotePaymentID = QuotePaymentID;
            payment.ShippingAmount = ShippingAmount;
            payment.ShippingCaptured = ShippingCaptured;
            payment.ShippingRefunded = ShippingRefunded;
            payment.PaymentToken = PaymentToken.Clone<VaultPaymentToken>();

            return payment;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(AccountStatus); 
            hash.Add(AdditionalData);
            hash.Add(AdditionalInformation);
            hash.Add(AmountAuthorized);
            hash.Add(AmountCanceled);
            hash.Add(AmountOrdered);
            hash.Add(AmountPaid);
            hash.Add(AmountRefunded);
            hash.Add(AuthorizeNetTransactionMethod);
            hash.Add(AmountAuthorizedBase);
            hash.Add(AmountCanceledBase);
            hash.Add(AmountOrderedBase);
            hash.Add(AmountPaidBase);
            hash.Add(AmountPaidOnlineBase);
            hash.Add(ShippingAmountBase);
            hash.Add(ShippingAmountCaptured);
            hash.Add(ShippingRefundedBase);
            hash.Add(CreditCardApproval);
            hash.Add(CreditCardAddressVerificationSystemStatus);
            hash.Add(CreditCardIdentificationVerificationStatus);
            hash.Add(CreditCardDebugRequest);
            hash.Add(CreditCardResponseBody);
            hash.Add(CreditCardDebugResponseSerialized);
            hash.Add(CreditCardExpiration);
            hash.Add(CreditCardLastFourDigits);
            hash.Add(CreditCardNumberEncrypted);
            hash.Add(CreditCardNumber);
            hash.Add(CreditCardSecureVerify);
            hash.Add(CreditCard_SS_Issue);
            hash.Add(CreditCard_SS_StartDate);
            hash.Add(CreditCardStatus);
            hash.Add(CreditCardStatusDescription);
            hash.Add(CreditCardTransactionID);
            hash.Add(CreditCardType);
            hash.Add(ElectronicChequeAccountName);
            hash.Add(ElectronicChequeBankName);
            hash.Add(ElectronicChequeRoutingNumber);
            hash.Add(ElectronicChequeType);
            hash.Add(ID);
            hash.Add(LastTransactionID);
            hash.Add(Method);
            hash.Add(ParentOrder);
            hash.Add(PurchaseOrderNumber);
            hash.Add(ProtectionEligibility);
            hash.Add(QuotePaymentID);
            hash.Add(ShippingAmount);
            hash.Add(ShippingCaptured);
            hash.Add(ShippingRefunded);
            hash.Add(PaymentToken);

            return hash.ToHashCode();
        }

        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(SalesOrderPaymentInterface model)
        {
            if (model != null)
            {
                AccountStatus = model.AccountStatus;
                AdditionalData = model.AdditionalData;
                AdditionalInformation = model.AdditionalInformation;
                AddressStatus = model.AddressStatus;
                AmountAuthorized = model.AmountAuthorized;
                AmountCanceled = model.AmountCanceled;
                AmountOrdered = model.AmountOrdered;
                AmountPaid = model.AmountPaid;
                AmountRefunded = model.AmountRefunded;
                AuthorizeNetTransactionMethod = model.AuthorizeNetTransactionMethod;
                AmountAuthorizedBase = model.AmountAuthorizedBase;
                AmountCanceledBase = model.AmountCanceledBase;
                AmountOrderedBase = model.AmountOrderedBase;
                AmountPaidBase = model.AmountPaidBase;
                AmountPaidOnlineBase = model.AmountPaidOnlineBase;
                AmountRefundedBase = model.AmountRefundedBase;
                AmountRefundedOnlineBase = model.AmountRefundedOnlineBase;
                ShippingAmountBase = model.ShippingAmountBase;
                ShippingAmountCaptured = model.ShippingAmountCaptured;
                ShippingRefundedBase = model.ShippingRefundedBase;
                CreditCardApproval = model.CreditCardApproval;
                CreditCardAddressVerificationSystemStatus = model.CreditCardAddressVerificationSystemStatus;
                CreditCardIdentificationVerificationStatus = model.CreditCardIdentificationVerificationStatus;
                CreditCardDebugRequest = model.CreditCardDebugRequest;
                CreditCardResponseBody = model.CreditCardResponseBody;
                CreditCardDebugResponseSerialized = model.CreditCardDebugResponseSerialized;

                if (!String.IsNullOrWhiteSpace(model.CreditCardExpirationMonth) && !String.IsNullOrWhiteSpace(model.CreditCardExpirationYear))
                {
                    CreditCardExpiration = LocalDate.FromDateOnly(new DateOnly(Convert.ToInt32(model.CreditCardExpirationYear), Convert.ToInt32(model.CreditCardExpirationMonth), 1));
                }

                CreditCardLastFourDigits = model.CreditCardLastFourDigits;
                CreditCardNumberEncrypted = model.CreditCardNumberEncrypted;
                CreditCardNumber = model.CreditCardNumber;
                CreditCardSecureVerify = model.CreditCardSecureVerify;
                CreditCard_SS_Issue = model.CreditCard_SS_Issue;
                
                if (!String.IsNullOrWhiteSpace(model.CreditCard_SS_StartMonth) && !String.IsNullOrWhiteSpace(model.CreditCard_SS_StartYear))
                {
                    CreditCard_SS_StartDate = LocalDate.FromDateOnly(new DateOnly(Convert.ToInt32(model.CreditCard_SS_StartYear), Convert.ToInt32(model.CreditCard_SS_StartMonth), 1));
                }

                CreditCardStatus = model.CreditCardStatus;
                CreditCardStatusDescription = model.CreditCardStatusDescription;
                CreditCardTransactionID = model.CreditCardTransactionID;
                CreditCardType = model.CreditCardType;
                ElectronicChequeAccountName = model.ElectronicChequeAccountName;
                ElectronicChequeAccountType = model.ElectronicChequeAccountType;
                ElectronicChequeBankName = model.ElectronicChequeBankName;
                ElectronicChequeRoutingNumber = model.ElectronicChequeRoutingNumber;
                ElectronicChequeType = model.ElectronicChequeType;
                ID = model.ID;
                LastTransactionID = model.LastTransactionID;
                Method = model.Method;
                ParentOrder = new SalesOrder(Convert.ToUInt32(model.ParentID));
                PurchaseOrderNumber = model.PurchaseOrderNumber;
                ProtectionEligibility = model.ProtectionEligibility;
                QuotePaymentID = model.QuotePaymentID;
                ShippingAmount = model.ShippingAmount;
                ShippingCaptured = model.ShippingCaptured;
                ShippingRefunded = model.ShippingRefunded;

                if (model.ExtensionAttributes != null)
                {
                    NotificationMessage = model.ExtensionAttributes.NotificationMessage;
                    PaymentToken = new VaultPaymentToken(model.ExtensionAttributes.VaultPaymentToken);
                }
            }
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="address"><see cref="ISalesOrderPayment"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ISalesOrderPayment address)
        {
            ArgumentNullException.ThrowIfNull(address);
            return address.GetHashCode();
        }
    }
}
