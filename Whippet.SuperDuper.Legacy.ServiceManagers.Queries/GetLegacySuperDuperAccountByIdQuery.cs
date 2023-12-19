using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Data;

namespace Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Queries
{
    /// <summary>
    /// Query that retrieves a <see cref="LegacySuperDuperAccount"/> by its ID. This class cannot be inherited
    /// </summary>
    public sealed class GetLegacySuperDuperAccountByIdQuery : WhippetQuery<LegacySuperDuperAccount>, IWhippetQuery<LegacySuperDuperAccount>
    {
        
    }
}

using System;

namespace Athi.Whippet.Security.ServiceManagers.Queries
{
    /// <summary>
    /// Query that retrieves a <see cref="WhippetUser"/> by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetWhippetUserByIdQuery : WhippetQuery<WhippetUser>, IWhippetQuery<WhippetUser>
    {
        /// <summary>
        /// Gets or sets the <see cref="WhippetEntity.ID"/> to filter by.
        /// </summary>
        public Guid UserId
        { get; set; }

    }
}
