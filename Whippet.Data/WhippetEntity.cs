using System;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using Athi.Whippet.Json;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Base class for all domain objets in Whippet. This class must be inherited.
    /// </summary>
    /// <remarks>This is the equivalent to an Aggregate base class. See <a href="http://www.andreavallotti.tech/en/2018/01/event-sourcing-and-cqrs-in-c/">Event Sourcing and CQRS in C#</a> for more information.</remarks>
    [JsonObject]
    public abstract class WhippetEntity : IWhippetEntity, IJsonSerializableObject
    {
        /// <summary>
        /// Unique ID of the entity.
        /// </summary>
        [JsonRequired]
        public virtual Guid ID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetEntity"/> class with no arguments.
        /// </summary>
        protected WhippetEntity()
        {
            ID = Guid.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetEntity"/> class with the specified <see cref="Guid"/>.
        /// </summary>
        /// <param name="id"><see cref="Guid"/> value that represents the unique identifier of the entity.</param>
        protected WhippetEntity(Guid id)
            : this()
        {
            ID = id;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        /// <summary>
        /// Converts the specified <see cref="Int32"/> ID value to its equivalent <see cref="Guid"/> value.
        /// </summary>
        /// <param name="id">ID to convert.</param>
        /// <returns><see cref="Guid"/> representation of the <see cref="Int32"/> value.</returns>
        protected static Guid IntegerIdToGuid(int id)
        {
            const int _HEX_LENGTH = 32;
            const int _HEX_PIECE_LENGTH = 12;
            
            StringBuilder hexBuilder = null;
            
            string hexId = String.Empty;
            string[] pieces = null;
            
            Guid idGuid = Guid.Empty;
            
            // split the GUID into its four parts using the default format
            pieces = idGuid.ToString().Split(new char[] { '-' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            
            // now convert the integer ID to its hexadecimal value
            hexId = id.ToString("X");
            
            // a GUID is 32 hexadecimal digits, so take the length of hexId and replace the last N digits
            hexBuilder = new StringBuilder();
            
            // append the first pieces

            for (int i = 0; i < pieces.Length - 2; i++)
            {
                hexBuilder.Append(pieces[i]);
            }
            
            // now append the last piece

            for (int j = 0; j < (_HEX_PIECE_LENGTH - hexId.Length) - 1; j++)
            {
                hexBuilder.Append("0");
            }

            hexBuilder.Append(hexId);
            
            // error check to make sure we're the right length

            if (hexBuilder.Length != _HEX_LENGTH)
            {
                // too long?

                while (hexBuilder.Length > _HEX_LENGTH)
                {
                    hexBuilder = hexBuilder.Remove(0, 1);
                }
                
                // too short?

                while (hexBuilder.Length < _HEX_LENGTH)
                {
                    hexBuilder = hexBuilder.Insert(0, "0");
                }
            }
            
            // create the GUID
            idGuid = Guid.Parse(hexBuilder.ToString());

            return idGuid;
        }

        /// <summary>
        /// Converts the specified <see cref="Guid"/> ID value to its equivalent <see cref="Int32"/> value.
        /// </summary>
        /// <param name="id">ID to convert.</param>
        /// <returns><see cref="Int32"/> representation of the <see cref="Guid"/> value.</returns>
        protected static int GuidIdToInteger(Guid id)
        {
            const string _INT32_MAX_HEX = "7fffffff";

            string hexValue = null;
            string guidValue = null;
                
            // try to convert it to an integer
            // we only want the last portion

            guidValue = id.ToString();
            hexValue = guidValue.Substring(guidValue.Length - _INT32_MAX_HEX.Length - 1);

            return Int32.Parse(hexValue, NumberStyles.HexNumber);
        }
    }
}
