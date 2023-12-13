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
    /// Represents a state or province and its associated tax information in M.O.M.
    /// </summary>
    public class MultichannelOrderManagerStateProvince : MultichannelOrderManagerEntity, IWhippetEntity, IWhippetEntityExternalDataRowImportMapper, IMultichannelOrderManagerStateProvince, IEqualityComparer<IMultichannelOrderManagerStateProvince>, IMultichannelOrderManagerEntity, IWhippetEntityDynamicImportMapper, IWhippetCloneable, IComparable<IMultichannelOrderManagerStateProvince>
    {
        private WhippetDataRowImportMap _internalMap;

        private MultichannelOrderManagerCountry _country;

        private MultichannelOrderManagerWarehouse _warehouse;

        private string _abbreviation;
        private string _name;
        private string _low;
        private string _high;
        private string _lookupBy;

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
        IMultichannelOrderManagerCountry IMultichannelOrderManagerStateProvince.Country
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
        /// Gets or sets the state abbreviation.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Abbreviation
        {
            get
            {
                return _abbreviation;
            }
            set
            {
                _abbreviation = this.CheckLengthRequirement(value, ImportMap[nameof(Abbreviation)].Column).Trim();
            }
        }

        /// <summary>
        /// Gets or sets the name of the state or province.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = this.CheckLengthRequirement(value, ImportMap[nameof(Name)].Column)?.Trim();
            }
        }

        /// <summary>
        /// This property is reserved for use by M.O.M.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Low
        {
            get
            {
                return _low;
            }
            set
            {
                _low = this.CheckLengthRequirement(value, ImportMap[nameof(Low)].Column);
            }
        }

        /// <summary>
        /// This property is reserved for use by M.O.M.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string High
        {
            get
            {
                return _high;
            }
            set
            {
                _high = this.CheckLengthRequirement(value, ImportMap[nameof(High)].Column);
            }
        }

        /// <summary>
        /// Gets or sets the tax rate for the state or province.
        /// </summary>
        public virtual decimal TaxRate
        { get; set; }

        /// <summary>
        /// Gets or sets the finance charges rate for the state or province.
        /// </summary>
        public virtual decimal FinanceChargesRate
        { get; set; }

        /// <summary>
        /// Indicates whether the state or province is sales tax class A taxable.
        /// </summary>
        public virtual bool TaxClass_A
        { get; set; }

        /// <summary>
        /// Indicates whether the state or province is sales tax class B taxable.
        /// </summary>
        public virtual bool TaxClass_B
        { get; set; }

        /// <summary>
        /// Indicates whether the state or province is sales tax class C taxable.
        /// </summary>
        public virtual bool TaxClass_C
        { get; set; }

        /// <summary>
        /// Indicates whether the state or province is sales tax class D taxable.
        /// </summary>
        public virtual bool TaxClass_D
        { get; set; }

        /// <summary>
        /// Indicates whether the state or province is sales tax class E taxable.
        /// </summary>
        public virtual bool TaxClass_E
        { get; set; }

        /// <summary>
        /// Indicates whether shipping is taxed for the state or province.
        /// </summary>
        public virtual bool TaxShipping
        { get; set; }

        /// <summary>
        /// This property is reserved for use by M.O.M.
        /// </summary>
        public virtual bool Presence
        { get; set; }

        /// <summary>
        /// Gets or sets the state or province sales tax rate for class A.
        /// </summary>
        public virtual decimal RateClass_A
        { get; set; }

        /// <summary>
        /// Gets or sets the state or province sales tax rate for class B.
        /// </summary>
        public virtual decimal RateClass_B
        { get; set; }

        /// <summary>
        /// Gets or sets the state or province sales tax rate for class C.
        /// </summary>
        public virtual decimal RateClass_C
        { get; set; }

        /// <summary>
        /// Gets or sets the state or province sales tax rate for class D.
        /// </summary>
        public virtual decimal RateClass_D
        { get; set; }

        /// <summary>
        /// Gets or sets the state or province sales tax rate for class E.
        /// </summary>
        public virtual decimal RateClass_E
        { get; set; }

        /// <summary>
        /// Specifies the (primary) warehouse that serves the state/province.
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
        /// Specifies the (primary) warehouse that serves the state/province.
        /// </summary>
        IMultichannelOrderManagerWarehouse IMultichannelOrderManagerStateProvince.Warehouse
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
        /// Indicates whether to tax handling fees only at national tax rates.
        /// </summary>
        public virtual bool TaxHandlingFeesNationalTaxRateOnly
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
                return MultichannelOrderManagerDatabaseConstants.Tables.STATE;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerStateProvince"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerStateProvince()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerStateProvince"/> with the specified ID.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        public MultichannelOrderManagerStateProvince(int id)
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
            WhippetDataRowImportMapEntry stateId = new WhippetDataRowImportMapEntry(nameof(MomObjectID), MultichannelOrderManagerDatabaseConstants.Columns.STATE_ID);
            WhippetDataRowImportMapEntry country = new WhippetDataRowImportMapEntry(nameof(Country), MultichannelOrderManagerDatabaseConstants.Columns.COUNTRY);
            WhippetDataRowImportMapEntry state = new WhippetDataRowImportMapEntry(nameof(Abbreviation), MultichannelOrderManagerDatabaseConstants.Columns.STATE);
            WhippetDataRowImportMapEntry name = new WhippetDataRowImportMapEntry(nameof(Name), MultichannelOrderManagerDatabaseConstants.Columns.NAME);
            WhippetDataRowImportMapEntry low = new WhippetDataRowImportMapEntry(nameof(Low), MultichannelOrderManagerDatabaseConstants.Columns.LOW);
            WhippetDataRowImportMapEntry high = new WhippetDataRowImportMapEntry(nameof(High), MultichannelOrderManagerDatabaseConstants.Columns.HIGH);
            WhippetDataRowImportMapEntry taxRate = new WhippetDataRowImportMapEntry(nameof(TaxRate), MultichannelOrderManagerDatabaseConstants.Columns.TAXRATE);
            WhippetDataRowImportMapEntry finRate = new WhippetDataRowImportMapEntry(nameof(FinanceChargesRate), MultichannelOrderManagerDatabaseConstants.Columns.FIN_RATE);
            WhippetDataRowImportMapEntry taxClassA = new WhippetDataRowImportMapEntry(nameof(TaxClass_A), MultichannelOrderManagerDatabaseConstants.Columns.TAX_CLASSA);
            WhippetDataRowImportMapEntry taxClassB = new WhippetDataRowImportMapEntry(nameof(TaxClass_B), MultichannelOrderManagerDatabaseConstants.Columns.TAX_CLASSB);
            WhippetDataRowImportMapEntry taxClassC = new WhippetDataRowImportMapEntry(nameof(TaxClass_C), MultichannelOrderManagerDatabaseConstants.Columns.TAX_CLASSC);
            WhippetDataRowImportMapEntry taxClassD = new WhippetDataRowImportMapEntry(nameof(TaxClass_D), MultichannelOrderManagerDatabaseConstants.Columns.TAX_CLASSD);
            WhippetDataRowImportMapEntry taxClassE = new WhippetDataRowImportMapEntry(nameof(TaxClass_E), MultichannelOrderManagerDatabaseConstants.Columns.TAX_CLASSE);
            WhippetDataRowImportMapEntry taxShip = new WhippetDataRowImportMapEntry(nameof(TaxShipping), MultichannelOrderManagerDatabaseConstants.Columns.TAXSHIP);
            WhippetDataRowImportMapEntry presence = new WhippetDataRowImportMapEntry(nameof(Presence), MultichannelOrderManagerDatabaseConstants.Columns.PRESENCE);
            WhippetDataRowImportMapEntry rateClassA = new WhippetDataRowImportMapEntry(nameof(RateClass_A), MultichannelOrderManagerDatabaseConstants.Columns.RATECLASSA);
            WhippetDataRowImportMapEntry rateClassB = new WhippetDataRowImportMapEntry(nameof(RateClass_B), MultichannelOrderManagerDatabaseConstants.Columns.RATECLASSB);
            WhippetDataRowImportMapEntry rateClassC = new WhippetDataRowImportMapEntry(nameof(RateClass_C), MultichannelOrderManagerDatabaseConstants.Columns.RATECLASSC);
            WhippetDataRowImportMapEntry rateClassD = new WhippetDataRowImportMapEntry(nameof(RateClass_D), MultichannelOrderManagerDatabaseConstants.Columns.RATECLASSD);
            WhippetDataRowImportMapEntry rateClassE = new WhippetDataRowImportMapEntry(nameof(RateClass_E), MultichannelOrderManagerDatabaseConstants.Columns.RATECLASSE);
            WhippetDataRowImportMapEntry lcapA = new WhippetDataRowImportMapEntry(nameof(FlagCapTaxClass_A), MultichannelOrderManagerDatabaseConstants.Columns.S_LCAPA);
            WhippetDataRowImportMapEntry lcapB = new WhippetDataRowImportMapEntry(nameof(FlagCapTaxClass_B), MultichannelOrderManagerDatabaseConstants.Columns.S_LCAPB);
            WhippetDataRowImportMapEntry lcapC = new WhippetDataRowImportMapEntry(nameof(FlagCapTaxClass_C), MultichannelOrderManagerDatabaseConstants.Columns.S_LCAPC);
            WhippetDataRowImportMapEntry lcapD = new WhippetDataRowImportMapEntry(nameof(FlagCapTaxClass_D), MultichannelOrderManagerDatabaseConstants.Columns.S_LCAPD);
            WhippetDataRowImportMapEntry lcapE = new WhippetDataRowImportMapEntry(nameof(FlagCapTaxClass_E), MultichannelOrderManagerDatabaseConstants.Columns.S_LCAPE);
            WhippetDataRowImportMapEntry stopTaxA = new WhippetDataRowImportMapEntry(nameof(TotalCapTaxClass_A), MultichannelOrderManagerDatabaseConstants.Columns.S_NCAPA);
            WhippetDataRowImportMapEntry stopTaxB = new WhippetDataRowImportMapEntry(nameof(TotalCapTaxClass_B), MultichannelOrderManagerDatabaseConstants.Columns.S_NCAPB);
            WhippetDataRowImportMapEntry stopTaxC = new WhippetDataRowImportMapEntry(nameof(TotalCapTaxClass_C), MultichannelOrderManagerDatabaseConstants.Columns.S_NCAPC);
            WhippetDataRowImportMapEntry stopTaxD = new WhippetDataRowImportMapEntry(nameof(TotalCapTaxClass_D), MultichannelOrderManagerDatabaseConstants.Columns.S_NCAPD);
            WhippetDataRowImportMapEntry stopTaxE = new WhippetDataRowImportMapEntry(nameof(TotalCapTaxClass_E), MultichannelOrderManagerDatabaseConstants.Columns.S_NCAPE);
            WhippetDataRowImportMapEntry exceedA = new WhippetDataRowImportMapEntry(nameof(ExceedAmountTaxClass_A), MultichannelOrderManagerDatabaseConstants.Columns.S_NTAXITA);
            WhippetDataRowImportMapEntry exceedB = new WhippetDataRowImportMapEntry(nameof(ExceedAmountTaxClass_B), MultichannelOrderManagerDatabaseConstants.Columns.S_NTAXITB);
            WhippetDataRowImportMapEntry exceedC = new WhippetDataRowImportMapEntry(nameof(ExceedAmountTaxClass_C), MultichannelOrderManagerDatabaseConstants.Columns.S_NTAXITC);
            WhippetDataRowImportMapEntry exceedD = new WhippetDataRowImportMapEntry(nameof(ExceedAmountTaxClass_D), MultichannelOrderManagerDatabaseConstants.Columns.S_NTAXITD);
            WhippetDataRowImportMapEntry exceedE = new WhippetDataRowImportMapEntry(nameof(ExceedAmountTaxClass_E), MultichannelOrderManagerDatabaseConstants.Columns.S_NTAXITE);
            WhippetDataRowImportMapEntry onlyTaxA = new WhippetDataRowImportMapEntry(nameof(DoNotTaxExceedAmountTaxClass_A), MultichannelOrderManagerDatabaseConstants.Columns.STAXTHRESA);
            WhippetDataRowImportMapEntry onlyTaxB = new WhippetDataRowImportMapEntry(nameof(DoNotTaxExceedAmountTaxClass_B), MultichannelOrderManagerDatabaseConstants.Columns.STAXTHRESB);
            WhippetDataRowImportMapEntry onlyTaxC = new WhippetDataRowImportMapEntry(nameof(DoNotTaxExceedAmountTaxClass_C), MultichannelOrderManagerDatabaseConstants.Columns.STAXTHRESC);
            WhippetDataRowImportMapEntry onlyTaxD = new WhippetDataRowImportMapEntry(nameof(DoNotTaxExceedAmountTaxClass_D), MultichannelOrderManagerDatabaseConstants.Columns.STAXTHRESD);
            WhippetDataRowImportMapEntry onlyTaxE = new WhippetDataRowImportMapEntry(nameof(DoNotTaxExceedAmountTaxClass_E), MultichannelOrderManagerDatabaseConstants.Columns.STAXTHRESE);
            WhippetDataRowImportMapEntry taxHandling = new WhippetDataRowImportMapEntry(nameof(TaxHandlingFeesNationalTaxRateOnly), MultichannelOrderManagerDatabaseConstants.Columns.TAXHAND);
            WhippetDataRowImportMapEntry taxUpdate = new WhippetDataRowImportMapEntry(nameof(TaxUpdate), MultichannelOrderManagerDatabaseConstants.Columns.TAXUPDATE);
            WhippetDataRowImportMapEntry lookupBy = new WhippetDataRowImportMapEntry(nameof(LookupBy), MultichannelOrderManagerDatabaseConstants.Columns.LU_BY);
            WhippetDataRowImportMapEntry lookupOn = new WhippetDataRowImportMapEntry(nameof(LookupOn), MultichannelOrderManagerDatabaseConstants.Columns.LU_ON);
            WhippetDataRowImportMapEntry nonTaxBox = new WhippetDataRowImportMapEntry(nameof(DoNotTaxShippingOnBoxesWithAllNonTaxableItems), MultichannelOrderManagerDatabaseConstants.Columns.NONTAXBOX);
            WhippetDataRowImportMapEntry warehouse = new WhippetDataRowImportMapEntry(nameof(Warehouse), MultichannelOrderManagerDatabaseConstants.Columns.WAREHOUSE);

            return new WhippetDataRowImportMap(new[]
            {
                stateId,
                country,
                state,
                name,
                low,
                high,
                taxRate,
                finRate,
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
                lookupOn,
                nonTaxBox,
                warehouse
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

                Abbreviation = dataRow.Field<string>(map[nameof(Abbreviation)].Column);
                Country = new MultichannelOrderManagerCountry() { CountryCode = dataRow.Field<string>(map[nameof(Country)].Column) };
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
                FinanceChargesRate = dataRow.Field<decimal>(map[nameof(FinanceChargesRate)].Column);
                FlagCapTaxClass_A = dataRow.Field<bool>(map[nameof(FlagCapTaxClass_A)].Column);
                FlagCapTaxClass_B = dataRow.Field<bool>(map[nameof(FlagCapTaxClass_B)].Column);
                FlagCapTaxClass_C = dataRow.Field<bool>(map[nameof(FlagCapTaxClass_C)].Column);
                FlagCapTaxClass_D = dataRow.Field<bool>(map[nameof(FlagCapTaxClass_D)].Column);
                FlagCapTaxClass_E = dataRow.Field<bool>(map[nameof(FlagCapTaxClass_E)].Column);
                High = dataRow.Field<string>(map[nameof(High)].Column);
                MomObjectID = dataRow.Field<long>(map[nameof(MomObjectID)].Column);
                Low = dataRow.Field<string>(map[nameof(Low)].Column);
                Name = dataRow.Field<string>(map[nameof(Name)].Column);
                Presence = dataRow.Field<bool>(map[nameof(Presence)].Column);
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
                TaxHandlingFeesNationalTaxRateOnly = dataRow.Field<bool>(map[nameof(TaxHandlingFeesNationalTaxRateOnly)].Column);
                TaxRate = dataRow.Field<decimal>(map[nameof(TaxRate)].Column);
                TaxShipping = dataRow.Field<bool>(map[nameof(TaxShipping)].Column);
                TaxUpdate = dataRow.Field<bool>(map[nameof(TaxUpdate)].Column);
                TotalCapTaxClass_A = dataRow.Field<decimal>(map[nameof(TotalCapTaxClass_A)].Column);
                TotalCapTaxClass_B = dataRow.Field<decimal>(map[nameof(TotalCapTaxClass_B)].Column);
                TotalCapTaxClass_C = dataRow.Field<decimal>(map[nameof(TotalCapTaxClass_C)].Column);
                TotalCapTaxClass_D = dataRow.Field<decimal>(map[nameof(TotalCapTaxClass_D)].Column);
                TotalCapTaxClass_E = dataRow.Field<decimal>(map[nameof(TotalCapTaxClass_E)].Column);
                Warehouse = new MultichannelOrderManagerWarehouse() { Code = dataRow.Field<string>(map[nameof(Warehouse)].Column) };
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

            DataColumn abbreviation = DataColumnFactory.CreateDataColumn(map[nameof(Abbreviation)].Column, typeof(string), false, 3);
            DataColumn country = DataColumnFactory.CreateDataColumn(map[nameof(Country)].Column, typeof(string), false, 3);
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
            DataColumn financeCharge = DataColumnFactory.CreateDataColumn(map[nameof(FinanceChargesRate)].Column, typeof(decimal), false);
            DataColumn flagCapTaxClassA = DataColumnFactory.CreateDataColumn(map[nameof(FlagCapTaxClass_A)].Column, typeof(bool), false);
            DataColumn flagCapTaxClassB = DataColumnFactory.CreateDataColumn(map[nameof(FlagCapTaxClass_B)].Column, typeof(bool), false);
            DataColumn flagCapTaxClassC = DataColumnFactory.CreateDataColumn(map[nameof(FlagCapTaxClass_C)].Column, typeof(bool), false);
            DataColumn flagCapTaxClassD = DataColumnFactory.CreateDataColumn(map[nameof(FlagCapTaxClass_D)].Column, typeof(bool), false);
            DataColumn flagCapTaxClassE = DataColumnFactory.CreateDataColumn(map[nameof(FlagCapTaxClass_E)].Column, typeof(bool), false);
            DataColumn high = DataColumnFactory.CreateDataColumn(map[nameof(High)].Column, typeof(string), false, 3);
            DataColumn low = DataColumnFactory.CreateDataColumn(map[nameof(Low)].Column, typeof(string), false, 3);
            DataColumn stateId = DataColumnFactory.CreateDataColumn(map[nameof(MomObjectID)].Column, typeof(long), false);
            DataColumn name = DataColumnFactory.CreateDataColumn(map[nameof(Name)].Column, typeof(string), false, 25);
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
            DataColumn handlingNationalTax = DataColumnFactory.CreateDataColumn(map[nameof(TaxHandlingFeesNationalTaxRateOnly)].Column, typeof(bool), false);
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
                abbreviation,
                country,
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
                financeCharge,
                flagCapTaxClassA,
                flagCapTaxClassB,
                flagCapTaxClassC,
                flagCapTaxClassD,
                flagCapTaxClassE,
                high,
                low,
                stateId,
                name,
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
                lookupOn
            });

            table.PrimaryKey = new[] { stateId };

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
        /// Imports the specified <see langword="dynamic"/> object containing information needed to populate the <see cref="IWhippetEntity"/>.
        /// </summary>
        /// <param name="dynObj"><see langword="dynamic"/> object containing the data to import.</param>
        /// <exception cref="ArgumentNullException" />
        public override void ImportObject(dynamic dynObj)
        {
            if (dynObj == null)
            {
                throw new ArgumentNullException(nameof(dynObj));
            }
            else
            {
                DataTable table = CreateDataTable();
                DataRow row = table.NewRow();

                object rowValue = null;

                foreach (DataColumn column in table.Columns)
                {
                    rowValue = Dynamic.InvokeGet(dynObj, column.ColumnName);

                    if (rowValue == null)
                    {
                        if (column.DataType.Equals(typeof(char)))
                        {
                            rowValue = ' ';
                        }
                        else if (column.DataType.Equals(typeof(string)))
                        {
                            rowValue = String.Empty;
                        }
                        else if (column.DataType.Equals(typeof(bool)))
                        {
                            rowValue = default(bool);
                        }
                        else
                        {
                            rowValue = DBNull.Value;
                        }
                    }

                    row[column] = rowValue;
                }

                ImportDataRow(row);
            }
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IMultichannelOrderManagerStateProvince);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerStateProvince obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="IMultichannelOrderManagerStateProvince"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IMultichannelOrderManagerStateProvince"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerStateProvince a, IMultichannelOrderManagerStateProvince b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals =
                    a.Server.Equals(b.Server)
                        && String.Equals(a.Abbreviation, b.Abbreviation, StringComparison.InvariantCultureIgnoreCase)
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
                        && a.FinanceChargesRate == b.FinanceChargesRate
                        && a.FlagCapTaxClass_A == b.FlagCapTaxClass_A
                        && a.FlagCapTaxClass_B == b.FlagCapTaxClass_B
                        && a.FlagCapTaxClass_C == b.FlagCapTaxClass_C
                        && a.FlagCapTaxClass_D == b.FlagCapTaxClass_D
                        && a.FlagCapTaxClass_E == b.FlagCapTaxClass_E
                        && String.Equals(a.High, b.High, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.LookupBy, b.LookupBy, StringComparison.InvariantCultureIgnoreCase)
                        && a.LookupOn.GetValueOrDefault().Equals(b.LookupOn.GetValueOrDefault())
                        && String.Equals(a.Low, b.Low, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase)
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
                        && a.TaxHandlingFeesNationalTaxRateOnly == b.TaxHandlingFeesNationalTaxRateOnly
                        && a.TaxRate == b.TaxRate
                        && a.TaxShipping == b.TaxShipping
                        && a.TaxUpdate == b.TaxUpdate
                        && a.TotalCapTaxClass_A == b.TotalCapTaxClass_A
                        && a.TotalCapTaxClass_B == b.TotalCapTaxClass_B
                        && a.TotalCapTaxClass_C == b.TotalCapTaxClass_C
                        && a.TotalCapTaxClass_D == b.TotalCapTaxClass_D
                        && a.TotalCapTaxClass_E == b.TotalCapTaxClass_E
                        && ((a.Warehouse == null && b.Warehouse == null) || (a.Warehouse != null && a.Warehouse.Equals(b.Warehouse)));
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
        public virtual int GetHashCode(IMultichannelOrderManagerStateProvince obj)
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
            return Name;
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
            MultichannelOrderManagerStateProvince stateProvince = new MultichannelOrderManagerStateProvince();

            if (!String.IsNullOrWhiteSpace(Abbreviation))
            {
                stateProvince.Abbreviation = Abbreviation;
            }

            stateProvince.Country = Country.Clone<MultichannelOrderManagerCountry>();
            stateProvince.DoNotTaxExceedAmountTaxClass_A = DoNotTaxExceedAmountTaxClass_A;
            stateProvince.DoNotTaxExceedAmountTaxClass_B = DoNotTaxExceedAmountTaxClass_B;
            stateProvince.DoNotTaxExceedAmountTaxClass_C = DoNotTaxExceedAmountTaxClass_C;
            stateProvince.DoNotTaxExceedAmountTaxClass_D = DoNotTaxExceedAmountTaxClass_D;
            stateProvince.DoNotTaxExceedAmountTaxClass_E = DoNotTaxExceedAmountTaxClass_E;
            stateProvince.DoNotTaxShippingOnBoxesWithAllNonTaxableItems = DoNotTaxShippingOnBoxesWithAllNonTaxableItems;
            stateProvince.ExceedAmountTaxClass_A = ExceedAmountTaxClass_A;
            stateProvince.ExceedAmountTaxClass_B = ExceedAmountTaxClass_B;
            stateProvince.ExceedAmountTaxClass_C = ExceedAmountTaxClass_C;
            stateProvince.ExceedAmountTaxClass_D = ExceedAmountTaxClass_D;
            stateProvince.ExceedAmountTaxClass_E = ExceedAmountTaxClass_E;
            stateProvince.FinanceChargesRate = FinanceChargesRate;
            stateProvince.FlagCapTaxClass_A = FlagCapTaxClass_A;
            stateProvince.FlagCapTaxClass_B = FlagCapTaxClass_B;
            stateProvince.FlagCapTaxClass_C = FlagCapTaxClass_C;
            stateProvince.FlagCapTaxClass_D = FlagCapTaxClass_D;
            stateProvince.FlagCapTaxClass_E = FlagCapTaxClass_E;

            if (!String.IsNullOrWhiteSpace(High))
            {
                stateProvince.High = High;
            }

            stateProvince.ID = ID;
            stateProvince.LookupBy = LookupBy;
            stateProvince.LookupOn = LookupOn;

            if (!String.IsNullOrWhiteSpace(Low))
            {
                stateProvince.Low = Low;
            }

            stateProvince.MomObjectID = MomObjectID;

            if (!String.IsNullOrWhiteSpace(Name))
            {
                stateProvince.Name = Name;
            }

            stateProvince.Presence = Presence;
            stateProvince.RateClass_A = RateClass_A;
            stateProvince.RateClass_B = RateClass_B;
            stateProvince.RateClass_C = RateClass_C;
            stateProvince.RateClass_D = RateClass_D;
            stateProvince.RateClass_E = RateClass_E;
            stateProvince.Server = Server.Clone<MultichannelOrderManagerServer>();
            stateProvince.TaxClass_A = TaxClass_A;
            stateProvince.TaxClass_B = TaxClass_B;
            stateProvince.TaxClass_C = TaxClass_C;
            stateProvince.TaxClass_D = TaxClass_D;
            stateProvince.TaxClass_E = TaxClass_E;
            stateProvince.TaxHandlingFeesNationalTaxRateOnly = TaxHandlingFeesNationalTaxRateOnly;
            stateProvince.TaxRate = TaxRate;
            stateProvince.TaxShipping = TaxShipping;
            stateProvince.TaxUpdate = TaxUpdate;
            stateProvince.TotalCapTaxClass_A = TotalCapTaxClass_A;
            stateProvince.TotalCapTaxClass_B = TotalCapTaxClass_B;
            stateProvince.TotalCapTaxClass_C = TotalCapTaxClass_C;
            stateProvince.TotalCapTaxClass_D = TotalCapTaxClass_D;
            stateProvince.TotalCapTaxClass_E = TotalCapTaxClass_E;
            stateProvince.Warehouse = Warehouse.Clone<MultichannelOrderManagerWarehouse>();

            return stateProvince;
        }

        /// <summary>
        /// Compares the current instance to the specified <see cref="IMultichannelOrderManagerStateProvince"/> for determining sort order.
        /// </summary>
        /// <param name="obj"><see cref="IMultichannelOrderManagerStateProvince"/> to compare against.</param>
        /// <returns>A signed integer that indicates the relative values of the current object and <paramref name="obj"/>. Values less than zero indicates that the current object precedes <paramref name="obj"/>; zero indicates that the values are equal; and values greater than zero indicate that the current object follows <paramref name="obj"/>.</returns>
        public virtual int CompareTo(IMultichannelOrderManagerStateProvince obj)
        {
            return CaseInsensitiveStringComparer.Instance.Compare(Name, obj?.Name);
        }

    }
}
