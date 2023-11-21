using System;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Store.Extensions
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
            Store s = null;

            if (store != null)
            {
                if (store is Store)
                {
                    s = (Store)(store);
                }
                else
                {
                    s = new Store();
                    s.Active = store.Active;
                    s.Code = store.Code;
                    s.Group = store.Group.ToStoreGroup();
                    s.ID = store.ID;
                    s.Name = store.Name;
                    s.RestEndpoint = store.RestEndpoint.ToMagentoRestEndpoint();
                    s.Server = store.Server.ToMagentoServer();
                    s.Website = store.Website.ToStoreWebsite();
                }
            }

            return s;
        }
    }
}
