using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data;

namespace Athi.Whippet.Localization.Addressing.Seed
{
    /// <summary>
    /// Installs default <see cref="PostalCode"/> objects into the Whippet database.
    /// </summary>
    public interface IPostalCodeSeed : IWhippetEntitySeed, IWhippetEntitySeed<PostalCode>
    { }
}
