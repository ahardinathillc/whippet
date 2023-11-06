using System;
using Athi.Whippet.Extensions.Primitives;

namespace Athi.Whippet.Adobe.Magento
{
    /// <summary>
    /// Represents a condition that is applied to a Magento search criteria. This class must be inherited.
    /// </summary>
    public abstract class MagentoSearchCriteriaConditionType : IEqualityComparer<MagentoSearchCriteriaConditionType>
    {
        private const string SHARED_TOKEN = "condition_type";

        /// <summary>
        /// Gets the token that the current condition represents. This property is read-only.
        /// </summary>
        public string Token
        { get; private set; }

        /// <summary>
        /// Gets the value that is associated with the token. This property is read-only.
        /// </summary>
        public string Value
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoSearchCriteriaConditionType"/> class with no arguments.
        /// </summary>
        private MagentoSearchCriteriaConditionType()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoSearchCriteriaConditionType"/> class with the specified token and value.
        /// </summary>
        /// <param name="token">Token the current condition represents.</param>
        /// <param name="value">Value that is associated with the token.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected MagentoSearchCriteriaConditionType(string token, string value)
            : this()
        {
            if (String.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentNullException(nameof(token));
            }
            else
            {
                Token = token;
                Value = value;
            }
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get the hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual int GetHashCode(MagentoSearchCriteriaConditionType obj)
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
            return ToString(true);
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <param name="decorateToken">If <see langword="true"/>, will decorate the <see cref="Token"/> value with square brackets.</param>
        /// <returns>String representation of the current object.</returns>
        public string ToString(bool decorateToken)
        {
            string token = Token;

            if (!String.IsNullOrWhiteSpace(token) && decorateToken)
            {
                if (!token.StartsWith('['))
                {
                    token = '[' + token;
                }

                if (!token.EndsWith(']'))
                {
                    token = token + ']';
                }
            }

            return (String.IsNullOrWhiteSpace(token) || String.IsNullOrWhiteSpace(Value)) ? base.ToString() : token + "=" + Value;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is MagentoSearchCriteriaConditionType)) ? false : Equals((MagentoSearchCriteriaConditionType)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(MagentoSearchCriteriaConditionType obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(MagentoSearchCriteriaConditionType x, MagentoSearchCriteriaConditionType y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.Token, y.Token, StringComparison.InvariantCultureIgnoreCase) && String.Equals(x.Value, y.Value, StringComparison.InvariantCultureIgnoreCase);
            }

            return equals;
        }

        /// <summary>
        /// Specifies the field to apply the search criteria to. This class cannot be inherited.
        /// </summary>
        public sealed class Field : MagentoSearchCriteriaConditionType
        {
            private const string TOKEN = "field";

            /// <summary>
            /// Initializes a new instance of the <see cref="Field"/> class with the specified value.
            /// </summary>
            /// <param name="value">Value that is associated with the token.</param>
            private Field(string value)
                : base(TOKEN, value)
            { }

            /// <summary>
            /// Creates a new <see cref="Field"/> instance based on the specified value.
            /// </summary>
            /// <param name="value">Value to search for.</param>
            /// <returns><see cref="Field"/> object.</returns>
            public static Field Create(string value)
            {
                return new Field(value);
            }
        }

        /// <summary>
        /// Specifies the search value. This class cannot be inherited.
        /// </summary>
        public sealed class SearchValue : MagentoSearchCriteriaConditionType
        {
            private const string TOKEN = "value";

            /// <summary>
            /// Initializes a new instance of the <see cref="SearchValue"/> class with the specified value.
            /// </summary>
            /// <param name="value">Value that is associated with the token.</param>
            private SearchValue(string value)
                : base(TOKEN, value)
            { }

            /// <summary>
            /// Creates a new <see cref="SearchValue"/> instance based on the specified value.
            /// </summary>
            /// <param name="value">Value to search for.</param>
            /// <returns><see cref="Field"/> object.</returns>
            public static SearchValue Create(string value)
            {
                return new SearchValue(value);
            }
        }

        /// <summary>
        /// Provides an equality comparison in the search. This class cannot be inherited.
        /// </summary>
        public sealed class EqualsCondition : MagentoSearchCriteriaConditionType
        {
            private const string TOKEN = "eq";

