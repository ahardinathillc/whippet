using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Json
{
    /// <summary>
    /// View model for Magento search result search criteria JSON objects. This class cannot be inherited.
    /// </summary>
    internal sealed class MagentoJsonSearchCriteriaViewModel : IMagentoJsonSearchCriteriaViewModel
    {
        /// <summary>
        /// Gets or sets the collection of <see cref="MagentoJsonSearchFilterContainerViewModel"/> objects that comprise the search criteria.
        /// </summary>
        [JsonProperty("filter_groups")]
        public IEnumerable<MagentoJsonSearchFilterContainerViewModel> FilterGroups
        { get; set; }

        /// <summary>
        /// Gets the collection of <see cref="IMagentoJsonSearchFilterContainerViewModel"/> objects that comprise the search criteria. This property is read-only.
        /// </summary>
        IEnumerable<IMagentoJsonSearchFilterContainerViewModel> IMagentoJsonSearchCriteriaViewModel.FilterGroups
        {
            get
            {
                return FilterGroups;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoJsonSearchCriteriaViewModel"/> class with no arguments.
        /// </summary>
        public MagentoJsonSearchCriteriaViewModel()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoJsonSearchCriteriaViewModel"/> class with the specified <see cref="MagentoJsonSearchFilterContainerViewModel"/> objects.
        /// </summary>
        /// <param name="filterGroups"><see cref="MagentoJsonSearchFilterContainerViewModel"/> object.</param>
        public MagentoJsonSearchCriteriaViewModel(IEnumerable<MagentoJsonSearchFilterContainerViewModel> filterGroups)
            : this()
        {
            FilterGroups = filterGroups;
        }
    }
}

