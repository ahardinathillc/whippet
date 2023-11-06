using System;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.EAV.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IStoreGroup"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IStoreGroupExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IStoreGroup"/> object to a <see cref="StoreGroup"/> object.
        /// </summary>
        /// <param name="group"><see cref="IStoreGroup"/> object to convert.</param>
        /// <returns><see cref="StoreGroup"/> object.</returns>
        public static StoreGroup ToStoreGroup(this IStoreGroup group)
        {
            StoreGroup sw = null;

            if (group != null)
            {
                if (group is StoreGroup)
                {
                    sw = (StoreGroup)(group);
                }
                else
                {
                    sw = new StoreGroup();

                    sw.Code = group.Code;
                    sw.DefaultStoreID = group.DefaultStoreID;
                    sw.GroupID = group.GroupID;
                    sw.Name = group.Name;
                    sw.RootCategoryID = group.RootCategoryID;
                    sw.Website = group.Website.ToStoreWebsite();
                    sw.Server = group.Server.ToMagentoServer();
                }
            }

            return sw;
        }
    }
}

