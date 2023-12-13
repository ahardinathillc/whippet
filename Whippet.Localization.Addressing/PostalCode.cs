using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data;
using Athi.Whippet.Extensions;
using Athi.Whippet.Geography;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Localization.Addressing
{
    /// <summary>
    /// Represents an individual postal code of a <see cref="Addressing.City"/>.
    /// </summary>
    public class PostalCode : WhippetEntity, IPostalCode, IWhippetReadOnlyEntity, IWhippetEntity, IEqualityComparer<IPostalCode>
    {
        /// <summary>
        /// Gets the postal code value. This property is read-only.
        /// </summary>
        public virtual string Value
        { get; protected set; }

        /// <summary>
        /// Gets the <see cref="LatitudeLongitudeCoordinate"/> value, if any. This property is read-only.
        /// </summary>
        public virtual LatitudeLongitudeCoordinate Coordinates
        { get; protected set; }

        /// <summary>
        /// Gets the <see cref="Addressing.City"/> that the postal code is associated with. This property is read-only.
        /// </summary>
        public virtual City City
        { get; protected set; }

        /// <summary>
        /// Gets the <see cref="ICity"/> that the postal code is associated with. This property is read-only.
        /// </summary>
        ICity IPostalCode.City
        {
            get
            {
                return City;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostalCode"/> class with no arguments.
        /// </summary>
        public PostalCode()
            : this(Guid.Empty)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostalCode"/> class with the specified <see cref="Guid"/>.
        /// </summary>
        /// <param name="id"><see cref="Guid"/> of the entity.</param>
        public PostalCode(Guid id)
            : base(id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostalCode"/> class with the specified values.
        /// </summary>
        /// <param name="id"><see cref="Guid"/> of the entity or <see langword="null"/> to assign a new one.</param>
        /// <param name="code">Postal code value.</param>
        /// <param name="city"><see cref="Addressing.City"/> the postal code is associated with.</param>
        /// <param name="coordinates"><see cref="LatitudeLongitudeCoordinate"/> of the postal code, if any.</param>
        /// <exception cref="ArgumentNullException" />
        public PostalCode(Guid? id, string code, City city, LatitudeLongitudeCoordinate? coordinates = null)
            : this(id.GetValueOrNew())
        {
            if (String.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException(nameof(code));
            }
            else if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }
            else
            {
                Value = code;
                City = city;
                Coordinates = coordinates.HasValue ? coordinates.Value : LatitudeLongitudeCoordinate.Null;
            }
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IPostalCode);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IPostalCode obj)
        {
            bool equals = false;

            if (obj != null)
            {
                equals = String.Equals(obj.Value, Value, StringComparison.InvariantCultureIgnoreCase);

                if (equals && (City != null))
                {
                    equals = City.Equals(obj.City);
                }
            }

            return equals;
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="IPostalCode"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IPostalCode"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IPostalCode a, IPostalCode b)
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
        public virtual int GetHashCode(IPostalCode obj)
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
        /// Gets the name of the country or the default implementation of the <see cref="PostalCode"/> object if no name is specified.
        /// </summary>
        /// <returns>Name of the state/province.</returns>
        public override string ToString()
        {
            string stringValue = String.Empty;

            if (!String.IsNullOrWhiteSpace(Value))
            {
                stringValue = Value;

                if (City != null)
                {
                    stringValue = stringValue + " [" + City.ToString() + "]";
                }
            }
            else
            {
                stringValue = base.ToString();
            }

            return stringValue;
        }
    }
}
