using System;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Store.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IStoreWebsite"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IStoreWebsiteExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IStoreWebsite"/> object to a <see cref="StoreWebsite"/> object.
        /// </summary>
        /// <param name="website"><see cref="IStoreWebsite"/> object to convert.</param>
        /// <returns><see cref="StoreWebsite"/> object.</returns>
        public static StoreWebsite ToStoreWebsite(this IStoreWebsite website)
        {
            StoreWebsite sw = null;

            if (website != null)
            {
                if (website is StoreWebsite)
                {
                    sw = (StoreWebsite)(website);
                }
                else
                {
                    sw = new StoreWebsite();
                    sw.Code = website.Code;
                    sw.DefaultGroupID = website.DefaultGroupID;
                    sw.ID = website.ID;
                    sw.Name = website.Name;
                    sw.RestEndpoint = website.RestEndpoint.ToMagentoRestEndpoint();
                    sw.Server = website.Server.ToMagentoServer();
                }
            }

            return sw;
        }
    }
}
