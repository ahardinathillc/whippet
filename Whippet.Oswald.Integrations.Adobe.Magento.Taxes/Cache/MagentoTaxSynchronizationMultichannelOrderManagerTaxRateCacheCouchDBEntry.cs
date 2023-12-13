using System;
using Newtonsoft.Json;
using Athi.Whippet.Data.Database.NoSQL.Apache.CouchDB;
using Athi.Whippet.Json.Newtonsoft.Extensions;
using Athi.Whippet.Json;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache
{
    /// <summary>
    /// Represents an <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> for storage inside CouchDB.
    /// </summary>
    public class MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry : WhippetCouchDBEntity, IWhippetCouchDocument, IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry, IWhippetCloneable, ICloneable
    {
        /// <summary>
        /// Gets or sets the row number of the entry.
        /// </summary>
        [JsonProperty("rowNumber")]
        public virtual int RowNumber
        { get; set; }
        
        /// <summary>
        /// Gets the JSON representation of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> object to store in the CouchDB instance. This property is read-only.
        /// </summary>
        [JsonProperty("json")]
        public virtual string Json
        { get; protected set; }

        /// <summary>
        /// Gets the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> ID that the entry is assigned to. This property is read-only.
        /// </summary>
        [JsonProperty("cacheID")]
        public virtual Guid CacheID
        { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> class with no arguments.
        /// </summary>
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> class with the specified <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> object.
        /// </summary>
        /// <param name="entry"><see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry(MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry entry)
            : base(Guid.NewGuid())
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }
            else
            {
                //Json = entry.ToJson<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>();

                if (entry.Cache != null)
                {
                    CacheID = entry.Cache.ID;
                }

                RowNumber = entry.RowNumber;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> class with the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object.
        /// </summary>
        /// <param name="entry"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry entry)
            : base(Guid.NewGuid())
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }
            else
            {
                Json = entry.Json;
                CacheID = entry.CacheID;
                RowNumber = entry.RowNumber;
                Rev = entry.Rev;
                Id = Guid.Parse(entry.ID).ToString();
            }
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        object ICloneable.Clone()
        {
            MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry entry = new MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry();
            entry.CacheID = CacheID;
            entry.Id = Id;
            entry.Json = Json;
            entry.Rev = Rev;
            entry.RowNumber = RowNumber;
           
            return entry;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object with the optional <see cref="Guid"/> that represents the user ID of the user who instantiated the new instance.
        /// </summary>
        /// <typeparam name="TObject">Type of object to return from the operation.</typeparam>
        /// <param name="createdBy"><see cref="Guid"/> ID of the user who instantiated the new instance.</param>
        /// <returns>Object of type <typeparamref name="TObject"/>.</returns>
        public virtual TObject Clone<TObject>(Guid? createdBy = null)
        {
            return (TObject)(((ICloneable)(this)).Clone());
        }

    }
}
