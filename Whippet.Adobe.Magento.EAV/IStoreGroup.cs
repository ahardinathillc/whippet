using System;
using System.ComponentModel;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.EAV
{
    /// <summary>
    /// Represents a logical grouping for an <see cref="IStore"/>.
    /// </summary>
    public interface IStoreGroup : IMagentoEntity, IEqualityComparer<IStoreGroup>, ICloneable, IWhippetCloneable
    {
        /// <summary>
        /// Gets or sets the unique website ID.
        /// </summary>
        ushort GroupID
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IStoreWebsite"/> that is assigned to the group.
        /// </summary>
        IStoreWebsite Website
        { get; set; }

        /// <summary>
        /// Gets or sets the group name.
        /// </summary>
        string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the group code.
        /// </summary>
        string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the root category that the group is a child of. Root categories are stored in Magento configuration.
        /// </summary>
        uint RootCategoryID
        { get; set; }

        /// <summary>
        /// This property is unused.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is not used and is only retained for legacy purposes.", false)]
        ushort DefaultStoreID
        { get; set; }
    }
}
