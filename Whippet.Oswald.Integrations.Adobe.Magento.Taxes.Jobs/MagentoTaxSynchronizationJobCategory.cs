using System;
using Athi.Whippet.Jobs;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Jobs;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs
{
    /// <summary>
    /// Represents the <see cref="IJobCategory"/> for Adobe Magento tax synchronization jobs. This class cannot be inherited.
    /// </summary>
    public class MagentoTaxSynchronizationJobCategory : JobCategoryWrapper, IJobCategory
    {
        private static readonly Guid _CategoryId = new Guid("83f81b81-3b0c-4046-a63e-27dfda711265");
        private static readonly string _EnglishName = "Taxes and Tax Classes";
        private static readonly string _EnglishDescription = "Provides synchronization jobs Adobe Magento tax items.";

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationJobCategory"/> class with no arguments.
        /// </summary>
        public MagentoTaxSynchronizationJobCategory()
            : this(null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationJobCategory"/> class with the specified localized name and localized description.
        /// </summary>
        /// <param name="localizedName">Localized name or <see cref="String.Empty"/> or <see langword="null"/> to use the default English name.</param>
        /// <param name="localizedDescription">Localized description or <see cref="String.Empty"/> or <see langword="null"/> to use the default English description.</param>
        /// <param name="parent">Localized <see cref="MagentoSynchronizationJobCategory"/> object or <see langword="null"/> to use the default </param>
        public MagentoTaxSynchronizationJobCategory(string localizedName, string localizedDescription, MagentoSynchronizationJobCategory parent = null)
            : base(_CategoryId, String.IsNullOrWhiteSpace(localizedName) ? _EnglishName : localizedName, String.IsNullOrWhiteSpace(localizedDescription) ? _EnglishDescription : localizedDescription, parent ?? new MagentoSynchronizationJobCategory())
        { }

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be inherited.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public override string ToJson<T>()
        {
            return this.SerializeJson(this);
        }
    }
}
