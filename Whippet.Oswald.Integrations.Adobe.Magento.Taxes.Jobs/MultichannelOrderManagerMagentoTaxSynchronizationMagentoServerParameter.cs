using System;
using Athi.Whippet.Jobs;
using Athi.Whippet.Adobe.Magento;
using RestSharp;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs
{
    /// <summary>
    /// Represents the destination <see cref="MagentoServer"/> for the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/>.
    /// </summary>
    public class MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter : JobParameterDropDownControlBase<MultichannelOrderManagerMagentoTaxSynchronizationJob>, IJobParameter
    {
        private const string PARAMETER_NAME = "MagentoServerID";

        private static readonly Guid __ParameterID = new Guid("8c861440-0399-4bc2-be53-c2f2ccded579");

        /// <summary>
        /// Gets or sets the ID of the source server that the parameter references.
        /// </summary>
        public virtual Guid? MagentoServerID
        { get; set; }

        /// <summary>
        /// Gets or sets the target server type.
        /// </summary>
        public virtual Type MagentoServerType
        { get; set; }

        /// <summary>
        /// Gets or sets the tax-exempt code used to identify tax-exempt rates in Magento.
        /// </summary>
        public virtual string TaxExemptCode
        { get; set; }

        /// <summary>
        /// Specifies whether existing tax-exempt rates should be preserved and not overridden.
        /// </summary>
        public virtual bool PreserveExistingTaxExemptRates
        { get; set; }

        /// <summary>
        /// Specifies whether the bulk import operation should be used. If <see langword="false"/>, tax rates will be individually synchronized.
        /// </summary>
        public virtual bool UseBulkImport
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter()
            : this(Guid.Empty, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter"/> class with the specified <see cref="Guid"/>.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        public MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter(Guid id)
            : this(id, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="job"><see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> that the parameter applies to.</param>
        public MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter(Guid id, MultichannelOrderManagerMagentoTaxSynchronizationJob job)
            : base(id, PARAMETER_NAME, job, __ParameterID)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="job"><see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> that the parameter applies to.</param>
        /// <param name="parameterType">Parameter type.</param>
        public MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter(Guid id, MultichannelOrderManagerMagentoTaxSynchronizationJob job, Type parameterType)
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
