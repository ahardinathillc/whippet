using System;
using System.Text;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;

namespace Athi.Whippet.Adobe.Magento.Customer
{
    /// <summary>
    /// Represents an individual customer in Magento.
    /// </summary>
    public class Customer : MagentoRestEntity<CustomerInterface>, IMagentoEntity, ICustomer, IEqualityComparer<ICustomer>, IWhippetActiveEntity
    {
        
    }
}
