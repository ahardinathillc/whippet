using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data;

namespace Athi.Whippet.Localization.Addressing.Seed
{
    /// <summary>
    /// Installs default <see cref="StateProvince"/> objects into the Whippet database.
    /// </summary>
    public interface IStateProvinceSeed : IWhippetEntitySeed, IWhippetEntitySeed<StateProvince>
    { }
}
