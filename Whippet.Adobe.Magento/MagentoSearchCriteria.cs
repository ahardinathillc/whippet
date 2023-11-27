using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Athi.Whippet.Adobe.Magento
{
    /// <summary>
    /// Represents a search criteria used in Magento's REST API. This class cannot be inherited.
    /// </summary>
    public sealed class MagentoSearchCriteria : IEnumerable<KeyValuePair<int, IEnumerable<Tuple<int, MagentoSearchCriteriaEntry>>>>
    {
        // searchCriteria[filter_groups][<index>][filters][<index>][field]=<field_name>
        // searchCriteria[filter_groups][< index >][filters][< index >][value]=<search_value>
        // searchCriteria[filter_groups][< index >][filters][< index >][condition_type]=<operator>

        private Dictionary<int, List<Tuple<int, MagentoSearchCriteriaEntry>>> _searchCriteria;

        private static readonly MagentoSearchCriteria _All = new MagentoSearchCriteria(true);
        
        /// <summary>
        /// Gets the <see cref="MagentoSearchCriteria"/> that retrieves all records for a specific Magento entity. This property is read-only.
        /// </summary>
        public static MagentoSearchCriteria All
        {
            get
            {
                return _All;
            }
        }
        
        /// <summary>
        /// Gets the search criteria to build the querystring. This property is read-only.
        /// </summary>
        private Dictionary<int, List<Tuple<int, MagentoSearchCriteriaEntry>>> SearchCriteria
        {
            get
            {
                if (_searchCriteria == null)
                {
                    _searchCriteria = new Dictionary<int, List<Tuple<int, MagentoSearchCriteriaEntry>>>();
                }

                return _searchCriteria;
            }
        }

        /// <summary>
        /// Indicates whether the current <see cref="MagentoSearchCriteria"/> is the criteria that retrieves all records for an entity.
        /// </summary>
        private bool IsAllSearchCriteria
        { get; set; }
        
        /// <summary>
        /// Gets all available filter groups. This property is read-only.
        /// </summary>
        public IEnumerable<int> FilterGroups
        {
            get
            {
                // default to the first filter group if no criteria is added

                return (SearchCriteria.Keys.Count > 0) ? SearchCriteria.Keys : new[] { 0 };
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoSearchCriteria"/> class.
        /// </summary>
        /// <param name="isAll">If <see langword="true"/>, will mark the <see cref="MagentoSearchCriteria"/> as the criteria that retrieves all records for an entity.</param>
        private MagentoSearchCriteria(bool isAll)
        {
            IsAllSearchCriteria = isAll;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoSearchCriteria"/> class with no arguments.
        /// </summary>
        public MagentoSearchCriteria()
            : this(false)
        { }

        /// <summary>
        /// Adds a search criterion to the current statement.
        /// </summary>
        /// <param name="field">Field to query.</param>
        /// <param name="value">Value or pattern to match.</param>
        /// <param name="conditionType">Condition type that controls the query behavior.</param>
        /// <param name="filterGroup">Filter group of the criterion.</param>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public void AddCriterion(MagentoSearchCriteriaConditionType.Field field, MagentoSearchCriteriaConditionType.SearchValue value, MagentoSearchCriteriaConditionType conditionType, int filterGroup = 0)
        {
            CheckArguments(field, value, conditionType, filterGroup);

            if (!SearchCriteria.ContainsKey(filterGroup))
            {
                SearchCriteria.Add(filterGroup, new List<Tuple<int, MagentoSearchCriteriaEntry>>());
            }
            else if (SearchCriteria[filterGroup] == null)
            {
                SearchCriteria[filterGroup] = new List<Tuple<int, MagentoSearchCriteriaEntry>>();
            }

            if (SearchCriteria[filterGroup].Count != 0)
            {
                AddCriterion(field, value, conditionType, SearchCriteria.Keys.Max() + 1);
            }
            else
            {
                SearchCriteria[filterGroup].Add(new Tuple<int, MagentoSearchCriteriaEntry>(0, new MagentoSearchCriteriaEntry(field, value, conditionType, filterGroup, 0)));
            }
        }

        /// <summary>
        /// Adds a search criterion to the current statement using a logical AND statement.
        /// </summary>
        /// <param name="field">Field to query.</param>
        /// <param name="value">Value or pattern to match.</param>
        /// <param name="conditionType">Condition type that controls the query behavior.</param>
        /// <param name="filterGroup">Filter group of the criterion.</param>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public void AddAndCriterion(MagentoSearchCriteriaConditionType.Field field, MagentoSearchCriteriaConditionType.SearchValue value, MagentoSearchCriteriaConditionType conditionType, int filterGroup = 0)
        {
            int filterIndex = 0;

            CheckArguments(field, value, conditionType, filterGroup);

            if (!SearchCriteria.ContainsKey(filterGroup) || SearchCriteria[filterGroup] == null)
            {
                AddCriterion(field, value, conditionType, filterGroup);
            }
            else
            {
                filterIndex = SearchCriteria[filterGroup].Select(entry => entry.Item1).Max() + 1;
                SearchCriteria[filterGroup].Add(new Tuple<int, MagentoSearchCriteriaEntry>(filterIndex, new MagentoSearchCriteriaEntry(field, value, conditionType, filterGroup, filterIndex)));
            }
        }

        /// <summary>
        /// Checks the arguments supplied to ensure validity.
        /// </summary>
        /// <param name="field">Field to search on.</param>
        /// <param name="value">Value <paramref name="field"/> contains to match.</param>
        /// <param name="conditionType">Condition type to apply to the query.</param>
        /// <param name="filterGroup">Optional filter group for creating logical AND statements.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException" />
        private void CheckArguments(MagentoSearchCriteriaConditionType.Field field, MagentoSearchCriteriaConditionType.SearchValue value, MagentoSearchCriteriaConditionType conditionType, int? filterGroup = null)
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
            else if (filterGroup.HasValue && (filterGroup.Value < 0 || ((FilterGroups != null && FilterGroups.Any()) && (filterGroup.Value > (FilterGroups.Max() + 2)))))   // cannot have filter group that exceeds the maximum filter groups by two or more
            {
                throw new ArgumentOutOfRangeException(nameof(filterGroup));
            }
            else if ((conditionType is MagentoSearchCriteriaConditionType.Field) || (conditionType is MagentoSearchCriteriaConditionType.SearchValue))
            {
                throw new ArgumentException();
            }
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
        /// <param name="prependQuerystring">If <see langword="true"/>, will prepend the querystring with &quot;?&quot;.</param>
        /// <returns>String representation of the current object.</returns>
        public string ToString(bool prependQuerystring)
        {
            StringBuilder builder = new StringBuilder();

            if (prependQuerystring)
            {
                builder.Append('?');
            }

            if (!IsAllSearchCriteria)
            {
                if (SearchCriteria.Count > 0)
                {
                    foreach (int i in SearchCriteria.Keys.OrderBy(key => key))
                    {
                        foreach (Tuple<int, MagentoSearchCriteriaEntry> entry in SearchCriteria[i].OrderBy(entryKey => entryKey.Item1))
                        {
                            builder.Append(entry.Item2.ToString());
                            builder.Append('&');
                        }
                    }

                    if (builder.ToString().EndsWith('&'))
                    {
                        builder = new StringBuilder(builder.ToString().Substring(0, builder.ToString().Length - 1));
                    }
                }
                else
                {
                    builder.Append(base.ToString());
                }
            }
            else
            {
                builder.Append("searchCriteria=all");
            }

            return builder.ToString();
        }

        /// <summary>
        /// Gets an enumerator used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator"/> object.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<int, IEnumerable<Tuple<int, MagentoSearchCriteriaEntry>>>>)(this)).GetEnumerator();
        }

        /// <summary>
        /// Gets an enumerator used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator{T}"/> object.</returns>
        IEnumerator<KeyValuePair<int, IEnumerable<Tuple<int, MagentoSearchCriteriaEntry>>>> IEnumerable<KeyValuePair<int, IEnumerable<Tuple<int, MagentoSearchCriteriaEntry>>>>.GetEnumerator()
        {
            foreach (int i in SearchCriteria.Keys.OrderBy(key => key))
            {
                yield return new KeyValuePair<int, IEnumerable<Tuple<int, MagentoSearchCriteriaEntry>>>(i, SearchCriteria[i]);
            }
        }
    }
}
