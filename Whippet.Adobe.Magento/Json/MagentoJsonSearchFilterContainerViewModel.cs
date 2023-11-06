using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Json
{
    /// <summary>
    /// View model for containing groups of <see cref="MagentoJsonSearchFilter"/> objects. This class cannot be inherited.
    /// </summary>
    internal sealed class MagentoJsonSearchFilterContainerViewModel : IMagentoJsonSearchFilterContainerViewModel
    {
        /// <summary>
        /// Gets or sets the collection of <see cref="MagentoJsonSearchFilter"/> objects that were used in a Magento API query.
        /// </summary>
        [JsonProperty("filters")]
        public IEnumerable<MagentoJsonSearchFilter> Filters
        { get; set; }

        /// <summary>
        /// Gets the collection of <see cref="IMagentoJsonSearchFilter"/> objects that were used in a Magento API query. This property is read-only.
        /// </summary>
        IEnumerable<IMagentoJsonSearchFilter> IMagentoJsonSearchFilterContainerViewModel.Filters
        {
            get
            {
                return Filters;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoJsonSearchFilterContainerViewModel"/> class with no arguments.
        /// </summary>
        public MagentoJsonSearchFilterContainerViewModel()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoJsonSearchFilterContainerViewModel"/> class with the specified <see cref="IEnumerable{T}"/> collection of <see cref="MagentoJsonSearchFilter"/> objects.
        /// </summary>
        /// <param name="filters"><see cref="IEnumerable{T}"/> collection of <see cref="MagentoJsonSearchFilter"/> objects.</param>
        public MagentoJsonSearchFilterContainerViewModel(IEnumerable<MagentoJsonSearchFilter> filters)
            : this()
        {
            Filters = filters;
        }
    }
}

