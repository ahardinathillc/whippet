using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Criterion;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Extensions.Threading.Tasks;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Repositories;

namespace Athi.Whippet.Security.Repositories
{
    /// <summary>
    /// Repository for <see cref="WhippetUserRegistrationVerificationRecord"/> objects.
    /// </summary>
    public class WhippetUserRegistrationVerificationRecordRepository : WhippetEntityRepository<WhippetUserRegistrationVerificationRecord>, IWhippetUserRegistrationVerificationRecordRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserRegistrationVerificationRecordRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetUserRegistrationVerificationRecordRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserRegistrationVerificationRecordRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetUserRegistrationVerificationRecordRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Retrieves all <see cref="WhippetUserRegistrationVerificationRecord"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<WhippetUserRegistrationVerificationRecord>> Get(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                return this.RunSync<WhippetResultContainer<IEnumerable<WhippetUserRegistrationVerificationRecord>>>(() => GetAsync(tenant));
            }
        }

        /// <summary>
        /// Retrieves all <see cref="WhippetUserRegistrationVerificationRecord"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<WhippetUserRegistrationVerificationRecord>>> GetAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                IList<WhippetUserRegistrationVerificationRecord> queryResults = await Context.QueryOver<WhippetUserRegistrationVerificationRecord>()
                    .Where(urvr => urvr.Tenant.ID == tenant.ID)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<WhippetUserRegistrationVerificationRecord>>(WhippetResult.Success, queryResults);
            }
        }

        /// <summary>
        /// Retrieves all <see cref="WhippetUserRegistrationVerificationRecord"/> objects for the specified <see cref="IWhippetUser"/> ID.
        /// </summary>
        /// <param name="userId">ID of the <see cref="IWhippetUser"/> to filter by or <see langword="null"/> to list all records that have not yet been activated.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<WhippetUserRegistrationVerificationRecord>> GetByUserId(Guid? userId)
        {
            return this.RunSync<WhippetResultContainer<IEnumerable<WhippetUserRegistrationVerificationRecord>>>(() => GetByUserIdAsync(userId));
        }

        /// <summary>
        /// Retrieves all <see cref="WhippetUserRegistrationVerificationRecord"/> objects for the specified <see cref="IWhippetUser"/> ID.
        /// </summary>
        /// <param name="userId">ID of the <see cref="IWhippetUser"/> to filter by or <see langword="null"/> to list all records that have not yet been activated.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<WhippetUserRegistrationVerificationRecord>>> GetByUserIdAsync(Guid? userId, CancellationToken? cancellationToken = null)
        {
            IList<WhippetUserRegistrationVerificationRecord> queryResults = null;

            if(userId.HasValue)
            {
                queryResults = await Context.QueryOver<WhippetUserRegistrationVerificationRecord>()
                    .WhereNot(urvr => urvr.UserId == null)
                    .Where(urvr => urvr.UserId == userId.Value)
                    .ListAsync();
            }
            else
            {
                queryResults = await Context.QueryOver<WhippetUserRegistrationVerificationRecord>()
                    .Where(urvr => urvr.UserId == null)
                    .ListAsync();
            }

            return new WhippetResultContainer<IEnumerable<WhippetUserRegistrationVerificationRecord>>(WhippetResult.Success, queryResults);
        }
    }
}
