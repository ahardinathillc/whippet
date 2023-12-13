using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Json;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Exports;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache
{
    /// <summary>
    /// Represents an entry in a <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
    /// </summary>
    public class MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry : WhippetEntity, IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry, IEqualityComparer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>, IMultichannelOrderManagerTaxRateExport
    {
        private MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache _cache;
        private MultichannelOrderManagerFlattenedTaxRateExport _export;

        /// <summary>
        /// Gets or sets the internal <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> object.
        /// </summary>
        private MultichannelOrderManagerFlattenedTaxRateExport Export
        {
            get
            {
                if (_export == null)
                {
                    _export = new MultichannelOrderManagerFlattenedTaxRateExport();
                }

                return _export;
            }
            set
            {
                _export = value;
            }
        }

        /// <summary>
        /// Gets or sets the parent <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object that the entry belongs to.
        /// </summary>
        public virtual MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache Cache
        {
            get
            {
                if (_cache == null)
                {
                    _cache = new MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache();
                }

                return _cache;
            }
            set
            {
                _cache = value;
            }
        }

        /// <summary>
        /// Gets or sets the parent <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object that the entry belongs to.
        /// </summary>
        IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry.Cache
        {
            get
            {
                return Cache;
            }
            set
            {
                Cache = value.ToMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache();
            }
        }

        /// <summary>
        /// Gets or sets the database row number of the entry.
        /// </summary>
        public virtual int RowNumber
        { get; set; }
        
        /// <summary>
        /// Gets or sets the tax rate.
        /// </summary>
        public virtual decimal TaxRate
        {
            get
            {
                return Export.TaxRate;
            }
            set
            {
                Export.TaxRate = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="MultichannelOrderManagerPostalCode"/> that the tax rate applies to.
        /// </summary>
        public virtual MultichannelOrderManagerPostalCode PostalCode
        {
            get
            {
                return Export.PostalCode;
            }
            set
            {
                Export.PostalCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IMultichannelOrderManagerPostalCode"/> that the tax rate applies to.
        /// </summary>
        IMultichannelOrderManagerPostalCode IMultichannelOrderManagerTaxRateExport.PostalCode
        {
            get
            {
                return ((IMultichannelOrderManagerTaxRateExport)(Export)).PostalCode;
            }
            set
            {
                ((IMultichannelOrderManagerTaxRateExport)(Export)).PostalCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="MultichannelOrderManagerStateProvince"/> that the tax rate applies to.
        /// </summary>
        public virtual MultichannelOrderManagerStateProvince StateProvince
        {
            get
            {
                return Export.StateProvince;
            }
            set
            {
                Export.StateProvince = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IMultichannelOrderManagerStateProvince"/> that the tax rate applies to.
        /// </summary>
        IMultichannelOrderManagerStateProvince IMultichannelOrderManagerTaxRateExport.StateProvince
        {
            get
            {
                return ((IMultichannelOrderManagerTaxRateExport)(Export)).StateProvince;
            }
            set
            {
                ((IMultichannelOrderManagerTaxRateExport)(Export)).StateProvince = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="MultichannelOrderManagerCountry"/> that the tax rate applies to.
        /// </summary>
        public virtual MultichannelOrderManagerCountry Country
        {
            get
            {
                return Export.Country;
            }
            set
            {
                Export.Country = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IMultichannelOrderManagerCountry"/> that the tax rate applies to.
        /// </summary>
        IMultichannelOrderManagerCountry IMultichannelOrderManagerTaxRateExport.Country
        {
            get
            {
                return ((IMultichannelOrderManagerTaxRateExport)(Export)).Country;
            }
            set
            {
                ((IMultichannelOrderManagerTaxRateExport)(Export)).Country = value;
            }
        }

        /// <summary>
        /// Specifies whether shipping should be taxed.
        /// </summary>
        public virtual bool TaxShipping
        {
            get
            {
                return Export.TaxShipping;
            }
            set
            {
                Export.TaxShipping = value;
            }
        }

        /// <summary>
        /// Specifies whether non-tangible products (such as services, including subscription-based software) should be taxed.
        /// </summary>
        public virtual bool TaxServices
        {
            get
            {
                return Export.TaxServices;
            }
            set
            {
                Export.TaxServices = value;
            }
        }

        /// <summary>
        /// Gets or sets the source <see cref="IMultichannelOrderManagerServer"/> where the tax data for MOM came from.
        /// </summary>
        public virtual IMultichannelOrderManagerServer MultichannelOrderManagerSourceServer
        {
            get
            {
                return ((IMultichannelOrderManagerTaxRateExport)(this)).Server;
            }
            set
            {
                ((IMultichannelOrderManagerTaxRateExport)(this)).Server = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IMultichannelOrderManagerServer"/> that the export was generated from.
        /// </summary>
        IMultichannelOrderManagerServer IMultichannelOrderManagerTaxRateExport.Server
        {
            get
            {
                return Export.Server;
            }
            set
            {
                Export.Server = value.ToMultichannelOrderManagerServer();
            }
        }

        /// <summary>
        /// Gets or sets the date the entry was created.
        /// </summary>
        public virtual Instant EntryDate
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> class with no arguments.
        /// </summary>
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the cache entry.</param>
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry(Guid id)
            : base(id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">ID of the cache entry.</param>
        /// <param name="parentCache">Parent <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> that the entry belongs to.</param>
        /// <param name="export"><see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> object.</param>
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry(Guid id, MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache parentCache, MultichannelOrderManagerFlattenedTaxRateExport export)
            : this(id, parentCache, export, Instant.FromDateTimeUtc(DateTime.UtcNow))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">ID of the cache entry.</param>
        /// <param name="parentCache">Parent <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> that the entry belongs to.</param>
        /// <param name="export"><see cref="IMultichannelOrderManagerTaxRateExport"/> object.</param>
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry(Guid id, MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache parentCache, IMultichannelOrderManagerTaxRateExport export)
            : this(id, parentCache, export, Instant.FromDateTimeUtc(DateTime.UtcNow))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">ID of the cache entry.</param>
        /// <param name="parentCache">Parent <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> that the entry belongs to.</param>
        /// <param name="export"><see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> object.</param>
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry(Guid id, MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache parentCache, MultichannelOrderManagerFlattenedTaxRateExport export, Instant entryDate)
            : this(id)
        {
            Cache = parentCache;
            Export = export;
            EntryDate = entryDate;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">ID of the cache entry.</param>
        /// <param name="parentCache">Parent <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> that the entry belongs to.</param>
        /// <param name="export"><see cref="IMultichannelOrderManagerTaxRateExport"/> object.</param>
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry(Guid id, MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache parentCache, IMultichannelOrderManagerTaxRateExport export, Instant entryDate)
            : this(id, parentCache, (export == null) ? null : new MultichannelOrderManagerFlattenedTaxRateExport(export), entryDate)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return (obj == null || (!(obj is IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry) && !(obj is IMultichannelOrderManagerTaxRateExport))) ? false : Equals((IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerTaxRateExport obj)
        {
            bool equals = false;

            if (obj is IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry)
            {
                equals = Equals((IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry)(obj));
            }

            return equals;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerTaxRateExport x, IMultichannelOrderManagerTaxRateExport y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = x.Equals(y);
            }

            return equals;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry x, IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals =
                    ((x.Cache == null && y.Cache == null) || (x.Cache != null && x.Cache.Equals(y.Cache)))
                        && ((x.Country == null && y.Country == null) || (x.Country != null && x.Country.Equals(y.Country)))
                        && ((x.PostalCode == null && y.PostalCode == null) || (x.PostalCode != null && x.PostalCode.Equals(y.PostalCode)))
                        && ((x.StateProvince == null && y.StateProvince == null) || (x.StateProvince != null && x.StateProvince.Equals(y.StateProvince)))
                        && (x.TaxRate == y.TaxRate)
                        && (x.TaxServices == y.TaxServices)
                        && (x.TaxShipping == y.TaxShipping);
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
        /// <param name="obj"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> object.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual int GetHashCode(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            return obj.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="IMultichannelOrderManagerTaxRateExport"/> object.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual int GetHashCode(IMultichannelOrderManagerTaxRateExport obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            return obj.GetHashCode();
        }

        /// <summary>
        /// Converts the current instance to a <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> object.
        /// </summary>
        /// <returns><see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> object.</returns>
        public virtual MultichannelOrderManagerFlattenedTaxRateExport ToTaxRateExport()
        {
            MultichannelOrderManagerFlattenedTaxRateExport export = new MultichannelOrderManagerFlattenedTaxRateExport(TaxRate, nameof(MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry), PostalCode, StateProvince, Country);
            export.TaxServices = TaxServices;
            export.TaxShipping = TaxShipping;
            export.Server = Export.Server.Clone<MultichannelOrderManagerServer>();

            return export;
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return TaxRate + String.Format("[{0} {1}]", PostalCode.ToString(), Country.ToString());
        }

    }
}
