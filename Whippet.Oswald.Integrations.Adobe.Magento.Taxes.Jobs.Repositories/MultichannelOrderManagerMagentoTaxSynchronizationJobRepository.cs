using System;
using NHibernate;
using Athi.Whippet.Jobs.Repositories;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.Repositories
{
    /// <summary>
    /// Represents a data repository for <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> objects.
    /// </summary>
    public class MultichannelOrderManagerMagentoTaxSynchronizationJobRepository : JobRepositoryBase<MultichannelOrderManagerMagentoTaxSynchronizationJob>, IMultichannelOrderManagerMagentoTaxSynchronizationJobRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJobRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public MultichannelOrderManagerMagentoTaxSynchronizationJobRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJobRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public MultichannelOrderManagerMagentoTaxSynchronizationJobRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }
    }
}
