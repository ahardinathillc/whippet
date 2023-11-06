using System;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Provides a comparison method for comparing two <see cref="IMultichannelOrderManagerStateProvince"/> objects. This class cannot be inherited.
    /// </summary>
    public sealed class IMultichannelOrderManagerStateProvinceComparer : IComparer<IMultichannelOrderManagerStateProvince>
    {
        private static IMultichannelOrderManagerStateProvinceComparer _instance;

        /// <summary>
        /// Gets a singleton instance of the <see cref="IMultichannelOrderManagerStateProvinceComparer"/> class. This property is read-only.
        /// </summary>
        public static IMultichannelOrderManagerStateProvinceComparer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new IMultichannelOrderManagerStateProvinceComparer();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IMultichannelOrderManagerStateProvinceComparer"/> class with no arguments.
        /// </summary>
        private IMultichannelOrderManagerStateProvinceComparer()
        { }

        /// <summary>
        /// Compares two objects and returns an indication of their relative sort order.
        /// </summary>
        /// <param name="x">An object to compare to <paramref name="y"/>.</param>
        /// <param name="y">An object to compare to <paramref name="x"/>.</param>
        /// <returns>A signed integer that indicates the relative values of <paramref name="x"/> and <paramref name="y"/>. Values less than zero indicates that <paramref name="x"/> precedes <paramref name="y"/>; zero indicates that the values are equal; and values greater than zero indicate that <paramref name="x"/> follows <paramref name="y"/>.</returns>
        public int Compare(IMultichannelOrderManagerStateProvince x, IMultichannelOrderManagerStateProvince y)
        {
            int compareResult = 0;

            if (x != null && y != null)
            {
                compareResult = x.CompareTo(y);
            }
            else if (x != null && y == null)
            {
                compareResult = 1;
            }
            else if (x == null && y != null)
            {
                compareResult = -1;
            }

            return compareResult;
        }
    }
}

