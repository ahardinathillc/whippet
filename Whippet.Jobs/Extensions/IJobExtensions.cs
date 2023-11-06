using System;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.Jobs.Extensions
{
    /// <summary>
    /// Provides extension methos to <see cref="IJob"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IJobExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IJob"/> object to a <typeparamref name="TJob"/> object.
        /// </summary>
        /// <param name="job"><see cref="IJob"/> object.</param>
        /// <returns><typeparamref name="TJob"/> object.</returns>
        public static TJob ToJob<TJob>(this IJob job)
            where TJob : JobBase, IJob, new()
        {
            TJob newJob = null;

            if (job != null)
            {
                job = new TJob()
                {
                    Active = job.Active,
                    Category = job.Category.ToJobCategory(),
                    JobDescription = job.JobDescription,
                    JobName = job.JobName,
                    Schedule = job.Schedule.Clone<CronTabSchedule>(),
                    Tenant = job.Tenant.ToWhippetTenant(),
                    ID = job.ID
                };
            }

            return newJob;
        }
    }
}

