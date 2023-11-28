using System;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Taxes.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ITaxClass"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ITaxClassExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ITaxClass"/> object to a <see cref="TaxClass"/> object.
        /// </summary>
        /// <param name="taxClass"><see cref="ITaxClass"/> object to convert.</param>
        /// <returns><see cref="TaxClass"/> object.</returns>
        public static TaxClass ToTaxClass(this ITaxClass taxClass)
        {
            TaxClass tc = null;

            if (taxClass is TaxClass)
            {
                tc = (TaxClass)(taxClass);
            }
            else if (taxClass != null)
            {
                tc = new TaxClass();
                tc.ID = taxClass.ID;
                tc.Server = taxClass.Server.ToMagentoServer();
                tc.RestEndpoint = taxClass.RestEndpoint.ToMagentoRestEndpoint();
                tc.Name = taxClass.Name;
                tc.Type = taxClass.Type;
            }

            return tc;
        }
    }
}
