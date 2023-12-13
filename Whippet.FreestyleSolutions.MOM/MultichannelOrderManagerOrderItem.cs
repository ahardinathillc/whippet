using System;
using System.Text;
using System.Data;
using System.Collections.ObjectModel;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Extensions;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents all items assigned to an order or quote.
    /// </summary>
    public class MultichannelOrderManagerOrderItem : MultichannelOrderManagerEntity, IMultichannelOrderManagerOrderSupport, IWhippetEntity, IMultichannelOrderManagerPurchaseOrderSupport, IWhippetEntityExternalDataRowImportMapper, IEqualityComparer<IMultichannelOrderManagerOrderItem>, IMultichannelOrderManagerEntity, IMultichannelOrderManagerOrderItem
    {
        private string _itemNumber;
        private string _advertisementCampaign;
        private string _description1;
        private string _salesId;
        private string _categoryCode;
        private string _itemState;
        private string _shipVia;
        private string _shipFrom;
        private string _returnItem;
        private string _supplierLicenseNumber;
        private string _lookupBy;
        private string _customerInfo;

        /// <summary>
        /// Gets or sets the unique ID of the object.
        /// </summary>
        public new long ID
        {
            get
            {
                return MomObjectID;
            }
            set
            {
                MomObjectID = value;
            }
        }

        /// <summary>
        /// Gets or sets the parent <see cref="IMultichannelOrderManagerServer"/> object that the <see cref="IMultichannelOrderManagerEntity"/> is registered with.
        /// </summary>
        IMultichannelOrderManagerServer IMultichannelOrderManagerEntity.Server
        {
            get
            {
                return Server;
            }
            set
            {
                Server = value?.ToMultichannelOrderManagerServer();
            }
        }

        /// <summary>
        /// Gets the external table name or <see langword="null"/> if the data source is not stored in a database. This property is read-only.
        /// </summary>
        protected override string ExternalTableName
        {
            get
            {
                return MultichannelOrderManagerDatabaseConstants.Tables.ITEMS;
            }
        }

        /// <summary>
        /// Gets or sets the order number of the entity.
        /// </summary>
        public virtual long OrderNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the item ID.
        /// </summary>
        public virtual long ItemID
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the item (B).
        /// </summary>
        public virtual decimal Quantity_B
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the item (F).
        /// </summary>
        public virtual decimal Quantity_F
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the item (O).
        /// </summary>
        public virtual decimal Quantity_O
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the item (P).
        /// </summary>
        public virtual decimal Quantity_P
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the item (S).
        /// </summary>
        public virtual decimal Quantity_S
        { get; set; }

        /// <summary>
        /// Gets or sets the item's unit cost.
        /// </summary>
        public virtual decimal UnitCost
        { get; set; }

        /// <summary>
        /// Gets or sets the item's list price.
        /// </summary>
        public virtual decimal UnitListPrice
        { get; set; }

        /// <summary>
        /// Gets or sets the discount applied to the item's cost.
        /// </summary>
        public virtual decimal Discount
        { get; set; }

        /// <summary>
        /// Gets or sets the purchase order number associated with the order entry.
        /// </summary>
        public virtual long PurchaseOrder
        { get; set; }

        /// <summary>
        /// Gets or sets the inventory ID of the item.
        /// </summary>
        public virtual long InventoryID
        { get; set; }

        /// <summary>
        /// Record identifier for the recipient of the item.
        /// </summary>
        public virtual long ShipTo
        { get; set; }

        /// <summary>
        /// Specifies the tax rate (N).
        /// </summary>
        public virtual decimal TaxRate_N
        { get; set; }

        /// <summary>
        /// Specifies the tax rate (S).
        /// </summary>
        public virtual decimal TaxRate_S
        { get; set; }

        /// <summary>
        /// Specifies the tax rate (C).
        /// </summary>
        public virtual decimal TaxRate_C
        { get; set; }

        /// <summary>
        /// Specifies the tax rate (I).
        /// </summary>
        public virtual decimal TaxRate_I
        { get; set; }

        /// <summary>
        /// Gets or sets the bin identifier that the item was picked from.
        /// </summary>
        public virtual long BinID
        { get; set; }

        /// <summary>
        /// Specifies the tax cap (N).
        /// </summary>
        public virtual decimal TaxCap_N
        { get; set; }

        /// <summary>
        /// Specifies the tax cap (S).
        /// </summary>
        public virtual decimal TaxCap_S
        { get; set; }

        /// <summary>
        /// Specifies the tax cap (C).
        /// </summary>
        public virtual decimal TaxCap_C
        { get; set; }

        /// <summary>
        /// Specifies the tax cap (I).
        /// </summary>
        public virtual decimal TaxCap_I
        { get; set; }

        /// <summary>
        /// Specifies the tax threshold (N).
        /// </summary>
        public virtual decimal TaxThreshold_N
        { get; set; }

        /// <summary>
        /// Specifies the tax threshold (S).
        /// </summary>
        public virtual decimal TaxThreshold_S
        { get; set; }

        /// <summary>
        /// Specifies the tax threshold (C).
        /// </summary>
        public virtual decimal TaxThreshold_C
        { get; set; }

        /// <summary>
        /// Specifies the tax threshold (I).
        /// </summary>
        public virtual decimal TaxThreshold_I
        { get; set; }

        /// <summary>
        /// Gets or sets the value added tax (VAT) amount.
        /// </summary>
        public virtual decimal VAT
        { get; set; }

        /// <summary>
        /// Gets or sets the list price with included <see cref="VAT"/> amount.
        /// </summary>
        public virtual decimal ListVAT
        { get; set; }

        /// <summary>
        /// Gets or sets the box length.
        /// </summary>
        public virtual decimal BoxLength
        { get; set; }

        /// <summary>
        /// Gets or sets the box width.
        /// </summary>
        public virtual decimal BoxWidth
        { get; set; }

        /// <summary>
        /// Gets or sets the box height.
        /// </summary>
        public virtual decimal BoxHeight
        { get; set; }

        /// <summary>
        /// Specifies any additional costs, such as handling.
        /// </summary>
        public virtual decimal AdditionalCosts
        { get; set; }

        /// <summary>
        /// Gets or sets the unique transaction ID for the order item.
        /// </summary>
        public virtual long TransactionID
        { get; set; }

        /// <summary>
        /// Indicates the box number of the item when shipped.
        /// </summary>
        public virtual long Box
        { get; set; }

        /// <summary>
        /// Gets or sets the item's certificate ID.
        /// </summary>
        public virtual long CertificateID
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        public virtual char Inpart
        { get; set; }

        /// <summary>
        /// Specifies the item number of the order item.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string ItemNumber
        {
            get
            {
                return _itemNumber;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(ItemNumber)].Column);
                _itemNumber = value;
            }
        }

        /// <summary>
        /// Specifies the sales campaign that the item was listed under.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Campaign
        {
            get
            {
                return _advertisementCampaign;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(Campaign)].Column);
                _advertisementCampaign = value;
            }
        }

        /// <summary>
        /// Gets or sets the item description.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Description
        {
            get
            {
                return _description1;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(Description)].Column);
                _description1 = value;
            }
        }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SaleID
        {
            get
            {
                return _salesId;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(SaleID)].Column);
                _salesId = value;
            }
        }

        /// <summary>
        /// Specifies the category code of the item.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string CategoryCode
        {
            get
            {
                return _categoryCode;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(CategoryCode)].Column);
                _categoryCode = value;
            }
        }

        /// <summary>
        /// Specifies the current item state.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string ItemState
        {
            get
            {
                return _itemState;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(ItemState)].Column);
                _itemState = value;
            }
        }

        /// <summary>
        /// Specifies the shipping method of the item.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string ShipVia
        {
            get
            {
                return _shipVia;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(ShipVia)].Column);
                _shipVia = value;
            }
        }

        /// <summary>
        /// Gets or sets the warehouse to ship the item from.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string ShipFrom
        {
            get
            {
                return _shipFrom;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(ShipFrom)].Column);
                _shipFrom = value;
            }
        }

        /// <summary>
        /// Specifies the tax code (N).
        /// </summary>
        public virtual string TaxCode_N
        { get; set; }

        /// <summary>
        /// Specifies the tax code (S).
        /// </summary>
        public virtual string TaxCode_S
        { get; set; }

        /// <summary>
        /// Specifies the tax code (C).
        /// </summary>
        public virtual string TaxCode_C
        { get; set; }

        /// <summary>
        /// Specifies the tax code (I).
        /// </summary>
        public virtual string TaxCode_I
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        public virtual char R_Code
        { get; set; }

        /// <summary>
        /// Specifies the return description for the item.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string ReturnItem
        {
            get
            {
                return _returnItem;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(ReturnItem)].Column);
                _returnItem = value;
            }
        }

        /// <summary>
        /// Gets or sets the supplier's license number.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SupplierLicenseNumber
        {
            get
            {
                return _supplierLicenseNumber;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(SupplierLicenseNumber)].Column);
                _supplierLicenseNumber = value;
            }
        }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        public virtual char PMM_Status
        { get; set; }

        /// <summary>
        /// Gets or sets the username of the user who last accessed the record.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string LookupBy
        {
            get
            {
                return _lookupBy;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(LookupBy)].Column);
                _lookupBy = value;
            }
        }

        /// <summary>
        /// Indicates whether the item is dropshipped.
        /// </summary>
        public virtual bool DropShip
        { get; set; }

        /// <summary>
        /// Indicates whether the item has been ordered.
        /// </summary>
        public virtual bool Ordered
        { get; set; }

        /// <summary>
        /// Specifies whether the item has been billed.
        /// </summary>
        public virtual bool Billed
        { get; set; }

        /// <summary>
        /// Specifies whether the item is oversized.
        /// </summary>
        public virtual bool Oversized
        { get; set; }

        /// <summary>
        /// Specifies whether the item has been picked.
        /// </summary>
        public virtual bool Picked
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        public virtual bool Internal_External
        { get; set; }

        /// <summary>
        /// Indicates whether the item is non-taxable.
        /// </summary>
        public virtual bool NonTaxable
        { get; set; }

        /// <summary>
        /// Indicates whether the item is a tangible product or a service.
        /// </summary>
        public virtual bool NonProduct
        { get; set; }

        /// <summary>
        /// Specifies whether the item price has changed.
        /// </summary>
        public virtual bool PriceChange
        { get; set; }

        /// <summary>
        /// Indicates whether the item has an extended description.
        /// </summary>
        public virtual bool ExtendedDescription
        { get; set; }

        /// <summary>
        /// Indicates whether the item is non-taxable (N).
        /// </summary>
        public virtual bool NonTaxable_N
        { get; set; }

        /// <summary>
        /// Indicates whether the item is non-taxable (C).
        /// </summary>
        public virtual bool NonTaxable_C
        { get; set; }

        /// <summary>
        /// Indicates whether the item is non-taxable (I).
        /// </summary>
        public virtual bool NonTaxable_I
        { get; set; }

        /// <summary>
        /// Specifies whether the tax rate is modified for the item.
        /// </summary>
        public virtual bool TaxModified
        { get; set; }

        /// <summary>
        /// Indicates whether the item is being quoted.
        /// </summary>
        public virtual bool IsQuote
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        public virtual bool PopEntry
        { get; set; }

        /// <summary>
        /// Indicates whether the item is oversized.
        /// </summary>
        public virtual bool Oversized_Extended
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        public virtual bool PointsRedeemed
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        public virtual bool GCERTPRINT
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        public virtual bool NeedsScanning
        { get; set; }

        /// <summary>
        /// Specifies whether the item has been packed for shipping.
        /// </summary>
        public virtual bool Packed
        { get; set; }

        /// <summary>
        /// Indicates whether the bin was modified.
        /// </summary>
        public virtual bool BinModified
        { get; set; }

        /// <summary>
        /// Indicates whether the warehouse was modified.
        /// </summary>
        public virtual bool WarehouseModified
        { get; set; }

        /// <summary>
        /// Indicates whether the <see cref="VAT"/> is included.
        /// </summary>
        public virtual bool IncludeVAT
        { get; set; }

        /// <summary>
        /// Indicates whether the item is oversized.
        /// </summary>
        public virtual bool Oversized_Extended_2
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        public virtual bool GCADDVALUE
        { get; set; }

        /// <summary>
        /// Indicates whether the item has been picked and scanned.
        /// </summary>
        public virtual bool PickScanned
        { get; set; }

        /// <summary>
        /// Indicates whether the service is taxable.
        /// </summary>
        public virtual bool TaxableService
        { get; set; }

        /// <summary>
        /// Specifies whether no discount is applied.
        /// </summary>
        public virtual bool NoDiscount
        { get; set; }

        /// <summary>
        /// Specifies extra customer information/notes on the order.
        /// </summary>
        public virtual string CustomerInformation
        {
            get
            {
                return _customerInfo;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(CustomerInformation)].Column);
                _customerInfo = value;
            }
        }

        /// <summary>
        /// Gets or sets the order sequence number.
        /// </summary>
        public virtual int Sequence
        { get; set; }

        /// <summary>
        /// Gets or sets the item's actual ship date.
        /// </summary>
        public virtual DateTime? ShipDate
        { get; set; }

        /// <summary>
        /// Gets or sets the item's expected date of shipping.
        /// </summary>
        public virtual DateTime? ExpectedShipDate
        { get; set; }

        /// <summary>
        /// Gets or sets the item's expected arrival date.
        /// </summary>
        public virtual DateTime? ArrivalDate
        { get; set; }

        /// <summary>
        /// Gets or sets the supplier's expected shipping date.
        /// </summary>
        public virtual DateTime? SupplierExpectedDate
        { get; set; }

        /// <summary>
        /// Gets or sets the supplier's order date.
        /// </summary>
        public virtual DateTime? SupplierOrderDate
        { get; set; }

        /// <summary>
        /// Gets or sets the supplier's ship date.
        /// </summary>
        public virtual DateTime? SupplierShipDate
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the record was last looked up.
        /// </summary>
        public virtual DateTime? LookupOn
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerOrderItem"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerOrderItem()
        { }

        /// <summary>
        /// Creates a <see cref="WhippetDataRowImportMap"/> object that contains a mapping for the current entity.
        /// </summary>
        /// <returns><see cref="WhippetDataRowImportMap"/> object.</returns>
        public override WhippetDataRowImportMap CreateImportMap()
        {
            return new WhippetDataRowImportMap(new[] {
                new WhippetDataRowImportMapEntry(nameof(OrderNumber), MultichannelOrderManagerDatabaseConstants.Columns.ORDERNO),
                new WhippetDataRowImportMapEntry(nameof(ItemID), MultichannelOrderManagerDatabaseConstants.Columns.ITEM_ID),
                new WhippetDataRowImportMapEntry(nameof(Quantity_B), MultichannelOrderManagerDatabaseConstants.Columns.QUANTB),
                new WhippetDataRowImportMapEntry(nameof(Quantity_F), MultichannelOrderManagerDatabaseConstants.Columns.QUANTF),
                new WhippetDataRowImportMapEntry(nameof(Quantity_O), MultichannelOrderManagerDatabaseConstants.Columns.QUANTO),
                new WhippetDataRowImportMapEntry(nameof(Quantity_P), MultichannelOrderManagerDatabaseConstants.Columns.QUANTP),
                new WhippetDataRowImportMapEntry(nameof(Quantity_S), MultichannelOrderManagerDatabaseConstants.Columns.QUANTS),
                new WhippetDataRowImportMapEntry(nameof(UnitCost), MultichannelOrderManagerDatabaseConstants.Columns.IT_UNCOST),
                new WhippetDataRowImportMapEntry(nameof(UnitListPrice), MultichannelOrderManagerDatabaseConstants.Columns.IT_UNLIST),
                new WhippetDataRowImportMapEntry(nameof(Discount), MultichannelOrderManagerDatabaseConstants.Columns.DISCOUNT),
                new WhippetDataRowImportMapEntry(nameof(PurchaseOrder), MultichannelOrderManagerDatabaseConstants.Columns.PONUMBER),
                new WhippetDataRowImportMapEntry(nameof(InventoryID), MultichannelOrderManagerDatabaseConstants.Columns.INVENT_ID),
                new WhippetDataRowImportMapEntry(nameof(ShipTo), MultichannelOrderManagerDatabaseConstants.Columns.SHIP_TO),
                new WhippetDataRowImportMapEntry(nameof(TaxRate_N), MultichannelOrderManagerDatabaseConstants.Columns.NTAXRATE),
                new WhippetDataRowImportMapEntry(nameof(TaxRate_S), MultichannelOrderManagerDatabaseConstants.Columns.STAXRATE),
                new WhippetDataRowImportMapEntry(nameof(TaxRate_C), MultichannelOrderManagerDatabaseConstants.Columns.CTAXRATE),
                new WhippetDataRowImportMapEntry(nameof(TaxRate_I), MultichannelOrderManagerDatabaseConstants.Columns.ITAXRATE),
                new WhippetDataRowImportMapEntry(nameof(BinID), MultichannelOrderManagerDatabaseConstants.Columns.BIN_ID),
                new WhippetDataRowImportMapEntry(nameof(TaxCap_N), MultichannelOrderManagerDatabaseConstants.Columns.NTAXCAP),
                new WhippetDataRowImportMapEntry(nameof(TaxCap_S), MultichannelOrderManagerDatabaseConstants.Columns.STAXCAP),
                new WhippetDataRowImportMapEntry(nameof(TaxCap_C), MultichannelOrderManagerDatabaseConstants.Columns.CTAXCAP),
                new WhippetDataRowImportMapEntry(nameof(TaxCap_I), MultichannelOrderManagerDatabaseConstants.Columns.ITAXCAP),
                new WhippetDataRowImportMapEntry(nameof(TaxThreshold_N), MultichannelOrderManagerDatabaseConstants.Columns.NTAXTHRES),
                new WhippetDataRowImportMapEntry(nameof(TaxThreshold_S), MultichannelOrderManagerDatabaseConstants.Columns.STAXTHRES),
                new WhippetDataRowImportMapEntry(nameof(TaxThreshold_C), MultichannelOrderManagerDatabaseConstants.Columns.CTAXTHRES),
                new WhippetDataRowImportMapEntry(nameof(TaxThreshold_I), MultichannelOrderManagerDatabaseConstants.Columns.ITAXTHRES),
                new WhippetDataRowImportMapEntry(nameof(VAT), MultichannelOrderManagerDatabaseConstants.Columns.VATAMT),
                new WhippetDataRowImportMapEntry(nameof(ListVAT), MultichannelOrderManagerDatabaseConstants.Columns.VATLIST),
                new WhippetDataRowImportMapEntry(nameof(BoxLength), MultichannelOrderManagerDatabaseConstants.Columns.BLENGTH),
                new WhippetDataRowImportMapEntry(nameof(BoxWidth), MultichannelOrderManagerDatabaseConstants.Columns.BWIDTH),
                new WhippetDataRowImportMapEntry(nameof(BoxHeight), MultichannelOrderManagerDatabaseConstants.Columns.BHEIGHT),
                new WhippetDataRowImportMapEntry(nameof(AdditionalCosts), MultichannelOrderManagerDatabaseConstants.Columns.ADDLCOST),
                new WhippetDataRowImportMapEntry(nameof(TransactionID), MultichannelOrderManagerDatabaseConstants.Columns.TRANS_ID),
                new WhippetDataRowImportMapEntry(nameof(Box), MultichannelOrderManagerDatabaseConstants.Columns.BOX),
                new WhippetDataRowImportMapEntry(nameof(CertificateID), MultichannelOrderManagerDatabaseConstants.Columns.CERTID),
                new WhippetDataRowImportMapEntry(nameof(Inpart), MultichannelOrderManagerDatabaseConstants.Columns.INPART),
                new WhippetDataRowImportMapEntry(nameof(ItemNumber), MultichannelOrderManagerDatabaseConstants.Columns.ITEM),
                new WhippetDataRowImportMapEntry(nameof(Campaign), MultichannelOrderManagerDatabaseConstants.Columns.ADVERT),
                new WhippetDataRowImportMapEntry(nameof(Description), MultichannelOrderManagerDatabaseConstants.Columns.DESC1),
                new WhippetDataRowImportMapEntry(nameof(SaleID), MultichannelOrderManagerDatabaseConstants.Columns.SALES_ID),
                new WhippetDataRowImportMapEntry(nameof(CategoryCode), MultichannelOrderManagerDatabaseConstants.Columns.CATCODE),
                new WhippetDataRowImportMapEntry(nameof(ItemState), MultichannelOrderManagerDatabaseConstants.Columns.ITEM_STATE),
                new WhippetDataRowImportMapEntry(nameof(ShipVia), MultichannelOrderManagerDatabaseConstants.Columns.SHIP_VIA),
                new WhippetDataRowImportMapEntry(nameof(ShipFrom), MultichannelOrderManagerDatabaseConstants.Columns.SHIP_FROM),
                new WhippetDataRowImportMapEntry(nameof(TaxCode_N), MultichannelOrderManagerDatabaseConstants.Columns.NTAXCODE),
                new WhippetDataRowImportMapEntry(nameof(TaxCode_S), MultichannelOrderManagerDatabaseConstants.Columns.STAXCODE),
                new WhippetDataRowImportMapEntry(nameof(TaxCode_C), MultichannelOrderManagerDatabaseConstants.Columns.CTAXCODE),
                new WhippetDataRowImportMapEntry(nameof(TaxCode_I), MultichannelOrderManagerDatabaseConstants.Columns.ITAXCODE),
                new WhippetDataRowImportMapEntry(nameof(R_Code), MultichannelOrderManagerDatabaseConstants.Columns.R_CODE),
                new WhippetDataRowImportMapEntry(nameof(ReturnItem), MultichannelOrderManagerDatabaseConstants.Columns.RETITEM),
                new WhippetDataRowImportMapEntry(nameof(SupplierLicenseNumber), MultichannelOrderManagerDatabaseConstants.Columns.SUP_LICNUM),
                new WhippetDataRowImportMapEntry(nameof(PMM_Status), MultichannelOrderManagerDatabaseConstants.Columns.PMMSTATUS),
                new WhippetDataRowImportMapEntry(nameof(LookupBy), MultichannelOrderManagerDatabaseConstants.Columns.LU_BY),
                new WhippetDataRowImportMapEntry(nameof(DropShip), MultichannelOrderManagerDatabaseConstants.Columns.DROPSHIP),
                new WhippetDataRowImportMapEntry(nameof(Ordered), MultichannelOrderManagerDatabaseConstants.Columns.ORDERED),
                new WhippetDataRowImportMapEntry(nameof(Billed), MultichannelOrderManagerDatabaseConstants.Columns.BILLED),
                new WhippetDataRowImportMapEntry(nameof(Oversized), MultichannelOrderManagerDatabaseConstants.Columns.OVERSIZED),
                new WhippetDataRowImportMapEntry(nameof(Picked), MultichannelOrderManagerDatabaseConstants.Columns.PICKED),
                new WhippetDataRowImportMapEntry(nameof(Internal_External), MultichannelOrderManagerDatabaseConstants.Columns.INT_EXT),
                new WhippetDataRowImportMapEntry(nameof(NonTaxable), MultichannelOrderManagerDatabaseConstants.Columns.NONTAX),
                new WhippetDataRowImportMapEntry(nameof(NonProduct), MultichannelOrderManagerDatabaseConstants.Columns.NONPRODUCT),
                new WhippetDataRowImportMapEntry(nameof(PriceChange), MultichannelOrderManagerDatabaseConstants.Columns.PRICECHANG),
                new WhippetDataRowImportMapEntry(nameof(ExtendedDescription), MultichannelOrderManagerDatabaseConstants.Columns.EXTENDDESC),
                new WhippetDataRowImportMapEntry(nameof(NonTaxable_N), MultichannelOrderManagerDatabaseConstants.Columns.N_NONTAX),
                new WhippetDataRowImportMapEntry(nameof(NonTaxable_C), MultichannelOrderManagerDatabaseConstants.Columns.C_NONTAX),
                new WhippetDataRowImportMapEntry(nameof(NonTaxable_I), MultichannelOrderManagerDatabaseConstants.Columns.I_NONTAX),
                new WhippetDataRowImportMapEntry(nameof(TaxModified), MultichannelOrderManagerDatabaseConstants.Columns.TAXMODIFY),
                new WhippetDataRowImportMapEntry(nameof(IsQuote), MultichannelOrderManagerDatabaseConstants.Columns.QUOTATION),
                new WhippetDataRowImportMapEntry(nameof(PopEntry), MultichannelOrderManagerDatabaseConstants.Columns.POPENTRY),
                new WhippetDataRowImportMapEntry(nameof(Oversized_Extended), MultichannelOrderManagerDatabaseConstants.Columns.OVERSIZE2),
                new WhippetDataRowImportMapEntry(nameof(PointsRedeemed), MultichannelOrderManagerDatabaseConstants.Columns.PTS_RDEEMD),
                new WhippetDataRowImportMapEntry(nameof(TaxModified), MultichannelOrderManagerDatabaseConstants.Columns.TAXMODIFY),
                new WhippetDataRowImportMapEntry(nameof(GCERTPRINT), MultichannelOrderManagerDatabaseConstants.Columns.GCERTPRINT),
                new WhippetDataRowImportMapEntry(nameof(NeedsScanning), MultichannelOrderManagerDatabaseConstants.Columns.NEEDSCAN),
                new WhippetDataRowImportMapEntry(nameof(Packed), MultichannelOrderManagerDatabaseConstants.Columns.PACKED),
                new WhippetDataRowImportMapEntry(nameof(BinModified), MultichannelOrderManagerDatabaseConstants.Columns.BINMODIFY),
                new WhippetDataRowImportMapEntry(nameof(WarehouseModified), MultichannelOrderManagerDatabaseConstants.Columns.WAREMODIFY),
                new WhippetDataRowImportMapEntry(nameof(IncludeVAT), MultichannelOrderManagerDatabaseConstants.Columns.VATINCL),
                new WhippetDataRowImportMapEntry(nameof(Oversized_Extended_2), MultichannelOrderManagerDatabaseConstants.Columns.OVERSIZE3),
                new WhippetDataRowImportMapEntry(nameof(GCADDVALUE), MultichannelOrderManagerDatabaseConstants.Columns.GCADDVALUE),
                new WhippetDataRowImportMapEntry(nameof(PickScanned), MultichannelOrderManagerDatabaseConstants.Columns.PICKSCAN),
                new WhippetDataRowImportMapEntry(nameof(TaxableService), MultichannelOrderManagerDatabaseConstants.Columns.TAXSERVICE),
                new WhippetDataRowImportMapEntry(nameof(NoDiscount), MultichannelOrderManagerDatabaseConstants.Columns.NODSCT),
                new WhippetDataRowImportMapEntry(nameof(CustomerInformation), MultichannelOrderManagerDatabaseConstants.Columns.CUSTOMINFO),
                new WhippetDataRowImportMapEntry(nameof(ShipDate), MultichannelOrderManagerDatabaseConstants.Columns.IT_SDATE),
                new WhippetDataRowImportMapEntry(nameof(ExpectedShipDate), MultichannelOrderManagerDatabaseConstants.Columns.SHIP_WHEN),
                new WhippetDataRowImportMapEntry(nameof(ArrivalDate), MultichannelOrderManagerDatabaseConstants.Columns.COMMITDATE),
                new WhippetDataRowImportMapEntry(nameof(SupplierExpectedDate), MultichannelOrderManagerDatabaseConstants.Columns.SUP_EDATE),
                new WhippetDataRowImportMapEntry(nameof(SupplierOrderDate), MultichannelOrderManagerDatabaseConstants.Columns.SUP_ODATE),
                new WhippetDataRowImportMapEntry(nameof(SupplierShipDate), MultichannelOrderManagerDatabaseConstants.Columns.SUP_SDATE),
                new WhippetDataRowImportMapEntry(nameof(LookupOn), MultichannelOrderManagerDatabaseConstants.Columns.LU_ON),
                new WhippetDataRowImportMapEntry(nameof(Sequence), MultichannelOrderManagerDatabaseConstants.Columns.SEQ)
            });
        }

        /// <summary>
        /// Imports the specified <see cref="DataRow"/> containing the information needed to populate the <see cref="IWhippetEntity"/>. This method must be overridden.
        /// </summary>
        /// <param name="dataRow"><see cref="DataRow"/> containing the data to import.</param>
        /// <param name="importMap">External <see cref="WhippetDataRowImportMap"/>. If <see langword="null"/>, then the one generated by <see cref="CreateImportMap"/> will be used.</param>
        /// <exception cref="ArgumentNullException" />
        public override void ImportDataRow(DataRow dataRow, WhippetDataRowImportMap importMap = null)
        {
            if (dataRow == null)
            {
                throw new ArgumentNullException(nameof(dataRow));
            }
            else
            {
                WhippetDataRowImportMap map = (importMap == null ? CreateImportMap() : importMap);

                AdditionalCosts = dataRow.Field<decimal>(map[nameof(AdditionalCosts)].Column);
                ArrivalDate = dataRow.Field<DateTime?>(map[nameof(ArrivalDate)].Column);
                Billed = dataRow.Field<bool>(map[nameof(Billed)].Column);
                BinID = dataRow.Field<long>(map[nameof(BinID)].Column);
                BinModified = dataRow.Field<bool>(map[nameof(BinModified)].Column);
                Box = dataRow.Field<long>(map[nameof(Box)].Column);
                BoxHeight = dataRow.Field<decimal>(map[nameof(BoxHeight)].Column);
                BoxLength = dataRow.Field<decimal>(map[nameof(BoxLength)].Column);
                BoxWidth = dataRow.Field<decimal>(map[nameof(BoxWidth)].Column);
                Campaign = dataRow.Field<string>(map[nameof(Campaign)].Column);
                CategoryCode = dataRow.Field<string>(map[nameof(CategoryCode)].Column);
                CertificateID = dataRow.Field<long>(map[nameof(CertificateID)].Column);
                CustomerInformation = dataRow.Field<string>(map[nameof(CustomerInformation)].Column);
                Description = dataRow.Field<string>(map[nameof(Description)].Column);
                Discount = dataRow.Field<decimal>(map[nameof(Discount)].Column);
                DropShip = dataRow.Field<bool>(map[nameof(DropShip)].Column);
                ExpectedShipDate = dataRow.Field<DateTime?>(map[nameof(ExpectedShipDate)].Column);
                ExtendedDescription = dataRow.Field<bool>(map[nameof(ExtendedDescription)].Column);
                GCADDVALUE = dataRow.Field<bool>(map[nameof(GCADDVALUE)].Column);
                GCERTPRINT = dataRow.Field<bool>(map[nameof(GCERTPRINT)].Column);
                IncludeVAT = dataRow.Field<bool>(map[nameof(IncludeVAT)].Column);
                Inpart = dataRow.Field<char>(map[nameof(Inpart)].Column);
                Internal_External = dataRow.Field<bool>(map[nameof(Internal_External)].Column);
                InventoryID = dataRow.Field<long>(map[nameof(InventoryID)].Column);
                IsQuote = dataRow.Field<bool>(map[nameof(IsQuote)].Column);
                ItemID = dataRow.Field<long>(map[nameof(ItemID)].Column);
                ItemNumber = dataRow.Field<string>(map[nameof(ItemNumber)].Column);
                ItemState = dataRow.Field<string>(map[nameof(ItemState)].Column);
                ListVAT = dataRow.Field<long>(map[nameof(Box)].Column);
                LookupBy = dataRow.Field<string>(map[nameof(LookupBy)].Column);
                LookupOn = dataRow.Field<DateTime?>(map[nameof(LookupOn)].Column);
                NeedsScanning = dataRow.Field<bool>(map[nameof(NeedsScanning)].Column);
                NoDiscount = dataRow.Field<bool>(map[nameof(NoDiscount)].Column);
                NonProduct = dataRow.Field<bool>(map[nameof(NonProduct)].Column);
                NonTaxable = dataRow.Field<bool>(map[nameof(NonTaxable)].Column);
                NonTaxable_C = dataRow.Field<bool>(map[nameof(NonTaxable_C)].Column);
                NonTaxable_I = dataRow.Field<bool>(map[nameof(NonTaxable_I)].Column);
                NonTaxable_N = dataRow.Field<bool>(map[nameof(NonTaxable_N)].Column);
                Ordered = dataRow.Field<bool>(map[nameof(Ordered)].Column);
                OrderNumber = dataRow.Field<long>(map[nameof(OrderNumber)].Column);
                Oversized = dataRow.Field<bool>(map[nameof(Oversized)].Column);
                Oversized_Extended = dataRow.Field<bool>(map[nameof(Oversized_Extended)].Column);
                Oversized_Extended_2 = dataRow.Field<bool>(map[nameof(Oversized_Extended_2)].Column);
                Packed = dataRow.Field<bool>(map[nameof(Packed)].Column);
                Picked = dataRow.Field<bool>(map[nameof(Picked)].Column);
                PickScanned = dataRow.Field<bool>(map[nameof(PickScanned)].Column);
                PMM_Status = dataRow.Field<char>(map[nameof(PMM_Status)].Column);
                PointsRedeemed = dataRow.Field<bool>(map[nameof(PointsRedeemed)].Column);
                PopEntry = dataRow.Field<bool>(map[nameof(PopEntry)].Column);
                PriceChange = dataRow.Field<bool>(map[nameof(PriceChange)].Column);
                PurchaseOrder = dataRow.Field<long>(map[nameof(PurchaseOrder)].Column);
                Quantity_B = dataRow.Field<decimal>(map[nameof(Quantity_B)].Column);
                Quantity_F = dataRow.Field<decimal>(map[nameof(Quantity_F)].Column);
                Quantity_O = dataRow.Field<decimal>(map[nameof(Quantity_O)].Column);
                Quantity_P = dataRow.Field<decimal>(map[nameof(Quantity_P)].Column);
                Quantity_S = dataRow.Field<decimal>(map[nameof(Quantity_S)].Column);
                ReturnItem = dataRow.Field<string>(map[nameof(ReturnItem)].Column);
                R_Code = dataRow.Field<char>(map[nameof(R_Code)].Column);
                SaleID = dataRow.Field<string>(map[nameof(SaleID)].Column);
                Sequence = dataRow.Field<int>(map[nameof(Sequence)].Column);
                ShipDate = dataRow.Field<DateTime?>(map[nameof(ShipDate)].Column);
                ShipFrom = dataRow.Field<string>(map[nameof(ShipFrom)].Column);
                ShipTo = dataRow.Field<long>(map[nameof(ShipTo)].Column);
                ShipVia = dataRow.Field<string>(map[nameof(ShipVia)].Column);
                SupplierExpectedDate = dataRow.Field<DateTime?>(map[nameof(SupplierExpectedDate)].Column);
                SupplierLicenseNumber = dataRow.Field<string>(map[nameof(SupplierLicenseNumber)].Column);
                SupplierOrderDate = dataRow.Field<DateTime?>(map[nameof(SupplierOrderDate)].Column);
                SupplierShipDate = dataRow.Field<DateTime?>(map[nameof(SupplierShipDate)].Column);
                TaxableService = dataRow.Field<bool>(map[nameof(TaxableService)].Column);
                TaxCap_C = dataRow.Field<decimal>(map[nameof(TaxCap_C)].Column);
                TaxCap_I = dataRow.Field<decimal>(map[nameof(TaxCap_I)].Column);
                TaxCap_N = dataRow.Field<decimal>(map[nameof(TaxCap_N)].Column);
                TaxCap_S = dataRow.Field<decimal>(map[nameof(TaxCap_S)].Column);
                TaxCode_C = dataRow.Field<string>(map[nameof(TaxCode_C)].Column);
                TaxCode_I = dataRow.Field<string>(map[nameof(TaxCode_I)].Column);
                TaxCode_N = dataRow.Field<string>(map[nameof(TaxCode_N)].Column);
                TaxCode_S = dataRow.Field<string>(map[nameof(TaxCode_S)].Column);
                TaxModified = dataRow.Field<bool>(map[nameof(TaxModified)].Column);
                TaxRate_C = dataRow.Field<decimal>(map[nameof(TaxRate_C)].Column);
                TaxRate_I = dataRow.Field<decimal>(map[nameof(TaxRate_I)].Column);
                TaxRate_N = dataRow.Field<decimal>(map[nameof(TaxRate_N)].Column);
                TaxRate_S = dataRow.Field<decimal>(map[nameof(TaxRate_S)].Column);
                TaxThreshold_C = dataRow.Field<decimal>(map[nameof(TaxThreshold_C)].Column);
                TaxThreshold_I = dataRow.Field<decimal>(map[nameof(TaxThreshold_I)].Column);
                TaxThreshold_N = dataRow.Field<decimal>(map[nameof(TaxThreshold_N)].Column);
                TaxThreshold_S = dataRow.Field<decimal>(map[nameof(TaxThreshold_S)].Column);
                TransactionID = dataRow.Field<long>(map[nameof(TransactionID)].Column);
                UnitCost = dataRow.Field<decimal>(map[nameof(UnitCost)].Column);
                UnitListPrice = dataRow.Field<decimal>(map[nameof(UnitListPrice)].Column);
                VAT = dataRow.Field<decimal>(map[nameof(VAT)].Column);
                WarehouseModified = dataRow.Field<bool>(map[nameof(WarehouseModified)].Column);
            }
        }

        /// <summary>
        /// Creates a <see cref="DataTable"/> that represents the database table of the current entity.
        /// </summary>
        /// <returns><see cref="DataTable"/> containing the columns and respective definitions of the associated external database table for the current entity.</returns>
        public override DataTable CreateDataTable()
        {
            WhippetDataRowImportMap map = CreateImportMap();
            DataTable table = new DataTable(((IWhippetEntityExternalDataRowImportMapper)(this)).ExternalTableName);

            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(AdditionalCosts)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(ArrivalDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Billed)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<long>(map[nameof(BinID)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(BinModified)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<long>(map[nameof(Box)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(BoxHeight)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(BoxLength)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(BoxWidth)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Campaign)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CategoryCode)].Column, false, 6));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<long>(map[nameof(CertificateID)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CustomerInformation)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Description)].Column, false, 30));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(Discount)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(DropShip)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(ExpectedShipDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(ExtendedDescription)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(GCADDVALUE)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(GCERTPRINT)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IncludeVAT)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(Inpart)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Internal_External)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<long>(map[nameof(InventoryID)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsQuote)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<long>(map[nameof(ItemID)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ItemNumber)].Column, false, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ItemState)].Column, false, 2));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(ListVAT)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(LookupBy)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LookupOn)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(NeedsScanning)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(NoDiscount)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(NonProduct)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(NonTaxable)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(NonTaxable_C)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(NonTaxable_I)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(NonTaxable_N)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Ordered)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<long>(map[nameof(OrderNumber)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Oversized)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Oversized_Extended)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Oversized_Extended_2)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Packed)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Picked)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(PickScanned)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(PMM_Status)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(PointsRedeemed)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(PopEntry)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(PriceChange)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<long>(map[nameof(PurchaseOrder)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(Quantity_B)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(Quantity_F)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(Quantity_O)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(Quantity_P)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(Quantity_S)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ReturnItem)].Column, false, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(R_Code)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SaleID)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(Sequence)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(ShipDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ShipFrom)].Column, false, 6));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<long>(map[nameof(ShipTo)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ShipVia)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(SupplierExpectedDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SupplierLicenseNumber)].Column, false, 15));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(SupplierOrderDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(SupplierShipDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(TaxableService)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(TaxCap_C)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(TaxCap_I)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(TaxCap_N)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(TaxCap_S)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(TaxCode_C)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(TaxCode_I)].Column, false, 5));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(TaxCode_N)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(TaxCode_S)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(TaxModified)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(TaxRate_C)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(TaxRate_I)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(TaxRate_N)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(TaxRate_S)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(TaxThreshold_C)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(TaxThreshold_I)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(TaxThreshold_N)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(TaxThreshold_S)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<long>(map[nameof(TransactionID)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(UnitCost)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(UnitListPrice)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(VAT)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(WarehouseModified)].Column, false));

            table.PrimaryKey = new[] { table.Columns[map[nameof(ItemID)].Column] };

            return table;
        }

        /// <summary>
        /// Creates a new <see cref="DataRow"/> that represents the current entity's state.
        /// </summary>
        /// <returns><see cref="DataRow"/> object containing the values of the current entity.</returns>
        public override DataRow CreateDataRow()
        {
            return this.CreateDataRow__Internal();
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IMultichannelOrderManagerOrderItem);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerOrderItem obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="IMultichannelOrderManagerOrderItem"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IMultichannelOrderManagerOrderItem"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerOrderItem a, IMultichannelOrderManagerOrderItem b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals =
                    a.Server.Equals(b.Server)
                        && a.AdditionalCosts.Equals(b.AdditionalCosts)
                        && a.ArrivalDate.GetValueOrDefault().Equals(b.ArrivalDate.GetValueOrDefault())
                        && a.Billed.Equals(b.Billed)
                        && a.BinID.Equals(b.BinID)
                        && a.BinModified.Equals(b.BinModified)
                        && a.Box.Equals(b.Box)
                        && a.BoxHeight.Equals(b.BoxHeight)
                        && a.BoxLength.Equals(b.BoxLength)
                        && a.BoxWidth.Equals(b.BoxWidth)
                        && String.Equals(a.Campaign, b.Campaign, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.CategoryCode, b.CategoryCode, StringComparison.InvariantCultureIgnoreCase)
                        && a.CertificateID.Equals(b.CertificateID)
                        && String.Equals(a.CustomerInformation, b.CustomerInformation, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Description, b.Description, StringComparison.InvariantCultureIgnoreCase)
                        && a.Discount.Equals(b.Discount)
                        && a.DropShip.Equals(b.DropShip)
                        && a.ExpectedShipDate.GetValueOrDefault().Equals(b.ExpectedShipDate.GetValueOrDefault())
                        && a.ExtendedDescription.Equals(b.ExtendedDescription)
                        && a.GCADDVALUE.Equals(b.GCADDVALUE)
                        && a.GCERTPRINT.Equals(b.GCERTPRINT)
                        && a.IncludeVAT.Equals(b.IncludeVAT)
                        && a.Inpart.Equals(b.Inpart)
                        && a.Internal_External.Equals(b.Internal_External)
                        && a.InventoryID.Equals(b.InventoryID)
                        && a.IsQuote.Equals(b.IsQuote)
                        && a.ItemID.Equals(b.ItemID)
                        && a.ItemNumber.Equals(b.ItemNumber)
                        && String.Equals(a.ItemState, b.ItemState, StringComparison.InvariantCultureIgnoreCase)
                        && a.ListVAT.Equals(b.ListVAT)
                        && String.Equals(a.LookupBy, b.LookupBy, StringComparison.InvariantCultureIgnoreCase)
                        && a.LookupOn.GetValueOrDefault().Equals(b.LookupOn.GetValueOrDefault())
                        && a.NeedsScanning.Equals(b.NeedsScanning)
                        && a.NoDiscount.Equals(b.NoDiscount)
                        && a.NonProduct.Equals(b.NonProduct)
                        && a.NonTaxable.Equals(b.NonTaxable)
                        && a.NonTaxable_C.Equals(b.NonTaxable_C)
                        && a.NonTaxable_I.Equals(b.NonTaxable_I)
                        && a.NonTaxable_N.Equals(b.NonTaxable_N)
                        && a.Ordered.Equals(b.Ordered)
                        && a.OrderNumber.Equals(b.OrderNumber)
                        && a.Oversized.Equals(b.Oversized)
                        && a.Oversized_Extended.Equals(b.Oversized_Extended)
                        && a.Oversized_Extended_2.Equals(b.Oversized_Extended_2)
                        && a.Packed.Equals(b.Packed)
                        && a.Picked.Equals(b.Picked)
                        && a.PickScanned.Equals(b.PickScanned)
                        && a.PMM_Status.Equals(b.PMM_Status)
                        && a.PointsRedeemed.Equals(b.PointsRedeemed)
                        && a.PopEntry.Equals(b.PopEntry)
                        && a.PriceChange.Equals(b.PriceChange)
                        && a.PurchaseOrder.Equals(b.PurchaseOrder)
                        && a.Quantity_B.Equals(b.Quantity_B)
                        && a.Quantity_F.Equals(b.Quantity_F)
                        && a.Quantity_O.Equals(b.Quantity_O)
                        && a.Quantity_P.Equals(b.Quantity_P)
                        && a.Quantity_S.Equals(b.Quantity_S)
                        && String.Equals(a.ReturnItem, b.ReturnItem, StringComparison.InvariantCultureIgnoreCase)
                        && a.R_Code.Equals(b.R_Code)
                        && String.Equals(a.SaleID, b.SaleID, StringComparison.InvariantCultureIgnoreCase)
                        && a.Sequence.Equals(b.Sequence)
                        && a.ShipDate.GetValueOrDefault().Equals(b.ShipDate.GetValueOrDefault())
                        && String.Equals(a.ShipFrom, b.ShipFrom, StringComparison.InvariantCultureIgnoreCase)
                        && a.ShipTo.Equals(b.ShipTo)
                        && String.Equals(a.ShipVia, b.ShipVia, StringComparison.InvariantCultureIgnoreCase)
                        && a.SupplierExpectedDate.GetValueOrDefault().Equals(b.SupplierExpectedDate.GetValueOrDefault())
                        && String.Equals(a.SupplierLicenseNumber, b.SupplierLicenseNumber, StringComparison.InvariantCultureIgnoreCase)
                        && a.SupplierOrderDate.GetValueOrDefault().Equals(b.SupplierOrderDate.GetValueOrDefault())
                        && a.SupplierShipDate.GetValueOrDefault().Equals(b.SupplierShipDate.GetValueOrDefault())
                        && a.TaxableService.Equals(b.TaxableService)
                        && a.TaxCap_C.Equals(b.TaxCap_C)
                        && a.TaxCap_I.Equals(b.TaxCap_I)
                        && a.TaxCap_N.Equals(b.TaxCap_N)
                        && a.TaxCap_S.Equals(b.TaxCap_S)
                        && a.TaxCode_C.Equals(b.TaxCode_C)
                        && a.TaxCode_I.Equals(b.TaxCode_I)
                        && a.TaxCode_N.Equals(b.TaxCode_N)
                        && a.TaxCode_S.Equals(b.TaxCode_S)
                        && a.TaxModified.Equals(b.TaxModified)
                        && a.TaxRate_C.Equals(b.TaxRate_C)
                        && a.TaxRate_I.Equals(b.TaxRate_I)
                        && a.TaxRate_N.Equals(b.TaxRate_N)
                        && a.TaxRate_S.Equals(b.TaxRate_S)
                        && a.TaxThreshold_C.Equals(b.TaxThreshold_C)
                        && a.TaxThreshold_I.Equals(b.TaxThreshold_I)
                        && a.TaxThreshold_N.Equals(b.TaxThreshold_N)
                        && a.TaxThreshold_S.Equals(b.TaxThreshold_S)
                        && a.TransactionID.Equals(b.TransactionID)
                        && a.UnitCost.Equals(b.UnitCost)
                        && a.UnitListPrice.Equals(b.UnitListPrice)
                        && a.VAT.Equals(b.VAT)
                        && a.WarehouseModified.Equals(b.WarehouseModified);
            }

            return equals;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual int GetHashCode(IMultichannelOrderManagerOrderItem obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else
            {
                return obj.GetHashCode();
            }
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(ItemNumber);
            builder.Append(" [");
            builder.Append(OrderNumber);
            builder.Append("]");

            return builder.ToString();
        }

    }
}
