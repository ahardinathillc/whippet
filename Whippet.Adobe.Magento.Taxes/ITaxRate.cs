using System;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Directory;

namespace Athi.Whippet.Adobe.Magento.Taxes
{
    /// <summary>
    /// Represents a tax rate in Magento.
    /// </summary>
    public interface ITaxRate : IMagentoEntity, IEqualityComparer<ITaxRate>, IMagentoRestEntity
    {
        /// <summary>
        /// Gets or sets the tax rate's parent country.
        /// </summary>
        ICountry Country
        { get; set; }

        /// <summary>
        /// Gets or sets the tax rate's region.
        /// </summary>
        IRegion Region
        { get; set; }
        
        /// <summary>
        /// Gets or sets the tax rate's applicable postal code.
        /// </summary>
        string PostalCode
        { get; set; }
        
        /// <summary>
        /// Specifies whether the tax rate applies to a range of postal codes.
        /// </summary>
        bool PostalCodeIsRange
        { get; set; }

        /// <summary>
        /// Gets or sets the lower bound of the <see cref="PostalCode"/> range.
        /// </summary>
        int? PostalCodeLowerBound
        { get; set; }

        /// <summary>
        /// Gets or sets the upper bound of the <see cref="PostalCode"/> range.
        /// </summary>
        int? PostalCodeUpperBound
        { get; set; }

        /// <summary>
        /// Gets or sets the tax rate percentage.
        /// </summary>
        decimal Rate
        { get; set; }

        /// <summary>
        /// Gets or sets the tax rate code.
        /// </summary>
        string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the tax rate titles.
        /// </summary>
        IEnumerable<ITaxRateTitle> Titles
        { get; set; }        
    }
}
