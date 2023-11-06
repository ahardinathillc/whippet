using System;
using Athi.Whippet.Data.NHibernate.UserTypes;
using Athi.Whippet.Jobs.EntityMappings;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.EntityMappings
{
    /// <summary>
    /// Provides an entity mapping for <see cref="MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterMap"/> objects.
    /// </summary>
    public class MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterMap : JobParameterMapBase<MultichannelOrderManagerMagentoTaxSynchronizationJob, MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter>
    {
        private const string PARAM_TABLE_NAME = "SourceServer";

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterMap"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterMap()
            : base(CreateTableName(MultichannelOrderManagerMagentoTaxSynchronizationJobMap.TABLE_NAME, PARAM_TABLE_NAME), null)
        {
            Map(j => j.SourceServerID).Nullable();
            Map(j => j.SourceServerType).Not.Nullable().CustomType<TypeUserType>();
        }
    }
}
