using System;

namespace Athi.Whippet.Adobe.Magento.Json
{
    /// <summary>
    /// View model for Magento search result search criteria JSON objects.
    /// </summary>
    public interface IMagentoJsonSearchCriteriaViewModel
    {
        /// <summary>
        /// Gets the collection of <see cref="IMagentoJsonSearchFilterContainerViewModel"/> objects that comprise the search criteria. This property is read-only.
        /// </summary>
        IEnumerable<IMagentoJsonSearchFilterContainerViewModel> FilterGroups
        { get; }
    }
}

