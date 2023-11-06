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
    /// Service manager for <see cref="IWhippetGroupUserAssignment"/> domain objects.
    /// </summary>
    public class WhippetGroupUserAssignmentServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IWhippetGroupUserAssignmentRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IWhippetGroupUserAssignmentRepository GroupUserAssignmentRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetGroupUserAssignmentServiceManager"/> class with the specified <see cref="IWhippetGroupUserAssignmentRepository"/> object.
        /// </summary>
        /// <param name="groupRepository"><see cref="IWhippetGroupUserAssignmentRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetGroupUserAssignmentServiceManager(IWhippetGroupUserAssignmentRepository groupRepository)
            : base()
        {
            if (groupRepository == null)
            {
                throw new ArgumentNullException(nameof(groupRepository));
            }
            else
            {
                GroupUserAssignmentRepository = groupRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetGroupUserAssignmentServiceManager"/> class with the specified <see cref="IWhippetGroupUserAssignmentRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="groupRepository"><see cref="IWhippetGroupUserAssignmentRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetGroupUserAssignmentServiceManager(IWhippetServiceContext serviceLocator, IWhippetGroupUserAssignmentRepository groupRepository)
            : base(serviceLocator)
        {
            if (groupRepository == null)
            {
                throw new ArgumentNullException(nameof(groupRepository));
            }
            else
            {
                GroupUserAssignmentRepository = groupRepository;
            }
        }

        /// <summary>
        /// Gets all <see cref="IWhippetGroupUserAssignment"/> objects by its parent <see cref="IWhippetGroup"/> object.
        /// </summary>
        /// <param name="group"><see cref="IWhippetGroup"/> to get all assignments for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IWhippetGroupUserAssignment>>> GetMembersOfGroup(IWhippetGroup group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            else
            {
                IWhippetGroupUserAssignmentQueryHandler<GetWhippetGroupUserAssignmentByGroupQuery> handler = new GetWhippetGroupUserAssignmentByGroupQueryHandler(GroupUserAssignmentRepository);
                WhippetResultContainer<IEnumerable<WhippetGroupUserAssignment>> result = await handler.HandleAsync(new GetWhippetGroupUserAssignmentByGroupQuery(group));

                return new WhippetResultContainer<IEnumerable<IWhippetGroupUserAssignment>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Gets all <see cref="IWhippetGroupUserAssignment"/> objects by its parent <see cref="IWhippetUser"/> object.
        /// </summary>
        /// <param name="user"><see cref="IWhippetUser"/> to get all group assignments for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IWhippetGroupUserAssignment>>> GetUserAssignments(IWhippetUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                IWhippetGroupUserAssignmentQueryHandler<GetWhippetGroupUserAssignmentByUserQuery> handler = new GetWhippetGroupUserAssignmentByUserQueryHandler(GroupUserAssignmentRepository);
                WhippetResultContainer<IEnumerable<WhippetGroupUserAssignment>> result = await handler.HandleAsync(new GetWhippetGroupUserAssignmentByUserQuery(user));

                return new WhippetResultContainer<IEnumerable<IWhippetGroupUserAssignment>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Determines if the specified <see cref="IWhippetUser"/> is a member of the given <see cref="IWhippetGroup"/>.
        /// </summary>
        /// <param name="user"><see cref="IWhippetUser"/> user to check membership for.</param>
        /// <param name="group"><see cref="IWhippetGroup"/> group to search for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<bool>> UserIsMemberOfGroup(IWhippetUser user, IWhippetGroup group)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            else
            {
                WhippetResultContainer<bool> memberResult = null;
                WhippetResultContainer<IEnumerable<IWhippetGroupUserAssignment>> result = await GetUserAssignments(user);

                if (!result.IsSuccess)
                {
                    memberResult = new WhippetResultContainer<bool>(result.Exception);
                }
                else
                {
                    memberResult = new WhippetResultContainer<bool>(WhippetResult.Success, result.HasItem && result.Item.Where(ua => ua.Group.ID == group.ID).Any());
                }

                return memberResult;
            }
        }

        /// <summary>
        /// Creates a new user group assignment.
        /// </summary>
        /// <param name="group"><see cref="IWhippetGroupUserAssignment"/> to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual WhippetResultContainer<IWhippetGroupUserAssignment> CreateWhippetGroupUserAssignment(IWhippetGroupUserAssignment group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            else
            {
                return Task.Run(() => CreateWhippetGroupUserAssignmentAsync(group)).Result;
            }
        }

        /// <summary>
        /// Creates a new user group assignment.
        /// </summary>
        /// <param name="group"><see cref="IWhippetGroupUserAssignment"/> to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IWhippetGroupUserAssignment>> CreateWhippetGroupUserAssignmentAsync(IWhippetGroupUserAssignment group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            else
            {
                WhippetResult createResult = null;
                IWhippetGroupUserAssignmentCommandHandler<CreateWhippetGroupUserAssignmentCommand> handler = new CreateWhippetGroupUserAssignmentCommandHandler(GroupUserAssignmentRepository);

                try
                {
                    createResult = await handler.HandleAsync(new CreateWhippetGroupUserAssignmentCommand(group.ToWhippetGroupUserAssignment()));

                    if (createResult.IsSuccess)
                    {
                        await GroupUserAssignmentRepository.CommitAsync();
                        createResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    createResult = new WhippetResultContainer<IWhippetGroupUserAssignment>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetGroupUserAssignment>(createResult, group);

            }
        }

        /// <summary>
        /// Updates an existing Whippet group assignment.
        /// </summary>
        /// <param name="group">GroupUserAssignment to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated group assignment.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetGroupUserAssignment> UpdateWhippetGroupUserAssignment(IWhippetGroupUserAssignment group)
        {
            return Task<WhippetResultContainer<IWhippetGroupUserAssignment>>.Run(() => UpdateWhippetGroupUserAssignmentAsync(group)).Result;
        }

        /// <summary>
        /// Updates an existing Whippet group assignment.
        /// </summary>
        /// <param name="group">GroupUserAssignment to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated group assignment.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetGroupUserAssignment>> UpdateWhippetGroupUserAssignmentAsync(IWhippetGroupUserAssignment group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetGroupUserAssignmentCommandHandler<UpdateWhippetGroupUserAssignmentCommand> handler = new UpdateWhippetGroupUserAssignmentCommandHandler(GroupUserAssignmentRepository);

                try
                {
                    updateResult = await handler.HandleAsync(new UpdateWhippetGroupUserAssignmentCommand(group.ToWhippetGroupUserAssignment()));

                    if (updateResult.IsSuccess)
                    {
                        await GroupUserAssignmentRepository.CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<IWhippetGroupUserAssignment>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetGroupUserAssignment>(updateResult, group);
            }
        }

        /// <summary>
        /// Deletes an existing Whippet group assignment.
        /// </summary>
        /// <param name="group">GroupUserAssignment to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted group assignment.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetGroupUserAssignment> DeleteWhippetGroupUserAssignment(IWhippetGroupUserAssignment group)
        {
            return Task<WhippetResultContainer<IWhippetGroupUserAssignment>>.Run(() => DeleteWhippetGroupUserAssignmentAsync(group)).Result;
        }

        /// <summary>
        /// Deletes an existing Whippet group assignment.
        /// </summary>
        /// <param name="group">GroupUserAssignment to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted group assignment.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetGroupUserAssignment>> DeleteWhippetGroupUserAssignmentAsync(IWhippetGroupUserAssignment group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetGroupUserAssignmentCommandHandler<DeleteWhippetGroupUserAssignmentCommand> handler = new DeleteWhippetGroupUserAssignmentCommandHandler(GroupUserAssignmentRepository);

                try
                {
                    updateResult = await handler.HandleAsync(new DeleteWhippetGroupUserAssignmentCommand(group.ToWhippetGroupUserAssignment()));

                    if (updateResult.IsSuccess)
                    {
                        await GroupUserAssignmentRepository.CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<IWhippetGroupUserAssignment>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetGroupUserAssignment>(updateResult, group);
            }
        }
    }
}
