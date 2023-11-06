using System;
using Athi.Whippet.Data;

namespace Athi.Whippet.Jobs
{
    /// <summary>
    /// Base class for job parameters that are rendered in a drop-down control. This class must be inherited.
    /// </summary>
    public abstract class JobParameterDropDownControlBase<TJob> : JobParameterBase<TJob>, IWhippetEntity, IJobParameter, IEqualityComparer<IJobParameter>
        where TJob : JobBase, IJob
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobParameterDropDownControlBase{TJob}"/> class with the specified parameter ID.
        /// </summary>
        /// <param name="parameterId">Parameter ID that identifies the parameter type.</param>
        protected JobParameterDropDownControlBase(Guid parameterId)
            : base(parameterId)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobParameterDropDownControlBase{TJob}"/> class with the specified <see cref="Guid"/>.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="parameterId">Parameter ID that identifies the parameter type.</param>
        protected JobParameterDropDownControlBase(Guid id, Guid parameterId)
            : base(id, parameterId)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobParameterDropDownControlBase{TJob}"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="name">Name of the parameter.</param>
        /// <param name="job"><typeparamref name="TJob"/> that the parameter applies to.</param>
        /// <param name="parameterId">Parameter ID that identifies the parameter type.</param>
        protected JobParameterDropDownControlBase(Guid id, string name, TJob job, Guid parameterId)
            : base(id, name, job, parameterId)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobParameterDropDownControlBase{TJob}"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="name">Name of the parameter.</param>
        /// <param name="job"><typeparamref name="TJob"/> that the parameter applies to.</param>
        /// <param name="parameterType">Parameter type.</param>
        /// <param name="parameterId">Parameter ID that identifies the parameter type.</param>
        protected JobParameterDropDownControlBase(Guid id, string name, TJob job, Type parameterType, Guid parameterId)
            : base(id, name, job, parameterType, parameterId)
        { }
    }
}
