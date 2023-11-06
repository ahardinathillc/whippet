using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Marker interface for <see cref="IWhippetEntity"/> objects that are read-only, that is, entities that are protected. Typically these are entities that are managed by the system.
    /// </summary>
    public interface IWhippetReadOnlyEntity : IWhippetEntity
    { }
}
