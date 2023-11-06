using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Nito.AsyncEx;
using Nito.AsyncEx.Synchronous;
using Athi.Whippet.Data;
using Athi.Whippet.Jobs.Extensions;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.Jobs
{
    /// <summary>
    /// Base class for all jobs in Whippet. This class must be inherited.
    /// </summary>
    public abstract class JobBase : WhippetEntity, IWhippetEntity, IWhippetActiveEntity, IJob, IEqualityComparer<IJob>, ICloneable, IWhippetCloneable
    {
        private string _name;
        private string _description;

        private CronTabSchedule _schedule;

        private JobCategory _category;

        private WhippetTenant _tenant;

        /// <summary>
        /// Gets a standard ID for the <see cref="JobBase"/> that identifies the job across tenants. This property is read-only. This property must be overridden.
        /// </summary>
        public abstract Guid FixedJobID
        { get; }

        /// <summary>
        /// Gets the job name. This property is read-only.
        /// </summary>
        public virtual string JobName
        {
            get
            {
                return _name;
            }
            protected internal set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                else
                {
                    _name = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the job schedule. By default, upon instantiation the schedule will be set to execute on the current <see cref="DateTime.UtcNow"/> hour on the <see cref="DateTime.UtcNow"/> day each year.
        /// </summary>
        public virtual CronTabSchedule Schedule
        {
            get
            {
                if (_schedule == null)
                {
                    _schedule = CronTabSchedule.CreateSchedule(
                        CronRange.CreateSecondInstance(0),
                        CronRange.CreateMinuteInstance(0),
                        CronRange.CreateHourInstance(DateTime.UtcNow.Hour),
                        CronRange.CreateDayOfMonthInstance(DateTime.UtcNow.Day),
                        CronRange.CreateMonthInstance(null),
                        CronRange.CreateDayOfWeekInstance(null),
                        CronRange.CreateYearInstance(null)
                    );
                }

                return _schedule;
            }
            set
            {
                _schedule = value;
            }
        }

        /// <summary>
        /// Gets the job description. This property is read-only.
        /// </summary>
        public virtual string JobDescription
        {
            get
            {
                return _description;
            }
            protected internal set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                else
                {
                    _description = value;
                }
            }
        }

        /// <summary>
        /// Specifies whether the job is currently active.
        /// </summary>
        public virtual bool Active
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="JobCategory"/> that the job is listed under.
        /// </summary>
        public virtual JobCategory Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new JobCategory();
                }

                return _category;
            }
            set
            {
                _category = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="WhippetTenant"/> that the job is registered with.
        /// </summary>
        public virtual WhippetTenant Tenant
        {
            get
            {
                if (_tenant == null)
                {
                    _tenant = new WhippetTenant();
                }

                return _tenant;
            }
            set
            {
                _tenant = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> that the job is registered with.
        /// </summary>
        IWhippetTenant IJob.Tenant
        {
            get
            {
                return Tenant;
            }
            set
            {
                Tenant = value.ToWhippetTenant();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IJobCategory"/> that the job is listed under.
        /// </summary>
        IJobCategory IJob.Category
        {
            get
            {
                return Category;
            }
            set
            {
                Category = value.ToJobCategory();
            }
        }

        /// <summary>
        /// Gets the <see cref="ILogger"/> used to log the current job. This property is read-only.
        /// </summary>
        protected virtual ILogger Logger
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobBase"/> class with no arguments.
        /// </summary>
        protected JobBase()
            : base()
        {
            Logger = NullLogger.Instance;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobBase"/> class with the specified <see cref="Guid"/>.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        protected JobBase(Guid id)
            : base(id)
        {
            Logger = NullLogger.Instance;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobBase"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="jobName">Name of the job.</param>
        /// <param name="jobDescription">Job description.</param>
        /// <param name="schedule">Job's cron schedule.</param>
        /// <param name="tenant"><see cref="WhippetTenant"/> that the job is registered with.</param>
        /// <param name="active">Specifies whether the job is currently active and running.</param>
        protected JobBase(Guid id, string jobName, string jobDescription, CronTabSchedule schedule, WhippetTenant tenant, bool active)
            : this(id, jobName, jobDescription, schedule, active, tenant, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobBase"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="jobName">Name of the job.</param>
        /// <param name="jobDescription">Job description.</param>
        /// <param name="schedule">Job's cron schedule.</param>
        /// <param name="tenant"><see cref="WhippetTenant"/> that the job is registered with.</param>
        /// <param name="active">Specifies whether the job is currently active and running.</param>
        /// <param name="category">Parent <see cref="JobCategory"/> that the job belongs to.</param>
        protected JobBase(Guid id, string jobName, string jobDescription, CronTabSchedule schedule, WhippetTenant tenant, bool active, JobCategory category)
            : this(id, jobName, jobDescription, schedule, active, tenant, category, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobBase"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="jobName">Name of the job.</param>
        /// <param name="jobDescription">Job description.</param>
        /// <param name="schedule">Job's cron schedule.</param>
        /// <param name="tenant"><see cref="WhippetTenant"/> that the job is registered with.</param>
        /// <param name="active">Specifies whether the job is currently active and running.</param>
        /// <param name="logger"><see cref="ILogger"/> used to log the job activity or <see langword="null"/> to use no logger.</param>
        protected JobBase(Guid id, string jobName, string jobDescription, CronTabSchedule schedule, bool active, WhippetTenant tenant, ILogger logger)
            : this(id, jobName, jobDescription, schedule, active, tenant, null, logger)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobBase"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="jobName">Name of the job.</param>
        /// <param name="jobDescription">Job description.</param>
        /// <param name="schedule">Job's cron schedule.</param>
        /// <param name="tenant"><see cref="WhippetTenant"/> that the job is registered with.</param>
        /// <param name="active">Specifies whether the job is currently active and running.</param>
        /// <param name="category">Parent <see cref="JobCategory"/> that the job belongs to.</param>
        /// <param name="logger"><see cref="ILogger"/> used to log the job activity or <see langword="null"/> to use no logger.</param>
        protected JobBase(Guid id, string jobName, string jobDescription, CronTabSchedule schedule, bool active, WhippetTenant tenant, JobCategory category, ILogger logger)
            : this(id)
        {
            JobName = jobName;
            JobDescription = jobDescription;
            Schedule = schedule;
            Tenant = tenant;
            Active = active;
            Category = category;
            Logger = (logger == null) ? NullLogger.Instance : logger;
        }

        /// <summary>
        /// Executes the job. This method must be overridden.
        /// </summary>
        /// <param name="parameters"><see cref="IJobParameter"/> object(s) that provide additional information the job needs in order to run (if any).</param>
        public abstract void Execute(params IJobParameter[] parameters);

        /// <summary>
        /// Executes the job asynchronously. Override this method to add an asynchronous implementation of <see cref="Execute(IJobParameter[])"/>.
        /// </summary>
        /// <param name="parameters"><see cref="IJobParameter"/> object(s) that provide additional information the job needs in order to run (if any).</param>
        /// <returns><see cref="Task"/> object.</returns>
        public virtual Task ExecuteAsync(params IJobParameter[] parameters)
        {
            return null;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return (obj == null) || !(obj is IJob) ? false : Equals((IJob)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IJob obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IJob x, IJob y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.JobName, y.JobName, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.JobDescription, y.JobDescription, StringComparison.InvariantCultureIgnoreCase)
                    && ((x.Schedule == null && y.Schedule == null) || (x.Schedule != null && x.Schedule.Equals(y.Schedule)))
                    && x.Active == y.Active
                    && ((x.Tenant == null && y.Tenant == null) || (x.Tenant != null && x.Tenant.Equals(y.Tenant)));
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <param name="obj"><see cref="IJob"/> object to get the hash code for.</param>
        /// <returns>Hash code for the current object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IJob obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else
            {
                return obj.GetHashCode();
            }
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public virtual object Clone()
        {
            return Clone<IJob>();
        }

        /// <summary>
        /// Creates a duplicate instance of the current object with the optional <see cref="Guid"/> that represents the user ID of the user who instantiated the new instance. This method must be overridden.
        /// </summary>
        /// <typeparam name="TObject">Type of object to return from the operation.</typeparam>
        /// <param name="createdBy"><see cref="Guid"/> ID of the user who instantiated the new instance.</param>
        /// <returns>Object of type <typeparamref name="TObject"/>.</returns>
        public abstract TObject Clone<TObject>(Guid? createdBy = null);

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(JobName) ? base.ToString() : JobName + " [" + (String.IsNullOrWhiteSpace(JobDescription) ? "No Description" : JobDescription) + "] (" + (Active ? "Active" : "Inactive");
        }
    }
}
