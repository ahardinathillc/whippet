using System;
using NHibernate;
using Athi.Whippet.Data.NHibernate;
using Athi.Whippet.Localization.Addressing;
using Athi.Whippet.Localization.Addressing.Repositories;
using Athi.Whippet.Localization.Addressing.ServiceManagers;
using Athi.Whippet.ServiceManagers;

namespace Athi.Whippet.Installer.Framework.Core
{
    /// <summary>
    /// Retrieves all available entity seeds for installation. This class cannot be inherited.
    /// </summary>
    public static class EntitySeedIndex
    {
        /// <summary>
        /// Gets all entities that are to be seeded in the data store.
        /// </summary>
        /// <param name="options"><see cref="NHibernateConfigurationOptions"/> options.</param>
        /// <returns><see cref="SortedList{TKey,TValue}"/> of all entities to be seeded in the order to be executed.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static SortedList<int, ISeedServiceManager> GetSeeds(NHibernateConfigurationOptions options)
        {
            ArgumentNullException.ThrowIfNull(options);
            
            SortedList<int, ISeedServiceManager> seeds = new SortedList<int, ISeedServiceManager>();
            ISessionFactory factory = DefaultNHibernateSessionFactory.Create(options);

            seeds.Add(0, new CountryServiceManager.CountrySeedServiceManager(new CountryRepository(factory.OpenSession())));
            
            seeds.Add(1, new StateProvinceServiceManager.StateProvinceSeedServiceManager(new StateProvinceRepository(factory.OpenSession()), () =>
            {
                WhippetResultContainer<IEnumerable<ICountry>> countryResult = new WhippetResultContainer<IEnumerable<ICountry>>(WhippetResult.Success, null);
                CountryServiceManager csm = new CountryServiceManager(new CountryRepository(factory.OpenSession()));

                try
                {
                    countryResult = Task.Run(() => csm.GetCountries()).Result;
                    countryResult.ThrowIfFailed();
                }
                finally 
                {
                    if (csm != null)
                    {
                        csm.Dispose();
                        csm = null;
                    }
                }

                return countryResult.Item;
            }));
            
            seeds.Add(2, new CityServiceManager.CitySeedServiceManager(new CityRepository(factory.OpenSession()), () =>
            {
                WhippetResultContainer<IEnumerable<IStateProvince>> stateResult = new WhippetResultContainer<IEnumerable<IStateProvince>>(WhippetResult.Success, null);
                StateProvinceServiceManager spm = new StateProvinceServiceManager(new StateProvinceRepository(factory.OpenSession()));

                try
                {
                    stateResult = Task.Run(() => spm.GetAllStateProvinces()).Result;
                    stateResult.ThrowIfFailed();
                }
                finally 
                {
                    if (spm != null)
                    {
                        spm.Dispose();
                        spm = null;
                    }
                }

                return stateResult.Item;
            }));
            
            seeds.Add(3, new PostalCodeServiceManager.PostalCodeSeedServiceManager(new PostalCodeRepository(factory.OpenSession()), () =>
            {
                WhippetResultContainer<IEnumerable<ICity>> cityResult = new WhippetResultContainer<IEnumerable<ICity>>(WhippetResult.Success, null);
                CityServiceManager csm = new CityServiceManager(new CityRepository(factory.OpenSession()));

                try
                {
                    cityResult = Task.Run(() => csm.GetCities()).Result;
                    cityResult.ThrowIfFailed();
                }
                finally 
                {
                    if (csm != null)
                    {
                        csm.Dispose();
                        csm = null;
                    }
                }

                return cityResult.Item;
            }));
            
            return seeds;
        }        
    }
}
