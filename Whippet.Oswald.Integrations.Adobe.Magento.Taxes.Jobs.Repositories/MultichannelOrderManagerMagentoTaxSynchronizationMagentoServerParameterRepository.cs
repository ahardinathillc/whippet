using System;
using NHibernate;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Jobs.Repositories;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.Repositories
{
    /// <summary>
    /// Represents a data repository for <see cref="MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter"/> objects.
    /// </summary>
    public class MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterRepository : JobParameterRepositoryBase<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter, MultichannelOrderManagerMagentoTaxSynchronizationJob>, IJobParameterRepository<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter, MultichannelOrderManagerMagentoTaxSynchronizationJob>, IWhippetEntityRepository<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter, Guid>, IWhippetQueryRepository<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }
    }
}
