using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento
{
    /// <summary>
    /// Interface that provides information about a Magento item's downloadable content.
    /// </summary>
    public class DownloadableOptionInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the downloadable links for the item.
        /// </summary>
        [JsonProperty("downloadable_links")]
        public int[] DownloadableLinks
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadableOptionInterface"/> class with no arguments.
        /// </summary>
        public DownloadableOptionInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadableOptionInterface"/> class with the specified collection of downloadable link IDs.
        /// </summary>
        /// <param name="downloadableLinks">Array of downloadable link IDs.</param>
        public DownloadableOptionInterface(int[] downloadableLinks)
            : this()
        {
            DownloadableLinks = downloadableLinks;
        }
    }
}
