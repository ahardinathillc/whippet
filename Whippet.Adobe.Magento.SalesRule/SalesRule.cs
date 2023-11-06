using System;
using NodaTime;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Data;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento.SalesRule
{
    /// <summary>
    /// Allows for the managing of discounts and promotions that are applied to sales orders in Magento.
    /// </summary>
    public class SalesRule : MagentoEntity, IMagentoEntity, ISalesRule, IEqualityComparer<ISalesRule>, IWhippetActiveEntity
    {
        /// <summary>
        /// Gets or sets the unique ID of the <see cref="SalesRule"/>.
        /// </summary>
        public virtual uint RuleID
        {
            get
            {
                return base.ID;
            }
            set
            {
                base.ID = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the sales rule.
        /// </summary>
        public virtual string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the description of the sales rule.
        /// </summary>
        public virtual string Description
        { get; set; }

        /// <summary>
        /// Gets the date from which the sales rule is in effect.
        /// </summary>
        public virtual Instant? FromDate
        { get; set; }

        /// <summary>
        /// Gets the date to which the sales rule is no longer in effect.
        /// </summary>
        public virtual Instant? ToDate
        { get; set; }

        /// <summary>
        /// Specifies the maximum number of times a customer can use the sales rule or zero (0) if there is no limit.
        /// </summary>
        public virtual int UsesPerCustomer
        { get; set; }

        /// <summary>
        /// Indicates whether the sales rule is currently active.
        /// </summary>
        public virtual bool Active
        { get; set; }

        /// <summary>
        /// Gets a JSON serialization of the conditions needed for the sales rule to take effect.
        /// </summary>
        public virtual string SerializedConditions
        { get; set; }

        /// <summary>
        /// Gets a JSON serialization of the actions performed by the sales rule.
        /// </summary>
        public virtual string SerializedActions
        { get; set; }

        /// <summary>
        /// Indicates whether further rules should be processed after the current rule is encountered.
        /// </summary>
        public virtual bool StopProcessingRules
        { get; set; }

        /// <summary>
        /// Indicates whether the sales rule is an advanced rule.
        /// </summary>
        public virtual bool IsAdvanced
        { get; set; }

        /// <summary>
        /// Gets or sets a delimited list of product IDs that the rule applies to specifically.
        /// </summary>
        public virtual string ProductIDs
        { get; set; }

        /// <summary>
        /// Specifies the sort order of the sales rule.
        /// </summary>
        public virtual uint SortOrder
        { get; set; }

        /// <summary>
        /// Provides a short description of what the sales rule does.
        /// </summary>
        public virtual string SimpleAction
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount to apply.
        /// </summary>
        public virtual decimal DiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the number of discounts to apply.
        /// </summary>
        public virtual decimal? DiscountQuantity
        { get; set; }

        /// <summary>
        /// Gets or sets the discount step.
        /// </summary>
        public virtual uint DiscountStep
        { get; set; }

        /// <summary>
        /// Indicates whether the sales rule can be applied to shipping costs.
        /// </summary>
        public virtual bool ApplyToShipping
        { get; set; }

        /// <summary>
        /// Represents the number of times the sales rule has been applied.
        /// </summary>
        public virtual uint TimesUsed
        { get; set; }

        /// <summary>
        /// Indicates whether the sales rule is an RSS rule origin.
        /// </summary>
        public virtual bool IsRSS
        { get; set; }

        /// <summary>
        /// Indicates whether the sales rule is a coupon.
        /// </summary>
        public virtual bool IsCouponType
        { get; set; }

        /// <summary>
        /// Specifies whether auto-generation should be used for the sales rule.
        /// </summary>
        public virtual bool UseAutoGeneration
        { get; set; }

        /// <summary>
        /// Specifies the maximum number of uses that can be applied per coupon.
        /// </summary>
        public virtual int UsesPerCoupon
        { get; set; }

        /// <summary>
        /// Indicates whether the sales rule is a simple free shipping rule.
        /// </summary>
        public virtual bool IsSimpleFreeShipping
        { get; set; }

        /// <summary>
        /// Gets or sets the row identifier of the current record.
        /// </summary>
        public virtual uint RowID
        { get; set; }

        /// <summary>
        /// Gets or sets the update ID.
        /// </summary>
        public virtual ulong CreatedIn
        { get; set; }

        /// <summary>
        /// Gets or sets the next update ID.
        /// </summary>
        public virtual ulong UpdatedIn
        { get; set; }

        /// <summary>
        /// Specifies whether to use custom text on the coupon.
        /// </summary>
        public virtual bool UseCustomCouponText
        { get; set; }

        /// <summary>
        /// Specifies whether the coupon should be applied to the highest priced item.
        /// </summary>
        public virtual bool UseCouponOnHighestPricedItem
        { get; set; }

        /// <summary>
        /// Specifies whether the coupon should be applied to the highest priced item.
        /// </summary>
        public virtual bool UseCouponOnHighestPricedItem2
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRule"/> class with no arguments.
        /// </summary>
        public SalesRule()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRule"/> class with the specified rule ID and <see cref="MagentoServer"/>.
        /// </summary>
        /// <param name="ruleId">Rule ID.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        public SalesRule(uint ruleId, MagentoServer server)
            : base(ruleId, server)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return (obj == null || !(obj is ISalesRule)) ? false : Equals(obj as ISalesRule);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
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
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = x.Active == y.Active
                    && x.ApplyToShipping == y.ApplyToShipping
                    && x.CreatedIn == y.CreatedIn
                    && String.Equals(x.Description, y.Description, StringComparison.InvariantCultureIgnoreCase)
                    && x.DiscountAmount == y.DiscountAmount
                    && x.DiscountQuantity.GetValueOrDefault().Equals(y.DiscountQuantity.GetValueOrDefault())
                    && x.DiscountStep == y.DiscountStep
                    && x.FromDate.GetValueOrDefault().Equals(y.FromDate.GetValueOrDefault())
                    && x.ID == y.ID
                    && x.IsAdvanced == y.IsAdvanced
                    && x.IsCouponType == y.IsCouponType
                    && x.IsRSS == y.IsRSS
                    && x.IsSimpleFreeShipping == y.IsSimpleFreeShipping
                    && String.Equals(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.ProductIDs, y.ProductIDs, StringComparison.InvariantCultureIgnoreCase)
                    && x.RowID == y.RowID
                    && x.RuleID == y.RuleID
                    && String.Equals(x.SerializedActions, y.SerializedActions, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.SerializedConditions, y.SerializedConditions, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.SimpleAction, y.SimpleAction, StringComparison.InvariantCultureIgnoreCase)
                    && x.SortOrder == y.SortOrder
                    && x.StopProcessingRules == y.StopProcessingRules
                    && x.TimesUsed == y.TimesUsed
                    && x.ToDate.GetValueOrDefault().Equals(y.ToDate.GetValueOrDefault())
                    && x.UpdatedIn == y.UpdatedIn
                    && x.UseAutoGeneration == y.UseAutoGeneration
                    && x.UseCouponOnHighestPricedItem == y.UseCouponOnHighestPricedItem
                    && x.UseCouponOnHighestPricedItem2 == y.UseCouponOnHighestPricedItem2
                    && x.UseCustomCouponText == y.UseCustomCouponText
                    && x.UsesPerCoupon == y.UsesPerCoupon
                    && x.UsesPerCustomer == y.UsesPerCustomer;
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
        /// <param name="obj"><see cref="ISalesRule"/> object.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ISalesRule obj)
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
            return Name;
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

