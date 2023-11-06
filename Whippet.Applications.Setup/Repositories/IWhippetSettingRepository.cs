using System;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Applications.Setup.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="WhippetSetting"/> entity objects.
    /// </summary>
    public interface IWhippetSettingRepository : IWhippetEntityRepository<WhippetSetting, Guid>, IWhippetRepository<WhippetSetting, Guid>, IWhippetQueryRepository<WhippetSetting>
    {
        /// <summary>
        /// Retrieves all <see cref="WhippetSetting"/> objects for the specified <see cref="IWhippetSettingGroup"/>.
        /// </summary>
        /// <param name="group"><see cref="IWhippetSettingGroup"/> to retrieve the <see cref="WhippetSetting"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<WhippetSetting>> GetSettingsForGroup(IWhippetSettingGroup group);

        /// <summary>
        /// Retrieves all <see cref="WhippetSetting"/> objects for the specified <see cref="IWhippetSettingGroup"/>.
        /// </summary>
        /// <param name="group"><see cref="IWhippetSettingGroup"/> to retrieve the <see cref="WhippetSetting"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<WhippetSetting>>> GetSettingsForGroupAsync(IWhippetSettingGroup group, CancellationToken? cancellationToken = null);
    }
}
