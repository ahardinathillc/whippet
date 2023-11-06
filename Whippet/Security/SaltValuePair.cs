using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Security
{
    /// <summary>
    /// Represents an encrypted value with its associated salt value.
    /// </summary>
    public struct SaltValuePair
    {
        /// <summary>
        /// Gets the salt value. This property is read-only.
        /// </summary>
        public byte[] Salt
        { get; private set; }

        /// <summary>
        /// Gets the encrypted value that <see cref="Salt"/> was applied to. This property is read-only.
        /// </summary>
        public byte[] Value
        { get; private set; }

        /// <summary>
        /// Gets the master key used for encryption and decryption. This property is read-only.
        /// </summary>
        public byte[] MasterKey
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SaltValuePair"/> structure with no arguments.
        /// </summary>
        static SaltValuePair()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SaltValuePair"/> structure.
        /// </summary>
        /// <param name="value">Encrypted value.</param>
        /// <param name="salt">Salt that was applied to <paramref name="value"/>.</param>
        /// <param name="masterKey">Master key used to encrypt or decrypt the value.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SaltValuePair(byte[] value, byte[] salt, byte[] masterKey)
            : this()
        {
            if(value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            else
            {
                Value = value;
                Salt = salt;
                MasterKey = masterKey;
            }
        }

        /// <summary>
        /// Gets the hexadecimal string value of the current <see cref="SaltValuePair"/> based on <see cref="Value"/>.
        /// </summary>
        /// <returns><see cref="Value"/> as a hexadecimal string.</returns>
        public override string ToString()
        {
            return (Value != null && Value.Any()) ? Convert.ToHexString(Value) : base.ToString();
        }
    }
}
