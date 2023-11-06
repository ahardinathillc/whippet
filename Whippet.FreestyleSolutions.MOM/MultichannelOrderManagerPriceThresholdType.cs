using System;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents a price threshold type.
    /// </summary>
    public enum MultichannelOrderManagerPriceThresholdType : byte
    {
        MinimumRetailPrice = 1,
        MinimumMarkupPercentage = 2,
        MinimumMarkupAmount = 3
    }
}

