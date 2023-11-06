using System;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Applications.Setup.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="WhippetSettingGroup"/> entity objects.
    /// </summary>
    public interface IWhippetSettingGroupRepository : IWhippetEntityRepository<WhippetSettingGroup, Guid>, IWhippetRepository<WhippetSettingGroup, Guid>, IWhippetQueryRepository<WhippetSettingGroup>
    {
        /// <summary>
        /// Retrieves all <see cref="WhippetSettingGroup"/> objects for the specified <see cref="IWhippetApplication"/>.
        /// </summary>
        /// <param name="application"><see cref="IWhippetApplication"/> to retrieve the <see cref="WhippetSettingGroup"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<WhippetSettingGroup>> GetSettingGroupsForApplication(IWhippetApplication application);

        /// <summary>
        /// Retrieves all <see cref="WhippetSettingGroup"/> objects for the specified <see cref="IWhippetApplication"/>.
        /// </summary>
        /// <param name="application"><see cref="IWhippetApplication"/> to retrieve the <see cref="WhippetSettingGroup"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<WhippetSettingGroup>>> GetSettingGroupsForApplicationAsync(IWhippetApplication application, CancellationToken? cancellationToken = null);
    }
}
