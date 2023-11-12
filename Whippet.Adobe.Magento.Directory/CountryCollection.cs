using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Athi.Whippet.Adobe.Magento.Directory
{
    /// <summary>
    /// Represents a read-only collection of <see cref="ICountry"/> objects and their respective <see cref="IRegion"/> objects. This class cannot be inherited.
    /// </summary>
    /// <typeparam name="TCountry"><see cref="ICountry"/> type represented in the collection.</typeparam>
    [Serializable]
    public sealed class CountryCollection<TCountry> : ReadOnlyDictionary<TCountry, IEnumerable<IRegion>>, IDictionary<TCountry, IEnumerable<IRegion>>, IDictionary, IReadOnlyDictionary<TCountry, IEnumerable<IRegion>>
        where TCountry : ICountry, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountryCollection{TCountry,IRegion}"/> class with no arguments.
        /// </summary>
        /// <param name="collection"><see cref="IDictionary{TCountry, IRegion}"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CountryCollection(IDictionary<TCountry, IEnumerable<IRegion>> collection)
            : base(collection)
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CountryCollection{TCountry,IRegion}"/> class with no arguments.
        /// </summary>
        /// <param name="countries"></param>
        public CountryCollection(IEnumerable<TCountry> countries)
            : this(MakeDictionary(countries))
        { }

        /// <summary>
        /// Indicates whether the specified <typeparamref nname="TCountry"/> has regions.
        /// </summary>
        /// <param name="country"><typeparamref name="TCountry"/> object.</param>
        /// <returns><see langword="true"/> if the country contains regions; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="KeyNotFoundException"></exception>
        public bool HasRegions(TCountry country)
        {
            return (this[country] != null) && (this[country].Any());
        }

        /// <summary>
        /// Creates an <see cref="IDictionary{TKey,TValue}"/> based on the specified <see cref="IEnumerable{T}"/> collection of <typeparamref name="TCountry"/> objects.
        /// </summary>
        /// <param name="countries"><see cref="IEnumerable{T}"/> collections of <typeparamref name="TCountry"/> objects.</param>
        /// <returns><see cref="IDictionary{TKey,TValue}"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        private static IDictionary<TCountry, IEnumerable<IRegion>> MakeDictionary(IEnumerable<TCountry> countries)
        {
            if (countries == null)
            {
                throw new ArgumentNullException(nameof(countries));
            }
            else
            {
                Dictionary<TCountry, IEnumerable<IRegion>> dict = new Dictionary<TCountry, IEnumerable<IRegion>>(countries.Count());
                IList<IRegion> regions = null;
                
                foreach (TCountry country in countries)
                {
                    if (country.AvailableRegions != null && country.AvailableRegions.Count() > 0)
                    {
                        regions = new List<IRegion>(country.AvailableRegions.Select(r => r));

                        if (country.AvailableRegions != null && country.AvailableRegions.Any())
                        {
                            regions = new List<IRegion>(country.AvailableRegions);
                        }
                    }

                    dict.Add(country, (regions == null) ? null : new ReadOnlyCollection<IRegion>(regions));
                }

                return dict;
            }
        }
    }
}
