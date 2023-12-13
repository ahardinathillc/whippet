using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using Dynamitey;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Extensions;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;
using Athi.Whippet.Collections.Comparers;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents a postal code and its associated tax information in M.O.M.
    /// </summary>
    public class MultichannelOrderManagerPostalCode : MultichannelOrderManagerEntity, IWhippetEntity, IWhippetEntityExternalDataRowImportMapper, IMultichannelOrderManagerPostalCode, IEqualityComparer<IMultichannelOrderManagerPostalCode>, IMultichannelOrderManagerEntity, IWhippetEntityDynamicImportMapper, IWhippetCloneable, IComparable<IMultichannelOrderManagerPostalCode>
    {
        private WhippetDataRowImportMap _internalMap;

        private MultichannelOrderManagerCountry _country;
        private MultichannelOrderManagerStateProvince _stateProvince;
        private MultichannelOrderManagerCounty _county;
        private MultichannelOrderManagerWarehouse _warehouse;

        private string _zipCode;
        private string _city;
        private string _lookupBy;

        /// <summary>
        /// Gets or sets the unique ID of the <see cref="MultichannelOrderManagerPostalCode"/>.
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
        /// Gets or sets the parent <see cref="MultichannelOrderManagerCountry"/>.
        /// </summary>
        public virtual MultichannelOrderManagerCountry Country
        {
            get
            {
                if (_country == null)
                {
                    _country = new MultichannelOrderManagerCountry();
                }

                return _country;
            }
            set
            {
                _country = value;
            }
        }

        /// <summary>
        /// Gets or sets the parent <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        IMultichannelOrderManagerCountry IMultichannelOrderManagerPostalCode.Country
        {
            get
            {
                return Country;
            }
            set
            {
                Country = value.ToMultichannelOrderManagerCountry();
            }
        }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string PostalCode
        {
            get
            {
                return _zipCode;
            }
            set
            {
                _zipCode = EnsureLength(value, nameof(PostalCode)).Trim();
            }
        }

        /// <summary>
        /// Gets or sets the parent <see cref="MultichannelOrderManagerStateProvince"/>.
        /// </summary>
        public virtual MultichannelOrderManagerStateProvince StateProvince
        {
            get
            {
                if (_stateProvince == null)
                {
                    _stateProvince = new MultichannelOrderManagerStateProvince();
                }

                return _stateProvince;
            }
            set
            {
                _stateProvince = value;
            }
        }

        /// <summary>
        /// Gets or sets the parent <see cref="IMultichannelOrderManagerStateProvince"/>.
        /// </summary>
        IMultichannelOrderManagerStateProvince IMultichannelOrderManagerPostalCode.StateProvince
        {
            get
            {
                return StateProvince;
            }
            set
            {
                StateProvince = value.ToMultichannelOrderManagerStateProvince();
            }
        }

        /// <summary>
        /// Gets or sets the parent <see cref="MultichannelOrderManagerCounty"/>.
        /// </summary>
        public virtual MultichannelOrderManagerCounty County
        {
            get
            {
                if (_county == null)
                {
                    _county = new MultichannelOrderManagerCounty();
                }

                return _county;
            }
            set
            {
                _county = value;
            }
        }

        /// <summary>
        /// Gets or sets the parent <see cref="IMultichannelOrderManagerCounty"/>.
        /// </summary>
        IMultichannelOrderManagerCounty IMultichannelOrderManagerPostalCode.County
        {
            get
            {
                return County;
            }
            set
            {
                County = value.ToMultichannelOrderManagerCounty();
            }
        }

        /// <summary>
        /// Reserved for internal use.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = EnsureLength(value, nameof(City)).Trim();
            }
        }

        /// <summary>
        /// Reserved for internal use.
        /// </summary>
        public virtual char Type
        { get; set; }

        /// <summary>
        /// Reserved for internal use.
        /// </summary>
        public virtual bool RTDTax
        { get; set; }

        /// <summary>
        /// Gets or sets the postal code tax rate.
        /// </summary>
        public virtual decimal TaxRate
        { get; set; }

        /// <summary>
        /// Reserved for internal use.
        /// </summary>
        public virtual bool Presence
        { get; set; }

        /// <summary>
        /// Reserved for internal use.
        /// </summary>
        public virtual char Code1
        { get; set; }

        /// <summary>
        /// Reserved for internal use.
        /// </summary>
        public virtual bool Logic1
        { get; set; }

        /// <summary>
        /// Specifies the (primary) warehouse that serves the postal code.
        /// </summary>
        public virtual MultichannelOrderManagerWarehouse Warehouse
        {
            get
            {
                if (_warehouse == null)
                {
                    _warehouse = new MultichannelOrderManagerWarehouse();
                }

                return _warehouse;
            }
            set
            {
                _warehouse = value;
            }
        }

        /// <summary>
        /// Specifies the (primary) warehouse that serves the postal code.
        /// </summary>
        IMultichannelOrderManagerWarehouse IMultichannelOrderManagerPostalCode.Warehouse
        {
            get
            {
                return Warehouse;
            }
            set
            {
                Warehouse = value.ToMultichannelOrderManagerWarehouse();
            }
        }

        /// <summary>
        /// Indicates whether shipping is taxed for the postal code.
        /// </summary>
        public virtual bool TaxShipping
        { get; set; }

        /// <summary>
        /// Indicates whether the postal code is sales tax class A taxable.
        /// </summary>
        public virtual bool TaxClass_A
        { get; set; }

        /// <summary>
        /// Indicates whether the postal code is sales tax class B taxable.
        /// </summary>
        public virtual bool TaxClass_B
        { get; set; }

        /// <summary>
        /// Indicates whether the postal code is sales tax class C taxable.
        /// </summary>
        public virtual bool TaxClass_C
        { get; set; }

        /// <summary>
        /// Indicates whether the postal code is sales tax class D taxable.
        /// </summary>
        public virtual bool TaxClass_D
        { get; set; }

        /// <summary>
        /// Indicates whether the postal code is sales tax class E taxable.
        /// </summary>
        public virtual bool TaxClass_E
        { get; set; }

        /// <summary>
        /// Gets or sets the postal code sales tax rate for class A.
        /// </summary>
        public virtual decimal RateClass_A
        { get; set; }

        /// <summary>
        /// Gets or sets the postal code sales tax rate for class B.
        /// </summary>
        public virtual decimal RateClass_B
        { get; set; }

        /// <summary>
        /// Gets or sets the postal code sales tax rate for class C.
        /// </summary>
        public virtual decimal RateClass_C
        { get; set; }

        /// <summary>
        /// Gets or sets the postal code sales tax rate for class D.
        /// </summary>
        public virtual decimal RateClass_D
        { get; set; }

        /// <summary>
        /// Gets or sets the postal code sales tax rate for class E.
        /// </summary>
        public virtual decimal RateClass_E
        { get; set; }

        /// <summary>
        /// Indicates whether to stop taxing after the order total exceeds flag for tax class A.
        /// </summary>
        public virtual bool FlagCapTaxClass_A
        { get; set; }

        /// <summary>
        /// Indicates whether to stop taxing after the order total exceeds flag for tax class B.
        /// </summary>
        public virtual bool FlagCapTaxClass_B
        { get; set; }

        /// <summary>
        /// Indicates whether to stop taxing after the order total exceeds flag for tax class C.
        /// </summary>
        public virtual bool FlagCapTaxClass_C
        { get; set; }

        /// <summary>
        /// Indicates whether to stop taxing after the order total exceeds flag for tax class D.
        /// </summary>
        public virtual bool FlagCapTaxClass_D
        { get; set; }

        /// <summary>
        /// Indicates whether to stop taxing after the order total exceeds flag for tax class E.
        /// </summary>
        public virtual bool FlagCapTaxClass_E
        { get; set; }

        /// <summary>
        /// Gets or sets the amount in which to stop taxing after the order total exceeds amount for tax class A.
        /// </summary>
        public virtual decimal TotalCapTaxClass_A
        { get; set; }

        /// <summary>
        /// Gets or sets the amount in which to stop taxing after the order total exceeds amount for tax class B.
        /// </summary>
        public virtual decimal TotalCapTaxClass_B
        { get; set; }

        /// <summary>
        /// Gets or sets the amount in which to stop taxing after the order total exceeds amount for tax class C.
        /// </summary>
        public virtual decimal TotalCapTaxClass_C
        { get; set; }

        /// <summary>
        /// Gets or sets the amount in which to stop taxing after the order total exceeds amount for tax class D.
        /// </summary>
        public virtual decimal TotalCapTaxClass_D
        { get; set; }

        /// <summary>
        /// Gets or sets the amount in which to stop taxing after the order total exceeds amount for tax class E.
        /// </summary>
        public virtual decimal TotalCapTaxClass_E
        { get; set; }

        /// <summary>
        /// Gets or sets the amount in which to start taxing after the order total exceeds amount for tax class A.
        /// </summary>
        public virtual decimal ExceedAmountTaxClass_A
        { get; set; }

        /// <summary>
        /// Gets or sets the amount in which to start taxing after the order total exceeds amount for tax class B.
        /// </summary>
        public virtual decimal ExceedAmountTaxClass_B
        { get; set; }

        /// <summary>
        /// Gets or sets the amount in which to start taxing after the order total exceeds amount for tax class C.
        /// </summary>
        public virtual decimal ExceedAmountTaxClass_C
        { get; set; }

        /// <summary>
        /// Gets or sets the amount in which to start taxing after the order total exceeds amount for tax class D.
        /// </summary>
        public virtual decimal ExceedAmountTaxClass_D
        { get; set; }

        /// <summary>
        /// Gets or sets the amount in which to start taxing after the order total exceeds amount for tax class E.
        /// </summary>
        public virtual decimal ExceedAmountTaxClass_E
        { get; set; }

        /// <summary>
        /// Specifies whether to tax shipping on boxes with all non-taxable items for state/province tax rates.
        /// </summary>
        public virtual bool DoNotTaxShippingOnBoxesWithAllNonTaxableItems
        { get; set; }

        /// <summary>
        /// Specifies whether to tax amounts below <see cref="ExceedAmountTaxClass_A"/>.
        /// </summary>
        public virtual bool DoNotTaxExceedAmountTaxClass_A
        { get; set; }

        /// <summary>
        /// Specifies whether to tax amounts below <see cref="ExceedAmountTaxClass_B"/>.
        /// </summary>
        public virtual bool DoNotTaxExceedAmountTaxClass_B
        { get; set; }

        /// <summary>
        /// Specifies whether to tax amounts below <see cref="ExceedAmountTaxClass_C"/>.
        /// </summary>
        public virtual bool DoNotTaxExceedAmountTaxClass_C
        { get; set; }

        /// <summary>
        /// Specifies whether to tax amounts below <see cref="ExceedAmountTaxClass_D"/>.
        /// </summary>
        public virtual bool DoNotTaxExceedAmountTaxClass_D
        { get; set; }

        /// <summary>
        /// Specifies whether to tax amounts below <see cref="ExceedAmountTaxClass_E"/>.
        /// </summary>
        public virtual bool DoNotTaxExceedAmountTaxClass_E
        { get; set; }

        /// <summary>
        /// Indicates whether to tax handling fees only at postal code tax rates.
        /// </summary>
        public virtual bool TaxHandlingFeesPostalCodeTaxRateOnly
        { get; set; }

        /// <summary>
        /// This property is reserved for use by M.O.M.
        /// </summary>
        public virtual bool TaxUpdate
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
                _lookupBy = this.CheckLengthRequirement(value, ImportMap[nameof(LookupBy)].Column);
            }
        }

        /// <summary>
        /// Gets or sets the timestamp the record was last accessed.
        /// </summary>
        public virtual DateTime? LookupOn
        { get; set; }

        /// <summary>
        /// Gets the external table name or <see langword="null"/> if the data source is not stored in a database. This property is read-only.
        /// </summary>
        protected override string ExternalTableName
        {
            get
            {
                return MultichannelOrderManagerDatabaseConstants.Tables.ZIP;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerPostalCode"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerPostalCode()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerPostalCode"/> with the specified ID.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        public MultichannelOrderManagerPostalCode(int id)
            : this()
        {
            MomObjectID = id;
        }

        /// <summary>
        /// Creates a <see cref="WhippetDataRowImportMap"/> object that contains a mapping for the current entity.
        /// </summary>
        /// <returns><see cref="WhippetDataRowImportMap"/> object.</returns>
        public override WhippetDataRowImportMap CreateImportMap()
        {
            WhippetDataRowImportMapEntry pcId = new WhippetDataRowImportMapEntry(nameof(MomObjectID), MultichannelOrderManagerDatabaseConstants.Columns.ZIP_ID);
            WhippetDataRowImportMapEntry country = new WhippetDataRowImportMapEntry(nameof(Country), MultichannelOrderManagerDatabaseConstants.Columns.COUNTRY);
            WhippetDataRowImportMapEntry postalCode = new WhippetDataRowImportMapEntry(nameof(PostalCode), MultichannelOrderManagerDatabaseConstants.Columns.ZIPCODE);
            WhippetDataRowImportMapEntry state = new WhippetDataRowImportMapEntry(nameof(StateProvince), MultichannelOrderManagerDatabaseConstants.Columns.STATE);
            WhippetDataRowImportMapEntry city = new WhippetDataRowImportMapEntry(nameof(City), MultichannelOrderManagerDatabaseConstants.Columns.CITY);
            WhippetDataRowImportMapEntry type = new WhippetDataRowImportMapEntry(nameof(Type), MultichannelOrderManagerDatabaseConstants.Columns.TYPE);
            WhippetDataRowImportMapEntry county = new WhippetDataRowImportMapEntry(nameof(County), MultichannelOrderManagerDatabaseConstants.Columns.COUNTY);
            WhippetDataRowImportMapEntry rtdTax = new WhippetDataRowImportMapEntry(nameof(RTDTax), MultichannelOrderManagerDatabaseConstants.Columns.RTDTAX);
            WhippetDataRowImportMapEntry rate = new WhippetDataRowImportMapEntry(nameof(TaxRate), MultichannelOrderManagerDatabaseConstants.Columns.ITAXR);
            WhippetDataRowImportMapEntry presence = new WhippetDataRowImportMapEntry(nameof(Presence), MultichannelOrderManagerDatabaseConstants.Columns.PRESENCE);
            WhippetDataRowImportMapEntry code1 = new WhippetDataRowImportMapEntry(nameof(Code1), MultichannelOrderManagerDatabaseConstants.Columns.CODE1);
            WhippetDataRowImportMapEntry logic1 = new WhippetDataRowImportMapEntry(nameof(Logic1), MultichannelOrderManagerDatabaseConstants.Columns.LOGIC1);
            WhippetDataRowImportMapEntry warehouse = new WhippetDataRowImportMapEntry(nameof(Warehouse), MultichannelOrderManagerDatabaseConstants.Columns.WAREHOUSE);
            WhippetDataRowImportMapEntry taxShip = new WhippetDataRowImportMapEntry(nameof(TaxShipping), MultichannelOrderManagerDatabaseConstants.Columns.TAXSHIP);
            WhippetDataRowImportMapEntry taxClassA = new WhippetDataRowImportMapEntry(nameof(TaxClass_A), MultichannelOrderManagerDatabaseConstants.Columns.TAX_CLASSA);
            WhippetDataRowImportMapEntry taxClassB = new WhippetDataRowImportMapEntry(nameof(TaxClass_B), MultichannelOrderManagerDatabaseConstants.Columns.TAX_CLASSB);
            WhippetDataRowImportMapEntry taxClassC = new WhippetDataRowImportMapEntry(nameof(TaxClass_C), MultichannelOrderManagerDatabaseConstants.Columns.TAX_CLASSC);
            WhippetDataRowImportMapEntry taxClassD = new WhippetDataRowImportMapEntry(nameof(TaxClass_D), MultichannelOrderManagerDatabaseConstants.Columns.TAX_CLASSD);
            WhippetDataRowImportMapEntry taxClassE = new WhippetDataRowImportMapEntry(nameof(TaxClass_E), MultichannelOrderManagerDatabaseConstants.Columns.TAX_CLASSE);
            WhippetDataRowImportMapEntry rateClassA = new WhippetDataRowImportMapEntry(nameof(RateClass_A), MultichannelOrderManagerDatabaseConstants.Columns.RATECLASSA);
            WhippetDataRowImportMapEntry rateClassB = new WhippetDataRowImportMapEntry(nameof(RateClass_B), MultichannelOrderManagerDatabaseConstants.Columns.RATECLASSB);
            WhippetDataRowImportMapEntry rateClassC = new WhippetDataRowImportMapEntry(nameof(RateClass_C), MultichannelOrderManagerDatabaseConstants.Columns.RATECLASSC);
            WhippetDataRowImportMapEntry rateClassD = new WhippetDataRowImportMapEntry(nameof(RateClass_D), MultichannelOrderManagerDatabaseConstants.Columns.RATECLASSD);
            WhippetDataRowImportMapEntry rateClassE = new WhippetDataRowImportMapEntry(nameof(RateClass_E), MultichannelOrderManagerDatabaseConstants.Columns.RATECLASSE);
            WhippetDataRowImportMapEntry lcapA = new WhippetDataRowImportMapEntry(nameof(FlagCapTaxClass_A), MultichannelOrderManagerDatabaseConstants.Columns.I_LCAPA);
            WhippetDataRowImportMapEntry lcapB = new WhippetDataRowImportMapEntry(nameof(FlagCapTaxClass_B), MultichannelOrderManagerDatabaseConstants.Columns.I_LCAPB);
            WhippetDataRowImportMapEntry lcapC = new WhippetDataRowImportMapEntry(nameof(FlagCapTaxClass_C), MultichannelOrderManagerDatabaseConstants.Columns.I_LCAPC);
            WhippetDataRowImportMapEntry lcapD = new WhippetDataRowImportMapEntry(nameof(FlagCapTaxClass_D), MultichannelOrderManagerDatabaseConstants.Columns.I_LCAPD);
            WhippetDataRowImportMapEntry lcapE = new WhippetDataRowImportMapEntry(nameof(FlagCapTaxClass_E), MultichannelOrderManagerDatabaseConstants.Columns.I_LCAPE);
            WhippetDataRowImportMapEntry stopTaxA = new WhippetDataRowImportMapEntry(nameof(TotalCapTaxClass_A), MultichannelOrderManagerDatabaseConstants.Columns.I_NCAPA);
            WhippetDataRowImportMapEntry stopTaxB = new WhippetDataRowImportMapEntry(nameof(TotalCapTaxClass_B), MultichannelOrderManagerDatabaseConstants.Columns.I_NCAPB);
            WhippetDataRowImportMapEntry stopTaxC = new WhippetDataRowImportMapEntry(nameof(TotalCapTaxClass_C), MultichannelOrderManagerDatabaseConstants.Columns.I_NCAPC);
            WhippetDataRowImportMapEntry stopTaxD = new WhippetDataRowImportMapEntry(nameof(TotalCapTaxClass_D), MultichannelOrderManagerDatabaseConstants.Columns.I_NCAPD);
            WhippetDataRowImportMapEntry stopTaxE = new WhippetDataRowImportMapEntry(nameof(TotalCapTaxClass_E), MultichannelOrderManagerDatabaseConstants.Columns.I_NCAPE);
            WhippetDataRowImportMapEntry exceedA = new WhippetDataRowImportMapEntry(nameof(ExceedAmountTaxClass_A), MultichannelOrderManagerDatabaseConstants.Columns.I_NTAXITA);
            WhippetDataRowImportMapEntry exceedB = new WhippetDataRowImportMapEntry(nameof(ExceedAmountTaxClass_B), MultichannelOrderManagerDatabaseConstants.Columns.I_NTAXITB);
            WhippetDataRowImportMapEntry exceedC = new WhippetDataRowImportMapEntry(nameof(ExceedAmountTaxClass_C), MultichannelOrderManagerDatabaseConstants.Columns.I_NTAXITC);
            WhippetDataRowImportMapEntry exceedD = new WhippetDataRowImportMapEntry(nameof(ExceedAmountTaxClass_D), MultichannelOrderManagerDatabaseConstants.Columns.I_NTAXITD);
            WhippetDataRowImportMapEntry exceedE = new WhippetDataRowImportMapEntry(nameof(ExceedAmountTaxClass_E), MultichannelOrderManagerDatabaseConstants.Columns.I_NTAXITE);
            WhippetDataRowImportMapEntry nonTaxBox = new WhippetDataRowImportMapEntry(nameof(DoNotTaxShippingOnBoxesWithAllNonTaxableItems), MultichannelOrderManagerDatabaseConstants.Columns.NONTAXBOX);
            WhippetDataRowImportMapEntry onlyTaxA = new WhippetDataRowImportMapEntry(nameof(DoNotTaxExceedAmountTaxClass_A), MultichannelOrderManagerDatabaseConstants.Columns.ITAXTHRESA);
            WhippetDataRowImportMapEntry onlyTaxB = new WhippetDataRowImportMapEntry(nameof(DoNotTaxExceedAmountTaxClass_B), MultichannelOrderManagerDatabaseConstants.Columns.ITAXTHRESB);
            WhippetDataRowImportMapEntry onlyTaxC = new WhippetDataRowImportMapEntry(nameof(DoNotTaxExceedAmountTaxClass_C), MultichannelOrderManagerDatabaseConstants.Columns.ITAXTHRESC);
            WhippetDataRowImportMapEntry onlyTaxD = new WhippetDataRowImportMapEntry(nameof(DoNotTaxExceedAmountTaxClass_D), MultichannelOrderManagerDatabaseConstants.Columns.ITAXTHRESD);
            WhippetDataRowImportMapEntry onlyTaxE = new WhippetDataRowImportMapEntry(nameof(DoNotTaxExceedAmountTaxClass_E), MultichannelOrderManagerDatabaseConstants.Columns.ITAXTHRESE);
            WhippetDataRowImportMapEntry taxHandling = new WhippetDataRowImportMapEntry(nameof(TaxHandlingFeesPostalCodeTaxRateOnly), MultichannelOrderManagerDatabaseConstants.Columns.TAXHAND);
            WhippetDataRowImportMapEntry taxUpdate = new WhippetDataRowImportMapEntry(nameof(TaxUpdate), MultichannelOrderManagerDatabaseConstants.Columns.TAXUPDATE);
            WhippetDataRowImportMapEntry lookupBy = new WhippetDataRowImportMapEntry(nameof(LookupBy), MultichannelOrderManagerDatabaseConstants.Columns.LU_BY);
            WhippetDataRowImportMapEntry lookupOn = new WhippetDataRowImportMapEntry(nameof(LookupOn), MultichannelOrderManagerDatabaseConstants.Columns.LU_ON);

            return new WhippetDataRowImportMap(new[]
            {
                postalCode,
                city,
                type,
                county,
                rtdTax,
                rate,
                code1,
                logic1,
                warehouse,
                nonTaxBox,
                pcId,
                country,
                state,
                taxClassA,
                taxClassB,
                taxClassC,
                taxClassD,
                taxClassE,
                taxShip,
                presence,
                rateClassA,
                rateClassB,
                rateClassC,
                rateClassD,
                rateClassE,
                lcapA,
                lcapB,
                lcapC,
                lcapD,
                lcapE,
                exceedA,
                exceedB,
                exceedC,
                exceedD,
                exceedE,
                stopTaxA,
                stopTaxB,
                stopTaxC,
                stopTaxD,
                stopTaxE,
                onlyTaxA,
                onlyTaxB,
                onlyTaxC,
                onlyTaxD,
                onlyTaxE,
                taxHandling,
                taxUpdate,
                lookupBy,
                lookupOn
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
                WhippetDataRowImportMap map = (importMap == null ? ImportMap : importMap);

                Country = new MultichannelOrderManagerCountry() { CountryCode = dataRow.Field<string>(map[nameof(Country)].Column) };
                PostalCode = dataRow.Field<string>(map[nameof(PostalCode)].Column);
                StateProvince = new MultichannelOrderManagerStateProvince() { Abbreviation = dataRow.Field<string>(map[nameof(StateProvince)].Column) };
                City = dataRow.Field<string>(map[nameof(City)].Column);
                Type = dataRow.Field<char>(map[nameof(Type)].Column);
                County = new MultichannelOrderManagerCounty() { CountyCode = dataRow.Field<string>(map[nameof(County)].Column) };
                RTDTax = dataRow.Field<bool>(map[nameof(RTDTax)].Column);
                TaxRate = dataRow.Field<decimal>(map[nameof(TaxRate)].Column);
                Presence = dataRow.Field<bool>(map[nameof(Presence)].Column);
                Code1 = dataRow.Field<char>(map[nameof(Code1)].Column);
                Logic1 = dataRow.Field<bool>(map[nameof(Logic1)].Column);
                Warehouse = new MultichannelOrderManagerWarehouse() { Code = dataRow.Field<string>(map[nameof(Warehouse)].Column) };
                TaxShipping = dataRow.Field<bool>(map[nameof(TaxShipping)].Column);
                DoNotTaxExceedAmountTaxClass_A = dataRow.Field<bool>(map[nameof(DoNotTaxExceedAmountTaxClass_A)].Column);
                DoNotTaxExceedAmountTaxClass_B = dataRow.Field<bool>(map[nameof(DoNotTaxExceedAmountTaxClass_B)].Column);
                DoNotTaxExceedAmountTaxClass_C = dataRow.Field<bool>(map[nameof(DoNotTaxExceedAmountTaxClass_C)].Column);
                DoNotTaxExceedAmountTaxClass_D = dataRow.Field<bool>(map[nameof(DoNotTaxExceedAmountTaxClass_D)].Column);
                DoNotTaxExceedAmountTaxClass_E = dataRow.Field<bool>(map[nameof(DoNotTaxExceedAmountTaxClass_E)].Column);
                DoNotTaxShippingOnBoxesWithAllNonTaxableItems = dataRow.Field<bool>(map[nameof(DoNotTaxShippingOnBoxesWithAllNonTaxableItems)].Column);
                ExceedAmountTaxClass_A = dataRow.Field<decimal>(map[nameof(ExceedAmountTaxClass_A)].Column);
                ExceedAmountTaxClass_B = dataRow.Field<decimal>(map[nameof(ExceedAmountTaxClass_B)].Column);
                ExceedAmountTaxClass_C = dataRow.Field<decimal>(map[nameof(ExceedAmountTaxClass_C)].Column);
                ExceedAmountTaxClass_D = dataRow.Field<decimal>(map[nameof(ExceedAmountTaxClass_D)].Column);
                ExceedAmountTaxClass_E = dataRow.Field<decimal>(map[nameof(ExceedAmountTaxClass_E)].Column);
                FlagCapTaxClass_A = dataRow.Field<bool>(map[nameof(FlagCapTaxClass_A)].Column);
                FlagCapTaxClass_B = dataRow.Field<bool>(map[nameof(FlagCapTaxClass_B)].Column);
                FlagCapTaxClass_C = dataRow.Field<bool>(map[nameof(FlagCapTaxClass_C)].Column);
                FlagCapTaxClass_D = dataRow.Field<bool>(map[nameof(FlagCapTaxClass_D)].Column);
                FlagCapTaxClass_E = dataRow.Field<bool>(map[nameof(FlagCapTaxClass_E)].Column);
                MomObjectID = dataRow.Field<long>(map[nameof(MomObjectID)].Column);
                RateClass_A = dataRow.Field<decimal>(map[nameof(RateClass_A)].Column);
                RateClass_B = dataRow.Field<decimal>(map[nameof(RateClass_B)].Column);
                RateClass_C = dataRow.Field<decimal>(map[nameof(RateClass_C)].Column);
                RateClass_D = dataRow.Field<decimal>(map[nameof(RateClass_D)].Column);
                RateClass_E = dataRow.Field<decimal>(map[nameof(RateClass_E)].Column);
                TaxClass_A = dataRow.Field<bool>(map[nameof(TaxClass_A)].Column);
                TaxClass_B = dataRow.Field<bool>(map[nameof(TaxClass_B)].Column);
                TaxClass_C = dataRow.Field<bool>(map[nameof(TaxClass_C)].Column);
                TaxClass_D = dataRow.Field<bool>(map[nameof(TaxClass_D)].Column);
                TaxClass_E = dataRow.Field<bool>(map[nameof(TaxClass_E)].Column);
                TaxHandlingFeesPostalCodeTaxRateOnly = dataRow.Field<bool>(map[nameof(TaxHandlingFeesPostalCodeTaxRateOnly)].Column);
                TaxUpdate = dataRow.Field<bool>(map[nameof(TaxUpdate)].Column);   
                TotalCapTaxClass_A = dataRow.Field<decimal>(map[nameof(TotalCapTaxClass_A)].Column);
                TotalCapTaxClass_B = dataRow.Field<decimal>(map[nameof(TotalCapTaxClass_B)].Column);
                TotalCapTaxClass_C = dataRow.Field<decimal>(map[nameof(TotalCapTaxClass_C)].Column);
                TotalCapTaxClass_D = dataRow.Field<decimal>(map[nameof(TotalCapTaxClass_D)].Column);
                TotalCapTaxClass_E = dataRow.Field<decimal>(map[nameof(TotalCapTaxClass_E)].Column);
                LookupBy = dataRow.Field<string>(map[nameof(LookupBy)].Column);
                LookupOn = dataRow.Field<DateTime?>(map[nameof(LookupOn)].Column);
            }
        }

        /// <summary>
        /// Creates a <see cref="DataTable"/> that represents the database table of the current entity.
        /// </summary>
        /// <returns><see cref="DataTable"/> containing the columns and respective definitions of the associated external database table for the current entity.</returns>
        public override DataTable CreateDataTable()
        {
            WhippetDataRowImportMap map = CreateImportMap();
            DataTable table = new DataTable();

            DataColumn country = DataColumnFactory.CreateDataColumn(map[nameof(Country)].Column, typeof(string), false, 3);
            DataColumn postalCode = DataColumnFactory.CreateDataColumn(map[nameof(PostalCode)].Column, typeof(string), false, 7);
            DataColumn stateProvince = DataColumnFactory.CreateDataColumn(map[nameof(StateProvince)].Column, typeof(string), false, 3);
            DataColumn city = DataColumnFactory.CreateDataColumn(map[nameof(City)].Column, typeof(string), false, 30);
            DataColumn type = DataColumnFactory.CreateDataColumn(map[nameof(Type)].Column, typeof(char), false, 1);
            DataColumn county = DataColumnFactory.CreateDataColumn(map[nameof(County)].Column, typeof(string), false, 3);
            DataColumn rtdTax = DataColumnFactory.CreateDataColumn(map[nameof(RTDTax)].Column, typeof(bool), false);
            DataColumn code1 = DataColumnFactory.CreateDataColumn(map[nameof(Code1)].Column, typeof(char), false, 1);
            DataColumn logic1 = DataColumnFactory.CreateDataColumn(map[nameof(Logic1)].Column, typeof(bool), false);
            DataColumn doNotExceedAmountTaxClassA = DataColumnFactory.CreateDataColumn(map[nameof(DoNotTaxExceedAmountTaxClass_A)].Column, typeof(bool), false);
            DataColumn doNotExceedAmountTaxClassB = DataColumnFactory.CreateDataColumn(map[nameof(DoNotTaxExceedAmountTaxClass_B)].Column, typeof(bool), false);
            DataColumn doNotExceedAmountTaxClassC = DataColumnFactory.CreateDataColumn(map[nameof(DoNotTaxExceedAmountTaxClass_C)].Column, typeof(bool), false);
            DataColumn doNotExceedAmountTaxClassD = DataColumnFactory.CreateDataColumn(map[nameof(DoNotTaxExceedAmountTaxClass_D)].Column, typeof(bool), false);
            DataColumn doNotExceedAmountTaxClassE = DataColumnFactory.CreateDataColumn(map[nameof(DoNotTaxExceedAmountTaxClass_E)].Column, typeof(bool), false);
            DataColumn doNotTaxShipping = DataColumnFactory.CreateDataColumn(map[nameof(DoNotTaxShippingOnBoxesWithAllNonTaxableItems)].Column, typeof(bool), false);
            DataColumn exceedAmountTaxClassA = DataColumnFactory.CreateDataColumn(map[nameof(ExceedAmountTaxClass_A)].Column, typeof(decimal), false);
            DataColumn exceedAmountTaxClassB = DataColumnFactory.CreateDataColumn(map[nameof(ExceedAmountTaxClass_B)].Column, typeof(decimal), false);
            DataColumn exceedAmountTaxClassC = DataColumnFactory.CreateDataColumn(map[nameof(ExceedAmountTaxClass_C)].Column, typeof(decimal), false);
            DataColumn exceedAmountTaxClassD = DataColumnFactory.CreateDataColumn(map[nameof(ExceedAmountTaxClass_D)].Column, typeof(decimal), false);
            DataColumn exceedAmountTaxClassE = DataColumnFactory.CreateDataColumn(map[nameof(ExceedAmountTaxClass_E)].Column, typeof(decimal), false);
            DataColumn flagCapTaxClassA = DataColumnFactory.CreateDataColumn(map[nameof(FlagCapTaxClass_A)].Column, typeof(bool), false);
            DataColumn flagCapTaxClassB = DataColumnFactory.CreateDataColumn(map[nameof(FlagCapTaxClass_B)].Column, typeof(bool), false);
            DataColumn flagCapTaxClassC = DataColumnFactory.CreateDataColumn(map[nameof(FlagCapTaxClass_C)].Column, typeof(bool), false);
            DataColumn flagCapTaxClassD = DataColumnFactory.CreateDataColumn(map[nameof(FlagCapTaxClass_D)].Column, typeof(bool), false);
            DataColumn flagCapTaxClassE = DataColumnFactory.CreateDataColumn(map[nameof(FlagCapTaxClass_E)].Column, typeof(bool), false);
            DataColumn zipId = DataColumnFactory.CreateDataColumn(map[nameof(MomObjectID)].Column, typeof(long), false);
            DataColumn presence = DataColumnFactory.CreateDataColumn(map[nameof(Presence)].Column, typeof(bool), false);
            DataColumn rateClassA = DataColumnFactory.CreateDataColumn(map[nameof(RateClass_A)].Column, typeof(decimal), false);
            DataColumn rateClassB = DataColumnFactory.CreateDataColumn(map[nameof(RateClass_B)].Column, typeof(decimal), false);
            DataColumn rateClassC = DataColumnFactory.CreateDataColumn(map[nameof(RateClass_C)].Column, typeof(decimal), false);
            DataColumn rateClassD = DataColumnFactory.CreateDataColumn(map[nameof(RateClass_D)].Column, typeof(decimal), false);
            DataColumn rateClassE = DataColumnFactory.CreateDataColumn(map[nameof(RateClass_E)].Column, typeof(decimal), false);
            DataColumn taxClassA = DataColumnFactory.CreateDataColumn(map[nameof(TaxClass_A)].Column, typeof(bool), false);
            DataColumn taxClassB = DataColumnFactory.CreateDataColumn(map[nameof(TaxClass_B)].Column, typeof(bool), false);
            DataColumn taxClassC = DataColumnFactory.CreateDataColumn(map[nameof(TaxClass_C)].Column, typeof(bool), false);
            DataColumn taxClassD = DataColumnFactory.CreateDataColumn(map[nameof(TaxClass_D)].Column, typeof(bool), false);
            DataColumn taxClassE = DataColumnFactory.CreateDataColumn(map[nameof(TaxClass_E)].Column, typeof(bool), false);
            DataColumn handlingNationalTax = DataColumnFactory.CreateDataColumn(map[nameof(TaxHandlingFeesPostalCodeTaxRateOnly)].Column, typeof(bool), false);
            DataColumn taxRate = DataColumnFactory.CreateDataColumn(map[nameof(TaxRate)].Column, typeof(decimal), false);
            DataColumn taxShipping = DataColumnFactory.CreateDataColumn(map[nameof(TaxShipping)].Column, typeof(bool), false);
            DataColumn taxUpdate = DataColumnFactory.CreateDataColumn(map[nameof(TaxUpdate)].Column, typeof(bool), false);
            DataColumn totalCapA = DataColumnFactory.CreateDataColumn(map[nameof(TotalCapTaxClass_A)].Column, typeof(decimal), false);
            DataColumn totalCapB = DataColumnFactory.CreateDataColumn(map[nameof(TotalCapTaxClass_B)].Column, typeof(decimal), false);
            DataColumn totalCapC = DataColumnFactory.CreateDataColumn(map[nameof(TotalCapTaxClass_C)].Column, typeof(decimal), false);
            DataColumn totalCapD = DataColumnFactory.CreateDataColumn(map[nameof(TotalCapTaxClass_D)].Column, typeof(decimal), false);
            DataColumn totalCapE = DataColumnFactory.CreateDataColumn(map[nameof(TotalCapTaxClass_E)].Column, typeof(decimal), false);
            DataColumn warehouse = DataColumnFactory.CreateDataColumn(map[nameof(Warehouse)].Column, typeof(string), false, 6);
            DataColumn lookupBy = DataColumnFactory.CreateDataColumn(map[nameof(LookupBy)].Column, typeof(string), false, 3);
            DataColumn lookupOn = DataColumnFactory.CreateDataColumn(map[nameof(LookupOn)].Column, typeof(DateTime), true);

            table.Columns.AddRange(new[]
            {
                country,
                postalCode,
                stateProvince,
                city,
                type,
                county,
                rtdTax,
                code1,
                logic1,
                doNotExceedAmountTaxClassA,
                doNotExceedAmountTaxClassB,
                doNotExceedAmountTaxClassC,
                doNotExceedAmountTaxClassD,
                doNotExceedAmountTaxClassE,
                doNotTaxShipping,
                exceedAmountTaxClassA,
                exceedAmountTaxClassB,
                exceedAmountTaxClassC,
                exceedAmountTaxClassD,
                exceedAmountTaxClassE,
                flagCapTaxClassA,
                flagCapTaxClassB,
                flagCapTaxClassC,
                flagCapTaxClassD,
                flagCapTaxClassE,
                presence,
                rateClassA,
                rateClassB,
                rateClassC,
                rateClassD,
                rateClassE,
                taxClassA,
                taxClassB,
                taxClassC,
                taxClassD,
                taxClassE,
                handlingNationalTax,
                taxRate,
                taxShipping,
                taxUpdate,
                totalCapA,
                totalCapB,
                totalCapC,
                totalCapD,
                totalCapE,
                warehouse,
                lookupBy,
                lookupOn,
                zipId
            });

            table.PrimaryKey = new[] { zipId };

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
            return Equals(obj as IMultichannelOrderManagerPostalCode);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerPostalCode obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="IMultichannelOrderManagerPostalCode"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IMultichannelOrderManagerPostalCode"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerPostalCode a, IMultichannelOrderManagerPostalCode b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals =
                    a.Server.Equals(b.Server)
                        && String.Equals(a.PostalCode, b.PostalCode, StringComparison.InvariantCultureIgnoreCase)
                        && ((a.Country == null && b.Country == null) || (a.Country != null && a.Country.Equals(b.Country)))
                        && a.DoNotTaxExceedAmountTaxClass_A == b.DoNotTaxExceedAmountTaxClass_A
                        && a.DoNotTaxExceedAmountTaxClass_B == b.DoNotTaxExceedAmountTaxClass_B
                        && a.DoNotTaxExceedAmountTaxClass_C == b.DoNotTaxExceedAmountTaxClass_C
                        && a.DoNotTaxExceedAmountTaxClass_D == b.DoNotTaxExceedAmountTaxClass_D
                        && a.DoNotTaxExceedAmountTaxClass_E == b.DoNotTaxExceedAmountTaxClass_E
                        && a.DoNotTaxShippingOnBoxesWithAllNonTaxableItems == b.DoNotTaxShippingOnBoxesWithAllNonTaxableItems
                        && a.ExceedAmountTaxClass_A == b.ExceedAmountTaxClass_A
                        && a.ExceedAmountTaxClass_B == b.ExceedAmountTaxClass_B
                        && a.ExceedAmountTaxClass_C == b.ExceedAmountTaxClass_C
                        && a.ExceedAmountTaxClass_D == b.ExceedAmountTaxClass_D
                        && a.ExceedAmountTaxClass_E == b.ExceedAmountTaxClass_E
                        && a.FlagCapTaxClass_A == b.FlagCapTaxClass_A
                        && a.FlagCapTaxClass_B == b.FlagCapTaxClass_B
                        && a.FlagCapTaxClass_C == b.FlagCapTaxClass_C
                        && a.FlagCapTaxClass_D == b.FlagCapTaxClass_D
                        && a.FlagCapTaxClass_E == b.FlagCapTaxClass_E
                        && String.Equals(a.LookupBy, b.LookupBy, StringComparison.InvariantCultureIgnoreCase)
                        && a.LookupOn.GetValueOrDefault().Equals(b.LookupOn.GetValueOrDefault())
                        && a.Presence == b.Presence
                        && a.RateClass_A == b.RateClass_A
                        && a.RateClass_B == b.RateClass_B
                        && a.RateClass_C == b.RateClass_C
                        && a.RateClass_D == b.RateClass_D
                        && a.RateClass_E == b.RateClass_E
                        && a.TaxClass_A == b.TaxClass_A
                        && a.TaxClass_B == b.TaxClass_B
                        && a.TaxClass_C == b.TaxClass_C
                        && a.TaxClass_D == b.TaxClass_D
                        && a.TaxClass_E == b.TaxClass_E
                        && a.TaxHandlingFeesPostalCodeTaxRateOnly == b.TaxHandlingFeesPostalCodeTaxRateOnly
                        && a.TaxRate == b.TaxRate
                        && a.TaxShipping == b.TaxShipping
                        && a.TaxUpdate == b.TaxUpdate
                        && a.TotalCapTaxClass_A == b.TotalCapTaxClass_A
                        && a.TotalCapTaxClass_B == b.TotalCapTaxClass_B
                        && a.TotalCapTaxClass_C == b.TotalCapTaxClass_C
                        && a.TotalCapTaxClass_D == b.TotalCapTaxClass_D
                        && a.TotalCapTaxClass_E == b.TotalCapTaxClass_E
                        && ((a.Warehouse == null && b.Warehouse == null) || (a.Warehouse != null && a.Warehouse.Equals(b.Warehouse)))
                        && ((a.County == null && b.County == null) || (a.County != null && a.County.Equals(b.County)))
                        && ((a.StateProvince == null && b.StateProvince == null) || (a.StateProvince != null && a.StateProvince.Equals(b.StateProvince)));
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
        public virtual int GetHashCode(IMultichannelOrderManagerPostalCode obj)
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
        /// Creates a duplicate instance of the current object with the optional <see cref="Guid"/> that represents the user ID of the user who instantiated the new instance.
        /// </summary>
        /// <typeparam name="TObject">Type of object to return from the operation.</typeparam>
        /// <param name="createdBy"><see cref="Guid"/> ID of the user who instantiated the new instance.</param>
        /// <returns>Object of type <typeparamref name="TObject"/>.</returns>
        public TObject Clone<TObject>(Guid? createdBy = null)
        {
            return (TObject)(Clone());
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public object Clone()
        {
            MultichannelOrderManagerPostalCode postalCode = new MultichannelOrderManagerPostalCode();

            if (!String.IsNullOrWhiteSpace(City))
            {
                postalCode.City = City;
            }

            postalCode.Code1 = Code1;
            postalCode.Country = Country.Clone<MultichannelOrderManagerCountry>();
            postalCode.County = County.Clone<MultichannelOrderManagerCounty>();
            postalCode.DoNotTaxExceedAmountTaxClass_A = DoNotTaxExceedAmountTaxClass_A;
            postalCode.DoNotTaxExceedAmountTaxClass_B = DoNotTaxExceedAmountTaxClass_B;
            postalCode.DoNotTaxExceedAmountTaxClass_C = DoNotTaxExceedAmountTaxClass_C;
            postalCode.DoNotTaxExceedAmountTaxClass_D = DoNotTaxExceedAmountTaxClass_D;
            postalCode.DoNotTaxExceedAmountTaxClass_E = DoNotTaxExceedAmountTaxClass_E;
            postalCode.DoNotTaxShippingOnBoxesWithAllNonTaxableItems = DoNotTaxShippingOnBoxesWithAllNonTaxableItems;
            postalCode.ExceedAmountTaxClass_A = ExceedAmountTaxClass_A;
            postalCode.ExceedAmountTaxClass_B = ExceedAmountTaxClass_B;
            postalCode.ExceedAmountTaxClass_C = ExceedAmountTaxClass_C;
            postalCode.ExceedAmountTaxClass_D = ExceedAmountTaxClass_D;
            postalCode.ExceedAmountTaxClass_E = ExceedAmountTaxClass_E;
            postalCode.FlagCapTaxClass_A = FlagCapTaxClass_A;
            postalCode.FlagCapTaxClass_B = FlagCapTaxClass_B;
            postalCode.FlagCapTaxClass_C = FlagCapTaxClass_C;
            postalCode.FlagCapTaxClass_D = FlagCapTaxClass_D;
            postalCode.FlagCapTaxClass_E = FlagCapTaxClass_E;
            postalCode.ID = ID;
            postalCode.Logic1 = Logic1;
            postalCode.LookupBy = LookupBy;
            postalCode.LookupOn = LookupOn;
            postalCode.MomObjectID = MomObjectID;

            if (!String.IsNullOrWhiteSpace(PostalCode))
            {
                postalCode.PostalCode = PostalCode;
            }

            postalCode.Presence = Presence;
            postalCode.RateClass_A = RateClass_A;
            postalCode.RateClass_B = RateClass_B;
            postalCode.RateClass_C = RateClass_C;
            postalCode.RateClass_D = RateClass_D;
            postalCode.RateClass_E = RateClass_E;
            postalCode.RTDTax = RTDTax;
            postalCode.Server = Server.Clone<MultichannelOrderManagerServer>();
            postalCode.StateProvince = StateProvince.Clone<MultichannelOrderManagerStateProvince>();
            postalCode.TaxClass_A = TaxClass_A;
            postalCode.TaxClass_B = TaxClass_B;
            postalCode.TaxClass_C = TaxClass_C;
            postalCode.TaxClass_D = TaxClass_D;
            postalCode.TaxClass_E = TaxClass_E;
            postalCode.TaxHandlingFeesPostalCodeTaxRateOnly = TaxHandlingFeesPostalCodeTaxRateOnly;
            postalCode.TaxRate = TaxRate;
            postalCode.TaxShipping = TaxShipping;
            postalCode.TaxUpdate = TaxUpdate;
            postalCode.TotalCapTaxClass_A = TotalCapTaxClass_A;
            postalCode.TotalCapTaxClass_B = TotalCapTaxClass_B;
            postalCode.TotalCapTaxClass_C = TotalCapTaxClass_C;
            postalCode.TotalCapTaxClass_D = TotalCapTaxClass_D;
            postalCode.TotalCapTaxClass_E = TotalCapTaxClass_E;
            postalCode.Type = Type;
            postalCode.Warehouse = Warehouse.Clone<MultichannelOrderManagerWarehouse>();

            return postalCode;
        }

        /// <summary>
        /// Compares the current instance to the specified <see cref="IMultichannelOrderManagerPostalCode"/> for determining sort order.
        /// </summary>
        /// <param name="obj"><see cref="IMultichannelOrderManagerPostalCode"/> to compare against.</param>
        /// <returns>A signed integer that indicates the relative values of the current object and <paramref name="obj"/>. Values less than zero indicates that the current object precedes <paramref name="obj"/>; zero indicates that the values are equal; and values greater than zero indicate that the current object follows <paramref name="obj"/>.</returns>
        public virtual int CompareTo(IMultichannelOrderManagerPostalCode obj)
        {
            return CaseInsensitiveStringComparer.Instance.Compare(PostalCode, obj?.PostalCode);
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return PostalCode;
        }

    }
}
