using System;
using NodaTime;
using Athi.Whippet.Adobe.Magento;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.ParadoxLabs.Magento.Data;
using Athi.Whippet.Adobe.Magento.Customer;
using Athi.Whippet.Adobe.Magento.Store;
using Athi.Whippet.Adobe.Magento.Sales;

namespace Athi.Whippet.ParadoxLabs.Magento.Subscriptions
{
    /// <summary>
    /// Represents a subscription of a product or service in Magento.
    /// </summary>
    public interface ISubscription : IEqualityComparer<ISubscription>,  IParadoxLabsMagentoRestEntity, IMagentoAuditableEntity
    {
        /// <summary>
        /// Gets or sets the parent <see cref="ISalesOrder"/> of the subscription.
        /// </summary>
        ISalesOrder Order
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ISalesOrderItem"/> that is being subscribed to.
        /// </summary>
        ISalesOrderItem Item
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICustomer"/> that is subscribing to <see cref="Item"/>. 
        /// </summary>
        ICustomer Subscriber
        { get; set; }
        
        /// <summary>
        /// Gets or sets the parent store that houses the subscription.
        /// </summary>
        IStore Store
        { get; set; }
        
        /// <summary>
        /// Gets or sets the date and time of the next subscription charge interval.
        /// </summary>
        Instant? NextRun
        { get; set; }
        
        /// <summary>
        /// Gets or sets the date and time of the last subscription charge interval.
        /// </summary>
        Instant? LastRun
        { get; set; }
        
        /// <summary>
        /// Gets or sets the subscription item subtotal.
        /// </summary>
        decimal Subtotal
        { get; set; }
        
        /// <summary>
        /// Specifies whether the subscription has completed its required number of runs and is now expired.
        /// </summary>
        bool IsComplete
        { get; set; }
        
        /// <summary>
        /// Gets or sets the total number of times the subscription has ran.
        /// </summary>
        int RunCount
        { get; set; }

        /// <summary>
        /// Gets or sets the subscription status.
        /// </summary>
        string Status
        { get; set; }
        
        /// <summary>
        /// Gets or sets the frequency of the subscription charges during the specified <see cref="FrequencyInterval"/>.
        /// </summary>
        int Frequency
        { get; set; }

        /// <summary>
        /// Gets or sets the frequency interval.
        /// </summary>
        string FrequencyInterval
        { get; set; }
    }
}
