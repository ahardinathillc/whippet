using System;
using FluentNHibernate.Cfg;

namespace Athi.Whippet.Data.NHibernate.FluentNHibernate
{
    /// <summary>
    /// Base class for mapping classes that manually map Fluent entities. This class must be inherited.
    /// </summary>
    public abstract class WhippetManualFluentMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetManualFluentMapper"/> class with no arguments.
        /// </summary>
        private WhippetManualFluentMapper()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetManualFluentMapper"/> class with the specified <see cref="MappingConfiguration"/> that will register the mappings.
        /// </summary>
        /// <param name="mappingConfig"><see cref="MappingConfiguration"/> that will register the mappings.</param>
        /// <exception cref="ArgumentNullException" />
        protected WhippetManualFluentMapper(MappingConfiguration mappingConfig)
            : this()
        {
            ArgumentNullException.ThrowIfNull(mappingConfig);
            MapEntities(mappingConfig);
        }

        /// <summary>
        /// Configures entities for mapping in NHibernate. This method must be overridden.
        /// </summary>
        /// <param name="mappingConfig"><see cref="MappingConfiguration"/> that will register the mappings.</param>
        protected abstract void MapEntities(MappingConfiguration mappingConfig);
    }
}

