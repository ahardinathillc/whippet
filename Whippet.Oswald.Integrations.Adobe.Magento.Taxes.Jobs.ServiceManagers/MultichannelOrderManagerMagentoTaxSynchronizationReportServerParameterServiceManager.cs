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
    /// Service manager for <see cref="MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter"/> domain objects.
    /// </summary>
    public class MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterServiceManager : JobParameterServiceManager<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter, MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected new virtual IMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterRepository JobParameterRepository
        {
            get
            {
                return base.JobParameterRepository as IMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterServiceManager"/> class with no arguments.
        /// </summary>
        private MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterServiceManager()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJobServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterServiceManager(IMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJobServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="repository"><see cref="IMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterServiceManager(IWhippetServiceContext serviceLocator, IMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterRepository repository)
            : base(serviceLocator, repository)
        { }

        /// <summary>
        /// Retrieves the <see cref="IJobParameter"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IJobParameter"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public override async Task<WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter>> GetJobParameter(Guid id)
        {
            GetMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterByIdQueryHandler handler = new GetMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterByIdQueryHandler(JobParameterRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter>> result = await handler.HandleAsync(new GetMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterByIdQuery(id));
            return new WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="IJobParameter"/> objects in the system. 
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public override async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter>>> GetJobParameters()
        {
            GetAllMultichannelOrderManagerMagentoTaxSynchronizationReportServerParametersQueryHandler handler = new GetAllMultichannelOrderManagerMagentoTaxSynchronizationReportServerParametersQueryHandler(JobParameterRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter>> result = await handler.HandleAsync(new GetAllMultichannelOrderManagerMagentoTaxSynchronizationReportServerParametersQuery());
            return new WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter>>(result.Result, result.Item);
        }

        /// <summary>
        /// Retrieves all <see cref="IJobParameter"/> objects in the system for the specified <see cref="IJob"/>. 
        /// </summary>
        /// <param name="job"><see cref="IJob"/> to get parameters for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter>>> GetJobParameters(MultichannelOrderManagerMagentoTaxSynchronizationJob job)
        {
            GetMultichannelOrderManagerMagentoTaxSynchronizationReportServerParametersByJobQueryHandler handler = new GetMultichannelOrderManagerMagentoTaxSynchronizationReportServerParametersByJobQueryHandler(JobParameterRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter>> result = await handler.HandleAsync(new GetMultichannelOrderManagerMagentoTaxSynchronizationReportServerParametersByJobQuery(job));
            return new WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter>>(result.Result, result.Item);
        }

        /// <summary>
        /// Creates a new Whippet job parameter. 
        /// </summary>
        /// <param name="parameter">Parameter to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created parameter.</returns>
        /// <exception cref="ArgumentNullException" />
        public override WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter> CreateJobParameter(MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter parameter)
        {
            return Task.Run(() => CreateJobAsync(parameter)).Result;
        }

        /// <summary>
        /// Creates a new Whippet job parameter. 
        /// </summary>
        /// <param name="parameter">Parameter to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created parameter.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter>> CreateJobAsync(MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }
            else
            {
                WhippetResult createResult = null;
                IWhippetCommandHandler<CreateMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterCommand> handler = new CreateMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterCommandHandler(JobParameterRepository);

                try
                {
                    createResult = await handler.HandleAsync(new CreateMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterCommand(parameter));

                    if (createResult.IsSuccess)
                    {
                        await JobParameterRepository.CommitAsync();
                        createResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    createResult = new WhippetResultContainer<CreateMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterCommand>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter>(createResult, parameter);
            }
        }

        /// <summary>
        /// Updates an existing Whippet job parameter. 
        /// </summary>
        /// <param name="parameter">Parameter to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated parameter.</returns>
        /// <exception cref="ArgumentNullException" />
        public override WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter> UpdateJobParameter(MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter parameter)
        {
            return Task.Run(() => UpdateJobAsync(parameter)).Result;
        }

        /// <summary>
        /// Updates an existing Whippet job parameter. 
        /// </summary>
        /// <param name="parameter">Parameter to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated parameter.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter>> UpdateJobAsync(MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetCommandHandler<UpdateMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterCommand> handler = new UpdateMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterCommandHandler(JobParameterRepository);

                try
                {
                    updateResult = await handler.HandleAsync(new UpdateMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterCommand(parameter));

                    if (updateResult.IsSuccess)
                    {
                        await JobParameterRepository.CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<CreateMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterCommand>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter>(updateResult, parameter);
            }
        }

        /// <summary>
        /// Deletes an existing Whippet job parameter. 
        /// </summary>
        /// <param name="parameter">Parameter to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted parameter.</returns>
        /// <exception cref="ArgumentNullException" />
        public override WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter> DeleteJobParameter(MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter parameter)
        {
            return Task.Run(() => DeleteJobParameterAsync(parameter)).Result;
        }

        /// <summary>
        /// Deletes an existing Whippet job parameter. 
        /// </summary>
        /// <param name="parameter">Parameter to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted parameter.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter>> DeleteJobParameterAsync(MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }
            else
            {
                WhippetResult deleteResult = null;
                IWhippetCommandHandler<DeleteMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterCommand> handler = new DeleteMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterCommandHandler(JobParameterRepository);

                try
                {
                    deleteResult = await handler.HandleAsync(new DeleteMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterCommand(parameter));

                    if (deleteResult.IsSuccess)
                    {
                        await JobParameterRepository.CommitAsync();
                        deleteResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    deleteResult = new WhippetResultContainer<DeleteMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterCommand>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter>(deleteResult, parameter);
            }
        }
    }
}
