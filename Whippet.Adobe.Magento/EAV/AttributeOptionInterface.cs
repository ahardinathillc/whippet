using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.EAV
{
    /// <summary>
    /// Interface that provides information about a Magento attribute option.
    /// </summary>
    public class AttributeOptionInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the option label.
        /// </summary>
        [JsonProperty("label")]
        public string Label
        { get; set; }

        /// <summary>
        /// Gets or sets the option value.
        /// </summary>
        [JsonProperty("value")]
        public string Value
        { get; set; }

        /// <summary>
        /// Gets or sets the option value.
        /// </summary>
        [JsonProperty("sort_order")]
        public int SortOrder
        { get; set; }

        /// <summary>
        /// Specifies whether the option is the default.
        /// </summary>
        [JsonProperty("is_default")]
        public bool IsDefault
        { get; set; }

        /// <summary>
        /// Gets or sets the option label(s) for store scopes.
        /// </summary>
        [JsonProperty("store_labels")]
        public AttributeOptionLabelInterface[] StoreLabels
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeOptionInterface"/> class with no arguments.
        /// </summary>
        public AttributeOptionInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeOptionInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="label">Option label.</param>
        /// <param name="value">Option value.</param>
        /// <param name="sortOrder">Sort order.</param>
        /// <param name="isDefault">Specifies whether the option is the default.</param>
        /// <param name="storeLabels">Option label(s) for store scopes.</param>
        public AttributeOptionInterface(string label, string value, int sortOrder, bool isDefault, IEnumerable<AttributeOptionLabelInterface> storeLabels)
            : this()
        {
            Label = label;
            Value = value;
            SortOrder = sortOrder;
            IsDefault = isDefault;
            StoreLabels = (storeLabels == null) ? null : storeLabels.ToArray();
        }
    }
}
