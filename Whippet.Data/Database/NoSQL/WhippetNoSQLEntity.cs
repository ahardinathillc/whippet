using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data.Database.NoSQL
{
    /// <summary>
    /// Base class for all domain objets in Whippet that are stored in a NoSQL data store. This class must be inherited.
    /// </summary>
    public abstract class WhippetNoSQLEntity : WhippetEntity, IWhippetEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetNoSQLEntity"/> class with no arguments.
        /// </summary>
        protected WhippetNoSQLEntity()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetNoSQLEntity"/> class with the specified <see cref="Guid"/>.
        /// </summary>
        /// <param name="id"><see cref="Guid"/> value that represents the unique identifier of the entity.</param>
        protected WhippetNoSQLEntity(Guid id)
            : base(id)
        { }
    }
}
