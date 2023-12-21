using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Queries
{
    /// <summary>
    /// Query that retrieves a <see cref="LegacySuperDuperAccount"/> by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetLegacySuperDuperAccountByCustomerNumberQuery : EntityByIdQueryBase<LegacySuperDuperAccount>, IWhippetQuery<LegacySuperDuperAccount>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetLegacySuperDuperAccountByCustomerNumberQuery"/> class with no arguments.
        /// </summary>
        private GetLegacySuperDuperAccountByCustomerNumberQuery()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GetLegacySuperDuperAccountByCustomerNumberQuery"/> class with the specified customer number.
        /// </summary>
        /// <param name="customerNumber">Customer number of the <see cref="LegacySuperDuperAccount"/> to retrieve.</param>
        public GetLegacySuperDuperAccountByCustomerNumberQuery(int customerNumber)
            : base(customerNumber)
        { }
    }
}
