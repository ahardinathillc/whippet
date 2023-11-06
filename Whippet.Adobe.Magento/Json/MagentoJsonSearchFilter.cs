using System;
using System.Text;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Json
{
    /// <summary>
    /// Represents a Magento API search filter.
    /// </summary>
    public class MagentoJsonSearchFilter : IMagentoJsonSearchFilter, IEqualityComparer<IMagentoJsonSearchFilter>
    {
        private const string JSP_FIELD = "field";
        private const string JSP_VALUE = "value";
        private const string JSP_CONDITION_TYPE = "condition_type";

        /// <summary>
        /// Gets or sets the field name that is being queried.
        /// </summary>
        [JsonProperty(JSP_FIELD)]
        public string Field
        { get; set; }

        /// <summary>
        /// Gets or sets the search value that is being queried in <see cref="Field"/>.
        /// </summary>
        [JsonProperty(JSP_VALUE)]
        public string Value
        { get; set; }

        /// <summary>
        /// Gets or sets the condition type (if any).
        /// </summary>
        [JsonProperty(JSP_CONDITION_TYPE)]
        public string ConditionType
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoJsonSearchFilter"/> class with no arguments.
        /// </summary>
        public MagentoJsonSearchFilter()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoJsonSearchFilter"/> class with the specified parameters.
        /// </summary>
        /// <param name="field">Field name that is being queried.</param>
        /// <param name="value">Value that is being queried in <paramref name="field"/>.</param>
        /// <param name="conditionType">Condition type (if any).</param>
        public MagentoJsonSearchFilter(string field, string value, string conditionType)
            : this()
        {
            Field = field;
            Value = value;
            ConditionType = conditionType;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return (obj == null) ? false : Equals(obj as IMagentoJsonSearchFilter);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(IMagentoJsonSearchFilter obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(IMagentoJsonSearchFilter x, IMagentoJsonSearchFilter y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.Field, y.Field, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Value, y.Value, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.ConditionType, y.ConditionType, StringComparison.InvariantCultureIgnoreCase);
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get the hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException" />
        public int GetHashCode(IMagentoJsonSearchFilter obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            return obj.GetHashCode();
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            StringWriter stringWriter = null;
            JsonWriter writer = null;
            StringBuilder builder = null;

            try
            {
                builder = new StringBuilder();
                stringWriter = new StringWriter(builder);
                writer = new JsonTextWriter(stringWriter);

                writer.Formatting = Formatting.Indented;

                writer.WriteStartObject();
                writer.WritePropertyName(JSP_FIELD, true);
                writer.WriteValue(Field);
                writer.WritePropertyName(JSP_VALUE, true);
                writer.WriteValue(Value);
                writer.WritePropertyName(JSP_CONDITION_TYPE, true);
                writer.WriteValue(ConditionType);
                writer.WriteEndObject();
            }
            finally
            {
                if (writer != null)
                {
                    writer.Flush();
                    writer.Close();
                    writer = null;
                }

                if (stringWriter != null)
                {
                    stringWriter.Flush();
                    stringWriter.Close();
                    stringWriter.Dispose();
                    stringWriter = null;
                }
            }

            return (builder == null || String.IsNullOrWhiteSpace(builder.ToString())) ? base.ToString() : builder.ToString();
        }
    }
}
