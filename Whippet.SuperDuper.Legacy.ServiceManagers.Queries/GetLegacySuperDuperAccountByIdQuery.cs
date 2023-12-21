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
    public sealed class GetLegacySuperDuperAccountByIdQuery : EntityByIdQueryBase<LegacySuperDuperAccount>, IWhippetQuery<LegacySuperDuperAccount>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetLegacySuperDuperAccountByIdQuery"/> class with no arguments.
        /// </summary>
        private GetLegacySuperDuperAccountByIdQuery()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GetLegacySuperDuperAccountByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="LegacySuperDuperAccount"/> to retrieve.</param>
        public GetLegacySuperDuperAccountByIdQuery(int id)
            : base(id)
        { }
    }
}
