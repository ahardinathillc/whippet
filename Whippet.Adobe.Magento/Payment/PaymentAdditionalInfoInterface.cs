using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Payment
{
    /// <summary>
    /// Interface that provides extra information about a payment in Magento.
    /// </summary>
    public class PaymentAdditionalInfoInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the object key.
        /// </summary>
        [JsonProperty("key")] 
        public string Key
        { get; set; }

        /// <summary>
        /// Gets or sets the object value.
        /// </summary>
        [JsonProperty("value")]
        public string Value
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentAdditionalInfoInterface"/> class with no arguments.
        /// </summary>
        public PaymentAdditionalInfoInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentAdditionalInfoInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="key">Object key.</param>
        /// <param name="value">Object value.</param>
        public PaymentAdditionalInfoInterface(string key, string value)
            : this()
        {
            Key = key;
            Value = value;
        }
    }
}
