using System;
using Athi.Whippet.Jobs.ServiceManagers.Commands;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter"/> object in the data store.
    /// </summary>
    public class DeleteMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterCommand : DeleteJobParameterCommand<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter, MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterCommand"/> class with no arguments.
        /// </summary>
        private DeleteMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterCommand()
            : this(new MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterCommand"/> class with the specified <see cref="MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter"/> object.
        /// </summary>
        /// <param name="parameter"><see cref="MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public DeleteMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterCommand(MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter parameter)
            : base(parameter)
        { }
    }
}
