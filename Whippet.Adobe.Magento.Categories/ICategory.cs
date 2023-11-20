using System;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Categories
{
    /// <summary>
    /// Provides support for organizing products in a Magento store.
    /// </summary>
    public interface ICategory : IMagentoEntity, IEqualityComparer<ICategory>, IWhippetActiveEntity, IMagentoRestEntity, IMagentoAuditableEntity
    {
        /// <summary>
        /// Gets or sets the parent <see cref="ICategory"/>.
        /// </summary>
        ICategory Parent
        { get; set; }

        /// <summary>
        /// Gets or sets the category name.
        /// </summary>
        string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the category position.
        /// </summary>
        int Position
        { get; set; }

        /// <summary>
        /// Gets or sets the category level.
        /// </summary>
        int Level
        { get; set; }

        /// <summary>
        /// Gets a collection of all child <see cref="ICategory"/> objects that are descendants of the current instance. This property is read-only.
        /// </summary>
        CategoryCollection Children
        { get; }

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
