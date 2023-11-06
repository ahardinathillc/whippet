using System;
using Athi.Whippet.Data;

namespace Athi.Whippet.Applications.Setup
{
    /// <summary>
    /// Represents a logical grouping for <see cref="IWhippetSetting"/> objects.
    /// </summary>
    public interface IWhippetSettingGroup : IWhippetEntity, ICloneable, IWhippetCloneable, IEqualityComparer<IWhippetSettingGroup>
    {
        /// <summary>
        /// Gets or sets the <see cref="IWhippetApplication"/> that the <see cref="IWhippetSettingGroup"/> is for.
        /// </summary>
        IWhippetApplication Application
        { get; set; }

        /// <summary>
        /// Gets or sets the setting group ID.
        /// </summary>
        Guid SettingGroupID
        { get; set; }

        /// <summary>
        /// Gets or sets the group name (non-localized; English only).
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the setting group description (non-localized; English only).
        /// </summary>
        string Description
        { get; set; }
    }
}

