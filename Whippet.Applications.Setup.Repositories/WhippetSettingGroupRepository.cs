using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using Athi.Whippet.Data;

namespace Athi.Whippet.Applications.Setup.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="WhippetSettingGroup"/> entity objects.
    /// </summary>
    public class WhippetSettingGroupRepository : WhippetEntityRepository<WhippetSettingGroup>, IWhippetSettingGroupRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSettingGroupRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetSettingGroupRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSettingGroupRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetSettingGroupRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Retrieves all <see cref="WhippetSettingGroup"/> objects for the specified <see cref="IWhippetApplication"/>.
        /// </summary>
        /// <param name="application"><see cref="IWhippetApplication"/> to retrieve the <see cref="WhippetSettingGroup"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<WhippetSettingGroup>> GetSettingGroupsForApplication(IWhippetApplication application)
        {
            if (application == null)
            {
                throw new ArgumentNullException(nameof(application));
            }
            else
            {
                return Task.Run(() => GetSettingGroupsForApplicationAsync(application)).Result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="WhippetSettingGroup"/> objects for the specified <see cref="IWhippetApplication"/>.
        /// </summary>
        /// <param name="application"><see cref="IWhippetApplication"/> to retrieve the <see cref="WhippetSettingGroup"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<WhippetSettingGroup>>> GetSettingGroupsForApplicationAsync(IWhippetApplication application, CancellationToken? cancellationToken = null)
        {
            if (application == null)
            {
                throw new ArgumentNullException(nameof(application));
            }
            else
            {
                IList<WhippetSettingGroup> queryResults = await Context.QueryOver<WhippetSettingGroup>()
                    .JoinQueryOver(wsg => wsg.Application)
                    .Where(t => t.ID == application.ID)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<WhippetSettingGroup>>(WhippetResult.Success, queryResults);
            }
        }
    }
}
