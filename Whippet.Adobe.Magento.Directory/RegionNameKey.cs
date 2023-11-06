using System;
using System.Text;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento.Directory
{
    /// <summary>
    /// Represents a composite key for <see cref="IRegion"/> object identifiers.
    /// </summary>
    public struct RegionNameKey : IEqualityComparer<RegionNameKey>, IJsonObject
    {
        /// <summary>
        /// Gets or sets the <see cref="IRegion"/> that the key applies to.
        /// </summary>
        public IRegion Region
        { get; set; }

        /// <summary>
        /// Gets or sets the locale of the <see cref="IRegionName"/>.
        /// </summary>
        public string Locale
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionNameKey"/> structure with no arguments.
        /// </summary>
        static RegionNameKey()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionNameKey"/> structure with the specified parameters.
        /// </summary>
        /// <param name="region"><see cref="IRegion"/> that the key applies to.</param>
        /// <param name="locale">Locale of the <see cref="IRegionName"/>.</param>
        public RegionNameKey(IRegion region, string locale)
            : this()
        {
            Region = region;
            Locale = locale;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return (obj == null || !(obj is RegionNameKey)) ? false : Equals((RegionNameKey)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(RegionNameKey obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(RegionNameKey x, RegionNameKey y)
        {
            return
                (((x.Region == null) && (y.Region == null)) || (x.Region != null && x.Region.Equals(y.Region)))
                    && String.Equals(x.Locale, y.Locale, StringComparison.InvariantCultureIgnoreCase);
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
        public int GetHashCode(RegionNameKey obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            bool appendClosingBrace = false;

            if (Region != null)
            {
                builder.Append(Region.ToString());
                builder.Append(' ');
            }

            if (!String.IsNullOrWhiteSpace(Locale))
            {
                if (!String.IsNullOrWhiteSpace(builder.ToString()))
                {
                    builder.Append('[');
                    appendClosingBrace = true;
                }

                builder.Append(Locale);

                if (appendClosingBrace)
                {
                    builder.Append(']');
                }
            }

            return (String.IsNullOrWhiteSpace(builder.ToString()) ? base.ToString() : builder.ToString().Trim());
        }

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be inherited.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public string ToJson<T>() where T : IJsonSerializableObject
        {
            return DefaultWhippetJsonObjectWriter.Instance.ToJson(this);
        }
    }
}

