using System;
using System.Collections;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Json
{
    /// <summary>
    /// Provides a JSON container for search results from the Magento API. This class cannot be inherited.
    /// </summary>
    /// <typeparam name="T"><see cref="IExtensionInterface"/> object type that is contained within the results.</typeparam>
    public sealed class MagentoInterfaceJsonSearchResultItemContainer<T> : IEnumerable<T>, IReadOnlyList<T> where T : IExtensionInterface, new()
    {
        /// <summary>
        /// Gets the item located at the specified index. This property is read-only.
        /// </summary>
        /// <param name="index">Index of the item to retrieve.</param>
        /// <returns>Object of type <typeparamref name="T"/> located at the specified index.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= SearchResult.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                else
                {
                    return SearchResult.Items.ElementAt(index);
                }
            }
        }

        /// <summary>
        /// Gets the <see cref="IMagentoInterfaceJsonSearchResultItemContainerViewModel{T}"/> object that contains the serialized JSON search result. This property is read-only.
        /// </summary>
        public IMagentoInterfaceJsonSearchResultItemContainerViewModel<T> SearchResult
        { get; private set; }

        /// <summary>
        /// Gets the total number of items in the collection. This property is read-only.
        /// </summary>
        public int Count
        {
            get
            {
                return SearchResult.Count;
            }
        }

        /// <summary>
        /// Gets the total number of records returned by the search criteria. This property is read-only.
        /// </summary>
        public int TotalCount
        {
            get
            {
                return SearchResult.TotalCount;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoInterfaceJsonSearchResultItemContainer{T}"/> class with no arguments.
        /// </summary>
        private MagentoInterfaceJsonSearchResultItemContainer()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoInterfaceJsonSearchResultItemContainer{T}"/> class with the specified raw JSON response.
        /// </summary>
        /// <param name="rawJsonResponse">Raw JSON returned by the Magento API.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MagentoInterfaceJsonSearchResultItemContainer(string rawJsonResponse)
            : this()
        {
            if (String.IsNullOrWhiteSpace(rawJsonResponse))
            {
                throw new ArgumentNullException(nameof(rawJsonResponse));
            }
            else
            {
                SearchResult = JsonConvert.DeserializeObject<MagentoInterfaceJsonSearchResultItemContainerViewModel<T>>(rawJsonResponse);
            }
        }

        /// <summary>
        /// Gets the enumerator used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator"/> object used to iterate over each item in the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)(this)).GetEnumerator();
        }

        /// <summary>
        /// Gets the enumerator used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator{T}"/> object used to iterate over each item in the collection.</returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return SearchResult.Items.GetEnumerator();
        }
    }
}
