using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Localization.Addressing.Extensions
{
    /// <summary>
    /// Provides extensions for <see cref="PostalCode"/> and <see cref="IPostalCode"/> objects. This class cannot be inherited.
    /// </summary>
    public static class PostalCodeExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IPostalCode"/> instance to a <see cref="PostalCode"/> object.
        /// </summary>
        /// <param name="code"><see cref="IPostalCode"/> object to convert.</param>
        /// <returns><see cref="PostalCode"/> object.</returns>
        public static PostalCode ToPostalCode(this IPostalCode code)
        {
            PostalCode pc = null;

            if (code != null)
            {
                if (code is PostalCode)
                {
                    pc = ((PostalCode)(code));
                }
                else
                {
                    pc = new PostalCode(code.ID, code.Value, code.City?.ToCity(), code.Coordinates);
                }
            }

            return pc;
        }

        /// <summary>
        /// For United States <see cref="IPostalCode"/> objects, returns the first five digits of the ZIP code without the plus four (+4) extension for routing.
        /// </summary>
        /// <param name="code"><see cref="IPostalCode"/> object.</param>
        /// <param name="value">Value to parse. If <see langword="null"/> or <see cref="String.Empty"/>, the value in <paramref name="code"/> will be used.</param>
        /// <returns>ZIP code value.</returns>
        public static string GetZipCodeOnly(this IPostalCode code, string value = null)
        {
            string zip = String.Empty;

            if ((code != null && code.Value.Length >= 5) || (!String.IsNullOrWhiteSpace(value) && value.Length >= 5))
            {
                zip = !String.IsNullOrWhiteSpace(value) ? value.Substring(0, 5) : code.Value.Substring(0, 5);
            }

            return zip;
        }
    }
}
