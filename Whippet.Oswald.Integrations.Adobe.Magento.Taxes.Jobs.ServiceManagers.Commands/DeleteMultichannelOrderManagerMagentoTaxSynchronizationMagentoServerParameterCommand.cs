using System;
using Athi.Whippet.Jobs.ServiceManagers.Commands;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter"/> object in the data store.
    /// </summary>
    public class DeleteMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommand : DeleteJobParameterCommand<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter, MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommand"/> class with no arguments.
        /// </summary>
        private DeleteMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommand()
            : this(new MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommand"/> class with the specified <see cref="MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter"/> object.
        /// </summary>
        /// <param name="parameter"><see cref="MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public DeleteMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommand(MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter parameter)
            : base(parameter)
        { }
    }
}
