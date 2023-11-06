using System;
using NodaTime;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.SalesRule.Extensions;
using Athi.Whippet.Adobe.Magento.EAV;
using Athi.Whippet.Adobe.Magento.EAV.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento.SalesRule
{
    /// <summary>
    /// Represents an aggregated report line item for an <see cref="SalesRuleCoupon"/> usage report.
    /// </summary>
    public class SalesRuleCouponAggregatedUpdatedReport : MagentoEntity, IMagentoEntity, ISalesRuleCouponAggregatedReport, ISalesRuleCouponAggregatedUpdatedReport, IEqualityComparer<ISalesRuleCouponAggregatedUpdatedReport>
    {
        private Store _store;

        /// <summary>
        /// Gets or sets the unique ID of the <see cref="SalesRuleCouponAggregatedUpdatedReport"/>.
        /// </summary>
        public virtual uint ReportEntryID
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
        /// Gets or sets the date for which the coupon was used.
        /// </summary>
        public virtual Instant Period
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="EAV.Store"/> that the coupon was applied at.
        /// </summary>
        public virtual Store Store
        {
            get
            {
                if (_store == null)
                {
                    _store = new Store();
                }

                return _store;
            }
            set
            {
                _store = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IStore"/> that the coupon was applied at.
        /// </summary>
        IStore ISalesRuleCouponAggregatedReport.Store
        {
            get
            {
                return Store;
            }
            set
            {
                Store = value.ToStore();
            }
        }

        /// <summary>
        /// Gets or sets the status of the order the coupon was used on.
        /// </summary>
        public virtual string OrderStatus
        { get; set; }

        /// <summary>
        /// Gets or sets the coupon code that was used.
        /// </summary>
        public virtual string CouponCode
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount of uses for the period that the coupon was used.
        /// </summary>
        public virtual int CouponUses
        { get; set; }

        /// <summary>
        /// Gets or sets the order subtotal.
        /// </summary>
        public virtual decimal Subtotal
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount that was applied.
        /// </summary>
        public virtual decimal Discount
        { get; set; }

        /// <summary>
        /// Gets or sets the order total.
        /// </summary>
        public virtual decimal Total
        { get; set; }

        /// <summary>
        /// Gets or sets the actual subtotal amount.
        /// </summary>
        public virtual decimal Subtotal_Actual
        { get; set; }

        /// <summary>
        /// Gets or sets the actual discount amount that was applied.
        /// </summary>
        public virtual decimal Discount_Actual
        { get; set; }

        /// <summary>
        /// Gets or sets the actual total amount that was applied.
        /// </summary>
        public virtual decimal Total_Actual
        { get; set; }

        /// <summary>
        /// Gets or sets the rule name.
        /// </summary>
        public virtual string RuleName
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleCouponAggregatedUpdatedReport"/> class with no arguments.
        /// </summary>
        public SalesRuleCouponAggregatedUpdatedReport()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleCouponAggregatedUpdatedReport"/> class with the specified rule ID and <see cref="MagentoServer"/>.
        /// </summary>
        /// <param name="ruleId">Rule ID.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        public SalesRuleCouponAggregatedUpdatedReport(uint ruleId, MagentoServer server)
            : base(ruleId, server)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return (obj == null || !(obj is ISalesRuleCouponAggregatedUpdatedReport)) ? false : Equals(obj as ISalesRuleCouponAggregatedUpdatedReport);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ISalesRuleCouponAggregatedUpdatedReport obj)
        {
            return Equals(obj as ISalesRuleCouponAggregatedReport);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ISalesRuleCouponAggregatedReport obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ISalesRuleCouponAggregatedUpdatedReport x, ISalesRuleCouponAggregatedUpdatedReport y)
        {
            return Equals(x as ISalesRuleCouponAggregatedReport, y as ISalesRuleCouponAggregatedReport);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ISalesRuleCouponAggregatedReport x, ISalesRuleCouponAggregatedReport y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.CouponCode, y.CouponCode, StringComparison.InvariantCultureIgnoreCase)
                    && x.ReportEntryID == y.ReportEntryID
                    && x.CouponUses == y.CouponUses
                    && x.Discount == y.Discount
                    && x.Discount_Actual == y.Discount_Actual
                    && String.Equals(x.OrderStatus, y.OrderStatus, StringComparison.InvariantCultureIgnoreCase)
                    && x.Period.Equals(y.Period)
                    && String.Equals(x.RuleName, y.RuleName, StringComparison.InvariantCultureIgnoreCase)
                    && ((x.Store == null && y.Store == null) || (x.Store != null && x.Store.Equals(y.Store)))
                    && x.Subtotal == y.Subtotal
                    && x.Subtotal_Actual == y.Subtotal_Actual
                    && x.Total == y.Total
                    && x.Total_Actual == y.Total_Actual;
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
        /// <param name="obj"><see cref="ISalesRuleCouponAggregatedReport"/> object.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ISalesRuleCouponAggregatedReport obj)
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
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="ISalesRuleCouponAggregatedUpdatedReport"/> object.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ISalesRuleCouponAggregatedUpdatedReport obj)
        {
            return GetHashCode(obj as ISalesRuleCouponAggregatedReport);
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return Period.ToString() + " :: " + CouponCode + " (" + CouponUses + ")";
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

