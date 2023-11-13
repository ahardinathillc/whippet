using System;
using Athi.Whippet.Jobs.ServiceManagers.Commands;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> object in the data store.
    /// </summary>
    public class CreateMultichannelOrderManagerMagentoTaxSynchronizationJobCommand : CreateJobCommand<MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMultichannelOrderManagerMagentoTaxSynchronizationJobCommand"/> class with no arguments.
        /// </summary>
        private CreateMultichannelOrderManagerMagentoTaxSynchronizationJobCommand()
            : this(new MultichannelOrderManagerMagentoTaxSynchronizationJob())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMultichannelOrderManagerMagentoTaxSynchronizationJobCommand"/> class with the specified <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> object.
        /// </summary>
        /// <param name="job"><see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public CreateMultichannelOrderManagerMagentoTaxSynchronizationJobCommand(MultichannelOrderManagerMagentoTaxSynchronizationJob job)
            : base(job)
        { }
    }
}
