using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Localization.Addressing
{
    /// <summary>
    /// Equality comparer for <see cref="Country"/> objects. This class cannot be inherited.
    /// </summary>
    public sealed class CountryComparer : IEqualityComparer<Country>
    {
        private static CountryComparer _comp;

        /// <summary>
        /// Gets the <see cref="CountryComparer"/> instance. This property is read-only.
        /// </summary>
        public static CountryComparer Instance
        {
            get
            {
                if (_comp == null)
                {
                    _comp = new CountryComparer();
                }

                return _comp;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryComparer"/> class with no arguments.
        /// </summary>
        private CountryComparer()
        { }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="Country"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="Country"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(Country a, Country b)
        {
            return ((a != null) && (b != null) && (a.Equals(b))) || (a == null && b == null);
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException" />
        public int GetHashCode(Country obj)
        {
            return new Country().GetHashCode(obj);
        }
    }
}
