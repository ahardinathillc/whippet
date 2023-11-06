using System;
using Newtonsoft.Json;
using Athi.Whippet.Json;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Data;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento.Directory.Models
{
    /// <summary>
    /// Represents a lightweight <see cref="ICountry"/> instance that can be used for intermediate serialization to and from <see cref="Country"/> instances. This class cannot be inherited.
    /// </summary>
    public sealed class CountryDataModel : ICountry, ICloneable, IWhippetCloneable, IJsonObject
    {
        /// <summary>
        /// This property is not supported.
        /// </summary>
        /// <exception cref="NotImplementedException" />
        Guid IWhippetEntity.ID
        {
            get
            {
                return Guid.Empty;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// This property is not supported.
        /// </summary>
        /// <exception cref="NotImplementedException" />
        uint IMagentoEntity.ID
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// This property is not supported.
        /// </summary>
        /// <exception cref="NotImplementedException" />
        IMagentoServer IMagentoEntity.Server
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// This property is not supported.
        /// </summary>
        /// <exception cref="NotImplementedException" />
        IMagentoRestEndpoint IMagentoEntity.RestEndpoint
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets the unique ID of the <see cref="ICountry"/>.
        /// </summary>
        [JsonProperty("id")]
        public string ID
        { get; set; }

        /// <summary>
        /// Gets or sets the unique ID of the <see cref="ICountry"/>.
        /// </summary>
        string ICountry.CountryID
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
        [JsonProperty("two_letter_abbreviation")]
        public string ISO2
        { get; set; }

        /// <summary>
        /// Gets or sets the ISO-3 country code.
        /// </summary>
        [JsonProperty("three_letter_abbreviation")]
        public string ISO3
        { get; set; }

        /// <summary>
        /// Gets or sets the locale-specific name of the <see cref="ICountry"/>.
        /// </summary>
        [JsonProperty("full_name_locale")]
        public string LocaleName
        { get; set; }

        /// <summary>
        /// Gets or sets the English name of the <see cref="ICountry"/>.
        /// </summary>
        [JsonProperty("full_name_english")]
        public string EnglishName
        { get; set; }

        /// <summary>
        /// Gets or sets the available regions for the store.
        /// </summary>
        [JsonProperty("available_regions")]
        public RegionDataModel[] AvailableRegions
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
                AvailableRegions = (value == null) ? null : value.Select(r => new RegionDataModel(r)).ToArray();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryDataModel"/> class with no arguments.
        /// </summary>
        public CountryDataModel()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryDataModel"/> class with the specified <see cref="ICountry"/>.
        /// </summary>
        /// <param name="country"><see cref="ICountry"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public CountryDataModel(ICountry country)
            : this()
        {
            ArgumentNullException.ThrowIfNull(country);

            ISO2 = country.ISO2;
            ISO3 = country.ISO3;
            LocaleName = country.LocaleName;
            EnglishName = country.EnglishName;
            ((ICountry)(this)).AvailableRegions = country.AvailableRegions;
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
        public bool Equals(ICountry obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ICountry x, ICountry y)
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
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="ICountry"/> object.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(ICountry obj)
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
        /// Converts the current instance to a <see cref="Country"/> object.
        /// </summary>
        /// <returns><see cref="Country"/> object.</returns>
        public Country ToCountry()
        {
            Country country = new Country();
            country.ID = ID;
            country.ISO2 = ISO2;
            country.ISO3 = ISO3;
            country.LocaleName = LocaleName;
            country.EnglishName = EnglishName;
            country.AvailableRegions = (AvailableRegions == null) ? null : new List<Region>(AvailableRegions.Select(r => r.ToRegion())).AsReadOnly();

            if (country.AvailableRegions != null)
            {
                foreach (Region r in country.AvailableRegions)
                {
                    r.Country = country;
                }
            }

            return country;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public object Clone()
        {
            return ToCountry();
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
        /// Serializes the current instance.
        /// </summary>
        /// <returns>JSON string.</returns>
        string IMagentoEntity.ToMagentoJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(ID) ? base.ToString() : ID;
        }

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be inherited.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public string ToJson<T>() where T : IJsonSerializableObject
        {
            return this.SerializeJson(this);
        }
    }
}

