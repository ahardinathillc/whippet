using System;
using Athi.Whippet.Adobe.Magento;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.SalesRule
{
    /// <summary>
    /// Represents a discount that can be applied to a Magento product or SKU.
    /// </summary>
    public class SalesRuleDiscount : MagentoRestEntity<SalesRuleDiscountInterface>, IMagentoEntity, ISalesRuleDiscount, IEqualityComparer<ISalesRuleDiscount>, IMagentoRestEntity, IMagentoRestEntity<SalesRuleDiscountInterface>
    {
        /// <summary>
        /// Gets or sets the rule label.
        /// </summary>
        public virtual string Label
        { get; set; }
        
        /// <summary>
        /// Gets or sets the discount data.
        /// </summary>
        public virtual IEnumerable<SalesRuleDiscountData> Discounts
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleDiscount"/> class with no arguments.
        /// </summary>
        public SalesRuleDiscount()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleDiscount"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public SalesRuleDiscount(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleDiscount"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public SalesRuleDiscount(SalesRuleDiscountInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is ISalesRuleDiscount)) ? false : Equals((ISalesRuleDiscount)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ISalesRuleDiscount obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ISalesRuleDiscount x, ISalesRuleDiscount y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.Label?.Trim(), y.Label?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                            && (((x.Discounts == null) && (y.Discounts == null)) || ((x.Discounts != null) && x.Discounts.SequenceEqual(y.Discounts)))
                            && (((x.Server == null) && (y.Server == null)) || ((x.Server != null) && x.Server.Equals(y.Server)))
                            && (((x.RestEndpoint == null) && (y.RestEndpoint == null)) || ((x.RestEndpoint != null) && x.RestEndpoint.Equals(y.RestEndpoint)));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="SalesRuleDiscountInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="SalesRuleDiscountInterface"/>.</returns>
        public override SalesRuleDiscountInterface ToInterface()
        {
            SalesRuleDiscountInterface ruleInterface = new SalesRuleDiscountInterface();
            ruleInterface.Discounts = (Discounts == null) ? null : Discounts.Select(d => d.ToInterface()).ToArray();
            ruleInterface.RuleLabel = Label;
            ruleInterface.ID = ID;
            
            return ruleInterface;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            SalesRuleDiscount discount = new SalesRuleDiscount();
            discount.ID = ID;
            discount.Discounts = (Discounts == null) ? null : Discounts.Select(d => d);
            discount.Label = Label;
            discount.Server = (Server == null) ? null : Server.Clone<MagentoServer>();
            discount.RestEndpoint = (RestEndpoint == null) ? null : RestEndpoint.Clone<MagentoRestEndpoint>();
            
            return discount;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(ID);
            hash.Add(Discounts);
            hash.Add(Label);

            return hash.ToHashCode();
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="ruleute"><see cref="ISalesRuleDiscount"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ISalesRuleDiscount ruleute)
        {
            ArgumentNullException.ThrowIfNull(ruleute);
            return ruleute.GetHashCode();
        }
        
        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(SalesRuleDiscountInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                Discounts = (model.Discounts == null) ? null : model.Discounts.Select(d => new SalesRuleDiscountData(d));
                Label = model.RuleLabel;
            }
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(Label) ? base.ToString() : Label;
        }
    }
}
