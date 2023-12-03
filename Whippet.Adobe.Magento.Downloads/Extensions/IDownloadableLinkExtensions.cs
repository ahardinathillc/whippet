using System;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Downloads.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IDownloadableLink"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IDownloadableLinkExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IDownloadableLink"/> object to a <see cref="DownloadableLink"/> object.
        /// </summary>
        /// <param name="link"><see cref="IDownloadableLink"/> object to convert.</param>
        /// <returns><see cref="DownloadableLink"/> object.</returns>
        public static DownloadableLink ToDownloadableLink(this IDownloadableLink link)
        {
            DownloadableLink dl = null;

            if (link is DownloadableLink)
            {
                dl = (DownloadableLink)(link);
            }
            else
            {
                dl = new DownloadableLink();
                dl.Title = link.Title;
                dl.SortOrder = link.SortOrder;
                dl.Shareable = link.Shareable;
                dl.Price = link.Price;
                dl.PerUserLimit = link.PerUserLimit;
                dl.Type = link.Type;
                dl.File = link.File;
                dl.FileContents = link.FileContents;
                dl.LinkURL = (link.LinkURL == null) ? null : new Uri(link.LinkURL.ToString(), UriKind.RelativeOrAbsolute);
                dl.SampleType = link.SampleType;
                dl.SampleFile = link.SampleFile;
                dl.SampleFileContent = link.SampleFileContent;
                dl.FileURL = (link.FileURL == null) ? null : new Uri(link.FileURL.ToString(), UriKind.RelativeOrAbsolute);
                dl.RestEndpoint = (link.RestEndpoint == null) ? null : link.RestEndpoint.ToMagentoRestEndpoint();
                dl.Server = (link.Server == null) ? null : link.Server.ToMagentoServer();
            }

            return dl;
        }
    }
}
