using System;
using Athi.Whippet.Adobe.Magento.SalesRule.Extensions;
using Athi.Whippet.Adobe.Magento.Catalog.Inventory.StockItems.Extensions;
using Athi.Whippet.Adobe.Magento.Catalog.Products.Extensions;
using Athi.Whippet.Adobe.Magento.Store.Extensions;

namespace Athi.Whippet.Adobe.Magento.Sales.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ISalesOrderItem"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ISalesOrderItemExtensions
    {
        public static SalesOrderItem ToSalesOrderItem(this ISalesOrderItem item)
        {
            SalesOrderItem soi = null;

            if (item is SalesOrderItem)
            {
                soi = (SalesOrderItem)(soi);
            }
            else if (item != null)
            {
                soi.AdditionalData = item.AdditionalData;
                soi.AmountRefunded = item.AmountRefunded;
                soi.AppliedRules = (item.AppliedRules == null) ? null : item.AppliedRules.Select(ar => ar.ToSalesRule());
                soi.AmountRefundedBase = item.AmountRefundedBase;
                soi.CostBase = item.CostBase;
                soi.DiscountAmountBase = item.DiscountAmountBase;
                soi.DiscountInvoicedBase = item.DiscountInvoicedBase;
                soi.DiscountRefundedBase = item.DiscountRefundedBase;
                soi.DiscountTaxCompensationAmountBase = item.DiscountTaxCompensationAmountBase;
                soi.DiscountTaxCompensationInvoicedBase = item.DiscountTaxCompensationInvoicedBase;
                soi.DiscountTaxCompensationRefundedBase = item.DiscountTaxCompensationRefundedBase;
                soi.OriginalPriceBase = item.OriginalPriceBase;
                soi.PriceBase = item.PriceBase;
                soi.PriceWithTaxBase = item.PriceWithTaxBase;
                soi.RowInvoicedBase = item.RowInvoicedBase;
                soi.RowTotalBase = item.RowTotalBase;
                soi.RowTotalWithTaxBase = item.RowTotalWithTaxBase;
                soi.TaxAmountBase = item.TaxAmountBase;
                soi.TaxBeforeDiscountBase = item.TaxBeforeDiscountBase;
                soi.TaxInvoicedBase = item.TaxInvoicedBase;
                soi.TaxRefundedBase = item.TaxRefundedBase;
                soi.EcologicalTaxAppliedAmountBase = item.EcologicalTaxAppliedAmountBase;
                soi.EcologicalTaxAppliedRowAmountBase = item.EcologicalTaxAppliedRowAmountBase;
                soi.EcologicalTaxDispositionBase = item.EcologicalTaxDispositionBase;
                soi.EcologicalTaxRowDispositionBase = item.EcologicalTaxRowDispositionBase;
                soi.CreatedTimestamp = item.CreatedTimestamp;
                soi.Description = item.Description;
                soi.DiscountAmount = item.DiscountAmount;
                soi.DiscountInvoiced = item.DiscountInvoiced;
                soi.DiscountPercent = item.DiscountPercent;
                soi.DiscountRefunded = item.DiscountRefunded;
                soi.EventID = item.EventID;
                soi.ExternalItemID = item.ExternalItemID;
                soi.FreeShipping = item.FreeShipping;
                soi.GiftWrapPriceBase = item.GiftWrapPriceBase;
                soi.GiftWrapPriceInvoicedBase = item.GiftWrapPriceInvoicedBase;
                soi.GiftWrapPriceRefundedBase = item.GiftWrapPriceRefundedBase;
                soi.GiftWrapTaxAmountBase = item.GiftWrapTaxAmountBase;
                soi.GiftWrapTaxAmountInvoicedBase = item.GiftWrapTaxAmountInvoicedBase;
                soi.GiftWrapTaxAmountRefundedBase = item.GiftWrapTaxAmountRefundedBase;
                soi.GiftWrapID = item.GiftWrapID;
                soi.GiftWrapPrice = item.GiftWrapPrice;
                soi.GiftWrapPriceInvoiced = item.GiftWrapPriceInvoiced;
                soi.GiftWrapPriceRefunded = item.GiftWrapPriceRefunded;
                soi.GiftWrapTaxAmount = item.GiftWrapTaxAmount;
                soi.GiftWrapTaxAmountInvoiced = item.GiftWrapTaxAmountInvoiced;
                soi.GiftWrapTaxAmountRefunded = item.GiftWrapTaxAmountRefunded;
                soi.DiscountTaxCompensationAmount = item.DiscountTaxCompensationAmount;
                soi.DiscountTaxCompensationCanceled = item.DiscountTaxCompensationCanceled;
                soi.DiscountTaxCompensationInvoiced = item.DiscountTaxCompensationInvoiced;
                soi.DiscountTaxCompensationRefunded = item.DiscountTaxCompensationRefunded;
                soi.QuantityIsDecimal = item.QuantityIsDecimal;
                soi.IsVirtual = item.IsVirtual;
                soi.Item = item.Item.ToStockItem();
                soi.LockedInvoice = item.LockedInvoice;
                soi.LockedShipping = item.LockedShipping;
                soi.Name = item.Name;
                soi.NoDiscount = item.NoDiscount;
                soi.OrderID = item.OrderID;
                soi.OriginalPrice = item.OriginalPrice;
                soi.ParentItemID = item.ParentItemID;
                soi.Price = item.Price;
                soi.PriceWithTax = item.PriceWithTax;
                soi.Product = item.Product.ToProduct();
                soi.ProductType = item.ProductType;
                soi.QuantityBackordered = item.QuantityBackordered;
                soi.QuantityCanceled = item.QuantityCanceled;
                soi.QuantityInvoiced = item.QuantityInvoiced;
                soi.QuantityOrdered = item.QuantityOrdered;
                soi.QuantityRefunded = item.QuantityRefunded;
                soi.QuantityReturned = item.QuantityReturned;
                soi.QuantityShipped = item.QuantityShipped;
                soi.QuoteItemID = item.QuoteItemID;
                soi.RowInvoiced = item.RowInvoiced;
                soi.RowTotal = item.RowTotal;
                soi.RowTotalWithTax = item.RowTotalWithTax;
                soi.RowWeight = item.RowWeight;
                soi.TaxAmount = item.TaxAmount;
                soi.TaxBeforeDiscount = item.TaxBeforeDiscount;
                soi.TaxCanceled = item.TaxCanceled;
                soi.TaxInvoiced = item.TaxInvoiced;
                soi.TaxPercent = item.TaxPercent;
                soi.TaxRefunded = item.TaxRefunded;
                soi.UpdatedTimestamp = item.UpdatedTimestamp;
                soi.EcologicalTaxApplied = item.EcologicalTaxApplied;
                soi.EcologicalTaxAmount = item.EcologicalTaxAmount;
                soi.EcologicalTaxRowAmount = item.EcologicalTaxRowAmount;
                soi.EcologicalTaxDisposition = item.EcologicalTaxDisposition;
                soi.EcologicalTaxRowDisposition = item.EcologicalTaxRowDisposition;
                soi.Store = item.Store.ToStore();
                soi.Weight = item.Weight;
                soi.ParentItem = item.ParentItem;
                soi.ProductOption = item.ProductOption;
                soi.GiftMessage = item.GiftMessage;
                soi._GiftWrapID = item._GiftWrapID;
                soi._GiftWrapPriceBase = item._GiftWrapPriceBase;
                soi._GiftWrapPriceInvoiced = item._GiftWrapPriceInvoiced;
                soi._GiftWrapTaxAmountInvoicedBase = item._GiftWrapTaxAmountInvoicedBase;
                soi._GiftWrapTaxAmountInvoiced = item._GiftWrapTaxAmountInvoiced;
                soi._GiftWrapPriceRefundedBase = item._GiftWrapPriceRefundedBase;
                soi._GiftWrapPriceRefunded = item._GiftWrapPriceRefunded;
                soi._GiftWrapTaxAmountRefundedBase = item._GiftWrapTaxAmountRefundedBase;
                soi._GiftWrapTaxAmountRefunded = item._GiftWrapTaxAmountRefunded;
            }

            return soi;
        }
    }
}
