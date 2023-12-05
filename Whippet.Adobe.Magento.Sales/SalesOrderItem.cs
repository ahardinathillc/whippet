using System;
using NodaTime;
using Athi.Whippet.Extensions;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Catalog.Products;
using Athi.Whippet.Adobe.Magento.Catalog.Inventory.StockItems;
using Athi.Whippet.Adobe.Magento.Store;
using Athi.Whippet.Adobe.Magento.Store.Extensions;
using Athi.Whippet.Adobe.Magento.SalesRule;
using Athi.Whippet.Adobe.Magento.Catalog.Inventory.StockItems.Extensions;
using Athi.Whippet.Adobe.Magento.Catalog.Products.Extensions;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.SalesRule.Extensions;
using MagentoSalesRule = Athi.Whippet.Adobe.Magento.SalesRule.SalesRule;
using MagentoGiftMessage = Athi.Whippet.Adobe.Magento.GiftMessage.GiftMessage;
using MagentoStore = Athi.Whippet.Adobe.Magento.Store.Store;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Represents a sales order item for a Magento <see cref="SalesOrder"/>.
    /// </summary>
    public class SalesOrderItem : MagentoRestEntity<SalesOrderItemInterface>, IMagentoEntity, ISalesOrderItem, IEqualityComparer<ISalesOrderItem>, IMagentoAuditableEntity, IMagentoRestEntity, IMagentoRestEntity<SalesOrderItemInterface>
    {
        private StockItem _item;
        private Product _product;
        private SalesOrderItem _parentSalesOrderItem;
        private MagentoStore _store;
        
        /// <summary>
        /// Gets or sets additional data.
        /// </summary>
        public virtual string AdditionalData
        { get; set; }

        /// <summary>
        /// Gets or sets the amount refunded.
        /// </summary>
        public virtual decimal AmountRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the applied rules.
        /// </summary>
        public virtual IEnumerable<MagentoSalesRule> AppliedRules
        { get; set; }

        /// <summary>
        /// Gets or sets the applied rules.
        /// </summary>
        IEnumerable<ISalesRule> ISalesOrderItem.AppliedRules
        {
            get
            {
                return AppliedRules;
            }
            set
            {
                AppliedRules = (value == null) ? null : AppliedRules.Select(ar => ar.ToSalesRule());
            }
        }
        
        /// <summary>
        /// Gets or sets the base amount refunded in base currency.
        /// </summary>
        public virtual decimal AmountRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the item cost in base currency.
        /// </summary>
        public virtual decimal CostBase
        { get; set; }

        /// <summary>
        /// Gets or sets the base discount amount in base currency.
        /// </summary>
        public virtual decimal DiscountAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount invoiced in base currency.
        /// </summary>
        public virtual decimal DiscountInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the discount refunded amount in base currency.
        /// </summary>
        public virtual decimal DiscountRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation amount in base currency.
        /// </summary>
        public virtual decimal DiscountTaxCompensationAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation invoiced in base currency.
        /// </summary>
        public virtual decimal DiscountTaxCompensationInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation refunded in base currency.
        /// </summary>
        public virtual decimal DiscountTaxCompensationRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the original price in base currency.
        /// </summary>
        public virtual decimal OriginalPriceBase
        { get; set; }

        /// <summary>
        /// Gets or sets the price in base currency.
        /// </summary>
        public virtual decimal PriceBase
        { get; set; }

        /// <summary>
        /// Gets or sets the price including tax in base currency.
        /// </summary>
        public virtual decimal PriceWithTaxBase
        { get; set; }

        /// <summary>
        /// Gets or sets the row invoiced in base currency.
        /// </summary>
        public virtual decimal RowInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the row total in base currency.
        /// </summary>
        public virtual decimal RowTotalBase
        { get; set; }

        /// <summary>
        /// Gets or sets the row total including tax in base currency.
        /// </summary>
        public virtual decimal RowTotalWithTaxBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount in base currency.
        /// </summary>
        public virtual decimal TaxAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount before discount in base currency.
        /// </summary>
        public virtual decimal TaxBeforeDiscountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount invoiced in base currency.
        /// </summary>
        public virtual decimal TaxInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount refunded in base currency.
        /// </summary>
        public virtual decimal TaxRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the Waste Electrical and Electronic Equipment Device (WEEE) tax that was applied in base currency. 
        /// </summary>
        public virtual decimal EcologicalTaxAppliedAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the Waste Electrical and Electronic Equipment Device (WEEE) tax that as applied to the row in base currency.
        /// </summary>
        public virtual decimal EcologicalTaxAppliedRowAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the Waste Electrical and Electronic Equipment Device (WEEE) tax disposition in base currency.
        /// </summary>
        public virtual decimal EcologicalTaxDispositionBase
        { get; set; }

        /// <summary>
        /// Gets or sets the Waste Electrical and Electronic Equipment Device (WEEE) tax disposition applied to the row in base currency.
        /// </summary>
        public virtual decimal EcologicalTaxRowDispositionBase
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the entity was created.
        /// </summary>
        public virtual Instant CreatedTimestamp
        { get; set; }

        /// <summary>
        /// Gets or sets the order item description.
        /// </summary>
        public virtual string Description
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount.
        /// </summary>
        public virtual decimal DiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount that was invoiced.
        /// </summary>
        public virtual decimal DiscountInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the discount percentage.
        /// </summary>
        public virtual decimal DiscountPercent
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount refunded.
        /// </summary>
        public virtual decimal DiscountRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the event ID.
        /// </summary>
        public virtual int EventID
        { get; set; }

        /// <summary>
        /// Gets or sets the external order item ID.
        /// </summary>
        public virtual string ExternalItemID
        { get; set; }

        /// <summary>
        /// Flag that specifies whether the item has free shipping. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        public virtual bool FreeShipping
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price in base currency.
        /// </summary>
        public virtual decimal GiftWrapPriceBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price invoiced in base currency.
        /// </summary>
        public virtual decimal GiftWrapPriceInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price refunded in base currency.
        /// </summary>
        public virtual decimal GiftWrapPriceRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap tax amount in base currency.
        /// </summary>
        public virtual decimal GiftWrapTaxAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap tax amount invoiced in base currency.
        /// </summary>
        public virtual decimal GiftWrapTaxAmountInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap tax amount refunded in base currency.
        /// </summary>
        public virtual decimal GiftWrapTaxAmountRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap ID.
        /// </summary>
        public virtual int GiftWrapID
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price.
        /// </summary>
        public virtual decimal GiftWrapPrice
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price invoiced.
        /// </summary>
        public virtual decimal GiftWrapPriceInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price refunded.
        /// </summary>
        public virtual decimal GiftWrapPriceRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap tax amount.
        /// </summary>
        public virtual decimal GiftWrapTaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap tax amount invoiced.
        /// </summary>
        public virtual decimal GiftWrapTaxAmountInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap tax amount refunded.
        /// </summary>
        public virtual decimal GiftWrapTaxAmountRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation amount.
        /// </summary>
        public virtual decimal DiscountTaxCompensationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation amount that was canceled.
        /// </summary>
        public virtual decimal DiscountTaxCompensationCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation amount invoiced.
        /// </summary>
        public virtual decimal DiscountTaxCompensationInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation amount refunded.
        /// </summary>
        public virtual decimal DiscountTaxCompensationRefunded
        { get; set; }

        /// <summary>
        /// Specifies whether quantity is an <see cref="Int32"/> or <see cref="Decimal"/>.
        /// </summary>
        public virtual bool QuantityIsDecimal
        { get; set; }

        /// <summary>
        /// Specifies whether the order item is virtual.
        /// </summary>
        public virtual bool IsVirtual
        { get; set; }

        /// <summary>
        /// Gets or sets the parent <see cref="StockItem"/> object.
        /// </summary>
        public virtual StockItem Item
        {
            get
            {
                if (_item == null)
                {
                    _item = new StockItem();
                }

                return _item;
            }
            set
            {
                _item = value;
            }
        }

        /// <summary>
        /// Gets or sets the parent <see cref="IStockItem"/> object.
        /// </summary>
        IStockItem ISalesOrderItem.Item
        {
            get
            {
                return Item;
            }
            set
            {
                Item = value.ToStockItem();
            }
        }
        
        /// <summary>
        /// Flag that indicates whether the invoice is locked. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        public virtual bool LockedInvoice
        { get; set; }

        /// <summary>
        /// Flag that indicates whether the shipping is locked. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        public virtual bool LockedShipping
        { get; set; }

        /// <summary>
        /// Gets or sets the item name. 
        /// </summary>
        public virtual string Name
        { get; set; }

        /// <summary>
        /// Flag that indicates whether there is no discount. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        public virtual bool NoDiscount
        { get; set; }

        /// <summary>
        /// Gets or sets the order ID.
        /// </summary>
        public virtual int OrderID
        { get; set; }

        /// <summary>
        /// Gets or sets the original price.
        /// </summary>
        public virtual decimal OriginalPrice
        { get; set; }

        /// <summary>
        /// Gets or sets the parent item ID.
        /// </summary>
        public virtual int ParentItemID
        { get; set; }

        /// <summary>
        /// Gets or sets the item price.
        /// </summary>
        public virtual decimal Price
        { get; set; }

        /// <summary>
        /// Gets or sets the item price including tax.
        /// </summary>
        public virtual decimal PriceWithTax
        { get; set; }

        /// <summary>
        /// Gets or sets the order item's product.
        /// </summary>
        public virtual Product Product
        {
            get
            {
                if (_product == null)
                {
                    _product = new Product();
                }

                return _product;
            }
            set
            {
                _product = value;
            }
        }

        /// <summary>
        /// Gets or sets the order item's product.
        /// </summary>
        IProduct ISalesOrderItem.Product
        {
            get
            {
                return Product;
            }
            set
            {
                Product = value.ToProduct();
            }
        }
        
        /// <summary>
        /// Gets or sets the product type.
        /// </summary>
        public virtual ProductType ProductType
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity backordered.
        /// </summary>
        public virtual decimal QuantityBackordered
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity canceled.
        /// </summary>
        public virtual decimal QuantityCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity invoiced.
        /// </summary>
        public virtual decimal QuantityInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity ordered.
        /// </summary>
        public virtual decimal QuantityOrdered
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity refunded. 
        /// </summary>
        public virtual decimal QuantityRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity returned.
        /// </summary>
        public virtual decimal QuantityReturned
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity shipped.
        /// </summary>
        public virtual decimal QuantityShipped
        { get; set; }

        /// <summary>
        /// Gets or sets the quote item ID.
        /// </summary>
        public virtual int QuoteItemID
        { get; set; }

        /// <summary>
        /// Gets or sets the row invoiced.
        /// </summary>
        public virtual decimal RowInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the row total.
        /// </summary>
        public virtual decimal RowTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the row total with tax.
        /// </summary>
        public virtual decimal RowTotalWithTax
        { get; set; }

        /// <summary>
        /// Gets or sets the row weight.
        /// </summary>
        public virtual decimal RowWeight
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount.
        /// </summary>
        public virtual decimal TaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount before discount.
        /// </summary>
        public virtual decimal TaxBeforeDiscount
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount canceled.
        /// </summary>
        public virtual decimal TaxCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount invoiced.
        /// </summary>
        public virtual decimal TaxInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the tax percentage.
        /// </summary>
        public virtual decimal TaxPercent
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount refunded.
        /// </summary>
        public virtual decimal TaxRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the entity was last updated (if any).
        /// </summary>
        public virtual Instant? UpdatedTimestamp
        { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Waste Electrical and Electronic Equipment Device (WEEE) tax was applied.
        /// </summary>
        public virtual string EcologicalTaxApplied
        { get; set; }
        
        /// <summary>
        /// Gets or sets the item's Waste Electrical and Electronic Equipment Device (WEEE) tax.
        /// </summary>
        public virtual decimal EcologicalTaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the row's Waste Electrical and Electronic Equipment Device (WEEE) tax.
        /// </summary>
        public virtual decimal EcologicalTaxRowAmount
        { get; set; }
        
        /// <summary>
        /// Gets or sets the item's Waste Electrical and Electronic Equipment Device (WEEE) tax disposition.
        /// </summary>
        public virtual decimal EcologicalTaxDisposition
        { get; set; }
        
        /// <summary>
        /// Gets or sets the row's Waste Electrical and Electronic Equipment Device (WEEE) tax disposition.
        /// </summary>
        public virtual decimal EcologicalTaxRowDisposition
        { get; set; }

        /// <summary>
        /// Gets or sets the weight of the item.
        /// </summary>
        public virtual decimal Weight
        { get; set; }

        /// <summary>
        /// Gets or sets the parent order item.
        /// </summary>
        public virtual SalesOrderItem ParentItem
        { get; set; }

        /// <summary>
        /// Gets or sets the store that the sales order item is associated with.
        /// </summary>
        public virtual MagentoStore Store
        {
            get
            {
                if (_store == null)
                {
                    _store = new MagentoStore();
                }

                return _store;
            }
            set
            {
                _store = value;
            }
        }

        /// <summary>
        /// Gets or sets the store that the sales order item is associated with.
        /// </summary>
        IStore ISalesOrderItem.Store
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
        /// Gets or sets the product options for the item.
        /// </summary>
        public virtual ProductOption ProductOption
        { get; set; }
        
        /// <summary>
        /// Gets or sets the gift message associated with the order item.
        /// </summary>
        public virtual MagentoGiftMessage GiftMessage
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap ID.
        /// </summary>
        public virtual string _GiftWrapID
        { get; set; }
        
        /// <summary>
        /// Gets or sets the gift wrap price in base currency.
        /// </summary>
        public virtual string _GiftWrapPriceBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price.
        /// </summary>
        public virtual string _GiftWrapPrice
        { get; set; }
                
        /// <summary>
        /// Gets or sets the gift wrap tax amount in base currency.
        /// </summary>
        public virtual string _GiftWrapTaxAmountBase
        { get; set; }
        
        /// <summary>
        /// Gets or sets the gift wrap tax amount.
        /// </summary>
        public virtual string _GiftWrapTaxAmount
        { get; set; }
        
        /// <summary>
        /// Gets or sets the gift wrap price invoiced in base currency.
        /// </summary>
        public virtual string _GiftWrapPriceInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price invoiced.
        /// </summary>
        public virtual string _GiftWrapPriceInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap tax amount invoiced in base currency.
        /// </summary>
        public virtual string _GiftWrapTaxAmountInvoicedBase
        { get; set; }
        
        /// <summary>
        /// Gets or sets the gift wrap tax amount invoiced.
        /// </summary>
        public virtual string _GiftWrapTaxAmountInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price refunded in base currency.
        /// </summary>
        public virtual string _GiftWrapPriceRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price refunded.
        /// </summary>
        public virtual string _GiftWrapPriceRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap tax amount refunded in base currency.
        /// </summary>
        public virtual string _GiftWrapTaxAmountRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap tax amount refunded.
        /// </summary>
        public virtual string _GiftWrapTaxAmountRefunded
        { get; set; }        

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderItem"/> class with no arguments.
        /// </summary>
        public SalesOrderItem()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderItem"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public SalesOrderItem(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderItem"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public SalesOrderItem(SalesOrderItemInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is ISalesOrderItem)) ? false : Equals((ISalesOrderItem)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ISalesOrderItem obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ISalesOrderItem x, ISalesOrderItem y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.AdditionalData?.Trim(), y.AdditionalData?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.AmountRefunded == y.AmountRefunded
                         && (((x.AppliedRules == null) && (y.AppliedRules == null)) || ((x.AppliedRules != null) && x.AppliedRules.SequenceEqual(y.AppliedRules)))
                         && x.AmountRefundedBase == y.AmountRefundedBase
                         && x.CostBase == y.CostBase
                         && x.DiscountAmountBase == y.DiscountAmountBase
                         && x.DiscountInvoicedBase == y.DiscountInvoicedBase
                         && x.DiscountRefundedBase == y.DiscountRefundedBase
                         && x.DiscountTaxCompensationAmountBase == y.DiscountTaxCompensationAmountBase
                         && x.DiscountTaxCompensationInvoicedBase == y.DiscountTaxCompensationInvoicedBase
                         && x.DiscountTaxCompensationRefundedBase == y.DiscountTaxCompensationRefundedBase
                         && x.OriginalPriceBase == y.OriginalPriceBase
                         && x.PriceBase == y.PriceBase
                         && x.PriceWithTaxBase == y.PriceWithTaxBase
                         && x.RowInvoicedBase == y.RowInvoicedBase
                         && x.RowTotalBase == y.RowTotalBase
                         && x.RowTotalWithTaxBase == y.RowTotalWithTaxBase
                         && x.TaxAmountBase == y.TaxAmountBase
                         && x.TaxBeforeDiscountBase == y.TaxBeforeDiscountBase
                         && x.TaxInvoicedBase == y.TaxInvoicedBase
                         && x.TaxRefundedBase == y.TaxRefundedBase
                         && x.EcologicalTaxAppliedAmountBase == y.EcologicalTaxAppliedAmountBase
                         && x.EcologicalTaxAppliedRowAmountBase == y.EcologicalTaxAppliedRowAmountBase
                         && x.EcologicalTaxDispositionBase == y.EcologicalTaxDispositionBase
                         && x.EcologicalTaxRowDispositionBase == y.EcologicalTaxRowDispositionBase
                         && x.CreatedTimestamp.Equals(y.CreatedTimestamp)
                         && String.Equals(x.Description?.Trim(), y.Description?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.DiscountAmount == y.DiscountAmount
                         && x.DiscountInvoiced == y.DiscountInvoiced
                         && x.DiscountPercent == y.DiscountPercent
                         && x.DiscountRefunded == y.DiscountRefunded
                         && x.EventID == y.EventID
                         && String.Equals(x.ExternalItemID?.Trim(), y.ExternalItemID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.FreeShipping == y.FreeShipping
                         && x.GiftWrapPriceBase == y.GiftWrapPriceBase
                         && x.GiftWrapPriceInvoicedBase == y.GiftWrapPriceInvoicedBase
                         && x.GiftWrapPriceRefundedBase == y.GiftWrapPriceRefundedBase
                         && x.GiftWrapTaxAmountBase == y.GiftWrapTaxAmountBase
                         && x.GiftWrapTaxAmountInvoicedBase == y.GiftWrapTaxAmountInvoicedBase
                         && x.GiftWrapTaxAmountRefundedBase == y.GiftWrapTaxAmountRefundedBase
                         && x.GiftWrapID == y.GiftWrapID
                         && x.GiftWrapPrice == y.GiftWrapPrice
                         && x.GiftWrapPriceInvoiced == y.GiftWrapPriceInvoiced
                         && x.GiftWrapPriceRefunded == y.GiftWrapPriceRefunded
                         && x.GiftWrapTaxAmount == y.GiftWrapTaxAmountBase
                         && x.GiftWrapTaxAmountInvoiced == y.GiftWrapTaxAmountInvoiced
                         && x.GiftWrapTaxAmountRefunded == y.GiftWrapTaxAmountRefunded
                         && x.DiscountTaxCompensationAmount == y.DiscountTaxCompensationAmount
                         && x.DiscountTaxCompensationCanceled == y.DiscountTaxCompensationCanceled
                         && x.DiscountTaxCompensationInvoiced == y.DiscountTaxCompensationInvoiced
                         && x.DiscountTaxCompensationRefunded == y.DiscountTaxCompensationRefunded
                         && x.QuantityIsDecimal == y.QuantityIsDecimal
                         && x.IsVirtual == y.IsVirtual
                         && (((x.Item == null) && (y.Item == null)) || ((x.Item != null) && x.Item.Equals(y.Item)))
                         && x.LockedInvoice == y.LockedInvoice
                         && x.LockedShipping == y.LockedShipping
                         && String.Equals(x.Name?.Trim(), y.Name?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.NoDiscount == y.NoDiscount
                         && x.OrderID == y.OrderID
                         && x.OriginalPrice == y.OriginalPrice
                         && x.ParentItemID == y.ParentItemID
                         && x.Price == y.Price
                         && x.PriceWithTax == y.PriceWithTax
                         && (((x.Product == null) && (y.Product == null)) || ((x.Product != null) && x.Product.Equals(y.Product)))
                         && x.ProductType.Equals(y.ProductType)
                         && x.QuantityBackordered == y.QuantityBackordered
                         && x.QuantityCanceled == y.QuantityCanceled
                         && x.QuantityInvoiced == y.QuantityInvoiced
                         && x.QuantityOrdered == y.QuantityOrdered
                         && x.QuantityRefunded == y.QuantityRefunded
                         && x.QuantityReturned == y.QuantityReturned
                         && x.QuantityShipped == y.QuantityShipped
                         && x.QuoteItemID == y.QuoteItemID
                         && x.RowInvoiced == y.RowInvoiced
                         && x.RowTotal == y.RowTotal
                         && x.RowTotalWithTax == y.RowTotalWithTax
                         && x.RowWeight == y.RowWeight
                         && x.TaxAmount == y.TaxAmount
                         && x.TaxBeforeDiscount == y.TaxBeforeDiscount
                         && x.TaxCanceled == y.TaxCanceled
                         && x.TaxInvoiced == y.TaxInvoiced
                         && x.TaxPercent == y.TaxPercent
                         && x.TaxRefunded == y.TaxRefunded
                         && x.UpdatedTimestamp.GetValueOrDefault().Equals(y.UpdatedTimestamp.GetValueOrDefault())
                         && String.Equals(x.EcologicalTaxApplied?.Trim(), y.EcologicalTaxApplied?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.EcologicalTaxAmount == y.EcologicalTaxAmount
                         && x.EcologicalTaxRowAmount == y.EcologicalTaxRowAmount
                         && x.EcologicalTaxDisposition == y.EcologicalTaxDisposition
                         && x.Weight == y.Weight
                         && (((x.ParentItem == null) && (y.ParentItem == null)) || ((x.ParentItem != null) && x.ParentItem.Equals(y.ParentItem)))
                         && x.ProductOption.Equals(y.ProductOption)
                         && x.GiftMessage.Equals(y.GiftMessage)
                         && x.EcologicalTaxRowDisposition == y.EcologicalTaxRowDisposition
                         && (((x.Store == null) && (y.Store == null)) || ((x.Store != null) && x.Store.Equals(y.Store)))
                         && String.Equals(x._GiftWrapID?.Trim(), y._GiftWrapID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x._GiftWrapPriceBase?.Trim(), y._GiftWrapPriceBase?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x._GiftWrapPrice?.Trim(), y._GiftWrapPrice?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x._GiftWrapTaxAmountBase?.Trim(), y._GiftWrapTaxAmountBase?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x._GiftWrapTaxAmount?.Trim(), y._GiftWrapTaxAmount?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x._GiftWrapPriceInvoicedBase?.Trim(), y._GiftWrapPriceInvoicedBase?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x._GiftWrapTaxAmountInvoicedBase?.Trim(), y._GiftWrapTaxAmountInvoicedBase?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x._GiftWrapTaxAmountInvoiced?.Trim(), y._GiftWrapTaxAmountInvoiced?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x._GiftWrapPriceRefundedBase?.Trim(), y._GiftWrapPriceRefundedBase?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x._GiftWrapPriceRefunded?.Trim(), y._GiftWrapPriceRefunded?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x._GiftWrapTaxAmountRefundedBase?.Trim(), y._GiftWrapTaxAmountRefundedBase?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x._GiftWrapTaxAmountRefunded?.Trim(), y._GiftWrapTaxAmountRefunded?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && (((x.Server == null) && (y.Server == null)) || ((x.Server != null) && x.Server.Equals(y.Server)))
                         && (((x.RestEndpoint == null) && (y.RestEndpoint == null)) || ((x.RestEndpoint != null) && x.RestEndpoint.Equals(y.RestEndpoint)));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="SalesOrderItemInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="SalesOrderItemInterface"/>.</returns>
        public override SalesOrderItemInterface ToInterface()
        {
            SalesOrderItemInterface item = new SalesOrderItemInterface();

            item.AdditionalData = AdditionalData;
            item.AmountRefunded = AmountRefunded;
            item.AppliedRuleIDs = (AppliedRules == null) ? String.Empty : AppliedRules.Select(ar => ar.ID.ToString()).Concat(",");
            item.AmountRefundedBase = AmountRefundedBase;
            item.CostBase = CostBase;
            item.DiscountAmountBase = DiscountAmountBase;
            item.DiscountInvoicedBase = DiscountInvoicedBase;
            item.DiscountRefundedBase = DiscountRefundedBase;
            item.DiscountTaxCompensationAmountBase = DiscountTaxCompensationAmountBase;
            item.DiscountTaxCompensationInvoicedBase = DiscountTaxCompensationInvoicedBase;
            item.DiscountTaxCompensationRefundedBase = DiscountTaxCompensationRefundedBase;
            item.OriginalPriceBase = OriginalPriceBase;
            item.PriceBase = PriceBase;
            item.PriceWithTaxBase = PriceWithTaxBase;
            item.RowInvoicedBase = RowInvoicedBase;
            item.RowTotalBase = RowTotalBase;
            item.RowTotalWithTaxBase = RowTotalWithTaxBase;
            item.TaxAmountBase = TaxAmountBase;
            item.TaxBeforeDiscountBase = TaxBeforeDiscountBase;
            item.TaxInvoicedBase = TaxInvoicedBase;
            item.TaxRefundedBase = TaxRefundedBase;
            item.EcologicalTaxAppliedAmountBase = EcologicalTaxAppliedAmountBase;
            item.EcologicalTaxAppliedRowAmountBase = EcologicalTaxAppliedRowAmountBase;
            item.EcologicalTaxDispositionBase = EcologicalTaxDispositionBase;
            item.EcologicalTaxRowDispositionBase = EcologicalTaxRowDispositionBase;
            item.EcologicalTaxRowDisposition = EcologicalTaxRowDisposition;
            item.CreatedAt = CreatedTimestamp.ToDateTimeUtc().ToString();
            item.Description = Description;
            item.DiscountAmount = DiscountAmount;
            item.DiscountInvoiced = DiscountInvoiced;
            item.DiscountPercent = DiscountPercent;
            item.DiscountRefunded = DiscountRefunded;
            item.EventID = EventID;
            item.ExternalItemID = ExternalItemID;
            item.FreeShipping = FreeShipping.ToMagentoBoolean();
            item.GiftWrapPriceBase = GiftWrapPriceBase;
            item.GiftWrapPriceInvoicedBase = GiftWrapPriceInvoicedBase;
            item.GiftWrapPriceRefundedBase = GiftWrapPriceRefundedBase;
            item.GiftWrapTaxAmountBase = GiftWrapTaxAmountBase;
            item.GiftWrapTaxAmountInvoicedBase = GiftWrapTaxAmountInvoicedBase;
            item.GiftWrapTaxAmountRefundedBase = GiftWrapTaxAmountRefundedBase;
            item.GiftWrapID = GiftWrapID;
            item.GiftWrapPrice = GiftWrapPrice;
            item.GiftWrapPriceInvoiced = GiftWrapPriceInvoiced;
            item.GiftWrapPriceRefunded = GiftWrapPriceRefunded;
            item.GiftWrapTaxAmount = GiftWrapTaxAmount;
            item.GiftWrapTaxAmountInvoiced = GiftWrapTaxAmountInvoiced;
            item.GiftWrapTaxAmountRefunded = GiftWrapTaxAmountRefunded;
            item.DiscountTaxCompensationAmount = DiscountTaxCompensationAmount;
            item.DiscountTaxCompensationCanceled = DiscountTaxCompensationCanceled;
            item.DiscountTaxCompensationInvoiced = DiscountTaxCompensationInvoiced;
            item.DiscountTaxCompensationRefunded = DiscountTaxCompensationRefunded;
            item.QuantityIsDecimal = QuantityIsDecimal.ToMagentoBoolean();
            item.IsVirtual = IsVirtual.ToMagentoBoolean();
            item.ItemID = Item.ItemID;
            item.LockedInvoice = LockedInvoice.ToMagentoBoolean();
            item.LockedShipping = LockedShipping.ToMagentoBoolean();
            item.Name = Name;
            item.NoDiscount = NoDiscount.ToMagentoBoolean();
            item.OrderID = OrderID;
            item.OriginalPrice = OriginalPrice;
            item.ParentItemID = ParentItemID;
            item.Price = Price;
            item.PriceWithTax = PriceWithTax;
            item.ProductID = Product.ID;
            item.ProductType = ProductType.Name;
            item.QuantityBackordered = QuantityBackordered;
            item.QuantityCanceled = QuantityCanceled;
            item.QuantityInvoiced = QuantityInvoiced;
            item.QuantityOrdered = QuantityOrdered;
            item.QuantityRefunded = QuantityRefunded;
            item.QuantityReturned = QuantityReturned;
            item.QuantityShipped = QuantityShipped;
            item.QuoteItemID = QuoteItemID;
            item.RowInvoiced = RowInvoiced;
            item.RowTotal = RowTotal;
            item.RowTotalWithTax = RowTotalWithTax;
            item.RowWeight = RowWeight;
            item.SKU = Product.SKU;
            item.StoreID = Store.ID;
            item.TaxAmount = TaxAmount;
            item.TaxBeforeDiscount = TaxBeforeDiscount;
            item.TaxCanceled = TaxCanceled;
            item.TaxInvoiced = TaxInvoiced;
            item.TaxPercent = TaxPercent;
            item.TaxRefunded = TaxRefunded;
            item.UpdatedAt = UpdatedTimestamp.HasValue ? UpdatedTimestamp.Value.ToDateTimeUtc().ToString() : String.Empty;
            item.EcologicalTaxApplied = EcologicalTaxApplied;
            item.EcologicalTaxAmount = EcologicalTaxAmount;
            item.EcologicalTaxRowAmount = EcologicalTaxRowAmount;
            item.EcologicalTaxDisposition = EcologicalTaxDisposition;
            item.EcologicalTaxRowDisposition = EcologicalTaxRowDisposition;
            item.Weight = Weight;
            item.ParentItem = (ParentItem == null) ? null : ParentItem.ToInterface();
            item.ProductOption = ProductOption.ToInterface();
            item.ExtensionAttributes = new SalesOrderItemExtensionInterface();
            item.ExtensionAttributes.GiftMessage = GiftMessage.ToInterface();
            item.ExtensionAttributes.GiftWrapID = _GiftWrapID;
            item.ExtensionAttributes.GiftWrapPrice = _GiftWrapPrice;
            item.ExtensionAttributes.GiftWrapPriceBase = _GiftWrapPriceBase;
            item.ExtensionAttributes.GiftWrapTaxAmountBase = _GiftWrapTaxAmountBase;
            item.ExtensionAttributes.GiftWrapTaxAmount = _GiftWrapTaxAmount;
            item.ExtensionAttributes.GiftWrapInvoicedPrice = _GiftWrapPriceInvoiced;
            item.ExtensionAttributes.GiftWrapInvoicedPriceBase = _GiftWrapPriceInvoicedBase;
            item.ExtensionAttributes.GiftWrapInvoicedTaxAmount = _GiftWrapTaxAmountInvoiced;
            item.ExtensionAttributes.GiftWrapInvoicedTaxAmountBase = _GiftWrapTaxAmountInvoicedBase;
            item.ExtensionAttributes.GiftWrapRefundedPrice = _GiftWrapPriceRefunded;
            item.ExtensionAttributes.GiftWrapRefundedPriceBase = _GiftWrapPriceRefundedBase;
            item.ExtensionAttributes.GiftWrapRefundedTaxAmount = _GiftWrapTaxAmountRefunded;
            item.ExtensionAttributes.GiftWrapRefundedTaxAmountBase = _GiftWrapTaxAmountRefundedBase;

            return item;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            SalesOrderItem item = new SalesOrderItem();

            item.AdditionalData = AdditionalData;
            item.AmountRefunded = AmountRefunded;
            item.AppliedRules = (AppliedRules == null) ? null : AppliedRules.Select(ar => ar);
            item.AmountRefundedBase = AmountRefundedBase;
            item.CostBase = CostBase;
            item.DiscountAmountBase = DiscountAmountBase;
            item.DiscountInvoicedBase = DiscountInvoicedBase;
            item.DiscountRefundedBase = DiscountRefundedBase;
            item.DiscountTaxCompensationAmountBase = DiscountTaxCompensationAmountBase;
            item.DiscountTaxCompensationInvoicedBase = DiscountTaxCompensationInvoicedBase;
            item.DiscountTaxCompensationRefundedBase = DiscountTaxCompensationRefundedBase;
            item.OriginalPriceBase = OriginalPriceBase;
            item.PriceBase = PriceBase;
            item.PriceWithTaxBase = PriceWithTaxBase;
            item.RowInvoicedBase = RowInvoicedBase;
            item.RowTotalBase = RowTotalBase;
            item.RowTotalWithTaxBase = RowTotalWithTaxBase;
            item.TaxAmountBase = TaxAmountBase;
            item.TaxBeforeDiscountBase = TaxBeforeDiscountBase;
            item.TaxInvoicedBase = TaxInvoicedBase;
            item.TaxRefundedBase = TaxRefundedBase;
            item.EcologicalTaxAppliedAmountBase = EcologicalTaxAppliedAmountBase;
            item.EcologicalTaxAppliedRowAmountBase = EcologicalTaxAppliedRowAmountBase;
            item.EcologicalTaxDispositionBase = EcologicalTaxDispositionBase;
            item.EcologicalTaxRowDispositionBase = EcologicalTaxRowDispositionBase;
            item.EcologicalTaxRowDisposition = EcologicalTaxRowDisposition;
            item.CreatedTimestamp = CreatedTimestamp;
            item.Description = Description;
            item.DiscountAmount = DiscountAmount;
            item.DiscountInvoiced = DiscountInvoiced;
            item.DiscountPercent = DiscountPercent;
            item.DiscountRefunded = DiscountRefunded;
            item.EventID = EventID;
            item.ExternalItemID = ExternalItemID;
            item.FreeShipping = FreeShipping;
            item.GiftWrapPriceBase = GiftWrapPriceBase;
            item.GiftWrapPriceInvoicedBase = GiftWrapPriceInvoicedBase;
            item.GiftWrapPriceRefundedBase = GiftWrapPriceRefundedBase;
            item.GiftWrapTaxAmountBase = GiftWrapTaxAmountBase;
            item.GiftWrapTaxAmountInvoicedBase = GiftWrapTaxAmountInvoicedBase;
            item.GiftWrapTaxAmountRefundedBase = GiftWrapTaxAmountRefundedBase;
            item.GiftWrapID = GiftWrapID;
            item.GiftWrapPrice = GiftWrapPrice;
            item.GiftWrapPriceInvoiced = GiftWrapPriceInvoiced;
            item.GiftWrapPriceRefunded = GiftWrapPriceRefunded;
            item.GiftWrapTaxAmount = GiftWrapTaxAmount;
            item.GiftWrapTaxAmountInvoiced = GiftWrapTaxAmountInvoiced;
            item.GiftWrapTaxAmountRefunded = GiftWrapTaxAmountRefunded;
            item.DiscountTaxCompensationAmount = DiscountTaxCompensationAmount;
            item.DiscountTaxCompensationCanceled = DiscountTaxCompensationCanceled;
            item.DiscountTaxCompensationInvoiced = DiscountTaxCompensationInvoiced;
            item.DiscountTaxCompensationRefunded = DiscountTaxCompensationRefunded;
            item.QuantityIsDecimal = QuantityIsDecimal;
            item.IsVirtual = IsVirtual;
            item.Item = Item.Clone<StockItem>();
            item.LockedInvoice = LockedInvoice;
            item.LockedShipping = LockedShipping;
            item.Name = Name;
            item.NoDiscount = NoDiscount;
            item.OrderID = OrderID;
            item.OriginalPrice = OriginalPrice;
            item.ParentItemID = ParentItemID;
            item.Price = Price;
            item.PriceWithTax = PriceWithTax;
            item.Product = Product.Clone<Product>();
            item.ProductType = ProductType;
            item.QuantityBackordered = QuantityBackordered;
            item.QuantityCanceled = QuantityCanceled;
            item.QuantityInvoiced = QuantityInvoiced;
            item.QuantityOrdered = QuantityOrdered;
            item.QuantityRefunded = QuantityRefunded;
            item.QuantityReturned = QuantityReturned;
            item.QuantityShipped = QuantityShipped;
            item.QuoteItemID = QuoteItemID;
            item.RowInvoiced = RowInvoiced;
            item.RowTotal = RowTotal;
            item.RowTotalWithTax = RowTotalWithTax;
            item.RowWeight = RowWeight;
            item.Store = Store.Clone<MagentoStore>();
            item.TaxAmount = TaxAmount;
            item.TaxBeforeDiscount = TaxBeforeDiscount;
            item.TaxCanceled = TaxCanceled;
            item.TaxInvoiced = TaxInvoiced;
            item.TaxPercent = TaxPercent;
            item.TaxRefunded = TaxRefunded;
            item.UpdatedTimestamp = UpdatedTimestamp;
            item.EcologicalTaxApplied = EcologicalTaxApplied;
            item.EcologicalTaxAmount = EcologicalTaxAmount;
            item.EcologicalTaxRowAmount = EcologicalTaxRowAmount;
            item.EcologicalTaxDisposition = EcologicalTaxDisposition;
            item.EcologicalTaxRowDisposition = EcologicalTaxRowDisposition;
            item.Weight = Weight;
            item.ParentItem = (ParentItem == null) ? null : ParentItem.Clone<SalesOrderItem>();
            item.ProductOption = ProductOption;
            item.GiftMessage = GiftMessage;
            item._GiftWrapID = _GiftWrapID;
            item._GiftWrapPrice = _GiftWrapPrice;
            item._GiftWrapPriceBase = _GiftWrapPriceBase;
            item._GiftWrapTaxAmountBase = _GiftWrapTaxAmountBase;
            item._GiftWrapTaxAmount = _GiftWrapTaxAmount;
            item._GiftWrapPriceInvoiced = _GiftWrapPriceInvoiced;
            item._GiftWrapPriceInvoicedBase = _GiftWrapPriceInvoicedBase;
            item._GiftWrapTaxAmountInvoiced = _GiftWrapTaxAmountInvoiced;
            item._GiftWrapTaxAmountInvoicedBase = _GiftWrapTaxAmountInvoicedBase;
            item._GiftWrapPriceRefunded = _GiftWrapPriceRefunded;
            item._GiftWrapPriceRefundedBase = _GiftWrapPriceRefundedBase;
            item._GiftWrapTaxAmountRefunded = _GiftWrapTaxAmountRefunded;
            item._GiftWrapTaxAmountRefundedBase = _GiftWrapTaxAmountRefundedBase;            
            
            return item;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(AdditionalData); 
            hash.Add(AmountRefunded); 
            hash.Add(AppliedRules); 
            hash.Add(AmountRefundedBase);
            hash.Add(CostBase);
            hash.Add(DiscountAmountBase);
            hash.Add(DiscountInvoicedBase);
            hash.Add(DiscountRefundedBase);
            hash.Add(DiscountTaxCompensationAmountBase);
            hash.Add(DiscountTaxCompensationInvoicedBase);
            hash.Add(DiscountTaxCompensationRefundedBase);
            hash.Add(OriginalPriceBase);
            hash.Add(PriceBase);
            hash.Add(PriceWithTaxBase);
            hash.Add(RowInvoicedBase);
            hash.Add(RowTotalBase);
            hash.Add(RowTotalWithTaxBase);
            hash.Add(TaxAmountBase);
            hash.Add(TaxBeforeDiscountBase);
            hash.Add(TaxInvoicedBase);
            hash.Add(TaxRefundedBase);
            hash.Add(EcologicalTaxAppliedAmountBase);
            hash.Add(EcologicalTaxAppliedRowAmountBase);
            hash.Add(EcologicalTaxDispositionBase);
            hash.Add(EcologicalTaxRowDispositionBase);
            hash.Add(EcologicalTaxRowDisposition);
            hash.Add(CreatedTimestamp);
            hash.Add(Description);
            hash.Add(DiscountAmount);
            hash.Add(DiscountInvoiced);
            hash.Add(DiscountPercent);
            hash.Add(DiscountRefunded);
            hash.Add(EventID);
            hash.Add(ExternalItemID);
            hash.Add(FreeShipping);
            hash.Add(GiftWrapPriceBase);
            hash.Add(GiftWrapPriceInvoicedBase);
            hash.Add(GiftWrapPriceRefundedBase);
            hash.Add(GiftWrapTaxAmountBase);
            hash.Add(GiftWrapTaxAmountInvoicedBase);
            hash.Add(GiftWrapTaxAmountRefundedBase);
            hash.Add(GiftWrapID);
            hash.Add(GiftWrapPrice);
            hash.Add(GiftWrapPriceInvoiced);
            hash.Add(GiftWrapPriceRefunded);
            hash.Add(GiftWrapTaxAmount);
            hash.Add(GiftWrapTaxAmountInvoiced);
            hash.Add(GiftWrapTaxAmountRefunded);
            hash.Add(DiscountTaxCompensationAmount);
            hash.Add(DiscountTaxCompensationCanceled);
            hash.Add(DiscountTaxCompensationInvoiced);
            hash.Add(DiscountTaxCompensationRefunded);
            hash.Add(QuantityIsDecimal);
            hash.Add(IsVirtual);
            hash.Add(Item); 
            hash.Add(LockedInvoice);
            hash.Add(LockedShipping);
            hash.Add(Name);
            hash.Add(NoDiscount);
            hash.Add(OrderID);
            hash.Add(OriginalPrice);
            hash.Add(ParentItemID);
            hash.Add(Price);
            hash.Add(PriceWithTax);
            hash.Add(Product);
            hash.Add(ProductType);
            hash.Add(QuantityBackordered);
            hash.Add(QuantityCanceled);
            hash.Add(QuantityInvoiced);
            hash.Add(QuantityOrdered);
            hash.Add(QuantityRefunded);
            hash.Add(QuantityReturned);
            hash.Add(QuantityShipped);
            hash.Add(QuoteItemID);
            hash.Add(RowInvoiced);
            hash.Add(RowTotal);
            hash.Add(RowTotalWithTax);
            hash.Add(RowWeight);
            hash.Add(Store);
            hash.Add(TaxAmount);
            hash.Add(TaxBeforeDiscount);
            hash.Add(TaxCanceled);
            hash.Add(TaxInvoiced);
            hash.Add(TaxPercent);
            hash.Add(TaxRefunded);
            hash.Add(UpdatedTimestamp);
            hash.Add(EcologicalTaxApplied);
            hash.Add(EcologicalTaxAmount);
            hash.Add(EcologicalTaxRowAmount);
            hash.Add(EcologicalTaxDisposition);
            hash.Add(EcologicalTaxRowDisposition);
            hash.Add(Weight);
            hash.Add(ParentItem);
            hash.Add(ProductOption);
            hash.Add(GiftMessage);
            hash.Add(_GiftWrapID);
            hash.Add(_GiftWrapPrice);
            hash.Add(_GiftWrapPriceBase);
            hash.Add(_GiftWrapTaxAmountBase);
            hash.Add(_GiftWrapTaxAmount);
            hash.Add(_GiftWrapPriceInvoiced);
            hash.Add(_GiftWrapPriceInvoicedBase);
            hash.Add(_GiftWrapTaxAmountInvoiced);
            hash.Add(_GiftWrapTaxAmountInvoicedBase);
            hash.Add(_GiftWrapPriceRefunded);
            hash.Add(_GiftWrapPriceRefundedBase);
            hash.Add(_GiftWrapTaxAmountRefunded);
            hash.Add(_GiftWrapTaxAmountRefundedBase);            
            
            return hash.ToHashCode();
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="product"><see cref="ISalesOrderItem"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ISalesOrderItem product)
        {
            ArgumentNullException.ThrowIfNull(product);
            return product.GetHashCode();
        }
        
        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(SalesOrderItemInterface model)
        {
            string[] appliedRuleIds = null;
            
            if (model != null)
            {
                appliedRuleIds = !String.IsNullOrWhiteSpace(model.AppliedRuleIDs) ? model.AppliedRuleIDs.Split(new char[] { ',' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries) : null;
                
                AdditionalData = model.AdditionalData;
                AmountRefunded = model.AmountRefunded;
                AppliedRules = (appliedRuleIds == null || appliedRuleIds.Length < 1) ? null : appliedRuleIds.Select(rid => new MagentoSalesRule(Convert.ToUInt32(rid)));
                AmountRefundedBase = model.AmountRefundedBase;
                CostBase = model.CostBase;
                DiscountAmountBase = model.DiscountAmountBase;
                DiscountInvoicedBase = model.DiscountInvoicedBase;
                DiscountRefundedBase = model.DiscountRefundedBase;
                DiscountTaxCompensationAmountBase = model.DiscountTaxCompensationAmountBase;
                DiscountTaxCompensationInvoicedBase = model.DiscountTaxCompensationInvoicedBase;
                DiscountTaxCompensationRefundedBase = model.DiscountTaxCompensationRefundedBase;
                OriginalPriceBase = model.OriginalPriceBase;
                PriceBase = model.PriceBase;
                PriceWithTaxBase = model.PriceWithTaxBase;
                RowInvoicedBase = model.RowInvoicedBase;
                RowTotalBase = model.RowTotalBase;
                RowTotalWithTaxBase = model.RowTotalWithTaxBase;
                TaxAmountBase = model.TaxAmountBase;
                TaxBeforeDiscountBase = model.TaxBeforeDiscountBase;
                TaxInvoicedBase = model.TaxInvoicedBase;
                TaxRefundedBase = model.TaxRefundedBase;
                EcologicalTaxAppliedAmountBase = model.EcologicalTaxAppliedAmountBase;
                EcologicalTaxAppliedRowAmountBase = model.EcologicalTaxAppliedRowAmountBase;
                EcologicalTaxDispositionBase = model.EcologicalTaxDispositionBase;
                EcologicalTaxRowDispositionBase = model.EcologicalTaxRowDispositionBase;
                EcologicalTaxRowDisposition = model.EcologicalTaxRowDisposition;
                CreatedTimestamp = Instant.FromDateTimeUtc(DateTime.Parse(model.CreatedAt).ToUniversalTime(true));
                Description = model.Description;
                DiscountAmount = model.DiscountAmount;
                DiscountInvoiced = model.DiscountInvoiced;
                DiscountPercent = model.DiscountPercent;
                DiscountRefunded = model.DiscountRefunded;
                EventID = model.EventID;
                ExternalItemID = model.ExternalItemID;
                FreeShipping = model.FreeShipping.FromMagentoBoolean();
                GiftWrapPriceBase = model.GiftWrapPriceBase;
                GiftWrapPriceInvoicedBase = model.GiftWrapPriceInvoicedBase;
                GiftWrapPriceRefundedBase = model.GiftWrapPriceRefundedBase;
                GiftWrapTaxAmountBase = model.GiftWrapTaxAmountBase;
                GiftWrapTaxAmountInvoicedBase = model.GiftWrapTaxAmountInvoicedBase;
                GiftWrapTaxAmountRefundedBase = model.GiftWrapTaxAmountRefundedBase;
                GiftWrapID = model.GiftWrapID;
                GiftWrapPrice = model.GiftWrapPrice;
                GiftWrapPriceInvoiced = model.GiftWrapPriceInvoiced;
                GiftWrapPriceRefunded = model.GiftWrapPriceRefunded;
                GiftWrapTaxAmount = model.GiftWrapTaxAmount;
                GiftWrapTaxAmountInvoiced = model.GiftWrapTaxAmountInvoiced;
                GiftWrapTaxAmountRefunded = model.GiftWrapTaxAmountRefunded;
                DiscountTaxCompensationAmount = model.DiscountTaxCompensationAmount;
                DiscountTaxCompensationCanceled = model.DiscountTaxCompensationCanceled;
                DiscountTaxCompensationInvoiced = model.DiscountTaxCompensationInvoiced;
                DiscountTaxCompensationRefunded = model.DiscountTaxCompensationRefunded;
                QuantityIsDecimal = model.QuantityIsDecimal.FromMagentoBoolean();
                IsVirtual = model.IsVirtual.FromMagentoBoolean();
                Item = new StockItem(Convert.ToUInt32(model.ItemID));
                LockedInvoice = model.LockedInvoice.FromMagentoBoolean();
                LockedShipping = model.LockedShipping.FromMagentoBoolean();
                Name = model.Name;
                NoDiscount = model.NoDiscount.FromMagentoBoolean();
                OrderID = model.OrderID;
                OriginalPrice = model.OriginalPrice;
                ParentItemID = model.ParentItemID;
                Price = model.Price;
                PriceWithTax = model.PriceWithTax;
                Product = new Product(Convert.ToUInt32(model.ProductID));
                ProductType = new ProductType(model.ProductType, String.Empty);
                QuantityBackordered = model.QuantityBackordered;
                QuantityCanceled = model.QuantityCanceled;
                QuantityInvoiced = model.QuantityInvoiced;
                QuantityOrdered = model.QuantityOrdered;
                QuantityRefunded = model.QuantityRefunded;
                QuantityReturned = model.QuantityReturned;
                QuantityShipped = model.QuantityShipped;
                QuoteItemID = model.QuoteItemID;
                RowInvoiced = model.RowInvoiced;
                RowTotal = model.RowTotal;
                RowTotalWithTax = model.RowTotalWithTax;
                RowWeight = model.RowWeight;
                Store = new MagentoStore(Convert.ToUInt32(model.StoreID));
                TaxAmount = model.TaxAmount;
                TaxBeforeDiscount = model.TaxBeforeDiscount;
                TaxCanceled = model.TaxCanceled;
                TaxInvoiced = model.TaxInvoiced;
                TaxPercent = model.TaxPercent;
                TaxRefunded = model.TaxRefunded;
                UpdatedTimestamp = String.IsNullOrWhiteSpace(model.UpdatedAt) ? null : Instant.FromDateTimeUtc(DateTime.Parse(model.UpdatedAt).ToUniversalTime(true));
                EcologicalTaxApplied = model.EcologicalTaxApplied;
                EcologicalTaxAmount = model.EcologicalTaxAmount;
                EcologicalTaxRowAmount = model.EcologicalTaxRowAmount;
                EcologicalTaxDisposition = model.EcologicalTaxDisposition;
                EcologicalTaxRowDisposition = model.EcologicalTaxRowDisposition;
                Weight = model.Weight;
                ParentItem = (model.ParentItem == null) ? null : new SalesOrderItem(model.ParentItem);
                ProductOption = new ProductOption(model.ProductOption);

                if (model.ExtensionAttributes != null)
                {
                    GiftMessage = new MagentoGiftMessage(model.ExtensionAttributes.GiftMessage);
                    _GiftWrapID = model.ExtensionAttributes.GiftWrapID;
                    _GiftWrapPrice = model.ExtensionAttributes.GiftWrapPrice;
                    _GiftWrapPriceBase = model.ExtensionAttributes.GiftWrapPriceBase;
                    _GiftWrapTaxAmountBase = model.ExtensionAttributes.GiftWrapTaxAmountBase;
                    _GiftWrapTaxAmount = model.ExtensionAttributes.GiftWrapTaxAmount;
                    _GiftWrapPriceInvoiced = model.ExtensionAttributes.GiftWrapInvoicedPrice;
                    _GiftWrapPriceInvoicedBase = model.ExtensionAttributes.GiftWrapInvoicedPriceBase;
                    _GiftWrapTaxAmountInvoiced = model.ExtensionAttributes.GiftWrapInvoicedTaxAmount;
                    _GiftWrapTaxAmountInvoicedBase = model.ExtensionAttributes.GiftWrapInvoicedTaxAmountBase;
                    _GiftWrapPriceRefunded = model.ExtensionAttributes.GiftWrapRefundedPrice;
                    _GiftWrapPriceRefundedBase = model.ExtensionAttributes.GiftWrapRefundedPriceBase;
                    _GiftWrapTaxAmountRefunded = model.ExtensionAttributes.GiftWrapRefundedTaxAmount;
                    _GiftWrapTaxAmountRefundedBase = model.ExtensionAttributes.GiftWrapRefundedTaxAmountBase;
                }
            }
        }
    }
}
