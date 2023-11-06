using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet
{
    /// <summary>
    /// Provides extension methods to the intrinsic data types of .NET. This class cannot be inherited.
    /// </summary>
    public static class IntrinsicExtensions
    {
        /// <summary>
        /// Gets the minimum value supported by SQL Server for date/time values if the value supplied is not greater.
        /// </summary>
        /// <returns><see cref="DateTime"/> minimum value for SQL Server.</returns>
        public static DateTime SqlServerMinFloor(this DateTime value)
        {
            DateTime floor = new DateTime(1753, 1, 1, 0, 0, 0);
            return value < floor ? floor : value;
        }
    }
}
