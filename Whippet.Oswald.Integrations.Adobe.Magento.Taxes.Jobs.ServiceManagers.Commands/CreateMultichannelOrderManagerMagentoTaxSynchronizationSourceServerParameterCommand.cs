using System;
using Athi.Whippet.Jobs.ServiceManagers.Commands;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter"/> object in the data store.
    /// </summary>
    public class CreateMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterCommand : CreateJobParameterCommand<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter, MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterCommand"/> class with no arguments.
        /// </summary>
        private CreateMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterCommand()
            : this(new MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterCommand"/> class with the specified <see cref="MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter"/> object.
        /// </summary>
        /// <param name="parameter"><see cref="MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public CreateMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterCommand(MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter parameter)
            : base(parameter)
        { }
    }
}
