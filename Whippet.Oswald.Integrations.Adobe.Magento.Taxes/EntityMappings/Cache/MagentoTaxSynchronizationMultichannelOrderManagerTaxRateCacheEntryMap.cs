using System;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Data.NHibernate.UserTypes.NodaTime;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.EntityMappings.Components;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
    /// </summary>
    public class MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryMap : WhippetFluentMap<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>
    {
        private const string TABLE_NAME = "Oswald__Cache__Magento__MOM_Entry";

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryMap"/> class with no arguments.
        /// </summary>
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryMap()
            : base(TABLE_NAME)
        {
            Map(c => c.EntryDate).CustomType<InstantUserType>().Not.Nullable();
            Map(c => c.TaxRate).Not.Nullable();
            Map(c => c.TaxServices).Not.Nullable();
            Map(c => c.TaxShipping).Not.Nullable();

            Component(c => c.Country);
            Component(c => c.PostalCode);
            Component(c => c.StateProvince);

            References<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>(c => c.Cache).Not.Nullable().LazyLoad(Laziness.False);
        }
    }
}
