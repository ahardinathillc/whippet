using System;
using Athi.Whippet.Jobs;
using Athi.Whippet.Adobe.Magento;
using RestSharp;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs
{
    /// <summary>
    /// Represents the source server parameter for a <see cref="MagentoServer"/> for the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/>.
    /// </summary>
    public class MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter : JobParameterDropDownControlBase<MultichannelOrderManagerMagentoTaxSynchronizationJob>, IJobParameter
    {
        private const string PARAMETER_NAME = "SourceServerID";

        private static readonly Guid __ParameterID = new Guid("a35d8231-2e33-4e59-9792-6763a2f54b33");

        /// <summary>
        /// Gets or sets the ID of the source server that the parameter references.
        /// </summary>
        public virtual Guid? SourceServerID
        { get; set; }

        /// <summary>
        /// Gets or sets the source server type.
        /// </summary>
        public virtual Type SourceServerType
        { get; set; }

        /// <summary>
        /// If <see langword="true"/>, the server contains the tax rate export report needed to process tax rates.
        /// </summary>
        public virtual bool IsReportServer
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter()
            : this(Guid.Empty, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter"/> class with the specified <see cref="Guid"/>.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        public MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter(Guid id)
            : this(id, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="job"><see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> that the parameter applies to.</param>
        public MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter(Guid id, MultichannelOrderManagerMagentoTaxSynchronizationJob job)
            : base(id, PARAMETER_NAME, job, __ParameterID)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="job"><see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> that the parameter applies to.</param>
        /// <param name="parameterType">Parameter type.</param>
        public MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter(Guid id, MultichannelOrderManagerMagentoTaxSynchronizationJob job, Type parameterType)
            : base(id, PARAMETER_NAME, job, parameterType, __ParameterID)
        { }

    }
}
