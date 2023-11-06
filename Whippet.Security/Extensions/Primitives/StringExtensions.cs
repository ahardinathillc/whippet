using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Security.Extensions.Primitives
{
    /// <summary>
    /// Provides security extensions to <see cref="String"/> objects. This class cannot be inherited.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="string"/> value to a <see cref="WhippetSecureArray{T}"/>.
        /// </summary>
        /// <param name="value"><see cref="string"/> value to convert.</param>
        /// <returns><see cref="WhippetSecureArray{T}"/> of <see cref="byte"/> values, representing the UTF-8 value of each character.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static WhippetSecureArray<byte> ToSecureByteArray(this string value)
        {
            if(value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            else
            {
                byte[] unsecureValue = Encoding.UTF8.GetBytes(value);
                WhippetSecureArray<byte> secureString = WhippetSecureArray<byte>.CreateBestAttempt(unsecureValue.Length, null);

                secureString.CopyFromArray(unsecureValue);

                Array.Clear(unsecureValue);
                unsecureValue = null;

                return secureString;
            }
        }
    }
}
