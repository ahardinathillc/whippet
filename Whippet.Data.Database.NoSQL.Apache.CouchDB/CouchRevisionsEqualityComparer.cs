using System;
using CouchDB.Driver.Types;

namespace Athi.Whippet.Data.Database.NoSQL.Apache.CouchDB
{
    /// <summary>
    /// Provides an equality comparer for <see cref="Revisions"/> objects. This class cannot be inherited.
    /// </summary>
    public sealed class CouchRevisionsEqualityComparer : IEqualityComparer<Revisions>
    {
        private static CouchRevisionsEqualityComparer _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="CouchRevisionsEqualityComparer"/> class. This property is read-only.
        /// </summary>
        public static CouchRevisionsEqualityComparer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CouchRevisionsEqualityComparer();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CouchRevisionsEqualityComparer"/> class with no arguments.
        /// </summary>
        private CouchRevisionsEqualityComparer()
        { }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(Revisions x, Revisions y)
        {
            bool equals = (x == null) && (y == null);

            int x_collectionCount = 0;
            int y_collectionCount = 0;

            if (!equals && ((x != null) && (y != null)))
            {
                equals = x.Start == y.Start;

                if (equals)
                {
                    if (!x.IDs.TryGetNonEnumeratedCount(out x_collectionCount))
                    {
                        x_collectionCount = x.IDs.Count();
                    }

                    if (!y.IDs.TryGetNonEnumeratedCount(out y_collectionCount))
                    {
                        y_collectionCount = y.IDs.Count();
                    }

                    if (x_collectionCount == y_collectionCount)
                    {
                        foreach (string id in x.IDs)
                        {
                            if (!y.IDs.Contains(id, StringComparer.InvariantCultureIgnoreCase))
                            {
                                equals = false;
                                break;
                            }
                            else
                            {
                                equals = true;
                            }
                        }
                    }
                }
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="Revisions"/> object to get the hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(Revisions obj)
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

