using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Extensions.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.ServiceManagers.Queries;

namespace Athi.Whippet.Security.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles all <see cref="GetWhippetUserRegistrationVerificationRecordsForTenantQuery"/> objects.
    /// </summary>
    public class GetWhippetUserRegistrationVerificationRecordsForTenantQueryHandler : WhippetUserRegistrationVerificationRecordQueryHandlerBase<GetWhippetUserRegistrationVerificationRecordsForTenantQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetUserRegistrationVerificationRecordsForTenantQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetWhippetUserRegistrationVerificationRecordsForTenantQueryHandler(IWhippetQueryRepository<WhippetUserRegistrationVerificationRecord> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<WhippetUserRegistrationVerificationRecord>>> HandleAsync(GetWhippetUserRegistrationVerificationRecordsForTenantQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<WhippetUserRegistrationVerificationRecord>> queryResult = await Repository.GetAsync(query.Tenant);
                return new WhippetResultContainer<IEnumerable<WhippetUserRegistrationVerificationRecord>>(queryResult.Result, queryResult.Item);
            }
        }
    }
}
