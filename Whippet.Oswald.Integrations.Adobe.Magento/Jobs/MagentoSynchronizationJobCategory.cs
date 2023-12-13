using System;
using Athi.Whippet.Jobs;
using Athi.Whippet.Oswald.Jobs;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Jobs
{
    /// <summary>
    /// Represents the <see cref="IJobCategory"/> for Adobe Magento synchronization jobs. This class cannot be inherited.
    /// </summary>
    public sealed class MagentoSynchronizationJobCategory : JobCategoryWrapper, IJobCategory
    {
        private static readonly Guid _CategoryId = new Guid("050b6537-943d-46d5-8687-21308e0162c1");
        private static readonly string _EnglishName = "Adobe Magento";
        private static readonly string _EnglishDescription = "Provides synchronization jobs for Adobe Magento and between Magento and 3rd-party applications.";

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoSynchronizationJobCategory"/> class with no arguments.
        /// </summary>
        public MagentoSynchronizationJobCategory()
            : this(null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoSynchronizationJobCategory"/> class with the specified localized name and localized description.
        /// </summary>
        /// <param name="localizedName">Localized name or <see cref="String.Empty"/> or <see langword="null"/> to use the default English name.</param>
        /// <param name="localizedDescription">Localized description or <see cref="String.Empty"/> or <see langword="null"/> to use the default English description.</param>
        /// <param name="parent">Localized <see cref="OswaldSynchronizationJobCategory"/> object or <see langword="null"/> to use the default </param>
        public MagentoSynchronizationJobCategory(string localizedName, string localizedDescription, OswaldSynchronizationJobCategory parent = null)
            : base(_CategoryId, String.IsNullOrWhiteSpace(localizedName) ? _EnglishName : localizedName, String.IsNullOrWhiteSpace(localizedDescription) ? _EnglishDescription : localizedDescription, parent ?? new OswaldSynchronizationJobCategory())
        { }

    }
}
