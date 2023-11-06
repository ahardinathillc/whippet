using System;
using Athi.Whippet.Data;

namespace Athi.Whippet.Jobs
{
    /// <summary>
    /// Represents a logical categorization for classes that implement <see cref="IJob"/>.
    /// </summary>
    public interface IJobCategory : IWhippetEntity, IEqualityComparer<IJobCategory>
    {
        /// <summary>
        /// Gets or sets the category name.
        /// </summary>
        string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the category description.
        /// </summary>
        string Description
        { get; set; }

        /// <summary>
        /// Gets the parent <see cref="IJobCategory"/> (if any). This property is read-only.
        /// </summary>
        IJobCategory Parent
        { get; }

        /// <summary>
        /// Indicates if the current <see cref="IJobCategory"/> is a root category. This property is read-only.
        /// </summary>
        bool IsRoot
        { get; }
    }
}

