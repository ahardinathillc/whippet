using System;
using System.Globalization;
using NodaTime;
using Newtonsoft.Json;

namespace Athi.Whippet.Json.Newtonsoft.Converters
{
    /// <summary>
    /// Converts a (nullable) <see cref="DateTime"/> value to a nullable <see cref="Instant"/> value.
    /// </summary>
    public class NullableInstantConverter : JsonConverter<Instant?>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullableInstantConverter"/> class with no arguments.
        /// </summary>
        public NullableInstantConverter()
            : base()
        { }

        /// <summary>
        /// Indicates whether the type can be converted.
        /// </summary>
        /// <param name="type"><see cref="Type"/> of object to convert.</param>
        /// <returns><see langword="true"/> if the type can be converted; otherwise, <see langword="false"/>.</returns>
        public new bool CanConvert(Type type)
        {
            return typeof(Instant).Equals(type) || typeof(DateTime).Equals(type) || typeof(Instant?).Equals(type) || typeof(DateTime?).Equals(type);
        }

        /// <summary>
        /// Writes the nullable <see cref="Instant"/> value to <paramref name="writer"/>.
        /// </summary>
        /// <param name="writer"><see cref="JsonWriter"/> used to emit JSON.</param>
        /// <param name="value">Value to write.</param>
        /// <param name="serializer"><see cref="JsonSerializer"/> object.</param>
        /// <exception cref="NotImplementedException"></exception>
        public override void WriteJson(JsonWriter writer, Instant? value, JsonSerializer serializer)
        {
            if (value.HasValue)
            {
                writer.WriteValue(value.GetValueOrDefault().ToDateTimeUtc());
            }
            else
            {
                writer.WriteNull();
            }
        }

        /// <summary>
        /// Reads an <see cref="Instant"/> from the specified parameters.
        /// </summary>
        /// <param name="reader"><see cref="JsonReader"/> from which the JSON is read.</param>
        /// <param name="objectType">Type of object.</param>
        /// <param name="existingValue">Existing value that was supplied.</param>
        /// <param name="hasExistingValue">Indicates whether an existing value was supplied.</param>
        /// <param name="serializer"><see cref="JsonSerializer"/> object.</param>
        /// <returns><see cref="Instant"/> value.</returns>
        public override Instant? ReadJson(JsonReader reader, Type objectType, Instant? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Instant? value = null;
            DateTime intermediateValue = default(DateTime);
            bool hasValue = false;

            if ((reader.Value != null) || !String.IsNullOrWhiteSpace(Convert.ToString(reader.Value)))
            {
                if (reader.Value is DateTime || reader.Value is DateTime?)
                {
                    if ((reader.Value is DateTime?) && ((DateTime?)(reader.Value)).HasValue)
                    {
                        intermediateValue = ((DateTime?)(reader.Value)).Value;
                        hasValue = true;
                    }
                    else if (reader.Value is DateTime)
                    {
                        intermediateValue = ((DateTime)(reader.Value));
                        hasValue = true;
                    }

                    if (hasValue)
                    {
                        if (intermediateValue.Kind != DateTimeKind.Utc)
                        {
                            intermediateValue = DateTime.Parse(Convert.ToString(reader.Value), null, DateTimeStyles.AdjustToUniversal);
                            intermediateValue = new DateTime(
                                intermediateValue.Year,
                                intermediateValue.Month,
                                intermediateValue.Day,
                                intermediateValue.Hour,
                                intermediateValue.Minute,
                                intermediateValue.Second,
                                intermediateValue.Millisecond,
                                intermediateValue.Microsecond,
                                DateTimeKind.Utc
                            );
                        }

                        value = Instant.FromDateTimeUtc(intermediateValue);     // if not a DateTime, let Instant throw the exception
                    }
                }
                else if (reader.Value is Instant)
                {
                    value = ((Instant)(reader.Value));
                }
            }

            return value;
        }
    }
}
