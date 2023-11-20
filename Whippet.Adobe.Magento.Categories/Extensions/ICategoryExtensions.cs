using System;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Categories.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ICategory"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ICategoryExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ICategory"/> object to a <see cref="Category"/> object.
        /// </summary>
        /// <param name="category"><see cref="ICategory"/> object to convert.</param>
        /// <returns><see cref="Category"/> object.</returns>
        public static Category ToCategory(this ICategory category)
        {
            Category cat = null;

            if (category is Category)
            {
                cat = (Category)(category);
            }
            else if (category != null)
            {
                cat = new Category();
                cat.Parent = (category.Parent == null) ? null : category.Parent.ToCategory();
                cat.IncludeInMenu = category.IncludeInMenu;
                cat.SortByValues = category.SortByValues;
                cat.Server = (category.Server == null) ? null : category.Server.ToMagentoServer();
                cat.ID = category.ID;
                cat.RestEndpoint = (category.RestEndpoint == null) ? null : category.RestEndpoint.ToMagentoRestEndpoint();
            }

            return cat;
        }
    }
}
