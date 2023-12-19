using System;
using Athi.Whippet.SuperDuper.Data;
using Athi.Whippet.Data;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy
{
    /// <summary>
    /// Represents a Super Duper Digital Library (SDDL) subscription period.
    /// </summary>
    public interface ILegacyDigitalLibrarySubscriptionPeriod : IWhippetEntity, ISuperDuperLegacyEntity, IEqualityComparer<ILegacyDigitalLibrarySubscriptionPeriod>
    {
        /// <summary>
        /// Gets or sets the period name.
        /// </summary>
        string Name
        { get; set; }
    }
}
