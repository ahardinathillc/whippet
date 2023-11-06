using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Athi.Whippet.Data.NHibernate.Extensions;
using Athi.Whippet.Data;
using Athi.Whippet.Localization.Addressing.EntityMappings;
using Athi.Whippet.Localization;
using Athi.Whippet.Localization.Addressing.Repositories;
using Athi.Whippet.Localization.Addressing.Installer.ResourceFiles;

namespace Athi.Whippet.Localization.Addressing.Installer
{
    /// <summary>
    /// Provides seeding functionality for <see cref="Country"/> objects. This class cannot be inherited.
    /// </summary>
    internal sealed class CountrySeed : WhippetEntitySeed<Country>, IWhippetEntitySeed, IWhippetEntitySeed<Country>, ICountrySeed
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountrySeed"/> class with no arguments.
        /// </summary>
        private CountrySeed()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CountrySeed"/> class.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> that provides context for the data store.</param>
        /// <param name="statusUpdater"><see cref="ProgressDelegate"/> used to report the status of the operation.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CountrySeed(ISession context, ProgressDelegate statusUpdater = null)
            : base(context, statusUpdater)
        { }

        /// <summary>
        /// Seeds the current data store provided by NHibernate given the specified <see cref="ISession"/>.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> that provides context for the data store.</param>
        /// <param name="statusUpdater"><see cref="ProgressDelegate"/> used to report the status of the operation.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override WhippetResult Seed(ISession context, ProgressDelegate statusUpdater = null)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;
                Exception exceptionEncountered = null;
                IEnumerable<WhippetResultContainer<Country>> resultContainers = null;

