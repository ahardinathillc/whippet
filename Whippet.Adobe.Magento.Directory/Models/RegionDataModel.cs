using System;
using Newtonsoft.Json;
using Athi.Whippet.Json;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Directory.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento.Directory.Models
{
    /// <summary>
    /// Represents a lightweight <see cref="IRegion"/> instance that can be used for intermediate serialization to and from <see cref="Region"/> instances. This class cannot be inherited.
    /// </summary>
    public sealed class RegionDataModel : IRegion, ICloneable, IWhippetCloneable, IJsonObject
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
        /// Gets or sets the unique ID of the <see cref="IRegion"/>.
        /// </summary>
        [JsonProperty("id")]
        public string ID
        { get; set; }

        /// <summary>
        /// Gets or sets the unique region ID.
        /// </summary>
        string IRegion.RegionID
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
        /// Gets or sets the <see cref="ICountry"/> that the <see cref="IRegion"/> belongs to.
        /// </summary>
        ICountry IRegion.Country
        { get; set; }

        /// <summary>
        /// Gets or sets the ID of the <see cref="ICountry"/> that the <see cref="IRegion"/> belongs to.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        string IRegion.CountryID
        {
            get
            {
                return (((IRegion)(this)).Country == null ? null : ((IRegion)(this)).Country.ID);
            }
            set
            {
                if (((IRegion)(this)).Country == null)
                {
                    ((IRegion)(this)).Country = new Country();
                }

                ((IRegion)(this)).Country.ID = value;
            }
        }

        /// <summary>
        /// Gets or sets the region code.
        /// </summary>
        [JsonProperty("code")]
        public string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the region name.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionDataModel"/> class with no arguments.
        /// </summary>
        public RegionDataModel()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionDataModel"/> class with the specified <see cref="IRegion"/>.
        /// </summary>
        /// <param name="region"><see cref="IRegion"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public RegionDataModel(IRegion region)
            : this()
        {
            ArgumentNullException.ThrowIfNull(region);

            ID = region.RegionID;
            ((IRegion)(this)).Country = region.Country;
            ((IRegion)(this)).CountryID = region.CountryID;
            Code = region.Code;
            Name = region.Name;
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
        public bool Equals(IRegion obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(IRegion x, IRegion y)
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
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="IRegion"/> object.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(IRegion obj)
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
        /// Converts the current instance to a <see cref="Region"/> object.
        /// </summary>
        /// <returns><see cref="Region"/> object.</returns>
        public Region ToRegion()
        {
            Region region = new Region();
            region.RegionID = ID;
            region.Code = Code;
            region.Country = ((IRegion)(this)).Country.ToCountry();
            region.CountryID = ((IRegion)(this)).CountryID;
            region.Name = Name;

            return region;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public object Clone()
        {
            return ToRegion();
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
            return String.IsNullOrWhiteSpace(Name) ? base.ToString() : Name + ((((IRegion)(this)).Country != null) ? "[" + ((IRegion)(this)).Country.ToString() + "]" : String.Empty);
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

