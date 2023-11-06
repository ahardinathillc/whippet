using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NHibernate;
using NHibernate.Linq.Functions;

namespace Athi.Whippet.Data.NHibernate
{
    /// <summary>
    /// Provides a registry of all LINQ-to-SQL generators for NHibernate. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetLinqToSqlGeneratorRegistry : DefaultLinqToHqlGeneratorsRegistry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetLinqToSqlGeneratorRegistry"/> class with no arguments.
        /// </summary>
        public WhippetLinqToSqlGeneratorRegistry()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetLinqToSqlGeneratorRegistry"/> class with the specified generators.
        /// </summary>
        /// <param name="runtimeGenerators"><see cref="IEnumerable{T}"/> collection of <see cref="IRuntimeMethodHqlGenerator"/> objects.</param>
        /// <param name="methodGenerators"><see cref="IEnumerable{T}"/> collection of <see cref="MethodInfo"/> objects and their associated <see cref="IHqlGeneratorForMethod"/> instances.</param>
        /// <param name="propertyGenerators"><see cref="IEnumerable{T}"/> collection of <see cref="MemberInfo"/> objects and their associated <see cref="IHqlGeneratorForProperty"/> instances.</param>
        public WhippetLinqToSqlGeneratorRegistry(IEnumerable<IRuntimeMethodHqlGenerator> runtimeGenerators, IEnumerable<KeyValuePair<MethodInfo, IHqlGeneratorForMethod>> methodGenerators, IEnumerable<KeyValuePair<MemberInfo, IHqlGeneratorForProperty>> propertyGenerators)
            : this()
        {
            if (runtimeGenerators != null && runtimeGenerators.Any())
            {
                foreach (IRuntimeMethodHqlGenerator rg in runtimeGenerators)
                {
                    RegisterGenerator(rg);
                }
            }

            if (methodGenerators != null && methodGenerators.Any())
            {
                foreach (KeyValuePair<MethodInfo, IHqlGeneratorForMethod> mg in methodGenerators)
                {
                    RegisterGenerator(mg.Key, mg.Value);
                }
            }

            if (propertyGenerators != null && propertyGenerators.Any())
            {
                foreach (KeyValuePair<MemberInfo, IHqlGeneratorForProperty> pg in propertyGenerators)
                {
                    RegisterGenerator(pg.Key, pg.Value);
                }
            }
        }
    }
}

