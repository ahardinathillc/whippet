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
    /// Query that retrieves all <see cref="WhippetUserRegistrationVerificationRecord"/> objects for a specific <see cref="WhippetUser"/>.
    /// </summary>
    public class GetWhippetUserRegistrationVerificationRecordsForUserQueryHandler : WhippetUserRegistrationVerificationRecordQueryHandlerBase<GetWhippetUserRegistrationVerificationRecordsForUserQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetUserRegistrationVerificationRecordsForUserQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetWhippetUserRegistrationVerificationRecordsForUserQueryHandler(IWhippetQueryRepository<WhippetUserRegistrationVerificationRecord> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<WhippetUserRegistrationVerificationRecord>>> HandleAsync(GetWhippetUserRegistrationVerificationRecordsForUserQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<WhippetUserRegistrationVerificationRecord>> queryResult = await Repository.GetByUserIdAsync(query.UserId);
                return new WhippetResultContainer<IEnumerable<WhippetUserRegistrationVerificationRecord>>(queryResult.Result, queryResult.Item);
            }
        }
    }
}
