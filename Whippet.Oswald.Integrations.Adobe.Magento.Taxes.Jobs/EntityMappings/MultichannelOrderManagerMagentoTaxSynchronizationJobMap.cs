using System;
using Athi.Whippet.Jobs.EntityMappings;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.EntityMappings
{
    /// <summary>
    /// Provides an entity mapping for <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> objects.
    /// </summary>
    public class MultichannelOrderManagerMagentoTaxSynchronizationJobMap : JobMapBase<MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        internal const string TABLE_NAME = "MagMomTaxSyncJob";

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJobMap"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerMagentoTaxSynchronizationJobMap()
            : base(CreateTableName(TABLE_NAME), null)
        { }
    }
}

