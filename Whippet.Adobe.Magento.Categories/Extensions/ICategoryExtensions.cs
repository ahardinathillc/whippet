using System;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Collections.Extensions;

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
                
                if ((category.Children != null) && (category.Children.Count > 0))
                {
                    cat.Children = category.Children;
                }

                if ((category.CustomAttributes != null) && (category.CustomAttributes.Count > 0))
                {
                    cat.CustomAttributes = category.CustomAttributes;
                }

                cat.Active = category.Active;
                
                cat.ID = category.ID;
                cat.IncludeInMenu = category.IncludeInMenu;

                cat.Level = category.Level;

                cat.Name = category.Name;

                cat.Parent = (category.Parent == null) ? null : category.Parent.ToCategory();
                cat.Path = category.Path;
                cat.Position = category.Position;

                cat.RestEndpoint = (category.RestEndpoint == null) ? null : category.RestEndpoint.ToMagentoRestEndpoint();

                cat.SortByValues = category.SortByValues;
                cat.Server = (category.Server == null) ? null : category.Server.ToMagentoServer();

                cat.CreatedTimestamp = category.CreatedTimestamp;
                cat.UpdatedTimestamp = category.UpdatedTimestamp;
            }

            return cat;
        }
    }
}
