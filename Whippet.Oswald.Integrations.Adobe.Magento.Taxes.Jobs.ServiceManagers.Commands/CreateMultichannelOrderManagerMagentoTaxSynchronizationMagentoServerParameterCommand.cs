using System;
using Athi.Whippet.Jobs.ServiceManagers.Commands;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter"/> object in the data store.
    /// </summary>
    public class CreateMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommand : CreateJobParameterCommand<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter, MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommand"/> class with no arguments.
        /// </summary>
        private CreateMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommand()
            : this(new MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommand"/> class with the specified <see cref="MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter"/> object.
        /// </summary>
        /// <param name="parameter"><see cref="MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public CreateMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommand(MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter parameter)
            : base(parameter)
        { }
    }
}
