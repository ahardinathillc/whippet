using System;
using Newtonsoft.Json;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Categories
{
    /// <summary>
    /// Provides support for organizing products in a Magento store.
    /// </summary>
    public class Category : MagentoRestEntity<CategoryInterface>, IMagentoEntity, ICategory, IEqualityComparer<ICategory>, IWhippetActiveEntity
    {
        /// <summary>
        /// Gets or sets the parent <see cref="Category"/>.
        /// </summary>
        public Category Parent
        { get; set; }

        /// <summary>
        /// Gets or sets the category name.
        /// </summary>
        public string Name
        { get; set; }
        
        /// <summary>
        /// Specifies whether the <see cref="Category"/> is currently active.
        /// </summary>
        public bool Active
        { get; set; }

        /// <summary>
        /// Gets or sets the category's display position.
        /// </summary>
        public int Position
        { get; set; }

        public 
    }
}
