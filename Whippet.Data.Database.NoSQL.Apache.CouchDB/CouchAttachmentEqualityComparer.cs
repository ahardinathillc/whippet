using System;
using CouchDB.Driver.Types;

namespace Athi.Whippet.Data.Database.NoSQL.Apache.CouchDB
{
    /// <summary>
    /// Provides an equality comparer for <see cref="CouchAttachment"/> objects. This class cannot be inherited.
    /// </summary>
    public sealed class CouchAttachmentEqualityComparer : IEqualityComparer<CouchAttachment>
    {
        private static CouchAttachmentEqualityComparer _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="CouchAttachmentEqualityComparer"/> class. This property is read-only.
        /// </summary>
        public static CouchAttachmentEqualityComparer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CouchAttachmentEqualityComparer();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CouchAttachmentEqualityComparer"/> class with no arguments.
        /// </summary>
        private CouchAttachmentEqualityComparer()
        { }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(CouchAttachment x, CouchAttachment y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && ((x != null) && (y != null)))
            {
                equals =
                    String.Equals(x.ContentType?.Trim(), y.ContentType?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.Digest?.Trim(), y.Digest?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                        && (x.Length.GetValueOrDefault() == y.Length.GetValueOrDefault())
                        && String.Equals(x.Name?.Trim(), y.Name?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                        && (x.RevPos.GetValueOrDefault() == y.RevPos.GetValueOrDefault())
                        && (x.Stub == y.Stub)
                        && ((x.Uri == null && y.Uri == null) || ((x.Uri != null) && x.Uri.Equals(y.Uri)));
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="CouchAttachment"/> object to get the hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(CouchAttachment obj)
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

