using System;
using Athi.Whippet.Data;

namespace Athi.Whippet.SuperDuper.Data
{
    /// <summary>
    /// Base class for all Super Duper entities in Whippet. This class must be inherited.
    /// </summary>
    public abstract class SuperDuperEntity : WhippetEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuperDuperEntity"/> class with no arguments.
        /// </summary>
        protected SuperDuperEntity()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SuperDuperEntity"/> class with the specified <see cref="Guid"/>.
        /// </summary>
        /// <param name="id"><see cref="Guid"/> value that represents the unique identifier of the entity.</param>
        protected SuperDuperEntity(Guid id)
            : base(id)
        { }
    }
}
