using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Athi.Whippet.Json;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Directory;
using Athi.Whippet.Adobe.Magento.Taxes.Extensions;
using Athi.Whippet.Adobe.Magento.Taxes.Json.Newtonsoft;
using Athi.Whippet.Data;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento.Taxes.Models
{
    /// <summary>
    /// Represents an <see cref="ITaxRate"/> object for Magento Open Source. This class cannot be inherited.
    /// </summary>
    [JsonConverter(typeof(OpenSourceTaxRateConverter))]
    public sealed class OpenSourceTaxRateModel : ITaxRate, IMagentoEntity, IWhippetEntity, IWhippetCloneable, ICloneable
    {
        private const string JP_CODE = "code";
        private const string JP_RATE = "rate";
        private const string JP_TAX_COUNTRY_ID = "tax_country_id";
        private const string JP_TAX_POSTAL_CODE = "tax_postcode";
        private const string JP_TAX_REGION_ID = "tax_region_id";
        private const string JP_TITLES = "titles";
        private const string JP_ZIP_FROM = "zip_from";
        private const string JP_ZIP_TO = "zip_to";
        private const string JP_ZIP_IS_RANGE = "zip_is_range";

        private ITaxRate _taxRate;

        /// <summary>
        /// Gets or sets the internal <see cref="ITaxRate"/> object.
        /// </summary>
        private ITaxRate InternalObject
        {
            get
            {
                if (_taxRate == null)
                {
                    _taxRate = new TaxRate();
                }

                return _taxRate;
            }
            set
            {
                _taxRate = value;
            }
        }

        /// <summary>
        /// Unique identifier of the entity.
        /// </summary>
        Guid IWhippetEntity.ID
        {
            get
            {
                return ((IWhippetEntity)(InternalObject)).ID;
            }
            set
            {
                ((IWhippetEntity)(InternalObject)).ID = value;
            }
        }

        /// <summary>
        /// Gets or sets the unique ID of the <see cref="MagentoEntity"/>.
        /// </summary>
        uint IMagentoEntity.ID
        {
            get
            {
                return ((IMagentoEntity)(InternalObject)).ID;
            }
            set
            {
                ((IMagentoEntity)(InternalObject)).ID = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="MagentoServer"/> that the <see cref="MagentoEntity"/> resides on.
        /// </summary>
        IMagentoServer IMagentoEntity.Server
        {
            get
            {
                return InternalObject.Server;
            }
            set
            {
                InternalObject.Server = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="MagentoRestEndpoint"/> that the <see cref="MagentoEntity"/> resides on.
        /// </summary>
        IMagentoRestEndpoint IMagentoEntity.RestEndpoint
        {
            get
            {
                return InternalObject.RestEndpoint;
            }
            set
            {
                InternalObject.RestEndpoint = value;
            }
        }

        /// <summary>
        /// Gets or sets the unique ID of the <see cref="TaxRate"/>.
        /// </summary>
        public int ID
        {
            get
            {
                return InternalObject.ID;
            }
            set
            {
                InternalObject.ID = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="ICountry"/> that the <see cref="ITaxRate"/> applies to.
        /// </summary>
        ICountry ITaxRate.Country
        {
            get
            {
                return InternalObject.Country;
            }
            set
            {
                InternalObject.Country = value;
            }
        }

        /// <summary>
        /// Gets or sets the ISO-2 country identifier that the <see cref="ITaxRate"/> applies to.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty(JP_TAX_COUNTRY_ID)]
        public string CountryID
        {
            get
            {
                return InternalObject.CountryID;
            }
            set
            {
                InternalObject.CountryID = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IRegion"/> that the <see cref="ITaxRate"/> applies to.
        /// </summary>
        IRegion ITaxRate.Region
        {
            get
            {
                return InternalObject.Region;
            }
            set
            {
                InternalObject.Region = value;
            }
        }

        /// <summary>
        /// Gets or sets the ID of the region that the <see cref="ITaxRate"/> applies to.
        /// </summary>
        [JsonProperty(JP_TAX_REGION_ID)]
        public int RegionID
        {
            get
            {
                return InternalObject.RegionID;
            }
            set
            {
                InternalObject.RegionID = value;
            }
        }

        /// <summary>
        /// Gets or sets the postal code that the <see cref="TaxRate"/> applies to.
        /// </summary>
        [JsonProperty(JP_TAX_POSTAL_CODE)]
        public string PostalCode
        {
            get
            {
                return InternalObject.PostalCode;
            }
            set
            {
                InternalObject.PostalCode = value;
            }
        }

        /// <summary>
        /// Numeric flag that specifies whether the <see cref="PostalCode"/> value is a ZIP code and, if so, is represented as a range in <see cref="ZipFrom"/> and <see cref="ZipTo"/>.
        /// </summary>
        [JsonProperty(JP_ZIP_IS_RANGE)]
        public int ZipIsRange
        {
            get
            {
                return InternalObject.ZipIsRange;
            }
            set
            {
                InternalObject.ZipIsRange = value;
            }
        }

        /// <summary>
        /// Lower-bound ZIP code value that the <see cref="TaxRate"/> applies to.
        /// </summary>
        [JsonProperty(JP_ZIP_FROM)]
        public int ZipFrom
        {
            get
            {
                return InternalObject.ZipFrom;
            }
            set
            {
                InternalObject.ZipFrom = value;
            }
        }

        /// <summary>
        /// Upper-bound ZIP code value that the <see cref="TaxRate"/> applies to.
        /// </summary>
        [JsonProperty(JP_ZIP_TO)]
        public int ZipTo
        {
            get
            {
                return InternalObject.ZipTo;
            }
            set
            {
                InternalObject.ZipTo = value;
            }
        }

        /// <summary>
        /// Gets or sets the numeric tax rate value.
        /// </summary>
        [JsonProperty(JP_RATE)]
        public decimal Rate
        {
            get
            {
                return InternalObject.Rate;
            }
            set
            {
                InternalObject.Rate = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="ITaxRate"/> code.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty(JP_CODE)]
        public string Code
        {
            get
            {
                return InternalObject.Code;
            }
            set
            {
                InternalObject.Code = value;
            }
        }

        /// <summary>
        /// Gets or sets the available <see cref="TaxRateTitle"/> associations for the <see cref="TaxRate"/>.
        /// </summary>
        [JsonProperty(JP_TITLES)]
        public IEnumerable<TaxRateTitle> Titles
        {
            get
            {
                return (InternalObject.Titles == null || !InternalObject.Titles.Any()) ? null : new ReadOnlyCollection<TaxRateTitle>(new List<TaxRateTitle>(InternalObject.Titles.Select(trt => trt.ToTaxRateTitle())));;
            }
            set
            {
                InternalObject.Titles = value;
            }
        }

        /// <summary>
        /// Gets or sets the available <see cref="ITaxRateTitle"/> associations for the <see cref="ITaxRate"/>.
        /// </summary>
        IEnumerable<ITaxRateTitle> ITaxRate.Titles
        {
            get
            {
                return InternalObject.Titles;
            }
            set
            {
                InternalObject.Titles = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenSourceTaxRateModel"/> class with no arguments.
        /// </summary>
        public OpenSourceTaxRateModel()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenSourceTaxRateModel"/> class with the specified <see cref="ITaxRate"/>.
        /// </summary>
        /// <param name="taxRate"><see cref="ITaxRate"/> object to initialize with.</param>
        public OpenSourceTaxRateModel(ITaxRate taxRate)
            : this()
        {
            InternalObject = taxRate;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return InternalObject.Equals(obj);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ITaxRate obj)
        {
            return InternalObject.Equals(obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ITaxRate x, ITaxRate y)
        {
            return InternalObject.Equals(x, y);
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return InternalObject.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="ITaxRate"/> object.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(ITaxRate obj)
        {
            return InternalObject.GetHashCode(obj);
        }
        
        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public object Clone()
        {
            return InternalObject.Clone();
        }
        
        /// <summary>
        /// Creates a duplicate instance of the current object with the optional <see cref="Guid"/> that represents the user ID of the user who instantiated the new instance.
        /// </summary>
        /// <typeparam name="TObject">Type of object to return from the operation.</typeparam>
        /// <param name="createdBy"><see cref="Guid"/> ID of the user who instantiated the new instance.</param>
        /// <returns>Object of type <typeparamref name="TObject"/>.</returns>
        public TObject Clone<TObject>(Guid? createdBy = null)
        {
            return InternalObject.Clone<TObject>(createdBy);
        }
        
        /// <summary>
        /// Returns the current instance as a JSON object in a <see cref="String"/> that is defined by the API documentation in Magento. This is typically used for POST and PUT requests as the default serializer suffices in GET requests.
        /// </summary>
        /// <returns><see cref="String"/> containing the JSON object representation of the current instance.</returns>
        public string ToMagentoJsonString()
        {
            return InternalObject.ToMagentoJsonString(true);
        }
        
        /// <summary>
        /// Returns the current instance as a JSON object in a <see cref="String"/> that is defined by the API documentation in Magento. This is typically used for POST and PUT requests as the default serializer suffices in GET requests.
        /// </summary>
        /// <param name="openSource">If <see langword="true"/>, will generate the JSON necessary for Magento Open Source.</param>
        /// <returns><see cref="String"/> containing the JSON object representation of the current instance.</returns>
        /// <remarks>See <a href="https://magento.stackexchange.com/questions/3480/how-to-programatically-create-tax-rates">How to Programatically Create Tax Rates</a> as the Adobe documentation is incorrect.</remarks>
        string ITaxRate.ToMagentoJsonString(bool openSource)
        {
            return InternalObject.ToMagentoJsonString(openSource);
        }
        
        /// <summary>
        /// Returns a JSON string representing the current object. This method must be inherited.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public string ToJson<T>() where T : IJsonSerializableObject
        {
            return InternalObject.SerializeJson(this);
        }
        
        /// <summary>
        /// Builds the <see cref="Code"/> value based on the specified parameters.
        /// </summary>
        /// <param name="countryIso2">ISO-2 abbreviation of the country.</param>
        /// <param name="stateProvinceAbbreviation">Two-letter state or province abbreviation.</param>
        /// <param name="postalCode">Postal code for the rate (if any).</param>
        /// <exception cref="ArgumentNullException" />
        void ITaxRate.BuildCode(string countryIso2, string stateProvinceAbbreviation, string postalCode)
        {
            InternalObject.BuildCode(countryIso2, stateProvinceAbbreviation, postalCode);
        }

        public static implicit operator OpenSourceTaxRateModel(TaxRate taxRate)
        {
            return (taxRate == null) ? null : new OpenSourceTaxRateModel(taxRate);
        }
    }
}
