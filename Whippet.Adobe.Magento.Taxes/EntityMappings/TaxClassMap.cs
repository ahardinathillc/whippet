using System;
using FluentNHibernate.Mapping;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Data.NHibernate.UserTypes.NodaTime;

namespace Athi.Whippet.Adobe.Magento.Taxes.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="TaxClass"/> objects.
    /// </summary>
    public class TaxClassMap : MagentoFluentMap<TaxClass>
    {
        private const string TABLE_NAME = "tax_class";

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxClassMap"/> class with no arguments.
        /// </summary>
        public TaxClassMap()
            : base(TABLE_NAME)
        {
            Id(tc => tc.ClassID).GeneratedBy.Increment().Column("class_id");
            Map(tc => tc.ClassName).Not.Nullable().Length(255).Column("class_name");
            Map(tc => tc.ClassType).Not.Nullable().Length(8).Default("CUSTOMER").Column("class_type");
        }
    }
}