using System;
using FluentNHibernate.Mapping;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Data.NHibernate.UserTypes.NodaTime;
using Athi.Whippet.Adobe.Magento.Taxes;

namespace Athi.Whippet.Adobe.Magento.Customer.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="CustomerGroup"/> objects.
    /// </summary>
    public class CustomerGroupMap : MagentoFluentMap<CustomerGroup>
    {
        private const string TABLE_NAME = "customer_group";

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerGroupMap"/> class with no arguments.
        /// </summary>
        public CustomerGroupMap()
            : base(TABLE_NAME)
        {
            Id(cg => cg.GroupID).GeneratedBy.Increment().Column("customer_group_id");
            Map(cg => cg.GroupCode).Not.Nullable().Length(32).Column("customer_group_code");

            References<TaxClass>(cg => cg.TaxClass).Not.Nullable().Column("tax_class_id");
        }
    }
}
