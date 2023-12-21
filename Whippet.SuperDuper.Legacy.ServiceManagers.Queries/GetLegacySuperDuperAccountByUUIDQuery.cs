using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Queries
{
    /// <summary>
    /// Query that retrieves a <see cref="LegacySuperDuperAccount"/> by its UUID <see cref="Guid"/>. This class cannot be inherited.
    /// </summary>
    public sealed class GetLegacySuperDuperAccountByUUIDQuery : EntityByUUIDQueryBase<LegacySuperDuperAccount>, IWhippetQuery<LegacySuperDuperAccount>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetLegacySuperDuperAccountByUUIDQuery"/> class with no arguments.
        /// </summary>
        private GetLegacySuperDuperAccountByUUIDQuery()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GetLegacySuperDuperAccountByUUIDQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="LegacySuperDuperAccount"/> to retrieve.</param>
        public GetLegacySuperDuperAccountByUUIDQuery(Guid id)
            : base(id)
        { }
    }
}
