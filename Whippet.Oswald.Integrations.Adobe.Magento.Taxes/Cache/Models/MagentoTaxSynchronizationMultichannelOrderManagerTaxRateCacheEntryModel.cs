using System;
using Newtonsoft.Json;
using NodaTime;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Data;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Exports;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Exports.Models;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Models
{
    /// <summary>
    /// Provides a data model for entries in a <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>. This class cannot be inherited.
    /// </summary>
    public sealed class MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel : IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry, IEqualityComparer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>, IMultichannelOrderManagerTaxRateExport, IJsonObject
    {
        private IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry _internalEntry;
        private MultichannelOrderManagerTaxRateExportModel _internalRateModel;

        /// <summary>
        /// Gets or sets the internal <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> object.
        /// </summary>
        private IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry InternalEntry
        {
            get
            {
                if (_internalEntry == null)
                {
                    _internalEntry = new MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry();
                }

                return _internalEntry;
            }
            set
            {
                _internalEntry = value;
            }
        }

        /// <summary>
        /// Gets or sets the internal <see cref="MultichannelOrderManagerTaxRateExportModel"/> object.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        private MultichannelOrderManagerTaxRateExportModel InternalRateModel
        {
            get
            {
                return _internalRateModel;
            }
            set
            {
                ArgumentNullException.ThrowIfNull(value);
                _internalRateModel = value;
            }
        }

        /// <summary>
        /// Gets or sets the row number of the cache entry.
        /// </summary>
        [JsonProperty("rowNumber")]
        public int RowNumber
        {
            get
            {
                return InternalEntry.RowNumber;
            }
            set
            {
                InternalEntry.RowNumber = value;
            }
        }
        
        /// <summary>
        /// Gets the unique ID of the cache entry. This property is read-only.
        /// </summary>
        [JsonProperty("id")]
        public Guid EntryID
        {
            get
            {
                return ((IWhippetEntity)(this)).ID;
            }
        }

        /// <summary>
        /// Gets or sets the unique ID of the cache entry.
        /// </summary>
        Guid IWhippetEntity.ID
        {
            get
            {
                return InternalEntry.ID;
            }
            set
            {
                InternalEntry.ID = value;
            }
        }

        /// <summary>
        /// JSON identifier that signals that this model is a cache entry. This property is read-only.
        /// </summary>
        [JsonProperty("isCacheEntry")]
        public bool IsCacheEntry
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets or sets the ID of the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        [JsonProperty("cacheId")]
        public Guid CacheID
        {
            get
            {
                return InternalEntry.Cache.ID;
            }
            set
            {
                InternalEntry.Cache.ID = value;
            }
        }

        /// <summary>
        /// Gets or sets the source <see cref="IMultichannelOrderManagerServer"/> where the tax data for MOM came from.
        /// </summary>
        public IMultichannelOrderManagerServer MultichannelOrderManagerSourceServer
        {
            get
            {
                return InternalEntry.Server;
            }
            set
            {
                InternalRateModel.Server = value;
                InternalEntry.Server = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IMultichannelOrderManagerServer"/> that the export was generated from.
        /// </summary>
        IMultichannelOrderManagerServer IMultichannelOrderManagerTaxRateExport.Server
        {
            get
            {
                return MultichannelOrderManagerSourceServer;
            }
            set
            {
                MultichannelOrderManagerSourceServer = value;
            }
        }

        /// <summary>
        /// Gets or sets the parent <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object that the entry belongs to.
        /// </summary>
        IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry.Cache
        {
            get
            {
                return InternalEntry.Cache;
            }
            set
            {
                InternalEntry.Cache = value;
            }
        }

        /// <summary>
        /// Gets or sets the tax rate.
        /// </summary>
        public decimal TaxRate
        {
            get
            {
                return InternalRateModel.TaxRate;
            }
            set
            {
                InternalRateModel.TaxRate = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IMultichannelOrderManagerPostalCode"/> that the tax rate applies to.
        /// </summary>
        public IMultichannelOrderManagerPostalCode PostalCode
        {
            get
            {
                return InternalRateModel.PostalCode;
            }
            set
            {
                InternalRateModel.PostalCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IMultichannelOrderManagerStateProvince"/> that the tax rate applies to.
        /// </summary>
        public IMultichannelOrderManagerStateProvince StateProvince
        {
            get
            {
                return InternalRateModel.StateProvince;
            }
            set
            {
                InternalRateModel.StateProvince = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IMultichannelOrderManagerCountry"/> that the tax rate applies to.
        /// </summary>
        public IMultichannelOrderManagerCountry Country
        {
            get
            {
                return InternalRateModel.Country;
            }
            set
            {
                InternalRateModel.Country = value;
            }
        }

        /// <summary>
        /// Specifies whether shipping should be taxed.
        /// </summary>
        public bool TaxShipping
        {
            get
            {
                return InternalRateModel.TaxShipping;
            }
            set
            {
                InternalRateModel.TaxShipping = value;
            }
        }

        /// <summary>
        /// Specifies whether non-tangible products (such as services, including subscription-based software) should be taxed.
        /// </summary>
        public bool TaxServices
        {
            get
            {
                return InternalRateModel.TaxServices;
            }
            set
            {
                InternalRateModel.TaxServices = value;
            }
        }

        /// <summary>
        /// Gets or sets the date the entry was created.
        /// </summary>
        public Instant EntryDate
        {
            get
            {
                return InternalEntry.EntryDate;
            }
            set
            {
                InternalEntry.EntryDate = value;
            }
        }

        /// <summary>
        /// Creates a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel"/> class with no arguments.
        /// </summary>
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel()
            : this(new MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry())
        { }

        /// <summary>
        /// Creates a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel"/> class with the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> object.
        /// </summary>
        /// <param name="entry"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }
            else
            {
                InternalEntry = entry;
                InternalRateModel = new MultichannelOrderManagerTaxRateExportModel(entry.ToTaxRateExport());
            }
        }

        /// <summary>
        /// Converts the current instance to a <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> object.
        /// </summary>
        /// <returns><see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> object.</returns>
        MultichannelOrderManagerFlattenedTaxRateExport IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry.ToTaxRateExport()
        {
            return InternalEntry.ToTaxRateExport();
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return InternalEntry.Equals(obj);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(IMultichannelOrderManagerTaxRateExport obj)
        {
            return InternalEntry.Equals(obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(IMultichannelOrderManagerTaxRateExport x, IMultichannelOrderManagerTaxRateExport y)
        {
            return InternalEntry.Equals(x, y);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry obj)
        {
            return InternalEntry.Equals(obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry x, IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry y)
        {
            return InternalEntry.Equals(x, y);
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return InternalEntry.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> object.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException" />
        public int GetHashCode(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry obj)
        {
            return InternalEntry.GetHashCode(obj);
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="IMultichannelOrderManagerTaxRateExport"/> object.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException" />
        public int GetHashCode(IMultichannelOrderManagerTaxRateExport obj)
        {
            return InternalEntry.GetHashCode(obj);
        }

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be inherited.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public string ToJson<T>() where T : IJsonSerializableObject
        {
            return this.SerializeJson(this);
        }

        public static implicit operator MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel(MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry obj)
        {
            return (obj == null) ? null : new MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel(obj);
        }

        public static implicit operator MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry(MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel obj)
        {
            return (obj == null) ? null : obj.InternalEntry.ToMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry();
        }
    }
}
