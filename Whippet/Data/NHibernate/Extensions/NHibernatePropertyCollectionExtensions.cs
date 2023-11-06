using System;
using NHibernate;
using NHibernateEnvironment = NHibernate.Cfg.Environment;
using NHibernate.Linq.Functions;

namespace Athi.Whippet.Data.NHibernate.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="NHibernatePropertyCollection"/> objects. This class cannot be inherited.
    /// </summary>
    public static class NHibernatePropertyCollectionExtensions
    {
        /// <summary>
        /// Adds the specified <see cref="ILinqToHqlGeneratorsRegistry"/> to the <see cref="NHibernatePropertyCollection"/>.
        /// </summary>
        /// <param name="collection"><see cref="NHibernatePropertyCollection"/> object to add the registry to.</param>
        /// <param name="registry"><see cref="ILinqToHqlGeneratorsRegistry"/> object to add.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddLinqToSqlGeneratorRegistry(this NHibernatePropertyCollection collection, ILinqToHqlGeneratorsRegistry registry)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            else if (registry == null)
            {
                throw new ArgumentNullException(nameof(registry));
            }
            else
            {
                collection.Add(NHibernateEnvironment.LinqToHqlGeneratorsRegistry, registry.GetType().AssemblyQualifiedName);
            }
        }
    }
}

