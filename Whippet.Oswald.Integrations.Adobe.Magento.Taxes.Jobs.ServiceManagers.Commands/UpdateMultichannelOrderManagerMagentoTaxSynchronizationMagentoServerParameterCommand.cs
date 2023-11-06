using System;
using Athi.Whippet.Jobs.ServiceManagers.Commands;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter"/> object in the data store.
    /// </summary>
    public class UpdateMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommand : UpdateJobParameterCommand<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter, MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommand"/> class with no arguments.
        /// </summary>
        private UpdateMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommand()
            : this(new MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommand"/> class with the specified <see cref="MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter"/> object.
        /// </summary>
        /// <param name="parameter"><see cref="MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public UpdateMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommand(MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter parameter)
            : base(parameter)
        { }
    }
}
