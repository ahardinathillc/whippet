using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Represents a composite key for loading <see cref="ISalesforcePriceBookEntry"/> objects.
    /// </summary>
    public struct SalesforcePriceBookEntryKey : IEqualityComparer<SalesforcePriceBookEntryKey>, ISalesforceCompositeReference
    {
        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> that is indexed by the Salesforce object column name and associated <see cref="SalesforceReference"/> value. This property is read-only.
        /// </summary>
        IReadOnlyDictionary<string, SalesforceReference> ISalesforceCompositeReference.CompositeValue
        {
            get
            {
                Dictionary<string, SalesforceReference> dict = new Dictionary<string, SalesforceReference>();

                dict.Add(nameof(PriceBookId), PriceBookId);
                dict.Add(nameof(ProductId), ProductId);

                return dict;
            }
        }

        /// <summary>
        /// Gets or sets the ID of the <see cref="ISalesforcePriceBook"/> to filter by.
        /// </summary>
        public SalesforceReference PriceBookId
        { get; set; }

        /// <summary>
        /// Gets or sets the ID of the <see cref="ISalesforceProduct"/> to filter by.
        /// </summary>
        public SalesforceReference ProductId
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforcePriceBookEntryKey"/> struct with no arguments.
        /// </summary>
        static SalesforcePriceBookEntryKey()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforcePriceBookEntryKey"/> struct with the specified parameters.
        /// </summary>
        /// <param name="priceBookId"><see cref="ISalesforcePriceBook"/> ID.</param>
        /// <param name="productId"><see cref="ISalesforceProduct"/> ID.</param>
        public SalesforcePriceBookEntryKey(SalesforceReference priceBookId, SalesforceReference productId)
            : this()
        {
            PriceBookId = priceBookId;
            ProductId = productId;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals([NotNullWhen(true)] object obj)
        {
            return (obj == null || !(obj is SalesforcePriceBookEntryKey)) ? false : Equals((SalesforcePriceBookEntryKey)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(SalesforcePriceBookEntryKey obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(SalesforcePriceBookEntryKey x, SalesforcePriceBookEntryKey y)
        {
            return String.Equals(x.PriceBookId, y.PriceBookId, StringComparison.InvariantCultureIgnoreCase) && String.Equals(x.ProductId, y.ProductId, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Gets the hash code for the current instance.
        /// </summary>
        /// <returns>Hash code for the current instance.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get the hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        public int GetHashCode(SalesforcePriceBookEntryKey obj)
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
            builder.Append('[');
            builder.Append(nameof(PriceBookId) + ": ");
            builder.Append(String.IsNullOrWhiteSpace(PriceBookId) ? "null" : PriceBookId);
            builder.Append(" | ");
            builder.Append(nameof(ProductId) + ": ");
            builder.Append(String.IsNullOrWhiteSpace(ProductId) ? "null" : ProductId);
            builder.Append(']');

            return builder.ToString();
        }

        public static bool operator ==(SalesforcePriceBookEntryKey x, SalesforcePriceBookEntryKey y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(SalesforcePriceBookEntryKey x, SalesforcePriceBookEntryKey y)
        {
            return !x.Equals(y);
        }

        public static implicit operator SalesforceReference(SalesforcePriceBookEntryKey pek)
        {
            return new SalesforceReference(pek);
        }
    }
}

