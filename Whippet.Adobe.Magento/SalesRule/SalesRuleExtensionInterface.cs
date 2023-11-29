using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.SalesRule
{
    /// <summary>
    /// Interface that provides extra information about a Magento sales rule.
    /// </summary>
    public class SalesRuleExtensionInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the number of rewards points to apply or subtract when a rule is invoked.
        /// </summary>
        public int RewardPointsDelta
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleExtensionInterface"/> class with no arguments.
        /// </summary>
        public SalesRuleExtensionInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleExtensionInterface"/> class with the specified reward points delta.
        /// </summary>
        /// <param name="rewardPointsDelta">Number of rewards points to apply or subtract when a rule is invoked.</param>
        public SalesRuleExtensionInterface(int rewardPointsDelta)
            : this()
        {
            RewardPointsDelta = rewardPointsDelta;
        }
    }
}
