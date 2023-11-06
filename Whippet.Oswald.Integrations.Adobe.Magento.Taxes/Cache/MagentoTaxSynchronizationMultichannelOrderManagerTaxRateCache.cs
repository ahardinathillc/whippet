using System;
using System.Text;
using System.ComponentModel;
using NodaTime;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache
{
    /// <summary>
    /// Represents a database cache for storing Magento tax rate information.
    /// </summary>
    public class MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache : WhippetEntity, IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache, IEqualityComparer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>, IJsonObject
    {
        private const int DEFAULT_SPREAD = 30;

        private WhippetTenant _tenant;
        private MultichannelOrderManagerServer _server;

        private Instant? _lastRefreshDate;
        private Instant? _expirationDate;

        /// <summary>
        /// Gets or sets the <see cref="WhippetTenant"/> that the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> belongs to.
        /// </summary>
        public virtual WhippetTenant Tenant
        {
            get
            {
                if (_tenant == null)
                {
                    _tenant = new WhippetTenant();
                }

                return _tenant;
            }
            set
            {
                _tenant = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> that the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> belongs to.
        /// </summary>
        IWhippetTenant IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache.Tenant
        {
            get
            {
                return Tenant;
            }
            set
            {
                Tenant = value?.ToWhippetTenant();
            }
        }

        /// <summary>
        /// Gets or sets the last date and time (in UTC format) the cache was refreshed. The default value is <see cref="DateTime.UtcNow"/>.
        /// </summary>
        public virtual Instant LastRefreshDate
        {
            get
            {
                if (!_lastRefreshDate.HasValue)
                {
                    _lastRefreshDate = Instant.FromDateTimeUtc(DateTime.UtcNow);
                }

                return _lastRefreshDate.Value;
            }
            set
            {
                _lastRefreshDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the expiration date. The default value is thirty days from <see cref="LastRefreshDate"/>.
        /// </summary>
        public virtual Instant ExpirationDate
        {
            get
            {
                if (!_expirationDate.HasValue)
                {
                    _expirationDate = Instant.FromDateTimeUtc(LastRefreshDate.ToDateTimeUtc().AddDays(DEFAULT_SPREAD));
                }

                return _expirationDate.Value;
            }
            set
            {
                _expirationDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the Multichannel Order Manager server where the tax rates are loaded from.
        /// </summary>
        public virtual MultichannelOrderManagerServer SourceServer
        {
            get
            {
                if (_server == null)
                {
                    _server = new MultichannelOrderManagerServer();
                }

                return _server;
            }
            set
            {
                _server = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> class with no arguments.
        /// </summary>
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the cache.</param>
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache(Guid id)
            : base(id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">ID of the cache.</param>
        /// <param name="tenant"><see cref="WhippetTenant"/> that the cache belongs to.</param>
        /// <param name="server"><see cref="MultichannelOrderManagerServer"/> that represents the unique ID of the Multichannel Order Manager server the tax rates are stored in.</param>
        /// <param name="lastRefreshDate">Date that the cache was last refreshed.</param>
        /// <param name="expirationDate">Date that the cache expires.</param>
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache(Guid id, WhippetTenant tenant, MultichannelOrderManagerServer server, Instant? lastRefreshDate = null, Instant? expirationDate = null)
            : this(id)
        {
            Tenant = tenant;
            SourceServer = server;

            if (lastRefreshDate.HasValue)
            {
                LastRefreshDate = lastRefreshDate.Value;
            }

            if (expirationDate.HasValue)
            {
                ExpirationDate = expirationDate.Value;
            }
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return (obj == null || !(obj is IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache)) ? false : Equals((IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache x, IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals =
                    x.ExpirationDate.Equals(y.ExpirationDate)
                        && x.LastRefreshDate.Equals(y.LastRefreshDate)
                        && ((x.SourceServer == null) && (y.SourceServer == null) || (x.SourceServer != null && x.SourceServer.Equals(y.SourceServer)))
                        && (((x.Tenant == null) && (y.Tenant == null)) || (x.Tenant != null && x.Tenant.Equals(y.Tenant)));
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual int GetHashCode(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            return obj.GetHashCode();
        }

        /// <summary>
        /// Creates an <see cref="Instant"/> that contains the date that the cache is set to expire.
        /// </summary>
        /// <param name="refreshDate"><see cref="Instant"/> containing the date the cache was last refreshed.</param>
        /// <param name="days">Number of days to be added (or subtracted) from <paramref name="refreshDate"/>.</param>
        /// <returns><see cref="Instant"/> representing the expiration date.</returns>
        public static Instant CalculateExpirationDate(Instant refreshDate, int days = DEFAULT_SPREAD)
        {
            return Instant.FromDateTimeUtc(refreshDate.ToDateTimeUtc().AddDays(days));
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            string cacheId = ID.ToString();

            if (Tenant != null)
            {
                cacheId = cacheId + " [" + Tenant.ToString() + "]";
            }

            if (SourceServer != null)
            {
                cacheId = cacheId + " [" + SourceServer.ToString() + "]";
            }

            return cacheId;
        }

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be inherited.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public override string ToJson<T>()
        {
            return this.SerializeJson(this);
        }
    }
}

