using System;
using System.Text;
using System.Data;
using System.Linq;
using NodaTime;
using Athi.Whippet.Data;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    public interface IMultichannelOrderManagerStockItem : IWhippetEntity, IWhippetEntityExternalDataRowImportMapper, IEqualityComparer<IMultichannelOrderManagerStockItem>, IMultichannelOrderManagerEntity, IMultichannelOrderManagerLookup
    {
        /// <summary>
        /// Gets or sets the unique ID of the object.
        /// </summary>
        new long ID
        { get; set; }

        /// <summary>
        /// Stock item number. If the <see cref="Size_Color"/> field is set to <see langword="true"/>, the first ten characters will be the stock number with the following ten being the "Size/Color."
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string Number
        { get; set; }

        /// <summary>
        /// First description line.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string DescriptionLineOne
        { get; set; }

        /// <summary>
        /// Second description line.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string DescriptionLineTwo
        { get; set; }

        /// <summary>
        /// Number of units in stock.
        /// </summary>
        decimal Units
        { get; set; }

        /// <summary>
        /// Reorder level threshold.
        /// </summary>
        decimal Low
        { get; set; }

        /// <summary>
        /// Weight in pounds.
        /// </summary>
        decimal UnitWeight
        { get; set; }

        /// <summary>
        /// Average cost value.
        /// </summary>
        decimal UnitCost
        { get; set; }

        /// <summary>
        /// Retail selling price for product.
        /// </summary>
        decimal RetailPrice
        { get; set; }

        /// <summary>
        /// Number of units backordered.
        /// </summary>
        decimal UnitsBackordered
        { get; set; }

        /// <summary>
        /// Number of units on order.
        /// </summary>
        decimal UnitsOnOrder
        { get; set; }

        /// <summary>
        /// Number of units sold but not shipped.
        /// </summary>
        decimal UnitsCommitted
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        decimal Sold
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        bool Received
        { get; set; }

        /// <summary>
        /// Specifies whether the item is a composite item.
        /// </summary>
        bool ConstructItem
        { get; set; }

        /// <summary>
        /// Specifies whether the item is a breakout item.
        /// </summary>
        bool BreakoutItem
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        string Extra
        { get; set; }

        /// <summary>
        /// Indicates whether the item is drop shipped.
        /// </summary>
        bool IsDropshipped
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        string Carrier
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        decimal PurchaseOrderQuantity
        { get; set; }

        /// <summary>
        /// Current reorder quantity.
        /// </summary>
        decimal ReorderQuantity
        { get; set; }

        /// <summary>
        /// Current reorder price.
        /// </summary>
        decimal ReorderPrice
        { get; set; }

        /// <summary>
        /// Product classification code.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string ClassificationCode
        { get; set; }

        /// <summary>
        /// Expected delivery date.
        /// </summary>
        Instant? DeliveryDate
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        bool Delivered
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        decimal DeliveredUnits
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        decimal DeliveredTotal
        { get; set; }

        /// <summary>
        /// Bin number.
        /// </summary>
        string Bin
        { get; set; }

        /// <summary>
        /// UPS oversized indicator.
        /// </summary>
        bool Oversized
        { get; set; }

        /// <summary>
        /// Cross-sell description.
        /// </summary>
        string Notation
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        bool InternalExternal
        { get; set; }

        /// <summary>
        /// Taxable status.
        /// </summary>
        bool NonTaxable
        { get; set; }

        /// <summary>
        /// Special shipping costs.
        /// </summary>
        decimal ShippingCharge
        { get; set; }

        /// <summary>
        /// Last used supplier level code 1-4.
        /// </summary>
        int CurrentSupplier
        { get; set; }

        /// <summary>
        /// Current distributer.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string Distributer
        { get; set; }

        /// <summary>
        /// Distributer stock number.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string DistributerStockNumber
        { get; set; }

        /// <summary>
        /// Indicates whether the current item is a service.
        /// </summary>
        bool IsService
        { get; set; }

        /// <summary>
        /// Indicates whether the product ships in its own container.
        /// </summary>
        bool ProductShipsInOwnBox
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        char TaxClass
        { get; set; }

        /// <summary>
        /// UPC or EAN code of the item.
        /// </summary>
        string UPC
        { get; set; }

        /// <summary>
        /// Indicates whether the product has serial numbers.
        /// </summary>
        bool HasSerialNumbers
        { get; set; }

        /// <summary>
        /// Next serial number to use.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string NextSerialNumber
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        bool Discontinued
        { get; set; }

        /// <summary>
        /// Indicates whether the product needs weighing during processing.
        /// </summary>
        bool RequiresWeighing
        { get; set; }

        /// <summary>
        /// Gross commission base in USD ($).
        /// </summary>
        decimal GrossCommissionBase
        { get; set; }

        /// <summary>
        /// Net commission base in USD ($).
        /// </summary>
        decimal NetCommissionBase
        { get; set; }

        /// <summary>
        /// Per unit commission base in USD ($).
        /// </summary>
        decimal FlatCommissionPerUnitBase
        { get; set; }

        /// <summary>
        /// Indicates whether the product is a subscription.
        /// </summary>
        bool IsSubscription
        { get; set; }

        /// <summary>
        /// Subscription publication code.
        /// </summary>
        string PublicationCode
        { get; set; }

        /// <summary>
        /// Specifies the number of issues (or units) in a subscription.
        /// </summary>
        int SubscriptionIssueCount
        { get; set; }

        /// <summary>
        /// Specifies whether the subscription is invoice-exempt.
        /// </summary>
        bool SubscriptionInvoiceExempt
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        decimal Royalty
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        bool Discontinue
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string Other_1
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        decimal Other_2
        { get; set; }

        /// <summary>
        /// Stock number to pull serial numbers from.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SerialSku
        { get; set; }

        /// <summary>
        /// Not used.
        /// </summary>
        [Obsolete("This field is not used and is only present for backwards-compatibility.", false)]
        decimal UnitsInBox
        { get; set; }

        /// <summary>
        /// Last purchase date.
        /// </summary>
        Instant? LastPurchaseDate
        { get; set; }

        /// <summary>
        /// Last purchase quantity.
        /// </summary>
        decimal LastPurchaseQuantity
        { get; set; }

        /// <summary>
        /// Specifies whether the item has a size and color.
        /// </summary>
        bool Size_Color
        { get; set; }

        /// <summary>
        /// Specifies whether fractional quantities are used.
        /// </summary>
        bool FractionalQuantities
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        bool SiteLINK_Sell
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SiteLINK_Description
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SiteLINK_Department
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SiteLINK_SubDepartment
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SiteLINK_CSMSG
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SiteLINK_CsProduct
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SiteLINK_Image
        { get; set; }

        /// <summary>
        /// Product cannot be sold.
        /// </summary>
        bool CannotSell
        { get; set; }

        /// <summary>
        /// National tax class.
        /// </summary>
        char TaxClass_N
        { get; set; }

        /// <summary>
        /// State tax class.
        /// </summary>
        char TaxClass_S
        { get; set; }

        /// <summary>
        /// National tax exempt flag.
        /// </summary>
        bool NationalTaxExempt
        { get; set; }

        /// <summary>
        /// General ledger sales department.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SalesDepartment
        { get; set; }

        /// <summary>
        /// Supplier code for royalties.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string RoyaltiesSupplierCode
        { get; set; }

        /// <summary>
        /// Net royalty base in USD.
        /// </summary>
        decimal RoyaltyNetBase
        { get; set; }

        /// <summary>
        /// Gross royalty base in USD.
        /// </summary>
        decimal RoyaltyGrossBase
        { get; set; }

        /// <summary>
        /// Per unit royalty base.
        /// </summary>
        decimal RoyaltyFlatBase
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        bool SiteLINK_Custom
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SiteLINK_CprPayment
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        char DropMethod
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SiteLINK_CprMpt
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        decimal SiteLINK_CPrice
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SiteLINK_UsProduct
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SiteLINK_UsMessage
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SiteLINK_Thumbnail
        { get; set; }

        /// <summary>
        /// Notice to send with this product.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SendNotice
        { get; set; }

        /// <summary>
        /// When to send the notice.
        /// </summary>
        char NoticeWhen
        { get; set; }

        /// <summary>
        /// Used to determine if product is a gift certificate item.
        /// </summary>
        bool GiftCertificate
        { get; set; }

        /// <summary>
        /// Points received when this item is purchased.
        /// </summary>
        int PointsReceived
        { get; set; }

        /// <summary>
        /// Points needed to purchase this item.
        /// </summary>
        int PointsNeeded
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        char Kit_Make
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        char Kit_Break
        { get; set; }

        /// <summary>
        /// ISBN  number of product.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string ISBN
        { get; set; }

        /// <summary>
        /// General ledger department to use for returns.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string ReturnsDepartment
        { get; set; }

        /// <summary>
        /// General ledger department to use for cost of goods sold.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string CostOfGoodsSoldDepartment
        { get; set; }

        /// <summary>
        /// Oversize UPS 2 indicator.
        /// </summary>
        bool Oversized_Extended
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string Substitute
        { get; set; }

        /// <summary>
        /// Warehouse preference for this item.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string WarehousePreference
        { get; set; }

        /// <summary>
        /// Used to determine if alternate warehouses can be used.
        /// </summary>
        bool AlternateWarehousesAllowed
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        bool SingleBin
        { get; set; }

        /// <summary>
        /// Number of units returned but not invoiced.
        /// </summary>
        decimal UnitsReturnedNotInvoiced
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        bool CanBuyItem
        { get; set; }

        /// <summary>
        /// County tax exempt flag.
        /// </summary>
        bool CountyNonTaxable
        { get; set; }

        /// <summary>
        /// County tax class.
        /// </summary>
        char TaxClass_C
        { get; set; }

        /// <summary>
        /// City tax exempt flag.
        /// </summary>
        bool CityNonTaxable
        { get; set; }

        /// <summary>
        /// City tax class.
        /// </summary>
        char TaxClass_I
        { get; set; }

        /// <summary>
        /// Number of drop shipped units on order.
        /// </summary>
        decimal DropShippedUnitsOnOrder
        { get; set; }

        /// <summary>
        /// Number of drop shipped units back ordered.
        /// </summary>
        decimal DropShippedUnitsOnBackOrder
        { get; set; }

        /// <summary>
        /// Item requires customization indicator.
        /// </summary>
        bool NeedsCustomization
        { get; set; }

        /// <summary>
        /// Custom information question.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string CustomText
        { get; set; }

        /// <summary>
        /// Shipping preference for item.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string ShippingPreference
        { get; set; }

        /// <summary>
        /// Advanced search field.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string AdvancedSearch_1
        { get; set; }

        /// <summary>
        /// Advanced search field.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string AdvancedSearch_2
        { get; set; }

        /// <summary>
        /// Advanced search field.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string AdvancedSearch_3
        { get; set; }

        /// <summary>
        /// Advanced search field.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string AdvancedSearch_4
        { get; set; }

        /// <summary>
        /// Full path and name of the picture.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string Picture
        { get; set; }

        /// <summary>
        /// Indicates a trigger product for club membership.
        /// </summary>
        bool ClubProduct
        { get; set; }

        /// <summary>
        /// Club code associated with the trigger item.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string ClubCode
        { get; set; }

        /// <summary>
        /// Oversize UPS 3 indicator.
        /// </summary>
        bool Oversized_Extended2
        { get; set; }

        /// <summary>
        /// If <see langword="true"/>, item is available to sell at auction.
        /// </summary>
        bool Auction
        { get; set; }

        /// <summary>
        /// Number of units reserved for auctions.
        /// </summary>
        decimal AuctionUnits
        { get; set; }

        /// <summary>
        /// Stock item length in inches.
        /// </summary>
        decimal BoxLength
        { get; set; }

        /// <summary>
        /// Stock item height in inches.
        /// </summary>
        decimal BoxHeight
        { get; set; }

        /// <summary>
        /// Stock item width in inches.
        /// </summary>
        decimal BoxWidth
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        long StockID
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        decimal AheadBackOrder
        { get; set; }

        /// <summary>
        /// Indicates if the item should appear in lookup screens for orders and purchasing.
        /// </summary>
        bool HideItem
        { get; set; }

        /// <summary>
        /// Maximum discount percentage allowed.
        /// </summary>
        decimal MaximumDiscount
        { get; set; }

        /// <summary>
        /// Minimum markup percentage above the current unit cost basis.
        /// </summary>
        decimal MinimumMarkupPercent
        { get; set; }

        /// <summary>
        /// Minimum markup amount above the current unit cost basis.
        /// </summary>
        decimal MinimumMarkupAmount
        { get; set; }

        /// <summary>
        /// Minimum retail price.
        /// </summary>
        decimal MinimumPrice
        { get; set; }

        /// <summary>
        /// Indicates whether the product is exempt from discounts.
        /// </summary>
        bool NoDiscounts
        { get; set; }

        /// <summary>
        /// Indicates if the product can be returned on an order.
        /// </summary>
        bool NoReturns
        { get; set; }

        /// <summary>
        /// If <see langword="false"/>, the product triggers a stock ID label to print when received on a purchase order.
        /// </summary>
        bool IgnorePrintStockIDLabel
        { get; set; }

        /// <summary>
        /// SKU number that will receive the inventory when the item is returned.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string ReturnItemSku
        { get; set; }

        /// <summary>
        /// Indicates if the prodct is exempt from shipping charges.
        /// </summary>
        bool ShippingChargesExempt
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SiteLINK_Image1
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SiteLINK_Image2
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SiteLINK_Image3
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SiteLINK_Image4
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SiteLINK_Image5
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SiteLINK_Image6
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SiteLINK_Image7
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SiteLINK_Image8
        { get; set; }

        /// <summary>
        /// Price threshold type for the item.
        /// </summary>
        MultichannelOrderManagerPriceThresholdType ThresholdType
        { get; set; }

        /// <summary>
        /// Specifies the number of boxes required to pack the item.
        /// </summary>
        int NumberOfBoxes
        { get; set; }

        /// <summary>
        /// Product is assembled using the product manufacturing module.
        /// </summary>
        bool ProductManufacturingModuleRequired
        { get; set; }

        /// <summary>
        /// Message to print on customer's packing/invoice.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string PackingInvoiceText
        { get; set; }

        /// <summary>
        /// Indicates whether product attributes are enabled.
        /// </summary>
        bool ProductAttributesEnabled
        { get; set; }

        /// <summary>
        /// Product disassembly setting. A value of <strong>T</strong> indicates that the product stays assembled once it is manufactured; a value of <strong>A</strong> indicates the product is automatically reverted into its raw materials.
        /// </summary>
        char ProductDisassemblySetting
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string ProductAvailability
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string MetaTitle
        { get; set; }

        /// <summary>
        /// If <see langword="true"/>, hides the product when purchasing products.
        /// </summary>
        bool CannotOrder
        { get; set; }

        /// <summary>
        /// Unit of measure.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string UnitOfMeasure
        { get; set; }

        /// <summary>
        /// Specifies how the product is manufactured. If empty or <see langword="null"/>, product is manufactured after ordering; if <strong>P</strong>, pre-manufacturing is required before product can be ordered.
        /// </summary>
        char ProductManufacturing
        { get; set; }

        /// <summary>
        /// Units in pre-manufacturing.
        /// </summary>
        decimal PreManufacturingUnits
        { get; set; }

        /// <summary>
        /// Product condition.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string Condition
        { get; set; }

        /// <summary>
        /// Product manufacturer.
        /// </summary>
        string Manufacturer
        { get; set; }

        /// <summary>
        /// Indicates whether the item is a gift card.
        /// </summary>
        bool IsGiftCard
        { get; set; }

        /// <summary>
        /// Specifies the gift card type. A value of <strong>G</strong> indicates a gift card while a value of <strong>E</strong> indicates an eGift card.
        /// </summary>
        char GiftCardType
        { get; set; }

        /// <summary>
        /// Indicates that the product is hazardous.
        /// </summary>
        bool Hazardous
        { get; set; }

        /// <summary>
        /// Indicates the product handling preference. A value of <strong>SH</strong> indicates shipper release; a value of <strong>HO</strong> indicates hold at location; a value of <strong>SI</strong> indicates signature required; lastly, a value of <strong>AD</strong> indicates an adult signature.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string Handling
        { get; set; }

        /// <summary>
        /// Product website.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string ProductUrl
        { get; set; }

        /// <summary>
        /// Indicates whether the product requires dry ice.
        /// </summary>
        bool DryIceRequired
        { get; set; }

        /// <summary>
        /// Weight of dry ice.
        /// </summary>
        decimal DryIceWeight
        { get; set; }

        /// <summary>
        /// Number of units reserved for FBA.
        /// </summary>
        int FulfilledByAmazonUnits
        { get; set; }

        /// <summary>
        /// Specified commodity code if hazardous materials or dangerous goods.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string Commodity
        { get; set; }

        /// <summary>
        /// Indicates whether the item contains alcohol.
        /// </summary>
        bool ContainsAlcohol
        { get; set; }

        /// <summary>
        /// Indicates whether the item contains lithium batteries.
        /// </summary>
        bool ContainsLithiumBatteries
        { get; set; }

        /// <summary>
        /// Gets or sets the URL to download the product.
        /// </summary>
        string DownloadProductUrl
        { get; set; }
    }
}

