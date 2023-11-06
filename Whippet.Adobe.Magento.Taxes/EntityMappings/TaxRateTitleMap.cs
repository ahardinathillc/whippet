using System;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Adobe.Magento.EAV;

namespace Athi.Whippet.Adobe.Magento.Taxes.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="TaxRateTitle"/> objects.
    /// </summary>
    public class TaxRateTitleMap : MagentoFluentMap<TaxRateTitle>
    {
        private const string TABLE_NAME = "tax_calculation_rate_title";

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateTitleMap"/> class with no arguments.
        /// </summary>
        public TaxRateTitleMap()
            : base(TABLE_NAME)
        {
            Id(tr => tr.ID).GeneratedBy.Increment().Column("tax_calculation_rate_title_id");
            Map(tr => tr.Value).Column("value").Not.Nullable().Length(255);

            References<Store>(tr => tr.Store).Column("store_id").Not.Nullable().LazyLoad(Laziness.False);
            References<TaxRate>(tr => tr.Rate).Column("tax_calculation_rate_id").Not.Nullable().LazyLoad(Laziness.False);
        }
    }
}
