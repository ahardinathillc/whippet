using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Athi.Whippet.Extensions;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Security.Tenants.ServiceManagers.Queries;
using Athi.Whippet.Security.Tenants.ServiceManagers.Commands;
using Athi.Whippet.Security.Tenants.ServiceManagers.Handlers.Commands;
using Athi.Whippet.Security.Tenants.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.Security.Tenants.Repositories;

namespace Athi.Whippet.Security.Tenants.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="WhippetUserTenantAssignmentServiceManager"/> domain objects.
    /// </summary>
    public class WhippetUserTenantAssignmentServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IWhippetUserTenantAssignmentRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IWhippetUserTenantAssignmentRepository AssignmentRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserTenantAssignmentServiceManager"/> class with the specified <see cref="IWhippetUserTenantAssignmentRepository"/> object.
        /// </summary>
        /// <param name="ipAddressBlacklistRepository"><see cref="IWhippetUserTenantAssignmentRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetUserTenantAssignmentServiceManager(IWhippetUserTenantAssignmentRepository assignmentRepository)
            : base()
        {
            if (assignmentRepository == null)
            {
                throw new ArgumentNullException(nameof(assignmentRepository));
            }
            else
            {
                AssignmentRepository = assignmentRepository;
            }
        }

        /// <summary>
        /// Gets the <see cref="IWhippetUserTenantAssignment"/> that matches the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IWhippetUserTenantAssignment"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IWhippetUserTenantAssignment>> GetTenantAssignment(Guid id)
        {
            IWhippetUserTenantAssignmentQueryHandler<GetWhippetUserTenantAssignmentByIdQuery> handler = new GetWhippetUserTenantAssignmentByIdQueryHandler(AssignmentRepository);
            WhippetResultContainer<IEnumerable<WhippetUserTenantAssignment>> result = await handler.HandleAsync(new GetWhippetUserTenantAssignmentByIdQuery(id));

            return new WhippetResultContainer<IWhippetUserTenantAssignment>(result.Result, result.Item?.FirstOrDefault());
        }

        /// <summary>
        /// Gets all <see cref="IWhippetUserTenantAssignment"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to get the <see cref="IWhippetUserTenantAssignment"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IWhippetUserTenantAssignment>>> GetForTenant(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                IWhippetUserTenantAssignmentQueryHandler<GetWhippetUserTenantAssignmentsByTenantQuery> handler = new GetWhippetUserTenantAssignmentsByTenantQueryHandler(AssignmentRepository);
                WhippetResultContainer<IEnumerable<WhippetUserTenantAssignment>> result = await handler.HandleAsync(new GetWhippetUserTenantAssignmentsByTenantQuery(tenant));

                return new WhippetResultContainer<IEnumerable<IWhippetUserTenantAssignment>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Gets all <see cref="IWhippetUserTenantAssignment"/> objects for the specified <see cref="IWhippetUser"/>.
        /// </summary>
        /// <param name="user"><see cref="IWhippetUser"/> to get the <see cref="IWhippetUserTenantAssignment"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IWhippetUserTenantAssignment>>> GetForUser(IWhippetUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                IWhippetUserTenantAssignmentQueryHandler<GetWhippetUserTenantAssignmentsForUserQuery> handler = new GetWhippetUserTenantAssignmentsForUserQueryHandler(AssignmentRepository);
                WhippetResultContainer<IEnumerable<WhippetUserTenantAssignment>> result = await handler.HandleAsync(new GetWhippetUserTenantAssignmentsForUserQuery(user));

                return new WhippetResultContainer<IEnumerable<IWhippetUserTenantAssignment>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Determines if the specified <see cref="IWhippetUser"/> is assigned to a given <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="user"><see cref="IWhippetUser"/> object.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to check.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<bool>> UserIsAssignedToTenant(IWhippetUser user, IWhippetTenant tenant)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                WhippetResultContainer<bool> result = null;
                WhippetResultContainer<IEnumerable<IWhippetUserTenantAssignment>> assignments = await GetForUser(user);

                if (assignments.IsSuccess)
                {
                    result = new WhippetResultContainer<bool>(assignments.Result, assignments.HasItem && !assignments.AllItemsAreNull() && assignments.Item.Where(a => a.Tenant.ID == tenant.ID).Any());
                }
                else
                {
                    result = new WhippetResultContainer<bool>(assignments.Result, false);
                }

                return result;
            }
        }

        /// <summary>
        /// Creates a new <see cref="WhippetUserTenantAssignment"/> object in the data store.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetUserTenantAssignment"/> object to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created tenant.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetUserTenantAssignment> CreateTenantAssignment(IWhippetUserTenantAssignment tenant)
        {
            return Task<WhippetResultContainer<IWhippetUserTenantAssignment>>.Run(() => CreateTenantAssignmentAsync(tenant)).Result;
        }

        /// <summary>
        /// Updates an existing <see cref="WhippetUserTenantAssignment"/> object in the data store.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetUserTenantAssignment"/> object to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated tenant.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetUserTenantAssignment> UpdateTenantAssignment(IWhippetUserTenantAssignment tenant)
        {
            return Task<WhippetResultContainer<IWhippetUserTenantAssignment>>.Run(() => UpdateTenantAssignmentAsync(tenant)).Result;
        }

        /// <summary>
        /// Deletes an existing <see cref="WhippetUserTenantAssignment"/> object in the data store.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetUserTenantAssignment"/> object to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted tenant.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetUserTenantAssignment> DeleteTenantAssignment(IWhippetUserTenantAssignment tenant)
        {
            return Task<WhippetResultContainer<IWhippetUserTenantAssignment>>.Run(() => DeleteTenantAssignmentAsync(tenant)).Result;
        }

        /// <summary>
        /// Creates a new <see cref="WhippetUserTenantAssignment"/> object in the data store.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetUserTenantAssignment"/> object to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created tenant.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetUserTenantAssignment>> CreateTenantAssignmentAsync(IWhippetUserTenantAssignment tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                WhippetResult createResult = null;
                IWhippetUserTenantAssignmentCommandHandler<CreateWhippetUserTenantAssignmentCommand> handler = new CreateWhippetUserTenantAssignmentCommandHandler(AssignmentRepository);

                try
                {
                    createResult = await handler.HandleAsync(new CreateWhippetUserTenantAssignmentCommand(tenant.ToWhippetUserTenantAssignment()));

                    if (createResult.IsSuccess)
                    {
                        await AssignmentRepository.CommitAsync();
                        createResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    createResult = new WhippetResultContainer<IWhippetUser>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetUserTenantAssignment>(createResult, tenant);
            }
        }

        /// <summary>
        /// Updates an existing <see cref="WhippetUserTenantAssignment"/> object in the data store.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetUserTenantAssignment"/> object to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated tenant.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetUserTenantAssignment>> UpdateTenantAssignmentAsync(IWhippetUserTenantAssignment tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetUserTenantAssignmentCommandHandler<UpdateWhippetUserTenantAssignmentCommand> handler = new UpdateWhippetUserTenantAssignmentCommandHandler(AssignmentRepository);

                try
                {
                    updateResult = await handler.HandleAsync(new UpdateWhippetUserTenantAssignmentCommand(tenant.ToWhippetUserTenantAssignment()));

                    if (updateResult.IsSuccess)
                    {
                        await AssignmentRepository.CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<IWhippetUser>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetUserTenantAssignment>(updateResult, tenant);
            }
        }

        /// <summary>
        /// Deletes an existing <see cref="WhippetUserTenantAssignment"/> object in the data store.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetUserTenantAssignment"/> object to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted tenant.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetUserTenantAssignment>> DeleteTenantAssignmentAsync(IWhippetUserTenantAssignment tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                WhippetResult deleteResult = null;
                IWhippetUserTenantAssignmentCommandHandler<DeleteWhippetUserTenantAssignmentCommand> handler = new DeleteWhippetUserTenantAssignmentCommandHandler(AssignmentRepository);

                try
                {
                    deleteResult = await handler.HandleAsync(new DeleteWhippetUserTenantAssignmentCommand(tenant.ToWhippetUserTenantAssignment()));

                    if (deleteResult.IsSuccess)
                    {
                        await AssignmentRepository.CommitAsync();
                        deleteResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    deleteResult = new WhippetResultContainer<IWhippetUser>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetUserTenantAssignment>(deleteResult, tenant);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (AssignmentRepository != null)
            {
                AssignmentRepository.Dispose();
                AssignmentRepository = null;
            }

            base.Dispose();
        }
    }
}
