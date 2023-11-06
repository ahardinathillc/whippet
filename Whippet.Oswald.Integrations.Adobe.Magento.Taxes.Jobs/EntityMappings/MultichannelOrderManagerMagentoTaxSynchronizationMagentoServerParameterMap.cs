using System;
using Athi.Whippet.Data.NHibernate.UserTypes;
using Athi.Whippet.Jobs.EntityMappings;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.EntityMappings
{
    /// <summary>
    /// Provides an entity mapping for <see cref="MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterMap"/> objects.
    /// </summary>
    public class MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterMap : JobParameterMapBase<MultichannelOrderManagerMagentoTaxSynchronizationJob, MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter>
    {
        private const string PARAM_TABLE_NAME = "MagentoServer";

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterMap"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterMap()
            : base(CreateTableName(MultichannelOrderManagerMagentoTaxSynchronizationJobMap.TABLE_NAME, PARAM_TABLE_NAME), null)
        {
            Map(j => j.MagentoServerID).Nullable();
            Map(j => j.MagentoServerType).Not.Nullable().CustomType<TypeUserType>();
            Map(j => j.TaxExemptCode).Not.Nullable().Length(255);                       // default to 255
            Map(j => j.PreserveExistingTaxExemptRates).Not.Nullable();
            Map(j => j.UseBulkImport).Not.Nullable();
        }
    }
}
