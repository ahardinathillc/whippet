using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data;
using Athi.Whippet.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Localization.Addressing
{
    /// <summary>
    /// Represents an individual state of a particular <see cref="Addressing.Country"/>.
    /// </summary>
    public class StateProvince : WhippetEntity, IStateProvince, IWhippetReadOnlyEntity, IWhippetEntity, IEqualityComparer<IStateProvince>
    {
        /// <summary>
        /// Gets the name of the state. This property is read-only.
        /// </summary>
        public virtual string Name
        { get; protected set; }

        /// <summary>
        /// Gets the abbreviation of the state. This property is read-only.
        /// </summary>
        public virtual string Abbreviation
        { get; protected set; }

        /// <summary>
        /// Gets the <see cref="Athi.Whippet.Localization.Addressing.Country"/> that the <see cref="StateProvince"/> belongs to. This property is read-only.
        /// </summary>
        public virtual Country Country
        { get; protected set; }

        /// <summary>
        /// Gets the <see cref="ICountry"/> that the <see cref="IStateProvince"/> belongs to. This property is read-only.
        /// </summary>
        ICountry IStateProvince.Country
        {
            get
            {
                return Country;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateProvince"/> class with no arguments.
        /// </summary>
        public StateProvince()
            : this(Guid.Empty)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateProvince"/> class with the specified <see cref="Guid"/>.
        /// </summary>
        /// <param name="id"><see cref="Guid"/> of the entity.</param>
        public StateProvince(Guid id)
            : base(id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateProvince"/> class with the specified name and abbreviation.
        /// </summary>
        /// <param name="id"><see cref="Guid"/> of the entity or <see langword="null"/> to assign a new one.</param>
        /// <param name="name">State/province name.</param>
        /// <param name="abbreviation">State/province abbreviation.</param>
        /// <param name="country"><see cref="Athi.Whippet.Localization.Addressing.Country"/> that the <see cref="StateProvince"/> belongs to.</param>
        /// <exception cref="ArgumentNullException" />
        public StateProvince(Guid? id, string name, string abbreviation, Country country)
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
            else if(country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
            else
            {
                Name = name;
                Abbreviation = abbreviation;
                Country = country;
            }
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IStateProvince);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IStateProvince obj)
        {
            bool equals = false;

            if (obj != null)
            {
                equals = String.Equals(obj.Name, Name, StringComparison.InvariantCultureIgnoreCase);

                if(equals && (Country != null))
                {
                    equals = Country.Equals(obj.Country);
                }
            }

            return equals;
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="IStateProvince"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IStateProvince"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IStateProvince a, IStateProvince b)
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
        public virtual int GetHashCode(IStateProvince obj)
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
        /// Gets the name of the country or the default implementation of the <see cref="StateProvince"/> object if no name is specified.
        /// </summary>
        /// <returns>Name of the state/province.</returns>
        public override string ToString()
        {
            string stringValue = String.Empty;

            if(!String.IsNullOrWhiteSpace(Name))
            {
                stringValue = Name;

                if(Country != null)
                {
                    stringValue = stringValue + " (" + Country.ToString() + ")";
                }
            }
            else
            {
                stringValue = base.ToString();
            }

            return stringValue;
        }

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be overridden.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public override string ToJson<T>()
        {
            return this.SerializeJson(this);
        }
    }
}
