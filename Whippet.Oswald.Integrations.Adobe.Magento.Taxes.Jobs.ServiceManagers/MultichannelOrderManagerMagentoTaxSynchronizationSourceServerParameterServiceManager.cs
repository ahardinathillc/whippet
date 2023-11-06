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
    /// Service manager for <see cref="MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter"/> domain objects.
    /// </summary>
    public class MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterServiceManager : JobParameterServiceManager<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter, MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected new virtual IMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterRepository JobParameterRepository
        {
            get
            {
                return base.JobParameterRepository as IMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterServiceManager"/> class with no arguments.
        /// </summary>
        private MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterServiceManager()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJobServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterServiceManager(IMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJobServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="repository"><see cref="IMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterServiceManager(IWhippetServiceContext serviceLocator, IMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterRepository repository)
            : base(serviceLocator, repository)
        { }

        /// <summary>
        /// Retrieves the <see cref="IJobParameter"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IJobParameter"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public override async Task<WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter>> GetJobParameter(Guid id)
        {
            GetMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterByIdQueryHandler handler = new GetMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterByIdQueryHandler(JobParameterRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter>> result = await handler.HandleAsync(new GetMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterByIdQuery(id));
            return new WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="IJobParameter"/> objects in the system. 
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public override async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter>>> GetJobParameters()
        {
            GetAllMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParametersQueryHandler handler = new GetAllMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParametersQueryHandler(JobParameterRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter>> result = await handler.HandleAsync(new GetAllMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParametersQuery());
            return new WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter>>(result.Result, result.Item);
        }

        /// <summary>
        /// Retrieves all <see cref="IJobParameter"/> objects in the system for the specified <see cref="IJob"/>. 
        /// </summary>
        /// <param name="job"><see cref="IJob"/> to get parameters for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter>>> GetJobParameters(MultichannelOrderManagerMagentoTaxSynchronizationJob job)
        {
            GetMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParametersByJobQueryHandler handler = new GetMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParametersByJobQueryHandler(JobParameterRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter>> result = await handler.HandleAsync(new GetMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParametersByJobQuery(job));
            return new WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter>>(result.Result, result.Item);
        }

        /// <summary>
        /// Creates a new Whippet job parameter. 
        /// </summary>
        /// <param name="parameter">Parameter to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created parameter.</returns>
        /// <exception cref="ArgumentNullException" />
        public override WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter> CreateJobParameter(MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter parameter)
        {
            return Task.Run(() => CreateJobAsync(parameter)).Result;
        }

        /// <summary>
        /// Creates a new Whippet job parameter. 
        /// </summary>
        /// <param name="parameter">Parameter to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created parameter.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter>> CreateJobAsync(MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }
            else
            {
                WhippetResult createResult = null;
                IWhippetCommandHandler<CreateMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterCommand> handler = new CreateMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterCommandHandler(JobParameterRepository);

                try
                {
                    createResult = await handler.HandleAsync(new CreateMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterCommand(parameter));

                    if (createResult.IsSuccess)
                    {
                        await JobParameterRepository.CommitAsync();
                        createResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    createResult = new WhippetResultContainer<CreateMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterCommand>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter>(createResult, parameter);
            }
        }

        /// <summary>
        /// Updates an existing Whippet job parameter. 
        /// </summary>
        /// <param name="parameter">Parameter to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated parameter.</returns>
        /// <exception cref="ArgumentNullException" />
        public override WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter> UpdateJobParameter(MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter parameter)
        {
            return Task.Run(() => UpdateJobAsync(parameter)).Result;
        }

        /// <summary>
        /// Updates an existing Whippet job parameter. 
        /// </summary>
        /// <param name="parameter">Parameter to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated parameter.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter>> UpdateJobAsync(MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetCommandHandler<UpdateMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterCommand> handler = new UpdateMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterCommandHandler(JobParameterRepository);

                try
                {
                    updateResult = await handler.HandleAsync(new UpdateMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterCommand(parameter));

                    if (updateResult.IsSuccess)
                    {
                        await JobParameterRepository.CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<CreateMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterCommand>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter>(updateResult, parameter);
            }
        }

        /// <summary>
        /// Deletes an existing Whippet job parameter. 
        /// </summary>
        /// <param name="parameter">Parameter to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted parameter.</returns>
        /// <exception cref="ArgumentNullException" />
        public override WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter> DeleteJobParameter(MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter parameter)
        {
            return Task.Run(() => DeleteJobParameterAsync(parameter)).Result;
        }

        /// <summary>
        /// Deletes an existing Whippet job parameter. 
        /// </summary>
        /// <param name="parameter">Parameter to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted parameter.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter>> DeleteJobParameterAsync(MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }
            else
            {
                WhippetResult deleteResult = null;
                IWhippetCommandHandler<DeleteMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterCommand> handler = new DeleteMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterCommandHandler(JobParameterRepository);

                try
                {
                    deleteResult = await handler.HandleAsync(new DeleteMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterCommand(parameter));

                    if (deleteResult.IsSuccess)
                    {
                        await JobParameterRepository.CommitAsync();
                        deleteResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    deleteResult = new WhippetResultContainer<DeleteMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterCommand>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter>(deleteResult, parameter);
            }
        }
    }
}
