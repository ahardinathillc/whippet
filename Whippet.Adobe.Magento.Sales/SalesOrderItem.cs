using System;
using NodaTime;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Catalog.Products;
using Athi.Whippet.Adobe.Magento.Sales.Addressing;
using Athi.Whippet.Adobe.Magento.Catalog.Inventory.StockItems;
using Athi.Whippet.Adobe.Magento.Catalog.Inventory.StockItems.Extensions;
using Athi.Whippet.Adobe.Magento.SalesRule;
using Athi.Whippet.Adobe.Magento.SalesRule.Extensions;
using MagentoSalesRule = Athi.Whippet.Adobe.Magento.SalesRule.SalesRule;
using MagentoGiftMessage = Athi.Whippet.Adobe.Magento.GiftMessage.GiftMessage;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Represents a sales order item for a Magento <see cref="SalesOrder"/>.
    /// </summary>
    public class SalesOrderItem : MagentoRestEntity<SalesOrderItemInterface>, IMagentoEntity, ISalesOrderItem, IEqualityComparer<ISalesOrderItem>, IMagentoAuditableEntity, IMagentoRestEntity, IMagentoRestEntity<SalesOrderItemInterface>
    {
        private StockItem _item;
        private StockItem _parentItem;
        private Product _product;
        private SalesOrderAddress _billingAddress;
        
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

        IEnumerable<ISalesRule> ISalesOrderItem.AppliedRules
        {
            get
            {
                return AppliedRules;
            }
            set
            {
                AppliedRules = (value == null) ? null : value.Select(ar => ar.ToSalesRule)
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
        /// Gets or setes the tax amount refunded in base currency.
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
        public virtual int FreeShipping
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
        /// Flag that indicates whether quantity is an <see cref="Int32"/> or <see cref="Decimal"/>. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        public virtual int QuantityIsDecimal
        { get; set; }

        /// <summary>
        /// Flag that indicates whether the order item is virtual. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        public virtual int IsVirtual
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
        /// Flag that indicates whether the invoice is locked. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        public virtual int LockedInvoice
        { get; set; }

        /// <summary>
        /// Flag that indicates whether the shipping is locked. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        public virtual int LockedShipping
        { get; set; }

        /// <summary>
        /// Gets or sets the item name. 
        /// </summary>
        public virtual string Name
        { get; set; }

        /// <summary>
        /// Flag that indicates whether there is no discount. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        public virtual int NoDiscount
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
                equals = String.Equals(x.Name?.Trim(), y.Name?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                        && (((x.StoreLabels == null) && (y.StoreLabels == null)) || ((x.StoreLabels != null) && x.StoreLabels.SequenceEqual(y.StoreLabels)))
                        && String.Equals(x.Description?.Trim(), y.Description?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                        && (((x.Websites == null) && (y.Websites == null)) || ((x.Websites != null) && x.Websites.SequenceEqual(y.Websites)))
                        && x.EffectiveDate.GetValueOrDefault().Equals(y.EffectiveDate.GetValueOrDefault())
                        && x.ExpirationDate.GetValueOrDefault().Equals(y.ExpirationDate.GetValueOrDefault())
                        && x.UsesPerCustomer == y.UsesPerCustomer
                        && (((x.Condition == null) && (y.Condition == null)) || ((x.Condition != null) && x.Condition.Equals(y.Condition)))
                        && (((x.ActionCondition == null) && (y.ActionCondition == null)) || ((x.Condition != null) && x.ActionCondition.Equals(y.ActionCondition)))
                        && x.StopRulesProcessing == y.StopRulesProcessing
                        && x.IsAdvanced == y.IsAdvanced
                        && (((x.ProductIDs == null) && (y.ProductIDs == null)) || ((x.ProductIDs != null) && x.ProductIDs.Equals(y.ProductIDs)))
                        && x.SortOrder == y.SortOrder
                        && String.Equals(x.SimpleAction?.Trim(), y.SimpleAction?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                        && x.DiscountAmount == y.DiscountAmount
                        && x.DiscountQuantity == y.DiscountQuantity
                        && x.Step == y.Step
                        && x.AppliesToShipping == y.AppliesToShipping
                        && x.TimesUsed == y.TimesUsed
                        && x.IsRSS == y.IsRSS
                        && String.Equals(x.CouponType?.Trim(), y.CouponType?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                        && x.AutoGenerateCoupon == y.AutoGenerateCoupon
                        && x.UsesPerCoupon == y.UsesPerCoupon
                        && String.Equals(x.SimpleFreeShipping?.Trim(), y.SimpleFreeShipping?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                        && x.RewardPointsDelta == y.RewardPointsDelta
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
            SalesOrderItemInterface rule = new SalesOrderItemInterface();

            rule.ID = ID;
            rule.Name = Name;
            rule.StoreLabels = (StoreLabels == null) ? null : StoreLabels.Select(s => s.ToInterface()).ToArray();
            rule.Description = Description;
            rule.WebsiteIDs = (Websites == null) ? null : Websites.Select(w => w.ID).ToArray();
            rule.CustomerGroupIDs = (CustomerGroups == null) ? null : CustomerGroups.Select(c => c.ID).ToArray();
            rule.EffectiveDate = !EffectiveDate.HasValue ? String.Empty : EffectiveDate.Value.ToDateTimeUtc().ToString();
            rule.ExpirationDate = !ExpirationDate.HasValue ? String.Empty : ExpirationDate.Value.ToDateTimeUtc().ToString();
            rule.UsesPerCustomer = UsesPerCustomer;
            rule.Active = Active;
            rule.Condition = (Condition == null) ? null : Condition.ToInterface();
            rule.ActionCondition = (ActionCondition == null) ? null : ActionCondition.ToInterface();
            rule.StopRulesProcessing = StopRulesProcessing;
            rule.IsAdvanced = IsAdvanced;
            rule.ProductIDs = (ProductIDs == null) ? null : ProductIDs.ToArray();
            rule.SortOrder = SortOrder;
            rule.SimpleAction = SimpleAction;
            rule.DiscountAmount = DiscountAmount;
            rule.DiscountQuantity = DiscountQuantity;
            rule.DiscountStep = Step;
            rule.ApplyToShipping = AppliesToShipping;
            rule.TimesUsed = TimesUsed;
            rule.IsRSS = IsRSS;
            rule.CouponType = CouponType;
            rule.UseAutoGeneration = AutoGenerateCoupon;
            rule.UsesPerCoupon = UsesPerCoupon;
            rule.SimpleFreeShipping = SimpleFreeShipping;
            rule.ExtensionAttributes = new SalesOrderItemExtensionInterface(RewardPointsDelta);
            
            return rule;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            SalesOrderItem rule = new SalesOrderItem();

            rule.Name = Name;
            rule.StoreLabels = (StoreLabels == null) ? null : StoreLabels.Select(sl => sl);
            rule.Description = Description;
            rule.Websites = (Websites == null) ? null : Websites.Select(w => w.Clone<StoreWebsite>());
            rule.CustomerGroups = (CustomerGroups == null) ? null : CustomerGroups.Select(c => c.Clone<CustomerGroup>());
            rule.EffectiveDate = EffectiveDate;
            rule.ExpirationDate = ExpirationDate;
            rule.UsesPerCustomer = UsesPerCustomer;
            rule.Condition = Condition;
            rule.ActionCondition = ActionCondition;
            rule.StopRulesProcessing = StopRulesProcessing;
            rule.IsAdvanced = IsAdvanced;
            rule.ProductIDs = (ProductIDs == null) ? null : ProductIDs.Select(p => p);
            rule.SortOrder = SortOrder;
            rule.SimpleAction = SimpleAction;
            rule.DiscountAmount = DiscountAmount;
            rule.DiscountQuantity = DiscountQuantity;
            rule.Step = Step;
            rule.AppliesToShipping = AppliesToShipping;
            rule.TimesUsed = TimesUsed;
            rule.IsRSS = IsRSS;
            rule.CouponType = CouponType;
            rule.AutoGenerateCoupon = AutoGenerateCoupon;
            rule.UsesPerCoupon = UsesPerCoupon;
            rule.SimpleFreeShipping = SimpleFreeShipping;
            rule.RewardPointsDelta = RewardPointsDelta;
            rule.Active = Active;
            
            return rule;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(ID);
            hash.Add(Name);
            hash.Add(StoreLabels);
            hash.Add(Description);
            hash.Add(Websites);
            hash.Add(CustomerGroups);
            hash.Add(EffectiveDate);
            hash.Add(ExpirationDate);
            hash.Add(UsesPerCustomer);
            hash.Add(Condition);
            hash.Add(ActionCondition);
            hash.Add(StopRulesProcessing);
            hash.Add(IsAdvanced);
            hash.Add(ProductIDs);
            hash.Add(SortOrder);
            hash.Add(SimpleAction);
            hash.Add(DiscountAmount);
            hash.Add(DiscountQuantity);
            hash.Add(Step);
            hash.Add(AppliesToShipping);
            hash.Add(TimesUsed);
            hash.Add(IsRSS);
            hash.Add(CouponType);
            hash.Add(AutoGenerateCoupon);
            hash.Add(UsesPerCoupon);
            hash.Add(SimpleFreeShipping);
            hash.Add(RewardPointsDelta);
            hash.Add(Active);
            
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
            if (model != null)
            {
                ID = model.ID;
                Name = model.Name;
                StoreLabels = (model.StoreLabels == null) ? null : model.StoreLabels.Select(s => new SalesOrderItemLabel(s));
                Description = model.Description;
                Websites = (model.WebsiteIDs == null) ? null : model.WebsiteIDs.Select(w => new StoreWebsite(Convert.ToUInt32(w)));
                CustomerGroups = (model.CustomerGroupIDs == null) ? null : model.CustomerGroupIDs.Select(c => new CustomerGroup(Convert.ToUInt32(c)));
                EffectiveDate = String.IsNullOrWhiteSpace(model.EffectiveDate) ? null : Instant.FromDateTimeUtc(DateTime.Parse(model.EffectiveDate).ToUniversalTime(true));
                ExpirationDate = String.IsNullOrWhiteSpace(model.ExpirationDate) ? null : Instant.FromDateTimeUtc(DateTime.Parse(model.ExpirationDate).ToUniversalTime(true));
                UsesPerCustomer = model.UsesPerCustomer;
                Active = model.Active;
                Condition = (model.Condition == null) ? null : new SalesOrderItemCondition(model.Condition);
                ActionCondition = (model.ActionCondition == null) ? null : new SalesOrderItemCondition(model.ActionCondition);
                StopRulesProcessing = model.StopRulesProcessing;
                IsAdvanced = model.IsAdvanced;
                ProductIDs = model.ProductIDs;
                SortOrder = model.SortOrder;
                SimpleAction = model.SimpleAction;
                DiscountAmount = model.DiscountAmount;
                DiscountQuantity = model.DiscountQuantity;
                Step = model.DiscountStep;
                AppliesToShipping = model.ApplyToShipping;
                TimesUsed = model.TimesUsed;
                IsRSS = model.IsRSS;
                CouponType = model.CouponType;
                AutoGenerateCoupon = model.UseAutoGeneration;
                UsesPerCoupon = model.UsesPerCoupon;
                SimpleFreeShipping = model.SimpleFreeShipping;
                RewardPointsDelta = (model.ExtensionAttributes == null) ? default(int) : model.ExtensionAttributes.RewardPointsDelta;
            }
        }

    }
}
