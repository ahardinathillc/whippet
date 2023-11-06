using System;
using Athi.Whippet.Adobe.Magento.Taxes;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Models
{
    /// <summary>
    /// Data model for synchronizing tax rates between Freestyle Solutions Multichannel Order Manager and Adobe Magento.
    /// </summary>
    public class MagentoMultichannelOrderManagerSalesTaxSynchronizationDataModel
    {
        private string _exemptCode;

        /// <summary>
        /// Gets or sets the Magento server ID.
        /// </summary>
        public Guid MagentoServerID
        { get; set; }

        /// <summary>
        /// Gets or sets the Multichannel Order Manager server ID.
        /// </summary>
        public Guid MultichannelOrderManagerServerID
        { get; set; }

        /// <summary>
        /// Gets or sets the Multichannel Order Manager export server ID. This server contains the export data needed for Magento.
        /// </summary>
        public Guid MultichannelOrderManagerExportServerID
        { get; set; }

        /// <summary>
        /// Gets or sets the table or view name that contains the export data from M.O.M. If <see cref="String.Empty"/> or <see langword="null"/>, the default option will be used.
        /// </summary>
        public string TableViewName
        { get; set; }

        /// <summary>
        /// If <see langword="true"/>, existing Magento tax-exempt rates will not be deleted or updated.
        /// </summary>
        public bool PreserveMagentoExemptTaxRates
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ITaxRate.Code"/> that indicates the tax rate is tax-exempt. If <see cref="String.Empty"/> or <see langword="null"/>, the default value is used.
        /// </summary>
        public string MagentoExemptTaxRateCode
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_exemptCode))
                {
                    _exemptCode = TaxRate.DEFAULT_TAX_EXEMPT_CODE;
                }

                return _exemptCode;
            }
            set
            {
                _exemptCode = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoMultichannelOrderManagerSalesTaxSynchronizationDataModel"/> class with no arguments.
        /// </summary>
        public MagentoMultichannelOrderManagerSalesTaxSynchronizationDataModel()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoMultichannelOrderManagerSalesTaxSynchronizationDataModel"/> class with the specified parameters.
        /// </summary>
        /// <param name="magentoServerId">Magento server ID.</param>
        /// <param name="momServerId">Multichannel Order Manager server ID.</param>
        /// <param name="momExportServerId">Multichannel Order Manager export server ID or <see langword="null"/> to use <paramref name="momServerId"/>.</param>
        /// <param name="tableViewName">Table or view name that contains the export data from M.O.M. If <see cref="String.Empty"/> or <see langword="null"/>, the default option will be used.</param>
        public MagentoMultichannelOrderManagerSalesTaxSynchronizationDataModel(Guid magentoServerId, Guid momServerId, Guid? momExportServerId = null, string tableViewName = null)
            : this()
        {
            MagentoServerID = magentoServerId;
            MultichannelOrderManagerServerID = momServerId;

            if (!momExportServerId.HasValue || (momExportServerId.Value == Guid.Empty))
            {
                MultichannelOrderManagerExportServerID = momServerId;
            }

            TableViewName = tableViewName;
        }
    }
}

