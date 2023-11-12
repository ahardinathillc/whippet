using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.Taxes.Models;

namespace Athi.Whippet.Adobe.Magento.Taxes.Json.Newtonsoft
{
    /// <summary>
    /// Converts <see cref="OpenSourceTaxRateModel"/> objects to and from JSON.
    /// </summary>
    public class OpenSourceTaxRateConverter : JsonConverter<OpenSourceTaxRateModel>
    {
        /// <summary>
        /// Reads a <see cref="OpenSourceTaxRateModel"/> from the specified parameters.
        /// </summary>
        /// <param name="reader"><see cref="JsonReader"/> from which the JSON is read.</param>
        /// <param name="objectType">Type of object.</param>
        /// <param name="existingValue">Existing value that was supplied.</param>
        /// <param name="hasExistingValue">Indicates whether an existing value was supplied.</param>
        /// <param name="serializer"><see cref="JsonSerializer"/> object.</param>
        /// <returns><see cref="OpenSourceTaxRateModel"/> value.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override OpenSourceTaxRateModel ReadJson(JsonReader reader, Type objectType, OpenSourceTaxRateModel? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            OpenSourceTaxRateModel value = null;
            
            if ((reader.Value != null) || !String.IsNullOrWhiteSpace(Convert.ToString(reader.Value)))
            {
                value = serializer.Deserialize<OpenSourceTaxRateModel>(reader);
            }

            return value;
        }

        /// <summary>
        /// Writes the <see cref="OpenSourceTaxRateModel"/> value to <paramref name="writer"/>.
        /// </summary>
        /// <param name="writer"><see cref="JsonWriter"/> used to emit JSON.</param>
        /// <param name="value">Value to write.</param>
        /// <param name="serializer"><see cref="JsonSerializer"/> object.</param>
        /// <exception cref="NotImplementedException"></exception>
        public override void WriteJson(JsonWriter writer, OpenSourceTaxRateModel value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToMagentoJsonString());
        }
    }
}
