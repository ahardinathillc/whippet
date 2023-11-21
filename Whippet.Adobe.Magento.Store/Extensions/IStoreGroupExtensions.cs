using System;
using Athi.Whippet.Adobe.Magento.Categories.Extensions;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Store.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IStoreGroup"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IStoreGroupExtensions
    {
        public static StoreGroup ToStoreGroup(this IStoreGroup group)
        {
            StoreGroup sg = null;

            if (group != null)
            {
                if (group is StoreGroup)
                {
                    sg = (StoreGroup)(group);
                }
                else
                {
                    sg = new StoreGroup();

                    sg.Code = group.Code;
                    sg.DefaultStoreID = group.DefaultStoreID;
                    sg.ID = group.ID;
                    sg.Name = group.Name;
                    sg.RestEndpoint = group.RestEndpoint.ToMagentoRestEndpoint();
                    sg.Website = group.Website.ToStoreWebsite();
                    sg.RootCategory = group.RootCategory.ToCategory();
                    sg.Server = group.Server.ToMagentoServer();
                }
            }

            return sg;
        }
    }
}
