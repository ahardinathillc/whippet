using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Customer
{
    /// <summary>
    /// Interface that provides extra information about a Magento customer group.
    /// </summary>
    public class CustomerGroupExtensionInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets a list of excluded website IDs.
        /// </summary>
        [JsonProperty("exclude_website_ids")]
        public int[] ExcludedWebsiteIDs
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerGroupExtensionInterface"/> class with no arguments.
        /// </summary>
        public CustomerGroupExtensionInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerGroupExtensionInterface"/> class with the specified <see cref="IEnumerable{T}"/> collection of website IDs.
        /// </summary>
        /// <param name="excludeWebsiteIds"><see cref="IEnumerable{T}"/> collection of website IDs that are excluded.</param>
        public CustomerGroupExtensionInterface(IEnumerable<int> excludeWebsiteIds)
            : this()
        {
            ExcludedWebsiteIDs = (excludeWebsiteIds == null) ? null : excludeWebsiteIds.ToArray();
        }
    }
}
