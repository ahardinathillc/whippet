using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using SecurityDriven.Inferno;

namespace Athi.Whippet.Security.Cryptography
{
    /// <summary>
    /// Provides cryptography support functions for Whippet. This class cannot be inherited.
    /// </summary>
    /// <remarks>See <a href="https://securitydriven.net/inferno/">Inferno</a> website for more information on API.</remarks>
    public static class WhippetCryptography
    {
        private const byte DEFAULT_KEY_LEN = byte.MaxValue;

        /// <summary>
        /// Encrypts the specified plain text with the optional supplied salt value (additional data or a hash).
        /// </summary>
        /// <param name="masterKey">Master key that is used to derive other keys.</param>
        /// <param name="plainText">Text to encrypt.</param>
        /// <param name="salt">Salt value to apply (if any).</param>
        /// <returns>Encrypted values stored as a <see cref="byte"/> array.</returns>
        public static byte[] Encrypt(byte[] masterKey, ArraySegment<byte> plainText, ArraySegment<byte>? salt = null)
        {
            return SuiteB.Encrypt(masterKey, plainText, salt);
        }

        /// <summary>
        /// Encrypts the specified plain text with the optional supplied salt value (additional data or a hash).
        /// </summary>
        /// <param name="masterKey">Master key that is used to derive other keys.</param>
        /// <param name="plainText">Text to encrypt.</param>
        /// <param name="salt">Salt value to apply (if any).</param>
        /// <returns>Encrypted values stored as a <see cref="byte"/> array.</returns>
        public static byte[] Encrypt(byte[] masterKey, string plainText, ArraySegment<byte>? salt = null)
        {
            return Encrypt(masterKey, Encoding.UTF8.GetBytes(plainText), salt);
        }

        /// <summary>
        /// Decrypts the specified plain text with the optional supplied salt value (additional data or a hash).
        /// </summary>
        /// <param name="masterKey">Master key that was used to derive other keys at time of encryption.</param>
        /// <param name="cipherText">Text to decrypt.</param>
        /// <param name="salt">Salt value to apply (if any).</param>
        /// <returns>Decrypted values stored as a <see cref="byte"/> array.</returns>
        public static byte[] Decrypt(byte[] masterKey, ArraySegment<byte> cipherText, ArraySegment<byte>? salt = null)
        {
            return SuiteB.Decrypt(masterKey, cipherText, salt);
        }

        /// <summary>
        /// Authenticates the cipher text using the supplied master key for validity.
        /// </summary>
        /// <param name="masterKey">Master key that was used to derive other keys at time of encryption.</param>
        /// <param name="cipherText">Text to decrypt.</param>
        /// <param name="salt">Salt value to apply (if any).</param>
        /// <returns><see langword="true"/> if the master key and cipher are valid; otherwise, <see langword="false"/>.</returns>
        public static bool Authenticate(byte[] masterKey, ArraySegment<byte> cipherText, ArraySegment<byte>? salt = null)
        {
            return SuiteB.Authenticate(masterKey, cipherText, salt);
        }

        /// <summary>
        /// Generates a new master key byte array for encryption and decryption functions.
        /// </summary>
        /// <param name="count">Length of the array to generate.</param>
        /// <returns><see cref="byte"/> array of cryptographically strong random values.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static byte[] GenerateMasterKey(int count = DEFAULT_KEY_LEN)
        {
            if(count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            else
            {
                return new CryptoRandom().NextBytes(count);
            }
        }

        /// <summary>
        /// Computes the hash for the specified string.
        /// </summary>
        /// <param name="plainText"><see cref="byte"/> array containing the bytes of the plain-text string.</param>
        /// <param name="provider"><see cref="HashAlgorithm"/> provider to use. If <see langword="null"/>, <see cref="MD5"/> will be used.</param>
        /// <returns><see cref="byte"/> array containing the hash.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static byte[] ComputeHash(byte[] plainText, HashAlgorithm provider = null)
        {
            if (plainText == null)
            {
                throw new ArgumentNullException(nameof(plainText));
            }
            else
            {
                if (provider == null)
                {
                    provider = MD5.Create();
                }

                byte[] returnValue = provider.ComputeHash(plainText);

                provider.Dispose();
                provider = null;

                return returnValue;
            }
        }

        /// <summary>
        /// Computes the hash for the specified string.
        /// </summary>
        /// <param name="plainText"><see cref="byte"/> array containing the bytes of the plain-text string.</param>
        /// <param name="encoding">Encoding of <paramref name="plainText"/>. If <see langword="null"/>, <see cref="Encoding.UTF8"/> is used.</param>
        /// <param name="provider"><see cref="HashAlgorithm"/> provider to use. If <see langword="null"/>, <see cref="MD5"/> will be used.</param>
        /// <returns><see cref="byte"/> array containing the hash.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static byte[] ComputeHash(string plainText, Encoding encoding = null, HashAlgorithm provider = null)
        {
            if (String.IsNullOrWhiteSpace(plainText))
            {
                throw new ArgumentNullException(nameof(plainText));
            }
            else
            {
                if(encoding == null)
                {
                    encoding = Encoding.UTF8;
                }

                if (provider == null)
                {
                    provider = MD5.Create();
                }

                return ComputeHash(encoding.GetBytes(plainText), provider);
            }

        }
    }
}
