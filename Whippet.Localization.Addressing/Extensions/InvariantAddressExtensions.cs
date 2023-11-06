using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Localization.Addressing.Extensions
{
    /// <summary>
    /// Provides extensions for <see cref="InvariantAddress"/> and <see cref="IInvariantAddress"/> objects. This class cannot be inherited.
    /// </summary>
    public static class InvariantAddressExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IInvariantAddress"/> instance to an <see cref="InvariantAddress"/> object.
        /// </summary>
        /// <param name="address"><see cref="IInvariantAddress"/> object to convert.</param>
        /// <returns><see cref="InvariantAddress"/> object.</returns>
        public static InvariantAddress ToInvariantAddress(this IInvariantAddress address)
        {
            InvariantAddress ia = null;

            if (address != null)
            {
                if (address is InvariantAddress)
                {
                    ia = ((InvariantAddress)(address));
                }
                else
                {
                    ia = new InvariantAddress(address.ID, address.LineOne, address.LineTwo, address.LineThree, address.LineFour, address.City?.ToCity(), address.PostalCode?.ToPostalCode());
                }
            }

            return ia;
        }
    }
}
