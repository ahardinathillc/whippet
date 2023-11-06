using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Services;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.AccessControl.Extensions;
using Athi.Whippet.Security.AccessControl.Repositories;
using Athi.Whippet.Security.AccessControl.ServiceManagers.Queries;
using Athi.Whippet.Security.AccessControl.ServiceManagers.Commands;
using Athi.Whippet.Security.AccessControl.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Security.AccessControl.ServiceManagers.Handlers.Commands;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IWhippetRoleUserAssignment"/> domain objects.
    /// </summary>
    public class WhippetRoleUserAssignmentServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IWhippetRoleUserAssignmentRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IWhippetRoleUserAssignmentRepository RoleUserAssignmentRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRoleUserAssignmentServiceManager"/> class with the specified <see cref="IWhippetRoleUserAssignmentRepository"/> object.
        /// </summary>
        /// <param name="roleRepository"><see cref="IWhippetRoleUserAssignmentRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetRoleUserAssignmentServiceManager(IWhippetRoleUserAssignmentRepository roleRepository)
            : base()
        {
            if (roleRepository == null)
            {
                throw new ArgumentNullException(nameof(roleRepository));
            }
            else
            {
                RoleUserAssignmentRepository = roleRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRoleUserAssignmentServiceManager"/> class with the specified <see cref="IWhippetRoleUserAssignmentRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="roleRepository"><see cref="IWhippetRoleUserAssignmentRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetRoleUserAssignmentServiceManager(IWhippetServiceContext serviceLocator, IWhippetRoleUserAssignmentRepository roleRepository)
            : base(serviceLocator)
        {
            if (roleRepository == null)
            {
                throw new ArgumentNullException(nameof(roleRepository));
            }
            else
            {
                RoleUserAssignmentRepository = roleRepository;
            }
        }

        /// <summary>
        /// Gets all <see cref="IWhippetRoleUserAssignment"/> objects by its parent <see cref="IWhippetRole"/> object.
        /// </summary>
        /// <param name="role"><see cref="IWhippetRole"/> to get all assignments for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IWhippetRoleUserAssignment>>> GetMembersOfRole(IWhippetRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            else
            {
                IWhippetRoleUserAssignmentQueryHandler<GetWhippetRoleUserAssignmentByRoleQuery> handler = new GetWhippetRoleUserAssignmentByRoleQueryHandler(RoleUserAssignmentRepository);
                WhippetResultContainer<IEnumerable<WhippetRoleUserAssignment>> result = await handler.HandleAsync(new GetWhippetRoleUserAssignmentByRoleQuery(role));

                return new WhippetResultContainer<IEnumerable<IWhippetRoleUserAssignment>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Gets all <see cref="IWhippetRoleUserAssignment"/> objects by its parent <see cref="IWhippetUser"/> object.
        /// </summary>
        /// <param name="user"><see cref="IWhippetUser"/> to get all role assignments for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IWhippetRoleUserAssignment>>> GetUserAssignments(IWhippetUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                IWhippetRoleUserAssignmentQueryHandler<GetWhippetRoleUserAssignmentByUserQuery> handler = new GetWhippetRoleUserAssignmentByUserQueryHandler(RoleUserAssignmentRepository);
                WhippetResultContainer<IEnumerable<WhippetRoleUserAssignment>> result = await handler.HandleAsync(new GetWhippetRoleUserAssignmentByUserQuery(user));

                return new WhippetResultContainer<IEnumerable<IWhippetRoleUserAssignment>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Determines if the specified <see cref="IWhippetUser"/> is a member of the given <see cref="IWhippetRole"/>.
        /// </summary>
        /// <param name="user"><see cref="IWhippetUser"/> user to check membership for.</param>
        /// <param name="role"><see cref="IWhippetRole"/> role to search for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<bool>> UserIsMemberOfRole(IWhippetUser user, IWhippetRole role)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            else
            {
                WhippetResultContainer<bool> memberResult = null;
                WhippetResultContainer<IEnumerable<IWhippetRoleUserAssignment>> result = await GetUserAssignments(user);

                if (!result.IsSuccess)
                {
                    memberResult = new WhippetResultContainer<bool>(result.Exception);
                }
                else
                {
                    memberResult = new WhippetResultContainer<bool>(WhippetResult.Success, result.HasItem && result.Item.Where(ua => ua.Role.ID == role.ID).Any());
                }

                return memberResult;
            }
        }

        /// <summary>
        /// Creates a new user role assignment.
        /// </summary>
        /// <param name="role"><see cref="IWhippetRoleUserAssignment"/> to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual WhippetResultContainer<IWhippetRoleUserAssignment> CreateWhippetRoleUserAssignment(IWhippetRoleUserAssignment role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            else
            {
                return Task.Run(() => CreateWhippetRoleUserAssignmentAsync(role)).Result;
            }
        }

        /// <summary>
        /// Creates a new user role assignment.
        /// </summary>
        /// <param name="role"><see cref="IWhippetRoleUserAssignment"/> to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IWhippetRoleUserAssignment>> CreateWhippetRoleUserAssignmentAsync(IWhippetRoleUserAssignment role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            else
            {
                WhippetResult createResult = null;
                IWhippetRoleUserAssignmentCommandHandler<CreateWhippetRoleUserAssignmentCommand> handler = new CreateWhippetRoleUserAssignmentCommandHandler(RoleUserAssignmentRepository);

                try
                {
                    createResult = await handler.HandleAsync(new CreateWhippetRoleUserAssignmentCommand(role.ToWhippetRoleUserAssignment()));

                    if (createResult.IsSuccess)
                    {
                        await RoleUserAssignmentRepository.CommitAsync();
                        createResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    createResult = new WhippetResultContainer<IWhippetRoleUserAssignment>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetRoleUserAssignment>(createResult, role);

            }
        }

        /// <summary>
        /// Updates an existing Whippet role assignment.
        /// </summary>
        /// <param name="role">RoleUserAssignment to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated role assignment.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetRoleUserAssignment> UpdateWhippetRoleUserAssignment(IWhippetRoleUserAssignment role)
        {
            return Task<WhippetResultContainer<IWhippetRoleUserAssignment>>.Run(() => UpdateWhippetRoleUserAssignmentAsync(role)).Result;
        }

        /// <summary>
        /// Updates an existing Whippet role assignment.
        /// </summary>
        /// <param name="role">RoleUserAssignment to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated role assignment.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetRoleUserAssignment>> UpdateWhippetRoleUserAssignmentAsync(IWhippetRoleUserAssignment role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetRoleUserAssignmentCommandHandler<UpdateWhippetRoleUserAssignmentCommand> handler = new UpdateWhippetRoleUserAssignmentCommandHandler(RoleUserAssignmentRepository);

                try
                {
                    updateResult = await handler.HandleAsync(new UpdateWhippetRoleUserAssignmentCommand(role.ToWhippetRoleUserAssignment()));

                    if (updateResult.IsSuccess)
                    {
                        await RoleUserAssignmentRepository.CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<IWhippetRoleUserAssignment>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetRoleUserAssignment>(updateResult, role);
            }
        }

        /// <summary>
        /// Deletes an existing Whippet role assignment.
        /// </summary>
        /// <param name="role">RoleUserAssignment to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted role assignment.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetRoleUserAssignment> DeleteWhippetRoleUserAssignment(IWhippetRoleUserAssignment role)
        {
            return Task<WhippetResultContainer<IWhippetRoleUserAssignment>>.Run(() => DeleteWhippetRoleUserAssignmentAsync(role)).Result;
        }

        /// <summary>
        /// Deletes an existing Whippet role assignment.
        /// </summary>
        /// <param name="role">RoleUserAssignment to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted role assignment.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetRoleUserAssignment>> DeleteWhippetRoleUserAssignmentAsync(IWhippetRoleUserAssignment role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetRoleUserAssignmentCommandHandler<DeleteWhippetRoleUserAssignmentCommand> handler = new DeleteWhippetRoleUserAssignmentCommandHandler(RoleUserAssignmentRepository);

                try
                {
                    updateResult = await handler.HandleAsync(new DeleteWhippetRoleUserAssignmentCommand(role.ToWhippetRoleUserAssignment()));

                    if (updateResult.IsSuccess)
                    {
                        await RoleUserAssignmentRepository.CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<IWhippetRoleUserAssignment>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetRoleUserAssignment>(updateResult, role);
            }
        }
    }
}
