using System;
using System.Collections;
using System.Collections.Generic;

namespace Athi.Whippet.Adobe.Magento.SalesRule
{
    /// <summary>
    /// Represents an <see cref="ISalesRule"/> condition. This class cannot be inherited.
    /// </summary>
    public sealed class SalesRuleCondition : IEnumerable<SalesRuleCondition>, IEnumerable
    {
        /// <summary>
        /// Gets or sets the condition type.
        /// </summary>
        public string Type
        { get; set; }
        
        /// <summary>
        /// Gets or sets the conditions to apply.
        /// </summary>
        public IEnumerable<SalesRuleCondition> Conditions
        { get; set; }

        /// <summary>
        /// Gets or sets the aggregator type.
        /// </summary>
        public string AggregatorType
        { get; set; }

        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        public string Operator
        { get; set; }

        /// <summary>
        /// Gets or sets the attribute name of the condition.
        /// </summary>
        public string AttributeName
        { get; set; }

        /// <summary>
        /// Gets or sets the value of the condition.
        /// </summary>
        public string Value
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleCondition"/> class with no arguments.
        /// </summary>
        public SalesRuleCondition()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleCondition"/> class with the specified parameters.
        /// </summary>
        /// <param name="type">Condition type.</param>
        /// <param name="conditions">List of conditions to apply.</param>
        /// <param name="aggregatorType">Aggregator type.</param>
        /// <param name="operator">Operator of the condition.</param>
        /// <param name="attributeName">Attribute name.</param>
        /// <param name="value">Value of the condition.</param>
        public SalesRuleCondition(string type, IEnumerable<SalesRuleCondition> conditions, string aggregatorType, string @operator, string attributeName, string value)
            : this()
        {
            Type = type;
            Conditions = conditions;
            AggregatorType = aggregatorType;
            Operator = @operator;
            AttributeName = attributeName;
            Value = value;
        }

        /// <summary>
        /// Gets the enumerator used to iterate over each item in the collection.
        /// </summary>
        /// <returns>Enumerator used to iterate over each item in the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<SalesRuleCondition>)(this)).GetEnumerator();
        }

        /// <summary>
        /// Gets the enumerator used to iterate over each item in the collection.
        /// </summary>
        /// <returns>Enumerator used to iterate over each item in the collection.</returns>
        IEnumerator<SalesRuleCondition> IEnumerable<SalesRuleCondition>.GetEnumerator()
        {
            IEnumerator<SalesRuleCondition> iterator = null;

            if (Conditions != null)
            {
                iterator = Conditions.GetEnumerator();
            }
            else
            {
                Enumerable.Empty<SalesRuleCondition>().GetEnumerator();
            }

            return iterator;
        }
    }
}
