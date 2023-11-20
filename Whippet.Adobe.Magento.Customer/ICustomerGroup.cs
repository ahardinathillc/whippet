using System;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Taxes;

namespace Athi.Whippet.Adobe.Magento.Customer
{
    /// <summary>
    /// Represents a logical grouping for <see cref="ICustomer"/> entities.
    /// </summary>
    public interface ICustomerGroup : IMagentoEntity, IEqualityComparer<ICustomerGroup>
    {
        /// <summary>
        /// Gets or sets the customer group code.
        /// </summary>
        string GroupCode
        { get; set; }

        /// <summary>
        /// Gets or sets the tax class of the <see cref="ICustomerGroup"/>.
        /// </summary>
        ITaxClass TaxClass
        { get; set; }
    }
}
