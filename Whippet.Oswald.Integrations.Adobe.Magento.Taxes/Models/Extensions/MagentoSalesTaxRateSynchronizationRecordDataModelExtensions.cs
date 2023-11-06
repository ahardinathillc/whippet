using System;
using Athi.Whippet.Adobe.Magento.Taxes;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Models.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="MagentoSalesTaxRateSynchronizationRecordDataModel"/> objects. This class cannot be inherited.
    /// </summary>
    public static class MagentoSalesTaxRateSynchronizationRecordDataModelExtensions
    {
        /// <summary>
        /// Determines whether the specified <see cref="MagentoSalesTaxRateSynchronizationRecordDataModel"/> object should be skipped or deleted based on the <see cref="ITaxRate.ID"/> value.
        /// </summary>
        /// <param name="model"><see cref="MagentoSalesTaxRateSynchronizationRecordDataModel"/> object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SkipOrDelete(this MagentoSalesTaxRateSynchronizationRecordDataModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            else if (model.Rate != null)
            {
                if (model.Rate.ID < 1)
                {
                    model.SkipRate = true;
                }
                else
                {
                    model.DeleteRate = true;
                }
            }
        }
    }
}

