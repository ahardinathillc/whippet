using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using Dynamitey;
using Newtonsoft.Json;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Extensions;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;
using Athi.Whippet.Collections.Comparers;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents a country in M.O.M.
    /// </summary>
    public class MultichannelOrderManagerCountry : MultichannelOrderManagerEntity, IWhippetEntity, IWhippetEntityExternalDataRowImportMapper, IMultichannelOrderManagerCountry, IEqualityComparer<IMultichannelOrderManagerCountry>, IMultichannelOrderManagerEntity, IWhippetEntityDynamicImportMapper, IWhippetCloneable, IComparable<IMultichannelOrderManagerCountry>
    {
        private static readonly MultichannelOrderManagerCountry _defaultCountry;
        
        private MultichannelOrderManagerServer _server;

        private MultichannelOrderManagerWarehouse _warehouse;

        private string _countryId;
        private string _name;
        private string _phoneMask;
        private string _iso2;
        private string _iso3;
        private string _isoNum;
        private string _lookupBy;

        /// <summary>
        /// Gets the default <see cref="MultichannelOrderManagerCountry"/> to use in the system. This property is read-only.
        /// </summary>
        public static MultichannelOrderManagerCountry DefaultCountry
        {
            get
            {
                return _defaultCountry;
            }
        }
        
        /// <summary>
        /// Represents the unique country ID that is assigned to each entry.
        /// </summary>
        public virtual new long ID
        {
            get
            {
                return CountryId;
            }
            set
            {
                CountryId = value;
            }
        }

        /// <summary>
        /// Represents the unique country ID that is assigned to each entry.
        /// </summary>
        public virtual string CountryCode
        {
            get
            {
                return _countryId;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    _countryId = DefaultCountry.CountryCode;
                }
                else
                {
                    this.CheckLengthRequirement(value, ImportMap[nameof(CountryCode)].Column);
                    _countryId = value?.Trim();
                }
            }
        }

        /// <summary>
        /// Name of the country.
        /// </summary>
        public virtual string Name
        {
            get
            {
                return _name;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(Name)].Column);
                _name = value?.Trim();
            }
        }

        /// <summary>
        /// Specifies the country's national tax rate.
        /// </summary>
        public virtual decimal NationalTaxRate
        { get; set; }

        /// <summary>
        /// Gets or sets the phone number format of the <see cref="MultichannelOrderManagerCountry"/>.
        /// </summary>
        public virtual string PhoneMask
        {
            get
            {
                return _phoneMask;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(PhoneMask)].Column);
                _phoneMask = value?.Trim();
            }
        }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool Tax_ClassA
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool Tax_ClassB
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool Tax_ClassC
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool Tax_ClassD
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool Tax_ClassE
        { get; set; }

        /// <summary>
        /// Indicates whether shipping costs are taxed.
        /// </summary>
        public virtual bool TaxShipping
        { get; set; }

        /// <summary>
        /// Represents the two-character ISO code for the country.
        /// </summary>
        public virtual string ISO2
        {
            get
            {
                return _iso2;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(ISO2)].Column);
                _iso2 = value;
            }
        }

        /// <summary>
        /// Represents the three-character ISO code for the country.
        /// </summary>
        public virtual string ISO3
        {
            get
            {
                return _iso3;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(ISO3)].Column);
                _iso3 = value;
            }
        }

        /// <summary>
        /// Represents the three-digit ISO number for the country.
        /// </summary>
        public virtual string ISONumber
        {
            get
            {
                return _isoNum;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(ISONumber)].Column);
                _isoNum = value;
            }
        }

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
        /// Specifies the (primary) warehouse that serves the country.
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
        /// Specifies the (primary) warehouse that serves the country.
        /// </summary>
        IMultichannelOrderManagerWarehouse IMultichannelOrderManagerCountry.Warehouse
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
        public virtual long CountryId
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
        /// Gets or sets the username of the user who last accessed the record.
        /// </summary>
        public virtual string LookupBy
        {
            get
            {
                return _lookupBy;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(LookupBy)].Column);
                _lookupBy = value?.Trim();
            }
        }

        /// <summary>
        /// Gets or sets the date/time the record was last accessed.
        /// </summary>
        public virtual DateTime? LookupOn
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
                Server = value.ToMultichannelOrderManagerServer();
            }
        }

        /// <summary>
        /// Gets the external table name or <see langword="null"/> if the data source is not stored in a database. This property is read-only.
        /// </summary>
        string IWhippetEntityExternalDataRowImportMapper.ExternalTableName
        {
            get
            {
                return MultichannelOrderManagerDatabaseConstants.Tables.COUNTRY;
            }
        }

        /// <summary>
        /// Gets the external table name or <see langword="null"/> if the data source is not stored in a database. This property is read-only.
        /// </summary>
        protected override string ExternalTableName
        {
            get
            {
                return ((IWhippetEntityExternalDataRowImportMapper)(this)).ExternalTableName;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCountry"/> with no arguments. This constructor assigns the default <see cref="MultichannelOrderManagerCountry"/> value.
        /// </summary>
        static MultichannelOrderManagerCountry()
        {
            MultichannelOrderManagerCountry country = new MultichannelOrderManagerCountry();
            country.CountryCode = "001";
            country.Name = "United States";
            country.PhoneMask = "(999) 999-9999";
            country.Tax_ClassE = true;
            country.ISO2 = "US";
            country.ISO3 = "USA";
            country.ISONumber = "840";
            country.ID = 1;

            _defaultCountry = country;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCountry"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerCountry()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCountry"/> with the specified ID.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        public MultichannelOrderManagerCountry(int id)
            : this()
        {
            MomObjectID = id;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCountry"/> with the specified ID.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        public MultichannelOrderManagerCountry(Guid id)
            : base(id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCountry"/> with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="countryCode">Three-digit country code.</param>
        /// <param name="countryName">Name of the country.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        public MultichannelOrderManagerCountry(Guid id, string countryCode, string countryName)
            : this(id)
        {
            CountryCode = countryCode;
            Name = countryName;
        }

        /// <summary>
        /// Creates a <see cref="WhippetDataRowImportMap"/> object that contains a mapping for the current entity.
        /// </summary>
        /// <returns><see cref="WhippetDataRowImportMap"/> object.</returns>
        public override WhippetDataRowImportMap CreateImportMap()
        {
            WhippetDataRowImportMapEntry countryCode = new WhippetDataRowImportMapEntry(nameof(CountryCode), MultichannelOrderManagerDatabaseConstants.Columns.COUNTRY);
            WhippetDataRowImportMapEntry name = new WhippetDataRowImportMapEntry(nameof(Name), MultichannelOrderManagerDatabaseConstants.Columns.NAME);
            WhippetDataRowImportMapEntry natTaxRate = new WhippetDataRowImportMapEntry(nameof(NationalTaxRate), MultichannelOrderManagerDatabaseConstants.Columns.NTAXR);
            WhippetDataRowImportMapEntry phoneMask = new WhippetDataRowImportMapEntry(nameof(PhoneMask), MultichannelOrderManagerDatabaseConstants.Columns.PHONEMASK);
            WhippetDataRowImportMapEntry taxClass_A = new WhippetDataRowImportMapEntry(nameof(Tax_ClassA), MultichannelOrderManagerDatabaseConstants.Columns.TAX_CLASSA);
            WhippetDataRowImportMapEntry taxClass_B = new WhippetDataRowImportMapEntry(nameof(Tax_ClassB), MultichannelOrderManagerDatabaseConstants.Columns.TAX_CLASSB);
            WhippetDataRowImportMapEntry taxClass_C = new WhippetDataRowImportMapEntry(nameof(Tax_ClassC), MultichannelOrderManagerDatabaseConstants.Columns.TAX_CLASSC);
            WhippetDataRowImportMapEntry taxClass_D = new WhippetDataRowImportMapEntry(nameof(Tax_ClassD), MultichannelOrderManagerDatabaseConstants.Columns.TAX_CLASSD);
            WhippetDataRowImportMapEntry taxClass_E = new WhippetDataRowImportMapEntry(nameof(Tax_ClassE), MultichannelOrderManagerDatabaseConstants.Columns.TAX_CLASSE);
            WhippetDataRowImportMapEntry taxShipping = new WhippetDataRowImportMapEntry(nameof(TaxShipping), MultichannelOrderManagerDatabaseConstants.Columns.TAXSHIP);
            WhippetDataRowImportMapEntry iso2 = new WhippetDataRowImportMapEntry(nameof(ISO2), MultichannelOrderManagerDatabaseConstants.Columns.ISO2);
            WhippetDataRowImportMapEntry iso3 = new WhippetDataRowImportMapEntry(nameof(ISO3), MultichannelOrderManagerDatabaseConstants.Columns.ISO3);
            WhippetDataRowImportMapEntry isoNum = new WhippetDataRowImportMapEntry(nameof(ISONumber), MultichannelOrderManagerDatabaseConstants.Columns.ISONUM);
            WhippetDataRowImportMapEntry rateClass_A = new WhippetDataRowImportMapEntry(nameof(RateClass_A), MultichannelOrderManagerDatabaseConstants.Columns.RATECLASSA);
            WhippetDataRowImportMapEntry rateClass_B = new WhippetDataRowImportMapEntry(nameof(RateClass_B), MultichannelOrderManagerDatabaseConstants.Columns.RATECLASSB);
            WhippetDataRowImportMapEntry rateClass_C = new WhippetDataRowImportMapEntry(nameof(RateClass_C), MultichannelOrderManagerDatabaseConstants.Columns.RATECLASSC);
            WhippetDataRowImportMapEntry rateClass_D = new WhippetDataRowImportMapEntry(nameof(RateClass_D), MultichannelOrderManagerDatabaseConstants.Columns.RATECLASSD);
            WhippetDataRowImportMapEntry rateClass_E = new WhippetDataRowImportMapEntry(nameof(RateClass_E), MultichannelOrderManagerDatabaseConstants.Columns.RATECLASSE);
            WhippetDataRowImportMapEntry warehouse = new WhippetDataRowImportMapEntry(nameof(Warehouse), MultichannelOrderManagerDatabaseConstants.Columns.WAREHOUSE);
            WhippetDataRowImportMapEntry lcap_A = new WhippetDataRowImportMapEntry(nameof(LCAP_A), MultichannelOrderManagerDatabaseConstants.Columns.N_LCAPA);
            WhippetDataRowImportMapEntry lcap_B = new WhippetDataRowImportMapEntry(nameof(LCAP_B), MultichannelOrderManagerDatabaseConstants.Columns.N_LCAPB);
            WhippetDataRowImportMapEntry lcap_C = new WhippetDataRowImportMapEntry(nameof(LCAP_C), MultichannelOrderManagerDatabaseConstants.Columns.N_LCAPC);
            WhippetDataRowImportMapEntry lcap_D = new WhippetDataRowImportMapEntry(nameof(LCAP_D), MultichannelOrderManagerDatabaseConstants.Columns.N_LCAPD);
            WhippetDataRowImportMapEntry lcap_E = new WhippetDataRowImportMapEntry(nameof(LCAP_E), MultichannelOrderManagerDatabaseConstants.Columns.N_LCAPE);
            WhippetDataRowImportMapEntry taxit_A = new WhippetDataRowImportMapEntry(nameof(LTAXIT_A), MultichannelOrderManagerDatabaseConstants.Columns.N_LTAXITA);
            WhippetDataRowImportMapEntry taxit_B = new WhippetDataRowImportMapEntry(nameof(LTAXIT_B), MultichannelOrderManagerDatabaseConstants.Columns.N_LTAXITB);
            WhippetDataRowImportMapEntry taxit_C = new WhippetDataRowImportMapEntry(nameof(LTAXIT_C), MultichannelOrderManagerDatabaseConstants.Columns.N_LTAXITC);
            WhippetDataRowImportMapEntry taxit_D = new WhippetDataRowImportMapEntry(nameof(LTAXIT_D), MultichannelOrderManagerDatabaseConstants.Columns.N_LTAXITD);
            WhippetDataRowImportMapEntry taxit_E = new WhippetDataRowImportMapEntry(nameof(LTAXIT_E), MultichannelOrderManagerDatabaseConstants.Columns.N_LTAXITE);
            WhippetDataRowImportMapEntry ncap_A = new WhippetDataRowImportMapEntry(nameof(NCAP_A), MultichannelOrderManagerDatabaseConstants.Columns.N_NCAPA);
            WhippetDataRowImportMapEntry ncap_B = new WhippetDataRowImportMapEntry(nameof(NCAP_B), MultichannelOrderManagerDatabaseConstants.Columns.N_NCAPB);
            WhippetDataRowImportMapEntry ncap_C = new WhippetDataRowImportMapEntry(nameof(NCAP_C), MultichannelOrderManagerDatabaseConstants.Columns.N_NCAPC);
            WhippetDataRowImportMapEntry ncap_D = new WhippetDataRowImportMapEntry(nameof(NCAP_D), MultichannelOrderManagerDatabaseConstants.Columns.N_NCAPD);
            WhippetDataRowImportMapEntry ncap_E = new WhippetDataRowImportMapEntry(nameof(NCAP_E), MultichannelOrderManagerDatabaseConstants.Columns.N_NCAPE);
            WhippetDataRowImportMapEntry taxit2_A = new WhippetDataRowImportMapEntry(nameof(NTAXIT_A), MultichannelOrderManagerDatabaseConstants.Columns.N_NTAXITA);
            WhippetDataRowImportMapEntry taxit2_B = new WhippetDataRowImportMapEntry(nameof(NTAXIT_B), MultichannelOrderManagerDatabaseConstants.Columns.N_NTAXITB);
            WhippetDataRowImportMapEntry taxit2_C = new WhippetDataRowImportMapEntry(nameof(NTAXIT_C), MultichannelOrderManagerDatabaseConstants.Columns.N_NTAXITC);
            WhippetDataRowImportMapEntry taxit2_D = new WhippetDataRowImportMapEntry(nameof(NTAXIT_D), MultichannelOrderManagerDatabaseConstants.Columns.N_NTAXITD);
            WhippetDataRowImportMapEntry taxit2_E = new WhippetDataRowImportMapEntry(nameof(NTAXIT_E), MultichannelOrderManagerDatabaseConstants.Columns.N_NTAXITE);
            WhippetDataRowImportMapEntry nonTaxBox = new WhippetDataRowImportMapEntry(nameof(NONTAXBOX), MultichannelOrderManagerDatabaseConstants.Columns.NONTAXBOX);
            WhippetDataRowImportMapEntry taxThreshold_A = new WhippetDataRowImportMapEntry(nameof(NTAXTHRES_A), MultichannelOrderManagerDatabaseConstants.Columns.NTAXTHRESA);
            WhippetDataRowImportMapEntry taxThreshold_B = new WhippetDataRowImportMapEntry(nameof(NTAXTHRES_B), MultichannelOrderManagerDatabaseConstants.Columns.NTAXTHRESB);
            WhippetDataRowImportMapEntry taxThreshold_C = new WhippetDataRowImportMapEntry(nameof(NTAXTHRES_C), MultichannelOrderManagerDatabaseConstants.Columns.NTAXTHRESC);
            WhippetDataRowImportMapEntry taxThreshold_D = new WhippetDataRowImportMapEntry(nameof(NTAXTHRES_D), MultichannelOrderManagerDatabaseConstants.Columns.NTAXTHRESD);
            WhippetDataRowImportMapEntry taxThreshold_E = new WhippetDataRowImportMapEntry(nameof(NTAXTHRES_E), MultichannelOrderManagerDatabaseConstants.Columns.NTAXTHRESE);
            WhippetDataRowImportMapEntry taxHandling = new WhippetDataRowImportMapEntry(nameof(TaxHandling), MultichannelOrderManagerDatabaseConstants.Columns.TAXHAND);
            WhippetDataRowImportMapEntry countryId = new WhippetDataRowImportMapEntry(nameof(CountryId), MultichannelOrderManagerDatabaseConstants.Columns.COUNTRY_ID);
            WhippetDataRowImportMapEntry lookupBy = new WhippetDataRowImportMapEntry(nameof(LookupBy), MultichannelOrderManagerDatabaseConstants.Columns.LU_BY);
            WhippetDataRowImportMapEntry lookupOn = new WhippetDataRowImportMapEntry(nameof(LookupOn), MultichannelOrderManagerDatabaseConstants.Columns.LU_ON);

            return new WhippetDataRowImportMap(new[]
            {
                countryCode,
                name,
                natTaxRate,
                phoneMask,
                taxClass_A,
                taxClass_B,
                taxClass_C,
                taxClass_D,
                taxClass_E,
                taxShipping,
                iso2,
                iso3,
                isoNum,
                rateClass_A,
                rateClass_B,
                rateClass_C,
                rateClass_D,
                rateClass_E,
                warehouse,
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
                countryId,
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
                WhippetDataRowImportMap map = (importMap == null ? CreateImportMap() : importMap);

                CountryCode = dataRow.Field<string>(map[nameof(CountryCode)].Column);
                Name = dataRow.Field<string>(map[nameof(Name)].Column);
                NationalTaxRate = dataRow.Field<decimal>(map[nameof(NationalTaxRate)].Column);
                PhoneMask = dataRow.Field<string>(map[nameof(PhoneMask)].Column);
                Tax_ClassA = dataRow.Field<bool>(map[nameof(Tax_ClassA)].Column);
                Tax_ClassB = dataRow.Field<bool>(map[nameof(Tax_ClassB)].Column);
                Tax_ClassC = dataRow.Field<bool>(map[nameof(Tax_ClassC)].Column);
                Tax_ClassD = dataRow.Field<bool>(map[nameof(Tax_ClassD)].Column);
                Tax_ClassE = dataRow.Field<bool>(map[nameof(Tax_ClassE)].Column);
                TaxShipping = dataRow.Field<bool>(map[nameof(TaxShipping)].Column);
                ISO2 = dataRow.Field<string>(map[nameof(ISO2)].Column);
                ISO3 = dataRow.Field<string>(map[nameof(ISO3)].Column);
                ISONumber = dataRow.Field<string>(map[nameof(ISONumber)].Column);
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
                CountryId = dataRow.Field<long>(map[nameof(CountryId)].Column);
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

            DataColumn countryCode = DataColumnFactory.CreateDataColumn(map[nameof(CountryCode)].Column, typeof(string), false, 3);
            DataColumn name = DataColumnFactory.CreateDataColumn(map[nameof(Name)].Column, typeof(string), false, 40);
            DataColumn nationalTaxRate = DataColumnFactory.CreateDataColumn(map[nameof(NationalTaxRate)].Column, typeof(decimal), false);
            DataColumn phoneMask = DataColumnFactory.CreateDataColumn(map[nameof(PhoneMask)].Column, typeof(string), false, 18);
            DataColumn tax_classA = DataColumnFactory.CreateDataColumn(map[nameof(Tax_ClassA)].Column, typeof(bool), false);
            DataColumn tax_classB = DataColumnFactory.CreateDataColumn(map[nameof(Tax_ClassB)].Column, typeof(bool), false);
            DataColumn tax_classC = DataColumnFactory.CreateDataColumn(map[nameof(Tax_ClassC)].Column, typeof(bool), false);
            DataColumn tax_classD = DataColumnFactory.CreateDataColumn(map[nameof(Tax_ClassD)].Column, typeof(bool), false);
            DataColumn tax_classE = DataColumnFactory.CreateDataColumn(map[nameof(Tax_ClassE)].Column, typeof(bool), false);
            DataColumn taxShipping = DataColumnFactory.CreateDataColumn(map[nameof(TaxShipping)].Column, typeof(bool), false);
            DataColumn iso2 = DataColumnFactory.CreateDataColumn(map[nameof(ISO2)].Column, typeof(string), false, 2);
            DataColumn iso3 = DataColumnFactory.CreateDataColumn(map[nameof(ISO3)].Column, typeof(string), false, 3);
            DataColumn isoNumber = DataColumnFactory.CreateDataColumn(map[nameof(ISONumber)].Column, typeof(string), false, 3);
            DataColumn rateClass_A = DataColumnFactory.CreateDataColumn(map[nameof(RateClass_A)].Column, typeof(decimal), false);
            DataColumn rateClass_B = DataColumnFactory.CreateDataColumn(map[nameof(RateClass_B)].Column, typeof(decimal), false);
            DataColumn rateClass_C = DataColumnFactory.CreateDataColumn(map[nameof(RateClass_C)].Column, typeof(decimal), false);
            DataColumn rateClass_D = DataColumnFactory.CreateDataColumn(map[nameof(RateClass_D)].Column, typeof(decimal), false);
            DataColumn rateClass_E = DataColumnFactory.CreateDataColumn(map[nameof(RateClass_E)].Column, typeof(decimal), false);
            DataColumn warehouse = DataColumnFactory.CreateDataColumn(map[nameof(Warehouse)].Column, typeof(string), false, 6);
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
            DataColumn countryId = DataColumnFactory.CreateDataColumn(map[nameof(CountryId)].Column, typeof(long), false);
            DataColumn lookupBy = DataColumnFactory.CreateDataColumn(map[nameof(LookupBy)].Column, typeof(string), false, 3);
            DataColumn lookupDate = DataColumnFactory.CreateDataColumn(map[nameof(LookupOn)].Column, typeof(DateTime), true);

            table.Columns.AddRange(new[]
            {
                countryCode,
                name,
                nationalTaxRate,
                phoneMask,
                tax_classA,
                tax_classB,
                tax_classC,
                tax_classD,
                tax_classE,
                taxShipping,
                iso2,
                iso3,
                isoNumber,
                rateClass_A,
                rateClass_B,
                rateClass_C,
                rateClass_D,
                rateClass_E,
                warehouse,
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
                countryId,
                lookupBy,
                lookupDate
            });

            table.PrimaryKey = new[] { countryId }; 

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
            return Equals(obj as IMultichannelOrderManagerCountry);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerCountry obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="IMultichannelOrderManagerCountry"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IMultichannelOrderManagerCountry"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerCountry a, IMultichannelOrderManagerCountry b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals =
                    a.Server.Equals(b.Server)
                        && String.Equals(a.CountryCode, b.CountryCode, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.ISO2, b.ISO2, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.ISO3, b.ISO3, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.ISONumber, b.ISONumber, StringComparison.InvariantCultureIgnoreCase)
                        && a.LCAP_A == b.LCAP_A
                        && a.LCAP_B == b.LCAP_B
                        && a.LCAP_C == b.LCAP_C
                        && a.LCAP_D == b.LCAP_D
                        && a.LCAP_E == b.LCAP_E
                        && String.Equals(a.LookupBy, b.LookupBy, StringComparison.InvariantCultureIgnoreCase)
                        && a.LookupOn.GetValueOrDefault().Equals(b.LookupOn.GetValueOrDefault())
                        && a.LTAXIT_A == b.LTAXIT_A
                        && a.LTAXIT_B == b.LTAXIT_B
                        && a.LTAXIT_C == b.LTAXIT_C
                        && a.LTAXIT_D == b.LTAXIT_D
                        && a.LTAXIT_E == b.LTAXIT_E
                        && String.Equals(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase)
                        && a.NationalTaxRate == b.NationalTaxRate
                        && a.NCAP_A == b.NCAP_A
                        && a.NCAP_B == b.NCAP_B
                        && a.NCAP_C == b.NCAP_C
                        && a.NCAP_D == b.NCAP_D
                        && a.NCAP_E == b.NCAP_E
                        && a.NONTAXBOX == b.NONTAXBOX
                        && a.NTAXIT_A == b.NTAXIT_A
                        && a.NTAXIT_B == b.NTAXIT_B
                        && a.NTAXIT_C == b.NTAXIT_C
                        && a.NTAXIT_D == b.NTAXIT_D
                        && a.NTAXIT_E == b.NTAXIT_E
                        && a.NTAXTHRES_A == b.NTAXTHRES_A
                        && a.NTAXTHRES_B == b.NTAXTHRES_B
                        && a.NTAXTHRES_C == b.NTAXTHRES_C
                        && a.NTAXTHRES_D == b.NTAXTHRES_D
                        && a.NTAXTHRES_E == b.NTAXTHRES_E
                        && String.Equals(a.PhoneMask, b.PhoneMask, StringComparison.InvariantCultureIgnoreCase)
                        && a.RateClass_A == b.RateClass_A
                        && a.RateClass_B == b.RateClass_B
                        && a.RateClass_C == b.RateClass_C
                        && a.RateClass_D == b.RateClass_D
                        && a.RateClass_E == b.RateClass_E
                        && a.TaxHandling == b.TaxHandling
                        && a.TaxShipping == b.TaxShipping
                        && a.Tax_ClassA == b.Tax_ClassA
                        && a.Tax_ClassB == b.Tax_ClassB
                        && a.Tax_ClassC == b.Tax_ClassC
                        && a.Tax_ClassD == b.Tax_ClassD
                        && a.Tax_ClassE == b.Tax_ClassE
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
        public virtual int GetHashCode(IMultichannelOrderManagerCountry obj)
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
            MultichannelOrderManagerCountry country = new MultichannelOrderManagerCountry();

            if (!String.IsNullOrWhiteSpace(CountryCode))
            {
                country.CountryCode = CountryCode;
            }

            country.CountryId = CountryId;
            country.ID = ID;

            if (!String.IsNullOrWhiteSpace(ISO2))
            {
                country.ISO2 = ISO2;
            }

            if (!String.IsNullOrWhiteSpace(ISO3))
            {
                country.ISO3 = ISO3;
            }

            if (!String.IsNullOrWhiteSpace(ISONumber))
            {
                country.ISONumber = ISONumber;
            }

            country.LCAP_A = LCAP_A;
            country.LCAP_B = LCAP_B;
            country.LCAP_C = LCAP_C;
            country.LCAP_D = LCAP_D;
            country.LCAP_E = LCAP_E;

            if (!String.IsNullOrWhiteSpace(LookupBy))
            {
                country.LookupBy = LookupBy;
            }

            country.LookupOn = LookupOn;
            country.LTAXIT_A = LTAXIT_A;
            country.LTAXIT_B = LTAXIT_B;
            country.LTAXIT_C = LTAXIT_C;
            country.LTAXIT_D = LTAXIT_D;
            country.LTAXIT_E = LTAXIT_E;
            country.MomObjectID = MomObjectID;

            if (!String.IsNullOrWhiteSpace(Name))
            {
                country.Name = Name;
            }

            country.NationalTaxRate = NationalTaxRate;
            country.NCAP_A = NCAP_A;
            country.NCAP_B = NCAP_B;
            country.NCAP_C = NCAP_C;
            country.NCAP_D = NCAP_D;
            country.NCAP_E = NCAP_E;
            country.NONTAXBOX = NONTAXBOX;
            country.NTAXIT_A = NTAXIT_A;
            country.NTAXIT_B = NTAXIT_B;
            country.NTAXIT_C = NTAXIT_C;
            country.NTAXIT_D = NTAXIT_D;
            country.NTAXIT_E = NTAXIT_E;
            country.NTAXTHRES_A = NTAXTHRES_A;
            country.NTAXTHRES_B = NTAXTHRES_B;
            country.NTAXTHRES_C = NTAXTHRES_C;
            country.NTAXTHRES_D = NTAXTHRES_D;
            country.NTAXTHRES_E = NTAXTHRES_E;

            if (!String.IsNullOrWhiteSpace(PhoneMask))
            {
                country.PhoneMask = PhoneMask;
            }

            country.RateClass_A = RateClass_A;
            country.RateClass_B = RateClass_B;
            country.RateClass_C = RateClass_C;
            country.RateClass_D = RateClass_D;
            country.RateClass_E = RateClass_E;
            country.Server = Server.Clone<MultichannelOrderManagerServer>();
            country.TaxHandling = TaxHandling;
            country.TaxShipping = TaxShipping;
            country.Tax_ClassA = Tax_ClassA;
            country.Tax_ClassB = Tax_ClassB;
            country.Tax_ClassC = Tax_ClassC;
            country.Tax_ClassD = Tax_ClassD;
            country.Tax_ClassE = Tax_ClassE;
            country.Warehouse = Warehouse.Clone<MultichannelOrderManagerWarehouse>();

            return country;
        }

        /// <summary>
        /// Compares the current instance to the specified <see cref="IMultichannelOrderManagerCountry"/> for determining sort order.
        /// </summary>
        /// <param name="country"><see cref="IMultichannelOrderManagerCountry"/> to compare against.</param>
        /// <returns>A signed integer that indicates the relative values of the current object and <paramref name="country"/>. Values less than zero indicates that the current object precedes <paramref name="country"/>; zero indicates that the values are equal; and values greater than zero indicate that the current object follows <paramref name="country"/>.</returns>
        public virtual int CompareTo(IMultichannelOrderManagerCountry country)
        {
            return CaseInsensitiveStringComparer.Instance.Compare(Name, country?.Name);
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return Name;
        }

    }
}
