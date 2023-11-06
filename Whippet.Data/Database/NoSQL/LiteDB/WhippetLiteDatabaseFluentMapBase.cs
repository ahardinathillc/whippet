using System;
using LiteDB;

namespace Athi.Whippet.Data.Database.NoSQL.LiteDB
{
    /// <summary>
    /// Base class for all LiteDB <see cref="BsonMapper"/> fluent mappings. This class must be inherited.
    /// </summary>
    public abstract class WhippetLiteDatabaseFluentMapBase
    {
        /// <summary>
        /// Gets the global <see cref="BsonMapper"/>. This property is read-only.
        /// </summary>
        protected virtual BsonMapper Mapper
        {
            get
            {
                return BsonMapper.Global;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetLiteDatabaseFluentMapBase"/> class with no arguments.
        /// </summary>
        protected WhippetLiteDatabaseFluentMapBase()
        { }
    }
}

