using System;
using Newtonsoft.Json;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Categories.Extensions;

namespace Athi.Whippet.Adobe.Magento.Categories
{
    /// <summary>
    /// Provides support for organizing products in a Magento store.
    /// </summary>
    public class Category : MagentoRestEntity<CategoryInterface>, IMagentoEntity, ICategory, IEqualityComparer<ICategory>, IWhippetActiveEntity
    {
        /// <summary>
        /// Gets or sets the parent <see cref="Category"/> (if any).
        /// </summary>
        public virtual Category Parent
        { get; set; }

        /// <summary>
        /// Gets or sets the parent <see cref="ICategory"/>.
        /// </summary>
        ICategory ICategory.Parent
        {
            get
            {
                return Parent;
            }
            set
            {
                Parent = value.ToCategory();
            }
        }

        /// <summary>
        /// Gets or sets the category name.
        /// </summary>
        public virtual string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the category position.
        /// </summary>
        public virtual int Position
        { get; set; }

        /// <summary>
        /// Gets or sets the category level.
        /// </summary>
        public virtual int Level
        { get; set; }

        public IEnumerable<Category> Children
        { get; set; }
        
        /// <summary>
        /// Gets or sets the child <see cref="ICategory"/> objects in respect to the current instance. 
        /// </summary>
        IEnumerable<ICategory> ICategory.Children
        { get; set; }

        /// <summary>
        /// Gets or sets the full path of the category.
        /// </summary>
        string Path
        { get; set; }

        /// <summary>
        /// Gets or sets the available values that the <see cref="ICategory"/> can be sorted by.
        /// </summary>
        public IEnumerable<string> SortByValues
        { get; set; }

        /// <summary>
        /// Specifies whether the category should be included in the menu.
        /// </summary>
        public bool IncludeInMenu
        { get; set; } 
    }
}
