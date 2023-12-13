using System;
using Athi.Whippet.Jobs;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Oswald.Jobs
{
    /// <summary>
    /// Represents the <see cref="IJobCategory"/> for Oswald synchronization jobs. This class cannot be inherited.
    /// </summary>
    public sealed class OswaldSynchronizationJobCategory : JobCategoryWrapper, IJobCategory
    {
        private static readonly Guid _CategoryId = new Guid("1509bb61-a297-42a1-b624-ed5ddd249e72");
        private static readonly string _EnglishName = "Synchronization";
        private static readonly string _EnglishDescription = "Jobs that synchronize the current application with 3rd-party outside applications or provides synchronization between one or more 3rd-party outside applications.";

        /// <summary>
        /// Initializes a new instance of the <see cref="OswaldSynchronizationJobCategory"/> class with no arguments.
        /// </summary>
        public OswaldSynchronizationJobCategory()
            : this(null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="OswaldSynchronizationJobCategory"/> class with the specified localized name and localized description.
        /// </summary>
        /// <param name="localizedName">Localized name or <see cref="String.Empty"/> or <see langword="null"/> to use the default English name.</param>
        /// <param name="localizedDescription">Localized description or <see cref="String.Empty"/> or <see langword="null"/> to use the default English description.</param>
        public OswaldSynchronizationJobCategory(string localizedName, string localizedDescription)
            : base(_CategoryId, String.IsNullOrWhiteSpace(localizedName) ? _EnglishName : localizedName, String.IsNullOrWhiteSpace(localizedDescription) ? _EnglishDescription : localizedDescription)
        { }
    }
}
