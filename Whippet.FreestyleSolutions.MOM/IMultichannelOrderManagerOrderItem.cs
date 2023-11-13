using System;
using System.Text;
using System.Data;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Extensions;
using System.Linq;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents all items assigned to an order or quote. Items reference <see cref="IMultichannelOrderManagerItem"/> by the <see cref="IMultichannelOrderManagerOrderItem.Item"/> field.
    /// </summary>
    public interface IMultichannelOrderManagerOrderItem : IMultichannelOrderManagerOrderSupport, IWhippetEntity, IMultichannelOrderManagerPurchaseOrderSupport, IWhippetEntityExternalDataRowImportMapper, IEqualityComparer<IMultichannelOrderManagerOrderItem>
    {
        /// <summary>
        /// Gets or sets the item ID.
        /// </summary>
        long ItemID
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the item (B).
        /// </summary>
        decimal Quantity_B
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the item (F).
        /// </summary>
        decimal Quantity_F
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the item (O).
        /// </summary>
        decimal Quantity_O
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the item (P).
        /// </summary>
        decimal Quantity_P
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the item (S).
        /// </summary>
        decimal Quantity_S
        { get; set; }

        /// <summary>
        /// Gets or sets the item's unit cost.
        /// </summary>
        decimal UnitCost
        { get; set; }

        /// <summary>
        /// Gets or sets the item's list price.
        /// </summary>
        decimal UnitListPrice
        { get; set; }

        /// <summary>
        /// Gets or sets the discount applied to the item's cost.
        /// </summary>
        decimal Discount
        { get; set; }

        /// <summary>
        /// Gets or sets the inventory ID of the item.
        /// </summary>
        long InventoryID
        { get; set; }

        /// <summary>
        /// Record identifier for the recipient of the item.
        /// </summary>
        long ShipTo
        { get; set; }

        /// <summary>
        /// Specifies the tax rate (N).
        /// </summary>
        decimal TaxRate_N
        { get; set; }

        /// <summary>
        /// Specifies the tax rate (S).
        /// </summary>
        decimal TaxRate_S
        { get; set; }

        /// <summary>
        /// Specifies the tax rate (C).
        /// </summary>
        decimal TaxRate_C
        { get; set; }

        /// <summary>
        /// Specifies the tax rate (I).
        /// </summary>
        decimal TaxRate_I
        { get; set; }

        /// <summary>
        /// Gets or sets the bin identifier that the item was picked from.
        /// </summary>
        long BinID
        { get; set; }

        /// <summary>
        /// Specifies the tax cap (N).
        /// </summary>
        decimal TaxCap_N
        { get; set; }

        /// <summary>
        /// Specifies the tax cap (S).
        /// </summary>
        decimal TaxCap_S
        { get; set; }

        /// <summary>
        /// Specifies the tax cap (C).
        /// </summary>
        decimal TaxCap_C
        { get; set; }

        /// <summary>
        /// Specifies the tax cap (I).
        /// </summary>
        decimal TaxCap_I
        { get; set; }

        /// <summary>
        /// Specifies the tax threshold (N).
        /// </summary>
        decimal TaxThreshold_N
        { get; set; }

        /// <summary>
        /// Specifies the tax threshold (S).
        /// </summary>
        decimal TaxThreshold_S
        { get; set; }

        /// <summary>
        /// Specifies the tax threshold (C).
        /// </summary>
        decimal TaxThreshold_C
        { get; set; }

        /// <summary>
        /// Specifies the tax threshold (I).
        /// </summary>
        decimal TaxThreshold_I
        { get; set; }

        /// <summary>
        /// Gets or sets the value added tax (VAT) amount.
        /// </summary>
        decimal VAT
        { get; set; }

        /// <summary>
        /// Gets or sets the list price with included <see cref="VAT"/> amount.
        /// </summary>
        decimal ListVAT
        { get; set; }

        /// <summary>
        /// Gets or sets the box length.
        /// </summary>
        decimal BoxLength
        { get; set; }

        /// <summary>
        /// Gets or sets the box width.
        /// </summary>
        decimal BoxWidth
        { get; set; }

        /// <summary>
        /// Gets or sets the box height.
        /// </summary>
        decimal BoxHeight
        { get; set; }

        /// <summary>
        /// Specifies any additional costs, such as handling.
        /// </summary>
        decimal AdditionalCosts
        { get; set; }

        /// <summary>
        /// Gets or sets the unique transaction ID for the order item.
        /// </summary>
        long TransactionID
        { get; set; }

        /// <summary>
        /// Indicates the box number of the item when shipped.
        /// </summary>
        long Box
        { get; set; }

        /// <summary>
        /// Gets or sets the item's certificate ID.
        /// </summary>
        long CertificateID
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        char Inpart
        { get; set; }

        /// <summary>
        /// Specifies the item number of the order item.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string ItemNumber
        { get; set; }

        /// <summary>
        /// Specifies the sales campaign that the item was listed under.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string Campaign
        { get; set; }

        /// <summary>
        /// Gets or sets the item description.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string Description
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SaleID
        { get; set; }

        /// <summary>
        /// Specifies the category code of the item.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string CategoryCode
        { get; set; }

        /// <summary>
        /// Specifies the current item state.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string ItemState
        { get; set; }

        /// <summary>
        /// Specifies the shipping method of the item.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string ShipVia
        { get; set; }

        /// <summary>
        /// Gets or sets the warehouse to ship the item from.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string ShipFrom
        { get; set; }

        /// <summary>
        /// Specifies the tax code (N).
        /// </summary>
        string TaxCode_N
        { get; set; }

        /// <summary>
        /// Specifies the tax code (S).
        /// </summary>
        string TaxCode_S
        { get; set; }

        /// <summary>
        /// Specifies the tax code (C).
        /// </summary>
        string TaxCode_C
        { get; set; }

        /// <summary>
        /// Specifies the tax code (I).
        /// </summary>
        string TaxCode_I
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        char R_Code
        { get; set; }

        /// <summary>
        /// Specifies the return description for the item.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string ReturnItem
        { get; set; }

        /// <summary>
        /// Gets or sets the supplier's license number.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string SupplierLicenseNumber
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        char PMM_Status
        { get; set; }

        /// <summary>
        /// Gets or sets the username of the user who last accessed the record.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string LookupBy
        { get; set; }

        /// <summary>
        /// Indicates whether the item is dropshipped.
        /// </summary>
        bool DropShip
        { get; set; }

        /// <summary>
        /// Indicates whether the item has been ordered.
        /// </summary>
        bool Ordered
        { get; set; }

        /// <summary>
        /// Specifies whether the item has been billed.
        /// </summary>
        bool Billed
        { get; set; }

        /// <summary>
        /// Specifies whether the item is oversized.
        /// </summary>
        bool Oversized
        { get; set; }

        /// <summary>
        /// Specifies whether the item has been picked.
        /// </summary>
        bool Picked
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        bool Internal_External
        { get; set; }

        /// <summary>
        /// Indicates whether the item is non-taxable.
        /// </summary>
        bool NonTaxable
        { get; set; }

        /// <summary>
        /// Indicates whether the item is a tangible product or a service.
        /// </summary>
        bool NonProduct
        { get; set; }

        /// <summary>
        /// Specifies whether the item price has changed.
        /// </summary>
        bool PriceChange
        { get; set; }

        /// <summary>
        /// Indicates whether the item has an extended description.
        /// </summary>
        bool ExtendedDescription
        { get; set; }

        /// <summary>
        /// Indicates whether the item is non-taxable (N).
        /// </summary>
        bool NonTaxable_N
        { get; set; }

        /// <summary>
        /// Indicates whether the item is non-taxable (C).
        /// </summary>
        bool NonTaxable_C
        { get; set; }

        /// <summary>
        /// Indicates whether the item is non-taxable (I).
        /// </summary>
        bool NonTaxable_I
        { get; set; }

        /// <summary>
        /// Specifies whether the tax rate is modified for the item.
        /// </summary>
        bool TaxModified
        { get; set; }

        /// <summary>
        /// Indicates whether the item is being quoted.
        /// </summary>
        bool IsQuote
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        bool PopEntry
        { get; set; }

        /// <summary>
        /// Indicates whether the item is oversized.
        /// </summary>
        bool Oversized_Extended
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        bool PointsRedeemed
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        bool GCERTPRINT
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        bool NeedsScanning
        { get; set; }

        /// <summary>
        /// Specifies whether the item has been packed for shipping.
        /// </summary>
        bool Packed
        { get; set; }

        /// <summary>
        /// Indicates whether the bin was modified.
        /// </summary>
        bool BinModified
        { get; set; }

        /// <summary>
        /// Indicates whether the warehouse was modified.
        /// </summary>
        bool WarehouseModified
        { get; set; }

        /// <summary>
        /// Indicates whether the <see cref="VAT"/> is included.
        /// </summary>
        bool IncludeVAT
        { get; set; }

        /// <summary>
        /// Indicates whether the item is oversized.
        /// </summary>
        bool Oversized_Extended_2
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        bool GCADDVALUE
        { get; set; }

        /// <summary>
        /// Indicates whether the item has been picked and scanned.
        /// </summary>
        bool PickScanned
        { get; set; }

        /// <summary>
        /// Indicates whether the service is taxable.
        /// </summary>
        bool TaxableService
        { get; set; }

        /// <summary>
        /// Specifies whether no discount is applied.
        /// </summary>
        bool NoDiscount
        { get; set; }

        /// <summary>
        /// Specifies extra customer information/notes on the order.
        /// </summary>
        string CustomerInformation
        { get; set; }

        /// <summary>
        /// Gets or sets the order sequence number.
        /// </summary>
        int Sequence
        { get; set; }

        /// <summary>
        /// Gets or sets the item's actual ship date.
        /// </summary>
        DateTime? ShipDate
        { get; set; }

        /// <summary>
        /// Gets or sets the item's expected date of shipping.
        /// </summary>
        DateTime? ExpectedShipDate
        { get; set; }

        /// <summary>
        /// Gets or sets the item's expected arrival date.
        /// </summary>
        DateTime? ArrivalDate
        { get; set; }

        /// <summary>
        /// Gets or sets the supplier's expected shipping date.
        /// </summary>
        DateTime? SupplierExpectedDate
        { get; set; }

        /// <summary>
        /// Gets or sets the supplier's order date.
        /// </summary>
        DateTime? SupplierOrderDate
        { get; set; }

        /// <summary>
        /// Gets or sets the supplier's ship date.
        /// </summary>
        DateTime? SupplierShipDate
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the record was last looked up.
        /// </summary>
        DateTime? LookupOn
        { get; set; }
    }
}
