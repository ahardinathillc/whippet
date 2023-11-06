using System;
using System.ComponentModel;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.EAV
{
    /// <summary>
    /// Represents a website that is associated with an <see cref="IStore"/>.
    /// </summary>
    public interface IStoreWebsite : IMagentoEntity, IEqualityComparer<IStoreWebsite>, ICloneable, IWhippetCloneable
    {
        /// <summary>
        /// Gets or sets the unique website ID.
        /// </summary>
        ushort WebsiteID
        { get; set; }

        /// <summary>
        /// Gets or sets the website code that identifies it in Magento.
        /// </summary>
        string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the website name.
        /// </summary>
        string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the sort order of the website.
        /// </summary>
        ushort SortOrder
        { get; set; }

        /// <summary>
        /// This property is unused.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is not used and is only retained for legacy purposes.", false)]
        ushort DefaultGroupID
        { get; set; }

        /// <summary>
        /// Indicates whether the website is the default site.
        /// </summary>
        bool IsDefault
        { get; set; }
    }
}

