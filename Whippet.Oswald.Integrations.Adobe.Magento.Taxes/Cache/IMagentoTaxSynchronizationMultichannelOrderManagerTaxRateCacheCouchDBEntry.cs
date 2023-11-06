using System;
using NodaTime;
using Athi.Whippet.Json;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Database.NoSQL;
using Athi.Whippet.Data.Database.NoSQL.Apache.CouchDB;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache
{
    /// <summary>
    /// Represents an entry in an Apache CouchDB <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> data store.
    /// </summary>
    public interface IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry : IWhippetCouchDocument, IWhippetEntity, IWhippetNoSQLEntity, IJsonObject, IWhippetCloneable, ICloneable
    {
        /// <summary>
        /// Gets or sets the database row number for the entry.
        /// </summary>
        int RowNumber
        { get; set; }
        
        /// <summary>
        /// Gets the JSON representation of the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> object to store in the CouchDB instance. This property is read-only.
        /// </summary>
        string Json
        { get; }

        /// <summary>
        /// Gets the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> ID that the entry is assigned to. This property is read-only.
        /// </summary>
        Guid CacheID
        { get; }
    }
}
