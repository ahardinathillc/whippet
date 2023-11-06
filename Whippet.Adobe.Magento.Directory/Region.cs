using System;
using Newtonsoft.Json;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Directory.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento.Directory
{
    /// <summary>
    /// Represents a country region in Magento.
    /// </summary>
    public class Region : MagentoEntity, IMagentoEntity, IRegion, IEqualityComparer<IRegion>, ICloneable, IWhippetCloneable, IJsonObject
    {
        private const byte MAX_LEN_CODE = 32;
        private const byte MAX_LEN_NAME = 255;

        private Country _country;

        private string _code;
        private string _defaultName;

        /// <summary>
        /// Gets or sets the region ID. This is a <see cref="String"/> version of <see cref="MagentoEntity.ID"/>.
        /// </summary>
        /// <exception cref="FormatException" />
        /// <exception cref="OverflowException" />
        [JsonProperty("id")]
        public virtual string RegionID
        {
            get
            {
                return Convert.ToString(base.ID);
            }
            set
            {
                base.ID = !String.IsNullOrWhiteSpace(value) ? Convert.ToUInt32(value) : default(uint);
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Directory.Country"/> that the <see cref="Region"/> belongs to.
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
        /// Gets or sets the <see cref="ICountry"/> that the <see cref="IRegion"/> belongs to.
        /// </summary>
        ICountry IRegion.Country
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
        /// Gets or sets the ID of the <see cref="Directory.Country"/> that the <see cref="Region"/> belongs to.
        /// </summary>
        public virtual string CountryID
        {
            get
            {
                return String.IsNullOrWhiteSpace(Country.ID) ? "0" : Country.ID;
            }
            set
            {
                Country = String.IsNullOrWhiteSpace(value) ? new Country() : new Country(value, Server);
            }
        }

        /// <summary>
        /// Gets or sets the region code.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("code")]
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
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _code = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the region name.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("name")]
        public virtual string Name
        {
            get
            {
                return _defaultName;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value) && (value.Length > MAX_LEN_NAME))
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _defaultName = value;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Region"/> class with no arguments.
        /// </summary>
        public Region()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Region"/> class with the specified ID and <see cref="MagentoServer"/>.
        /// </summary>
        /// <param name="id">Region ID.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        public Region(uint id, MagentoServer server)
            : base(id, server)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Region"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Region ID.</param>
        /// <param name="country"><see cref="Directory.Country"/> the <see cref="Region"/> belongs to.</param>
        /// <param name="code">Region code.</param>
        /// <param name="name">Region name.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        public Region(uint id, Country country, string code, string name, MagentoServer server)
            : this(id, server)
        {
            Country = country;
            Code = code;
            Name = name;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return (obj == null || !(obj is IRegion)) ? false : Equals(obj as IRegion);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IRegion obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IRegion x, IRegion y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = ((x.Country == null && y.Country == null) || (x.Country != null && x.Country.Equals(y.Country)))
                    && String.Equals(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Code, y.Code, StringComparison.InvariantCultureIgnoreCase);
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
        /// <param name="obj"><see cref="IRegion"/> object.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IRegion obj)
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
            Region obj = new Region();

            obj.Code = Code;
            obj.Country = new Country(Country.CountryID, Country.ISO2, Country.ISO3, Country.LocaleName, Country.EnglishName, Country.AvailableRegions, Country.Server.Clone<MagentoServer>());     // have to do this manually
            obj.ID = ID;
            obj.Name = Name;
            obj.RegionID = RegionID;
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
            return String.IsNullOrWhiteSpace(Name) ? base.ToString() : Name + " [" + Country.ToString() + "]";
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