            /// <summary>
            /// Initializes a new instance of the <see cref="EqualsCondition"/> class with the specified value.
            /// </summary>
            /// <param name="value">Value that is associated with the token.</param>
            private EqualsCondition(string value)
                : base(SHARED_TOKEN, value)
            { }

            /// <summary>
            /// Creates a new <see cref="EqualsCondition"/> instance.
            /// </summary>
            /// <returns><see cref="EqualsCondition"/> object.</returns>
            public static EqualsCondition Create()
            {
                return new EqualsCondition(TOKEN);
            }
        }

        /// <summary>
        /// Searches for a value within a set of values. This class cannot be inherited.
        /// </summary>
        public sealed class SubsetCondition : MagentoSearchCriteriaConditionType
        {
            private const string TOKEN = "finset";

            /// <summary>
            /// Initializes a new instance of the <see cref="SubsetCondition"/> class with the specified value.
            /// </summary>
            /// <param name="value">Value that is associated with the token.</param>
            private SubsetCondition(string value)
                : base(SHARED_TOKEN, value)
            { }

            /// <summary>
            /// Creates a new <see cref="SubsetCondition"/> instance.
            /// </summary>
            /// <returns><see cref="SubsetCondition"/> object.</returns>
            public static SubsetCondition Create()
            {
                return new SubsetCondition(TOKEN);
            }
        }

        /// <summary>
        /// Searches for all values that fall between two values inclusive. This class cannot be inherited.
        /// </summary>
        public sealed class RangeCondition : MagentoSearchCriteriaConditionType
        {
            private const string TOKEN_FROM = "from";
            private const string TOKEN_TO = "to";

            /// <summary>
            /// Initializes a new instance of the <see cref="RangeCondition"/> class with the specified value.
            /// </summary>
            /// <param name="value">Value that is associated with the token.</param>
            private RangeCondition(string value)
                : base(SHARED_TOKEN, value)
            { }

            /// <summary>
            /// Creates a <see cref="Tuple{T1, T2}"/> containing the beginning and ending range tokens.
            /// </summary>
            /// <returns><see cref="Tuple{T1, T2}"/> containing the beginning and ending range tokens.</returns>
            public static Tuple<RangeCondition, RangeCondition> Create()
            {
                return new Tuple<RangeCondition, RangeCondition>(new RangeCondition(TOKEN_FROM), new RangeCondition(TOKEN_TO));
            }
        }

        /// <summary>
        /// Searches for values that are greater than the specified value (exclusive). This class cannot be inherited.
        /// </summary>
        public sealed class GreaterThanCondition : MagentoSearchCriteriaConditionType
        {
            private const string TOKEN = "gt";

            /// <summary>
            /// Initializes a new instance of the <see cref="GreaterThanCondition"/> class with the specified value.
            /// </summary>
            /// <param name="value">Value that is associated with the token.</param>
            private GreaterThanCondition(string value)
                : base(SHARED_TOKEN, value)
            { }

            /// <summary>
            /// Creates a new <see cref="GreaterThanCondition"/> instance.
            /// </summary>
            /// <returns><see cref="SubsetCondition"/> object.</returns>
            public static GreaterThanCondition Create()
            {
                return new GreaterThanCondition(TOKEN);
            }
        }

        /// <summary>
        /// Searches for values that are greater than or equal to the specified value (inclusive). This class cannot be inherited.
        /// </summary>
        public sealed class GreaterThanOrEqualCondition : MagentoSearchCriteriaConditionType
        {
            private const string TOKEN = "gteq";

            /// <summary>
            /// Initializes a new instance of the <see cref="GreaterThanOrEqualCondition"/> class with the specified value.
            /// </summary>
            /// <param name="value">Value that is associated with the token.</param>
            private GreaterThanOrEqualCondition(string value)
                : base(SHARED_TOKEN, value)
            { }

            /// <summary>
            /// Creates a new <see cref="GreaterThanOrEqualCondition"/> instance.
            /// </summary>
            /// <returns><see cref="SubsetCondition"/> object.</returns>
            public static GreaterThanOrEqualCondition Create()
            {
                return new GreaterThanOrEqualCondition(TOKEN);
            }
        }

        /// <summary>
        /// Searches for one or more values that match the supplied criterion. This class cannot be inherited.
        /// </summary>
        public sealed class InCondition : MagentoSearchCriteriaConditionType
        {
            private const string TOKEN = "in";

