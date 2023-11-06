using System;
using Athi.Whippet.Jobs.ServiceManagers.Commands;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> object in the data store.
    /// </summary>
    public class UpdateMultichannelOrderManagerMagentoTaxSynchronizationJobCommand : UpdateJobCommand<MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMultichannelOrderManagerMagentoTaxSynchronizationJobCommand"/> class with no arguments.
        /// </summary>
        private UpdateMultichannelOrderManagerMagentoTaxSynchronizationJobCommand()
            : this(new MultichannelOrderManagerMagentoTaxSynchronizationJob())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMultichannelOrderManagerMagentoTaxSynchronizationJobCommand"/> class with the specified <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> object.
        /// </summary>
        /// <param name="job"><see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public UpdateMultichannelOrderManagerMagentoTaxSynchronizationJobCommand(MultichannelOrderManagerMagentoTaxSynchronizationJob job)
            : base(job)
        { }
    }
}

