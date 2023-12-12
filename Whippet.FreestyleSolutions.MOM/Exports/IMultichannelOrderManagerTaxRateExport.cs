using System;
using Athi.Whippet.Json;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Exports
{
    /// <summary>
    /// Provides a lightweight, data store independent implementation of a tax rate export record from a Multichannel Order Manager server.
    /// </summary>
    public interface IMultichannelOrderManagerTaxRateExport : IEqualityComparer<IMultichannelOrderManagerTaxRateExport>
    {
        /// <summary>
        /// Gets or sets the tax rate.
        /// </summary>
        decimal TaxRate
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IMultichannelOrderManagerPostalCode"/> that the tax rate applies to.
        /// </summary>
        IMultichannelOrderManagerPostalCode PostalCode
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IMultichannelOrderManagerStateProvince"/> that the tax rate applies to.
        /// </summary>
        IMultichannelOrderManagerStateProvince StateProvince
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IMultichannelOrderManagerCountry"/> that the tax rate applies to.
        /// </summary>
        IMultichannelOrderManagerCountry Country
        { get; set; }

        /// <summary>
        /// Specifies whether shipping should be taxed.
        /// </summary>
        bool TaxShipping
        { get; set; }

        /// <summary>
        /// Specifies whether non-tangible products (such as services, including subscription-based software) should be taxed.
        /// </summary>
        bool TaxServices
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IMultichannelOrderManagerServer"/> that the export was generated from.
        /// </summary>
        IMultichannelOrderManagerServer Server
        { get; set; }
    }
}
