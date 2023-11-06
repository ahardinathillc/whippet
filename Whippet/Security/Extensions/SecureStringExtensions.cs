using System;
using System.Security;
using System.Security.Cryptography;

namespace Athi.Whippet.Security.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="SecureString"/> objects. This class cannot be inherited.
    /// </summary>
    public static class SecureStringExtensions
    {
        /// <summary>
        /// Imports the specified <see cref="string"/> into the <see cref="SecureString"/>.
        /// </summary>
        /// <param name="sString"><see cref="SecureString"/> object.</param>
        /// <param name="value">String to import into <paramref name="sString"/>.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ObjectDisposedException" />
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="CryptographicException" />
        public static void ImportString(this SecureString sString, string value)
        {
            if (sString == null)
            {
                throw new ArgumentNullException(nameof(sString));
            }
            else if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            else
            {
                for (int i = 0; i < value.Length; i++)
                {
                    sString.AppendChar(value[i]);
                }
            }
        }
    }
}

