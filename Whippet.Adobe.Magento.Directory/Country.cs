using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Directory.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento.Directory
{
    /// <summary>
    /// Represents a country in Magento. This entity only encapsulates the ISO-2 and ISO-3 country codes.
    /// </summary>
    public class Country : MagentoEntity, IMagentoEntity, ICountry, IEqualityComparer<ICountry>, ICloneable, IWhippetCloneable
    {
        private const byte MAX_LEN_ID = 2;
        private const byte MAX_LEN_ISO2 = 2;
        private const byte MAX_LEN_ISO3 = 3;

        private string _countryID;
        private string _iso2;
        private string _iso3;
        private string _nameLocale;
        private string _nameEnglish;

        /// <summary>
        /// Gets or sets the unique ID of the <see cref="MagentoEntity"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("id")]
        public new virtual string ID
        {
            get
            {
                return _countryID;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value) && (value.Length > MAX_LEN_ID))
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _countryID = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the unique ID of the <see cref="Country"/>.
        /// </summary>
        public virtual string CountryID
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }

        /// <summary>
        /// Gets or sets the ISO-2 country code.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("two_letter_abbreviation")]
        public virtual string ISO2
        {
            get
            {
                return _iso2;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value) && (value.Length > MAX_LEN_ISO2))
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _iso2 = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the ISO-3 country code.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("three_letter_abbreviation")]
        public virtual string ISO3
        {
            get
            {
                return _iso3;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value) && (value.Length > MAX_LEN_ISO3))
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _iso3 = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the locale-specific name of the <see cref="Country"/>.
        /// </summary>
        [JsonProperty("full_name_locale")]
        public virtual string LocaleName
        {
            get
            {
                return _nameLocale;
            }
            set
            {
                _nameLocale = value;
            }
        }

        /// <summary>
        /// Gets or sets the English name of the <see cref="Country"/>.
        /// </summary>
        [JsonProperty("full_name_english")]
        public virtual string EnglishName
        {
            get
            {
                return _nameEnglish;
            }
            set
            {
                _nameEnglish = value;
            }
        }

        /// <summary>
        /// Gets or sets the available regions for the store.
        /// </summary>
        [JsonProperty("available_regions")]
        [JsonIgnore]
        public virtual IReadOnlyList<Region> AvailableRegions
        { get; set; }

        /// <summary>
        /// Gets or sets the available regions for the store.
        /// </summary>
        IEnumerable<IRegion> ICountry.AvailableRegions
        {
            get
            {
                return AvailableRegions;
            }
            set
            {
                AvailableRegions = (value == null) ? null : new ReadOnlyCollection<Region>(value.Select(r => r.ToRegion()).ToList());
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Country"/> class with no arguments.
        /// </summary>
        public Country()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Country"/> class with the specified ID and <see cref="MagentoServer"/>.
        /// </summary>
        /// <param name="id">Country ID.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public Country(string id, MagentoServer server)
            : this(id, null, null, server)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Country"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Country ID.</param>
        /// <param name="iso2">ISO-2 country code.</param>
        /// <param name="iso3">ISO-3 country code.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public Country(string id, string iso2, string iso3, MagentoServer server)
            : this(id, iso2, iso3, null, null, null, server, false, false)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Country"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Country ID.</param>
        /// <param name="iso2">ISO-2 country code.</param>
        /// <param name="iso3">ISO-3 country code.</param>
        /// <param name="localeName">Locale name.</param>
        /// <param name="englishName">English name.</param>
        /// <param name="availableRegions">Available <see cref="Region"/> objects assigned to the country.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public Country(string id, string iso2, string iso3, string localeName, string englishName, IEnumerable<Region> availableRegions, MagentoServer server)
            : this(id, iso2, iso3, localeName, englishName, availableRegions, server, true, true)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Country"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Country ID.</param>
        /// <param name="iso2">ISO-2 country code.</param>
        /// <param name="iso3">ISO-3 country code.</param>
        /// <param name="localeName">Locale name.</param>
        /// <param name="englishName">English name.</param>
        /// <param name="availableRegions">Available <see cref="Region"/> objects assigned to the country.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="hasLocale">Indicates whether <paramref name="localeName"/> should contain a value.</param>
        /// <param name="hasEnglishName">Indicates whether <paramref name="englishName"/> should contain a value.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        private Country(string id, string iso2, string iso3, string localeName, string englishName, IEnumerable<Region> availableRegions, MagentoServer server, bool hasLocale, bool hasEnglishName)
            : base(default(int), server)
        {
            ID = id;
            ISO2 = iso2;
            ISO3 = iso3;

            if (hasLocale)
            {
                LocaleName = localeName;
            }

            if (hasEnglishName)
            {
                EnglishName = englishName;
            }

            AvailableRegions = (availableRegions == null ? null : new ReadOnlyCollection<Region>(new List<Region>(availableRegions)));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return (obj == null || !(obj is ICountry)) ? false : Equals(obj as ICountry);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ICountry obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ICountry x, ICountry y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.ID, y.ID, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.CountryID, y.CountryID, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.ISO2, y.ISO2, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.ISO3, y.ISO3, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.LocaleName, y.LocaleName, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.EnglishName, y.EnglishName, StringComparison.InvariantCultureIgnoreCase);
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
        /// <param name="obj"><see cref="ICountry"/> object.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ICountry obj)
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
            Country obj = new Country();
            List<Region> regions = new List<Region>();

            if (AvailableRegions != null && AvailableRegions.Count > 0)
            {
                foreach (Region region in AvailableRegions)
                {
                    regions.Add(region.Clone<Region>());
                }
            }

            obj.AvailableRegions = regions.AsReadOnly();
            obj.EnglishName = EnglishName;
            obj.ID = ID;
            obj.ISO2 = ISO2;
            obj.ISO3 = ISO3;
            obj.LocaleName = LocaleName;
            obj.RestEndpoint = RestEndpoint.Clone<MagentoRestEndpoint>();
            obj.Server = Server.Clone<MagentoServer>();

            return obj;
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
            return String.IsNullOrWhiteSpace(CountryID) ? base.ToString() : CountryID;
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

