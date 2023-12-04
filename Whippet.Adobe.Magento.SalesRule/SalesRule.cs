using System;
using NodaTime;
using Athi.Whippet.Extensions;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Store;
using Athi.Whippet.Adobe.Magento.Customer;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;
using Athi.Whippet.Adobe.Magento.Store.Extensions;

namespace Athi.Whippet.Adobe.Magento.SalesRule
{
    /// <summary>
    /// Represents a sales rule in Magento. Sales rules apply discounts based on certain parameters to an order or product.
    /// </summary>
    public class SalesRule : MagentoRestEntity<SalesRuleInterface>, IMagentoEntity, ISalesRule, IEqualityComparer<ISalesRule>, IMagentoRestEntity, IMagentoRestEntity<SalesRuleInterface>
    {
        private SalesRuleCondition _condition;
        private SalesRuleCondition _actionCondition;

        /// <summary>
        /// Gets or sets the rule name.
        /// </summary>
        public virtual string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the display labels for the sales rule.
        /// </summary>
        public virtual IEnumerable<SalesRuleLabel> StoreLabels
        { get; set; }

        /// <summary>
        /// Gets or sets the sales rule description.
        /// </summary>
        public virtual string Description
        { get; set; }

        /// <summary>
        /// Gets or sets the websites the rule applies to.
        /// </summary>
        public virtual IEnumerable<StoreWebsite> Websites
        { get; set; }

        /// <summary>
        /// Gets or sets the websites the rule applies to.
        /// </summary>
        IEnumerable<IStoreWebsite> ISalesRule.Websites
        {
            get
            {
                return Websites;
            }
            set
            {
                Websites = (value == null) ? null : value.Select(w => w.ToStoreWebsite());
            }
        }
        
        /// <summary>
        /// Gets or sets the customer groups that the rule applies to.
        /// </summary>
        public virtual IEnumerable<CustomerGroup> CustomerGroups
        { get; set; }

        /// <summary>
        /// Gets or sets the customer groups that the rule applies to.
        /// </summary>
        IEnumerable<ICustomerGroup> ISalesRule.CustomerGroups
        {
            get
            {
                return CustomerGroups;
            }
            set
            {
                CustomerGroups = (value == null) ? null : value.Select(c => c.ToCustomerGroup());
            }
        }
        
        /// <summary>
        /// Gets or sets the effective date of the coupon.
        /// </summary>
        public virtual Instant? EffectiveDate
        { get; set; }

