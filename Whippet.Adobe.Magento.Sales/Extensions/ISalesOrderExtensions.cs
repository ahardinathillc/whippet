using System;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;
using Athi.Whippet.Adobe.Magento.Taxes.Extensions;
using Athi.Whippet.Adobe.Magento.EAV.Extensions;

namespace Athi.Whippet.Adobe.Magento.Sales.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ISalesOrder"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ISalesOrderExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ISalesOrder"/> object to a <see cref="SalesOrder"/> object.
        /// </summary>
        /// <param name="salesOrder"><see cref="ISalesOrder"/> object to convert.</param>
        /// <returns><see cref="SalesOrder"/> object.</returns>
        public static SalesOrder ToSalesOrder(this ISalesOrder salesOrder)
        {
            SalesOrder sa = null;

            if (salesOrder != null)
            {
                if (salesOrder is SalesOrder)
                {
                    sa = (SalesOrder)(salesOrder);
                }
                else
                {
                    sa = new SalesOrder();
                    sa.AdjustmentNegative = salesOrder.AdjustmentNegative;
                    sa.AdjustmentPositive = salesOrder.AdjustmentPositive;
                    sa.AppliedRuleIDs = salesOrder.AppliedRuleIDs;
                    sa.BaseAdjustmentNegative = salesOrder.BaseAdjustmentNegative;
                    sa.BaseAdjustmentPositive = salesOrder.BaseAdjustmentPositive;
                    sa.BaseCurrencyCode = salesOrder.BaseCurrencyCode;
                    sa.BaseCustomerBalanceAmount = salesOrder.BaseCustomerBalanceAmount;
                    sa.BaseCustomerBalanceInvoiced = salesOrder.BaseCustomerBalanceInvoiced;
                    sa.BaseCustomerBalanceRefunded = salesOrder.BaseCustomerBalanceRefunded;
                    sa.BaseCustomerBalanceTotalRefunded = salesOrder.BaseCustomerBalanceTotalRefunded;
                    sa.BaseDiscountAmount = salesOrder.BaseDiscountAmount;
                    sa.BaseDiscountCanceled = salesOrder.BaseDiscountCanceled;
                    sa.BaseDiscountInvoiced = salesOrder.BaseDiscountInvoiced;
                    sa.BaseDiscountRefunded = salesOrder.BaseDiscountRefunded;
                    sa.BaseDiscountTaxCompensationAmount = salesOrder.BaseDiscountTaxCompensationAmount;
                    sa.BaseDiscountTaxCompensationInvoiced = salesOrder.BaseDiscountTaxCompensationInvoiced;
                    sa.BaseDiscountTaxCompensationRefunded = salesOrder.BaseDiscountTaxCompensationRefunded;
                    sa.BaseGiftCardsAmount = salesOrder.BaseGiftCardsAmount;
                    sa.BaseGiftCardsInvoiced = salesOrder.BaseGiftCardsInvoiced;
                    sa.BaseGiftCardsRefunded = salesOrder.BaseGiftCardsRefunded;
                    sa.BaseGrandTotal = salesOrder.BaseGrandTotal;
                    sa.BaseRewardCurrencyAmount = salesOrder.BaseRewardCurrencyAmount;
                    sa.BaseRewardCurrencyAmountInvoiced = salesOrder.BaseRewardCurrencyAmountInvoiced;
                    sa.BaseRewardCurrencyAmountRefunded = salesOrder.BaseRewardCurrencyAmountRefunded;
                    sa.BaseShippingAmount = salesOrder.BaseShippingAmount;
                    sa.BaseShippingCanceled = salesOrder.BaseShippingCanceled;
                    sa.BaseShippingDiscountAmount = salesOrder.BaseShippingDiscountAmount;
                    sa.BaseShippingDiscountTaxCompensationAmount = salesOrder.BaseShippingDiscountTaxCompensationAmount;
                    sa.BaseShippingIncludingTax = salesOrder.BaseShippingIncludingTax;
                    sa.BaseShippingInvoiced = salesOrder.BaseShippingInvoiced;
                    sa.BaseShippingRefunded = salesOrder.BaseShippingRefunded;
                    sa.BaseShippingTaxAmount = salesOrder.BaseShippingTaxAmount;
                    sa.BaseShippingTaxRefunded = salesOrder.BaseShippingTaxRefunded;
                    sa.BaseSubtotal = salesOrder.BaseSubtotal;
                    sa.BaseSubtotalCanceled = salesOrder.BaseSubtotalCanceled;
                    sa.BaseSubtotalIncludingTax = salesOrder.BaseSubtotalIncludingTax;
                    sa.BaseSubtotalInvoiced = salesOrder.BaseSubtotalInvoiced;
                    sa.BaseSubtotalRefunded = salesOrder.BaseSubtotalRefunded;
                    sa.BaseTaxAmount = salesOrder.BaseTaxAmount;
                    sa.BaseTaxCanceled = salesOrder.BaseTaxCanceled;
                    sa.BaseTaxInvoiced = salesOrder.BaseTaxInvoiced;
                    sa.BaseTaxRefunded = salesOrder.BaseTaxRefunded;
                    sa.BaseToGlobalRate = salesOrder.BaseToGlobalRate;
                    sa.BaseToOrderRate = salesOrder.BaseToOrderRate;
                    sa.BaseTotalCanceled = salesOrder.BaseTotalCanceled;
                    sa.BaseTotalDue = salesOrder.BaseTotalDue;
                    sa.BaseTotalInvoiced = salesOrder.BaseTotalInvoiced;
                    sa.BaseTotalInvoicedCost = salesOrder.BaseTotalInvoicedCost;
                    sa.BaseTotalOfflineRefunded = salesOrder.BaseTotalOfflineRefunded;
                    sa.BaseTotalOnlineRefunded = salesOrder.BaseTotalOnlineRefunded;
                    sa.BaseTotalPaid = salesOrder.BaseTotalPaid;
                    sa.BaseTotalQuantityOrdered = salesOrder.BaseTotalQuantityOrdered;
                    sa.BaseTotalRefunded = salesOrder.BaseTotalRefunded;
                    sa.BillingAddress = salesOrder.BillingAddress.ToSalesOrderAddress();
                    sa.CanShipItemPartially = salesOrder.CanShipItemPartially;
                    sa.CanShipPartially = salesOrder.CanShipPartially;
                    sa.ChildID = salesOrder.ChildID;
                    sa.ChildRealID = salesOrder.ChildRealID;
                    sa.CouponCode = salesOrder.CouponCode;
                    sa.CouponRuleName = salesOrder.CouponRuleName;
                    ((ISalesOrder)(sa)).CreatedAt = salesOrder.CreatedAt;
                    sa.Customer = salesOrder.Customer.ToCustomer();
                    sa.CustomerBalanceAmount = salesOrder.CustomerBalanceAmount;
                    sa.CustomerBalanceInvoiced = salesOrder.CustomerBalanceInvoiced;
                    sa.CustomerBalanceRefunded = salesOrder.CustomerBalanceRefunded;
                    sa.CustomerBalanceTotalRefunded = salesOrder.CustomerBalanceTotalRefunded;
                    ((ISalesOrder)(sa)).CustomerDateOfBirth = salesOrder.CustomerDateOfBirth;
                    sa.CustomerEmail = salesOrder.CustomerEmail;
                    sa.CustomerFirstName = salesOrder.CustomerFirstName;
                    sa.CustomerGender = salesOrder.CustomerGender;
                    sa.CustomerGroup = salesOrder.CustomerGroup.ToCustomerGroup();
                    sa.CustomerIsGuest = salesOrder.CustomerIsGuest;
                    sa.CustomerLastName = salesOrder.CustomerLastName;
                    sa.CustomerMiddleName = salesOrder.CustomerMiddleName;
                    sa.CustomerNote = salesOrder.CustomerNote;
                    sa.CustomerNotifyNote = salesOrder.CustomerNotifyNote;
                    sa.CustomerPrefix = salesOrder.CustomerPrefix;
                    sa.CustomerSuffix = salesOrder.CustomerSuffix;
                    sa.CustomerValueAddedTax = salesOrder.CustomerValueAddedTax;
                    sa.DiscountAmount = salesOrder.DiscountAmount;
                    sa.DiscountCanceled = salesOrder.DiscountCanceled;
                    sa.DiscountDescription = salesOrder.DiscountDescription;
                    sa.DiscountInvoiced = salesOrder.DiscountInvoiced;
                    sa.DiscountRefunded = salesOrder.DiscountRefunded;
                    sa.DiscountTaxCompensationAmount = salesOrder.DiscountTaxCompensationAmount;
                    sa.DiscountTaxCompensationInvoiced = salesOrder.DiscountTaxCompensationInvoiced;
                    sa.DiscountTaxCompensationRefunded = salesOrder.DiscountTaxCompensationRefunded;
                    sa.EditIncrement = salesOrder.EditIncrement;
                    sa.EmailSent = salesOrder.EmailSent;
                    sa.EntityID = salesOrder.EntityID;
                    sa.ExternalCustomerID = salesOrder.ExternalCustomerID;
                    sa.ExternalOrderID = salesOrder.ExternalOrderID;
                    sa.ForcedShipmentWithInvoice = salesOrder.ForcedShipmentWithInvoice;
                    sa.GiftCards = salesOrder.GiftCards;
                    sa.GiftCardsAmount = salesOrder.GiftCardsAmount;
                    sa.GiftCardsInvoiced = salesOrder.GiftCardsInvoiced;
                    sa.GiftCardsRefunded = salesOrder.GiftCardsRefunded;
                    sa.GiftMessage = salesOrder.GiftMessage.ToGiftMessage();
                    sa.GlobalCurrencyCode = salesOrder.GlobalCurrencyCode;
                    sa.GrandTotal = salesOrder.GrandTotal;
                    sa.HoldBeforeState = salesOrder.HoldBeforeState;
                    sa.HoldBeforeStatus = salesOrder.HoldBeforeStatus;
                    sa.IncrementID = salesOrder.IncrementID;
                    sa.IsVirtual = salesOrder.IsVirtual;
                    sa.OrderCurrencyCode = salesOrder.OrderCurrencyCode;
                    sa.OriginalIncrementID = salesOrder.OriginalIncrementID;
                    sa.ParentID = salesOrder.ParentID;
                    sa.ParentRealID = salesOrder.ParentRealID;
                    sa.PaymentAuthorizationAmount = salesOrder.PaymentAuthorizationAmount;
                    sa.PaymentAuthorizationExpiration = salesOrder.PaymentAuthorizationExpiration;
                    sa.PayPalCustomerNotified = salesOrder.PayPalCustomerNotified;
                    sa.ProtectCode = salesOrder.ProtectCode;
                    sa.Quote = salesOrder.Quote.ToQuote();
                    sa.QuoteAddress = salesOrder.QuoteAddress.ToQuoteAddress();
                    sa.RemoteIP = salesOrder.RemoteIP;
                    sa.RewardCurrencyAmount = salesOrder.RewardCurrencyAmount;
                    sa.RewardCurrencyAmountInvoiced = salesOrder.RewardCurrencyAmountInvoiced;
                    sa.RewardCurrencyAmountRefunded = salesOrder.RewardCurrencyAmountRefunded;
                    sa.RewardPointsBalance = salesOrder.RewardPointsBalance;
                    sa.RewardPointsBalanceRefund = salesOrder.RewardPointsBalanceRefund;
                    sa.SendEmail = salesOrder.SendEmail;
                    sa.Server = salesOrder.Server.ToMagentoServer();
                    sa.ShippingAddress = salesOrder.ShippingAddress.ToSalesOrderAddress();
                    sa.ShippingAmount = salesOrder.ShippingAmount;
                    sa.ShippingCanceled = salesOrder.ShippingCanceled;
                    sa.ShippingDescription = salesOrder.ShippingDescription;
                    sa.ShippingDiscountAmount = salesOrder.ShippingDiscountAmount;
                    sa.ShippingDiscountTaxCompensationAmount = salesOrder.ShippingDiscountTaxCompensationAmount;
                    sa.ShippingIncludingTax = salesOrder.ShippingIncludingTax;
                    sa.ShippingInvoiced = salesOrder.ShippingInvoiced;
                    sa.ShippingMethod = salesOrder.ShippingMethod;
                    sa.ShippingRefunded = salesOrder.ShippingRefunded;
                    sa.ShippingTaxAmount = salesOrder.ShippingTaxAmount;
                    sa.ShippingTaxRefunded = salesOrder.ShippingTaxRefunded;
                    sa.State = salesOrder.State;
                    sa.Status = salesOrder.Status;
                    sa.Store = salesOrder.Store.ToStore();
                    sa.StoreCurrencyCode = salesOrder.StoreCurrencyCode;
                    sa.StoreName = salesOrder.StoreName;
                    sa.StoreToBaseRate = salesOrder.StoreToBaseRate;
                    sa.StoreToOrderRate = salesOrder.StoreToOrderRate;
                    sa.Subtotal = salesOrder.Subtotal;
                    sa.SubtotalCanceled = salesOrder.SubtotalCanceled;
                    sa.SubtotalIncludingTax = salesOrder.SubtotalIncludingTax;
                    sa.SubtotalInvoiced = salesOrder.SubtotalInvoiced;
                    sa.SubtotalCanceled = salesOrder.SubtotalCanceled;
                    sa.SubtotalIncludingTax = salesOrder.SubtotalIncludingTax;
                    sa.SubtotalInvoiced = salesOrder.SubtotalInvoiced;
                    sa.SubtotalRefunded = salesOrder.SubtotalRefunded;
                    sa.TaxAmount = salesOrder.TaxAmount;
                    sa.TaxCanceled = salesOrder.TaxCanceled;
                    sa.TaxInvoiced = salesOrder.TaxInvoiced;
                    sa.TaxRefunded = salesOrder.TaxRefunded;
                    sa.TotalCanceled = salesOrder.TotalCanceled;
                    sa.TotalDue = salesOrder.TotalDue;
                    sa.TotalInvoiced = salesOrder.TotalInvoiced;
                    sa.TotalItemCount = salesOrder.TotalItemCount;
                    sa.TotalPaid = salesOrder.TotalPaid;
                    sa.TotalQuantityOrdered = salesOrder.TotalQuantityOrdered;
                    sa.TotalRefunded = salesOrder.TotalRefunded;
                    sa.TotalRefundedOffline = salesOrder.TotalRefundedOffline;
                    sa.TotalRefundedOnline = salesOrder.TotalRefundedOnline;
                    sa.TransactionForwardedFor = salesOrder.TransactionForwardedFor;
                    ((ISalesOrder)(sa)).UpdatedAt = salesOrder.UpdatedAt;
                    sa.Weight = salesOrder.Weight;
                }
            }

            return sa;
        }
    }
}