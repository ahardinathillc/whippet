using System;
using Athi.Whippet.Json;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Directory;

namespace Athi.Whippet.Adobe.Magento.Taxes
{
    /// <summary>
    /// Tax rate that is applied to a region in Magento.
    /// </summary>
    public interface ITaxRate : IMagentoEntity, IEqualityComparer<ITaxRate>, ICloneable, IWhippetCloneable, IJsonObject
    {
        /// <summary>
        /// Gets or sets the unique ID of the <see cref="ITaxRate"/>.
        /// </summary>
        new int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICountry"/> that the <see cref="ITaxRate"/> applies to.
        /// </summary>
        ICountry Country
        { get; set; }

        /// <summary>
        /// Gets or sets the ISO-2 country identifier that the <see cref="ITaxRate"/> applies to.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string CountryID
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IRegion"/> that the <see cref="ITaxRate"/> applies to.
        /// </summary>
        IRegion Region
        { get; set; }

        /// <summary>
        /// Gets or sets the ID of the <see cref="IRegion"/> that the <see cref="ITaxRate"/> applies to.
        /// </summary>
        int RegionID
        { get; set; }

        /// <summary>
        /// Gets or sets the postal code that the <see cref="ITaxRate"/> applies to.
        /// </summary>
        string PostalCode
        { get; set; }

        /// <summary>
        /// Numeric flag that specifies whether the <see cref="PostalCode"/> value is a ZIP code and, if so, is represented as a range in <see cref="ZipFrom"/> and <see cref="ZipTo"/>.
        /// </summary>
        int ZipIsRange
        { get; set; }

        /// <summary>
        /// Lower-bound ZIP code value that the <see cref="ITaxRate"/> applies to.
        /// </summary>
        int ZipFrom
        { get; set; }

        /// <summary>
        /// Upper-bound ZIP code value that the <see cref="ITaxRate"/> applies to.
        /// </summary>
        int ZipTo
        { get; set; }

        /// <summary>
        /// Gets or sets the numeric tax rate value.
        /// </summary>
        decimal Rate
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ITaxRate"/> code.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the available <see cref="ITaxRateTitle"/> associations for the <see cref="ITaxRate"/>.
        /// </summary>
        IEnumerable<ITaxRateTitle> Titles
        { get; set; }

        /// <summary>
        /// Returns the current instance as a JSON object in a <see cref="String"/> that is defined by the API documentation in Magento. This is typically used for POST and PUT requests as the default serializer suffices in GET requests.
        /// </summary>
        /// <param name="openSource">If <see langword="true"/>, will generate the JSON necessary for Magento Open Source.</param>
        /// <returns><see cref="String"/> containing the JSON object representation of the current instance.</returns>
        /// <remarks>See <a href="https://magento.stackexchange.com/questions/3480/how-to-programatically-create-tax-rates">How to Programatically Create Tax Rates</a> as the Adobe documentation is incorrect.</remarks>
        string ToMagentoJsonString(bool openSource);
        
        /// <summary>
        /// Builds the <see cref="Code"/> value based on the specified parameters.
        /// </summary>
        /// <param name="countryIso2">ISO-2 abbreviation of the country.</param>
        /// <param name="stateProvinceAbbreviation">Two-letter state or province abbreviation.</param>
        /// <param name="postalCode">Postal code for the rate (if any).</param>
        /// <exception cref="ArgumentNullException" />
        void BuildCode(string countryIso2, string stateProvinceAbbreviation, string postalCode);
    }
}
