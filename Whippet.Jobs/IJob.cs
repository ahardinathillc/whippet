using System;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Jobs
{
    /// <summary>
    /// Represents a job in Whippet.
    /// </summary>
    public interface IJob : IWhippetEntity, IWhippetActiveEntity, IEqualityComparer<IJob>, IWhippetCloneable, ICloneable
    {
        /// <summary>
        /// Gets a standard ID for the <see cref="IJob"/> that identifies the job across tenants. This property is read-only.
        /// </summary>
        Guid FixedJobID
        { get; }

        /// <summary>
        /// Gets the job name. This property is read-only.
        /// </summary>
        string JobName
        { get; }

        /// <summary>
        /// Gets or sets the job schedule.
        /// </summary>
        CronTabSchedule Schedule
        { get; set; }

        /// <summary>
        /// Gets the job description. This property is read-only.
        /// </summary>
        string JobDescription
        { get; }

        /// <summary>
        /// Gets or sets the <see cref="IJobCategory"/> that the job is listed under.
        /// </summary>
        IJobCategory Category
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> that the job is registered with.
        /// </summary>
        IWhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Executes the job.
        /// </summary>
        /// <param name="parameters"><see cref="IJobParameter"/> object(s) that provide additional information the job needs in order to run (if any).</param>
        void Execute(params IJobParameter[] parameters);
    }
}