        /// <summary>
        /// Gets or sets the expiration date of the coupon.
        /// </summary>
        public virtual Instant? ExpirationDate
        { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of uses per customer.
        /// </summary>
        public virtual int UsesPerCustomer
        { get; set; }

        /// <summary>
        /// Gets or sets the sales rule condition.
        /// </summary>
        public virtual SalesRuleCondition Condition
        {
            get
            {
                if (_condition == null)
                {
                    _condition = new SalesRuleCondition();
                }

                return _condition;
            }
            set
            {
                _condition = value;
            }
        }

        /// <summary>
        /// Gets or sets the action rule condition.
        /// </summary>
        public virtual SalesRuleCondition ActionCondition
        {
            get
            {
                if (_actionCondition == null)
                {
                    _actionCondition = new SalesRuleCondition();
                }

                return _actionCondition;
            }
            set
            {
                _actionCondition = value;
            }
        }
        
        /// <summary>
        /// Specifies whether rule processing should stop once the current rule has been processed.
        /// </summary>
        public virtual bool StopRulesProcessing
        { get; set; }

        /// <summary>
        /// Specifies whether the sales rule is an advanced rule.
        /// </summary>
        public virtual bool IsAdvanced
        { get; set; }
        
        /// <summary>
        /// Gets or sets the associated product IDs.
        /// </summary>
        public virtual IEnumerable<int> ProductIDs
        { get; set; }

        /// <summary>
        /// Gets or sets the sort order flag.
        /// </summary>
        public virtual int SortOrder
        { get; set; }

        /// <summary>
        /// Gets or sets the simple action of the rule.
        /// </summary>
        public virtual string SimpleAction
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount applied.
        /// </summary>
        public virtual decimal DiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the maximum quantity discount that can be applied.
        /// </summary>
        public virtual decimal DiscountQuantity
        { get; set; }

        /// <summary>
        /// Gets or sets the discount step.
        /// </summary>
        public virtual int Step
        { get; set; }

        /// <summary>
        /// Specifies whether the discount is applied to shipping.
        /// </summary>
        public virtual bool AppliesToShipping
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount of times the rule has been used.
        /// </summary>
        public virtual int TimesUsed
        { get; set; }

        /// <summary>
        /// Specifies whether the rule is in the RSS feed.
        /// </summary>
        public virtual bool IsRSS
        { get; set; }

        /// <summary>
        /// Gets or sets the coupon type.
        /// </summary>
        public virtual string CouponType
        { get; set; }

        /// <summary>
        /// Specifies whether to automatically generate a coupon.
        /// </summary>
        public virtual bool AutoGenerateCoupon
        { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of uses per coupon.
        /// </summary>
        public virtual int UsesPerCoupon
        { get; set; }

        /// <summary>
        /// Gets or sets whether to grant free shipping.
        /// </summary>
        public virtual string SimpleFreeShipping
        { get; set; }

        /// <summary>
        /// Gets or sets the number of rewards points to add or subtract from the customer's balance.
        /// </summary>
        public virtual int RewardPointsDelta
        { get; set; }
        
        /// <summary>
        /// Specifies whether the sales rule is currently active.
        /// </summary>
        public virtual bool Active
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRule"/> class with no arguments.
        /// </summary>
        public SalesRule()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRule"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public SalesRule(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRule"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public SalesRule(SalesRuleInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is ISalesRule)) ? false : Equals((ISalesRule)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ISalesRule obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ISalesRule x, ISalesRule y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.Name?.Trim(), y.Name?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                        && (((x.StoreLabels == null) && (y.StoreLabels == null)) || ((x.StoreLabels != null) && x.StoreLabels.SequenceEqual(y.StoreLabels)))
                        && String.Equals(x.Description?.Trim(), y.Description?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                        && (((x.Websites == null) && (y.Websites == null)) || ((x.Websites != null) && x.Websites.SequenceEqual(y.Websites)))
                        && x.EffectiveDate.GetValueOrDefault().Equals(y.EffectiveDate.GetValueOrDefault())
                        && x.ExpirationDate.GetValueOrDefault().Equals(y.ExpirationDate.GetValueOrDefault())
                        && x.UsesPerCustomer == y.UsesPerCustomer
                        && (((x.Condition == null) && (y.Condition == null)) || ((x.Condition != null) && x.Condition.Equals(y.Condition)))
                        && (((x.ActionCondition == null) && (y.ActionCondition == null)) || ((x.Condition != null) && x.ActionCondition.Equals(y.ActionCondition)))
                        && x.StopRulesProcessing == y.StopRulesProcessing
                        && x.IsAdvanced == y.IsAdvanced
                        && (((x.ProductIDs == null) && (y.ProductIDs == null)) || ((x.ProductIDs != null) && x.ProductIDs.Equals(y.ProductIDs)))
                        && x.SortOrder == y.SortOrder
                        && String.Equals(x.SimpleAction?.Trim(), y.SimpleAction?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                        && x.DiscountAmount == y.DiscountAmount
                        && x.DiscountQuantity == y.DiscountQuantity
                        && x.Step == y.Step
                        && x.AppliesToShipping == y.AppliesToShipping
                        && x.TimesUsed == y.TimesUsed
                        && x.IsRSS == y.IsRSS
                        && String.Equals(x.CouponType?.Trim(), y.CouponType?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                        && x.AutoGenerateCoupon == y.AutoGenerateCoupon
                        && x.UsesPerCoupon == y.UsesPerCoupon
                        && String.Equals(x.SimpleFreeShipping?.Trim(), y.SimpleFreeShipping?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                        && x.RewardPointsDelta == y.RewardPointsDelta
                        && (((x.Server == null) && (y.Server == null)) || ((x.Server != null) && x.Server.Equals(y.Server)))
                        && (((x.RestEndpoint == null) && (y.RestEndpoint == null)) || ((x.RestEndpoint != null) && x.RestEndpoint.Equals(y.RestEndpoint)));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="SalesRuleInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="SalesRuleInterface"/>.</returns>
        public override SalesRuleInterface ToInterface()
        {
            SalesRuleInterface rule = new SalesRuleInterface();

            rule.ID = ID;
            rule.Name = Name;
            rule.StoreLabels = (StoreLabels == null) ? null : StoreLabels.Select(s => s.ToInterface()).ToArray();
            rule.Description = Description;
            rule.WebsiteIDs = (Websites == null) ? null : Websites.Select(w => w.ID).ToArray();
            rule.CustomerGroupIDs = (CustomerGroups == null) ? null : CustomerGroups.Select(c => c.ID).ToArray();
            rule.EffectiveDate = !EffectiveDate.HasValue ? String.Empty : EffectiveDate.Value.ToDateTimeUtc().ToString();
            rule.ExpirationDate = !ExpirationDate.HasValue ? String.Empty : ExpirationDate.Value.ToDateTimeUtc().ToString();
            rule.UsesPerCustomer = UsesPerCustomer;
            rule.Active = Active;
            rule.Condition = (Condition == null) ? null : Condition.ToInterface();
            rule.ActionCondition = (ActionCondition == null) ? null : ActionCondition.ToInterface();
            rule.StopRulesProcessing = StopRulesProcessing;
            rule.IsAdvanced = IsAdvanced;
            rule.ProductIDs = (ProductIDs == null) ? null : ProductIDs.ToArray();
            rule.SortOrder = SortOrder;
            rule.SimpleAction = SimpleAction;
            rule.DiscountAmount = DiscountAmount;
            rule.DiscountQuantity = DiscountQuantity;
            rule.DiscountStep = Step;
            rule.ApplyToShipping = AppliesToShipping;
            rule.TimesUsed = TimesUsed;
            rule.IsRSS = IsRSS;
            rule.CouponType = CouponType;
            rule.UseAutoGeneration = AutoGenerateCoupon;
            rule.UsesPerCoupon = UsesPerCoupon;
            rule.SimpleFreeShipping = SimpleFreeShipping;
            rule.ExtensionAttributes = new SalesRuleExtensionInterface(RewardPointsDelta);
            
            return rule;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            SalesRule rule = new SalesRule();

            rule.Name = Name;
            rule.StoreLabels = (StoreLabels == null) ? null : StoreLabels.Select(sl => sl);
            rule.Description = Description;
            rule.Websites = (Websites == null) ? null : Websites.Select(w => w.Clone<StoreWebsite>());
            rule.CustomerGroups = (CustomerGroups == null) ? null : CustomerGroups.Select(c => c.Clone<CustomerGroup>());
            rule.EffectiveDate = EffectiveDate;
            rule.ExpirationDate = ExpirationDate;
            rule.UsesPerCustomer = UsesPerCustomer;
            rule.Condition = Condition;
            rule.ActionCondition = ActionCondition;
            rule.StopRulesProcessing = StopRulesProcessing;
            rule.IsAdvanced = IsAdvanced;
            rule.ProductIDs = (ProductIDs == null) ? null : ProductIDs.Select(p => p);
            rule.SortOrder = SortOrder;
            rule.SimpleAction = SimpleAction;
            rule.DiscountAmount = DiscountAmount;
            rule.DiscountQuantity = DiscountQuantity;
            rule.Step = Step;
            rule.AppliesToShipping = AppliesToShipping;
            rule.TimesUsed = TimesUsed;
            rule.IsRSS = IsRSS;
            rule.CouponType = CouponType;
            rule.AutoGenerateCoupon = AutoGenerateCoupon;
            rule.UsesPerCoupon = UsesPerCoupon;
            rule.SimpleFreeShipping = SimpleFreeShipping;
            rule.RewardPointsDelta = RewardPointsDelta;
            rule.Active = Active;
            
            return rule;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(ID);
            hash.Add(Name);
            hash.Add(StoreLabels);
            hash.Add(Description);
            hash.Add(Websites);
            hash.Add(CustomerGroups);
            hash.Add(EffectiveDate);
            hash.Add(ExpirationDate);
            hash.Add(UsesPerCustomer);
            hash.Add(Condition);
            hash.Add(ActionCondition);
            hash.Add(StopRulesProcessing);
            hash.Add(IsAdvanced);
            hash.Add(ProductIDs);
            hash.Add(SortOrder);
            hash.Add(SimpleAction);
            hash.Add(DiscountAmount);
            hash.Add(DiscountQuantity);
            hash.Add(Step);
            hash.Add(AppliesToShipping);
            hash.Add(TimesUsed);
            hash.Add(IsRSS);
            hash.Add(CouponType);
            hash.Add(AutoGenerateCoupon);
            hash.Add(UsesPerCoupon);
            hash.Add(SimpleFreeShipping);
            hash.Add(RewardPointsDelta);
            hash.Add(Active);
            
            return hash.ToHashCode();
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="product"><see cref="ISalesRule"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ISalesRule product)
        {
            ArgumentNullException.ThrowIfNull(product);
            return product.GetHashCode();
        }
        
        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(SalesRuleInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                Name = model.Name;
                StoreLabels = (model.StoreLabels == null) ? null : model.StoreLabels.Select(s => new SalesRuleLabel(s));
                Description = model.Description;
                Websites = (model.WebsiteIDs == null) ? null : model.WebsiteIDs.Select(w => new StoreWebsite(Convert.ToUInt32(w)));
                CustomerGroups = (model.CustomerGroupIDs == null) ? null : model.CustomerGroupIDs.Select(c => new CustomerGroup(Convert.ToUInt32(c)));
                EffectiveDate = String.IsNullOrWhiteSpace(model.EffectiveDate) ? null : Instant.FromDateTimeUtc(DateTime.Parse(model.EffectiveDate).ToUniversalTime(true));
                ExpirationDate = String.IsNullOrWhiteSpace(model.ExpirationDate) ? null : Instant.FromDateTimeUtc(DateTime.Parse(model.ExpirationDate).ToUniversalTime(true));
                UsesPerCustomer = model.UsesPerCustomer;
                Active = model.Active;
                Condition = (model.Condition == null) ? null : new SalesRuleCondition(model.Condition);
                ActionCondition = (model.ActionCondition == null) ? null : new SalesRuleCondition(model.ActionCondition);
                StopRulesProcessing = model.StopRulesProcessing;
                IsAdvanced = model.IsAdvanced;
                ProductIDs = model.ProductIDs;
                SortOrder = model.SortOrder;
                SimpleAction = model.SimpleAction;
                DiscountAmount = model.DiscountAmount;
                DiscountQuantity = model.DiscountQuantity;
                Step = model.DiscountStep;
                AppliesToShipping = model.ApplyToShipping;
                TimesUsed = model.TimesUsed;
                IsRSS = model.IsRSS;
                CouponType = model.CouponType;
                AutoGenerateCoupon = model.UseAutoGeneration;
                UsesPerCoupon = model.UsesPerCoupon;
                SimpleFreeShipping = model.SimpleFreeShipping;
                RewardPointsDelta = (model.ExtensionAttributes == null) ? default(int) : model.ExtensionAttributes.RewardPointsDelta;
            }
        }
    }
}
