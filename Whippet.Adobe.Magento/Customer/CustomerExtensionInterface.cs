using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Customer
{
    /// <summary>
    /// Interface that provides extra information about a Magento customer.
    /// </summary>
    public class CustomerExtensionInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the customer company attributes.
        /// </summary>
        [JsonProperty("company_attributes")]
        public CustomerCompanyInterface Company
        { get; set; }

        /// <summary>
        /// Flag that indicates whether customer assistance is allowed. Values greater than zero (0) are <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        [JsonProperty("assistance_allowed")]
        public int AssistanceAllowed
        { get; set; }

        /// <summary>
        /// Specifies whether the customer is a subscriber.
        /// </summary>
        [JsonProperty("is_subscribed")]
        public bool IsSubscribed
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerExtensionInterface"/> class with no arguments.
        /// </summary>
        public CustomerExtensionInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerExtensionInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="company">Customer company attributes.</param>
        /// <param name="assistanceAllowed">Flag that indicates whether customer assistance is allowed. Values greater than zero (0) are <see langword="true"/> otherwise, <see langword="false"/>.</param>
        /// <param name="isSubscribed"></param>
        public CustomerExtensionInterface(CustomerCompanyInterface company, int assistanceAllowed, bool isSubscribed)
            : this()
        {
            Company = company;
            AssistanceAllowed = assistanceAllowed;
            IsSubscribed = isSubscribed;
        }
    }
}
