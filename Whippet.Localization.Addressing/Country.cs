using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using NodaTime.TimeZones;
using Athi.Whippet.Data;
using Athi.Whippet.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Localization.Addressing
{
    /// <summary>
    /// Represents a country that is registered in Whippet with a backing data entity.
    /// </summary>
    public class Country : WhippetEntity, IWhippetReadOnlyEntity, IWhippetEntity, ICountry, IEqualityComparer<ICountry>, IWhippetCloneable
    {
        /// <summary>
        /// Indicates the name of the country. This property is read-only.
        /// </summary>
        public virtual string Name
        { get; protected set; }

        /// <summary>
        /// Country abbreviation. This property is read-only.
        /// </summary>
        public virtual string Abbreviation
        { get; protected set; }

        /// <summary>
        /// Country calling code. This property is read-only.
        /// </summary>
        public virtual string CallingCode
        { get; protected set; }

        /// <summary>
        /// Provides a list of all the various time zones that the country has. This property is read-only.
        /// </summary>
        /// <remarks>Time zones are loaded via <see cref="NodaTime"/> objects.</remarks>
        public virtual IEnumerable<TimeZoneInfo> TimeZones
        { get; protected set; }

        /// <summary>
        /// Indicates the geographical region of the country. This property is read-only.
        /// </summary>
        public virtual GeographicalRegion Region
        { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Country"/> class with no arguments.
        /// </summary>
        public Country()
            : this(Guid.Empty)
        {  }

        /// <summary>
        /// Initializes a new instance of the <see cref="Country"/> class with the specified <see cref="Guid"/>.
        /// </summary>
        /// <param name="id"><see cref="Guid"/> of the entity.</param>
        public Country(Guid id)
            : base(id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Country"/> class with the specified name and abbreviation.
        /// </summary>
        /// <param name="id"><see cref="Guid"/> of the entity or <see langword="null"/> to assign a new one.</param>
        /// <param name="name">Country name.</param>
        /// <param name="abbreviation">Country abbreviation.</param>
        /// <param name="callingCode">Calling code for the country.</param>
        /// <param name="region">Geographical region of the country.</param>
        /// <exception cref="ArgumentNullException" />
        public Country(Guid? id, string name, string abbreviation, string callingCode = null, GeographicalRegion region = GeographicalRegion.UNKNOWN)
            : this(id.GetValueOrNew())
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            else if (String.IsNullOrWhiteSpace(abbreviation))
            {
                throw new ArgumentNullException(nameof(abbreviation));
            }
            else
            {
                IEnumerable<string> windowsZoneIds = null;
                List<TimeZoneInfo> zones = new List<TimeZoneInfo>();
                TzdbDateTimeZoneSource source = TzdbDateTimeZoneSource.Default;

                Name = name;
                Abbreviation = abbreviation;
                Region = region;
                CallingCode = callingCode;

                try
                {
                    windowsZoneIds = source.ZoneLocations
                        .Where(x => String.Equals(x.CountryCode, abbreviation, StringComparison.InvariantCultureIgnoreCase))
                        .Select(tz => source.WindowsMapping.MapZones
                            .FirstOrDefault(x => x.TzdbIds.Contains(source.CanonicalIdMap.First(y => y.Value == tz.ZoneId).Key)))
                        .Where(x => x != null)
                        .Select(x => x.WindowsId)
                        .Distinct();

                    foreach(string windowsZone in windowsZoneIds)
                    {
                        try
                        {
                            zones.Add(TimeZoneInfo.FindSystemTimeZoneById(windowsZone));
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
                catch
                {
                    zones.Clear();
                }

                TimeZones = zones.AsReadOnly();

            } 
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public virtual object Clone()
        {
            return new Country(ID, Name, Abbreviation, CallingCode, Region);
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
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Country);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ICountry obj)
        {
            bool equals = false;

            if(obj != null)
            {
                equals = String.Equals(obj.Name, Name, StringComparison.InvariantCultureIgnoreCase);
            }

            return equals;
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="ICountry"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="ICountry"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ICountry a, ICountry b)
        {
            return ((a != null) && (b != null) && (a.Equals(b))) || (a == null && b == null);
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
        public virtual int GetHashCode(ICountry obj)
        {
            if(obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else
            {
                return obj.GetHashCode();
            }
        }

        /// <summary>
        /// Gets the name of the country or the default implementation of the <see cref="Country"/> object if no name is specified.
        /// </summary>
        /// <returns>Name of the country.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(Name) ? base.ToString() : Name;
        }
    }
}
