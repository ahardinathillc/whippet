using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.EntityMappings;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes
{
    /// <summary>
    /// Provides mapping support for Fluent NHibernate entities by being invoked by <see cref="FluentNHibernate.Cfg.FluentMappingsContainer.AddFromAssembly(System.Reflection.Assembly)"/>. This class must be inherited.
    /// </summary>
    public sealed class FluentEntityMapper : WhippetManualFluentMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FluentEntityMapper"/> class with the specified <see cref="MappingConfiguration"/>.
        /// </summary>
        /// <param name="mappingConfig"><see cref="MappingConfiguration"/> that will register the mappings.</param>
        /// <exception cref="ArgumentNullException" />
        public FluentEntityMapper(MappingConfiguration mappingConfig)
            : base(mappingConfig)
        { }

        /// <summary>
        /// Configures entities for mapping in NHibernate. This method must be overridden.
        /// </summary>
        /// <param name="mappingConfig"><see cref="MappingConfiguration"/> that will register the mappings.</param>
        protected override void MapEntities(MappingConfiguration mappingConfig)
        {
            mappingConfig.FluentMappings.Add<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheMap>();
            mappingConfig.FluentMappings.Add<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryMap>();
        }
    }
}