            /// <summary>
            /// Initializes a new instance of the <see cref="InCondition"/> class with the specified value.
            /// </summary>
            /// <param name="value">Value that is associated with the token.</param>
            private InCondition(string value)
                : base(SHARED_TOKEN, value)
            { }

            /// <summary>
            /// Creates a new <see cref="InCondition"/> instance.
            /// </summary>
            /// <returns><see cref="InCondition"/> object.</returns>
            public static InCondition Create()
            {
                return new InCondition(TOKEN);
            }
        }

        /// <summary>
        /// Searches for values that match the specified pattern. The value can contain SQL wildcard characters. This class cannot be inherited.
        /// </summary>
        public sealed class LikeCondition : MagentoSearchCriteriaConditionType
        {
            private const string TOKEN = "like";

            /// <summary>
            /// Initializes a new instance of the <see cref="LikeCondition"/> class with the specified value.
            /// </summary>
            /// <param name="value">Value that is associated with the token.</param>
            private LikeCondition(string value)
                : base(SHARED_TOKEN, value)
            { }

            /// <summary>
            /// Creates a new <see cref="LikeCondition"/> instance.
            /// </summary>
            /// <returns><see cref="LikeCondition"/> object.</returns>
            public static LikeCondition Create()
            {
                return new LikeCondition(TOKEN);
            }
        }

        /// <summary>
        /// Searches for values that are less than the specified value (exclusive). This class cannot be inherited.
        /// </summary>
        public sealed class LessThanCondition : MagentoSearchCriteriaConditionType
        {
            private const string TOKEN = "lt";

            /// <summary>
            /// Initializes a new instance of the <see cref="LessThanCondition"/> class with the specified value.
            /// </summary>
            /// <param name="value">Value that is associated with the token.</param>
            private LessThanCondition(string value)
                : base(SHARED_TOKEN, value)
            { }

            /// <summary>
            /// Creates a new <see cref="LessThanCondition"/> instance.
            /// </summary>
            /// <returns><see cref="LessThanCondition"/> object.</returns>
            public static LessThanCondition Create()
            {
                return new LessThanCondition(TOKEN);
            }
        }

        /// <summary>
        /// Searches for values that are less than or equal to the specified value (inclusive). This class cannot be inherited.
        /// </summary>
        public sealed class LessThanOrEqualCondition : MagentoSearchCriteriaConditionType
        {
            private const string TOKEN = "lteq";

            /// <summary>
            /// Initializes a new instance of the <see cref="LessThanOrEqualCondition"/> class with the specified value.
            /// </summary>
            /// <param name="value">Value that is associated with the token.</param>
            private LessThanOrEqualCondition(string value)
                : base(SHARED_TOKEN, value)
            { }

            /// <summary>
            /// Creates a new <see cref="LessThanOrEqualCondition"/> instance.
            /// </summary>
            /// <returns><see cref="LessThanOrEqualCondition"/> object.</returns>
            public static LessThanOrEqualCondition Create()
            {
                return new LessThanOrEqualCondition(TOKEN);
            }
        }

        /// <summary>
        /// Searches for values that are greater than or equal to the specified value (inclusive). This class cannot be inherited.
        /// </summary>
        public sealed class MoreOrEqualCondition : MagentoSearchCriteriaConditionType
        {
            private const string TOKEN = "moreq";

            /// <summary>
            /// Initializes a new instance of the <see cref="MoreOrEqualCondition"/> class with the specified value.
            /// </summary>
            /// <param name="value">Value that is associated with the token.</param>
            private MoreOrEqualCondition(string value)
                : base(SHARED_TOKEN, value)
            { }

            /// <summary>
            /// Creates a new <see cref="MoreOrEqualCondition"/> instance.
            /// </summary>
            /// <returns><see cref="MoreOrEqualCondition"/> object.</returns>
            public static MoreOrEqualCondition Create(string value)
            {
                return new MoreOrEqualCondition(value);
            }
        }

        /// <summary>
        /// Searches for values that are not equal to the specified value. This class cannot be inherited.
        /// </summary>
        public sealed class NotEqualCondition : MagentoSearchCriteriaConditionType
        {
            private const string TOKEN = "neq";

            /// <summary>
            /// Initializes a new instance of the <see cref="NotEqualCondition"/> class with the specified value.
            /// </summary>
            /// <param name="value">Value that is associated with the token.</param>
            private NotEqualCondition(string value)
                : base(SHARED_TOKEN, value)
            { }

