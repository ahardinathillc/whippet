using System;
using Athi.Whippet.Json;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Directory.Extensions;

namespace Athi.Whippet.Adobe.Magento.Directory
{
    /// <summary>
    /// Represents a country in Magento.
    /// </summary>
    public class Country : MagentoRestEntity<CountryInterface>, IMagentoEntity, IEqualityComparer<ICountry>, ICloneable, IWhippetCloneable, IJsonObject, IMagentoRestEntity, ICountry
    {
        /// <summary>
        /// Gets or sets the country ID. The country ID is the country's ISO-2 code.
        /// </summary>
        public new virtual string ID
        {
            get
            {
                return ISO2;
            }
            set
            {
                ISO2 = value;
            }
        }
                
        /// <summary>
        /// Gets or sets the ISO-2 country code.
        /// </summary>
        public virtual string ISO2
        { get; set; }
        
        /// <summary>
        /// Gets or setes the ISO-3 country code.
        /// </summary>
        public virtual string ISO3
        { get; set; }
        
        /// <summary>
        /// Gets or sets the country name with respect to its locale.
        /// </summary>
        public virtual string LocaleName
        { get; set; }
        
        /// <summary>
        /// Gets or sets the country name in English.
        /// </summary>
        public virtual string Name
        { get; set; }
        
        /// <summary>
        /// Gets or sets the available countrys for the country.
        /// </summary>
        public virtual IEnumerable<Region> AvailableRegions
        { get; set; }

        /// <summary>
        /// Gets or sets the available countrys for the country.
        /// </summary>
        IEnumerable<IRegion> ICountry.AvailableRegions
        {
            get
            {
                return (AvailableRegions == null) ? null : AvailableRegions.Select(r => r);
            }
            set
            {
                AvailableRegions = (value == null) ? null : value.Select(r => r.ToRegion());
            }
        }    

        /// <summary>
        /// Initializes a new instance of the <see cref="Country"/> class with no arguments.
        /// </summary>
        public Country()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Country"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public Country(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Country"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public Country(CountryInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }
        
                /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is ICountry)) ? false : Equals((ICountry)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
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
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.Name?.Trim(), y.Name?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && (((x.AvailableRegions == null) && (y.AvailableRegions == null)) && ((x.AvailableRegions != null) && x.AvailableRegions.SequenceEqual(y.AvailableRegions)))
                         && String.Equals(x.LocaleName?.Trim(), y.LocaleName?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.ISO2?.Trim(), y.ISO2?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.ISO3?.Trim(), y.ISO3?.Trim(), StringComparison.InvariantCultureIgnoreCase);
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="CountryInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="CountryInterface"/>.</returns>
        public override CountryInterface ToInterface()
        {
            CountryInterface countryInterface = new CountryInterface();
            countryInterface.AvailableRegions = (AvailableRegions == null) ? null : AvailableRegions.Select(ar => ar.ToInterface()).ToArray();
            countryInterface.Name = Name;
            countryInterface.LocaleName = LocaleName;
            countryInterface.ID = ID;
            countryInterface.ISO2 = ISO2;
            countryInterface.ISO3 = ISO3;
            
            return countryInterface;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            Country countryClass = new Country();

            countryClass.ID = ID;
            countryClass.Name = Name;
            countryClass.AvailableRegions = (AvailableRegions == null) ? null : AvailableRegions.Select(ar => ar.Clone<Region>());
            countryClass.LocaleName = LocaleName;
            countryClass.ISO2 = ISO2;
            countryClass.ISO3 = ISO3;
            countryClass.Server = Server.Clone<MagentoServer>();
            countryClass.RestEndpoint = RestEndpoint.Clone<MagentoRestEndpoint>();

            return countryClass;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(ID);
            hash.Add(Name);
            hash.Add(AvailableRegions);
            hash.Add(LocaleName);
            hash.Add(ISO2);
            hash.Add(ISO3);

            return hash.ToHashCode();
        }

        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(CountryInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                Name = model.Name;
                AvailableRegions = (model.AvailableRegions == null) ? null : model.AvailableRegions.Select(ar => new Region(ar));
                LocaleName = model.LocaleName;
                ISO2 = model.ISO2;
                ISO3 = model.ISO3;
            }
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="countryClass"><see cref="ICountry"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ICountry countryClass)
        {
            ArgumentNullException.ThrowIfNull(countryClass);
            return countryClass.GetHashCode();
        }
        
        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(Name) ? base.ToString() : Name;
        }    
    }
}
