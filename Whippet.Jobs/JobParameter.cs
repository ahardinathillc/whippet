using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Athi.Whippet.Data;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Jobs
{
    /// <summary>
    /// Represents a concrete implementation of the <see cref="JobParameterBase{TJob}"/> class that serves as a wrapper around an existing <see cref="IJobParameter"/> object.
    /// </summary>
    public class JobParameter : JobParameterBase<Job>, IWhippetEntity, IJobParameter, IEqualityComparer<IJobParameter>
    {
        /// <summary>
        /// Gets or sets the internal <see cref="IJobParameter"/> object.
        /// </summary>
        private IJobParameter InternalObject
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
        /// Gets the parameter name. This property is read-only.
        /// </summary>
        public override string Name
        {
            get
            {
                return InternalObject.Name;
            }
        }

        /// <summary>
        /// Gets the <see cref="IJob"/> that the parameter applies to. This property is read-only.
        /// </summary>
        public new Job Job
        {
            get
            {
                return new Job((IJob)(InternalObject.Job));
            }
        }

        /// <summary>
        /// Gets the <see cref="IJob"/> that the parameter applies to. This property is read-only.
        /// </summary>
        /// <exception cref="EntityIsReadOnlyException" />
        IJob IJobParameter.Job
        {
            get
            {
                return Job;
            }
            set
            {
                throw new EntityIsReadOnlyException();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Type"/> of the parameter. How it is rendered on the view is left up to the caller.
        /// </summary>
        public override Type ParameterType
        {
            get
            {
                return InternalObject.ParameterType;
            }
            set
            {
                InternalObject.ParameterType = value;
            }
        }

        /// <summary>
        /// Gets the unique constant ID of the parameter which identifies its type. This property is read-only.
        /// </summary>
        Guid IJobParameter.ParameterID
        {
            get
            {
                return InternalObject.ParameterID;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobParameter"/> class with the specified ID and <see cref="Athi.Whippet.Jobs.Job"/>.
        /// </summary>
        /// <param name="id">Unique ID of the <see cref="JobParameter"/>.</param>
        /// <param name="job"><see cref="Athi.Whippet.Jobs.Job"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public JobParameter(Guid id, IJob job, IJobParameter parameter)
            : base(id, null, new Job(job), Guid.Empty)
        {
            if (job == null)
            {
                throw new ArgumentNullException(nameof(job));
            }
            else if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }
            else
            {
                InternalObject = parameter;
            }
        }

        /// <summary>
        /// Creates a new <see cref="JobParameter"/> instance for the specified type with the given constructor arguments.
        /// </summary>
        /// <typeparam name="TJobParameter">Type of <see cref="JobParameter"/> to initialize.</typeparam>
        /// <typeparam name="TJob">Type of <see cref="Athi.Whippet.Jobs.Job"/> that the parameter is for.</typeparam>
        /// <param name="id">Unique ID of the <see cref="JobParameter"/>.</param>
        /// <param name="job"><see cref="Athi.Whippet.Jobs.Job"/> object that the parameter is for.</param>
        /// <param name="parameterType">Parameter type of the <typeparamref name="TJobParameter"/>.</param>
        /// <returns><see cref="JobParameter"/> object.</returns>
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
        public static JobParameter CreateInstance<TJobParameter, TJob>(Guid id, TJob job, Type parameterType)
            where TJob : JobBase, IJob, new()
            where TJobParameter : JobParameterBase<TJob>, IJobParameter, new()
        {
            return new JobParameter(id, job, (IJobParameter)(Activator.CreateInstance(typeof(TJobParameter), id, job)));
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
        public override bool Equals(IJobParameter obj)
        {
            return InternalObject.Equals(obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(IJobParameter x, IJobParameter y)
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
        /// <param name="obj"><see cref="IJobParameter"/> object to get the hash code for.</param>
        /// <returns>Hash code for the current object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override int GetHashCode(IJobParameter obj)
        {
            return InternalObject.GetHashCode(obj);
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
