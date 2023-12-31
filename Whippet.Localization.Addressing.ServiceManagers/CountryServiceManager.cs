using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Resources.NetStandard;
using Athi.Whippet.Collections.Extensions;
using Athi.Whippet.Services;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Localization.Addressing.EntityMappings;
using Athi.Whippet.Localization.Addressing.Extensions;
using Athi.Whippet.Localization.Addressing.Repositories;
using Athi.Whippet.Localization.Addressing.ServiceManagers.Queries;
using Athi.Whippet.Localization.Addressing.ServiceManagers.Commands;
using Athi.Whippet.Localization.Addressing.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Localization.Addressing.ServiceManagers.Handlers.Commands;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="ICountry"/> domain objects.
    /// </summary>
    public class CountryServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="ICountryRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual ICountryRepository CountryRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryServiceManager"/> class with the specified <see cref="ICountryRepository"/> object.
        /// </summary>
        /// <param name="countryRepository"><see cref="ICountryRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CountryServiceManager(ICountryRepository countryRepository)
            : base()
        {
            if (countryRepository == null)
            {
                throw new ArgumentNullException(nameof(countryRepository));
            }
            else
            {
                CountryRepository = countryRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryServiceManager"/> class with the specified <see cref="ICountryRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="countryRepository"><see cref="ICountryRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CountryServiceManager(IWhippetServiceContext serviceLocator, ICountryRepository countryRepository)
            : base(serviceLocator)
        {
            if (countryRepository == null)
            {
                throw new ArgumentNullException(nameof(countryRepository));
            }
            else
            {
                CountryRepository = countryRepository;
            }
        }

        /// <summary>
        /// Gets an <see cref="ICountry"/> based on its ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="ICountry"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ICountry>> GetCountry(Guid id)
        {
            ICountryQueryHandler<GetCountryByIdQuery> handler = new GetCountryByIdQueryHandler(CountryRepository);
            WhippetResultContainer<IEnumerable<Country>> result = await handler.HandleAsync(new GetCountryByIdQuery(id));
            return new WhippetResultContainer<ICountry>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="ICountry"/> objects registered in the data store.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<ICountry>>> GetCountries()
        {
            ICountryQueryHandler<GetAllCountriesQuery> handler = new GetAllCountriesQueryHandler(CountryRepository);
            WhippetResultContainer<IEnumerable<Country>> result = await handler.HandleAsync(new GetAllCountriesQuery());
            return new WhippetResultContainer<IEnumerable<ICountry>>(result.Result, result.Item?.OrderBy(c => c.Name));
        }

        /// <summary>
        /// Retrieves the <see cref="ICountry"/> object with the specified name.
        /// </summary>
        /// <param name="name">Name of the <see cref="ICountry"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<ICountry>> GetCountryByName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            else
            {
                ICountryQueryHandler<GetCountryByNameQuery> handler = new GetCountryByNameQueryHandler(CountryRepository);
                WhippetResultContainer<IEnumerable<Country>> result = await handler.HandleAsync(new GetCountryByNameQuery(name));
                return new WhippetResultContainer<ICountry>(result.Result, result.Item?.FirstOrDefault());
            }
        }

        /// <summary>
        /// Retrieves the <see cref="ICountry"/> object with the specified abbreviation.
        /// </summary>
        /// <param name="abbreviation">Two-character ISO abbreviation of the <see cref="ICountry"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<ICountry>> GetCountryByAbbreviation(string abbreviation)
        {
            if (String.IsNullOrWhiteSpace(abbreviation))
            {
                throw new ArgumentNullException(nameof(abbreviation));
            }
            else
            {
                WhippetResultContainer<ICountry> country = null;
                WhippetResultContainer<IEnumerable<ICountry>> countries = await GetCountries();

                if (countries.IsSuccess)
                {
                    country = new WhippetResultContainer<ICountry>(countries.Result, (from c in countries.Item where String.Equals(c.Abbreviation, abbreviation.Trim(), StringComparison.InvariantCultureIgnoreCase) select c).FirstOrDefault());
                }
                else
                {
                    country = new WhippetResultContainer<ICountry>(countries.Result, null);
                }

                return country;
            }
        }

        /// <summary>
        /// Creates a new country entry.
        /// </summary>
        /// <param name="server"><see cref="ICountry"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ICountry"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ICountry> CreateCountry(ICountry country)
        {
            return Task<WhippetResultContainer<ICountry>>.Run(() => CreateCountryAsync(country)).Result;
        }

        /// <summary>
        /// Creates a new country entry.
        /// </summary>
        /// <param name="country"><see cref="ICountry"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ICountry"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ICountry>> CreateCountryAsync(ICountry country)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateCountryCommand> handler = new CreateCountryCommandHandler(CountryRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateCountryCommand(country.ToCountry()));

                    if (result.IsSuccess)
                    {
                        await CountryRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ICountry>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ICountry>(result, country);
            }
        }

        /// <summary>
        /// Updates an existing country.
        /// </summary>
        /// <param name="country"><see cref="ICountry"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="ICountry"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ICountry> UpdateCountry(ICountry country)
        {
            return Task<WhippetResultContainer<ICountry>>.Run(() => UpdateCountryAsync(country)).Result;
        }

        /// <summary>
        /// Updates an existing country.
        /// </summary>
        /// <param name="country"><see cref="ICountry"/> object to update in the data store.</param>
        /// <param name="newId">New ID to assign to <paramref name="country"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="ICountry"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ICountry> UpdateCountry(ICountry country, Guid newId)
        {
            return Task<WhippetResultContainer<ICountry>>.Run(() => UpdateCountryAsync(country, newId)).Result;
        }
        
        /// <summary>
        /// Updates an existing country.
        /// </summary>
        /// <param name="country"><see cref="ICountry"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="ICountry"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ICountry>> UpdateCountryAsync(ICountry country)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateCountryCommand> handler = new UpdateCountryCommandHandler(CountryRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateCountryCommand(country.ToCountry()));

                    if (result.IsSuccess)
                    {
                        await CountryRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ICountry>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ICountry>(result, country);
            }
        }

        /// <summary>
        /// Updates an existing country.
        /// </summary>
        /// <param name="country"><see cref="ICountry"/> object to update in the data store.</param>
        /// <param name="newId">New ID to assign to <paramref name="country"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="ICountry"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ICountry>> UpdateCountryAsync(ICountry country, Guid newId, CancellationToken cancellationToken = default)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateCountryIdCommand> handler = new UpdateCountryIdCommandHandler(CountryRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateCountryIdCommand(country.ToCountry(), newId));

                    if (result.IsSuccess)
                    {
                        await CountryRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ICountry>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ICountry>(result, country);
            }
        }
        
        /// <summary>
        /// Deletes an existing country.
        /// </summary>
        /// <param name="country"><see cref="ICountry"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="ICountry"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ICountry> DeleteCountry(ICountry country)
        {
            return Task<WhippetResultContainer<ICountry>>.Run(() => DeleteCountryAsync(country)).Result;
        }

        /// <summary>
        /// Deletes an existing country.
        /// </summary>
        /// <param name="country"><see cref="ICountry"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="ICountry"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ICountry>> DeleteCountryAsync(ICountry country)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteCountryCommand> handler = new DeleteCountryCommandHandler(CountryRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteCountryCommand(country.ToCountry()));

                    if (result.IsSuccess)
                    {
                        await CountryRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ICountry>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ICountry>(result, country);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (CountryRepository != null)
            {
                CountryRepository.Dispose();
                CountryRepository = null;
            }

            base.Dispose();
        }

        /// <summary>
        /// Service manager that seeds <see cref="Country"/> objects. This class cannot be inherited.
        /// </summary>
        public sealed class CountrySeedServiceManager : CountryServiceManager, IServiceManager, ISeedServiceManager, IDisposable
        {
            private const string RESOURCE_COUNTRIES = "CountriesIndex";
            
            /// <summary>
            /// Initializes a new instance of the <see cref="CountryServiceManager.CountrySeedServiceManager"/> class with the specified <see cref="ICountryRepository"/> object.
            /// </summary>
            /// <param name="countryRepository"><see cref="ICountryRepository"/> to initialize with.</param>
            /// <exception cref="ArgumentNullException"></exception>
            public CountrySeedServiceManager(ICountryRepository countryRepository)
                : base(countryRepository)
            { }

            /// <summary>
            /// Initializes a new instance of the <see cref="CountryServiceManager.CountrySeedServiceManager"/> class with the specified <see cref="ICountryRepository"/> object.
            /// </summary>
            /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
            /// <param name="countryRepository"><see cref="ICountryRepository"/> object to initialize with.</param>
            /// <exception cref="ArgumentNullException"></exception>
            public CountrySeedServiceManager(IWhippetServiceContext serviceLocator, ICountryRepository countryRepository)
                : base(serviceLocator, countryRepository)
            { }

            /// <summary>
            /// Seeds the backing data store for one or more entities.
            /// </summary>
            /// <param name="progressReporter"><see cref="Action{T1, T2}"/> that reports the current status to an external caller.</param>
            /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
            public WhippetResult Seed(Action<double, string> progressReporter = null)
            {
                const string MSG_READING_COUNTRY = "Reading country {0}";
                const string MSG_CREATING_COUNTRY = "Creating country {0}";
                
                //5a2da7c2-4338-4e17-98f5-49b54f13f6d3,Afghanistan,AF,AFG,4
                // Country entires are ID, NAME, 2-LETTER ISO ABBR, 3-LETTER ISO ABBR, ISO-3166 NUMERIC CODE

                int index_guid = 0;
                int index_name = 1;
                int index_twoLetterISOAbbreviation = 2;
                int index_threeLetterISOAbbreviation = 3;
                int index_iso3166NumericCode = 4;

                string[] countryEntries = null;
                string[] countryPieces = null;

                string rawResource = null;
                
                List<Country> countries = null;
                
                IEnumerable<ICountry> missingCountries = null;
                
                WhippetResult result = WhippetResult.Success;
                WhippetResultContainer<IEnumerable<ICountry>> existingCountries = null;
                WhippetResultContainer<ICountry> newCountry = null;

                ICountry updateCountry = null;
                Country country = null;
                
                int counter = 0;

                ResXResourceReader resxReader = null;
                
                try
                {
                    resxReader = new ResXResourceReader(ResourceFileIndex.Addressing_Countries);
                    
                    foreach (DictionaryEntry d in resxReader)
                    {
                        if (d.Key.ToString().Equals(RESOURCE_COUNTRIES, StringComparison.InvariantCultureIgnoreCase))
                        {
                            rawResource = d.Value.ToString();
                        }
                    }

                    if (String.IsNullOrWhiteSpace(rawResource))
                    {
                        throw new Exception("No countries were found in the resource file " + ResourceFileIndex.Addressing_Countries);
                    }
                    else
                    {
                        countryEntries = rawResource.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries); 

                        if (countryEntries != null && countryEntries.Length > 0)
                        {
                            countries = new List<Country>(countryEntries.Length);

                            foreach (string entry in countryEntries)
                            {
                                countryPieces = entry.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                                country = new Country(new Guid(countryPieces[index_guid]), countryPieces[index_name], countryPieces[index_twoLetterISOAbbreviation]);

                                countries.Add(country);
                            }
                        }

                        existingCountries = Task.Run(() => GetCountries()).Result;
                        existingCountries.ThrowIfFailed();

                        if (progressReporter != null)
                        {
                            progressReporter(Convert.ToDouble(counter) / Convert.ToDouble(countries.Count), "Creating Countries");
                        }
                                
                        if (existingCountries.HasItem && existingCountries.Item.Any())
                        {
                            if (countries != null)
                            {
                                missingCountries = countries.Where(c => !existingCountries.Item.Contains(c));

                                if (missingCountries != null && missingCountries.Any())
                                {
                                    foreach (ICountry missingCountry in missingCountries)
                                    {
                                        newCountry = CreateCountry(missingCountry);
                                        newCountry.ThrowIfFailed();
                                    }
                                }
                            }
                        }
                        else
                        {
                            // no existing countries, so create new ones

                            foreach (ICountry c in countries)
                            {
                                newCountry = CreateCountry(c);
                                newCountry.ThrowIfFailed();
                            }
                        }

                        if (!String.IsNullOrWhiteSpace(rawResource))
                        {
                            existingCountries = Task.Run(() => GetCountries()).Result;
                            existingCountries.ThrowIfFailed();

                            countryEntries = rawResource.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                            for (int i = 0; i < countryEntries.Length; i++)
                            {
                                countryPieces = countryEntries[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                                updateCountry = (from c in existingCountries.Item where String.Equals(c.Name?.Trim(), countryPieces[index_name]?.Trim(), StringComparison.InvariantCultureIgnoreCase) select c).FirstOrDefault();

                                if (updateCountry != null)
                                {
                                    newCountry = UpdateCountry(updateCountry, new Guid(countryPieces[index_guid]));
                                    newCountry.ThrowIfFailed();
                                }
                            }
                        }
                        
                        counter++;
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResult(e);
                }
                finally
                {
                    if (resxReader != null)
                    {
                        resxReader.Close();
                        resxReader = null;
                    }
                }

                if (result == null)
                {
                    result = WhippetResult.Success;
                }

                return result;
            }
        }
    }
}
