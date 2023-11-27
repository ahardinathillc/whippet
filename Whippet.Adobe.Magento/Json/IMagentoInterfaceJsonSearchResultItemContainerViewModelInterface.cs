using System;

namespace Athi.Whippet.Adobe.Magento.Json
{
    /// <summary>
    /// View model for items returned by the Magento search API.
    /// </summary>
    /// <typeparam name="T"><see cref="IExtensionInterface"/> object that is stored in the result set.</typeparam>
    public interface IMagentoInterfaceJsonSearchResultItemContainerViewModel<T> where T : IExtensionInterface, new()
    {
        /// <summary>
        /// Gets the items of type <typeparamref name="T"/> that have been deserialized from the JSON result. This property is read-only.
        /// </summary>
        IEnumerable<T> Items
        { get; }

        /// <summary>
        /// Gets or sets the search criteria used to perform the query.
        /// </summary>
        IMagentoJsonSearchCriteriaViewModel SearchCriteria
        { get; }

        /// <summary>
        /// Gets or sets the total number of items returned in the query.
        /// </summary>
        int TotalCount
        { get; set; }

        /// <summary>
        /// Gets the current total number of items stored in the view model. This value may be different than the value represented in <see cref="TotalCount"/> which is the overall total number of items that was returned in the initial query. This property is read-only.
        /// </summary>
        public int Count
        { get; }
    }
}
