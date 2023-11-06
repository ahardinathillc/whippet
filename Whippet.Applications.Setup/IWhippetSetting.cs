using System;
using NodaTime;
using Athi.Whippet.Applications.Setup.Extensions;
using Athi.Whippet.Data;

namespace Athi.Whippet.Applications.Setup
{
    /// <summary>
    /// Represents an individual application setting for an <see cref="IWhippetApplication"/> instance.
    /// </summary>
    public interface IWhippetSetting : IWhippetEntity, IEqualityComparer<IWhippetSetting>, ICloneable, IWhippetCloneable
    {
        /// <summary>
        /// Gets or sets the parent <see cref="IWhippetSettingGroup"/> that the setting belongs to.
        /// </summary>
        IWhippetSettingGroup Group
        { get; set; }

        /// <summary>
        /// Gets or sets the setting ID.
        /// </summary>
        Guid SettingID
        { get; set; }

        /// <summary>
        /// Gets or sets the group name (non-localized; English only).
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the setting description (non-localized; English only).
        /// </summary>
        string Description
        { get; set; }

        /// <summary>
        /// Gets or sets the value stored as a byte array.
        /// </summary>
        byte[] ByteValue
        { get; set; }

        /// <summary>
        /// Gets or sets the value stored as an <see cref="Instant"/> value.
        /// </summary>
        Instant? InstantValue
        { get; set; }

        /// <summary>
        /// Gets or sets the value stored as an <see cref="Int32"/> value.
        /// </summary>
        int? IntegerValue
        { get; set; }

        /// <summary>
        /// Gets or sets the value stored as a <see cref="Decimal"/> value.
        /// </summary>
        decimal? DecimalValue
        { get; set; }

        /// <summary>
        /// Gets or sets the value stored as a <see cref="Double"/> value.
        /// </summary>
        double? DoubleValue
        { get; set; }

        /// <summary>
        /// Gets or sets the value stored as a <see cref="Boolean"/> value.
        /// </summary>
        bool? BoolValue
        { get; set; }

        /// <summary>
        /// Gets or sets the value stored as a <see cref="String"/>  value.
        /// </summary>
        string StringValue
        { get; set; }

        /// <summary>
        /// Gets or sets the value stored as a <see cref="Guid"/> value.
        /// </summary>
        Guid? GuidValue
        { get; set; }
    }
}
