using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using NodaTime;
using Athi.Whippet;
using Athi.Whippet.Services;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Data.CQRS;
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
    }
}
