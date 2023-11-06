using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data;

namespace Athi.Whippet.Localization.Addressing.Installer
{
    /// <summary>
    /// Installs default <see cref="City"/> objects into the Whippet database.
    /// </summary>
    public interface ICitySeed : IWhippetEntitySeed, IWhippetEntitySeed<City>
    { }
}
