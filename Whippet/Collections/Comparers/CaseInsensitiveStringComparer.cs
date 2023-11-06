using System;
using System.Collections;
using System.Collections.Generic;

namespace Athi.Whippet.Collections.Comparers
{
    /// <summary>
    /// Provides a case-insensitive comparison for two <see cref="String"/> instances with an invariant culture. This class cannot be inherited.
    /// </summary>
    public sealed class CaseInsensitiveStringComparer : IComparer<string>
    { 
        private static CaseInsensitiveStringComparer _instance;

        /// <summary>
        /// Gets a singleton instance of the <see cref="CaseInsensitiveStringComparer"/> class. This property is read-only.
        /// </summary>
        public static CaseInsensitiveStringComparer Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new CaseInsensitiveStringComparer();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CaseInsensitiveStringComparer"/> class with no arguments.
        /// </summary>
        private CaseInsensitiveStringComparer()
        { }

        /// <summary>
        /// Compares two strings and returns an indication of their relative sort order.
        /// </summary>
        /// <param name="x">A string to compare to <paramref name="y"/>.</param>
        /// <param name="y">A string to compare to <paramref name="x"/>.</param>
        /// <returns>A signed integer that indicates the relative values of <paramref name="x"/> and <paramref name="y"/>. Values less than zero indicates that <paramref name="x"/> precedes <paramref name="y"/>; zero indicates that the values are equal; and values greater than zero indicate that <paramref name="x"/> follows <paramref name="y"/>.</returns>
        public int Compare(string x, string y)
        {
            int compareResult = 0;

            if (!(String.IsNullOrWhiteSpace(x) && String.IsNullOrWhiteSpace(y)))
            {
                compareResult = StringComparer.InvariantCultureIgnoreCase.Compare(x, y);
            }

            return compareResult;
        }
    }
}

