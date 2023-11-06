using System;
using System.Collections.Generic;
using NHibernate.Dialect.Function;

namespace Athi.Whippet.Data.NHibernate
{
    /// <summary>
    /// Base class for all NHibernate HQL generator indexes. This class must be inherited.
    /// </summary>
    public abstract class NHibernateHqlGeneratorIndexBase
    {
        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> of the function names and their associated <see cref="SQLFunctionTemplate"/> objects. This property is read-only. This property must be overridden.
        /// </summary>
        public abstract IReadOnlyDictionary<string, SQLFunctionTemplate> GeneratedFunctions
        { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernateHqlGeneratorIndexBase"/> class with no arguments.
        /// </summary>
        protected NHibernateHqlGeneratorIndexBase()
        { }
    }
}

