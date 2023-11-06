using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Json
{
    /// <summary>
    /// Represents the status of a bulk operation in Magento. This class cannot be inherited.
    /// </summary>
    public sealed class MagentoBulkOperationStatusViewModel
    {
        private List<MagentoBulkOperationStatusItemViewModel> _items;

        /// <summary>
        /// Gets or sets the bulk operation items which contain information about each item that was processed.
        /// </summary>
        [JsonProperty("items")]
        public List<MagentoBulkOperationStatusItemViewModel> Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new List<MagentoBulkOperationStatusItemViewModel>();
                }

                return _items;
            }
            set
            {
                _items = value;
            }
        }

        /// <summary>
        /// Gets or sets the search criteria that was used to access the bulk results.
        /// </summary>
        [JsonProperty("search_criteria")]
        internal MagentoJsonSearchCriteriaViewModel SearchCriteria
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of items returned in the query.
        /// </summary>
        [JsonProperty("total_count")]
        public int TotalCount
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoBulkOperationStatusViewModel"/> class with no arguments.
        /// </summary>
        public MagentoBulkOperationStatusViewModel()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoBulkOperationStatusViewModel"/> class with the specified parameters.
        /// </summary>
        /// <param name="items">Bulk operation items which contain information about each item that was processed.</param>
        /// <param name="totalCount">Total number of items returned in the query.</param>
        public MagentoBulkOperationStatusViewModel(IEnumerable<MagentoBulkOperationStatusItemViewModel> items, int totalCount)
            : this()
        {
            if (items != null && items.Any())
            {
                Items = new List<MagentoBulkOperationStatusItemViewModel>(items);
            }

            TotalCount = totalCount;
        }
    }
}

