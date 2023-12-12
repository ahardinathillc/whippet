using System;
using Athi.Whippet.Data;
using Athi.Whippet.SuperDuper.Data;

namespace Athi.Whippet.SuperDuper.Legacy
{
    /// <summary>
    /// Represents a customer or user's occupation.
    /// </summary>
    public interface IOccupation : ISuperDuperLegacyEntity, IWhippetEntity, IEqualityComparer<IOccupation>
    {
        /// <summary>
        /// Gets or sets the occupation title.
        /// </summary>
        string Title
        { get; set; }
        
        /// <summary>
        /// Specifies whether the occupation is to be displayed.
        /// </summary>
        bool Display
        { get; set; }
        
        /// <summary>
        /// Gets or sets the display order of the occupation.
        /// </summary>
        int DisplayOrder
        { get; set; }
        
        /// <summary>
        /// Gets or sets the occupation categorization type.
        /// </summary>
        string Categorization
        { get; set; }
    }
}
