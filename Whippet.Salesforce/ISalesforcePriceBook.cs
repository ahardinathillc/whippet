using System;
using NodaTime;
using Athi.Whippet.Data;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Represents a price book that contains the list of products that your org sells. 
    /// </summary>
    public interface ISalesforcePriceBook : IWhippetEntityDynamicImportMapper, IWhippetEntityExternalDataRowImportMapper, IWhippetEntity, ISalesforceObject
    {
        /// <summary>
        /// Text description of the price book.
        /// </summary>
        string Description
        { get; set; }

        /// <summary>
        /// Indicates whether the price book is active (<see langword="true"/>) or not (<see langword="false"/>). Inactive price books are hidden in many areas in the user interface. You can change this field’s value as often as necessary. Label is <strong>Active</strong>.
        /// </summary>
        bool IsActive
        { get; set; }

        /// <summary>
        /// Indicates whether the price book has been archived (<see langword="true"/>) or not (<see langword="false"/>). This field is read-only.
        /// </summary>
        bool IsArchived
        { get; set; }

        /// <summary>
        /// Indicates whether the price book has been moved to the Recycle Bin (<see langword="true"/>) or not (<see langword="false"/>). Label is <strong>Deleted></strong>.
        /// </summary>
        bool IsDeleted
        { get; set; }

        /// <summary>
        /// Indicates whether the price book is the standard price book for the org (<see langword="true"/>) or not (<see langword="false"/>). Every org has one standard price book; all other price books are custom price books.
        /// </summary>
        bool IsStandard
        { get; set; }

        /// <summary>
        /// Name of this object. This field is read-only for the standard price book. Label is <strong>Price Book Name</strong>.
        /// </summary>
        string Name
        { get; set; }

        /// <summary>
        /// The date and time when a Commerce price book is valid from. If this field is <see langword="null"/>, the price book is valid from the time it's created.
        /// </summary>
        Instant? ValidFrom
        { get; set; }

        /// <summary>
        /// The date and time when a Commerce price book is valid to. If this field is <see langword="null"/>, the price book is valid until it's deactivated.
        /// </summary>
        Instant? ValidTo
        { get; set; }
    }
}

