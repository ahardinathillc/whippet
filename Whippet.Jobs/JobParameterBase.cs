using System;
using Athi.Whippet.Data;

namespace Athi.Whippet.Jobs
{
    /// <summary>
    /// Base class for all job parameters in Whippet. This class must be inherited.
    /// </summary>
    public abstract class JobParameterBase<TJob> : WhippetEntity, IWhippetEntity, IJobParameter, IEqualityComparer<IJobParameter>
        where TJob : JobBase, IJob
    {
        private Guid _overwriteParameterIdValue;

        /// <summary>
        /// Gets the static ID of the parameter that uniquely identifies its type regardless of the job it's assigned to.
        /// </summary>
        protected readonly Guid _ParameterID;

        /// <summary>
        /// Gets the parameter name. This property is read-only.
        /// </summary>
        public virtual string Name
        { get; protected internal set; }

        /// <summary>
        /// Gets or sets the <typeparamref name="TJob"/> that the parameter applies to.
        /// </summary>
        public virtual TJob Job
        { get; set; }

        /// <summary>
        /// Gets the static ID of the parameter that uniquely identifies its type regardless of the job it's assigned to. This property is read-only.
        /// </summary>
        Guid IJobParameter.ParameterID
        {
            get
            {
                return _ParameterID;
            }
        }

        /// <summary>
        /// Gets the static ID of the parameter that uniquely identifies its type regardless of the job it's assigned to.
        /// </summary>
        protected internal virtual Guid ParameterID
        {
            get
            {
                return OverwriteParameterID ? _overwriteParameterIdValue : _ParameterID;
            }
            set
            {
                if (OverwriteParameterID)
                {
                    _overwriteParameterIdValue = value;
                }
            }
        }

        /// <summary>
        /// If <see langword="true"/>, allows a different parameter ID to be used.
        /// </summary>
        protected internal virtual bool OverwriteParameterID
        { get; set; } = false;

        /// <summary>
        /// Gets or sets the <see cref="IJob"/> that the parameter applies to.
        /// </summary>
        /// <exception cref="InvalidCastException" />
        IJob IJobParameter.Job
        {
            get
            {
                return Job;
            }
            set
            {
                Job = (TJob)(value);
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Type"/> of the parameter. How it is rendered on the view is left up to the caller.
        /// </summary>
        public virtual Type ParameterType
        { get; set; } = typeof(string);

        /// <summary>
        /// Initializes a new instance of the <see cref="JobParameterBase{TJob}"/> class with no arguments.
        /// </summary>
        private JobParameterBase()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobParameterBase{TJob}"/> class with the specified parameter ID.
        /// </summary>
        /// <param name="parameterId">Parameter ID that identifies the parameter type.</param>
        protected JobParameterBase(Guid parameterId)
            : this(new Guid(), parameterId)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobParameterBase{TJob}"/> class with the specified <see cref="Guid"/>.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="parameterId">Parameter ID that identifies the parameter type.</param>
        protected JobParameterBase(Guid id, Guid parameterId)
            : base(id)
        {
            _ParameterID = parameterId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobParameterBase{TJob}"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="name">Name of the parameter.</param>
        /// <param name="job"><typeparamref name="TJob"/> that the parameter applies to.</param>
        /// <param name="parameterId">Parameter ID that identifies the parameter type.</param>
        protected JobParameterBase(Guid id, string name, TJob job, Guid parameterId)
            : this(id, parameterId)
        {
            Name = name;
            Job = job;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobParameterBase{TJob}"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="name">Name of the parameter.</param>
        /// <param name="job"><typeparamref name="TJob"/> that the parameter applies to.</param>
        /// <param name="parameterType">Parameter type.</param>
        /// <param name="parameterId">Parameter ID that identifies the parameter type.</param>
        protected JobParameterBase(Guid id, string name, TJob job, Type parameterType, Guid parameterId)
            : this(id, name, job, parameterId)
        {
            ParameterType = parameterType;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return (obj == null) || !(obj is IJobParameter) ? false : Equals((IJobParameter)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IJobParameter obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IJobParameter x, IJobParameter y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase)
                    && ((x.Job == null && y.Job == null) || (x.Job != null && x.Job.Equals(y.Job)))
                    && ((x.ParameterType == null && y.ParameterType == null) || (x.ParameterType != null && x.ParameterType.Equals(y.ParameterType)))
                    && (x.ParameterID.Equals(y.ParameterID));
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
        /// <param name="obj"><see cref="IJobParameter"/> object to get the hash code for.</param>
        /// <returns>Hash code for the current object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IJobParameter obj)
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
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(Name) ? base.ToString() : Name + (ParameterType != null ? " " + ParameterType.AssemblyQualifiedName : String.Empty);
        }
    }
}
