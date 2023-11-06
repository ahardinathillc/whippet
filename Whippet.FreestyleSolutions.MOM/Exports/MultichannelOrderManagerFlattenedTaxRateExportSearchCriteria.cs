using System;
namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Exports
{
    /// <summary>
    /// Provides a search criteria used for querying <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> objects.
    /// </summary>
    public struct MultichannelOrderManagerFlattenedTaxRateExportSearchCriteria
    {
        /// <summary>
        /// Gets or sets the <see cref="MultichannelOrderManagerPostalCode"/> to query by.
        /// </summary>
        public MultichannelOrderManagerPostalCode PostalCode
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="MultichannelOrderManagerStateProvince"/> to query by.
        /// </summary>
        public MultichannelOrderManagerStateProvince StateProvince
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="MultichannelOrderManagerCountry"/> to query by.
        /// </summary>
        public MultichannelOrderManagerCountry Country
        { get; set; }

        /// <summary>
        /// Filters results based on whether shipping is or is not taxed.
        /// </summary>
        public bool? TaxShipping
        { get; set; }

        /// <summary>
        /// Filters results based on whether services are or are not taxed.
        /// </summary>
        public bool? TaxServices
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerFlattenedTaxRateExportSearchCriteria"/> structure with no arguments.
        /// </summary>
        static MultichannelOrderManagerFlattenedTaxRateExportSearchCriteria()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerFlattenedTaxRateExportSearchCriteria"/> structure with the specified parameters.
        /// </summary>
        /// <param name="postalCode"><see cref="MultichannelOrderManagerPostalCode"/> to query by.</param>
        /// <param name="stateProvince"></param>
        /// <param name="country"></param>
        /// <param name="taxShipping"></param>
        /// <param name="taxServices"></param>
        public MultichannelOrderManagerFlattenedTaxRateExportSearchCriteria(MultichannelOrderManagerPostalCode postalCode, MultichannelOrderManagerStateProvince stateProvince, MultichannelOrderManagerCountry country, bool? taxShipping, bool? taxServices)
            : this()
        {
            PostalCode = postalCode;
            StateProvince = stateProvince;
            Country = country;
            TaxShipping = taxShipping;
            TaxServices = taxServices;
        }
    }
}

