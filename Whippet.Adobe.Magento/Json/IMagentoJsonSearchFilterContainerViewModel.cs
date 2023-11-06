using System;

namespace Athi.Whippet.Adobe.Magento.Json
{
    /// <summary>
    /// View model for containing groups of <see cref="IMagentoJsonSearchFilter"/> objects.
    /// </summary>
    public interface IMagentoJsonSearchFilterContainerViewModel
    {
        /// <summary>
        /// Gets the collection of <see cref="IMagentoJsonSearchFilter"/> objects that were used in a Magento API query. This property is read-only.
        /// </summary>
        IEnumerable<IMagentoJsonSearchFilter> Filters
        { get; }
    }
}

