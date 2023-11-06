using System;
using Athi.Whippet.Jobs.ServiceManagers.Commands;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> object in the data store.
    /// </summary>
    public class DeleteMultichannelOrderManagerMagentoTaxSynchronizationJobCommand : DeleteJobCommand<MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMultichannelOrderManagerMagentoTaxSynchronizationJobCommand"/> class with no arguments.
        /// </summary>
        private DeleteMultichannelOrderManagerMagentoTaxSynchronizationJobCommand()
            : this(new MultichannelOrderManagerMagentoTaxSynchronizationJob())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMultichannelOrderManagerMagentoTaxSynchronizationJobCommand"/> class with the specified <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> object.
        /// </summary>
        /// <param name="job"><see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public DeleteMultichannelOrderManagerMagentoTaxSynchronizationJobCommand(MultichannelOrderManagerMagentoTaxSynchronizationJob job)
            : base(job)
        { }
    }
}

