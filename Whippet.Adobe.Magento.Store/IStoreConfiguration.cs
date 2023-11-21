using System;
using NodaTime;
using Athi.Whippet.Adobe.Magento;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Store
{
    /// <summary>
    /// Represents an <see cref="IStore"/> configuration which specifies locality, currency used, and store URLs.
    /// </summary>
    public interface IStoreConfiguration : IMagentoEntity, IEqualityComparer<IStore>, IMagentoRestEntity
    {
        /// <summary>
        /// Gets or sets the store code.
        /// </summary>
        string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the store website.
        /// </summary>
        IStoreWebsite Website
        { get; set; }

        /// <summary>
        /// Gets or sets the locale of the store.
        /// </summary>
        string Locale
        { get; set; }

        /// <summary>
        /// Gets or sets the store's currency code.
        /// </summary>
        string CurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the default display currency code.
        /// </summary>
        string DisplayCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the time zone that applies to the store.
        /// </summary>
        DateTimeZone TimeZone
        { get; set; }

        /// <summary>
        /// Gets or sets the unit of weight used by the store.
        /// </summary>
        string UnitOfWeight
        { get; set; }
        
        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey,TValue}"/> of <see cref="StoreLinkType"/> objects and their associated <see cref="StoreLinkValue"/> (mutable) values. This property is read-only.
        /// </summary>
        IReadOnlyDictionary<StoreLinkType, StoreLinkValue> Links
        { get; }
    }
}
