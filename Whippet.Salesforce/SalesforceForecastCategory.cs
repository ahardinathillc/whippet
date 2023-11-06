using System;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// The forecast category automatically determines how opportunities are tracked and totaled in a forecast.
    /// </summary>
    public enum SalesforceForecastCategory
    {
        BestCase,
        Closed,
        Forecast,
        MostLikely,
        Omitted,
        Pipeline
    }
}

