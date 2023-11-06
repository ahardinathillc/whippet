using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Applications.Setup.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="WhippetSetting"/> entity objects.
    /// </summary>
    public class WhippetSettingRepository : WhippetEntityRepository<WhippetSetting>, IWhippetSettingRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSettingRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetSettingRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSettingRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetSettingRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Retrieves all <see cref="WhippetSetting"/> objects for the specified <see cref="IWhippetSettingGroup"/>.
        /// </summary>
        /// <param name="group"><see cref="IWhippetSettingGroup"/> to retrieve the <see cref="WhippetSetting"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<WhippetSetting>> GetSettingsForGroup(IWhippetSettingGroup group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            else
            {
                return Task.Run(() => GetSettingsForGroupAsync(group)).Result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="WhippetSetting"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="group"><see cref="IWhippetSettingGroup"/> to retrieve the <see cref="WhippetSetting"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<WhippetSetting>>> GetSettingsForGroupAsync(IWhippetSettingGroup group, CancellationToken? cancellationToken = null)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            else
            {
                IList<WhippetSetting> queryResults = await Context.QueryOver<WhippetSetting>()
                    .JoinQueryOver(hbsg => hbsg.Group)
                    .Where(g => g.ID == group.ID)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<WhippetSetting>>(WhippetResult.Success, queryResults);
            }
        }
    }
}
