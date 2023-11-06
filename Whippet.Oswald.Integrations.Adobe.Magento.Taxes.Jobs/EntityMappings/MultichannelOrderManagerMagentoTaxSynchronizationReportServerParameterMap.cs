using System;
using Athi.Whippet.Data.NHibernate.UserTypes;
using Athi.Whippet.Jobs.EntityMappings;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.EntityMappings
{
    /// <summary>
    /// Provides an entity mapping for <see cref="MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterMap"/> objects.
    /// </summary>
    public class MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterMap : JobParameterMapBase<MultichannelOrderManagerMagentoTaxSynchronizationJob, MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter>
    {
        private const string PARAM_TABLE_NAME = "ReportServer";

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterMap"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterMap()
            : base(CreateTableName(MultichannelOrderManagerMagentoTaxSynchronizationJobMap.TABLE_NAME, PARAM_TABLE_NAME), null)
        {
            Map(j => j.ReportServerID).Nullable();
            Map(j => j.ReportServerType).Not.Nullable().CustomType<TypeUserType>();
            Map(j => j.TableViewName).Not.Nullable().Length(SqlServerNVarCharMaxLength);
        }
    }
}
