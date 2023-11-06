using System;
using System.ComponentModel;

namespace Athi.Whippet.Salesforce.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="SalesforceForecastCategory"/> objects. This class cannot be inherited.
    /// </summary>
    public static class SalesforceForecastCategoryExtensions
    {
        /// <summary>
        /// Returns the Salesforce picklist value name for the specified <see cref="SalesforceForecastCategory"/> value.
        /// </summary>
        /// <param name="category"><see cref="SalesforceForecastCategory"/> value.</param>
        /// <returns>Valid forecast category name.</returns>
        /// <exception cref="InvalidEnumArgumentException" />
        public static string ToCategoryName(this SalesforceForecastCategory category)
        {
            switch (category)
            {
                case SalesforceForecastCategory.BestCase:
                    return "Best Case";
                case SalesforceForecastCategory.Closed:
                    return "Closed";
                case SalesforceForecastCategory.Forecast:
                    return "Commit";
                case SalesforceForecastCategory.MostLikely:
                    return "Most Likely";
                case SalesforceForecastCategory.Omitted:
                    return "Omitted";
                case SalesforceForecastCategory.Pipeline:
                    return "Pipeline";
                default:
                    throw new InvalidEnumArgumentException(nameof(category), Convert.ToInt32(category), typeof(SalesforceForecastCategory));
            }
        }
    }
}

