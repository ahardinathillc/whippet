using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data;
using Athi.Whippet.Extensions;
using Athi.Whippet.Localization.Addressing.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Localization.Addressing
{
    /// <summary>
    /// Represents an invariant address, that is, an address that is unformatted with respect to its respective country.
    /// </summary>
    public class InvariantAddress : WhippetEntity, IWhippetEntity, IInvariantAddress, IEqualityComparer<IInvariantAddress>, IWhippetCloneable
    {
        private City _city;
        private PostalCode _postalCode;

        /// <summary>
        /// Represents the first line of the address. This is typically the recipient or receiving entity.
        /// </summary>
        public virtual string LineOne
        { get; set; }

        /// <summary>
        /// Represents the second line of the address. Normally this specifies a department, "Attention" or "Care Of" directive.
        /// </summary>
        public virtual string LineTwo
        { get; set; }

        /// <summary>
        /// Represents the third line of the address.
        /// </summary>
        public virtual string LineThree
        { get; set; }

        /// <summary>
        /// Represents the fourth line of the address.
        /// </summary>
        public virtual string LineFour
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Addressing.City"/> that the address resides in. The state/province is determined by this property.
        /// </summary>
        public virtual City City
        {
            get
            {
                if (_city == null)
                {
                    _city = new City();
                }

                return _city;
            }
            set
            {
                _city = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="PostalCode"/> that the mail service used to route mail to the address. This property is independent of <see cref="City"/>.
        /// </summary>
        public virtual PostalCode PostalCode
        {
            get
            {
                if (_postalCode == null)
                {
                    _postalCode = new PostalCode();
                }

                return _postalCode;
            }
            set
            {
                _postalCode = value;
            }
        }

        /// <summary>
        /// Gets the <see cref="Addressing.StateProvince"/> that the address resides in based on the <see cref="City"/> property. This property is read-only.
        /// </summary>
        public virtual StateProvince StateProvince
        {
            get
            {
                return City.StateProvince;
            }
        }

        /// <summary>
        /// Gets the <see cref="Addressing.Country"/> that the address resides in based on the <see cref="StateProvince"/> property. This property is read-only.
        /// </summary>
        public virtual Country Country
        {
            get
            {
                return StateProvince.Country;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="ICity"/> that the address resides in. The state/province is determined by this property.
        /// </summary>
        ICity IInvariantAddress.City
        {
            get
            {
                return City;
            }
            set
            {
                City = value?.ToCity();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IPostalCode"/> that the mail service used to route mail to the address. This property is independent of <see cref="City"/>.
        /// </summary>
        IPostalCode IInvariantAddress.PostalCode
        {
            get
            {
                return PostalCode;
            }
            set
            {
                PostalCode = value?.ToPostalCode();
            }
        }

        /// <summary>
        /// Gets the <see cref="IStateProvince"/> that the address resides in based on the <see cref="City"/> property. This property is read-only.
        /// </summary>
        IStateProvince IInvariantAddress.StateProvince
        {
            get
            {
                return ((IInvariantAddress)(this)).City?.StateProvince;
            }
        }

        /// <summary>
        /// Gets the <see cref="ICountry"/> that the address resides in based on the <see cref="StateProvince"/> property. This property is read-only.
        /// </summary>
        ICountry IInvariantAddress.Country
        {
            get
            {
                return ((IInvariantAddress)(this)).City?.StateProvince?.Country;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvariantAddress"/> class with no arguments.
        /// </summary>
        public InvariantAddress()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvariantAddress"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the entity.</param>
        public InvariantAddress(Guid id)
            : base(id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvariantAddress"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">ID of the entity.</param>
        /// <param name="lineOne">First line of the address.</param>
        /// <param name="lineTwo">Second line of the address.</param>
        /// <param name="lineThree">Third line of the address.</param>
        /// <param name="lineFour">Fourth line of the address.</param>
        /// <param name="city">The <see cref="Addressing.City"/> the address resides in.</param>
        /// <param name="postalCode">The <see cref="Addressing.PostalCode"/> the mail service uses for routing independent of <paramref name="city"/>.</param>
        public InvariantAddress(Guid id, string lineOne, string lineTwo, string lineThree, string lineFour, City city, PostalCode postalCode)
            : this(id)
        {
            LineOne = lineOne;
            LineTwo = lineTwo;
            LineThree = lineThree;
            LineFour = lineFour;
            City = city;
            PostalCode = postalCode;
        }

        /// <summary>
        /// Creates a deep copy of the current object.
        /// </summary>
        /// <typeparam name="TObject">Type of object to cast the return value to.</typeparam>
        /// <param name="userId">User ID of the user who created the cloned object.</param>
        /// <returns>Object of type <typeparamref name="TObject"/>.</returns>
        public virtual TObject Clone<TObject>(Guid? userId = null)
        {
            return (TObject)(Clone());
        }

        /// <summary>
        /// Creates a deep copy of the current object.
        /// </summary>
        /// <returns>Deep copy of the current object.</returns>
        public virtual object Clone()
        {
            City c = null;
            StateProvince sp = null;
            Country cnt = null;
            PostalCode pc = null;

            if (City != null)
            {
                if (City.StateProvince != null)
                {
                    if (City.StateProvince.Country != null)
                    {
                        cnt = new Country(City.StateProvince.Country.ID, City.StateProvince.Country.Name, City.StateProvince.Country.Abbreviation, City.StateProvince.Country.CallingCode, City.StateProvince.Country.Region);
                    }

                    sp = new StateProvince(City.StateProvince.ID, City.StateProvince.Name, City.StateProvince.Abbreviation, cnt);
                }

                c = new City(City.ID, City.Name, sp, City.Coordinates);
            }

            if (PostalCode != null)
            {
                pc = new PostalCode(PostalCode.ID, PostalCode.Value, c, PostalCode.Coordinates);
            }

            return new InvariantAddress(ID, LineOne, LineTwo, LineThree, LineFour, c, pc);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IInvariantAddress);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IInvariantAddress obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IInvariantAddress x, IInvariantAddress y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals =
                    ((x.City == null && y.City == null) || (x.City != null && y.City != null && x.City.Equals(y.City)))
                        && String.Equals(x.LineOne, y.LineOne, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.LineTwo, y.LineTwo, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.LineThree, y.LineThree, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.LineFour, y.LineFour, StringComparison.InvariantCultureIgnoreCase)
                        && ((x.PostalCode == null && y.PostalCode == null) || (x.PostalCode != null && y.PostalCode != null && x.PostalCode.Equals(y.PostalCode)));
            }

            return equals;
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
        /// Serves as the default hash function.
        /// </summary>
        /// <param name="obj"><see cref="IInvariantAddress"/> object.</param>
        /// <returns>A hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IInvariantAddress obj)
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
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            if (!String.IsNullOrWhiteSpace(LineOne))
            {
                builder.Append(LineOne);
                builder.Append(" ");
            }

            if (!String.IsNullOrWhiteSpace(LineTwo))
            {
                builder.Append(LineTwo);
                builder.Append(" ");
            }

            if (!String.IsNullOrWhiteSpace(LineThree))
            {
                builder.Append(LineThree);
                builder.Append(" ");
            }

            if (!String.IsNullOrWhiteSpace(LineFour))
            {
                builder.Append(LineFour);
                builder.Append(" ");
            }

            if ((City != null) && !String.IsNullOrWhiteSpace(City.ToString()))
            {
                builder.Append(City.ToString());
                builder.Append(" ");
            }

            if ((PostalCode != null) && !String.IsNullOrWhiteSpace(PostalCode.ToString()))
            {
                builder.Append(PostalCode.ToString());
            }

            return builder.ToString();
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
