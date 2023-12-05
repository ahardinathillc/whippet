using System;
using Athi.Whippet.Adobe.Magento.Vault.Extensions;

namespace Athi.Whippet.Adobe.Magento.Sales.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ISalesOrderPayment"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ISalesOrderPaymentExtensions
    {
        public static SalesOrderPayment ToSalesOrderPayment(this ISalesOrderPayment pmt)
        {
            SalesOrderPayment sop = null;

            if (pmt is SalesOrderPayment)
            {
                sop = (SalesOrderPayment)(pmt);
            }
            else if (pmt != null)
            {
                sop = new SalesOrderPayment();
                sop.AccountStatus = pmt.AccountStatus;
                sop.AdditionalData = pmt.AdditionalData;
                sop.AdditionalInformation = pmt.AdditionalInformation;
                sop.AddressStatus = pmt.AddressStatus;
                sop.AmountAuthorized = pmt.AmountAuthorized;
                sop.AmountCanceled = pmt.AmountCanceled;
                sop.AmountOrdered = pmt.AmountOrdered;
                sop.AmountPaid = pmt.AmountPaid;
                sop.AmountRefunded = pmt.AmountRefunded;
                sop.AuthorizeNetTransactionMethod = pmt.AuthorizeNetTransactionMethod;
                sop.AmountAuthorizedBase = pmt.AmountAuthorizedBase;
                sop.AmountCanceledBase = pmt.AmountCanceledBase;
                sop.AmountOrderedBase = pmt.AmountOrderedBase;
                sop.AmountPaidBase = pmt.AmountPaidBase;
                sop.AmountPaidOnlineBase = pmt.AmountPaidOnlineBase;
                sop.AmountRefundedBase = pmt.AmountRefundedBase;
                sop.AmountRefundedOnlineBase = pmt.AmountRefundedOnlineBase;
                sop.ShippingAmountBase = pmt.ShippingAmountBase;
                sop.ShippingAmountCaptured = pmt.ShippingAmountCaptured;
                sop.ShippingRefundedBase = pmt.ShippingRefundedBase;
                sop.CreditCardApproval = pmt.CreditCardApproval;
                sop.CreditCardAddressVerificationSystemStatus = pmt.CreditCardAddressVerificationSystemStatus;
                sop.CreditCardIdentificationVerificationStatus = pmt.CreditCardIdentificationVerificationStatus;
                sop.CreditCardDebugRequest = pmt.CreditCardDebugRequest;
                sop.CreditCardResponseBody = pmt.CreditCardResponseBody;
                sop.CreditCardDebugResponseSerialized = pmt.CreditCardDebugResponseSerialized;
                sop.CreditCardExpiration = pmt.CreditCardExpiration;
                sop.CreditCardLastFourDigits = pmt.CreditCardLastFourDigits;
                sop.CreditCardNumberEncrypted = pmt.CreditCardNumberEncrypted;
                sop.CreditCardNumber = pmt.CreditCardNumber;
                sop.CreditCardSecureVerify = pmt.CreditCardSecureVerify;
                sop.CreditCard_SS_Issue = pmt.CreditCard_SS_Issue;
                sop.CreditCard_SS_StartDate = pmt.CreditCard_SS_StartDate;
                sop.CreditCardStatus = pmt.CreditCardStatus;
                sop.CreditCardStatusDescription = pmt.CreditCardStatusDescription;
                sop.CreditCardTransactionID = pmt.CreditCardTransactionID;
                sop.CreditCardType = pmt.CreditCardType;
                sop.ElectronicChequeAccountName = pmt.ElectronicChequeAccountName;
                sop.ElectronicChequeAccountType = pmt.ElectronicChequeAccountType;
                sop.ElectronicChequeBankName = pmt.ElectronicChequeBankName;
                sop.ElectronicChequeRoutingNumber = pmt.ElectronicChequeRoutingNumber;
                sop.ElectronicChequeBankName = pmt.ElectronicChequeBankName;
                sop.ElectronicChequeRoutingNumber = pmt.ElectronicChequeRoutingNumber;
                sop.ElectronicChequeType = pmt.ElectronicChequeType;
                sop.LastTransactionID = pmt.LastTransactionID;
                sop.Method = pmt.Method;
                sop.ParentOrder = pmt.ParentOrder.ToSalesOrder();
                sop.PurchaseOrderNumber = pmt.PurchaseOrderNumber;
                sop.ProtectionEligibility = pmt.ProtectionEligibility;
                sop.QuotePaymentID = pmt.QuotePaymentID;
                sop.ShippingAmount = pmt.ShippingAmount;
                sop.ShippingCaptured = pmt.ShippingCaptured;
                sop.ShippingRefunded = pmt.ShippingRefunded;
                sop.NotificationMessage = pmt.NotificationMessage;
                sop.PaymentToken = pmt.PaymentToken.ToVaultPaymentToken();
            }

            return sop;
        }
    }
}
