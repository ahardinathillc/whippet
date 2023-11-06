using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Services;
using Athi.Whippet.Jobs;
using Athi.Whippet.Jobs.ServiceManagers;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.Repositories;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Commands;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Queries;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Handlers.Commands;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter"/> domain objects.
    /// </summary>
    public class MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterServiceManager : JobParameterServiceManager<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter, MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected new virtual IMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterRepository JobParameterRepository
        {
            get
            {
                return base.JobParameterRepository as IMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterServiceManager"/> class with no arguments.
        /// </summary>
        private MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterServiceManager()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJobServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterServiceManager(IMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJobServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="repository"><see cref="IMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterServiceManager(IWhippetServiceContext serviceLocator, IMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterRepository repository)
            : base(serviceLocator, repository)
        { }

        /// <summary>
        /// Retrieves the <see cref="IJobParameter"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IJobParameter"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public override async Task<WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter>> GetJobParameter(Guid id)
        {
            GetMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterByIdQueryHandler handler = new GetMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterByIdQueryHandler(JobParameterRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter>> result = await handler.HandleAsync(new GetMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterByIdQuery(id));
            return new WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="IJobParameter"/> objects in the system. 
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public override async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter>>> GetJobParameters()
        {
            GetAllMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParametersQueryHandler handler = new GetAllMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParametersQueryHandler(JobParameterRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter>> result = await handler.HandleAsync(new GetAllMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParametersQuery());
            return new WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter>>(result.Result, result.Item);
        }

        /// <summary>
        /// Retrieves all <see cref="IJobParameter"/> objects in the system for the specified <see cref="IJob"/>. 
        /// </summary>
        /// <param name="job"><see cref="IJob"/> to get parameters for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter>>> GetJobParameters(MultichannelOrderManagerMagentoTaxSynchronizationJob job)
        {
            GetMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParametersByJobQueryHandler handler = new GetMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParametersByJobQueryHandler(JobParameterRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter>> result = await handler.HandleAsync(new GetMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParametersByJobQuery(job));
            return new WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter>>(result.Result, result.Item);
        }

        /// <summary>
        /// Creates a new Whippet job parameter. 
        /// </summary>
        /// <param name="parameter">Parameter to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created parameter.</returns>
        /// <exception cref="ArgumentNullException" />
        public override WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter> CreateJobParameter(MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter parameter)
        {
            return Task.Run(() => CreateJobAsync(parameter)).Result;
        }

        /// <summary>
        /// Creates a new Whippet job parameter. 
        /// </summary>
        /// <param name="parameter">Parameter to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created parameter.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter>> CreateJobAsync(MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }
            else
            {
                WhippetResult createResult = null;
                IWhippetCommandHandler<CreateMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommand> handler = new CreateMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommandHandler(JobParameterRepository);

                try
                {
                    createResult = await handler.HandleAsync(new CreateMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommand(parameter));

                    if (createResult.IsSuccess)
                    {
                        await JobParameterRepository.CommitAsync();
                        createResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    createResult = new WhippetResultContainer<CreateMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommand>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter>(createResult, parameter);
            }
        }

        /// <summary>
        /// Updates an existing Whippet job parameter. 
        /// </summary>
        /// <param name="parameter">Parameter to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated parameter.</returns>
        /// <exception cref="ArgumentNullException" />
        public override WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter> UpdateJobParameter(MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter parameter)
        {
            return Task.Run(() => UpdateJobAsync(parameter)).Result;
        }

        /// <summary>
        /// Updates an existing Whippet job parameter. 
        /// </summary>
        /// <param name="parameter">Parameter to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated parameter.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter>> UpdateJobAsync(MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetCommandHandler<UpdateMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommand> handler = new UpdateMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommandHandler(JobParameterRepository);

                try
                {
                    updateResult = await handler.HandleAsync(new UpdateMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommand(parameter));

                    if (updateResult.IsSuccess)
                    {
                        await JobParameterRepository.CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<CreateMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommand>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter>(updateResult, parameter);
            }
        }

        /// <summary>
        /// Deletes an existing Whippet job parameter. 
        /// </summary>
        /// <param name="parameter">Parameter to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted parameter.</returns>
        /// <exception cref="ArgumentNullException" />
        public override WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter> DeleteJobParameter(MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter parameter)
        {
            return Task.Run(() => DeleteJobParameterAsync(parameter)).Result;
        }

        /// <summary>
        /// Deletes an existing Whippet job parameter. 
        /// </summary>
        /// <param name="parameter">Parameter to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted parameter.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter>> DeleteJobParameterAsync(MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }
            else
            {
                WhippetResult deleteResult = null;
                IWhippetCommandHandler<DeleteMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommand> handler = new DeleteMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommandHandler(JobParameterRepository);

                try
                {
                    deleteResult = await handler.HandleAsync(new DeleteMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommand(parameter));

                    if (deleteResult.IsSuccess)
                    {
                        await JobParameterRepository.CommitAsync();
                        deleteResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    deleteResult = new WhippetResultContainer<DeleteMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterCommand>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter>(deleteResult, parameter);
            }
        }
    }
}
