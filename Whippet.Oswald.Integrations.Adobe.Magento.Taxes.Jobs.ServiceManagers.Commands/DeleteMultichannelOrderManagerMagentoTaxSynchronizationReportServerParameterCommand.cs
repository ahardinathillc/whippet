using System;
using Athi.Whippet.Jobs.ServiceManagers.Commands;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter"/> object in the data store.
    /// </summary>
    public class DeleteMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterCommand : DeleteJobParameterCommand<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter, MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterCommand"/> class with no arguments.
        /// </summary>
        private DeleteMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterCommand()
            : this(new MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterCommand"/> class with the specified <see cref="MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter"/> object.
        /// </summary>
        /// <param name="parameter"><see cref="MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public DeleteMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterCommand(MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter parameter)
            : base(parameter)
        { }
    }
}
