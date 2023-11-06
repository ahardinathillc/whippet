using System;
using Athi.Whippet.Data;

namespace Athi.Whippet.Jobs
{
    /// <summary>
    /// Represents a parameter for an <see cref="IJob"/> in Whippet.
    /// </summary>
    public interface IJobParameter : IWhippetEntity, IEqualityComparer<IJobParameter>
    {
        /// <summary>
        /// Gets the parameter name. This property is read-only.
        /// </summary>
        string Name
        { get; }

        /// <summary>
        /// Gets or sets the <see cref="IJob"/> that the parameter applies to.
        /// </summary>
        /// <exception cref="InvalidCastException" />
        public IJob Job
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Type"/> of the parameter. How it is rendered on the view is left up to the caller.
        /// </summary>
        public Type ParameterType
        { get; set; }

        /// <summary>
        /// Gets the unique constant ID of the parameter which identifies its type. This property is read-only.
        /// </summary>
        public Guid ParameterID
        { get; }
    }
}

