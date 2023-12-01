using System;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.SalesRule
{
    /// <summary>
    /// Represents a sales rule discount amount.
    /// </summary>
    public struct SalesRuleDiscountData : IExtensionInterfaceMap<SalesRuleDiscountDataInterface>
    {
        /// <summary>
        /// Gets or sets the discount amount.
        /// </summary>
        public decimal Amount
        { get; set; }
        
        /// <summary>
        /// Gets or sets the base amount.
        /// </summary>
        public decimal BaseAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the original amount before the discount was applied.
        /// </summary>
        public decimal OriginalAmount
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleDiscountData"/> struct with no arguments.
        /// </summary>
        static SalesRuleDiscountData()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleDiscountData"/> struct with no arguments.
        /// </summary>
        public SalesRuleDiscountData()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleDiscountData"/> struct with the specified parameters.
        /// </summary>
        /// <param name="amount">Discount amount.</param>
        /// <param name="baseAmount">Base product amount.</param>
        /// <param name="originalAmount">Original product amount.</param>
        public SalesRuleDiscountData(decimal amount, decimal baseAmount, decimal originalAmount)
            : this()
        {
            Amount = amount;
            BaseAmount = baseAmount;
            OriginalAmount = originalAmount;
        }
        
        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="SalesRuleDiscountDataInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="SalesRuleDiscountDataInterface"/>.</returns>
        public SalesRuleDiscountDataInterface ToInterface()
        {
            return new SalesRuleDiscountDataInterface(Amount, BaseAmount, OriginalAmount);
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="SalesRuleDiscountDataInterface"/> object used to populate the object.</param>
        public void FromModel(SalesRuleDiscountDataInterface model)
        {
            if (model != null)
            {
                Amount = model.Amount;
                BaseAmount = model.BaseAmount;
                OriginalAmount = model.OriginalAmount;
            }
        }
    }
}
