using System;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.EAV.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IStore"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IStoreExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IStore"/> object to a <see cref="Store"/> object.
        /// </summary>
        /// <param name="store"><see cref="IStore"/> object to convert.</param>
        /// <returns><see cref="Store"/> object.</returns>
        public static Store ToStore(this IStore store)
        {
            Store sw = null;

            if (store != null)
            {
                if (store is Store)
                {
                    sw = (Store)(store);
                }
                else
                {
                    sw = new Store();

                    sw.Code = store.Code;
                    sw.Group = store.Group.ToStoreGroup();
                    sw.Name = store.Name;
                    sw.Server = store.Server.ToMagentoServer();
                    sw.SortOrder = store.SortOrder;
                    sw.StoreID = store.StoreID;
                    sw.Website = store.Website.ToStoreWebsite();
                }
            }

            return sw;
        }
    }
}

