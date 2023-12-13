using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Json.Newtonsoft.Extensions;
using Athi.Whippet.Json;

namespace Athi.Whippet.Jobs
{
    /// <summary>
    /// Represents a concrete implementation of the <see cref="JobBase"/> class that serves as a wrapper around an existing <see cref="IJob"/> object.
    /// </summary>
    public class Job : JobBase, IWhippetEntity, IWhippetActiveEntity, IJob, IEqualityComparer<IJob>, IWhippetCloneable, ICloneable
    {
        /// <summary>
        /// Gets or sets the internal <see cref="IJob"/> object.
        /// </summary>
        private IJob InternalObject
        { get; set; }

        /// <summary>
        /// Unique ID of the entity.
        /// </summary>
        [JsonRequired]
        public override Guid ID
        {
            get
            {
                return InternalObject.ID;
            }
            set
            {
                InternalObject.ID = value;
            }
        }

        /// <summary>
        /// Gets a standard ID for the <see cref="IJob"/> that identifies the job across tenants. This property is read-only. This property must be overridden.
        /// </summary>
        public override Guid FixedJobID
        {
            get
            {
                return InternalObject.FixedJobID;
            }
        }

        /// <summary>
        /// Gets the job name. This property is read-only.
        /// </summary>
        public override string JobName
        {
            get
            {
                return InternalObject.JobName;
            }
        }

        /// <summary>
        /// Gets or sets the job schedule. By default, upon instantiation the schedule will be set to execute on the current <see cref="DateTime.UtcNow"/> hour on the <see cref="DateTime.UtcNow"/> day each year.
        /// </summary>
        public override CronTabSchedule Schedule
        {
            get
            {
                return InternalObject.Schedule;
            }
            set
            {
                InternalObject.Schedule = value;
            }
        }

        /// <summary>
        /// Gets the job description. This property is read-only.
        /// </summary>
        public override string JobDescription
        {
            get
            {
                return InternalObject.JobDescription;
            }
        }

        /// <summary>
        /// Specifies whether the job is currently active.
        /// </summary>
        public override bool Active
        {
            get
            {
                return InternalObject.Active;
            }
            set
            {
                InternalObject.Active = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> that the job is registered with.
        /// </summary>
        public new IWhippetTenant Tenant
        {
            get
            {
                return InternalObject.Tenant;
            }
            set
            {
                InternalObject.Tenant = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IJobCategory"/> that the job is listed under.
        /// </summary>
        public new IJobCategory Category
        {
            get
            {
                return InternalObject.Category;
            }
            set
            {
                InternalObject.Category = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Job"/> class with no arguments.
        /// </summary>
        public Job()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Job"/> class with the specified <see cref="IJob"/> object.
        /// </summary>
        /// <param name="job"><see cref="IJob"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Job(IJob job)
            : this()
        {
            if (job == null)
            {
                throw new ArgumentNullException(nameof(job));
            }
            else
            {
                InternalObject = job;
            }
        }

        /// <summary>
        /// Creates a new <see cref="Job"/> instance for the specified type with the given constructor arguments.
        /// </summary>
        /// <typeparam name="TJob"><see cref="IJob"/> type to instantiate.</typeparam>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="jobName">Name of the job.</param>
        /// <param name="jobDescription">Job description.</param>
        /// <param name="schedule">Job's cron schedule.</param>
        /// <param name="tenant"><see cref="WhippetTenant"/> that the job is registered with.</param>
        /// <param name="active">Specifies whether the job is currently active and running.</param>
        /// <param name="category">Parent <see cref="JobCategory"/> that the job belongs to.</param>
        /// <param name="logger"><see cref="ILogger"/> used to log the job activity or <see langword="null"/> to use no logger.</param>
        /// <returns><see cref="Job"/> instance that wraps around the instantiated object.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="NotSupportedException" />
        /// <exception cref="TargetInvocationException" />
        /// <exception cref="MethodAccessException" />
        /// <exception cref="MemberAccessException" />
        /// <exception cref="InvalidComObjectException" />
        /// <exception cref="MissingMethodException" />
        /// <exception cref="COMException" />
        /// <exception cref="TypeLoadException" />
        public static Job CreateInstance<TJob>(Guid id, string jobName, string jobDescription, CronTabSchedule schedule, bool active, WhippetTenant tenant, JobCategory category, ILogger logger)
            where TJob : JobBase, IJob, new()
        {
            return new Job((IJob)(Activator.CreateInstance(typeof(TJob), id, jobName, jobDescription, schedule, active, tenant, category, logger)));
        }

        /// <summary>
        /// Creates a new <see cref="Job"/> instance for the specified type with the given constructor arguments.
        /// </summary>
        /// <typeparam name="TJob"><see cref="IJob"/> type to instantiate.</typeparam>
        /// <param name="args">Arguments to pass to the constructor stored in the order that the constructor is expecting.</param>
        /// <returns><see cref="Job"/> instance that wraps around the instantiated object.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="NotSupportedException" />
        /// <exception cref="TargetInvocationException" />
        /// <exception cref="MethodAccessException" />
        /// <exception cref="MemberAccessException" />
        /// <exception cref="InvalidComObjectException" />
        /// <exception cref="MissingMethodException" />
        /// <exception cref="COMException" />
        /// <exception cref="TypeLoadException" />
        public static Job CreateInstance<TJob>(IEnumerable<object> args)
        {
            return new Job((IJob)(Activator.CreateInstance(typeof(TJob), (args == null || !args.Any()) ? Array.Empty<object>() : args.ToArray())));
        }

        /// <summary>
        /// Executes the job.
        /// </summary>
        /// <param name="parameters"><see cref="IJobParameter"/> object(s) that provide additional information the job needs in order to run (if any).</param>
        public override void Execute(params IJobParameter[] parameters)
        {
            InternalObject.Execute(parameters);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return InternalObject.Equals(obj);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(IJob obj)
        {
            return InternalObject.Equals(obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(IJob x, IJob y)
        {
            return InternalObject.Equals(x, y);
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return InternalObject.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <param name="obj"><see cref="IJob"/> object to get the hash code for.</param>
        /// <returns>Hash code for the current object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override int GetHashCode(IJob obj)
        {
            return InternalObject.GetHashCode(obj);
        }

        /// <summary>
        /// Creates a duplicate instance of the current object with the optional <see cref="Guid"/> that represents the user ID of the user who instantiated the new instance.
        /// </summary>
        /// <typeparam name="TObject">Type of object to return from the operation.</typeparam>
        /// <param name="createdBy"><see cref="Guid"/> ID of the user who instantiated the new instance.</param>
        /// <returns>Object of type <typeparamref name="TObject"/>.</returns>
        public override TObject Clone<TObject>(Guid? createdBy = null)
        {
            return InternalObject.Clone<TObject>(createdBy);
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return InternalObject.ToString();
        }
    }
}
