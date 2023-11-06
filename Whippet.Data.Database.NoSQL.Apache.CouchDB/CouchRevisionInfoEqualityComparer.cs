using System;
using CouchDB.Driver.Types;

namespace Athi.Whippet.Data.Database.NoSQL.Apache.CouchDB
{
    /// <summary>
    /// Provides an equality comparer for <see cref="RevisionInfo"/> objects. This class cannot be inherited.
    /// </summary>
    public sealed class CouchRevisionInfoEqualityComparer : IEqualityComparer<RevisionInfo>
    {
        private static CouchRevisionInfoEqualityComparer _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="CouchRevisionInfoEqualityComparer"/> class. This property is read-only.
        /// </summary>
        public static CouchRevisionInfoEqualityComparer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CouchRevisionInfoEqualityComparer();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CouchRevisionInfoEqualityComparer"/> class with no arguments.
        /// </summary>
        private CouchRevisionInfoEqualityComparer()
        { }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(RevisionInfo x, RevisionInfo y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && ((x != null) && (y != null)))
            {
                equals = String.Equals(x.Rev?.Trim(), y.Rev?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Status?.Trim(), y.Status?.Trim(), StringComparison.InvariantCultureIgnoreCase);
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="RevisionInfo"/> object to get the hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(RevisionInfo obj)
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
    }
}

