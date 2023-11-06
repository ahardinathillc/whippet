using System;
using System.Text;

namespace Athi.Whippet.Adobe.Magento
{
    /// <summary>
    /// Represents a search criterion entry used in building Magento search querystrings. This class cannot be inherited.
    /// </summary>
    public sealed class MagentoSearchCriteriaEntry : IEqualityComparer<MagentoSearchCriteriaEntry>
    {
        private const string TOKEN_CRITERIA = "searchCriteria";
        private const string TOKEN_FILTER_GROUPS = "filter_groups";
        private const string TOKEN_FILTERS = "filters";

        private readonly MagentoSearchCriteriaConditionType.Field _Field;
        private readonly MagentoSearchCriteriaConditionType.SearchValue _Value;
        private readonly MagentoSearchCriteriaConditionType _ConditionType;
        private readonly int _FilterGroup;
        private readonly int _FilterIndex;

        /// <summary>
        /// Gets the field to search on. This property is read-only.
        /// </summary>
        public MagentoSearchCriteriaConditionType.Field Field
        {
            get
            {
                return _Field;
            }
        }

        /// <summary>
        /// Gets the value to filter by. This property is read-only.
        /// </summary>
        public MagentoSearchCriteriaConditionType.SearchValue Value
        {
            get
            {
                return _Value;
            }
        }

        /// <summary>
        /// Gets the condition to apply to the query. This property is read-only.
        /// </summary>
        public MagentoSearchCriteriaConditionType Condition
        {
            get
            {
                return _ConditionType;
            }
        }

        /// <summary>
        /// Gets the filter group the entry belongs to. This property is read-only.
        /// </summary>
        public int Group
        {
            get
            {
                return _FilterGroup;
            }
        }

        /// <summary>
        /// Gets the filter index the entry belongs to. This property is read-only.
        /// </summary>
        public int Index
        {
            get
            {
                return _FilterIndex;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoSearchCriteriaEntry"/> class with no arguments.
        /// </summary>
        private MagentoSearchCriteriaEntry()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoSearchCriteriaEntry"/> class with the specified parameters.
        /// </summary>
        /// <param name="field">Field to search on.</param>
        /// <param name="value">Value <paramref name="field"/> contains to match.</param>
        /// <param name="conditionType">Condition type to apply to the query.</param>
        /// <param name="filterGroup">Filter group for creating logical AND statements.</param>
        /// <param name="filterIndex">Filter index for creating logical OR statements.</param>
        internal MagentoSearchCriteriaEntry(MagentoSearchCriteriaConditionType.Field field, MagentoSearchCriteriaConditionType.SearchValue value, MagentoSearchCriteriaConditionType conditionType, int filterGroup, int filterIndex)
            : this()
        {
            CheckArguments(field, value, conditionType, filterGroup, filterIndex);

            _Field = field;
            _Value = value;
            _ConditionType = conditionType;
            _FilterGroup = filterGroup;
            _FilterIndex = filterIndex;
        }

        /// <summary>
        /// Checks the arguments supplied to ensure validity.
        /// </summary>
        /// <param name="field">Field to search on.</param>
        /// <param name="value">Value <paramref name="field"/> contains to match.</param>
        /// <param name="conditionType">Condition type to apply to the query.</param>
        /// <param name="filterGroup">Filter group for creating logical AND statements.</param>
        /// <param name="filterIndex">Filter index for creating logical OR statements.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException" />
        private void CheckArguments(MagentoSearchCriteriaConditionType.Field field, MagentoSearchCriteriaConditionType.SearchValue value, MagentoSearchCriteriaConditionType conditionType, int filterGroup, int filterIndex)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }
            else if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            else if (conditionType == null)
            {
                throw new ArgumentNullException(nameof(conditionType));
            }
            else if (filterGroup < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(filterGroup));
            }
            else if (filterIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(filterIndex));
            }
            else if ((conditionType is MagentoSearchCriteriaConditionType.Field) || (conditionType is MagentoSearchCriteriaConditionType.SearchValue))
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return (obj == null) || !(obj is MagentoSearchCriteriaEntry) ? false : Equals((MagentoSearchCriteriaEntry)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(MagentoSearchCriteriaEntry obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(MagentoSearchCriteriaEntry x, MagentoSearchCriteriaEntry y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.ToString(), y.ToString(), StringComparison.InvariantCulture);
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get the hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(MagentoSearchCriteriaEntry obj)
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
            StringBuilder builder = new StringBuilder();
            StringBuilder builder_field = new StringBuilder();
            StringBuilder builder_value = new StringBuilder();
            StringBuilder builder_condition = new StringBuilder();

            builder.Append(TOKEN_CRITERIA);
            builder.Append('[');
            builder.Append(TOKEN_FILTER_GROUPS);
            builder.Append(']');
            builder.Append('[');
            builder.Append(Group);
            builder.Append(']');
            builder.Append('[');
            builder.Append(TOKEN_FILTERS);
            builder.Append(']');
            builder.Append('[');
            builder.Append(Index);
            builder.Append(']');

            builder_field = new StringBuilder(builder.ToString());
            builder_field.Append(Field.ToString(true));

            builder_value = new StringBuilder(builder.ToString());
            builder_value.Append(Value.ToString(true));

            builder_condition = new StringBuilder(builder.ToString());
            builder_condition.Append(Condition.ToString(true));

            return builder_field.ToString() + "&" + builder_value.ToString() + "&" + builder_condition.ToString();
        }
    }
}

