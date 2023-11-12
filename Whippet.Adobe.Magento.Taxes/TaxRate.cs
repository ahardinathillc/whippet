using System;
using System.Collections.ObjectModel;
using System.Text;
using Newtonsoft.Json;
using Athi.Whippet.Json;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Directory;
using Athi.Whippet.Adobe.Magento.Directory.Extensions;
using Athi.Whippet.Adobe.Magento.Taxes.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento.Taxes
{
    /// <summary>
    /// Tax rate that is applied to a region in Magento.
    /// </summary>
    public class TaxRate : MagentoEntity, IMagentoEntity, ITaxRate, IEqualityComparer<ITaxRate>, ICloneable, IWhippetCloneable, IJsonObject
    {
        /// <summary>
        /// Default <see cref="TaxRate.Code"/> that indicates the tax rate is tax-exempt.
        /// </summary>
        public const string DEFAULT_TAX_EXEMPT_CODE = "EXEMPT";

        private const string JP_CODE = "code";
        private const string JP_ID = "id";
        private const string JP_RATE = "rate";
        private const string JP_REGION_NAME = "region_name";
        private const string JP_TAX_COUNTRY_ID = "tax_country_id";
        private const string JP_TAX_POSTAL_CODE = "tax_postcode";
        private const string JP_TAX_REGION_ID = "tax_region_id";
        private const string JP_TITLES = "titles";
        private const string JP_TITLE = "title";
        private const string JP_STORE_ID = "store_id";
        private const string JP_VALUE = "value";
        private const string JP_ZIP_FROM = "zip_from";
        private const string JP_ZIP_TO = "zip_to";
        private const string JP_ZIP_IS_RANGE = "zip_is_range";

        private const byte MAX_LEN_CODE = 255;

        private string _code;

        private Country _country;
        private Region _region;

        /// <summary>
        /// Gets or sets the unique ID of the <see cref="TaxRate"/>.
        /// </summary>
        public new int ID
        {
            get
            {
                return Convert.ToInt32(base.ID);
            }
            set
            {
                base.ID = Convert.ToUInt32(value);
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Directory.Country"/> that the <see cref="TaxRate"/> applies to.
        /// </summary>
        public virtual Country Country
        {
            get
            {
                if (_country == null)
                {
                    _country = new Country();
                }

                return _country;
            }
            set
            {
                _country = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="ICountry"/> that the <see cref="ITaxRate"/> applies to.
        /// </summary>
        ICountry ITaxRate.Country
        {
            get
            {
                return Country;
            }
            set
            {
                Country = value.ToCountry();
            }
        }

        /// <summary>
        /// Gets or sets the ISO-2 country identifier that the <see cref="TaxRate"/> applies to.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty(JP_TAX_COUNTRY_ID)]
        public virtual string CountryID
        {
            get
            {
                return Country.ID;
            }
            set
            {
                Country = new Country(value, Server);
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Directory.Region"/> that the <see cref="TaxRate"/> applies to.
        /// </summary>
        public virtual Region Region
        {
            get
            {
                if (_region == null)
                {
                    _region = new Region();
                }

                return _region;
            }
            set
            {
                _region = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IRegion"/> that the <see cref="ITaxRate"/> applies to.
        /// </summary>
        IRegion ITaxRate.Region
        {
            get
            {
                return Region;
            }
            set
            {
                Region = value.ToRegion();
            }
        }

        /// <summary>
        /// Gets or sets the ID of the <see cref="Directory.Region"/> that the <see cref="TaxRate"/> applies to.
        /// </summary>
        [JsonProperty(JP_TAX_REGION_ID)]
        public virtual int RegionID
        {
            get
            {
                return Convert.ToInt32(Region.ID);
            }
            set
            {
                Region = new Region(Convert.ToUInt32(value), Server);
            }
        }

        /// <summary>
        /// Gets or sets the postal code that the <see cref="TaxRate"/> applies to.
        /// </summary>
        [JsonProperty(JP_TAX_POSTAL_CODE)]
        public virtual string PostalCode
        { get; set; }

        /// <summary>
        /// Numeric flag that specifies whether the <see cref="PostalCode"/> value is a ZIP code and, if so, is represented as a range in <see cref="ZipFrom"/> and <see cref="ZipTo"/>.
        /// </summary>
        [JsonProperty(JP_ZIP_IS_RANGE)]
        public virtual int ZipIsRange
        {
            get
            {
                return ZipIsRangeInternal.GetValueOrDefault();
            }
            set
            {
                ZipIsRangeInternal = Convert.ToInt16(value);
            }
        }

        /// <summary>
        /// Numeric flag that specifies whether the <see cref="PostalCode"/> value is a ZIP code and, if so, is represented as a range in <see cref="ZipFrom"/> and <see cref="ZipTo"/>.
        /// </summary>
        protected internal virtual short? ZipIsRangeInternal
        { get; set; }

        /// <summary>
        /// Lower-bound ZIP code value that the <see cref="TaxRate"/> applies to.
        /// </summary>
        [JsonProperty(JP_ZIP_FROM)]
        public virtual int ZipFrom
        {
            get
            {
                return Convert.ToInt32(ZipFromInternal.GetValueOrDefault());
            }
            set
            {
                ZipFromInternal = Convert.ToUInt32(value);
            }
        }

        /// <summary>
        /// Upper-bound ZIP code value that the <see cref="TaxRate"/> applies to.
        /// </summary>
        [JsonProperty(JP_ZIP_TO)]
        public virtual int ZipTo
        {
            get
            {
                return Convert.ToInt32(ZipToInternal.GetValueOrDefault());
            }
            set
            {
                ZipToInternal = Convert.ToUInt32(value);
            }
        }

        /// <summary>
        /// Lower-bound ZIP code value that the <see cref="TaxRate"/> applies to.
        /// </summary>
        protected internal virtual uint? ZipFromInternal
        { get; set; }

        /// <summary>
        /// Upper-bound ZIP code value that the <see cref="TaxRate"/> applies to.
        /// </summary>
        protected internal virtual uint? ZipToInternal
        { get; set; }

        /// <summary>
        /// Gets or sets the numeric tax rate value.
        /// </summary>
        [JsonProperty(JP_RATE)]
        public virtual decimal Rate
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="TaxRate"/> code.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty(JP_CODE)]
        public virtual string Code
        {
            get
            {
                return _code;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value) && (value.Length > MAX_LEN_CODE))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                else
                {
                    _code = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the available <see cref="TaxRateTitle"/> associations for the <see cref="TaxRate"/>.
        /// </summary>
        [JsonProperty(JP_TITLES)]
        public virtual IEnumerable<TaxRateTitle> Titles
        { get; set; }

        /// <summary>
        /// Gets or sets the available <see cref="ITaxRateTitle"/> associations for the <see cref="ITaxRate"/>.
        /// </summary>
        IEnumerable<ITaxRateTitle> ITaxRate.Titles
        {
            get
            {
                return Titles;
            }
            set
            {
                Titles = (value == null) ? null : new ReadOnlyCollection<TaxRateTitle>(new List<TaxRateTitle>(value.Select(trt => trt.ToTaxRateTitle())));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRate"/> class with no arguments.
        /// </summary>
        public TaxRate()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRate"/> class with the specified class ID and <see cref="MagentoServer"/>.
        /// </summary>
        /// <param name="rateId">Tax rate ID.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        public TaxRate(int rateId, MagentoServer server)
            : base(Convert.ToUInt32(rateId), server)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return (obj == null || !(obj is ITaxRate)) ? false : Equals(obj as ITaxRate);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ITaxRate obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ITaxRate x, ITaxRate y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = ((x.Country == null && y.Country == null) || (x.Country != null && x.Country.Equals(y.Country)))
                    && String.Equals(x.Code, y.Code, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.PostalCode, y.PostalCode, StringComparison.InvariantCultureIgnoreCase)
                    && (x.Rate == y.Rate)
                    && ((x.Region == null && y.Region == null) || (x.Region != null && x.Region.Equals(y.Region)))
                    && (x.ZipFrom == y.ZipFrom)
                    && (x.ZipTo == y.ZipTo);
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
        /// <param name="obj"><see cref="ITaxRate"/> object.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ITaxRate obj)
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
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public virtual object Clone()
        {
            TaxRate rate = new TaxRate();

            rate.Code = Code;
            rate.Country = Country.Clone<Country>();
            rate.ID = ID;
            rate.PostalCode = PostalCode;
            rate.Rate = Rate;
            rate.Region = Region.Clone<Region>();
            rate.RestEndpoint = RestEndpoint.Clone<MagentoRestEndpoint>();
            rate.Server = Server.Clone<MagentoServer>();

            if (Titles != null && Titles.Any())
            {
                rate.Titles = Titles.Select(t => t.Clone<TaxRateTitle>());
            }

            rate.ZipFrom = ZipFrom;
            rate.ZipFromInternal = ZipFromInternal;
            rate.ZipIsRange = ZipIsRange;
            rate.ZipIsRangeInternal = ZipIsRangeInternal;
            rate.ZipTo = ZipTo;
            rate.ZipToInternal = ZipToInternal;

            return rate;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object with the optional <see cref="Guid"/> that represents the user ID of the user who instantiated the new instance.
        /// </summary>
        /// <typeparam name="TObject">Type of object to return from the operation.</typeparam>
        /// <param name="createdBy"><see cref="Guid"/> ID of the user who instantiated the new instance.</param>
        /// <returns>Object of type <typeparamref name="TObject"/>.</returns>
        public virtual TObject Clone<TObject>(Guid? createdBy = null)
        {
            return (TObject)(Clone());
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(Code) ? base.ToString() : Code + " [" + Region.ToString() + "]";
        }

        /// <summary>
        /// Returns the current instance as a JSON object in a <see cref="String"/> that is defined by the API documentation in Magento. This is typically used for POST and PUT requests as the default serializer suffices in GET requests.
        /// </summary>
        /// <returns><see cref="String"/> containing the JSON object representation of the current instance.</returns>
        /// <remarks>See <a href="https://magento.stackexchange.com/questions/3480/how-to-programatically-create-tax-rates">How to Programatically Create Tax Rates</a> as the Adobe documentation is incorrect.</remarks>
        public override string ToMagentoJsonString()
        {
            return ToMagentoJsonString(true);
        }

        /// <summary>
        /// Returns the current instance as a JSON object in a <see cref="String"/> that is defined by the API documentation in Magento. This is typically used for POST and PUT requests as the default serializer suffices in GET requests.
        /// </summary>
        /// <param name="openSource">If <see langword="true"/>, will generate the JSON necessary for Magento Open Source.</param>
        /// <returns><see cref="String"/> containing the JSON object representation of the current instance.</returns>
        /// <remarks>See <a href="https://magento.stackexchange.com/questions/3480/how-to-programatically-create-tax-rates">How to Programatically Create Tax Rates</a> as the Adobe documentation is incorrect.</remarks>
        public string ToMagentoJsonString(bool openSource)
        {
            return InternalToMagentoJsonString(openSource);
        }

        /// <summary>
        /// Returns the current instance as a JSON object in a <see cref="String"/> that is defined by the API documentation in Magento. This is typically used for POST and PUT requests as the default serializer suffices in GET requests.
        /// </summary>
        /// <returns><see cref="String"/> containing the JSON object representation of the current instance.</returns>
        /// <remarks>If creating for Open Source, see <a href="https://magento.stackexchange.com/questions/3480/how-to-programatically-create-tax-rates">How to Programatically Create Tax Rates</a> as the Adobe documentation is incorrect.</remarks>
        private string InternalToMagentoJsonString(bool openSource)
        {
            StringBuilder stringBuilder = new StringBuilder();
            StringWriter stringWriter = new StringWriter(stringBuilder);

            using (JsonWriter writer = new JsonTextWriter(stringWriter))
            {
                writer.Formatting = Formatting.Indented;

                writer.WriteStartObject();

                writer.WritePropertyName("taxRate");
                writer.WriteStartObject();                          // tax rate object - start

                writer.WritePropertyName(JP_CODE);
                writer.WriteValue(Code);

                if (ID > 0)
                {
                    writer.WritePropertyName(JP_ID);
                    writer.WriteValue(ID);
                }

                writer.WritePropertyName(JP_RATE);
                writer.WriteValue(Rate);

                if (!openSource)
                {
                    writer.WritePropertyName(JP_REGION_NAME);
                    writer.WriteValue(Region.Name);
                }

                writer.WritePropertyName(JP_TAX_COUNTRY_ID);
                writer.WriteValue(CountryID);

                writer.WritePropertyName(JP_TAX_POSTAL_CODE);
                writer.WriteValue(PostalCode);

                writer.WritePropertyName(JP_TAX_REGION_ID);
                writer.WriteValue(RegionID);

                if (Titles != null && Titles.Any())
                {
                    writer.WritePropertyName(JP_TITLES);
                    writer.WriteStartArray();

                    foreach (TaxRateTitle title in Titles)
                    {
                        if (title != null)
                        {
                            writer.WriteStartObject();
                            writer.WritePropertyName(JP_STORE_ID);
                            writer.WriteValue(title.StoreID);
                            writer.WritePropertyName(JP_VALUE);
                            writer.WriteValue(title.Value);
                            writer.WriteEndObject();
                        }
                    }

                    writer.WriteEndArray();
                }

                if (!openSource)
                {
                    writer.WritePropertyName(JP_ZIP_FROM);

                    if (ZipFrom > 0)
                    {
                        writer.WriteValue(ZipFrom);
                    }
                    else
                    {
                        writer.WriteNull();
                    }

                    writer.WritePropertyName(JP_ZIP_TO);

                    if (ZipTo > 0)
                    {
                        writer.WriteValue(ZipTo);
                    }
                    else
                    {
                        writer.WriteNull();
                    }

                    writer.WritePropertyName(JP_TITLE);
                    writer.WriteValue(Code);
                }

                writer.WritePropertyName(JP_ZIP_IS_RANGE);
                writer.WriteValue(ZipIsRange);

                writer.WriteEndObject();                            // tax rate object - end

                writer.WriteEndObject();
            }

            return stringBuilder.ToString();
        }
        
        /// <summary>
        /// Builds the <see cref="Code"/> value based on the specified parameters.
        /// </summary>
        /// <param name="countryIso2">ISO-2 abbreviation of the country.</param>
        /// <param name="stateProvinceAbbreviation">Two-letter state or province abbreviation.</param>
        /// <param name="postalCode">Postal code for the rate (if any).</param>
        /// <exception cref="ArgumentNullException" />
        public virtual void BuildCode(string countryIso2, string stateProvinceAbbreviation, string postalCode)
        {
            BuildCode(countryIso2, stateProvinceAbbreviation, postalCode, out string code);
            Code = code;
        }

        /// <summary>
        /// Builds the <see cref="Code"/> value based on the specified parameters.
        /// </summary>
        /// <param name="countryIso2">ISO-2 abbreviation of the country.</param>
        /// <param name="stateProvinceAbbreviation">Two-letter state or province abbreviation.</param>
        /// <param name="postalCode">Postal code for the rate (if any).</param>
        /// <param name="code"><see cref="TaxRate.Code"/> value.</param>
        /// <exception cref="ArgumentNullException" />
        public static void BuildCode(string countryIso2, string stateProvinceAbbreviation, string postalCode, out string code)
        {
            if (String.IsNullOrWhiteSpace(countryIso2))
            {
                throw new ArgumentNullException(nameof(countryIso2));
            }
            else
            {
                StringBuilder builder = new StringBuilder();

                builder.Append(countryIso2);
                builder.Append('-');

                if (String.IsNullOrWhiteSpace(stateProvinceAbbreviation))
                {
                    builder.Append('*');
                }
                else
                {
                    builder.Append(stateProvinceAbbreviation);
                    builder.Append('-');

                    if (String.IsNullOrWhiteSpace(postalCode))
                    {
                        builder.Append('*');
                    }
                    else
                    {
                        builder.Append(postalCode);
                    }
                }

                code = builder.ToString();
            }
        }

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be inherited.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public override string ToJson<T>()
        {
            return this.SerializeJson(this);
        }
    }
}
