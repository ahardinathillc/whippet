using System;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Downloads.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IDownloadableSample"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IDownloadableSampleExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IDownloadableSample"/> object to a <see cref="DownloadableSample"/> object.
        /// </summary>
        /// <param name="sample"><see cref="IDownloadableSample"/> object to convert.</param>
        /// <returns><see cref="DownloadableSample"/> object.</returns>
        public static DownloadableSample ToDownloadableSample(this IDownloadableSample sample)
        {
            DownloadableSample ds = null;

            if (sample is DownloadableSample)
            {
                ds = (DownloadableSample)(sample);
            }
            else
            {
                ds = new DownloadableSample();
                ds.Title = sample.Title;
                ds.SortOrder = sample.SortOrder;
                ds.Type = sample.Type;
                ds.File = sample.File;
                ds.FileContents = sample.FileContents;
                ds.URL = (sample.URL == null) ? null : new Uri(sample.URL.ToString(), UriKind.RelativeOrAbsolute);
                ds.RestEndpoint = (sample.RestEndpoint == null) ? null : sample.RestEndpoint.ToMagentoRestEndpoint();
                ds.Server = (sample.Server == null) ? null : sample.Server.ToMagentoServer();
            }

            return ds;
        }
    }
}