                try
                {
                    resultContainers = Seed(new CountryRepository(context), statusUpdater);

                    if (resultContainers.Any(rc => !rc.IsSuccess))
                    {
                        exceptionEncountered = resultContainers.Where(rc => rc.Exception != null && !rc.IsSuccess).FirstOrDefault()?.Exception;
                        result = new WhippetResult(WhippetResultSeverity.Failure, exception: exceptionEncountered, resultObject: resultContainers);
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResult(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Seeds the current data store provided by NHibernate given the specified <see cref="ISession"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetEntityRepository{TEntity, TKey}"/> that is the backing data store where the <see cref="Country"/> entities will be stored.</param>
        /// <param name="statusUpdater"><see cref="Delegate"/> that provides real-time updates to each record being updated.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the seed action with each <see cref="IWhippetEntity"/> object(s).</returns>
        /// <exception cref="ArgumentNullException" />
        public override IEnumerable<WhippetResultContainer<Country>> Seed(IWhippetEntityRepository<Country, Guid> repository, ProgressDelegate statusUpdater = null)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            else
            {
                int index_guid;
                int index_name;
                int index_twoLetterISOAbbreviation;
                int index_threeLetterISOAbbreviation;
                int index_iso3166NumericCode;

                string rawCountryList = LoadRawCountryList(out index_guid, out index_name, out index_twoLetterISOAbbreviation, out index_threeLetterISOAbbreviation, out index_iso3166NumericCode);
                string query = null;

                string param_id = "@ID";
                string param_name = "@Name";

                string[] countryEntries = null;
                string[] countryPieces = null;

                Dictionary<string, object> parameters = null;

                ProgressDelegateManager rawCountryStatusManager = null;
                ProgressDelegateManager existingCountryStatusManager = null;

                List<WhippetResultContainer<Country>> results = null;
                List<Country> countries = null;

                WhippetResult result = WhippetResult.Success;

                WhippetResultContainer<IEnumerable<Country>> existingCountries = null;

                Country country = null;
                CountryMap countryMap = null;

                ITransaction transaction = null;

                try
                {
                    if (!String.IsNullOrWhiteSpace(rawCountryList))
                    {
                        countryEntries = rawCountryList.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                        if (countryEntries != null && countryEntries.Any())
                        {
                            countries = new List<Country>(countryEntries.Length);
                            rawCountryStatusManager = new ProgressDelegateManager(0, countryEntries.Length, statusUpdater);

                            foreach (string entry in countryEntries)
                            {
                                countryPieces = entry.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                                country = new Country(new Guid(countryPieces[index_guid]), countryPieces[index_name], countryPieces[index_twoLetterISOAbbreviation]);

                                countries.Add(country);

                                rawCountryStatusManager.Advance(LocalizedStringResourceLoader.GetResource(typeof(CountrySeed), ResourceIndex.ReadCountry, new[] { country.ToString() }), WhippetResultSeverity.Info);
                            }
                        }
                    }

                    existingCountries = repository.GetAll();

                    if (existingCountries.IsSuccess)
                    {
                        results = new List<WhippetResultContainer<Country>>();
                        transaction = repository.BeginTransaction();

                        if (existingCountries.Item.Any())
                        {
                            existingCountryStatusManager = new ProgressDelegateManager(0, existingCountries.Item.Count(), statusUpdater);

                            if (countries != null)
                            {
                                foreach (Country cntry in countries)
                                {
                                    if (!existingCountries.Item.Contains(cntry, CountryComparer.Instance))
                                    {
                                        results.Add(new WhippetResultContainer<Country>(repository.Create(cntry), cntry));
                                    }

                                    existingCountryStatusManager.Advance(LocalizedStringResourceLoader.GetResource(typeof(CountrySeed), ResourceIndex.CountryExists, new[] { cntry.ToString() }), WhippetResultSeverity.Info);
                                }
                            }
                        }
                        else
                        {
                            if (countries != null)
                            {
                                existingCountryStatusManager = new ProgressDelegateManager(0, countries.Count, statusUpdater);

                                countries.ForEach(c =>
                                {
                                    results.Add(new WhippetResultContainer<Country>(repository.Create(c), c));
                                    existingCountryStatusManager.Advance(c.ToString());
                                });

                                repository.Commit();
                            }
                        }

                        transaction.Commit();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResult(e);
                }
                finally
                {
                    if (transaction != null)
                    {
                        transaction.Dispose();
                        transaction = null;
                    }
                }

                // update the IDs

                if (result.IsSuccess)
                {
                    try
                    {
                        // reload the raw country list -- we'll need it to get the GUIDs
                        rawCountryList = LoadRawCountryList(out index_guid, out index_name, out index_twoLetterISOAbbreviation, out index_threeLetterISOAbbreviation, out index_iso3166NumericCode);

                        if (!String.IsNullOrWhiteSpace(rawCountryList))
                        {
                            countryMap = new CountryMap();
                            countryEntries = rawCountryList.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                            if (countryEntries != null && countryEntries.Any())
                            {
                                countries = new List<Country>(countryEntries.Length);

                                foreach (string entry in countryEntries)
                                {
                                    parameters = new Dictionary<string, object>();

                                    countryPieces = entry.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                    country = new Country(new Guid(countryPieces[index_guid]), countryPieces[index_name], countryPieces[index_twoLetterISOAbbreviation]);

                                    query = String.Format("UPDATE {0} SET {1}={2} WHERE {3}={4}",
                                        countryMap.FullyQualifiedTableName,
                                        nameof(country.ID),
                                        param_id,
                                        nameof(country.Name),
                                        param_name);

                                    parameters.Add(param_id, countryPieces[index_guid]);
                                    parameters.Add(param_name, countryPieces[index_name]);

                                    Context.ExecuteRawUpdate(query, parameters);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        result = new WhippetResult(e);
                    }
                }

                if (result.IsSuccess)
                {
                    if (results == null)
                    {
                        results = new List<WhippetResultContainer<Country>>();
                    }
                }
                else
                {
                    results = new List<WhippetResultContainer<Country>>(new[] { new WhippetResultContainer<Country>(result, null) });
                }

                return results.AsReadOnly();
            }
        }

        /// <summary>
        /// Loads the raw listing of all countries in Whippet. All country entries are semicolon delimited with individual pieces comma delimited.
        /// </summary>
        /// <param name="index_guid">Index of the GUID ID of the country.</param>
        /// <param name="index_name">Index of the country name.</param>
        /// <param name="index_twoLetterISOAbbreviation">Index of the country's two letter ISO abbreviation.</param>
        /// <param name="index_threeLetterISOAbbreviation">Index of the country's three letter ISO abbreviation.</param>
        /// <param name="index_iso3166NumericCode">Index of the country's ISO 3166 numeric code.</param>
        /// <returns>Raw country list.</returns>
        private static string LoadRawCountryList(out int index_guid, out int index_name, out int index_twoLetterISOAbbreviation, out int index_threeLetterISOAbbreviation, out int index_iso3166NumericCode)
        {
            //5a2da7c2-4338-4e17-98f5-49b54f13f6d3,Afghanistan,AF,AFG,4
            // Country entires are ID, NAME, 2-LETTER ISO ABBR, 3-LETTER ISO ABBR, ISO-3166 NUMERIC CODE

            index_guid = 0;
            index_name = 1;
            index_twoLetterISOAbbreviation = 2;
            index_threeLetterISOAbbreviation = 3;
            index_iso3166NumericCode = 4;

            return LocalizedStringResourceLoader.GetResource(typeof(CountrySeed), ResourceIndex.CountryList);
        }
    }
}

