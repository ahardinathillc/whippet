using System;
using System.Text;
using System.Data;
using System.Collections.ObjectModel;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents a stock item supplier in the Multichannel Order Management (M.O.M.) system.
    /// </summary>
    public class MultichannelOrderManagerSupplier : MultichannelOrderManagerEntity, IWhippetEntity, IWhippetEntityExternalDataRowImportMapper, IEqualityComparer<IMultichannelOrderManagerSupplier>, IMultichannelOrderManagerEntity, IMultichannelOrderManagerSupplier, IMultichannelOrderManagerLookup
    {
        private string _code;
        private string _name;
        private string _address_l1;
        private string _address_l2;
        private string _address_l3;
        private string _phone;
        private string _fax;
        private string _account;
        private string _contact;
        private string _terms;
        private string _instruct1;
        private string _instruct2;
        private string _instruct3;
        private string _note1;
        private string _note2;
        private string _note3;
        private string _email;
        private string _country;
        private string _cardType;
        private string _zipCode;
        private string _shipVia;
        private string _emailDef;
        private string _phoneExt;
        private string _luBy;

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
                return MultichannelOrderManagerDatabaseConstants.Tables.SUPPLIER;
            }
        }

        /// <summary>
        /// Unique record identifier of the supplier.
        /// </summary>
        public virtual long SupplierID
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
        /// Indicates whether the supplier can drop-ship items.
        /// </summary>
        public virtual bool CanDropShip
        { get; set; }

        /// <summary>
        /// Discount allowed by supplier.
        /// </summary>
        public virtual decimal DiscountPercent
        { get; set; }

        /// <summary>
        /// Number of days for discount.
        /// </summary>
        public virtual int DiscountDays
        { get; set; }

        /// <summary>
        /// Number of days invoice is due.
        /// </summary>
        public virtual int DueDays
        { get; set; }

        /// <summary>
        /// Indicates whether the supplier allows terms.
        /// </summary>
        public virtual bool AllowTerms
        { get; set; }

        /// <summary>
        /// Indicates whether purchase orders are printed.
        /// </summary>
        public virtual bool PrintPurchaseOrders
        { get; set; }

        /// <summary>
        /// Indicates whether purchase orders are e-mailed.
        /// </summary>
        public virtual bool EmailPurchaseOrders
        { get; set; }

        /// <summary>
        /// Indicates whether purchase orders are faxed.
        /// </summary>
        public virtual bool FaxPurchaseOrders
        { get; set; }

        /// <summary>
        /// Specifies the payment terms.
        /// </summary>
        public virtual char PaymentTerms
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        public virtual bool LoadZones
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        public virtual decimal LeadAverage
        { get; set; }

        /// <summary>
        /// Minimum units required for the supplier.
        /// </summary>
        public virtual decimal MinimumUnits
        { get; set; }

        /// <summary>
        /// Minimum order amount required for the supplier.
        /// </summary>
        public virtual decimal MinimumAmount
        { get; set; }

        /// <summary>
        /// Indicates a minimum is required for the supplier.
        /// </summary>
        public virtual bool MinimumRequired
        { get; set; }

        /// <summary>
        /// Indicates whether the supplier code and associated purchasing levels will display during purchasing.
        /// </summary>
        public virtual bool Inactive
        { get; set; }

        /// <summary>
        /// Indicates if the landed cost adjustment will be determined by the product's value.
        /// </summary>
        public virtual bool LandedCostAdjustmentDeterminedByProductValue
        { get; set; }

        /// <summary>
        /// Indicates if the landed cost adjustment will be determined by the product's volume.
        /// </summary>
        public virtual bool LandedCostAdjustmentDeterminedByProductVolume
        { get; set; }

        /// <summary>
        /// Indicates if the landed cost adjustment will be determined by the product's weight.
        /// </summary>
        public virtual bool LandedCostAdjustmentDeterminedByProductWeight
        { get; set; }

        /// <summary>
        /// Indicates if the landed cost tax will be determined by the product's value.
        /// </summary>
        public virtual bool LandedCostTaxDerterminedByProductValue
        { get; set; }

        /// <summary>
        /// Indicates if the landed cost tax will be determined by the product's volume.
        /// </summary>
        public virtual bool LandedCostTaxDeterminedByProductVolume
        { get; set; }

        /// <summary>
        /// Indicates if the landed cost tax will be determined by the product's weight.
        /// </summary>
        public virtual bool LandedCostTaxDeterminedByProductWeight
        { get; set; }

        /// <summary>
        /// Indicates if the shipping landed cost will be determined by the product's value.
        /// </summary>
        public virtual bool ShippingLandedCostDeterminedByValue
        { get; set; }

        /// <summary>
        /// Indicates if the shipping landed cost will be determined by the product's volume.
        /// </summary>
        public virtual bool ShippingLandedCostDeterminedByVolume
        { get; set; }

        /// <summary>
        /// Indicates if the shipping landed cost will be determined by the product's weight.
        /// </summary>
        public virtual bool ShippingLandedCostDeterminedByWeight
        { get; set; }

        /// <summary>
        /// Specifies the maximum volume per shipment.
        /// </summary>
        public virtual decimal MaximumVolume
        { get; set; }

        /// <summary>
        /// Specifies the minimum volume per shipment.
        /// </summary>
        public virtual decimal MinimumVolume
        { get; set; }

        /// <summary>
        /// Specifies the minimum weight per shipment.
        /// </summary>
        public virtual decimal MinimumWeight
        { get; set; }

        /// <summary>
        /// Specifies the maximum weight per shipment.
        /// </summary>
        public virtual decimal MaximumWeight
        { get; set; }

        /// <summary>
        /// Supplier code.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        public virtual string Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = EnsureLength(value, nameof(Code));
            }
        }

        /// <summary>
        /// Supplier name.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        public virtual string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = EnsureLength(value, nameof(Name));
            }
        }

        /// <summary>
        /// First address line.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        public virtual string AddressLineOne
        {
            get
            {
                return _address_l1;
            }
            set
            {
                _address_l1 = EnsureLength(value, nameof(AddressLineOne));
            }
        }

        /// <summary>
        /// Second address line.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        public virtual string AddressLineTwo
        {
            get
            {
                return _address_l2;
            }
            set
            {
                _address_l2 = EnsureLength(value, nameof(AddressLineTwo));
            }
        }

        /// <summary>
        /// Third address line.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        public virtual string AddressLineThree
        {
            get
            {
                return _address_l3;
            }
            set
            {
                _address_l3 = EnsureLength(value, nameof(AddressLineThree));
            }
        }

        /// <summary>
        /// Contact phone number.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = EnsureLength(value, nameof(Phone));
            }
        }

        /// <summary>
        /// Contact fax number.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Fax
        {
            get
            {
                return _fax;
            }
            set
            {
                _fax = EnsureLength(value, nameof(Fax));
            }
        }

        /// <summary>
        /// Account number.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Account
        {
            get
            {
                return _account;
            }
            set
            {
                _account = EnsureLength(value, nameof(Account));
            }
        }

        /// <summary>
        /// Contact name.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Contact
        {
            get
            {
                return _contact;
            }
            set
            {
                _contact = EnsureLength(value, nameof(Contact));
            }
        }

        /// <summary>
        /// Terms.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Terms
        {
            get
            {
                return _terms;
            }
            set
            {
                _terms = EnsureLength(value, nameof(Terms));
            }
        }

        /// <summary>
        /// Instructions on purchase order one.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string PurchaseOrderInstructionsOne
        {
            get
            {
                return _instruct1;
            }
            set
            {
                _instruct1 = EnsureLength(value, nameof(PurchaseOrderInstructionsOne));
            }
        }

        /// <summary>
        /// Instructions on purchase order two.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string PurchaseOrderInstructionsTwo
        {
            get
            {
                return _instruct2;
            }
            set
            {
                _instruct2 = EnsureLength(value, nameof(PurchaseOrderInstructionsTwo));
            }
        }

        /// <summary>
        /// Instructions on purchase order three.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string PurchaseOrderInstructionsThree
        {
            get
            {
                return _instruct3;
            }
            set
            {
                _instruct3 = EnsureLength(value, nameof(PurchaseOrderInstructionsThree));
            }
        }

        /// <summary>
        /// First line of notes about the supplier.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string NotesOne
        {
            get
            {
                return _note1;
            }
            set
            {
                _note1 = EnsureLength(value, nameof(NotesOne));
            }
        }

        /// <summary>
        /// Second line of notes about the supplier.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string NotesTwo
        {
            get
            {
                return _note2;
            }
            set
            {
                _note2 = EnsureLength(value, nameof(NotesTwo));
            }
        }

        /// <summary>
        /// Third line of notes about the supplier.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string NotesThree
        {
            get
            {
                return _note3;
            }
            set
            {
                _note3 = EnsureLength(value, nameof(NotesThree));
            }
        }

        /// <summary>
        /// Supplier e-mail address.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = EnsureLength(value, nameof(Email));
            }
        }

        /// <summary>
        /// Country code of the supplier.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = EnsureLength(value, nameof(Country));
            }
        }

        /// <summary>
        /// Indicates whether the supplier participates in an electronic data interchange.
        /// </summary>
        public virtual bool EDI
        { get; set; }

        /// <summary>
        /// Specifies the credit card payment type.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string CardType
        {
            get
            {
                return _cardType;
            }
            set
            {
                _cardType = EnsureLength(value, nameof(CardType));
            }
        }

        /// <summary>
        /// Specifies the zip code of the supplier.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string ZipCode
        {
            get
            {
                return _zipCode;
            }
            set
            {
                _zipCode = EnsureLength(value, nameof(ZipCode));
            }
        }

        /// <summary>
        /// Preferred shipping method for product delivery.
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
                _shipVia = EnsureLength(value, nameof(ShipVia));
            }
        }

        /// <summary>
        /// Preferred e-mail format.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string PreferredEmailFormat
        {
            get
            {
                return _emailDef;
            }
            set
            {
                _emailDef = EnsureLength(value, nameof(PreferredEmailFormat));
            }
        }

        /// <summary>
        /// Supplier contact phone extension number.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string PhoneExtension
        {
            get
            {
                return _phoneExt;
            }
            set
            {
                _phoneExt = EnsureLength(value, nameof(PhoneExtension));
            }
        }

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
                _luBy = EnsureLength(value, nameof(LookupBy));
            }
        }

        /// <summary>
        /// Gets or sets the date/time the record was last accessed.
        /// </summary>
        public virtual Instant? LookupOn
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerSupplier"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerSupplier()
        { }

        /// <summary>
        /// Creates a <see cref="WhippetDataRowImportMap"/> object that contains a mapping for the current entity.
        /// </summary>
        /// <returns><see cref="WhippetDataRowImportMap"/> object.</returns>
        public override WhippetDataRowImportMap CreateImportMap()
        {
            return new WhippetDataRowImportMap(new[] {
                new WhippetDataRowImportMapEntry(nameof(Code), MultichannelOrderManagerDatabaseConstants.Columns.CODE),
                new WhippetDataRowImportMapEntry(nameof(Name), MultichannelOrderManagerDatabaseConstants.Columns.NAME),
                new WhippetDataRowImportMapEntry(nameof(AddressLineOne), MultichannelOrderManagerDatabaseConstants.Columns.L1),
                new WhippetDataRowImportMapEntry(nameof(AddressLineTwo), MultichannelOrderManagerDatabaseConstants.Columns.L2),
                new WhippetDataRowImportMapEntry(nameof(AddressLineThree), MultichannelOrderManagerDatabaseConstants.Columns.L3),
                new WhippetDataRowImportMapEntry(nameof(Phone), MultichannelOrderManagerDatabaseConstants.Columns.PHONE),
                new WhippetDataRowImportMapEntry(nameof(Fax), MultichannelOrderManagerDatabaseConstants.Columns.FAX),
                new WhippetDataRowImportMapEntry(nameof(Account), MultichannelOrderManagerDatabaseConstants.Columns.ACCOUNT),
                new WhippetDataRowImportMapEntry(nameof(CanDropShip), MultichannelOrderManagerDatabaseConstants.Columns.SU_DROP),
                new WhippetDataRowImportMapEntry(nameof(Contact), MultichannelOrderManagerDatabaseConstants.Columns.CONTACT),
                new WhippetDataRowImportMapEntry(nameof(Terms), MultichannelOrderManagerDatabaseConstants.Columns.TERMS),
                new WhippetDataRowImportMapEntry(nameof(PurchaseOrderInstructionsOne), MultichannelOrderManagerDatabaseConstants.Columns.INSTRUCT1),
                new WhippetDataRowImportMapEntry(nameof(PurchaseOrderInstructionsTwo), MultichannelOrderManagerDatabaseConstants.Columns.INSTRUCT2),
                new WhippetDataRowImportMapEntry(nameof(PurchaseOrderInstructionsThree), MultichannelOrderManagerDatabaseConstants.Columns.INSTRUCT3),
                new WhippetDataRowImportMapEntry(nameof(NotesOne), MultichannelOrderManagerDatabaseConstants.Columns.NOTE1),
                new WhippetDataRowImportMapEntry(nameof(NotesTwo), MultichannelOrderManagerDatabaseConstants.Columns.NOTE2),
                new WhippetDataRowImportMapEntry(nameof(NotesThree), MultichannelOrderManagerDatabaseConstants.Columns.NOTE3),
                new WhippetDataRowImportMapEntry(nameof(DiscountPercent), MultichannelOrderManagerDatabaseConstants.Columns.DISCT_PCT),
                new WhippetDataRowImportMapEntry(nameof(DiscountDays), MultichannelOrderManagerDatabaseConstants.Columns.DISCT_DAYS),
                new WhippetDataRowImportMapEntry(nameof(DueDays), MultichannelOrderManagerDatabaseConstants.Columns.DUE_DAYS),
                new WhippetDataRowImportMapEntry(nameof(AllowTerms), MultichannelOrderManagerDatabaseConstants.Columns.TERM_ALLOW),
                new WhippetDataRowImportMapEntry(nameof(Email), MultichannelOrderManagerDatabaseConstants.Columns.EMAIL),
                new WhippetDataRowImportMapEntry(nameof(PrintPurchaseOrders), MultichannelOrderManagerDatabaseConstants.Columns.PRINTPO),
                new WhippetDataRowImportMapEntry(nameof(EmailPurchaseOrders), MultichannelOrderManagerDatabaseConstants.Columns.EMAILPO),
                new WhippetDataRowImportMapEntry(nameof(FaxPurchaseOrders), MultichannelOrderManagerDatabaseConstants.Columns.FAXPO),
                new WhippetDataRowImportMapEntry(nameof(Country), MultichannelOrderManagerDatabaseConstants.Columns.COUNTRY),
                new WhippetDataRowImportMapEntry(nameof(PaymentTerms), MultichannelOrderManagerDatabaseConstants.Columns.PTERMS),
                new WhippetDataRowImportMapEntry(nameof(CardType), MultichannelOrderManagerDatabaseConstants.Columns.CTYPE),
                new WhippetDataRowImportMapEntry(nameof(LoadZones), MultichannelOrderManagerDatabaseConstants.Columns.LOADZONES),
                new WhippetDataRowImportMapEntry(nameof(ZipCode), MultichannelOrderManagerDatabaseConstants.Columns.ZIPCODE),
                new WhippetDataRowImportMapEntry(nameof(LeadAverage), MultichannelOrderManagerDatabaseConstants.Columns.LEAD_AVG),
                new WhippetDataRowImportMapEntry(nameof(MinimumUnits), MultichannelOrderManagerDatabaseConstants.Columns.MIN_UNITS),
                new WhippetDataRowImportMapEntry(nameof(MinimumAmount), MultichannelOrderManagerDatabaseConstants.Columns.MIN_AMT),
                new WhippetDataRowImportMapEntry(nameof(MinimumRequired), MultichannelOrderManagerDatabaseConstants.Columns.MIN_REQ),
                new WhippetDataRowImportMapEntry(nameof(ShipVia), MultichannelOrderManagerDatabaseConstants.Columns.SHIPVIA),
                new WhippetDataRowImportMapEntry(nameof(SupplierID), MultichannelOrderManagerDatabaseConstants.Columns.SUPPLIER_ID),
                new WhippetDataRowImportMapEntry(nameof(PreferredEmailFormat), MultichannelOrderManagerDatabaseConstants.Columns.EMAILDEF),
                new WhippetDataRowImportMapEntry(nameof(Inactive), MultichannelOrderManagerDatabaseConstants.Columns.INACTIVE),
                new WhippetDataRowImportMapEntry(nameof(LandedCostAdjustmentDeterminedByProductValue), MultichannelOrderManagerDatabaseConstants.Columns.LADJVAL),
                new WhippetDataRowImportMapEntry(nameof(LandedCostAdjustmentDeterminedByProductVolume), MultichannelOrderManagerDatabaseConstants.Columns.LADJVOL),
                new WhippetDataRowImportMapEntry(nameof(LandedCostAdjustmentDeterminedByProductWeight), MultichannelOrderManagerDatabaseConstants.Columns.LADJWEIGHT),
                new WhippetDataRowImportMapEntry(nameof(ShippingLandedCostDeterminedByValue), MultichannelOrderManagerDatabaseConstants.Columns.LSHPVAL),
                new WhippetDataRowImportMapEntry(nameof(ShippingLandedCostDeterminedByVolume), MultichannelOrderManagerDatabaseConstants.Columns.LSHPVOL),
                new WhippetDataRowImportMapEntry(nameof(ShippingLandedCostDeterminedByWeight), MultichannelOrderManagerDatabaseConstants.Columns.LSHIPWEIGHT),
                new WhippetDataRowImportMapEntry(nameof(LandedCostTaxDerterminedByProductValue), MultichannelOrderManagerDatabaseConstants.Columns.LTAXVAL),
                new WhippetDataRowImportMapEntry(nameof(LandedCostTaxDeterminedByProductVolume), MultichannelOrderManagerDatabaseConstants.Columns.LTAXVOL),
                new WhippetDataRowImportMapEntry(nameof(LandedCostTaxDeterminedByProductWeight), MultichannelOrderManagerDatabaseConstants.Columns.LTAXWEIGHT),
                new WhippetDataRowImportMapEntry(nameof(MaximumVolume), MultichannelOrderManagerDatabaseConstants.Columns.MAXVOL),
                new WhippetDataRowImportMapEntry(nameof(MaximumWeight), MultichannelOrderManagerDatabaseConstants.Columns.MAXWEIGHT),
                new WhippetDataRowImportMapEntry(nameof(MinimumVolume), MultichannelOrderManagerDatabaseConstants.Columns.MINVOL),
                new WhippetDataRowImportMapEntry(nameof(MinimumWeight), MultichannelOrderManagerDatabaseConstants.Columns.MINWEIGHT),
                new WhippetDataRowImportMapEntry(nameof(PhoneExtension), MultichannelOrderManagerDatabaseConstants.Columns.PHONEEXT),
                new WhippetDataRowImportMapEntry(nameof(LookupBy), MultichannelOrderManagerDatabaseConstants.Columns.LU_BY),
                new WhippetDataRowImportMapEntry(nameof(LookupOn), MultichannelOrderManagerDatabaseConstants.Columns.LU_ON),
                new WhippetDataRowImportMapEntry(nameof(EDI), MultichannelOrderManagerDatabaseConstants.Columns.EDI)
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

                Code = dataRow.Field<string>(map[nameof(Code)].Column);
                Name = dataRow.Field<string>(map[nameof(Name)].Column);
                AddressLineOne = dataRow.Field<string>(map[nameof(AddressLineOne)].Column);
                AddressLineTwo = dataRow.Field<string>(map[nameof(AddressLineTwo)].Column);
                AddressLineThree = dataRow.Field<string>(map[nameof(AddressLineThree)].Column);
                Phone = dataRow.Field<string>(map[nameof(Phone)].Column);
                Fax = dataRow.Field<string>(map[nameof(Fax)].Column);
                Account = dataRow.Field<string>(map[nameof(Account)].Column);
                CanDropShip = dataRow.Field<bool>(map[nameof(CanDropShip)].Column);
                Contact = dataRow.Field<string>(map[nameof(Contact)].Column);
                Terms = dataRow.Field<string>(map[nameof(Terms)].Column);
                PurchaseOrderInstructionsOne = dataRow.Field<string>(map[nameof(PurchaseOrderInstructionsOne)].Column);
                PurchaseOrderInstructionsTwo = dataRow.Field<string>(map[nameof(PurchaseOrderInstructionsTwo)].Column);
                PurchaseOrderInstructionsThree = dataRow.Field<string>(map[nameof(PurchaseOrderInstructionsThree )].Column);
                NotesOne = dataRow.Field<string>(map[nameof(NotesOne)].Column);
                NotesTwo = dataRow.Field<string>(map[nameof(NotesTwo)].Column);
                NotesThree = dataRow.Field<string>(map[nameof(NotesThree)].Column);
                DiscountPercent = dataRow.Field<decimal>(map[nameof(DiscountPercent)].Column);
                DiscountDays = dataRow.Field<int>(map[nameof(DiscountDays)].Column);
                DueDays = dataRow.Field<int>(map[nameof(DueDays)].Column);
                AllowTerms = dataRow.Field<bool>(map[nameof(AllowTerms)].Column);
                Email = dataRow.Field<string>(map[nameof(Email)].Column);
                PrintPurchaseOrders = dataRow.Field<bool>(map[nameof(PrintPurchaseOrders)].Column);
                EmailPurchaseOrders = dataRow.Field<bool>(map[nameof(EmailPurchaseOrders)].Column);
                FaxPurchaseOrders = dataRow.Field<bool>(map[nameof(FaxPurchaseOrders)].Column);
                Country = dataRow.Field<string>(map[nameof(Country)].Column);
                PaymentTerms = dataRow.Field<char>(map[nameof(PaymentTerms)].Column);
                CardType = dataRow.Field<string>(map[nameof(CardType)].Column);
                LoadZones = dataRow.Field<bool>(map[nameof(LoadZones)].Column);
                ZipCode = dataRow.Field<string>(map[nameof(ZipCode)].Column);
                LeadAverage = dataRow.Field<decimal>(map[nameof(LeadAverage)].Column);
                MinimumUnits = dataRow.Field<decimal>(map[nameof(MinimumUnits)].Column);
                MinimumAmount = dataRow.Field<decimal>(map[nameof(MinimumAmount)].Column);
                MinimumRequired = dataRow.Field<bool>(map[nameof(MinimumRequired)].Column);
                ShipVia = dataRow.Field<string>(map[nameof(ShipVia)].Column);
                SupplierID = dataRow.Field<long>(map[nameof(SupplierID)].Column);
                PreferredEmailFormat = dataRow.Field<string>(map[nameof(PreferredEmailFormat)].Column);
                Inactive = dataRow.Field<bool>(map[nameof(Inactive)].Column);
                LandedCostAdjustmentDeterminedByProductValue = dataRow.Field<bool>(map[nameof(LandedCostAdjustmentDeterminedByProductValue)].Column);
                LandedCostAdjustmentDeterminedByProductVolume = dataRow.Field<bool>(map[nameof(LandedCostAdjustmentDeterminedByProductVolume)].Column);
                LandedCostAdjustmentDeterminedByProductWeight = dataRow.Field<bool>(map[nameof(LandedCostAdjustmentDeterminedByProductWeight)].Column);
                ShippingLandedCostDeterminedByValue = dataRow.Field<bool>(map[nameof(ShippingLandedCostDeterminedByValue)].Column);
                ShippingLandedCostDeterminedByVolume = dataRow.Field<bool>(map[nameof(ShippingLandedCostDeterminedByVolume)].Column);
                ShippingLandedCostDeterminedByWeight = dataRow.Field<bool>(map[nameof(ShippingLandedCostDeterminedByWeight)].Column);
                LandedCostTaxDerterminedByProductValue = dataRow.Field<bool>(map[nameof(LandedCostTaxDerterminedByProductValue)].Column);
                LandedCostTaxDeterminedByProductVolume = dataRow.Field<bool>(map[nameof(LandedCostTaxDeterminedByProductVolume)].Column);
                LandedCostTaxDeterminedByProductWeight = dataRow.Field<bool>(map[nameof(LandedCostTaxDeterminedByProductWeight)].Column);
                MaximumVolume = dataRow.Field<decimal>(map[nameof(MaximumVolume)].Column);
                MaximumWeight = dataRow.Field<decimal>(map[nameof(MaximumWeight)].Column);
                MinimumVolume = dataRow.Field<decimal>(map[nameof(MinimumVolume)].Column);
                MinimumWeight = dataRow.Field<decimal>(map[nameof(MinimumWeight)].Column);
                PhoneExtension = dataRow.Field<string>(map[nameof(PhoneExtension)].Column);
                EDI = dataRow.Field<bool>(map[nameof(EDI)].Column);
                MomObjectID = dataRow.Field<long>(map[nameof(SupplierID)].Column);
                LookupBy = dataRow.Field<string>(map[nameof(LookupBy)].Column);
                LookupOn = ToNullableInstant(dataRow.Field<DateTime?>(map[nameof(LookupOn)].Column));

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

            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Code)].Column, false, 6));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Name)].Column, false, 30));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(AddressLineOne)].Column, false, 30));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(AddressLineTwo)].Column, false, 30));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(AddressLineThree)].Column, false, 30));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Phone)].Column, false, 16));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Fax)].Column, false, 16));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Account)].Column, false, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(CanDropShip)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Contact)].Column, false, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Terms)].Column, false, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(PurchaseOrderInstructionsOne)].Column, false, 30));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(PurchaseOrderInstructionsTwo)].Column, false, 30));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(PurchaseOrderInstructionsThree)].Column, false, 30));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(NotesOne)].Column, false, 60));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(NotesTwo)].Column, false, 60));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(NotesThree)].Column, false, 60));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(DiscountPercent)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(DiscountDays)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(DueDays)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(AllowTerms)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Email)].Column, false, 50));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(PrintPurchaseOrders)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(EmailPurchaseOrders)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(FaxPurchaseOrders)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Country)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(PaymentTerms)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CardType)].Column, false, 2));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(LoadZones)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ZipCode)].Column, false, 5));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(LeadAverage)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(MinimumUnits)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(MinimumAmount)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(MinimumRequired)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ShipVia)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<long>(map[nameof(SupplierID)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(PreferredEmailFormat)].Column, false, 8));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Inactive)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(LandedCostAdjustmentDeterminedByProductValue)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(LandedCostAdjustmentDeterminedByProductVolume)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(LandedCostAdjustmentDeterminedByProductWeight)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(ShippingLandedCostDeterminedByValue)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(ShippingLandedCostDeterminedByVolume)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(ShippingLandedCostDeterminedByWeight)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(LandedCostTaxDerterminedByProductValue)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(LandedCostTaxDeterminedByProductVolume)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(LandedCostTaxDeterminedByProductWeight)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(MaximumVolume)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(MaximumWeight)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(MinimumVolume)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(MinimumWeight)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(PhoneExtension)].Column, false, 8));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(EDI)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(LookupBy)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LookupOn)].Column, true));

            table.PrimaryKey = new[] { table.Columns[map[nameof(SupplierID)].Column] };

            return table;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IMultichannelOrderManagerSupplier);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerSupplier obj)
        {
            return (obj != null) && Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerSupplier x, IMultichannelOrderManagerSupplier y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals =
                    String.Equals(x.Account, y.Account, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.AddressLineOne, y.AddressLineOne, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.AddressLineTwo, y.AddressLineTwo, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.AddressLineThree, y.AddressLineThree, StringComparison.InvariantCultureIgnoreCase)
                        && x.AllowTerms == y.AllowTerms
                        && x.CanDropShip == y.CanDropShip
                        && String.Equals(x.CardType, y.CardType, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.Code, y.Code, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.Contact, y.Contact, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.Country, y.Country, StringComparison.InvariantCultureIgnoreCase)
                        && x.DiscountDays == y.DiscountDays
                        && x.DiscountPercent == y.DiscountPercent
                        && x.DueDays == y.DueDays
                        && x.EDI == y.EDI
                        && String.Equals(x.Email, y.Email, StringComparison.InvariantCultureIgnoreCase)
                        && x.EmailPurchaseOrders == y.EmailPurchaseOrders
                        && String.Equals(x.Fax, y.Fax, StringComparison.InvariantCultureIgnoreCase)
                        && x.FaxPurchaseOrders == y.FaxPurchaseOrders
                        && x.Inactive == y.Inactive
                        && x.LandedCostAdjustmentDeterminedByProductValue == y.LandedCostAdjustmentDeterminedByProductValue
                        && x.LandedCostAdjustmentDeterminedByProductVolume == y.LandedCostAdjustmentDeterminedByProductVolume
                        && x.LandedCostAdjustmentDeterminedByProductWeight == y.LandedCostAdjustmentDeterminedByProductWeight
                        && x.LandedCostTaxDerterminedByProductValue == y.LandedCostTaxDerterminedByProductValue
                        && x.LandedCostTaxDeterminedByProductVolume == y.LandedCostTaxDeterminedByProductVolume
                        && x.LandedCostTaxDeterminedByProductWeight == y.LandedCostTaxDeterminedByProductWeight
                        && x.LeadAverage == y.LeadAverage
                        && x.LoadZones == y.LoadZones
                        && String.Equals(x.LookupBy, y.LookupBy, StringComparison.InvariantCultureIgnoreCase)
                        && x.LookupOn.GetValueOrDefault().Equals(y.LookupOn.GetValueOrDefault())
                        && x.MaximumVolume == y.MaximumVolume
                        && x.MaximumWeight == y.MaximumWeight
                        && x.MinimumAmount == y.MinimumAmount
                        && x.MinimumRequired == y.MinimumRequired
                        && x.MinimumUnits == y.MinimumUnits
                        && x.MinimumVolume == y.MinimumVolume
                        && x.MinimumWeight == y.MinimumWeight
                        && String.Equals(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.NotesOne, y.NotesOne, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.NotesTwo, y.NotesTwo, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.NotesThree, y.NotesThree, StringComparison.InvariantCultureIgnoreCase)
                        && x.PaymentTerms == y.PaymentTerms
                        && String.Equals(x.Phone, y.Phone, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.PhoneExtension, y.PhoneExtension, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.PreferredEmailFormat, y.PreferredEmailFormat, StringComparison.InvariantCultureIgnoreCase)
                        && x.PrintPurchaseOrders == y.PrintPurchaseOrders
                        && String.Equals(x.PurchaseOrderInstructionsOne, y.PurchaseOrderInstructionsOne, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.PurchaseOrderInstructionsTwo, y.PurchaseOrderInstructionsTwo, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.PurchaseOrderInstructionsThree, y.PurchaseOrderInstructionsThree, StringComparison.InvariantCultureIgnoreCase)
                        && x.ShippingLandedCostDeterminedByValue == y.ShippingLandedCostDeterminedByValue
                        && x.ShippingLandedCostDeterminedByVolume == y.ShippingLandedCostDeterminedByVolume
                        && x.ShippingLandedCostDeterminedByWeight == y.ShippingLandedCostDeterminedByWeight
                        && String.Equals(x.ShipVia, y.ShipVia, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.Terms, y.Terms, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.ZipCode, y.ZipCode, StringComparison.InvariantCultureIgnoreCase);
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
        /// <param name="obj"><see cref="IMultichannelOrderManagerSupplier"/> object ot get hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(IMultichannelOrderManagerSupplier obj)
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

            if (String.IsNullOrWhiteSpace(Name))
            {
                builder.Append(base.ToString());
            }
            else
            {
                builder.Append(Name);

                if (!String.IsNullOrWhiteSpace(Code))
                {
                    builder.Append(" [");
                    builder.Append(Code);
                    builder.Append("]");
                }
            }

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