using System;
using Athi.Whippet.SuperDuper.Data;
using Athi.Whippet.Data;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy
{
    /// <summary>
    /// Represents a Super Duper Digital Library (SDDL) subscription access level.
    /// </summary>
    public interface ILegacyDigitalLibrarySubscriptionLevel : IWhippetEntity, ISuperDuperLegacyEntity, IEqualityComparer<ILegacyDigitalLibrarySubscriptionLevel>
    {
        /// <summary>
        /// Gets or sets the subscription level name.
        /// </summary>
        string Name
        { get; set; }
    }
}
