﻿using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.Vault;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Interface that provides extra information about a Magento sales order payment.
    /// </summary>
    public class SalesOrderPaymentExtensionInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the notification message.
        /// </summary>
        [JsonProperty("notification_message")]
        public string NotificationMessage
        { get; set; }

        /// <summary>
        /// Gets or sets the gateway vault payment token.
        /// </summary>
        [JsonProperty("vault_payment_token")]
        public VaultPaymentTokenInterface VaultPaymentToken
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderPaymentExtensionInterface"/> class with no arguments.
        /// </summary>
        public SalesOrderPaymentExtensionInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderPaymentExtensionInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="notificationMessage">Notification message.</param>
        /// <param name="token">Vault payment token.</param>
        public SalesOrderPaymentExtensionInterface(string notificationMessage, VaultPaymentTokenInterface token)
            : this()
        {
            NotificationMessage = notificationMessage;
            VaultPaymentToken = token;
        }
    }
}
