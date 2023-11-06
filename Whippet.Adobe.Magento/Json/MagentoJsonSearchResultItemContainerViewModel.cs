using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Json
{
    /// <summary>
    /// View model for items returned by the Magento search API. This class cannot be inherited.
    /// </summary>
    /// <typeparam name="T"><see cref="IMagentoEntity"/> object that is stored in the result set.</typeparam>
    internal sealed class MagentoJsonSearchResultItemContainerViewModel<T> : IMagentoJsonSearchResultItemContainerViewModel<T> where T : IMagentoEntity, new()
    {
        private IEnumerable<T> _items;

        /// <summary>
        /// Gets or sets the items of type <typeparamref name="T"/> that have been deserialized from the JSON result.
        /// </summary>
        [JsonProperty("items")]
        public IEnumerable<T> Items
        {
            get
            {
                return _items;
            }
            set
            {
                int itemCount = 0;

                _items = value;

                if (_items != null)
                {
                    _items.TryGetNonEnumeratedCount(out itemCount);
                }

                Count = itemCount;
            }
        }

        /// <summary>
        /// Gets or sets the search criteria used to perform the query.
        /// </summary>
        [JsonProperty("search_criteria")]
        public MagentoJsonSearchCriteriaViewModel SearchCriteria
        { get; set; }

        /// <summary>
        /// Gets the search criteria used to perform the query. This property is read-only.
        /// </summary>
        IMagentoJsonSearchCriteriaViewModel IMagentoJsonSearchResultItemContainerViewModel<T>.SearchCriteria
        {
            get
            {
                return SearchCriteria;
            }
        }

        /// <summary>
        /// Gets or sets the total number of items returned in the query.
        /// </summary>
        [JsonProperty("total_count")]
        public int TotalCount
        { get; set; }

        /// <summary>
        /// Gets the current total number of items stored in the view model. This value may be different than the value represented in <see cref="TotalCount"/> which is the overall total number of items that was returned in the initial query. This property is read-only.
        /// </summary>
        public int Count
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoJsonSearchResultItemContainerViewModel{T}"/> class with no arguments.
        /// </summary>
        public MagentoJsonSearchResultItemContainerViewModel()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoJsonSearchResultItemContainerViewModel{T}"/> class with the specified parameters.
        /// </summary>
        /// <param name="items">The items of type <typeparamref name="T"/> that have been deserialized from the JSON result.</param>
        /// <param name="searchCriteria">Search criteria used to perform the query.</param>
        /// <param name="totalCount">Total number of items returned in the query.</param>
        public MagentoJsonSearchResultItemContainerViewModel(IEnumerable<T> items, MagentoJsonSearchCriteriaViewModel searchCriteria, int totalCount)
            : this()
        {
            Items = items;
            SearchCriteria = searchCriteria;
            TotalCount = totalCount;
        }
    }
}

