using System;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Data.NHibernate.UserTypes.NodaTime;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
    /// </summary>
    public class MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheMap : WhippetFluentMap<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>
    {
        private const string TABLE_NAME = "Oswald__Cache__Magento__MOM";

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheMap"/> class with no arguments.
        /// </summary>
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheMap()
            : base(TABLE_NAME)
        {
            Map(cache => cache.ExpirationDate).CustomType<InstantUserType>().Not.Nullable();
            Map(cache => cache.LastRefreshDate).CustomType<InstantUserType>().Not.Nullable();

            References<WhippetTenant>(cache => cache.Tenant).Not.Nullable().LazyLoad(Laziness.False);
            References<MultichannelOrderManagerServer>(cache => cache.SourceServer).Not.Nullable().LazyLoad(Laziness.False);
        }
    }
}
