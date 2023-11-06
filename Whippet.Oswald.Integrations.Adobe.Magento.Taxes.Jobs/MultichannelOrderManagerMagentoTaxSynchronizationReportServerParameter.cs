using System;
using Athi.Whippet.Jobs;
using Athi.Whippet.Adobe.Magento;
using RestSharp;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs
{
    /// <summary>
    /// Represents the report server parameter for a <see cref="MagentoServer"/> for the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/>.
    /// </summary>
    public class MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter : JobParameterDropDownControlBase<MultichannelOrderManagerMagentoTaxSynchronizationJob>, IJobParameter
    {
        private const string PARAMETER_NAME = "ReportServerID";

        private static readonly Guid __ParameterID = new Guid("cea49d68-1ac8-45cd-8f39-a5fe39b31f8f");

        /// <summary>
        /// Gets or sets the ID of the report server that the parameter references.
        /// </summary>
        public virtual Guid? ReportServerID
        { get; set; }

        /// <summary>
        /// Gets or sets the report server type.
        /// </summary>
        public virtual Type ReportServerType
        { get; set; }

        /// <summary>
        /// Gets or sets the table (or view) name that contains the flattened tax export data.
        /// </summary>
        public virtual string TableViewName
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter()
            : this(Guid.Empty, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter"/> class with the specified <see cref="Guid"/>.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        public MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter(Guid id)
            : this(id, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="job"><see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> that the parameter applies to.</param>
        public MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter(Guid id, MultichannelOrderManagerMagentoTaxSynchronizationJob job)
            : base(id, PARAMETER_NAME, job, __ParameterID)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="job"><see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> that the parameter applies to.</param>
        /// <param name="parameterType">Parameter type.</param>
        public MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter(Guid id, MultichannelOrderManagerMagentoTaxSynchronizationJob job, Type parameterType)
            : base(id, PARAMETER_NAME, job, parameterType, __ParameterID)
        { }

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be inherited.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public override string ToJson<T>()
        {
            return this.SerializeJson(this);
        }
    }
}
