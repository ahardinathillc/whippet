using System;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.Sales.Extensions;
using Athi.Whippet.Adobe.Magento.Store.Extensions;

namespace Athi.Whippet.ParadoxLabs.Magento.Subscriptions.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ISubscription"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ISubscriptionExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ISubscription"/> object to a <see cref="Subscription"/> object.
        /// </summary>
        /// <param name="sub"><see cref="ISubscription"/> object to convert.</param>
        /// <returns><see cref="Subscription"/> object.</returns>
        public static Subscription ToSubscription(this ISubscription sub)
        {
            Subscription subscription = null;

            if (sub is Subscription)
            {
                subscription = (Subscription)(sub);
            }
            else if (sub != null)
            {
                subscription = new Subscription(Convert.ToUInt32(sub.ID));
                subscription.Length = sub.Length;
                subscription.Frequency = sub.Frequency;
                subscription.CreatedTimestamp = sub.CreatedTimestamp;
                subscription.FrequencyInterval = sub.FrequencyInterval;
                subscription.Length = sub.Length;
                subscription.RunCount = sub.RunCount;
                subscription.Item = sub.Item.ToSalesOrderItem();
                subscription.Order = sub.Order.ToSalesOrder();
                subscription.Status = sub.Status;
                subscription.Store = sub.Store.ToStore();
                subscription.Subscriber = sub.Subscriber.ToCustomer();
                subscription.Subtotal = sub.Subtotal;
                subscription.LastRun = sub.LastRun;
                subscription.NextRun = sub.NextRun;
                subscription.UpdatedTimestamp = sub.UpdatedTimestamp;
                subscription.Server = sub.Server.ToMagentoServer();
                subscription.RestEndpoint = sub.RestEndpoint.ToMagentoRestEndpoint();
            }

            return subscription;
        }
    }
}
