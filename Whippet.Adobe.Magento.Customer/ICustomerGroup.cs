using System;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Taxes;
using Athi.Whippet.Adobe.Magento.Store;

namespace Athi.Whippet.Adobe.Magento.Customer
{
    /// <summary>
    /// Represents a logical grouping for <see cref="ICustomer"/> entities.
    /// </summary>
    public interface ICustomerGroup : IMagentoEntity, IEqualityComparer<ICustomerGroup>, IMagentoRestEntity
    {
        /// <summary>
        /// Gets or sets the customer group code.
        /// </summary>
        string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the tax class of the <see cref="ICustomerGroup"/>.
        /// </summary>
        ITaxClass TaxClass
        { get; set; }
        
        /// <summary>
        /// Gets or sets the excluded <see cref="IStoreWebsite"/> objects for the <see cref="ICustomerGroup"/>.
        /// </summary>
        IEnumerable<IStoreWebsite> ExcludedWebsites
        { get; set; }
    }
}
