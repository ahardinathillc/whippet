using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Extensions;
using Athi.Whippet.Collections.Comparers;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents a county in the Multichannel Order Manager (M.O.M.) database.
    /// </summary>
    public class MultichannelOrderManagerCounty : MultichannelOrderManagerEntity, IWhippetEntity, IMultichannelOrderManagerEntity, IWhippetEntityExternalDataRowImportMapper, IMultichannelOrderManagerCounty, IEqualityComparer<IMultichannelOrderManagerCounty>, IWhippetCloneable, IComparable<IMultichannelOrderManagerCounty>
    {
        private string _county;
        private string _fips;
        private string _name;
        private string _timeZone;
        private string _msa;
        private string _lookupBy;

        private MultichannelOrderManagerWarehouse _warehouse;

        private MultichannelOrderManagerStateProvince _stateProvince;

        private MultichannelOrderManagerCountry _country;

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
        /// Gets or sets the county's parent <see cref="MultichannelOrderManagerCountry"/>.
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
        /// Gets or sets the county's parent country.
        /// </summary>
        IMultichannelOrderManagerCountry IMultichannelOrderManagerCounty.Country
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
        /// Gets or sets the state the county resides in.
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
        IMultichannelOrderManagerStateProvince IMultichannelOrderManagerCounty.StateProvince
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
        /// Gets or sets the three digit county code.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string CountyCode
        {
            get
            {
                return _county;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(CountyCode)].Column);
                _county = value;
            }
        }

        /// <summary>
        /// Specifies the FIPS code for the county.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string FIPS
        {
            get
            {
                return _fips;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(FIPS)].Column);
                _fips = value;
            }
        }

        /// <summary>
        /// Specifies the name of the county.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Name
        {
            get
            {
                return _name;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(Name)].Column);
                _name = value;
            }
        }

        /// <summary>
        /// Gets or sets the timezone offet for the county.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string TimezoneOffset
        {
            get
            {
                return _timeZone;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(TimezoneOffset)].Column);
                _timeZone = value;
            }
        }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string MSA
        {
            get
            {
                return _msa;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(MSA)].Column);
                _msa = value;
            }
        }

        /// <summary>
        /// Gets or sets the county's tax rate.
        /// </summary>
        public virtual decimal TaxRate
        { get; set; }

        /// <summary>
        /// Indicates whether the company has a presence in the county.
        /// </summary>
        public virtual bool Presence
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual char Code
        { get; set; }

        /// <summary>
        /// Specifies the warehouse that serves the county.
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
        /// Specifies the warehouse that serves the county.
        /// </summary>
        IMultichannelOrderManagerWarehouse IMultichannelOrderManagerCounty.Warehouse
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
        /// Indicates whether shipping should be taxed.
        /// </summary>
        public virtual bool TaxShipping
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M internally.
        /// </summary>
        public virtual bool Tax_ClassA
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M internally.
        /// </summary>
        public virtual bool Tax_ClassB
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M internally.
        /// </summary>
        public virtual bool Tax_ClassC
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M internally.
        /// </summary>
        public virtual bool Tax_ClassD
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M internally.
        /// </summary>
        public virtual bool Tax_ClassE
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual decimal RateClass_A
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual decimal RateClass_B
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual decimal RateClass_C
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual decimal RateClass_D
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual decimal RateClass_E
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool LCAP_A
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool LCAP_B
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool LCAP_C
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool LCAP_D
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool LCAP_E
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool LTAXIT_A
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool LTAXIT_B
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool LTAXIT_C
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool LTAXIT_D
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool LTAXIT_E
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual decimal NTAXIT_A
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual decimal NTAXIT_B
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual decimal NTAXIT_C
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual decimal NTAXIT_D
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual decimal NTAXIT_E
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual decimal NCAP_A
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual decimal NCAP_B
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual decimal NCAP_C
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual decimal NCAP_D
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual decimal NCAP_E
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool NONTAXBOX
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool NTAXTHRES_A
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool NTAXTHRES_B
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool NTAXTHRES_C
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool NTAXTHRES_D
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool NTAXTHRES_E
        { get; set; }

        /// <summary>
        /// Specifies whether handling charges should be taxed.
        /// </summary>
        public virtual bool TaxHandling
        { get; set; }

        /// <summary>
        /// Represents the unique ID assigned to the entity by the external data source.
        /// </summary>
        public virtual long CountyId
        {
            get
            {
                return base.MomObjectID;
            }
            set
            {
                base.MomObjectID = value;
            }
        }

        /// <summary>
        /// Gets or sets the username of the user who last accessed the record.
        /// </summary>
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
        /// Gets or sets the date/time the record was last accessed.
        /// </summary>
        public virtual DateTime? LookupOn
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the record was last updated.
        /// </summary>
        public virtual DateTime? Updated
        { get; set; }

        /// <summary>
        /// Gets or sets the parent <see cref="IMultichannelOrderManagerServer"/> object that the <see cref="IMultichannelOrderManagerCountry"/> is registered with.
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
        string IWhippetEntityExternalDataRowImportMapper.ExternalTableName
        {
            get
            {
                return ExternalTableName;
            }
        }

        /// <summary>
        /// Gets the external table name or <see langword="null"/> if the data source is not stored in a database. This property is read-only.
        /// </summary>
        protected override string ExternalTableName
        {
            get
            {
                return MultichannelOrderManagerDatabaseConstants.Tables.COUNTY;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCounty"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerCounty()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCounty"/> with the specified ID.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        public MultichannelOrderManagerCounty(Guid id)
            : base(id)
        { }

        /// <summary>
        /// Creates a <see cref="WhippetDataRowImportMap"/> object that contains a mapping for the current entity.
        /// </summary>
        /// <returns><see cref="WhippetDataRowImportMap"/> object.</returns>
        public override WhippetDataRowImportMap CreateImportMap()
        {
            WhippetDataRowImportMapEntry countryCode = new WhippetDataRowImportMapEntry(nameof(Country), MultichannelOrderManagerDatabaseConstants.Columns.COUNTRY);
            WhippetDataRowImportMapEntry state = new WhippetDataRowImportMapEntry(nameof(StateProvince), MultichannelOrderManagerDatabaseConstants.Columns.STATE);
            WhippetDataRowImportMapEntry countyCode = new WhippetDataRowImportMapEntry(nameof(CountyCode), MultichannelOrderManagerDatabaseConstants.Columns.COUNTY);
            WhippetDataRowImportMapEntry fips = new WhippetDataRowImportMapEntry(nameof(FIPS), MultichannelOrderManagerDatabaseConstants.Columns.FIPS);
            WhippetDataRowImportMapEntry name = new WhippetDataRowImportMapEntry(nameof(Name), MultichannelOrderManagerDatabaseConstants.Columns.NAME);
            WhippetDataRowImportMapEntry t_z = new WhippetDataRowImportMapEntry(nameof(TimezoneOffset), MultichannelOrderManagerDatabaseConstants.Columns.T_Z);
            WhippetDataRowImportMapEntry msa = new WhippetDataRowImportMapEntry(nameof(MSA), MultichannelOrderManagerDatabaseConstants.Columns.MSA);
            WhippetDataRowImportMapEntry countyTaxRate = new WhippetDataRowImportMapEntry(nameof(TaxRate), MultichannelOrderManagerDatabaseConstants.Columns.CTAXR);
            WhippetDataRowImportMapEntry presence = new WhippetDataRowImportMapEntry(nameof(Presence), MultichannelOrderManagerDatabaseConstants.Columns.PRESENCE);
            WhippetDataRowImportMapEntry code = new WhippetDataRowImportMapEntry(nameof(Code), MultichannelOrderManagerDatabaseConstants.Columns.CODE1);
            WhippetDataRowImportMapEntry warehouse = new WhippetDataRowImportMapEntry(nameof(Warehouse), MultichannelOrderManagerDatabaseConstants.Columns.WAREHOUSE);
            WhippetDataRowImportMapEntry taxShipping = new WhippetDataRowImportMapEntry(nameof(TaxShipping), MultichannelOrderManagerDatabaseConstants.Columns.TAXSHIP);
            WhippetDataRowImportMapEntry taxClass_A = new WhippetDataRowImportMapEntry(nameof(Tax_ClassA), MultichannelOrderManagerDatabaseConstants.Columns.TAX_CLASSA);
            WhippetDataRowImportMapEntry taxClass_B = new WhippetDataRowImportMapEntry(nameof(Tax_ClassB), MultichannelOrderManagerDatabaseConstants.Columns.TAX_CLASSB);
            WhippetDataRowImportMapEntry taxClass_C = new WhippetDataRowImportMapEntry(nameof(Tax_ClassC), MultichannelOrderManagerDatabaseConstants.Columns.TAX_CLASSC);
            WhippetDataRowImportMapEntry taxClass_D = new WhippetDataRowImportMapEntry(nameof(Tax_ClassD), MultichannelOrderManagerDatabaseConstants.Columns.TAX_CLASSD);
            WhippetDataRowImportMapEntry taxClass_E = new WhippetDataRowImportMapEntry(nameof(Tax_ClassE), MultichannelOrderManagerDatabaseConstants.Columns.TAX_CLASSE);
            WhippetDataRowImportMapEntry rateClass_A = new WhippetDataRowImportMapEntry(nameof(RateClass_A), MultichannelOrderManagerDatabaseConstants.Columns.RATECLASSA);
            WhippetDataRowImportMapEntry rateClass_B = new WhippetDataRowImportMapEntry(nameof(RateClass_B), MultichannelOrderManagerDatabaseConstants.Columns.RATECLASSB);
            WhippetDataRowImportMapEntry rateClass_C = new WhippetDataRowImportMapEntry(nameof(RateClass_C), MultichannelOrderManagerDatabaseConstants.Columns.RATECLASSC);
            WhippetDataRowImportMapEntry rateClass_D = new WhippetDataRowImportMapEntry(nameof(RateClass_D), MultichannelOrderManagerDatabaseConstants.Columns.RATECLASSD);
            WhippetDataRowImportMapEntry rateClass_E = new WhippetDataRowImportMapEntry(nameof(RateClass_E), MultichannelOrderManagerDatabaseConstants.Columns.RATECLASSE);
            WhippetDataRowImportMapEntry lcap_A = new WhippetDataRowImportMapEntry(nameof(LCAP_A), MultichannelOrderManagerDatabaseConstants.Columns.C_LCAPA);
            WhippetDataRowImportMapEntry lcap_B = new WhippetDataRowImportMapEntry(nameof(LCAP_B), MultichannelOrderManagerDatabaseConstants.Columns.C_LCAPB);
            WhippetDataRowImportMapEntry lcap_C = new WhippetDataRowImportMapEntry(nameof(LCAP_C), MultichannelOrderManagerDatabaseConstants.Columns.C_LCAPC);
            WhippetDataRowImportMapEntry lcap_D = new WhippetDataRowImportMapEntry(nameof(LCAP_D), MultichannelOrderManagerDatabaseConstants.Columns.C_LCAPD);
            WhippetDataRowImportMapEntry lcap_E = new WhippetDataRowImportMapEntry(nameof(LCAP_E), MultichannelOrderManagerDatabaseConstants.Columns.C_LCAPE);
            WhippetDataRowImportMapEntry taxit_A = new WhippetDataRowImportMapEntry(nameof(LTAXIT_A), MultichannelOrderManagerDatabaseConstants.Columns.C_LTAXITA);
            WhippetDataRowImportMapEntry taxit_B = new WhippetDataRowImportMapEntry(nameof(LTAXIT_B), MultichannelOrderManagerDatabaseConstants.Columns.C_LTAXITB);
            WhippetDataRowImportMapEntry taxit_C = new WhippetDataRowImportMapEntry(nameof(LTAXIT_C), MultichannelOrderManagerDatabaseConstants.Columns.C_LTAXITC);
            WhippetDataRowImportMapEntry taxit_D = new WhippetDataRowImportMapEntry(nameof(LTAXIT_D), MultichannelOrderManagerDatabaseConstants.Columns.C_LTAXITD);
            WhippetDataRowImportMapEntry taxit_E = new WhippetDataRowImportMapEntry(nameof(LTAXIT_E), MultichannelOrderManagerDatabaseConstants.Columns.C_LTAXITE);
            WhippetDataRowImportMapEntry ncap_A = new WhippetDataRowImportMapEntry(nameof(NCAP_A), MultichannelOrderManagerDatabaseConstants.Columns.C_NCAPA);
            WhippetDataRowImportMapEntry ncap_B = new WhippetDataRowImportMapEntry(nameof(NCAP_B), MultichannelOrderManagerDatabaseConstants.Columns.C_NCAPB);
            WhippetDataRowImportMapEntry ncap_C = new WhippetDataRowImportMapEntry(nameof(NCAP_C), MultichannelOrderManagerDatabaseConstants.Columns.C_NCAPC);
            WhippetDataRowImportMapEntry ncap_D = new WhippetDataRowImportMapEntry(nameof(NCAP_D), MultichannelOrderManagerDatabaseConstants.Columns.C_NCAPD);
            WhippetDataRowImportMapEntry ncap_E = new WhippetDataRowImportMapEntry(nameof(NCAP_E), MultichannelOrderManagerDatabaseConstants.Columns.C_NCAPE);
            WhippetDataRowImportMapEntry taxit2_A = new WhippetDataRowImportMapEntry(nameof(NTAXIT_A), MultichannelOrderManagerDatabaseConstants.Columns.C_NTAXITA);
            WhippetDataRowImportMapEntry taxit2_B = new WhippetDataRowImportMapEntry(nameof(NTAXIT_B), MultichannelOrderManagerDatabaseConstants.Columns.C_NTAXITB);
            WhippetDataRowImportMapEntry taxit2_C = new WhippetDataRowImportMapEntry(nameof(NTAXIT_C), MultichannelOrderManagerDatabaseConstants.Columns.C_NTAXITC);
            WhippetDataRowImportMapEntry taxit2_D = new WhippetDataRowImportMapEntry(nameof(NTAXIT_D), MultichannelOrderManagerDatabaseConstants.Columns.C_NTAXITD);
            WhippetDataRowImportMapEntry taxit2_E = new WhippetDataRowImportMapEntry(nameof(NTAXIT_E), MultichannelOrderManagerDatabaseConstants.Columns.C_NTAXITE);
            WhippetDataRowImportMapEntry nonTaxBox = new WhippetDataRowImportMapEntry(nameof(NONTAXBOX), MultichannelOrderManagerDatabaseConstants.Columns.NONTAXBOX);
            WhippetDataRowImportMapEntry taxThreshold_A = new WhippetDataRowImportMapEntry(nameof(NTAXTHRES_A), MultichannelOrderManagerDatabaseConstants.Columns.CTAXTHRESA);
            WhippetDataRowImportMapEntry taxThreshold_B = new WhippetDataRowImportMapEntry(nameof(NTAXTHRES_B), MultichannelOrderManagerDatabaseConstants.Columns.CTAXTHRESB);
            WhippetDataRowImportMapEntry taxThreshold_C = new WhippetDataRowImportMapEntry(nameof(NTAXTHRES_C), MultichannelOrderManagerDatabaseConstants.Columns.CTAXTHRESC);
            WhippetDataRowImportMapEntry taxThreshold_D = new WhippetDataRowImportMapEntry(nameof(NTAXTHRES_D), MultichannelOrderManagerDatabaseConstants.Columns.CTAXTHRESD);
            WhippetDataRowImportMapEntry taxThreshold_E = new WhippetDataRowImportMapEntry(nameof(NTAXTHRES_E), MultichannelOrderManagerDatabaseConstants.Columns.CTAXTHRESE);
            WhippetDataRowImportMapEntry taxHandling = new WhippetDataRowImportMapEntry(nameof(TaxHandling), MultichannelOrderManagerDatabaseConstants.Columns.TAXHAND);
            WhippetDataRowImportMapEntry countyId = new WhippetDataRowImportMapEntry(nameof(CountyId), MultichannelOrderManagerDatabaseConstants.Columns.COUNTY_ID);
            WhippetDataRowImportMapEntry lookupBy = new WhippetDataRowImportMapEntry(nameof(LookupBy), MultichannelOrderManagerDatabaseConstants.Columns.LU_BY);
            WhippetDataRowImportMapEntry lookupOn = new WhippetDataRowImportMapEntry(nameof(LookupOn), MultichannelOrderManagerDatabaseConstants.Columns.LU_ON);
            WhippetDataRowImportMapEntry updated = new WhippetDataRowImportMapEntry(nameof(Updated), MultichannelOrderManagerDatabaseConstants.Columns.UPDATED);

            return new WhippetDataRowImportMap(new[]
            {
                countryCode,
                state,
                countyCode,
                fips,
                name,
                t_z,
                msa,
                countyTaxRate,
                presence,
                code,
                warehouse,
                taxShipping,
                taxClass_A,
                taxClass_B,
                taxClass_C,
                taxClass_D,
                taxClass_E,
                rateClass_A,
                rateClass_B,
                rateClass_C,
                rateClass_D,
                rateClass_E,
                lcap_A,
                lcap_B,
                lcap_C,
                lcap_D,
                lcap_E,
                taxit_A,
                taxit_B,
                taxit_C,
                taxit_D,
                taxit_E,
                ncap_A,
                ncap_B,
                ncap_C,
                ncap_D,
                ncap_E,
                taxit2_A,
                taxit2_B,
                taxit2_C,
                taxit2_D,
                taxit2_E,
                nonTaxBox,
                taxThreshold_A,
                taxThreshold_B,
                taxThreshold_C,
                taxThreshold_D,
                taxThreshold_E,
                taxHandling,
                countyId,
                lookupBy,
                lookupOn,
                updated
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

                CountyCode = dataRow.Field<string>(map[nameof(CountyCode)].Column);
                Code = dataRow.Field<char>(map[nameof(Code)].Column);
                Presence = dataRow.Field<bool>(map[nameof(Presence)].Column);
                TaxRate = dataRow.Field<decimal>(map[nameof(TaxRate)].Column);
                MSA = dataRow.Field<string>(map[nameof(MSA)].Column);
                FIPS = dataRow.Field<string>(map[nameof(FIPS)].Column);
                StateProvince = new MultichannelOrderManagerStateProvince() { Abbreviation = dataRow.Field<string>(map[nameof(StateProvince)].Column) };
                Country = new MultichannelOrderManagerCountry() { CountryCode = dataRow.Field<string>(map[nameof(Country)].Column) };
                Name = dataRow.Field<string>(map[nameof(Name)].Column);
                Tax_ClassA = dataRow.Field<bool>(map[nameof(Tax_ClassA)].Column);
                Tax_ClassB = dataRow.Field<bool>(map[nameof(Tax_ClassB)].Column);
                Tax_ClassC = dataRow.Field<bool>(map[nameof(Tax_ClassC)].Column);
                Tax_ClassD = dataRow.Field<bool>(map[nameof(Tax_ClassD)].Column);
                Tax_ClassE = dataRow.Field<bool>(map[nameof(Tax_ClassE)].Column);
                TaxShipping = dataRow.Field<bool>(map[nameof(TaxShipping)].Column);
                RateClass_A = dataRow.Field<decimal>(map[nameof(RateClass_A)].Column);
                RateClass_B = dataRow.Field<decimal>(map[nameof(RateClass_B)].Column);
                RateClass_C = dataRow.Field<decimal>(map[nameof(RateClass_C)].Column);
                RateClass_D = dataRow.Field<decimal>(map[nameof(RateClass_D)].Column);
                RateClass_E = dataRow.Field<decimal>(map[nameof(RateClass_E)].Column);
                Warehouse = new MultichannelOrderManagerWarehouse() { Code = dataRow.Field<string>(map[nameof(Warehouse)].Column) };
                LCAP_A = dataRow.Field<bool>(map[nameof(LCAP_A)].Column);
                LCAP_B = dataRow.Field<bool>(map[nameof(LCAP_B)].Column);
                LCAP_C = dataRow.Field<bool>(map[nameof(LCAP_C)].Column);
                LCAP_D = dataRow.Field<bool>(map[nameof(LCAP_D)].Column);
                LCAP_E = dataRow.Field<bool>(map[nameof(LCAP_E)].Column);
                LTAXIT_A = dataRow.Field<bool>(map[nameof(LTAXIT_A)].Column);
                LTAXIT_B = dataRow.Field<bool>(map[nameof(LTAXIT_B)].Column);
                LTAXIT_C = dataRow.Field<bool>(map[nameof(LTAXIT_C)].Column);
                LTAXIT_D = dataRow.Field<bool>(map[nameof(LTAXIT_D)].Column);
                LTAXIT_E = dataRow.Field<bool>(map[nameof(LTAXIT_E)].Column);
                NCAP_A = dataRow.Field<decimal>(map[nameof(NCAP_A)].Column);
                NCAP_B = dataRow.Field<decimal>(map[nameof(NCAP_B)].Column);
                NCAP_C = dataRow.Field<decimal>(map[nameof(NCAP_C)].Column);
                NCAP_D = dataRow.Field<decimal>(map[nameof(NCAP_D)].Column);
                NCAP_E = dataRow.Field<decimal>(map[nameof(NCAP_E)].Column);
                NTAXIT_A = dataRow.Field<decimal>(map[nameof(NTAXIT_A)].Column);
                NTAXIT_B = dataRow.Field<decimal>(map[nameof(NTAXIT_B)].Column);
                NTAXIT_C = dataRow.Field<decimal>(map[nameof(NTAXIT_C)].Column);
                NTAXIT_D = dataRow.Field<decimal>(map[nameof(NTAXIT_D)].Column);
                NTAXIT_E = dataRow.Field<decimal>(map[nameof(NTAXIT_E)].Column);
                NONTAXBOX = dataRow.Field<bool>(map[nameof(NONTAXBOX)].Column);
                NTAXTHRES_A = dataRow.Field<bool>(map[nameof(NTAXTHRES_A)].Column);
                NTAXTHRES_B = dataRow.Field<bool>(map[nameof(NTAXTHRES_B)].Column);
                NTAXTHRES_C = dataRow.Field<bool>(map[nameof(NTAXTHRES_C)].Column);
                NTAXTHRES_D = dataRow.Field<bool>(map[nameof(NTAXTHRES_D)].Column);
                NTAXTHRES_E = dataRow.Field<bool>(map[nameof(NTAXTHRES_E)].Column);
                TaxHandling = dataRow.Field<bool>(map[nameof(TaxHandling)].Column);
                CountyId = dataRow.Field<long>(map[nameof(CountyId)].Column);
                LookupBy = dataRow.Field<string>(map[nameof(LookupBy)].Column);
                LookupOn = dataRow.Field<DateTime?>(map[nameof(LookupOn)].Column);
                Updated = dataRow.Field<DateTime?>(map[nameof(Updated)].Column);
                TimezoneOffset = dataRow.Field<string>(map[nameof(TimezoneOffset)].Column);
            }
        }

        /// <summary>
        /// Creates a <see cref="DataTable"/> that represents the database table of the current entity.
        /// </summary>
        /// <returns><see cref="DataTable"/> containing the columns and respective definitions of the associated external database table for the current entity.</returns>
        public override DataTable CreateDataTable()
        {
            WhippetDataRowImportMap map = ImportMap;
            DataTable table = new DataTable();

            DataColumn countryCode = DataColumnFactory.CreateDataColumn(map[nameof(Country)].Column, typeof(string), false, 3);
            DataColumn countyCode = DataColumnFactory.CreateDataColumn(map[nameof(CountyCode)].Column, typeof(string), false, 3);
            DataColumn state = DataColumnFactory.CreateDataColumn(map[nameof(StateProvince)].Column, typeof(string), false, 3);
            DataColumn fips = DataColumnFactory.CreateDataColumn(map[nameof(FIPS)].Column, typeof(string), false, 5);
            DataColumn name = DataColumnFactory.CreateDataColumn(map[nameof(Name)].Column, typeof(string), false, 25);
            DataColumn t_z = DataColumnFactory.CreateDataColumn(map[nameof(TimezoneOffset)].Column, typeof(string), false, 2);
            DataColumn msa = DataColumnFactory.CreateDataColumn(map[nameof(MSA)].Column, typeof(string), false, 4);
            DataColumn taxRate = DataColumnFactory.CreateDataColumn(map[nameof(TaxRate)].Column, typeof(decimal), false);
            DataColumn presence = DataColumnFactory.CreateDataColumn(map[nameof(Presence)].Column, typeof(bool), false);
            DataColumn code = DataColumnFactory.CreateDataColumn(map[nameof(Code)].Column, typeof(char), false, 1);
            DataColumn warehouse = DataColumnFactory.CreateDataColumn(map[nameof(Warehouse)].Column, typeof(string), false, 6);
            DataColumn taxShipping = DataColumnFactory.CreateDataColumn(map[nameof(TaxShipping)].Column, typeof(bool), false);
            DataColumn tax_classA = DataColumnFactory.CreateDataColumn(map[nameof(Tax_ClassA)].Column, typeof(bool), false);
            DataColumn tax_classB = DataColumnFactory.CreateDataColumn(map[nameof(Tax_ClassB)].Column, typeof(bool), false);
            DataColumn tax_classC = DataColumnFactory.CreateDataColumn(map[nameof(Tax_ClassC)].Column, typeof(bool), false);
            DataColumn tax_classD = DataColumnFactory.CreateDataColumn(map[nameof(Tax_ClassD)].Column, typeof(bool), false);
            DataColumn tax_classE = DataColumnFactory.CreateDataColumn(map[nameof(Tax_ClassE)].Column, typeof(bool), false);
            DataColumn rateClass_A = DataColumnFactory.CreateDataColumn(map[nameof(RateClass_A)].Column, typeof(decimal), false);
            DataColumn rateClass_B = DataColumnFactory.CreateDataColumn(map[nameof(RateClass_B)].Column, typeof(decimal), false);
            DataColumn rateClass_C = DataColumnFactory.CreateDataColumn(map[nameof(RateClass_C)].Column, typeof(decimal), false);
            DataColumn rateClass_D = DataColumnFactory.CreateDataColumn(map[nameof(RateClass_D)].Column, typeof(decimal), false);
            DataColumn rateClass_E = DataColumnFactory.CreateDataColumn(map[nameof(RateClass_E)].Column, typeof(decimal), false);
            DataColumn lcap_A = DataColumnFactory.CreateDataColumn(map[nameof(LCAP_A)].Column, typeof(bool), false);
            DataColumn lcap_B = DataColumnFactory.CreateDataColumn(map[nameof(LCAP_B)].Column, typeof(bool), false);
            DataColumn lcap_C = DataColumnFactory.CreateDataColumn(map[nameof(LCAP_C)].Column, typeof(bool), false);
            DataColumn lcap_D = DataColumnFactory.CreateDataColumn(map[nameof(LCAP_D)].Column, typeof(bool), false);
            DataColumn lcap_E = DataColumnFactory.CreateDataColumn(map[nameof(LCAP_E)].Column, typeof(bool), false);
            DataColumn ltaxit_A = DataColumnFactory.CreateDataColumn(map[nameof(LTAXIT_A)].Column, typeof(bool), false);
            DataColumn ltaxit_B = DataColumnFactory.CreateDataColumn(map[nameof(LTAXIT_B)].Column, typeof(bool), false);
            DataColumn ltaxit_C = DataColumnFactory.CreateDataColumn(map[nameof(LTAXIT_C)].Column, typeof(bool), false);
            DataColumn ltaxit_D = DataColumnFactory.CreateDataColumn(map[nameof(LTAXIT_D)].Column, typeof(bool), false);
            DataColumn ltaxit_E = DataColumnFactory.CreateDataColumn(map[nameof(LTAXIT_E)].Column, typeof(bool), false);
            DataColumn ncap_A = DataColumnFactory.CreateDataColumn(map[nameof(NCAP_A)].Column, typeof(decimal), false);
            DataColumn ncap_B = DataColumnFactory.CreateDataColumn(map[nameof(NCAP_B)].Column, typeof(decimal), false);
            DataColumn ncap_C = DataColumnFactory.CreateDataColumn(map[nameof(NCAP_C)].Column, typeof(decimal), false);
            DataColumn ncap_D = DataColumnFactory.CreateDataColumn(map[nameof(NCAP_D)].Column, typeof(decimal), false);
            DataColumn ncap_E = DataColumnFactory.CreateDataColumn(map[nameof(NCAP_E)].Column, typeof(decimal), false);
            DataColumn ntaxit_A = DataColumnFactory.CreateDataColumn(map[nameof(NTAXIT_A)].Column, typeof(decimal), false);
            DataColumn ntaxit_B = DataColumnFactory.CreateDataColumn(map[nameof(NTAXIT_B)].Column, typeof(decimal), false);
            DataColumn ntaxit_C = DataColumnFactory.CreateDataColumn(map[nameof(NTAXIT_C)].Column, typeof(decimal), false);
            DataColumn ntaxit_D = DataColumnFactory.CreateDataColumn(map[nameof(NTAXIT_D)].Column, typeof(decimal), false);
            DataColumn ntaxit_E = DataColumnFactory.CreateDataColumn(map[nameof(NTAXIT_E)].Column, typeof(decimal), false);
            DataColumn nontaxBox = DataColumnFactory.CreateDataColumn(map[nameof(NONTAXBOX)].Column, typeof(bool), false);
            DataColumn thresh_A = DataColumnFactory.CreateDataColumn(map[nameof(NTAXTHRES_A)].Column, typeof(bool), false);
            DataColumn thresh_B = DataColumnFactory.CreateDataColumn(map[nameof(NTAXTHRES_B)].Column, typeof(bool), false);
            DataColumn thresh_C = DataColumnFactory.CreateDataColumn(map[nameof(NTAXTHRES_C)].Column, typeof(bool), false);
            DataColumn thresh_D = DataColumnFactory.CreateDataColumn(map[nameof(NTAXTHRES_D)].Column, typeof(bool), false);
            DataColumn thresh_E = DataColumnFactory.CreateDataColumn(map[nameof(NTAXTHRES_E)].Column, typeof(bool), false);
            DataColumn taxHandling = DataColumnFactory.CreateDataColumn(map[nameof(TaxHandling)].Column, typeof(bool), false);
            DataColumn countyId = DataColumnFactory.CreateDataColumn(map[nameof(CountyId)].Column, typeof(long), false);
            DataColumn lookupBy = DataColumnFactory.CreateDataColumn(map[nameof(LookupBy)].Column, typeof(string), false, 3);
            DataColumn lookupDate = DataColumnFactory.CreateDataColumn(map[nameof(LookupOn)].Column, typeof(DateTime), true);
            DataColumn updateDate = DataColumnFactory.CreateDataColumn(map[nameof(Updated)].Column, typeof(DateTime), true);

            table.Columns.AddRange(new[]
            {
                countryCode,
                countyCode,
                state,
                fips,
                name,
                t_z,
                msa,
                taxRate,
                presence,
                code,
                warehouse,
                taxShipping,
                tax_classA,
                tax_classB,
                tax_classC,
                tax_classD,
                tax_classE,
                rateClass_A,
                rateClass_B,
                rateClass_C,
                rateClass_D,
                rateClass_E,
                lcap_A,
                lcap_B,
                lcap_C,
                lcap_D,
                lcap_E,
                ltaxit_A,
                ltaxit_B,
                ltaxit_C,
                ltaxit_D,
                ltaxit_E,
                ncap_A,
                ncap_B,
                ncap_C,
                ncap_D,
                ncap_E,
                ntaxit_A,
                ntaxit_B,
                ntaxit_C,
                ntaxit_D,
                ntaxit_E,
                nontaxBox,
                thresh_A,
                thresh_B,
                thresh_C,
                thresh_D,
                thresh_E,
                taxHandling,
                countyId,
                lookupBy,
                lookupDate,
                updateDate
            });

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
            return Equals(obj as IMultichannelOrderManagerCounty);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerCounty obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="IMultichannelOrderManagerCounty"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IMultichannelOrderManagerCounty"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerCounty a, IMultichannelOrderManagerCounty b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals =
                    a.Server.Equals(b.Server)
                        && a.Code.Equals(b.Code)
                        && ((a.Country == null && b.Country == null) || (a.Country != null && a.Country.Equals(b.Country)))
                        && ((a.StateProvince == null && b.StateProvince == null) || (a.StateProvince != null && a.StateProvince.Equals(b.StateProvince)))
                        && String.Equals(a.CountyCode, b.CountyCode, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.FIPS, b.FIPS, StringComparison.InvariantCultureIgnoreCase)
                        && a.LCAP_A.Equals(b.LCAP_A)
                        && a.LCAP_B.Equals(b.LCAP_B)
                        && a.LCAP_C.Equals(b.LCAP_C)
                        && a.LCAP_D.Equals(b.LCAP_D)
                        && a.LCAP_E.Equals(b.LCAP_E)
                        && String.Equals(a.LookupBy, b.LookupBy, StringComparison.InvariantCultureIgnoreCase)
                        && a.LookupOn.GetValueOrDefault().Equals(b.LookupOn.GetValueOrDefault())
                        && a.LTAXIT_A.Equals(b.LTAXIT_A)
                        && a.LTAXIT_B.Equals(b.LTAXIT_B)
                        && a.LTAXIT_C.Equals(b.LTAXIT_C)
                        && a.LTAXIT_D.Equals(b.LTAXIT_D)
                        && a.LTAXIT_E.Equals(b.LTAXIT_E)
                        && String.Equals(a.MSA, b.MSA, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase)
                        && a.NCAP_A.Equals(b.NCAP_A)
                        && a.NCAP_B.Equals(b.NCAP_B)
                        && a.NCAP_C.Equals(b.NCAP_C)
                        && a.NCAP_D.Equals(b.NCAP_D)
                        && a.NCAP_E.Equals(b.NCAP_E)
                        && a.NONTAXBOX.Equals(b.NONTAXBOX)
                        && a.NTAXIT_A.Equals(b.NTAXIT_A)
                        && a.NTAXIT_B.Equals(b.NTAXIT_B)
                        && a.NTAXIT_C.Equals(b.NTAXIT_C)
                        && a.NTAXIT_D.Equals(b.NTAXIT_D)
                        && a.NTAXIT_E.Equals(b.NTAXIT_E)
                        && a.NTAXTHRES_A.Equals(b.NTAXTHRES_A)
                        && a.NTAXTHRES_B.Equals(b.NTAXTHRES_B)
                        && a.NTAXTHRES_C.Equals(b.NTAXTHRES_C)
                        && a.NTAXTHRES_D.Equals(b.NTAXTHRES_D)
                        && a.NTAXTHRES_E.Equals(b.NTAXTHRES_E)
                        && a.Presence.Equals(b.Presence)
                        && a.RateClass_A.Equals(b.RateClass_A)
                        && a.RateClass_B.Equals(b.RateClass_B)
                        && a.RateClass_C.Equals(b.RateClass_C)
                        && a.RateClass_D.Equals(b.RateClass_D)
                        && a.RateClass_E.Equals(b.RateClass_E)
                        && a.TaxHandling.Equals(b.TaxHandling)
                        && a.TaxRate.Equals(b.TaxRate)
                        && a.TaxShipping.Equals(b.TaxShipping)
                        && a.Tax_ClassA.Equals(b.Tax_ClassA)
                        && a.Tax_ClassB.Equals(b.Tax_ClassB)
                        && a.Tax_ClassC.Equals(b.Tax_ClassC)
                        && a.Tax_ClassD.Equals(b.Tax_ClassD)
                        && a.Tax_ClassE.Equals(b.Tax_ClassE)
                        && String.Equals(a.TimezoneOffset, b.TimezoneOffset, StringComparison.InvariantCultureIgnoreCase)
                        && a.Updated.GetValueOrDefault().Equals(b.Updated.GetValueOrDefault())
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
        public virtual int GetHashCode(IMultichannelOrderManagerCounty obj)
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
            MultichannelOrderManagerCounty county = new MultichannelOrderManagerCounty();

            county.Code = Code;
            county.Country = Country.Clone<MultichannelOrderManagerCountry>();

            if (!String.IsNullOrEmpty(CountyCode))
            {
                county.CountyCode = CountyCode;
            }

            county.CountyId = CountyId;

            if (!String.IsNullOrEmpty(FIPS))
            {
                county.FIPS = FIPS;
            }

            county.ID = ID;
            county.LCAP_A = LCAP_A;
            county.LCAP_B = LCAP_B;
            county.LCAP_C = LCAP_C;
            county.LCAP_D = LCAP_D;
            county.LCAP_E = LCAP_E;

            if (!String.IsNullOrEmpty(LookupBy))
            {
                county.LookupBy = LookupBy;
            }

            county.LookupOn = LookupOn;
            county.LTAXIT_A = LTAXIT_A;
            county.LTAXIT_B = LTAXIT_B;
            county.LTAXIT_C = LTAXIT_C;
            county.LTAXIT_D = LTAXIT_D;
            county.LTAXIT_E = LTAXIT_E;
            county.MomObjectID = MomObjectID;

            if (!String.IsNullOrEmpty(MSA))
            {
                county.MSA = MSA;
            }

            if (!String.IsNullOrEmpty(Name))
            {
                county.Name = Name;
            }

            county.NCAP_A = NCAP_A;
            county.NCAP_B = NCAP_B;
            county.NCAP_C = NCAP_C;
            county.NCAP_D = NCAP_D;
            county.NCAP_E = NCAP_E;
            county.NONTAXBOX = NONTAXBOX;
            county.NTAXIT_A = NTAXIT_A;
            county.NTAXIT_B = NTAXIT_B;
            county.NTAXIT_C = NTAXIT_C;
            county.NTAXIT_D = NTAXIT_D;
            county.NTAXIT_E = NTAXIT_E;
            county.NTAXTHRES_A = NTAXTHRES_A;
            county.NTAXTHRES_B = NTAXTHRES_B;
            county.NTAXTHRES_C = NTAXTHRES_C;
            county.NTAXTHRES_D = NTAXTHRES_D;
            county.NTAXTHRES_E = NTAXTHRES_E;
            county.Presence = Presence;
            county.RateClass_A = RateClass_A;
            county.RateClass_B = RateClass_B;
            county.RateClass_C = RateClass_C;
            county.RateClass_D = RateClass_D;
            county.RateClass_E = RateClass_E;
            county.Server = Server.Clone<MultichannelOrderManagerServer>();
            county.StateProvince = StateProvince.Clone<MultichannelOrderManagerStateProvince>();
            county.TaxHandling = TaxHandling;
            county.TaxRate = TaxRate;
            county.TaxShipping = TaxShipping;
            county.Tax_ClassA = Tax_ClassA;
            county.Tax_ClassB = Tax_ClassB;
            county.Tax_ClassC = Tax_ClassC;
            county.Tax_ClassD = Tax_ClassD;
            county.Tax_ClassE = Tax_ClassE;

            if (!String.IsNullOrEmpty(TimezoneOffset))
            {
                county.TimezoneOffset = TimezoneOffset;
            }

            county.Updated = Updated;
            county.Warehouse = Warehouse.Clone<MultichannelOrderManagerWarehouse>();

            return county;
        }

        /// <summary>
        /// Compares the current instance to the specified <see cref="IMultichannelOrderManagerCounty"/> for determining sort order.
        /// </summary>
        /// <param name="obj"><see cref="IMultichannelOrderManagerCounty"/> to compare against.</param>
        /// <returns>A signed integer that indicates the relative values of the current object and <paramref name="obj"/>. Values less than zero indicates that the current object precedes <paramref name="obj"/>; zero indicates that the values are equal; and values greater than zero indicate that the current object follows <paramref name="obj"/>.</returns>
        public virtual int CompareTo(IMultichannelOrderManagerCounty obj)
        {
            return CaseInsensitiveStringComparer.Instance.Compare(Name, obj?.Name);
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            if (!String.IsNullOrWhiteSpace(Name))
            {
                builder.Append(Name.Trim());

                if (!String.IsNullOrWhiteSpace(StateProvince.Name))
                {
                    builder.Append(" ");
                    builder.Append("(");
                    builder.Append(StateProvince.ToString());
                    builder.Append(")");
                }
            }
            else
            {
                builder.Append(base.ToString());
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

