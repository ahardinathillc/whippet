using System;
using Athi.Whippet.Jobs.ServiceManagers.Commands;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter"/> object in the data store.
    /// </summary>
    public class CreateMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterCommand : CreateJobParameterCommand<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter, MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterCommand"/> class with no arguments.
        /// </summary>
        private CreateMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterCommand()
            : this(new MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterCommand"/> class with the specified <see cref="MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter"/> object.
        /// </summary>
        /// <param name="parameter"><see cref="MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public CreateMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterCommand(MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter parameter)
            : base(parameter)
        { }
    }
}
