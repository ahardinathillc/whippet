using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Json.Newtonsoft.Converters;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento.Taxes
{
    /// <summary>
    /// Represents a tax rule in Magento.
    /// </summary>
    public class TaxRule : MagentoEntity, IMagentoEntity, ITaxRule, IEqualityComparer<ITaxRule>
    {
        private IReadOnlyList<TaxClass> _customerClasses;
        private IReadOnlyList<TaxClass> _productClasses;
        private IReadOnlyList<TaxRate> _rates;

        /// <summary>
        /// Specifies whether the subtotal of the order should be calculated with respect to the rule.
        /// </summary>
        [JsonProperty("calculate_subtotal")]
        public virtual bool CalculateSubtotal
        { get; set; }

        /// <summary>
        /// Gets or sets the tax rule code.
        /// </summary>
        [JsonProperty("code")]
        public virtual string Code
        { get; set; }

        /// <summary>
        /// Gets the customer tax classes that the rule applies to. This property is read-only.
        /// </summary>
        public virtual IEnumerable<TaxClass> CustomerTaxClasses
        {
            get
            {
                if (_customerClasses == null)
                {
                    _customerClasses = new List<TaxClass>().AsReadOnly();
                }

                return _customerClasses;
            }
            protected set
            {
                _customerClasses = (value == null) ? null : new List<TaxClass>(value).AsReadOnly();
            }
        }

        /// <summary>
        /// Gets the customer tax classes that the rule applies to. This property is read-only.
        /// </summary>
        IEnumerable<ITaxClass> ITaxRule.CustomerTaxClasses
        {
            get
            {
                return CustomerTaxClasses;
            }
        }

        /// <summary>
        /// Gets or sets the customer tax class IDs that the rule applies to. Setting this property will reset all entries in <see cref="CustomerTaxClasses"/>.
        /// </summary>
        [JsonProperty("customer_tax_class_ids")]
        [JsonConverter(typeof(PrimitiveEnumerableConverter))]
        public virtual IEnumerable<int> CustomerTaxClassIDs
        {
            get
            {
                return CustomerTaxClasses.Select(ctc => Convert.ToInt32(ctc.ClassID));
            }
            set
            {
                if (value != null && value.Any())
                {
                    CustomerTaxClasses = new List<TaxClass>(value.Select(id => new TaxClass(Convert.ToUInt32(id), Server))).AsReadOnly();
                }
                else
                {
                    CustomerTaxClasses = null;
                }
            }
        }

        /// <summary>
        /// Specifies the order in which the tax rule is applied.
        /// </summary>
        [JsonProperty("position")]
        public virtual int SortOrder
        { get; set; }

        /// <summary>
        /// Specifies the priority of the tax rule.
        /// </summary>
        [JsonProperty("priority")]
        public virtual int Priority
        { get; set; }

        /// <summary>
        /// Gets the product tax classes that the rule applies to. This property is read-only.
        /// </summary>
        public virtual IEnumerable<TaxClass> ProductTaxClasses
        {
            get
            {
                if (_productClasses == null)
                {
                    _productClasses = new List<TaxClass>().AsReadOnly();
                }

                return _productClasses;
            }
            protected set
            {
                _productClasses = (value == null) ? null : new List<TaxClass>(value).AsReadOnly();
            }
        }

        /// <summary>
        /// Gets the product tax classes that the rule applies to. This property is read-only.
        /// </summary>
        IEnumerable<ITaxClass> ITaxRule.ProductTaxClasses
        {
            get
            {
                return ProductTaxClasses;
            }
        }

        /// <summary>
        /// Gets or sets the product tax class IDs that the rule applies to. Setting this property will reset all entries in <see cref="ProductTaxClasses"/>.
        /// </summary>
        [JsonProperty("product_tax_class_ids")]
        [JsonConverter(typeof(PrimitiveEnumerableConverter))]
        public virtual IEnumerable<int> ProductTaxClassIDs
        {
            get
            {
                return ProductTaxClasses.Select(ctc => Convert.ToInt32(ctc.ClassID));
            }
            set
            {
                if (value != null && value.Any())
                {
                    ProductTaxClasses = new List<TaxClass>(value.Select(id => new TaxClass(Convert.ToUInt32(id), Server))).AsReadOnly();
                }
                else
                {
                    ProductTaxClasses = null;
                }
            }
        }

        /// <summary>
        /// Gets the tax rates that are applied in the rule. This property is read-only.
        /// </summary>
        public virtual IEnumerable<TaxRate> TaxRates
        {
            get
            {
                if (_rates == null)
                {
                    _rates = new List<TaxRate>().AsReadOnly();
                }

                return _rates;
            }
            protected set
            {
                _rates = (value == null) ? null : new List<TaxRate>(value).AsReadOnly();
            }
        }

        /// <summary>
        /// Gets the tax rates that are applied in the rule. This property is read-only.
        /// </summary>
        IEnumerable<ITaxRate> ITaxRule.TaxRates
        {
            get
            {
                return TaxRates;
            }
        }

        /// <summary>
        /// Gets or sets the product tax rate IDs that are applied in the rule. Setting this property will reset all entries in <see cref="TaxRates"/>.
        /// </summary>
        [JsonProperty("tax_rate_ids")]
        [JsonConverter(typeof(PrimitiveEnumerableConverter))]
        public virtual IEnumerable<int> TaxRateIDs
        {
            get
            {
                return TaxRates.Select(ctc => Convert.ToInt32(ctc.ID));
            }
            set
            {
                if (value != null && value.Any())
                {
                    TaxRates = new List<TaxRate>(value.Select(id => new TaxRate(id, Server))).AsReadOnly();
                }
                else
                {
                    TaxRates = null;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRule"/> class with no arguments.
        /// </summary>
        public TaxRule()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRule"/> class with the specified class ID and <see cref="MagentoServer"/>.
        /// </summary>
        /// <param name="ruleId">Tax rule ID.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        public TaxRule(uint ruleId, MagentoServer server)
            : base(ruleId, server)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return (obj == null || !(obj is ITaxRule)) ? false : Equals(obj as ITaxRule);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ITaxRule obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ITaxRule x, ITaxRule y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = x.CalculateSubtotal == y.CalculateSubtotal
                    && String.Equals(x.Code, y.Code, StringComparison.InvariantCultureIgnoreCase)
                    && ((x.CustomerTaxClassIDs == null && y.CustomerTaxClassIDs == null) || (x.CustomerTaxClassIDs != null && x.CustomerTaxClassIDs.SequenceEqual(y.CustomerTaxClassIDs)))
                    && x.Priority == y.Priority
                    && x.SortOrder == y.SortOrder
                    && ((x.ProductTaxClassIDs == null && y.ProductTaxClassIDs == null) || (x.ProductTaxClassIDs != null && x.ProductTaxClassIDs.SequenceEqual(y.ProductTaxClassIDs)))
                    && ((x.TaxRateIDs == null && y.TaxRateIDs == null) || (x.TaxRateIDs != null && x.TaxRateIDs.SequenceEqual(y.TaxRateIDs)));
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="ITaxRule"/> object.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ITaxRule obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else
            {
                return obj.GetHashCode();
            }
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(Code) ? base.ToString() : Code;
        }

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be inherited.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public override string ToJson<T>()
        {
            return this.SerializeJson(this);
        }
    }
}
