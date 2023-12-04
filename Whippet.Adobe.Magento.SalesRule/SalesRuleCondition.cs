using System;
using System.Collections;
using System.Collections.Generic;

namespace Athi.Whippet.Adobe.Magento.SalesRule
{
    /// <summary>
    /// Represents an <see cref="ISalesRule"/> condition. This class cannot be inherited.
    /// </summary>
    public sealed class SalesRuleCondition : IEnumerable<SalesRuleCondition>, IEnumerable, IExtensionInterfaceMap<SalesRuleConditionInterface>, IEqualityComparer<SalesRuleCondition>
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
        /// Initializes a new instance of the <see cref="SalesRuleCondition"/> class with the specified <see cref="SalesRuleConditionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="SalesRuleConditionInterface"/> object.</param>
        public SalesRuleCondition(SalesRuleConditionInterface model)
            : this()
        {
            FromModel(model);
        }

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
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is SalesRuleCondition)) ? false : Equals((SalesRuleCondition)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(SalesRuleCondition obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(SalesRuleCondition x, SalesRuleCondition y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.Type?.Trim(), y.Type?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && (((x.Conditions == null) && (y.Conditions == null)) || ((x.Conditions != null) && (x.Conditions.SequenceEqual(y.Conditions))))
                         && String.Equals(x.AggregatorType?.Trim(), y.AggregatorType?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.Operator?.Trim(), y.Operator?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.AttributeName?.Trim(), y.AttributeName?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.Value?.Trim(), y.Value?.Trim(), StringComparison.InvariantCultureIgnoreCase);
            }

            return equals;
        }
        
        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="SalesRuleConditionInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="SalesRuleConditionInterface"/>.</returns>
        public SalesRuleConditionInterface ToInterface()
        {
            SalesRuleConditionInterface srcInterface = new SalesRuleConditionInterface();

            srcInterface.ConditionType = Type;
            srcInterface.Conditions = (Conditions == null) ? null : Conditions.Select(c => c.ToInterface()).ToArray();
            srcInterface.AggregatorType = AggregatorType;
            srcInterface.Operator = Operator;
            srcInterface.AttributeName = AttributeName;
            srcInterface.Value = Value;
            srcInterface.ExtensionAttributes = new SalesRuleConditionExtensionInterface();
            
            return srcInterface;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(Type);
            hash.Add(Conditions);
            hash.Add(AggregatorType);
            hash.Add(Operator);
            hash.Add(AttributeName);
            hash.Add(Value);

            return hash.ToHashCode();
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="condition"><see cref="SalesRuleCondition"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(SalesRuleCondition condition)
        {
            ArgumentNullException.ThrowIfNull(condition);
            return condition.GetHashCode();
        }
        
        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="SalesRuleConditionInterface"/> object used to populate the object.</param>
        public void FromModel(SalesRuleConditionInterface model)
        {
            if (model != null)
            {
                Type = model.ConditionType;
                Conditions = (model.Conditions == null) ? null : model.Conditions.Select(c => new SalesRuleCondition(c));
                AggregatorType = model.AggregatorType;
                Operator = model.Operator;
                AttributeName = model.AttributeName;
                Value = model.Value;
            }
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
