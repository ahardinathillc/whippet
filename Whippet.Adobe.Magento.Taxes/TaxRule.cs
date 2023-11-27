using System;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Taxes.Extensions;

namespace Athi.Whippet.Adobe.Magento.Taxes
{
    /// <summary>
    /// Represents a tax rule in Magento.
    /// </summary>
    public class TaxRule : MagentoRestEntity<TaxRuleInterface>, IMagentoEntity, ITaxRule, IEqualityComparer<ITaxRule>, IMagentoRestEntity<TaxRuleInterface>, IMagentoRestEntity
    {
        /// <summary>
        /// Gets or sets the tax rule code.
        /// </summary>
        public virtual string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        public virtual int Priority
        { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        public virtual int Position
        { get; set; }

        /// <summary>
        /// Gets or sets the customer tax classes.
        /// </summary>
        public virtual IEnumerable<TaxClass> CustomerTaxClasses
        { get; set; }

        /// <summary>
        /// Gets or sets the customer tax classes.
        /// </summary>
        IEnumerable<ITaxClass> ITaxRule.CustomerTaxClasses
        {
            get
            {
                return (CustomerTaxClasses == null) ? null : CustomerTaxClasses.Select(c => c);
            }
            set
            {
                CustomerTaxClasses = (value == null) ? null : value.Select(c => c.ToTaxClass());
            }
        }
        
        /// <summary>
        /// Gets or sets the product tax classes.
        /// </summary>
        public virtual IEnumerable<TaxClass> ProductTaxClasses
        { get; set; }

        /// <summary>
        /// Gets or sets the product tax classes.
        /// </summary>
        IEnumerable<ITaxClass> ITaxRule.ProductTaxClasses
        {
            get
            {
                return (ProductTaxClasses == null) ? null : ProductTaxClasses.Select(c => c);
            }
            set
            {
                ProductTaxClasses = (value == null) ? null : value.Select(c => c.ToTaxClass());
            }
        }
        
        /// <summary>
        /// Gets or sets the tax rates that the rule applies.
        /// </summary>
        public virtual IEnumerable<TaxRate> TaxRates
        { get; set; }

        /// <summary>
        /// Gets or sets the tax rates that the rule applies.
        /// </summary>
        IEnumerable<ITaxRate> ITaxRule.TaxRates
        {
            get
            {
                return (TaxRates == null) ? null : TaxRates.Select(c => c);
            }
            set
            {
                TaxRates = (value == null) ? null : value.Select(c => c.ToTaxRate());
            }
        }
        
        /// <summary>
        /// Specifies whether the subtotal should be calculated for the rule.
        /// </summary>
        public virtual bool CalculateSubtotal
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRule"/> class with no arguments.
        /// </summary>
        public TaxRule()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRule"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public TaxRule(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRule"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public TaxRule(TaxRuleInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is ITaxRule)) ? false : Equals((ITaxRule)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
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
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = (((x.CustomerTaxClasses == null) && (y.CustomerTaxClasses == null)) || ((x.CustomerTaxClasses != null) && x.CustomerTaxClasses.SequenceEqual(y.CustomerTaxClasses)))
                         && (x.CalculateSubtotal == y.CalculateSubtotal)
                         && (((x.ProductTaxClasses == null) && (y.ProductTaxClasses == null)) || ((x.ProductTaxClasses != null) && x.ProductTaxClasses.SequenceEqual(y.ProductTaxClasses)))
                         && (((x.TaxRates == null) && (y.TaxRates == null)) || ((x.TaxRates != null) && x.TaxRates.SequenceEqual(y.TaxRates)))
                         && String.Equals(x.Code?.Trim(), y.Code?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && (x.Position == y.Position)
                         && (x.Priority == y.Priority);
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="TaxRuleInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="TaxRuleInterface"/>.</returns>
        public override TaxRuleInterface ToInterface()
        {
            TaxRuleInterface taxInterface = new TaxRuleInterface();
            taxInterface.ID = ID;
            taxInterface.CalculateSubtotal = CalculateSubtotal;
            taxInterface.Code = Code;
            taxInterface.Position = Position;
            taxInterface.Priority = Priority;
            taxInterface.TaxRateIDs = (TaxRates == null) ? null : TaxRates.Select(tr => tr.ID).ToArray();
            taxInterface.CustomerTaxClassIDs = (CustomerTaxClasses == null) ? null : CustomerTaxClasses.Select(ct => ct.ID).ToArray();
            taxInterface.ProductTaxClassIDs = (ProductTaxClasses == null) ? null : ProductTaxClasses.Select(pt => pt.ID).ToArray();
            
            return taxInterface;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            TaxRule taxRule = new TaxRule();

            taxRule.ID = ID;
            taxRule.CustomerTaxClasses = (CustomerTaxClasses == null) ? null : CustomerTaxClasses.Select(ct => ct.Clone<TaxClass>());
            taxRule.ProductTaxClasses = (ProductTaxClasses == null) ? null : ProductTaxClasses.Select(ct => ct.Clone<TaxClass>());
            taxRule.CalculateSubtotal = CalculateSubtotal;
            taxRule.TaxRates = (TaxRates == null) ? null : TaxRates.Select(ct => ct.Clone<TaxRate>());
            taxRule.Code = Code;
            taxRule.Position = Position;
            taxRule.Priority = Priority;
            taxRule.Server = Server.Clone<MagentoServer>();
            taxRule.RestEndpoint = RestEndpoint.Clone<MagentoRestEndpoint>();
            
            return taxRule;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(ID);
            hash.Add(CustomerTaxClasses);
            hash.Add(ProductTaxClasses);
            hash.Add(CalculateSubtotal);
            hash.Add(TaxRates);
            hash.Add(Code);
            hash.Add(Position);
            hash.Add(Priority);
            
            return hash.ToHashCode();
        }

        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(TaxRuleInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                CustomerTaxClasses = (model.CustomerTaxClassIDs == null) ? null : model.CustomerTaxClassIDs.Select(ctc => new TaxClass(Convert.ToUInt32(ctc)));
                ProductTaxClasses = (model.ProductTaxClassIDs == null) ? null : model.ProductTaxClassIDs.Select(ctc => new TaxClass(Convert.ToUInt32(ctc)));
                CalculateSubtotal = model.CalculateSubtotal;
                TaxRates = (model.TaxRateIDs == null) ? null : model.TaxRateIDs.Select(ctc => new TaxRate(Convert.ToUInt32(ctc)));
                Code = model.Code;
                Position = model.Position;
                Priority = model.Priority;
            }
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="taxRule"><see cref="ITaxRule"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ITaxRule taxRule)
        {
            ArgumentNullException.ThrowIfNull(taxRule);
            return taxRule.GetHashCode();
        }
        
        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(Code) ? base.ToString() : Code;
        }
    }
}
