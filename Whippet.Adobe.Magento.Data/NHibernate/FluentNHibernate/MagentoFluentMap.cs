using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate;
using FluentNHibernate.Mapping;
using FluentNHibernate.MappingModel;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Data.NHibernate.FluentNHibernate
{
    /// <summary>
    /// Base class for all <see cref="IMagentoEntity"/> mappings. This class must be inherited.
    /// </summary>
    /// <typeparam name="T"><see cref="IMagentoEntity"/> object that is to be mapped.</typeparam>
    /// <remarks>See https://github.com/nhibernate/fluent-nhibernate/wiki/Fluent-mapping for more information.</remarks>
    public abstract class MagentoFluentMap<T> : ClassMap<T>, IMappingProvider where T : IMagentoEntity, new()
    {
        private static object _syncRoot;

        /// <summary>
        /// Gets an <see cref="object"/> instance used for invoking object extension methods. This property is read-only.
        /// </summary>
        protected static object ObjectExtensionMethods
        {
            get
            {
                if (_syncRoot == null)
                {
                    _syncRoot = new object();
                }

                return _syncRoot;
            }
        }

        /// <summary>
        /// Gets the mapping's table. This property is read-only.
        /// </summary>
        public string TableName
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoFluentMap{T}"/> class with no arguments. Will default the primary key to <see cref="DefaultPrimaryKeyColumnName"/>.
        /// </summary>
        private MagentoFluentMap()
            : this(String.Empty)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoFluentMap{T}"/> class with the specified parameters.
        /// </summary>
        /// <param name="table">Name of the table the entity is bound to.</param>
        protected MagentoFluentMap(string table)
            : base()
        {
            if (!String.IsNullOrWhiteSpace(table))
            {
                Table(table);
            }

            TableName = table;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoFluentMap{T}"/> class with the specified attribute store and mapping providers.
        /// </summary>
        /// <param name="attributes">Attributes to apply to the entity.</param>
        /// <param name="providers">Mapping providers.</param>
        protected MagentoFluentMap(AttributeStore attributes, MappingProviderStore providers)
            : base(attributes, providers)
        { }
    }
}
