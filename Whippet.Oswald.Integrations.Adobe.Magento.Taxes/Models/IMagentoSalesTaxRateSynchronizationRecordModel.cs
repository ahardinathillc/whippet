using System;
using Athi.Whippet.Adobe.Magento.Taxes;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Models
{
    /// <summary>
    /// Represents a data transfer object (DTO) for synchronizing Magento tax rates.
    /// </summary>
    public interface IMagentoSalesTaxRateSynchronizationRecordModel : ICloneable, IWhippetCloneable
    {
        /// <summary>
        /// Gets the unique ID of the target Magento server. This property is read-only.
        /// </summary>
        Guid MagentoServerID
        { get; }

        /// <summary>
        /// If <see langword="true"/>, the rate will be added to (or updated in) Magento.
        /// </summary>
        bool CreateOrUpdateRate
        { get; set; }

        /// <summary>
        /// If <see langword="true"/>, the rate will be removed from Magento.
        /// </summary>
        bool DeleteRate
        { get; set; }

        /// <summary>
        /// If <see langword="true"/>, the rate will not be added to Magento.
        /// </summary>
        public bool SkipRate
        { get; set; }

        /// <summary>
        /// Gets the <see cref="ITaxRate"/> to create or remove. This property is read-only.
        /// </summary>
        ITaxRate Rate
        { get; }
    }
}

