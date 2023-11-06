using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Athi.Whippet.Json.Newtonsoft.Converters
{
    /// <summary>
    /// Converts <see cref="IEnumerable{T}"/> collections of primitive types from JSON.
    /// </summary>
    public class PrimitiveEnumerableConverter : JsonConverter
    {
        /// <summary>
        /// Provides a read-only array of <see cref="Type"/> objects that are supported by the converter.
        /// </summary>
        protected static readonly Type[] _CompatibleTypes = new Type[]
        {
            typeof(IEnumerable<bool>),
            typeof(IEnumerable<byte>),
            typeof(IEnumerable<sbyte>),
            typeof(IEnumerable<char>),
            typeof(IEnumerable<decimal>),
            typeof(IEnumerable<double>),
            typeof(IEnumerable<float>),
            typeof(IEnumerable<int>),
            typeof(IEnumerable<uint>),
            typeof(IEnumerable<nint>),
            typeof(IEnumerable<nuint>),
            typeof(IEnumerable<long>),
            typeof(IEnumerable<ulong>),
            typeof(IEnumerable<short>),
            typeof(IEnumerable<ushort>),
            typeof(IEnumerable<string>),
            typeof(IEnumerable<object>)
        };

        /// <summary>
        /// Determines if the specified <see cref="Type"/> can be converted for serialization.
        /// </summary>
        /// <param name="objectType">Object type.</param>
        /// <returns><see langword="true"/> if the type is supported; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override bool CanConvert(Type objectType)
        {
            return _CompatibleTypes.Where(t => t.IsAssignableFrom(objectType)).Any();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrimitiveEnumerableConverter"/> class with no arguments.
        /// </summary>
        public PrimitiveEnumerableConverter()
            : base()
        { }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of the object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        /// <remarks>See <a href="https://stackoverflow.com/questions/28014002/json-net-error-unexpected-token-deserializing-object">Stack Overflow</a> for more information on reading custom collections with Newtonsoft.</remarks>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Type listType = typeof(List<>).MakeGenericType(new[] { objectType.GetGenericArguments()[0] });
            IList list = (IList)(Activator.CreateInstance(listType));

            JToken token = JToken.Load(reader);

            if (token.HasValues)
            {
                foreach (JToken item in token)
                {
                    list.Add(Convert.ChangeType(item.Value<object>(), objectType.GetGenericArguments()[0]));
                }
            }

            return Convert.ChangeType(list, listType);
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartArray();

            if (value != null && CanConvert(value.GetType()))
            {
                foreach (object item in ((IEnumerable)(value)))
                {
                    writer.WriteValue(item);
                }
            }

            writer.WriteEndArray();
        }
    }
}