            /// <summary>
            /// Creates a new <see cref="NotEqualCondition"/> instance.
            /// </summary>
            /// <returns><see cref="NotEqualCondition"/> object.</returns>
            public static NotEqualCondition Create()
            {
                return new NotEqualCondition(TOKEN);
            }
        }

        /// <summary>
        /// Searches for a value that is not within a set of values. This class cannot be inherited.
        /// </summary>
        public sealed class ExclusionCondition : MagentoSearchCriteriaConditionType
        {
            private const string TOKEN = "nfinset";

            /// <summary>
            /// Initializes a new instance of the <see cref="ExclusionCondition"/> class with the specified value.
            /// </summary>
            /// <param name="value">Value that is associated with the token.</param>
            private ExclusionCondition(string value)
                : base(SHARED_TOKEN, value)
            { }

            /// <summary>
            /// Creates a new <see cref="ExclusionCondition"/> instance.
            /// </summary>
            /// <returns><see cref="ExclusionCondition"/> object.</returns>
            public static ExclusionCondition Create()
            {
                return new ExclusionCondition(TOKEN);
            }
        }

        /// <summary>
        /// Searches for one or more values that are not a match the supplied criterion. This class cannot be inherited.
        /// </summary>
        public sealed class NotInCondition : MagentoSearchCriteriaConditionType
        {
            private const string TOKEN = "nin";

            /// <summary>
            /// Initializes a new instance of the <see cref="NotInCondition"/> class with the specified value.
            /// </summary>
            /// <param name="value">Value that is associated with the token.</param>
            private NotInCondition(string value)
                : base(SHARED_TOKEN, value)
            { }

            /// <summary>
            /// Creates a new <see cref="NotInCondition"/> instance.
            /// </summary>
            /// <returns><see cref="NotInCondition"/> object.</returns>
            public static NotInCondition Create()
            {
                return new NotInCondition(TOKEN);
            }
        }

        /// <summary>
        /// Searches for values that do not match the specified pattern. The value can contain SQL wildcard characters. This class cannot be inherited.
        /// </summary>
        public sealed class NotLikeCondition : MagentoSearchCriteriaConditionType
        {
            private const string TOKEN = "nlike";

            /// <summary>
            /// Initializes a new instance of the <see cref="NotLikeCondition"/> class with the specified value.
            /// </summary>
            /// <param name="value">Value that is associated with the token.</param>
            private NotLikeCondition(string value)
                : base(SHARED_TOKEN, value)
            { }

            /// <summary>
            /// Creates a new <see cref="NotLikeCondition"/> instance.
            /// </summary>
            /// <returns><see cref="NotLikeCondition"/> object.</returns>
            public static NotLikeCondition Create()
            {
                return new NotLikeCondition(TOKEN);
            }
        }

        /// <summary>
        /// Searches for values that are not <see langword="null"/>. This class cannot be inherited.
        /// </summary>
        public sealed class NotNullCondition : MagentoSearchCriteriaConditionType
        {
            private const string TOKEN = "notnull";

            /// <summary>
            /// Initializes a new instance of the <see cref="NotNullCondition"/> class with the specified value.
            /// </summary>
            /// <param name="value">Value that is associated with the token.</param>
            private NotNullCondition(string value)
                : base(SHARED_TOKEN, value)
            { }

            /// <summary>
            /// Creates a new <see cref="NotNullCondition"/> instance.
            /// </summary>
            /// <returns><see cref="NotNullCondition"/> object.</returns>
            public static NotNullCondition Create()
            {
                return new NotNullCondition(TOKEN);
            }
        }

        /// <summary>
        /// Searches for values that are <see langword="null"/>. This class cannot be inherited.
        /// </summary>
        public sealed class NullCondition : MagentoSearchCriteriaConditionType
        {
            private const string TOKEN = "null";

            /// <summary>
            /// Initializes a new instance of the <see cref="NullCondition"/> class with the specified value.
            /// </summary>
            /// <param name="value">Value that is associated with the token.</param>
            private NullCondition(string value)
                : base(SHARED_TOKEN, value)
            { }

            /// <summary>
            /// Creates a new <see cref="NullCondition"/> instance.
            /// </summary>
            /// <returns><see cref="NullCondition"/> object.</returns>
            public static NullCondition Create()
            {
                return new NullCondition(TOKEN);
            }
        }
    }
}

