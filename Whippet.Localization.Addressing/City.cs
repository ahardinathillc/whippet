using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data;
using Athi.Whippet.Extensions;
using Athi.Whippet.Geography;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Localization.Addressing
{
    /// <summary>
    /// Represents an individual city of a particular <see cref="Addressing.StateProvince"/>.
    /// </summary>
    public class City : WhippetEntity, ICity, IWhippetReadOnlyEntity, IWhippetEntity, IEqualityComparer<ICity>
    {
        /// <summary>
        /// Gets the name of the city. This property is read-only.
        /// </summary>
        public virtual string Name
        { get; protected set; }

        /// <summary>
        /// Getse the latitude and longitude of a city. This property is read-only.
        /// </summary>
        public virtual LatitudeLongitudeCoordinate Coordinates
        { get; protected set; }

        /// <summary>
        /// Gets the <see cref="Addressing.StateProvince"/> of the city. This property is read-only.
        /// </summary>
        public virtual StateProvince StateProvince
        { get; protected set; }

        /// <summary>
        /// Gets the <see cref="IStateProvince"/> of the city. This property is read-only.
        /// </summary>
        IStateProvince ICity.StateProvince
        {
            get
            {
                return StateProvince;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="City"/> class with no arguments.
        /// </summary>
        public City()
            : this(Guid.Empty)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="City"/> class with the specified <see cref="Guid"/>.
        /// </summary>
        /// <param name="id"><see cref="Guid"/> of the entity.</param>
        public City(Guid id)
            : base(id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="City"/> class with the specified name.
        /// </summary>
        /// <param name="id"><see cref="Guid"/> of the entity or <see langword="null"/> to assign a new one.</param>
        /// <param name="name">Name of the <see cref="City"/>.</param>
        /// <param name="stateProvince"><see cref="Addressing.StateProvince"/> that the city belongs to.</param>
        /// <param name="coordinates">City coordinates, if any.</param>
        /// <exception cref="ArgumentNullException" />
        public City(Guid? id, string name, StateProvince stateProvince, LatitudeLongitudeCoordinate? coordinates = null)
            : this(id.GetValueOrNew())
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            else if (stateProvince == null)
            {
                throw new ArgumentNullException(nameof(stateProvince));
            }
            else
            {
                Name = name;
                StateProvince = stateProvince;
                Coordinates = coordinates.GetValueOrDefault();
            }
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as ICity);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ICity obj)
        {
            bool equals = false;

            if (obj != null)
            {
                equals = String.Equals(obj.Name, Name, StringComparison.InvariantCultureIgnoreCase);

                if (equals && (StateProvince != null))
                {
                    equals = StateProvince.Equals(obj.StateProvince);
                }
            }

            return equals;
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="ICity"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="ICity"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ICity a, ICity b)
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
        public virtual int GetHashCode(ICity obj)
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
        /// Gets the name of the country or the default implementation of the <see cref="ICity"/> object if no name is specified.
        /// </summary>
        /// <returns>Name of the city/province.</returns>
        public override string ToString()
        {
            string stringValue = String.Empty;

            if (!String.IsNullOrWhiteSpace(Name))
            {
                stringValue = Name;

                if (StateProvince != null)
                {
                    stringValue = stringValue + " " + StateProvince.ToString();
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
