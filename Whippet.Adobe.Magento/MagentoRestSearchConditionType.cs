using System;
namespace Athi.Whippet.Adobe.Magento
{
    /// <summary>
    /// Provides an index of query conditions when using the Magento REST API search endpoint. This class cannot be inherited.
    /// </summary>
    [Obsolete("This class is obsolete. Use MagentoSearchCriteria instead.", false)]
    public static class MagentoRestSearchConditionType
    {
        /// <summary>
        /// Equals.
        /// </summary>
        public new const string Equals = "eq";

        /// <summary>
        /// The beginning of a range. Must be used with <see cref="To"/>.
        /// </summary>
        public const string WithinSetOfValues = "finset";

        /// <summary>
        /// The beginning of a range. Must be used with <see cref="To"/>.
        /// </summary>
        public const string From = "from";

        /// <summary>
        /// Greater than.
        /// </summary>
        public const string GreaterThan = "gt";

        /// <summary>
        /// Greater than or equal.
        /// </summary>
        public const string GreaterThanEqual = "gteq";

        /// <summary>
        /// In. The value can contain a comma-separated list of values.
        /// </summary>
        public const string In = "in";

        /// <summary>
        /// Like. The value can contain the SQL wildcard characters when like is specified.
        /// </summary>
        public const string Like = "like";

        /// <summary>
        /// Less than.
        /// </summary>
        public const string LessThan = "lt";

        /// <summary>
        /// Less than or equal.
        /// </summary>
        public const string LessThanEqual = "lteq";

        /// <summary>
        /// More or equal.
        /// </summary>
        public const string MoreOrEqual = "moreq";

        /// <summary>
        /// Not equal.
        /// </summary>
        public const string NotEqual = "neq";

        /// <summary>
        /// A value that is not within a set of values.
        /// </summary>
        public const string NotWithinSetOfValues = "nfinset";

        /// <summary>
        /// Not in. The value can contain a comma-separated list of values.
        /// </summary>
        public const string NotIn = "nin";

        /// <summary>
        /// Not like.
        /// </summary>
        public const string NotLike = "nlike";

        /// <summary>
        /// Not null.
        /// </summary>
        public const string NotNull = "notnull";

        /// <summary>
        /// Null.
        /// </summary>
        public const string Null = "null";

        /// <summary>
        /// The end of a range. Must be used with <see cref="From"/>.
        /// </summary>
        public const string To = "to";
    }
}