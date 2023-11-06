using System;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Taxes.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ITaxClass"/> objects.
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

            if (taxClass != null)
            {
                if (taxClass is TaxClass)
                {
                    tc = (TaxClass)(taxClass);
                }
                else
                {
                    tc = new TaxClass();
                    tc.ClassID = taxClass.ClassID;
                    tc.ClassName = taxClass.ClassName;
                    tc.ClassType = taxClass.ClassType;
                    tc.Server = taxClass.Server.ToMagentoServer();
                }
            }

            return tc;
        }
    }
}

