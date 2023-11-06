using System;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.Salesforce.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ISalesforceProduct"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ISalesforceProductExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ISalesforceProduct"/> object to a <see cref="SalesforceProduct"/> object.
        /// </summary>
        /// <param name="product"><see cref="ISalesforceProduct"/> object to convert.</param>
        /// <returns><see cref="SalesforceProduct"/> object.</returns>
        public static SalesforceProduct ToSalesforceProduct(this ISalesforceProduct product)
        {
            SalesforceProduct sfProduct = null;

            if (product != null)
            {
                if (product is SalesforceProduct)
                {
                    sfProduct = (SalesforceProduct)(product);
                }
                else
                {
                    sfProduct = new SalesforceProduct();
                    sfProduct.ImportDataRow(product.CreateDataRow__Internal());
                }
            }

            return sfProduct;
        }
    }
}

