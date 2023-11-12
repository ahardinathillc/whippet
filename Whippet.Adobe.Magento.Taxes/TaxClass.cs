using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento.Taxes
{
    /// <summary>
    /// Tax classification for customers in Magento.
    /// </summary>
    public class TaxClass : MagentoEntity, IMagentoEntity, ITaxClass, IEqualityComparer<ITaxClass>
    {
        private const string DEFAULT_TYPE = "CUSTOMER";

        /// <summary>
        /// Gets or sets the unique ID of the entity.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public new short ID
        {
            get
            {
                return Convert.ToInt16(base.ID);
            }
            set
            {
                base.ID = Convert.ToUInt32(value);
            }
        }

        /// <summary>
        /// Gets or sets the unique ID of the tax class.
        /// </summary>
        [JsonProperty("class_id")]
        public virtual short ClassID
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the tax class.
        /// </summary>
        [JsonProperty("class_name")]
        public virtual string ClassName
        { get; set; }

        /// <summary>
        /// Gets or sets the tax class type.
        /// </summary>
        [JsonProperty("class_type")]
        public virtual string ClassType
        { get; set; } = DEFAULT_TYPE;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxClass"/> class with no arguments.
        /// </summary>
        public TaxClass()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxClass"/> class with the specified class ID and <see cref="MagentoServer"/>.
        /// </summary>
        /// <param name="classId">Tax class ID.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        public TaxClass(uint classId, MagentoServer server)
            : base(classId, server)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return (obj == null || !(obj is ITaxClass)) ? false : Equals(obj as ITaxClass);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ITaxClass obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ITaxClass x, ITaxClass y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.ClassName, y.ClassName, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.ClassType, y.ClassType, StringComparison.InvariantCultureIgnoreCase);
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
        /// <param name="obj"><see cref="ITaxClass"/> object.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ITaxClass obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else
            {
                return obj.GetHashCode();
            }
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(ClassName) ? base.ToString() : ClassName + " [" + ClassType + "]";
        }

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be inherited.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public override string ToJson<T>()
        {
            return this.SerializeJson(this);
        }
    }
}