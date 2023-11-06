using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurityDriven.Inferno;

namespace Athi.Whippet.Extensions.Text
{
    /// <summary>
    /// Provides extension methods to <see cref="Encoding"/> objects. This class cannot be inherited.
    /// </summary>
    public static class EncodingExtensions
    {
        /// <summary>
        /// Decodes all the bytes in the specified byte array into a string.
        /// </summary>
        /// <param name="bytes">Byte array to decode.</param>
        /// <returns>String representation of the byte array.</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="DecoderFallbackException" />
        public static string SafeGetString_UTF8(this Encoding encoding, byte[] bytes)
        {
            if (encoding == null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }
            else
            {
                return Utils.SafeUTF8.GetString(bytes);
            }
        }
    }
}
