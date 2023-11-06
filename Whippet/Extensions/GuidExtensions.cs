using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="Guid"/> objects. This class cannot be inherited.
    /// </summary>
    public static class GuidExtensions
    {
        /// <summary>
        /// Returns the value of the <see cref="Guid"/> if one is present or generates a new <see cref="Guid"/> value.
        /// </summary>
        /// <param name="guid"><see cref="Guid"/> nullable value.</param>
        /// <returns><see cref="Guid"/> value.</returns>
        public static Guid GetValueOrNew(this Guid? guid)
        {
            return guid.GetValueOrDefault(Guid.NewGuid());
        }
    }
}
