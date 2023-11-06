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
    /// Service manager for <see cref="IPostalCode"/> domain objects.
    /// </summary>
    public class PostalCodeServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IPostalCodeRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IPostalCodeRepository PostalCodeRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostalCodeServiceManager"/> class with the specified <see cref="IPostalCodeRepository"/> object.
        /// </summary>
        /// <param name="postalCodeRepository"><see cref="IPostalCodeRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public PostalCodeServiceManager(IPostalCodeRepository postalCodeRepository)
            : base()
        {
            if (postalCodeRepository == null)
            {
                throw new ArgumentNullException(nameof(postalCodeRepository));
            }
            else
            {
                PostalCodeRepository = postalCodeRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostalCodeServiceManager"/> class with the specified <see cref="IPostalCodeRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="postalCodeRepository"><see cref="IPostalCodeRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public PostalCodeServiceManager(IWhippetServiceContext serviceLocator, IPostalCodeRepository postalCodeRepository)
            : base(serviceLocator)
        {
            if (postalCodeRepository == null)
            {
                throw new ArgumentNullException(nameof(postalCodeRepository));
            }
            else
            {
                PostalCodeRepository = postalCodeRepository;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="IPostalCode"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<IPostalCode>>> GetAllPostalCodes()
        {
            IPostalCodeQueryHandler<GetAllPostalCodesQuery> handler = new GetAllPostalCodesQueryHandler(PostalCodeRepository);
            WhippetResultContainer<IEnumerable<PostalCode>> result = await handler.HandleAsync(new GetAllPostalCodesQuery());
            return new WhippetResultContainer<IEnumerable<IPostalCode>>(result.Result, result.Item);
        }

        /// <summary>
        /// Retrieves all <see cref="IPostalCode"/> objects registered in the data store for the specified <see cref="ICity"/>.
        /// </summary>
        /// <param name="city"><see cref="ICity"/> to retrieve postal codes for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IPostalCode>>> GetPostalCodes(ICity city)
        {
            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }
            else
            {
                IPostalCodeQueryHandler<GetAllPostalCodesForCityQuery> handler = new GetAllPostalCodesForCityQueryHandler(PostalCodeRepository);
                WhippetResultContainer<IEnumerable<PostalCode>> result = await handler.HandleAsync(new GetAllPostalCodesForCityQuery(city));
                return new WhippetResultContainer<IEnumerable<IPostalCode>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Retrieves all <see cref="IPostalCode"/> object(s) that match the specified value.
        /// </summary>
        /// <param name="postalCodeValue"><see cref="IPostalCode"/> value to search for.</param>
        /// <param name="city">Optional <see cref="ICity"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IPostalCode>>> GetPostalCodes(string postalCodeValue, ICity city = null)
        {
            if (String.IsNullOrWhiteSpace(postalCodeValue))
            {
                throw new ArgumentNullException(nameof(postalCodeValue));
            }
            else
            {
                IPostalCodeQueryHandler<GetPostalCodesQuery> handler = new GetPostalCodesQueryHandler(PostalCodeRepository);
                WhippetResultContainer<IEnumerable<PostalCode>> result = await handler.HandleAsync(new GetPostalCodesQuery(postalCodeValue, city));
                return new WhippetResultContainer<IEnumerable<IPostalCode>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Creates a new postalCode entry.
        /// </summary>
        /// <param name="server"><see cref="IPostalCode"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IPostalCode"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IPostalCode> CreatePostalCode(IPostalCode postalCode)
        {
            return Task<WhippetResultContainer<IPostalCode>>.Run(() => CreatePostalCodeAsync(postalCode)).Result;
        }

        /// <summary>
        /// Creates a new postalCode entry.
        /// </summary>
        /// <param name="postalCode"><see cref="IPostalCode"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IPostalCode"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IPostalCode>> CreatePostalCodeAsync(IPostalCode postalCode)
        {
            if (postalCode == null)
            {
                throw new ArgumentNullException(nameof(postalCode));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreatePostalCodeCommand> handler = new CreatePostalCodeCommandHandler(PostalCodeRepository);

                try
                {
                    result = await handler.HandleAsync(new CreatePostalCodeCommand(postalCode.ToPostalCode()));

                    if (result.IsSuccess)
                    {
                        await PostalCodeRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IPostalCode>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IPostalCode>(result, postalCode);
            }
        }

        /// <summary>
        /// Updates an existing postalCode.
        /// </summary>
        /// <param name="postalCode"><see cref="IPostalCode"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IPostalCode"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IPostalCode> UpdatePostalCode(IPostalCode postalCode)
        {
            return Task<WhippetResultContainer<IPostalCode>>.Run(() => UpdatePostalCodeAsync(postalCode)).Result;
        }

        /// <summary>
        /// Updates an existing postalCode.
        /// </summary>
        /// <param name="postalCode"><see cref="IPostalCode"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IPostalCode"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IPostalCode>> UpdatePostalCodeAsync(IPostalCode postalCode)
        {
            if (postalCode == null)
            {
                throw new ArgumentNullException(nameof(postalCode));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdatePostalCodeCommand> handler = new UpdatePostalCodeCommandHandler(PostalCodeRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdatePostalCodeCommand(postalCode.ToPostalCode()));

                    if (result.IsSuccess)
                    {
                        await PostalCodeRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IPostalCode>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IPostalCode>(result, postalCode);
            }
        }

        /// <summary>
        /// Deletes an existing postalCode.
        /// </summary>
        /// <param name="postalCode"><see cref="IPostalCode"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IPostalCode"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IPostalCode> DeletePostalCode(IPostalCode postalCode)
        {
            return Task<WhippetResultContainer<IPostalCode>>.Run(() => DeletePostalCodeAsync(postalCode)).Result;
        }

        /// <summary>
        /// Deletes an existing postalCode.
        /// </summary>
        /// <param name="postalCode"><see cref="IPostalCode"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IPostalCode"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IPostalCode>> DeletePostalCodeAsync(IPostalCode postalCode)
        {
            if (postalCode == null)
            {
                throw new ArgumentNullException(nameof(postalCode));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeletePostalCodeCommand> handler = new DeletePostalCodeCommandHandler(PostalCodeRepository);

                try
                {
                    result = await handler.HandleAsync(new DeletePostalCodeCommand(postalCode.ToPostalCode()));

                    if (result.IsSuccess)
                    {
                        await PostalCodeRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IPostalCode>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IPostalCode>(result, postalCode);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (PostalCodeRepository != null)
            {
                PostalCodeRepository.Dispose();
                PostalCodeRepository = null;
            }

            base.Dispose();
        }
    }
}
