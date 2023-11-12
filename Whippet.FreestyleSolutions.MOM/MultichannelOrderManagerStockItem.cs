using System;
using System.Text;
using System.Data;
using System.Collections.ObjectModel;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Extensions;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents a stock item in the Multichannel Order Management (M.O.M.) system.
    /// </summary>
    public class MultichannelOrderManagerStockItem : MultichannelOrderManagerEntity, IWhippetEntity, IWhippetEntityExternalDataRowImportMapper, IEqualityComparer<IMultichannelOrderManagerStockItem>, IMultichannelOrderManagerEntity, IMultichannelOrderManagerStockItem, IMultichannelOrderManagerLookup
    {
        private string _itemNumber;
        private string _description1;
        private string _description2;
        private string _extra;
        private string _carrier;
        private string _assoc;
        private string _notation;
        private string _distrib;
        private string _distStock;
        private string _upcCode;
        private string _nextSerial;
        private string _other1;
        private string _serialSku;
        private string _inetsDesc;
        private string _inetDep;
        private string _inetSubDep;
        private string _inetCsmSg;
        private string _inetCsProd;
        private string _inetImage;
        private string _salesDept;
        private string _roySup;
        private string _inetCprPmt;
        private string _inetCprMpt;
        private string _inetUsProd;
        private string _inetUsMsg;
        private string _inetThumb;
        private string _sendNotice;
        private string _isbn;
        private string _cogs_dept;
        private string _substitute;
        private string _warepref;
        private string _customText;
        private string _prefShip;
        private string _advanced1;
        private string _advanced2;
        private string _advanced3;
        private string _advanced4;
        private string _picture;
        private string _clubCode;
        private string _retItem;
        private string _slImage1;
        private string _slImage2;
        private string _slImage3;
        private string _slImage4;
        private string _slImage5;
        private string _slImage6;
        private string _slImage7;
        private string _slImage8;
        private string _pmmText;
        private string _prodAvail;
        private string _metaTitle;
        private string _uom;
        private string _condition;
        private string _manufactur;
        private string _handling;
        private string _prodUrl;
        private string _commodity;
        private string _luBy;
        private string _dlUrl;

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
        /// Gets the external table name or <see langword="null"/> if the data source is not stored in a database. This property is read-only.
        /// </summary>
        protected override string ExternalTableName
        {
            get
            {
                return MultichannelOrderManagerDatabaseConstants.Tables.STOCK;
            }
        }

        /// <summary>
        /// Stock item number. If the <see cref="Size_Color"/> field is set to <see langword="true"/>, the first ten characters will be the stock number with the following ten being the "Size/Color."
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Number
        {
            get
            {
                return _itemNumber;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Number)].Column);
                _itemNumber = value;
            }
        }

        /// <summary>
        /// First description line.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string DescriptionLineOne
        {
            get
            {
                return _description1;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(DescriptionLineOne)].Column);
                _description1 = value;
            }
        }

        /// <summary>
        /// Second description line.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string DescriptionLineTwo
        {
            get
            {
                return _description2;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(DescriptionLineTwo)].Column, true);
                _description2 = value;
            }
        }

        /// <summary>
        /// Number of units in stock.
        /// </summary>
        public virtual decimal Units
        { get; set; }

        /// <summary>
        /// Reorder level threshold.
        /// </summary>
        public virtual decimal Low
        { get; set; }

        /// <summary>
        /// Weight in pounds.
        /// </summary>
        public virtual decimal UnitWeight
        { get; set; }

        /// <summary>
        /// Average cost value.
        /// </summary>
        public virtual decimal UnitCost
        { get; set; }

        /// <summary>
        /// Retail selling price for product.
        /// </summary>
        public virtual decimal RetailPrice
        { get; set; }

        /// <summary>
        /// Number of units backordered.
        /// </summary>
        public virtual decimal UnitsBackordered
        { get; set; }

        /// <summary>
        /// Number of units on order.
        /// </summary>
        public virtual decimal UnitsOnOrder
        { get; set; }

        /// <summary>
        /// Number of units sold but not shipped.
        /// </summary>
        public virtual decimal UnitsCommitted
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        public virtual decimal Sold
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        public virtual bool Received
        { get; set; }

        /// <summary>
        /// Specifies whether the item is a composite item.
        /// </summary>
        public virtual bool ConstructItem
        { get; set; }

        /// <summary>
        /// Specifies whether the item is a breakout item.
        /// </summary>
        public virtual bool BreakoutItem
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        public virtual string Extra
        {
            get
            {
                return _extra;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Extra)].Column);
                _extra = value;
            }
        }

        /// <summary>
        /// Indicates whether the item is drop shipped.
        /// </summary>
        public virtual bool IsDropshipped
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        public virtual string Carrier
        {
            get
            {
                return _carrier;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Carrier)].Column);
                _carrier = value;
            }
        }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        public virtual decimal PurchaseOrderQuantity
        { get; set; }

        /// <summary>
        /// Current reorder quantity.
        /// </summary>
        public virtual decimal ReorderQuantity
        { get; set; }

        /// <summary>
        /// Current reorder price.
        /// </summary>
        public virtual decimal ReorderPrice
        { get; set; }

        /// <summary>
        /// Product classification code.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string ClassificationCode
        {
            get
            {
                return _assoc;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(ClassificationCode)].Column);
                _assoc = value;
            }
        }

        /// <summary>
        /// Expected delivery date.
        /// </summary>
        public virtual Instant? DeliveryDate
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        public virtual bool Delivered
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        public virtual decimal DeliveredUnits
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        public virtual decimal DeliveredTotal
        { get; set; }

        /// <summary>
        /// Bin number.
        /// </summary>
        public virtual string Bin
        { get; set; }

        /// <summary>
        /// UPS oversized indicator.
        /// </summary>
        public virtual bool Oversized
        { get; set; }

        /// <summary>
        /// Cross-sell description.
        /// </summary>
        public virtual string Notation
        {
            get
            {
                return _notation;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Notation)].Column);
                _notation = value;
            }
        }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        public virtual bool InternalExternal
        { get; set; }

        /// <summary>
        /// Taxable status.
        /// </summary>
        public virtual bool NonTaxable
        { get; set; }

        /// <summary>
        /// Special shipping costs.
        /// </summary>
        public virtual decimal ShippingCharge
        { get; set; }

        /// <summary>
        /// Last used supplier level code 1-4.
        /// </summary>
        public virtual int CurrentSupplier
        { get; set; }

        /// <summary>
        /// Current distributer.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Distributer
        {
            get
            {
                return _distrib;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Distributer)].Column);
                _distrib = value;
            }
        }

        /// <summary>
        /// Distributer stock number.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string DistributerStockNumber
        {
            get
            {
                return _distStock;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(DistributerStockNumber)].Column);
                _distStock = value;
            }
        }

        /// <summary>
        /// Indicates whether the current item is a service.
        /// </summary>
        public virtual bool IsService
        { get; set; }

        /// <summary>
        /// Indicates whether the product ships in its own container.
        /// </summary>
        public virtual bool ProductShipsInOwnBox
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        public virtual char TaxClass
        { get; set; }

        /// <summary>
        /// UPC or EAN code of the item.
        /// </summary>
        public virtual string UPC
        {
            get
            {
                return _upcCode;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(UPC)].Column);
                _upcCode = value;
            }
        }

        /// <summary>
        /// Indicates whether the product has serial numbers.
        /// </summary>
        public virtual bool HasSerialNumbers
        { get; set; }

        /// <summary>
        /// Next serial number to use.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string NextSerialNumber
        {
            get
            {
                return _nextSerial;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(NextSerialNumber)].Column);
                _nextSerial = value;
            }
        }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        public virtual bool Discontinued
        { get; set; }

        /// <summary>
        /// Indicates whether the product needs weighing during processing.
        /// </summary>
        public virtual bool RequiresWeighing
        { get; set; }

        /// <summary>
        /// Gross commission base in USD ($).
        /// </summary>
        public virtual decimal GrossCommissionBase
        { get; set; }

        /// <summary>
        /// Net commission base in USD ($).
        /// </summary>
        public virtual decimal NetCommissionBase
        { get; set; }

        /// <summary>
        /// Per unit commission base in USD ($).
        /// </summary>
        public virtual decimal FlatCommissionPerUnitBase
        { get; set; }

        /// <summary>
        /// Indicates whether the product is a subscription.
        /// </summary>
        public virtual bool IsSubscription
        { get; set; }

        /// <summary>
        /// Subscription publication code.
        /// </summary>
        public virtual string PublicationCode
        { get; set; }

        /// <summary>
        /// Specifies the number of issues (or units) in a subscription.
        /// </summary>
        public virtual int SubscriptionIssueCount
        { get; set; }

        /// <summary>
        /// Specifies whether the subscription is invoice-exempt.
        /// </summary>
        public virtual bool SubscriptionInvoiceExempt
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        public virtual decimal Royalty
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        public virtual bool Discontinue
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Other_1
        {
            get
            {
                return _other1;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Other_1)].Column);
                _other1 = value;
            }
        }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        public virtual decimal Other_2
        { get; set; }

        /// <summary>
        /// Stock number to pull serial numbers from.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SerialSku
        {
            get
            {
                return _serialSku;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SerialSku)].Column);
                _serialSku = value;
            }
        }

        /// <summary>
        /// Not used.
        /// </summary>
        [Obsolete("This field is not used and is only present for backwards-compatibility.", false)]
        public virtual decimal UnitsInBox
        { get; set; }

        /// <summary>
        /// Last purchase date.
        /// </summary>
        public virtual Instant? LastPurchaseDate
        { get; set; }

        /// <summary>
        /// Last purchase quantity.
        /// </summary>
        public virtual decimal LastPurchaseQuantity
        { get; set; }

        /// <summary>
        /// Specifies whether the item has a size and color.
        /// </summary>
        public virtual bool Size_Color
        { get; set; }

        /// <summary>
        /// Specifies whether fractional quantities are used.
        /// </summary>
        public virtual bool FractionalQuantities
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        public virtual bool SiteLINK_Sell
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SiteLINK_Description
        {
            get
            {
                return _inetsDesc;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SiteLINK_Description)].Column);
                _inetsDesc = value;
            }
        }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SiteLINK_Department
        {
            get
            {
                return _inetDep;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SiteLINK_Department)].Column);
                _inetDep = value;
            }
        }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SiteLINK_SubDepartment
        {
            get
            {
                return _inetSubDep;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SiteLINK_SubDepartment)].Column);
                _inetSubDep = value;
            }
        }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SiteLINK_CSMSG
        {
            get
            {
                return _inetCsmSg;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SiteLINK_CSMSG)].Column);
                _inetCsmSg = value;
            }
        }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SiteLINK_CsProduct
        {
            get
            {
                return _inetCsProd;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SiteLINK_CsProduct)].Column);
                _inetCsProd = value;
            }
        }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SiteLINK_Image
        {
            get
            {
                return _inetImage;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SiteLINK_Image)].Column);
                _inetImage = value;
            }
        }

        /// <summary>
        /// Product cannot be sold.
        /// </summary>
        public virtual bool CannotSell
        { get; set; }

        /// <summary>
        /// National tax class.
        /// </summary>
        public virtual char TaxClass_N
        { get; set; }

        /// <summary>
        /// State tax class.
        /// </summary>
        public virtual char TaxClass_S
        { get; set; }

        /// <summary>
        /// National tax exempt flag.
        /// </summary>
        public virtual bool NationalTaxExempt
        { get; set; }

        /// <summary>
        /// General ledger sales department.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SalesDepartment
        {
            get
            {
                return _salesDept;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SalesDepartment)].Column);
                _salesDept = value;
            }
        }

        /// <summary>
        /// Supplier code for royalties.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string RoyaltiesSupplierCode
        {
            get
            {
                return _roySup;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(RoyaltiesSupplierCode)].Column);
                _roySup = value;
            }
        }

        /// <summary>
        /// Net royalty base in USD.
        /// </summary>
        public virtual decimal RoyaltyNetBase
        { get; set; }

        /// <summary>
        /// Gross royalty base in USD.
        /// </summary>
        public virtual decimal RoyaltyGrossBase
        { get; set; }

        /// <summary>
        /// Per unit royalty base.
        /// </summary>
        public virtual decimal RoyaltyFlatBase
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        public virtual bool SiteLINK_Custom
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SiteLINK_CprPayment
        {
            get
            {
                return _inetCprPmt;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SiteLINK_CprPayment)].Column);
                _inetCprPmt = value;
            }
        }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        public virtual char DropMethod
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SiteLINK_CprMpt
        {
            get
            {
                return _inetCprMpt;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SiteLINK_CprMpt)].Column);
                _inetCprMpt = value;
            }
        }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        public virtual decimal SiteLINK_CPrice
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SiteLINK_UsProduct
        {
            get
            {
                return _inetUsProd;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SiteLINK_UsProduct)].Column);
                _inetUsProd = value;
            }
        }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SiteLINK_UsMessage
        {
            get
            {
                return _inetUsMsg;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SiteLINK_UsMessage)].Column);
                _inetUsMsg = value;
            }
        }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SiteLINK_Thumbnail
        {
            get
            {
                return _inetThumb;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SiteLINK_Thumbnail)].Column);
                _inetThumb = value;
            }
        }

        /// <summary>
        /// Notice to send with this product.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SendNotice
        {
            get
            {
                return _sendNotice;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SendNotice)].Column);
                _sendNotice = value;
            }
        }

        /// <summary>
        /// When to send the notice.
        /// </summary>
        public virtual char NoticeWhen
        { get; set; }

        /// <summary>
        /// Used to determine if product is a gift certificate item.
        /// </summary>
        public virtual bool GiftCertificate
        { get; set; }

        /// <summary>
        /// Points received when this item is purchased.
        /// </summary>
        public virtual int PointsReceived
        { get; set; }

        /// <summary>
        /// Points needed to purchase this item.
        /// </summary>
        public virtual int PointsNeeded
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        public virtual char Kit_Make
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        public virtual char Kit_Break
        { get; set; }

        /// <summary>
        /// ISBN  number of product.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string ISBN
        {
            get
            {
                return _isbn;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(ISBN)].Column);
                _isbn = value;
            }
        }

        /// <summary>
        /// General ledger department to use for returns.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string ReturnsDepartment
        {
            get
            {
                return _retItem;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(ReturnsDepartment)].Column);
                _retItem = value;
            }
        }

        /// <summary>
        /// General ledger department to use for cost of goods sold.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string CostOfGoodsSoldDepartment
        {
            get
            {
                return _cogs_dept;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(CostOfGoodsSoldDepartment)].Column);
                _cogs_dept = value;
            }
        }

        /// <summary>
        /// Oversize UPS 2 indicator.
        /// </summary>
        public virtual bool Oversized_Extended
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Substitute
        {
            get
            {
                return _substitute;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Substitute)].Column);
                _substitute = value;
            }
        }

        /// <summary>
        /// Warehouse preference for this item.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string WarehousePreference
        {
            get
            {
                return _warepref;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(WarehousePreference)].Column);
                _warepref = value;
            }
        }

        /// <summary>
        /// Used to determine if alternate warehouses can be used.
        /// </summary>
        public virtual bool AlternateWarehousesAllowed
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        public virtual bool SingleBin
        { get; set; }

        /// <summary>
        /// Number of units returned but not invoiced.
        /// </summary>
        public virtual decimal UnitsReturnedNotInvoiced
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        public virtual bool CanBuyItem
        { get; set; }

        /// <summary>
        /// County tax exempt flag.
        /// </summary>
        public virtual bool CountyNonTaxable
        { get; set; }

        /// <summary>
        /// County tax class.
        /// </summary>
        public virtual char TaxClass_C
        { get; set; }

        /// <summary>
        /// City tax exempt flag.
        /// </summary>
        public virtual bool CityNonTaxable
        { get; set; }

        /// <summary>
        /// City tax class.
        /// </summary>
        public virtual char TaxClass_I
        { get; set; }

        /// <summary>
        /// Number of drop shipped units on order.
        /// </summary>
        public virtual decimal DropShippedUnitsOnOrder
        { get; set; }

        /// <summary>
        /// Number of drop shipped units back ordered.
        /// </summary>
        public virtual decimal DropShippedUnitsOnBackOrder
        { get; set; }

        /// <summary>
        /// Item requires customization indicator.
        /// </summary>
        public virtual bool NeedsCustomization
        { get; set; }

        /// <summary>
        /// Custom information question.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string CustomText
        {
            get
            {
                return _customText;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(CustomText)].Column);
                _customText = value;
            }
        }

        /// <summary>
        /// Shipping preference for item.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string ShippingPreference
        {
            get
            {
                return _prefShip;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(ShippingPreference)].Column);
                _prefShip = value;
            }
        }

        /// <summary>
        /// Advanced search field.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string AdvancedSearch_1
        {
            get
            {
                return _advanced1;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(AdvancedSearch_1)].Column);
                _advanced1 = value;
            }
        }

        /// <summary>
        /// Advanced search field.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string AdvancedSearch_2
        {
            get
            {
                return _advanced2;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(AdvancedSearch_2)].Column);
                _advanced2 = value;
            }
        }

        /// <summary>
        /// Advanced search field.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string AdvancedSearch_3
        {
            get
            {
                return _advanced3;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(AdvancedSearch_3)].Column);
                _advanced3 = value;
            }
        }

        /// <summary>
        /// Advanced search field.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string AdvancedSearch_4
        {
            get
            {
                return _advanced4;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(AdvancedSearch_4)].Column);
                _advanced4 = value;
            }
        }

        /// <summary>
        /// Full path and name of the picture.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Picture
        {
            get
            {
                return _picture;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Picture)].Column);
                _picture = value;
            }
        }

        /// <summary>
        /// Indicates a trigger product for club membership.
        /// </summary>
        public virtual bool ClubProduct
        { get; set; }

        /// <summary>
        /// Club code associated with the trigger item.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string ClubCode
        {
            get
            {
                return _clubCode;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(ClubCode)].Column);
                _clubCode = value;
            }
        }

        /// <summary>
        /// Oversize UPS 3 indicator.
        /// </summary>
        public virtual bool Oversized_Extended2
        { get; set; }

        /// <summary>
        /// If <see langword="true"/>, item is available to sell at auction.
        /// </summary>
        public virtual bool Auction
        { get; set; }

        /// <summary>
        /// Number of units reserved for auctions.
        /// </summary>
        public virtual decimal AuctionUnits
        { get; set; }

        /// <summary>
        /// Stock item length in inches.
        /// </summary>
        public virtual decimal BoxLength
        { get; set; }

        /// <summary>
        /// Stock item height in inches.
        /// </summary>
        public virtual decimal BoxHeight
        { get; set; }

        /// <summary>
        /// Stock item width in inches.
        /// </summary>
        public virtual decimal BoxWidth
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        public virtual long StockID
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
        /// Reserved for internal use by M.O.M.
        /// </summary>
        public virtual decimal AheadBackOrder
        { get; set; }

        /// <summary>
        /// Indicates if the item should appear in lookup screens for orders and purchasing.
        /// </summary>
        public virtual bool HideItem
        { get; set; }

        /// <summary>
        /// Maximum discount percentage allowed.
        /// </summary>
        public virtual decimal MaximumDiscount
        { get; set; }

        /// <summary>
        /// Minimum markup percentage above the current unit cost basis.
        /// </summary>
        public virtual decimal MinimumMarkupPercent
        { get; set; }

        /// <summary>
        /// Minimum markup amount above the current unit cost basis.
        /// </summary>
        public virtual decimal MinimumMarkupAmount
        { get; set; }

        /// <summary>
        /// Minimum retail price.
        /// </summary>
        public virtual decimal MinimumPrice
        { get; set; }

        /// <summary>
        /// Indicates whether the product is exempt from discounts.
        /// </summary>
        public virtual bool NoDiscounts
        { get; set; }

        /// <summary>
        /// Indicates if the product can be returned on an order.
        /// </summary>
        public virtual bool NoReturns
        { get; set; }

        /// <summary>
        /// If <see langword="false"/>, the product triggers a stock ID label to print when received on a purchase order.
        /// </summary>
        public virtual bool IgnorePrintStockIDLabel
        { get; set; }

        /// <summary>
        /// SKU number that will receive the inventory when the item is returned.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string ReturnItemSku
        {
            get
            {
                return _retItem;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(ReturnItemSku)].Column);
                _retItem = value;
            }
        }

        /// <summary>
        /// Indicates if the prodct is exempt from shipping charges.
        /// </summary>
        public virtual bool ShippingChargesExempt
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SiteLINK_Image1
        {
            get
            {
                return _slImage1;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SiteLINK_Image1)].Column);
                _slImage1 = value;
            }
        }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SiteLINK_Image2
        {
            get
            {
                return _slImage2;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SiteLINK_Image2)].Column);
                _slImage2 = value;
            }
        }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SiteLINK_Image3
        {
            get
            {
                return _slImage3;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SiteLINK_Image3)].Column);
                _slImage3 = value;
            }
        }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SiteLINK_Image4
        {
            get
            {
                return _slImage4;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SiteLINK_Image4)].Column);
                _slImage4 = value;
            }
        }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SiteLINK_Image5
        {
            get
            {
                return _slImage5;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SiteLINK_Image5)].Column);
                _slImage5 = value;
            }
        }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SiteLINK_Image6
        {
            get
            {
                return _slImage6;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SiteLINK_Image6)].Column);
                _slImage6 = value;
            }
        }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SiteLINK_Image7
        {
            get
            {
                return _slImage7;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SiteLINK_Image7)].Column);
                _slImage7 = value;
            }
        }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SiteLINK_Image8
        {
            get
            {
                return _slImage8;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SiteLINK_Image8)].Column);
                _slImage8 = value;
            }
        }

        /// <summary>
        /// Price threshold type for the item.
        /// </summary>
        public virtual MultichannelOrderManagerPriceThresholdType ThresholdType
        { get; set; }

        /// <summary>
        /// Specifies the number of boxes required to pack the item.
        /// </summary>
        public virtual int NumberOfBoxes
        { get; set; }

        /// <summary>
        /// Product is assembled using the product manufacturing module.
        /// </summary>
        public virtual bool ProductManufacturingModuleRequired
        { get; set; }

        /// <summary>
        /// Message to print on customer's packing/invoice.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string PackingInvoiceText
        {
            get
            {
                return _pmmText;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(PackingInvoiceText)].Column);
                _pmmText = value;
            }
        }

        /// <summary>
        /// Indicates whether product attributes are enabled.
        /// </summary>
        public virtual bool ProductAttributesEnabled
        { get; set; }

        /// <summary>
        /// Product disassembly setting. A value of <strong>T</strong> indicates that the product stays assembled once it is manufactured; a value of <strong>A</strong> indicates the product is automatically reverted into its raw materials.
        /// </summary>
        public virtual char ProductDisassemblySetting
        { get; set; }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string ProductAvailability
        {
            get
            {
                return _prodAvail;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(ProductAvailability)].Column);
                _prodAvail = value;
            }
        }

        /// <summary>
        /// For use with SiteLINK.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string MetaTitle
        {
            get
            {
                return _metaTitle;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(MetaTitle)].Column);
                _metaTitle = value;
            }
        }

        /// <summary>
        /// If <see langword="true"/>, hides the product when purchasing products.
        /// </summary>
        public virtual bool CannotOrder
        { get; set; }

        /// <summary>
        /// Unit of measure.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string UnitOfMeasure
        {
            get
            {
                return _uom;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(UnitOfMeasure)].Column);
                _uom = value;
            }
        }

        /// <summary>
        /// Specifies how the product is manufactured. If empty or <see langword="null"/>, product is manufactured after ordering; if <strong>P</strong>, pre-manufacturing is required before product can be ordered.
        /// </summary>
        public virtual char ProductManufacturing
        { get; set; }

        /// <summary>
        /// Units in pre-manufacturing.
        /// </summary>
        public virtual decimal PreManufacturingUnits
        { get; set; }

        /// <summary>
        /// Product condition.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Condition
        {
            get
            {
                return _condition;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Condition)].Column);
                _condition = value;
            }
        }

        /// <summary>
        /// Product manufacturer.
        /// </summary>
        public virtual string Manufacturer
        {
            get
            {
                return _manufactur;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Manufacturer)].Column);
                _manufactur = value;
            }
        }

        /// <summary>
        /// Indicates whether the item is a gift card.
        /// </summary>
        public virtual bool IsGiftCard
        { get; set; }

        /// <summary>
        /// Specifies the gift card type. A value of <strong>G</strong> indicates a gift card while a value of <strong>E</strong> indicates an eGift card.
        /// </summary>
        public virtual char GiftCardType
        { get; set; }

        /// <summary>
        /// Indicates that the product is hazardous.
        /// </summary>
        public virtual bool Hazardous
        { get; set; }

        /// <summary>
        /// Indicates the product handling preference. A value of <strong>SH</strong> indicates shipper release; a value of <strong>HO</strong> indicates hold at location; a value of <strong>SI</strong> indicates signature required; lastly, a value of <strong>AD</strong> indicates an adult signature.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Handling
        {
            get
            {
                return _handling;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Handling)].Column);
                _handling = value;
            }
        }

        /// <summary>
        /// Product website.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string ProductUrl
        {
            get
            {
                return _prodUrl;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(ProductUrl)].Column);
                _prodUrl = value;
            }
        }

        /// <summary>
        /// Indicates whether the product requires dry ice.
        /// </summary>
        public virtual bool DryIceRequired
        { get; set; }

        /// <summary>
        /// Weight of dry ice.
        /// </summary>
        public virtual decimal DryIceWeight
        { get; set; }

        /// <summary>
        /// Number of units reserved for FBA.
        /// </summary>
        public virtual int FulfilledByAmazonUnits
        { get; set; }

        /// <summary>
        /// Specified commodity code if hazardous materials or dangerous goods.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Commodity
        {
            get
            {
                return _commodity;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Commodity)].Column);
                _commodity = value;
            }
        }

        /// <summary>
        /// Indicates whether the item contains alcohol.
        /// </summary>
        public virtual bool ContainsAlcohol
        { get; set; }

        /// <summary>
        /// Indicates whether the item contains lithium batteries.
        /// </summary>
        public virtual bool ContainsLithiumBatteries
        { get; set; }

        /// <summary>
        /// Gets or sets the username of who last accessed the record.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string LookupBy
        {
            get
            {
                return _luBy;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(LookupBy)].Column);
                _luBy = value;
            }
        }

        /// <summary>
        /// Gets or sets the date/time the record was last accessed.
        /// </summary>
        public virtual Instant? LookupOn
        { get; set; }

        /// <summary>
        /// Gets or sets the URL to download the product.
        /// </summary>
        public virtual string DownloadProductUrl
        {
            get
            {
                return _dlUrl;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(DownloadProductUrl)].Column);
                _dlUrl = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerStockItem"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerStockItem()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerStockItem"/> class with the specified ID.
        /// </summary>
        /// <param name="id">Unique ID of the <see cref="MultichannelOrderManagerStockItem"/>.</param>
        public MultichannelOrderManagerStockItem(long id)
            : this()
        {
            StockID = id;
        }

        /// <summary>
        /// Creates a <see cref="WhippetDataRowImportMap"/> object that contains a mapping for the current entity.
        /// </summary>
        /// <returns><see cref="WhippetDataRowImportMap"/> object.</returns>
        public override WhippetDataRowImportMap CreateImportMap()
        {
            return new WhippetDataRowImportMap(new[] {
                new WhippetDataRowImportMapEntry(nameof(Number), MultichannelOrderManagerDatabaseConstants.Columns.NUMBER),
                new WhippetDataRowImportMapEntry(nameof(DescriptionLineOne), MultichannelOrderManagerDatabaseConstants.Columns.DESC1),
                new WhippetDataRowImportMapEntry(nameof(DescriptionLineTwo), MultichannelOrderManagerDatabaseConstants.Columns.DESC2),
                new WhippetDataRowImportMapEntry(nameof(Units), MultichannelOrderManagerDatabaseConstants.Columns.UNITS),
                new WhippetDataRowImportMapEntry(nameof(Low), MultichannelOrderManagerDatabaseConstants.Columns.LOW),
                new WhippetDataRowImportMapEntry(nameof(UnitWeight), MultichannelOrderManagerDatabaseConstants.Columns.UNITWEIGHT),
                new WhippetDataRowImportMapEntry(nameof(UnitCost), MultichannelOrderManagerDatabaseConstants.Columns.UNCOST),
                new WhippetDataRowImportMapEntry(nameof(RetailPrice), MultichannelOrderManagerDatabaseConstants.Columns.PRICE1),
                new WhippetDataRowImportMapEntry(nameof(UnitsBackordered), MultichannelOrderManagerDatabaseConstants.Columns.BOUNITS),
                new WhippetDataRowImportMapEntry(nameof(UnitsOnOrder), MultichannelOrderManagerDatabaseConstants.Columns.ONORDER),
                new WhippetDataRowImportMapEntry(nameof(UnitsCommitted), MultichannelOrderManagerDatabaseConstants.Columns.COMMITTED),
                new WhippetDataRowImportMapEntry(nameof(Sold), MultichannelOrderManagerDatabaseConstants.Columns.SOLD),
                new WhippetDataRowImportMapEntry(nameof(Received), MultichannelOrderManagerDatabaseConstants.Columns.RECEIVED),
                new WhippetDataRowImportMapEntry(nameof(ConstructItem), MultichannelOrderManagerDatabaseConstants.Columns.CONSTRUCT),
                new WhippetDataRowImportMapEntry(nameof(BreakoutItem), MultichannelOrderManagerDatabaseConstants.Columns.BREAK_OUT),
                new WhippetDataRowImportMapEntry(nameof(Extra), MultichannelOrderManagerDatabaseConstants.Columns.EXTRA),
                new WhippetDataRowImportMapEntry(nameof(IsDropshipped), MultichannelOrderManagerDatabaseConstants.Columns.DROPSHIP),
                new WhippetDataRowImportMapEntry(nameof(Carrier), MultichannelOrderManagerDatabaseConstants.Columns.CARRIER),
                new WhippetDataRowImportMapEntry(nameof(PurchaseOrderQuantity), MultichannelOrderManagerDatabaseConstants.Columns.POQUANT),
                new WhippetDataRowImportMapEntry(nameof(ReorderQuantity), MultichannelOrderManagerDatabaseConstants.Columns.REORDQUANT),
                new WhippetDataRowImportMapEntry(nameof(ReorderPrice), MultichannelOrderManagerDatabaseConstants.Columns.REORDPRICE),
                new WhippetDataRowImportMapEntry(nameof(ClassificationCode), MultichannelOrderManagerDatabaseConstants.Columns.ASSOC),
                new WhippetDataRowImportMapEntry(nameof(DeliveryDate), MultichannelOrderManagerDatabaseConstants.Columns.DELDATE),
                new WhippetDataRowImportMapEntry(nameof(Delivered), MultichannelOrderManagerDatabaseConstants.Columns.DELFLAG),
                new WhippetDataRowImportMapEntry(nameof(DeliveredUnits), MultichannelOrderManagerDatabaseConstants.Columns.DELUNITS),
                new WhippetDataRowImportMapEntry(nameof(DeliveredTotal), MultichannelOrderManagerDatabaseConstants.Columns.DELTOTAL),
                new WhippetDataRowImportMapEntry(nameof(Bin), MultichannelOrderManagerDatabaseConstants.Columns.BIN),
                new WhippetDataRowImportMapEntry(nameof(Oversized), MultichannelOrderManagerDatabaseConstants.Columns.OVERSIZE),
                new WhippetDataRowImportMapEntry(nameof(Notation), MultichannelOrderManagerDatabaseConstants.Columns.NOTATION),
                new WhippetDataRowImportMapEntry(nameof(InternalExternal), MultichannelOrderManagerDatabaseConstants.Columns.INT_EXT),
                new WhippetDataRowImportMapEntry(nameof(NonTaxable), MultichannelOrderManagerDatabaseConstants.Columns.NONTAX),
                new WhippetDataRowImportMapEntry(nameof(ShippingCharge), MultichannelOrderManagerDatabaseConstants.Columns.SHIPCHARGE),
                new WhippetDataRowImportMapEntry(nameof(CurrentSupplier), MultichannelOrderManagerDatabaseConstants.Columns.CURSUPPLY),
                new WhippetDataRowImportMapEntry(nameof(Distributer), MultichannelOrderManagerDatabaseConstants.Columns.DISTRIB),
                new WhippetDataRowImportMapEntry(nameof(DistributerStockNumber), MultichannelOrderManagerDatabaseConstants.Columns.DISTSTOCK),
                new WhippetDataRowImportMapEntry(nameof(IsService), MultichannelOrderManagerDatabaseConstants.Columns.NONPRODUCT),
                new WhippetDataRowImportMapEntry(nameof(ProductShipsInOwnBox), MultichannelOrderManagerDatabaseConstants.Columns.OWN_BOX),
                new WhippetDataRowImportMapEntry(nameof(TaxClass), MultichannelOrderManagerDatabaseConstants.Columns.TAX_CLASS),
                new WhippetDataRowImportMapEntry(nameof(UPC), MultichannelOrderManagerDatabaseConstants.Columns.UPCCODE),
                new WhippetDataRowImportMapEntry(nameof(HasSerialNumbers), MultichannelOrderManagerDatabaseConstants.Columns.SERIAL),
                new WhippetDataRowImportMapEntry(nameof(NextSerialNumber), MultichannelOrderManagerDatabaseConstants.Columns.NEXTSER),
                new WhippetDataRowImportMapEntry(nameof(Discontinue), MultichannelOrderManagerDatabaseConstants.Columns.DISCONT),
                new WhippetDataRowImportMapEntry(nameof(RequiresWeighing), MultichannelOrderManagerDatabaseConstants.Columns.NEEDWEIGHT),
                new WhippetDataRowImportMapEntry(nameof(GrossCommissionBase), MultichannelOrderManagerDatabaseConstants.Columns.COMMGROSS),
                new WhippetDataRowImportMapEntry(nameof(NetCommissionBase), MultichannelOrderManagerDatabaseConstants.Columns.COMMNET),
                new WhippetDataRowImportMapEntry(nameof(FlatCommissionPerUnitBase), MultichannelOrderManagerDatabaseConstants.Columns.COMMFLAT),
                new WhippetDataRowImportMapEntry(nameof(IsSubscription), MultichannelOrderManagerDatabaseConstants.Columns.SUBSPROD),
                new WhippetDataRowImportMapEntry(nameof(PublicationCode), MultichannelOrderManagerDatabaseConstants.Columns.PUBLCTNCD),
                new WhippetDataRowImportMapEntry(nameof(SubscriptionIssueCount), MultichannelOrderManagerDatabaseConstants.Columns.SUBSISUCT),
                new WhippetDataRowImportMapEntry(nameof(SubscriptionInvoiceExempt), MultichannelOrderManagerDatabaseConstants.Columns.PRODXINVC),
                new WhippetDataRowImportMapEntry(nameof(Royalty), MultichannelOrderManagerDatabaseConstants.Columns.ROYALTY),
                new WhippetDataRowImportMapEntry(nameof(Discontinued), MultichannelOrderManagerDatabaseConstants.Columns.DISCONTINU),
                new WhippetDataRowImportMapEntry(nameof(Other_1), MultichannelOrderManagerDatabaseConstants.Columns.OTHER1),
                new WhippetDataRowImportMapEntry(nameof(Other_2), MultichannelOrderManagerDatabaseConstants.Columns.OTHER2),
                new WhippetDataRowImportMapEntry(nameof(SerialSku), MultichannelOrderManagerDatabaseConstants.Columns.SERIALSKU),
                new WhippetDataRowImportMapEntry(nameof(UnitsInBox), MultichannelOrderManagerDatabaseConstants.Columns.UNITSINBOX),
                new WhippetDataRowImportMapEntry(nameof(LastPurchaseDate), MultichannelOrderManagerDatabaseConstants.Columns.LPURCHDATE),
                new WhippetDataRowImportMapEntry(nameof(LastPurchaseQuantity), MultichannelOrderManagerDatabaseConstants.Columns.LPURCHQTY),
                new WhippetDataRowImportMapEntry(nameof(Size_Color), MultichannelOrderManagerDatabaseConstants.Columns.SIZE_COLOR),
                new WhippetDataRowImportMapEntry(nameof(FractionalQuantities), MultichannelOrderManagerDatabaseConstants.Columns.FRACTIONS),
                new WhippetDataRowImportMapEntry(nameof(SiteLINK_Sell), MultichannelOrderManagerDatabaseConstants.Columns.INETSELL),
                new WhippetDataRowImportMapEntry(nameof(SiteLINK_Description), MultichannelOrderManagerDatabaseConstants.Columns.INETDESC),
                new WhippetDataRowImportMapEntry(nameof(SiteLINK_Department), MultichannelOrderManagerDatabaseConstants.Columns.INETDEP),
                new WhippetDataRowImportMapEntry(nameof(SiteLINK_SubDepartment), MultichannelOrderManagerDatabaseConstants.Columns.INETSUBDEP),
                new WhippetDataRowImportMapEntry(nameof(SiteLINK_CSMSG), MultichannelOrderManagerDatabaseConstants.Columns.INETCSMSG),
                new WhippetDataRowImportMapEntry(nameof(SiteLINK_CsProduct), MultichannelOrderManagerDatabaseConstants.Columns.INETCSPROD),
                new WhippetDataRowImportMapEntry(nameof(SiteLINK_Image), MultichannelOrderManagerDatabaseConstants.Columns.INETIMAGE),
                new WhippetDataRowImportMapEntry(nameof(CannotSell), MultichannelOrderManagerDatabaseConstants.Columns.CANTSELL),
                new WhippetDataRowImportMapEntry(nameof(TaxClass_C), MultichannelOrderManagerDatabaseConstants.Columns.CTAXCLASS),
                new WhippetDataRowImportMapEntry(nameof(TaxClass_I), MultichannelOrderManagerDatabaseConstants.Columns.ITAXCLASS),
                new WhippetDataRowImportMapEntry(nameof(TaxClass_N), MultichannelOrderManagerDatabaseConstants.Columns.NTAXCLASS),
                new WhippetDataRowImportMapEntry(nameof(TaxClass_S), MultichannelOrderManagerDatabaseConstants.Columns.STAXCLASS),
                new WhippetDataRowImportMapEntry(nameof(NationalTaxExempt), MultichannelOrderManagerDatabaseConstants.Columns.N_NONTAX),
                new WhippetDataRowImportMapEntry(nameof(SalesDepartment), MultichannelOrderManagerDatabaseConstants.Columns.SALES_DEPT),
                new WhippetDataRowImportMapEntry(nameof(RoyaltiesSupplierCode), MultichannelOrderManagerDatabaseConstants.Columns.ROYSUP),
                new WhippetDataRowImportMapEntry(nameof(RoyaltyNetBase), MultichannelOrderManagerDatabaseConstants.Columns.ROYNET),
                new WhippetDataRowImportMapEntry(nameof(RoyaltyGrossBase), MultichannelOrderManagerDatabaseConstants.Columns.ROYGROSS),
                new WhippetDataRowImportMapEntry(nameof(RoyaltyFlatBase), MultichannelOrderManagerDatabaseConstants.Columns.ROYFLAT),
                new WhippetDataRowImportMapEntry(nameof(SiteLINK_Custom), MultichannelOrderManagerDatabaseConstants.Columns.INETCUSTOM),
                new WhippetDataRowImportMapEntry(nameof(SiteLINK_CprPayment), MultichannelOrderManagerDatabaseConstants.Columns.INETCPRPMT),
                new WhippetDataRowImportMapEntry(nameof(DropMethod), MultichannelOrderManagerDatabaseConstants.Columns.DROPMETHOD),
                new WhippetDataRowImportMapEntry(nameof(SiteLINK_CprMpt), MultichannelOrderManagerDatabaseConstants.Columns.INETCPRMPT),
                new WhippetDataRowImportMapEntry(nameof(SiteLINK_CPrice), MultichannelOrderManagerDatabaseConstants.Columns.INETCPRICE),
                new WhippetDataRowImportMapEntry(nameof(SiteLINK_UsProduct), MultichannelOrderManagerDatabaseConstants.Columns.INETUSPROD),
                new WhippetDataRowImportMapEntry(nameof(SiteLINK_UsMessage), MultichannelOrderManagerDatabaseConstants.Columns.INETUSMSG),
                new WhippetDataRowImportMapEntry(nameof(SiteLINK_Thumbnail), MultichannelOrderManagerDatabaseConstants.Columns.INETTHUMB),
                new WhippetDataRowImportMapEntry(nameof(SendNotice), MultichannelOrderManagerDatabaseConstants.Columns.SENDNOTICE),
                new WhippetDataRowImportMapEntry(nameof(NoticeWhen), MultichannelOrderManagerDatabaseConstants.Columns.NOTICEWHEN),
                new WhippetDataRowImportMapEntry(nameof(GiftCertificate), MultichannelOrderManagerDatabaseConstants.Columns.GIFTCERT),
                new WhippetDataRowImportMapEntry(nameof(PointsReceived), MultichannelOrderManagerDatabaseConstants.Columns.POINTS_REV),
                new WhippetDataRowImportMapEntry(nameof(PointsNeeded), MultichannelOrderManagerDatabaseConstants.Columns.POINTS_NED),
                new WhippetDataRowImportMapEntry(nameof(Kit_Make), MultichannelOrderManagerDatabaseConstants.Columns.KIT_MAKE),
                new WhippetDataRowImportMapEntry(nameof(Kit_Break), MultichannelOrderManagerDatabaseConstants.Columns.KIT_BREAK),
                new WhippetDataRowImportMapEntry(nameof(ISBN), MultichannelOrderManagerDatabaseConstants.Columns.ISBN),
                new WhippetDataRowImportMapEntry(nameof(ReturnsDepartment), MultichannelOrderManagerDatabaseConstants.Columns.RTNS_DEPT),
                new WhippetDataRowImportMapEntry(nameof(CostOfGoodsSoldDepartment), MultichannelOrderManagerDatabaseConstants.Columns.COGS_DEPT),
                new WhippetDataRowImportMapEntry(nameof(Oversized_Extended), MultichannelOrderManagerDatabaseConstants.Columns.OVERSIZE2),
                new WhippetDataRowImportMapEntry(nameof(Substitute), MultichannelOrderManagerDatabaseConstants.Columns.SUBSTITUTE),
                new WhippetDataRowImportMapEntry(nameof(WarehousePreference), MultichannelOrderManagerDatabaseConstants.Columns.WAREPREF),
                new WhippetDataRowImportMapEntry(nameof(AlternateWarehousesAllowed), MultichannelOrderManagerDatabaseConstants.Columns.WARE_ALTOK),
                new WhippetDataRowImportMapEntry(nameof(SingleBin), MultichannelOrderManagerDatabaseConstants.Columns.SINGLEBIN),
                new WhippetDataRowImportMapEntry(nameof(UnitsReturnedNotInvoiced), MultichannelOrderManagerDatabaseConstants.Columns.RCOMMIT),
                new WhippetDataRowImportMapEntry(nameof(CanBuyItem), MultichannelOrderManagerDatabaseConstants.Columns.CANBUYITEM),
                new WhippetDataRowImportMapEntry(nameof(CountyNonTaxable), MultichannelOrderManagerDatabaseConstants.Columns.C_NONTAX),
                new WhippetDataRowImportMapEntry(nameof(TaxClass_C), MultichannelOrderManagerDatabaseConstants.Columns.CTAXCLASS),
                new WhippetDataRowImportMapEntry(nameof(CityNonTaxable), MultichannelOrderManagerDatabaseConstants.Columns.I_NONTAX),
                new WhippetDataRowImportMapEntry(nameof(DropShippedUnitsOnOrder), MultichannelOrderManagerDatabaseConstants.Columns.DONORDER),
                new WhippetDataRowImportMapEntry(nameof(DropShippedUnitsOnBackOrder), MultichannelOrderManagerDatabaseConstants.Columns.DBOUNITS),
                new WhippetDataRowImportMapEntry(nameof(NeedsCustomization), MultichannelOrderManagerDatabaseConstants.Columns.NEEDCUSTOM),
                new WhippetDataRowImportMapEntry(nameof(CustomText), MultichannelOrderManagerDatabaseConstants.Columns.CUSTOMTEXT),
                new WhippetDataRowImportMapEntry(nameof(ShippingPreference), MultichannelOrderManagerDatabaseConstants.Columns.PREFSHIP),
                new WhippetDataRowImportMapEntry(nameof(AdvancedSearch_1), MultichannelOrderManagerDatabaseConstants.Columns.ADVANCED1),
                new WhippetDataRowImportMapEntry(nameof(AdvancedSearch_2), MultichannelOrderManagerDatabaseConstants.Columns.ADVANCED2),
                new WhippetDataRowImportMapEntry(nameof(AdvancedSearch_3), MultichannelOrderManagerDatabaseConstants.Columns.ADVANCED3),
                new WhippetDataRowImportMapEntry(nameof(AdvancedSearch_4), MultichannelOrderManagerDatabaseConstants.Columns.ADVANCED4),
                new WhippetDataRowImportMapEntry(nameof(Picture), MultichannelOrderManagerDatabaseConstants.Columns.PICTURE),
                new WhippetDataRowImportMapEntry(nameof(ClubProduct), MultichannelOrderManagerDatabaseConstants.Columns.CLUBPROD),
                new WhippetDataRowImportMapEntry(nameof(ClubCode), MultichannelOrderManagerDatabaseConstants.Columns.CLUB_CODE),
                new WhippetDataRowImportMapEntry(nameof(Oversized_Extended2), MultichannelOrderManagerDatabaseConstants.Columns.OVERSIZE3),
                new WhippetDataRowImportMapEntry(nameof(Auction), MultichannelOrderManagerDatabaseConstants.Columns.AUCTSELL),
                new WhippetDataRowImportMapEntry(nameof(AuctionUnits), MultichannelOrderManagerDatabaseConstants.Columns.AUCTUNIT),
                new WhippetDataRowImportMapEntry(nameof(BoxLength), MultichannelOrderManagerDatabaseConstants.Columns.BLENGTH),
                new WhippetDataRowImportMapEntry(nameof(BoxHeight), MultichannelOrderManagerDatabaseConstants.Columns.BHEIGHT),
                new WhippetDataRowImportMapEntry(nameof(BoxWidth), MultichannelOrderManagerDatabaseConstants.Columns.BWIDTH),
                new WhippetDataRowImportMapEntry(nameof(StockID), MultichannelOrderManagerDatabaseConstants.Columns.STOCK_ID),
                new WhippetDataRowImportMapEntry(nameof(AheadBackOrder), MultichannelOrderManagerDatabaseConstants.Columns.BO_AHEAD),
                new WhippetDataRowImportMapEntry(nameof(HideItem), MultichannelOrderManagerDatabaseConstants.Columns.HIDE_ITEM),
                new WhippetDataRowImportMapEntry(nameof(MaximumDiscount), MultichannelOrderManagerDatabaseConstants.Columns.MAXDSCT),
                new WhippetDataRowImportMapEntry(nameof(MinimumMarkupPercent), MultichannelOrderManagerDatabaseConstants.Columns.MIN_MKUP_D),
                new WhippetDataRowImportMapEntry(nameof(MinimumMarkupAmount), MultichannelOrderManagerDatabaseConstants.Columns.MIN_MKUP_P),
                new WhippetDataRowImportMapEntry(nameof(MinimumPrice), MultichannelOrderManagerDatabaseConstants.Columns.MIN_PRICE),
                new WhippetDataRowImportMapEntry(nameof(NoDiscounts), MultichannelOrderManagerDatabaseConstants.Columns.NODSCT),
                new WhippetDataRowImportMapEntry(nameof(NoReturns), MultichannelOrderManagerDatabaseConstants.Columns.NORETURN),
                new WhippetDataRowImportMapEntry(nameof(IgnorePrintStockIDLabel), MultichannelOrderManagerDatabaseConstants.Columns.PRINTSTKID),
                new WhippetDataRowImportMapEntry(nameof(ReturnItemSku), MultichannelOrderManagerDatabaseConstants.Columns.RETITEM),
                new WhippetDataRowImportMapEntry(nameof(ShippingChargesExempt), MultichannelOrderManagerDatabaseConstants.Columns.SHIPEXEMPT),
                new WhippetDataRowImportMapEntry(nameof(SiteLINK_Image1), MultichannelOrderManagerDatabaseConstants.Columns.SL_IMAGE1),
                new WhippetDataRowImportMapEntry(nameof(SiteLINK_Image2), MultichannelOrderManagerDatabaseConstants.Columns.SL_IMAGE2),
                new WhippetDataRowImportMapEntry(nameof(SiteLINK_Image3), MultichannelOrderManagerDatabaseConstants.Columns.SL_IMAGE3),
                new WhippetDataRowImportMapEntry(nameof(SiteLINK_Image4), MultichannelOrderManagerDatabaseConstants.Columns.SL_IMAGE4),
                new WhippetDataRowImportMapEntry(nameof(SiteLINK_Image5), MultichannelOrderManagerDatabaseConstants.Columns.SL_IMAGE5),
                new WhippetDataRowImportMapEntry(nameof(SiteLINK_Image6), MultichannelOrderManagerDatabaseConstants.Columns.SL_IMAGE6),
                new WhippetDataRowImportMapEntry(nameof(SiteLINK_Image7), MultichannelOrderManagerDatabaseConstants.Columns.SL_IMAGE7),
                new WhippetDataRowImportMapEntry(nameof(SiteLINK_Image8), MultichannelOrderManagerDatabaseConstants.Columns.SL_IMAGE8),
                new WhippetDataRowImportMapEntry(nameof(ThresholdType), MultichannelOrderManagerDatabaseConstants.Columns.THRESHTYPE),
                new WhippetDataRowImportMapEntry(nameof(NumberOfBoxes), MultichannelOrderManagerDatabaseConstants.Columns.NUM_BOXES),
                new WhippetDataRowImportMapEntry(nameof(ProductManufacturingModuleRequired), MultichannelOrderManagerDatabaseConstants.Columns.PMMPROD),
                new WhippetDataRowImportMapEntry(nameof(PackingInvoiceText), MultichannelOrderManagerDatabaseConstants.Columns.PMMTEXT),
                new WhippetDataRowImportMapEntry(nameof(ProductAttributesEnabled), MultichannelOrderManagerDatabaseConstants.Columns.ATTRIBS),
                new WhippetDataRowImportMapEntry(nameof(ProductDisassemblySetting), MultichannelOrderManagerDatabaseConstants.Columns.PMM_BREAK),
                new WhippetDataRowImportMapEntry(nameof(ProductAvailability), MultichannelOrderManagerDatabaseConstants.Columns.PRODAVAIL),
                new WhippetDataRowImportMapEntry(nameof(MetaTitle), MultichannelOrderManagerDatabaseConstants.Columns.META_TITLE),
                new WhippetDataRowImportMapEntry(nameof(CannotOrder), MultichannelOrderManagerDatabaseConstants.Columns.NO_ORDER),
                new WhippetDataRowImportMapEntry(nameof(UnitOfMeasure), MultichannelOrderManagerDatabaseConstants.Columns.UOM),
                new WhippetDataRowImportMapEntry(nameof(ProductManufacturing), MultichannelOrderManagerDatabaseConstants.Columns.PMM_MAKE),
                new WhippetDataRowImportMapEntry(nameof(PreManufacturingUnits), MultichannelOrderManagerDatabaseConstants.Columns.PMUNITS),
                new WhippetDataRowImportMapEntry(nameof(Condition), MultichannelOrderManagerDatabaseConstants.Columns.CONDITION),
                new WhippetDataRowImportMapEntry(nameof(Manufacturer), MultichannelOrderManagerDatabaseConstants.Columns.MANUFACTUR),
                new WhippetDataRowImportMapEntry(nameof(IsGiftCard), MultichannelOrderManagerDatabaseConstants.Columns.GIFTCARD),
                new WhippetDataRowImportMapEntry(nameof(GiftCardType), MultichannelOrderManagerDatabaseConstants.Columns.CARDTYPE),
                new WhippetDataRowImportMapEntry(nameof(Hazardous), MultichannelOrderManagerDatabaseConstants.Columns.HAZORDOUS),
                new WhippetDataRowImportMapEntry(nameof(Handling), MultichannelOrderManagerDatabaseConstants.Columns.HANDLING),
                new WhippetDataRowImportMapEntry(nameof(ProductUrl), MultichannelOrderManagerDatabaseConstants.Columns.PRODURL),
                new WhippetDataRowImportMapEntry(nameof(DryIceRequired), MultichannelOrderManagerDatabaseConstants.Columns.DRYICE),
                new WhippetDataRowImportMapEntry(nameof(DryIceWeight), MultichannelOrderManagerDatabaseConstants.Columns.DRYICEWGHT),
                new WhippetDataRowImportMapEntry(nameof(FulfilledByAmazonUnits), MultichannelOrderManagerDatabaseConstants.Columns.FBAUNITS),
                new WhippetDataRowImportMapEntry(nameof(Commodity), MultichannelOrderManagerDatabaseConstants.Columns.COMMODITY),
                new WhippetDataRowImportMapEntry(nameof(ContainsAlcohol), MultichannelOrderManagerDatabaseConstants.Columns.ALCOHOL),
                new WhippetDataRowImportMapEntry(nameof(ContainsLithiumBatteries), MultichannelOrderManagerDatabaseConstants.Columns.LITHUIUM),
                new WhippetDataRowImportMapEntry(nameof(LookupBy), MultichannelOrderManagerDatabaseConstants.Columns.LU_BY),
                new WhippetDataRowImportMapEntry(nameof(LookupOn), MultichannelOrderManagerDatabaseConstants.Columns.LU_ON),
                new WhippetDataRowImportMapEntry(nameof(DownloadProductUrl), MultichannelOrderManagerDatabaseConstants.Columns.DOWNLOADPRD)
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

                AdvancedSearch_1 = dataRow.Field<string>(map[nameof(AdvancedSearch_1)].Column);
                AdvancedSearch_2 = dataRow.Field<string>(map[nameof(AdvancedSearch_2)].Column);
                AdvancedSearch_3 = dataRow.Field<string>(map[nameof(AdvancedSearch_3)].Column);
                AdvancedSearch_4 = dataRow.Field<string>(map[nameof(AdvancedSearch_4)].Column);
                AheadBackOrder = dataRow.Field<decimal>(map[nameof(AheadBackOrder)].Column);
                AlternateWarehousesAllowed = dataRow.Field<bool>(map[nameof(AlternateWarehousesAllowed)].Column);
                Auction = dataRow.Field<bool>(map[nameof(Auction)].Column);
                AuctionUnits = dataRow.Field<decimal>(map[nameof(AuctionUnits)].Column);
                Bin = dataRow.Field<string>(map[nameof(Bin)].Column);
                BoxHeight = dataRow.Field<decimal>(map[nameof(BoxHeight)].Column);
                BoxLength = dataRow.Field<decimal>(map[nameof(BoxLength)].Column);
                BoxWidth = dataRow.Field<decimal>(map[nameof(BoxWidth)].Column);
                BreakoutItem = dataRow.Field<bool>(map[nameof(BreakoutItem)].Column);
                CanBuyItem = dataRow.Field<bool>(map[nameof(CanBuyItem)].Column);
                CannotOrder = dataRow.Field<bool>(map[nameof(CannotOrder)].Column);
                CannotSell = dataRow.Field<bool>(map[nameof(CannotSell)].Column);
                Carrier = dataRow.Field<string>(map[nameof(Carrier)].Column);
                CityNonTaxable = dataRow.Field<bool>(map[nameof(CityNonTaxable)].Column);
                ClassificationCode = dataRow.Field<string>(map[nameof(ClassificationCode)].Column);
                ClubCode = dataRow.Field<string>(map[nameof(ClubCode)].Column);
                ClubProduct = dataRow.Field<bool>(map[nameof(ClubProduct)].Column);
                Commodity = dataRow.Field<string>(map[nameof(Commodity)].Column);
                Condition = dataRow.Field<string>(map[nameof(Condition)].Column);
                ConstructItem = dataRow.Field<bool>(map[nameof(ConstructItem)].Column);
                ContainsAlcohol = dataRow.Field<bool>(map[nameof(ContainsAlcohol)].Column);
                ContainsLithiumBatteries = dataRow.Field<bool>(map[nameof(ContainsLithiumBatteries)].Column);
                CostOfGoodsSoldDepartment = dataRow.Field<string>(map[nameof(CostOfGoodsSoldDepartment)].Column);
                CountyNonTaxable = dataRow.Field<bool>(map[nameof(CountyNonTaxable)].Column);
                CurrentSupplier = dataRow.Field<int>(map[nameof(CurrentSupplier)].Column);
                CustomText = dataRow.Field<string>(map[nameof(CustomText)].Column);
                Delivered = dataRow.Field<bool>(map[nameof(Delivered)].Column);
                DeliveredTotal = dataRow.Field<decimal>(map[nameof(DeliveredTotal)].Column);
                DeliveredUnits = dataRow.Field<decimal>(map[nameof(DeliveredUnits)].Column);
                DeliveryDate = ToNullableInstant(dataRow.Field<DateTime?>(map[nameof(DeliveryDate)].Column));
                DescriptionLineOne = dataRow.Field<string>(map[nameof(DescriptionLineOne)].Column);
                DescriptionLineTwo = dataRow.Field<string>(map[nameof(DescriptionLineTwo)].Column);
                Discontinue = dataRow.Field<bool>(map[nameof(Discontinue)].Column);
                Discontinued = dataRow.Field<bool>(map[nameof(Discontinued)].Column);
                Distributer = dataRow.Field<string>(map[nameof(Distributer)].Column);
                DistributerStockNumber = dataRow.Field<string>(map[nameof(DistributerStockNumber)].Column);
                DownloadProductUrl = dataRow.Field<string>(map[nameof(DownloadProductUrl)].Column);
                DropMethod = dataRow.Field<char>(map[nameof(DropMethod)].Column);
                DropShippedUnitsOnBackOrder = dataRow.Field<decimal>(map[nameof(DropShippedUnitsOnBackOrder)].Column);
                DropShippedUnitsOnOrder = dataRow.Field<decimal>(map[nameof(DropShippedUnitsOnOrder)].Column);
                DryIceRequired = dataRow.Field<bool>(map[nameof(DryIceRequired)].Column);
                DryIceWeight = dataRow.Field<decimal>(map[nameof(DryIceWeight)].Column);
                Extra = dataRow.Field<string>(map[nameof(Extra)].Column);
                FlatCommissionPerUnitBase = dataRow.Field<decimal>(map[nameof(FlatCommissionPerUnitBase)].Column);
                FractionalQuantities = dataRow.Field<bool>(map[nameof(FractionalQuantities)].Column);
                FulfilledByAmazonUnits = dataRow.Field<int>(map[nameof(FulfilledByAmazonUnits)].Column);
                GiftCardType = dataRow.Field<char>(map[nameof(GiftCardType)].Column);
                GiftCertificate = dataRow.Field<bool>(map[nameof(GiftCertificate)].Column);
                GrossCommissionBase = dataRow.Field<decimal>(map[nameof(GrossCommissionBase)].Column);
                Handling = dataRow.Field<string>(map[nameof(Handling)].Column);
                HasSerialNumbers = dataRow.Field<bool>(map[nameof(HasSerialNumbers)].Column);
                Hazardous = dataRow.Field<bool>(map[nameof(Hazardous)].Column);
                HideItem = dataRow.Field<bool>(map[nameof(HideItem)].Column);
                IgnorePrintStockIDLabel = dataRow.Field<bool>(map[nameof(IgnorePrintStockIDLabel)].Column);
                InternalExternal = dataRow.Field<bool>(map[nameof(InternalExternal)].Column);
                ISBN = dataRow.Field<string>(map[nameof(ISBN)].Column);
                IsDropshipped = dataRow.Field<bool>(map[nameof(IsDropshipped)].Column);
                IsGiftCard = dataRow.Field<bool>(map[nameof(IsGiftCard)].Column);
                IsService = dataRow.Field<bool>(map[nameof(IsService)].Column);
                IsSubscription = dataRow.Field<bool>(map[nameof(IsSubscription)].Column);
                Kit_Break = dataRow.Field<char>(map[nameof(Kit_Break)].Column);
                Kit_Make = dataRow.Field<char>(map[nameof(Kit_Make)].Column);
                LastPurchaseDate = ToNullableInstant(dataRow.Field<DateTime?>(map[nameof(LastPurchaseDate)].Column));
                LastPurchaseQuantity = dataRow.Field<decimal>(map[nameof(LastPurchaseQuantity)].Column);
                LookupBy = dataRow.Field<string>(map[nameof(LookupBy)].Column);
                LookupOn = ToNullableInstant(dataRow.Field<DateTime?>(map[nameof(LookupOn)].Column));
                Low = dataRow.Field<decimal>(map[nameof(Low)].Column);
                Manufacturer = dataRow.Field<string>(map[nameof(Manufacturer)].Column);
                MaximumDiscount = dataRow.Field<decimal>(map[nameof(MaximumDiscount)].Column);
                MetaTitle = dataRow.Field<string>(map[nameof(MetaTitle)].Column);
                MinimumMarkupAmount = dataRow.Field<decimal>(map[nameof(MinimumMarkupAmount)].Column);
                MinimumMarkupPercent = dataRow.Field<decimal>(map[nameof(MinimumMarkupPercent)].Column);
                MinimumPrice = dataRow.Field<decimal>(map[nameof(MinimumPrice)].Column);
                MomObjectID = dataRow.Field<long>(map[nameof(StockID)].Column);
                NationalTaxExempt = dataRow.Field<bool>(map[nameof(NationalTaxExempt)].Column);
                NeedsCustomization = dataRow.Field<bool>(map[nameof(NeedsCustomization)].Column);
                NetCommissionBase = dataRow.Field<decimal>(map[nameof(NetCommissionBase)].Column);
                NextSerialNumber = dataRow.Field<string>(map[nameof(NextSerialNumber)].Column);
                NoDiscounts = dataRow.Field<bool>(map[nameof(NoDiscounts)].Column);
                NonTaxable = dataRow.Field<bool>(map[nameof(NonTaxable)].Column);
                NoReturns = dataRow.Field<bool>(map[nameof(NoReturns)].Column);
                Notation = dataRow.Field<string>(map[nameof(Notation)].Column);
                NoticeWhen = dataRow.Field<char>(map[nameof(NoticeWhen)].Column);
                Number = dataRow.Field<string>(map[nameof(Number)].Column);
                NumberOfBoxes = dataRow.Field<int>(map[nameof(NumberOfBoxes)].Column);
                Other_1 = dataRow.Field<string>(map[nameof(Other_1)].Column);
                Other_2 = dataRow.Field<int>(map[nameof(Other_2)].Column);
                Oversized = dataRow.Field<bool>(map[nameof(Oversized)].Column);
                Oversized_Extended = dataRow.Field<bool>(map[nameof(Oversized_Extended)].Column);
                Oversized_Extended2 = dataRow.Field<bool>(map[nameof(Oversized_Extended2)].Column);
                PackingInvoiceText = dataRow.Field<string>(map[nameof(PackingInvoiceText)].Column);
                Picture = dataRow.Field<string>(map[nameof(Picture)].Column);
                PointsNeeded = dataRow.Field<int>(map[nameof(PointsNeeded)].Column);
                PointsReceived = dataRow.Field<int>(map[nameof(PointsReceived)].Column);
                PreManufacturingUnits = dataRow.Field<decimal>(map[nameof(PreManufacturingUnits)].Column);
                ProductAttributesEnabled = dataRow.Field<bool>(map[nameof(ProductAttributesEnabled)].Column);
                ProductAvailability = dataRow.Field<string>(map[nameof(ProductAvailability)].Column);
                ProductDisassemblySetting = dataRow.Field<char>(map[nameof(ProductDisassemblySetting)].Column);
                ProductManufacturing = dataRow.Field<char>(map[nameof(ProductManufacturing)].Column);
                ProductManufacturingModuleRequired = dataRow.Field<bool>(map[nameof(ProductManufacturingModuleRequired)].Column);
                ProductShipsInOwnBox = dataRow.Field<bool>(map[nameof(ProductShipsInOwnBox)].Column);
                ProductUrl = dataRow.Field<string>(map[nameof(ProductUrl)].Column);
                PublicationCode = dataRow.Field<string>(map[nameof(PublicationCode)].Column);
                PurchaseOrderQuantity = dataRow.Field<decimal>(map[nameof(PurchaseOrderQuantity)].Column);
                Received = dataRow.Field<bool>(map[nameof(Received)].Column);
                ReorderPrice = dataRow.Field<decimal>(map[nameof(ReorderPrice)].Column);
                ReorderQuantity = dataRow.Field<decimal>(map[nameof(ReorderQuantity)].Column);
                RequiresWeighing = dataRow.Field<bool>(map[nameof(RequiresWeighing)].Column);
                RetailPrice = dataRow.Field<decimal>(map[nameof(RetailPrice)].Column);
                ReturnItemSku = dataRow.Field<string>(map[nameof(ReturnItemSku)].Column);
                ReturnsDepartment = dataRow.Field<string>(map[nameof(ReturnsDepartment)].Column);
                RoyaltiesSupplierCode = dataRow.Field<string>(map[nameof(RoyaltiesSupplierCode)].Column);
                Royalty = dataRow.Field<decimal>(map[nameof(Royalty)].Column);
                RoyaltyFlatBase = dataRow.Field<decimal>(map[nameof(RoyaltyFlatBase)].Column);
                RoyaltyGrossBase = dataRow.Field<decimal>(map[nameof(RoyaltyGrossBase)].Column);
                RoyaltyNetBase = dataRow.Field<decimal>(map[nameof(RoyaltyNetBase)].Column);
                SalesDepartment = dataRow.Field<string>(map[nameof(SalesDepartment)].Column);
                SendNotice = dataRow.Field<string>(map[nameof(SendNotice)].Column);
                SerialSku = dataRow.Field<string>(map[nameof(SerialSku)].Column);
                ShippingCharge = dataRow.Field<decimal>(map[nameof(ShippingCharge)].Column);
                ShippingChargesExempt = dataRow.Field<bool>(map[nameof(ShippingChargesExempt)].Column);
                ShippingPreference = dataRow.Field<string>(map[nameof(ShippingPreference)].Column);
                SingleBin = dataRow.Field<bool>(map[nameof(SingleBin)].Column);
                SiteLINK_CPrice = dataRow.Field<decimal>(map[nameof(SiteLINK_CPrice)].Column);
                SiteLINK_CprMpt = dataRow.Field<string>(map[nameof(SiteLINK_CprMpt)].Column);
                SiteLINK_CSMSG = dataRow.Field<string>(map[nameof(SiteLINK_CSMSG)].Column);
                SiteLINK_CsProduct = dataRow.Field<string>(map[nameof(SiteLINK_CsProduct)].Column);
                SiteLINK_Custom = dataRow.Field<bool>(map[nameof(SiteLINK_Custom)].Column);
                SiteLINK_Department = dataRow.Field<string>(map[nameof(SiteLINK_Department)].Column);
                SiteLINK_Description = dataRow.Field<string>(map[nameof(SiteLINK_Description)].Column);
                SiteLINK_Image = dataRow.Field<string>(map[nameof(SiteLINK_Image)].Column);
                SiteLINK_Image1 = dataRow.Field<string>(map[nameof(SiteLINK_Image1)].Column);
                SiteLINK_Image2 = dataRow.Field<string>(map[nameof(SiteLINK_Image2)].Column);
                SiteLINK_Image3 = dataRow.Field<string>(map[nameof(SiteLINK_Image3)].Column);
                SiteLINK_Image4 = dataRow.Field<string>(map[nameof(SiteLINK_Image4)].Column);
                SiteLINK_Image5 = dataRow.Field<string>(map[nameof(SiteLINK_Image5)].Column);
                SiteLINK_Image6 = dataRow.Field<string>(map[nameof(SiteLINK_Image6)].Column);
                SiteLINK_Image7 = dataRow.Field<string>(map[nameof(SiteLINK_Image7)].Column);
                SiteLINK_Image8 = dataRow.Field<string>(map[nameof(SiteLINK_Image8)].Column);
                SiteLINK_Sell = dataRow.Field<bool>(map[nameof(SiteLINK_Sell)].Column);
                SiteLINK_SubDepartment = dataRow.Field<string>(map[nameof(SiteLINK_SubDepartment)].Column);
                SiteLINK_Thumbnail = dataRow.Field<string>(map[nameof(SiteLINK_Thumbnail)].Column);
                SiteLINK_UsMessage = dataRow.Field<string>(map[nameof(SiteLINK_UsMessage)].Column);
                SiteLINK_UsProduct = dataRow.Field<string>(map[nameof(SiteLINK_UsProduct)].Column);
                Size_Color = dataRow.Field<bool>(map[nameof(Size_Color)].Column);
                Sold = dataRow.Field<decimal>(map[nameof(Sold)].Column);
                StockID = dataRow.Field<long>(map[nameof(StockID)].Column);
                SubscriptionInvoiceExempt = dataRow.Field<bool>(map[nameof(SubscriptionInvoiceExempt)].Column);
                SubscriptionIssueCount = dataRow.Field<int>(map[nameof(SubscriptionIssueCount)].Column);
                Substitute = dataRow.Field<string>(map[nameof(Substitute)].Column);
                TaxClass = dataRow.Field<char>(map[nameof(TaxClass)].Column);
                TaxClass_C = dataRow.Field<char>(map[nameof(TaxClass_C)].Column);
                TaxClass_I = dataRow.Field<char>(map[nameof(TaxClass_I)].Column);
                TaxClass_N = dataRow.Field<char>(map[nameof(TaxClass_N)].Column);
                TaxClass_S = dataRow.Field<char>(map[nameof(TaxClass_S)].Column);
                ThresholdType = Enum.Parse<MultichannelOrderManagerPriceThresholdType>(Convert.ToString(dataRow.Field<int>(map[nameof(ThresholdType)].Column)));
                UnitCost = dataRow.Field<decimal>(map[nameof(UnitCost)].Column);
                UnitOfMeasure = dataRow.Field<string>(map[nameof(UnitOfMeasure)].Column);
                Units = dataRow.Field<decimal>(map[nameof(Units)].Column);
                UnitsBackordered = dataRow.Field<decimal>(map[nameof(UnitsBackordered)].Column);
                UnitsCommitted = dataRow.Field<decimal>(map[nameof(UnitsCommitted)].Column);
                UnitsInBox = dataRow.Field<decimal>(map[nameof(UnitsInBox)].Column);
                UnitsOnOrder = dataRow.Field<decimal>(map[nameof(UnitsOnOrder)].Column);
                UnitsReturnedNotInvoiced = dataRow.Field<decimal>(map[nameof(UnitsReturnedNotInvoiced)].Column);
                UnitWeight = dataRow.Field<decimal>(map[nameof(UnitWeight)].Column);
                UPC = dataRow.Field<string>(map[nameof(UPC)].Column);
                WarehousePreference = dataRow.Field<string>(map[nameof(WarehousePreference)].Column);
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

            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Number)].Column, false, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(DescriptionLineOne)].Column, false, 60));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(DescriptionLineTwo)].Column, false, 60));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(Units)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(Low)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(UnitWeight)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(UnitCost)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(RetailPrice)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(UnitsBackordered)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(UnitsOnOrder)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(UnitsCommitted)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(Sold)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Received)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(ConstructItem)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(BreakoutItem)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Extra)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsDropshipped)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Carrier)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(PurchaseOrderQuantity)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(ReorderPrice)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(ReorderQuantity)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ClassificationCode)].Column, false, 30));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(DeliveryDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Delivered)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(DeliveredUnits)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(DeliveredTotal)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Bin)].Column, false, 16));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Oversized)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Notation)].Column, false, 60));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(InternalExternal)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(NonTaxable)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(ShippingCharge)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(CurrentSupplier)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Distributer)].Column, false, 6));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(DistributerStockNumber)].Column, false, 30));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsService)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(ProductShipsInOwnBox)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(TaxClass)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(UPC)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(HasSerialNumbers)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(NextSerialNumber)].Column, false, 15));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Discontinue)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(RequiresWeighing)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(GrossCommissionBase)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(NetCommissionBase)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(FlatCommissionPerUnitBase)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsSubscription)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(PublicationCode)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(SubscriptionIssueCount)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(SubscriptionInvoiceExempt)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(Royalty)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Discontinued)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Other_1)].Column, false, 2));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(Other_2)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SerialSku)].Column, false, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(UnitsInBox)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LastPurchaseDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(LastPurchaseQuantity)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Size_Color)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(FractionalQuantities)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(SiteLINK_Sell)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SiteLINK_Description)].Column, false, 120));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SiteLINK_Department)].Column, false, 50));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SiteLINK_SubDepartment)].Column, false, 50));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SiteLINK_CSMSG)].Column, false, 70));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SiteLINK_CsProduct)].Column, false, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SiteLINK_Image)].Column, false, 50));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(CannotSell)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(TaxClass_N)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(TaxClass_S)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(NationalTaxExempt)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SalesDepartment)].Column, false, 2));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(RoyaltiesSupplierCode)].Column, false, 6));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(RoyaltyNetBase)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(RoyaltyGrossBase)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(RoyaltyFlatBase)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(SiteLINK_Custom)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SiteLINK_CprPayment)].Column, false, 40));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(SiteLINK_CPrice)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SiteLINK_UsProduct)].Column, false, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SiteLINK_UsMessage)].Column, false, 70));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SiteLINK_Thumbnail)].Column, false, 50));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SendNotice)].Column, false, 6));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(NoticeWhen)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(GiftCertificate)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(PointsReceived)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(PointsNeeded)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(Kit_Make)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(Kit_Break)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ISBN)].Column, false, 15));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ReturnsDepartment)].Column, false, 2));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CostOfGoodsSoldDepartment)].Column, false, 2));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Oversized_Extended)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Substitute)].Column, false, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(WarehousePreference)].Column, false, 6));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(AlternateWarehousesAllowed)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(SingleBin)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(UnitsReturnedNotInvoiced)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(CanBuyItem)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(CountyNonTaxable)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(TaxClass_C)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(CityNonTaxable)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(TaxClass_I)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(DropShippedUnitsOnOrder)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(DropShippedUnitsOnBackOrder)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(NeedsCustomization)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CustomText)].Column, false, 40));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ShippingPreference)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(AdvancedSearch_1)].Column, false, 30));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(AdvancedSearch_2)].Column, false, 30));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(AdvancedSearch_3)].Column, false, 30));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(AdvancedSearch_4)].Column, false, 30));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Picture)].Column, false, 100));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(ClubProduct)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ClubCode)].Column, false, 6));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Oversized_Extended2)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Auction)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(AuctionUnits)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(BoxLength)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(BoxHeight)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(BoxWidth)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<long>(map[nameof(StockID)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(AheadBackOrder)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(HideItem)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(MaximumDiscount)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(MinimumMarkupPercent)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(MinimumMarkupAmount)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(MinimumPrice)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(NoDiscounts)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(NoReturns)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IgnorePrintStockIDLabel)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ReturnItemSku)].Column, false, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(ShippingChargesExempt)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SiteLINK_Image1)].Column, false, 100));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SiteLINK_Image2)].Column, false, 100));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SiteLINK_Image3)].Column, false, 100));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SiteLINK_Image4)].Column, false, 100));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SiteLINK_Image5)].Column, false, 100));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SiteLINK_Image6)].Column, false, 100));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SiteLINK_Image7)].Column, false, 100));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SiteLINK_Image8)].Column, false, 100));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(ThresholdType)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(NumberOfBoxes)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(ProductManufacturingModuleRequired)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(PackingInvoiceText)].Column, false, 100));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(ProductAttributesEnabled)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(ProductDisassemblySetting)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ProductAvailability)].Column, false, 40));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(MetaTitle)].Column, false, 60));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(CannotOrder)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(UnitOfMeasure)].Column, false, 6));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(ProductManufacturing)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(PreManufacturingUnits)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Condition)].Column, false, 15));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Manufacturer)].Column, false, 50));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsGiftCard)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(GiftCardType)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Hazardous)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Handling)].Column, false, 2));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ProductUrl)].Column, false, 100));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(DryIceRequired)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(DryIceWeight)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(FulfilledByAmazonUnits)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Commodity)].Column, false, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(ContainsAlcohol)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(ContainsLithiumBatteries)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(LookupBy)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LookupOn)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(DownloadProductUrl)].Column, false, 100));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(DropMethod)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SiteLINK_CprMpt)].Column, false, 40));

            table.PrimaryKey = new[] { table.Columns[map[nameof(StockID)].Column] };

            return table;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IMultichannelOrderManagerStockItem);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerStockItem obj)
        {
            return (obj != null) && Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerStockItem x, IMultichannelOrderManagerStockItem y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals =
                    String.Equals(x.AdvancedSearch_1, y.AdvancedSearch_1, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.AdvancedSearch_2, y.AdvancedSearch_2, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.AdvancedSearch_3, y.AdvancedSearch_3, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.AdvancedSearch_4, y.AdvancedSearch_4, StringComparison.InvariantCultureIgnoreCase)
                        && x.AheadBackOrder == y.AheadBackOrder
                        && x.AlternateWarehousesAllowed == y.AlternateWarehousesAllowed
                        && x.Auction == y.Auction
                        && x.AuctionUnits == y.AuctionUnits
                        && String.Equals(x.Bin, y.Bin, StringComparison.InvariantCultureIgnoreCase)
                        && x.BoxHeight == y.BoxHeight
                        && x.BoxLength == y.BoxLength
                        && x.BoxWidth == y.BoxWidth
                        && x.BreakoutItem == y.BreakoutItem
                        && x.CanBuyItem == y.CanBuyItem
                        && x.CannotOrder == y.CannotOrder
                        && x.CannotSell == y.CannotSell
                        && String.Equals(x.Carrier, y.Carrier, StringComparison.InvariantCultureIgnoreCase)
                        && x.CityNonTaxable == y.CityNonTaxable
                        && String.Equals(x.ClassificationCode, y.ClassificationCode, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.ClubCode, y.ClubCode, StringComparison.InvariantCultureIgnoreCase)
                        && x.ClubProduct == y.ClubProduct
                        && String.Equals(x.Commodity, y.Commodity, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.Condition, y.Condition, StringComparison.InvariantCultureIgnoreCase)
                        && x.ConstructItem == y.ConstructItem
                        && x.ContainsAlcohol == y.ContainsAlcohol
                        && x.ContainsLithiumBatteries == y.ContainsLithiumBatteries
                        && String.Equals(x.CostOfGoodsSoldDepartment, y.CostOfGoodsSoldDepartment, StringComparison.InvariantCultureIgnoreCase)
                        && x.CountyNonTaxable == y.CountyNonTaxable
                        && x.CurrentSupplier == y.CurrentSupplier
                        && String.Equals(x.CustomText, y.CustomText, StringComparison.InvariantCultureIgnoreCase)
                        && x.Delivered == y.Delivered
                        && x.DeliveredTotal == y.DeliveredTotal
                        && x.DeliveredUnits == y.DeliveredUnits
                        && x.DeliveryDate.GetValueOrDefault() == y.DeliveryDate.GetValueOrDefault()
                        && String.Equals(x.DescriptionLineOne, y.DescriptionLineOne, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.DescriptionLineTwo, y.DescriptionLineTwo, StringComparison.InvariantCultureIgnoreCase)
                        && x.Discontinue == y.Discontinue
                        && x.Discontinued == y.Discontinued
                        && String.Equals(x.Distributer, y.Distributer, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.DistributerStockNumber, y.DistributerStockNumber, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.DownloadProductUrl, y.DownloadProductUrl, StringComparison.InvariantCultureIgnoreCase)
                        && x.DropMethod == y.DropMethod
                        && x.DropShippedUnitsOnBackOrder == y.DropShippedUnitsOnBackOrder
                        && x.DropShippedUnitsOnOrder == y.DropShippedUnitsOnOrder
                        && x.DryIceRequired == y.DryIceRequired
                        && x.DryIceWeight == y.DryIceWeight
                        && String.Equals(x.Extra, y.Extra, StringComparison.InvariantCultureIgnoreCase)
                        && x.FlatCommissionPerUnitBase == y.FlatCommissionPerUnitBase
                        && x.FractionalQuantities == y.FractionalQuantities
                        && x.FulfilledByAmazonUnits == y.FulfilledByAmazonUnits
                        && x.GiftCardType == y.GiftCardType
                        && x.GiftCertificate == y.GiftCertificate
                        && x.GrossCommissionBase == y.GrossCommissionBase
                        && String.Equals(x.Handling, y.Handling, StringComparison.InvariantCultureIgnoreCase)
                        && x.HasSerialNumbers == y.HasSerialNumbers
                        && x.Hazardous == y.Hazardous
                        && x.HideItem == y.HideItem
                        && x.IgnorePrintStockIDLabel == y.IgnorePrintStockIDLabel
                        && x.InternalExternal == y.InternalExternal
                        && String.Equals(x.ISBN, y.ISBN, StringComparison.InvariantCultureIgnoreCase)
                        && x.IsDropshipped == y.IsDropshipped
                        && x.IsGiftCard == y.IsGiftCard
                        && x.IsService == y.IsService
                        && x.IsSubscription == y.IsSubscription
                        && x.Kit_Break == y.Kit_Break
                        && x.Kit_Make == y.Kit_Make
                        && x.LastPurchaseDate.GetValueOrDefault() == y.LastPurchaseDate.GetValueOrDefault()
                        && x.LastPurchaseQuantity == y.LastPurchaseQuantity
                        && String.Equals(x.LookupBy, y.LookupBy, StringComparison.InvariantCultureIgnoreCase)
                        && x.LookupOn.GetValueOrDefault() == y.LookupOn.GetValueOrDefault()
                        && x.Low == y.Low
                        && String.Equals(x.Manufacturer, y.Manufacturer, StringComparison.InvariantCultureIgnoreCase)
                        && x.MaximumDiscount == y.MaximumDiscount
                        && String.Equals(x.MetaTitle, y.MetaTitle, StringComparison.InvariantCultureIgnoreCase)
                        && x.MinimumMarkupAmount == y.MinimumMarkupAmount
                        && x.MinimumMarkupPercent == y.MinimumMarkupPercent
                        && x.MinimumPrice == y.MinimumPrice
                        && x.NationalTaxExempt == y.NationalTaxExempt
                        && x.NeedsCustomization == y.NeedsCustomization
                        && x.NetCommissionBase == y.NetCommissionBase
                        && String.Equals(x.NextSerialNumber, y.NextSerialNumber, StringComparison.InvariantCultureIgnoreCase)
                        && x.NoDiscounts == y.NoDiscounts
                        && x.NonTaxable == y.NonTaxable
                        && x.NoReturns == y.NoReturns
                        && String.Equals(x.Notation, y.Notation, StringComparison.InvariantCultureIgnoreCase)
                        && x.NoticeWhen == y.NoticeWhen
                        && String.Equals(x.Number, y.Number, StringComparison.InvariantCultureIgnoreCase)
                        && x.NumberOfBoxes == y.NumberOfBoxes
                        && String.Equals(x.Other_1, y.Other_1, StringComparison.InvariantCultureIgnoreCase)
                        && x.Other_2 == y.Other_2
                        && x.Oversized == y.Oversized
                        && x.Oversized_Extended == y.Oversized_Extended
                        && x.Oversized_Extended2 == y.Oversized_Extended2
                        && String.Equals(x.PackingInvoiceText, y.PackingInvoiceText, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.Picture, y.Picture, StringComparison.InvariantCultureIgnoreCase)
                        && x.PointsNeeded == y.PointsNeeded
                        && x.PointsReceived == y.PointsReceived
                        && x.PreManufacturingUnits == y.PreManufacturingUnits
                        && x.ProductAttributesEnabled == y.ProductAttributesEnabled
                        && String.Equals(x.ProductAvailability, y.ProductAvailability, StringComparison.InvariantCultureIgnoreCase)
                        && x.ProductDisassemblySetting == y.ProductDisassemblySetting
                        && x.ProductManufacturing == y.ProductManufacturing
                        && x.ProductManufacturingModuleRequired == y.ProductManufacturingModuleRequired
                        && x.ProductShipsInOwnBox == y.ProductShipsInOwnBox
                        && String.Equals(x.ProductUrl, y.ProductUrl, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.PublicationCode, y.PublicationCode, StringComparison.InvariantCultureIgnoreCase)
                        && x.PurchaseOrderQuantity == y.PurchaseOrderQuantity
                        && x.Received == y.Received
                        && x.ReorderPrice == y.ReorderPrice
                        && x.ReorderQuantity == y.ReorderQuantity
                        && x.RequiresWeighing == y.RequiresWeighing
                        && x.RetailPrice == y.RetailPrice
                        && String.Equals(x.ReturnItemSku, y.ReturnItemSku, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.ReturnsDepartment, y.ReturnsDepartment, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.RoyaltiesSupplierCode, y.RoyaltiesSupplierCode, StringComparison.InvariantCultureIgnoreCase)
                        && x.Royalty == y.Royalty
                        && x.RoyaltyFlatBase == y.RoyaltyFlatBase
                        && x.RoyaltyGrossBase == y.RoyaltyGrossBase
                        && x.RoyaltyNetBase == y.RoyaltyNetBase
                        && String.Equals(x.SalesDepartment, y.SalesDepartment, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.SendNotice, y.SendNotice, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.SerialSku, y.SerialSku, StringComparison.InvariantCultureIgnoreCase)
                        && ((x.Server == null && y.Server == null) || (x.Server != null && x.Server.Equals(y.Server)))
                        && x.ShippingCharge == y.ShippingCharge
                        && x.ShippingChargesExempt == y.ShippingChargesExempt
                        && String.Equals(x.ShippingPreference, y.ShippingPreference, StringComparison.InvariantCultureIgnoreCase)
                        && x.SingleBin == y.SingleBin
                        && x.SiteLINK_CPrice == y.SiteLINK_CPrice
                        && String.Equals(x.SiteLINK_CprMpt, y.SiteLINK_CprMpt, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.SiteLINK_CprPayment, y.SiteLINK_CprPayment, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.SiteLINK_CSMSG, y.SiteLINK_CSMSG, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.SiteLINK_CsProduct, y.SiteLINK_CsProduct, StringComparison.InvariantCultureIgnoreCase)
                        && x.SiteLINK_Custom == y.SiteLINK_Custom
                        && String.Equals(x.SiteLINK_Department, y.SiteLINK_Department, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.SiteLINK_Description, y.SiteLINK_Description, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.SiteLINK_Image, y.SiteLINK_Image, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.SiteLINK_Image1, y.SiteLINK_Image1, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.SiteLINK_Image2, y.SiteLINK_Image2, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.SiteLINK_Image3, y.SiteLINK_Image3, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.SiteLINK_Image4, y.SiteLINK_Image4, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.SiteLINK_Image5, y.SiteLINK_Image5, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.SiteLINK_Image6, y.SiteLINK_Image6, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.SiteLINK_Image7, y.SiteLINK_Image7, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.SiteLINK_Image8, y.SiteLINK_Image8, StringComparison.InvariantCultureIgnoreCase)
                        && x.SiteLINK_Sell == y.SiteLINK_Sell
                        && String.Equals(x.SiteLINK_SubDepartment, y.SiteLINK_SubDepartment, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.SiteLINK_Thumbnail, y.SiteLINK_Thumbnail, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.SiteLINK_UsMessage, y.SiteLINK_UsMessage, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.SiteLINK_UsProduct, y.SiteLINK_UsProduct, StringComparison.InvariantCultureIgnoreCase)
                        && x.Size_Color == y.Size_Color
                        && x.Sold == y.Sold
                        && x.StockID == y.StockID
                        && x.SubscriptionInvoiceExempt == y.SubscriptionInvoiceExempt
                        && x.SubscriptionIssueCount == y.SubscriptionIssueCount
                        && String.Equals(x.Substitute, y.Substitute, StringComparison.InvariantCultureIgnoreCase)
                        && x.TaxClass == y.TaxClass
                        && x.TaxClass_C == y.TaxClass_C
                        && x.TaxClass_I == y.TaxClass_I
                        && x.TaxClass_N == y.TaxClass_N
                        && x.TaxClass_S == y.TaxClass_S
                        && x.ThresholdType == y.ThresholdType
                        && x.UnitCost == y.UnitCost
                        && String.Equals(x.UnitOfMeasure, y.UnitOfMeasure, StringComparison.InvariantCultureIgnoreCase)
                        && x.Units == y.Units
                        && x.UnitsBackordered == y.UnitsBackordered
                        && x.UnitsCommitted == y.UnitsCommitted
                        && x.UnitsOnOrder == y.UnitsOnOrder
                        && x.UnitsReturnedNotInvoiced == y.UnitsReturnedNotInvoiced
                        && x.UnitWeight == y.UnitWeight
                        && String.Equals(x.UPC, y.UPC, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.WarehousePreference, y.WarehousePreference, StringComparison.InvariantCultureIgnoreCase);
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="IMultichannelOrderManagerStockItem"/> object ot get hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(IMultichannelOrderManagerStockItem obj)
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
        /// Returns the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            if (!String.IsNullOrWhiteSpace(Number))
            {
                builder.Append('[');
                builder.Append(Number.Trim());
                builder.Append(']');
                builder.Append(' ');
            }

            if (!String.IsNullOrWhiteSpace(DescriptionLineOne) || !(String.IsNullOrWhiteSpace(DescriptionLineTwo)))
            {
                builder.Append("[");

                if (!String.IsNullOrWhiteSpace(DescriptionLineOne))
                {
                    builder.Append(DescriptionLineOne.Trim());
                    builder.Append(' ');
                }

                if (!String.IsNullOrWhiteSpace(DescriptionLineTwo))
                {
                    builder.Append(DescriptionLineTwo.Trim());
                }

                builder = new StringBuilder(builder.ToString().Trim());
                builder.Append(']');
            }

            builder.Append(" ");
            builder.Append(RetailPrice.ToString("C"));

            return builder.ToString();
        }

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be overridden.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public override string ToJson<T>()
        {
            return this.SerializeJson(this);
        }
    }
}