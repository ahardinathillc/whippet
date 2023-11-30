using System;
using System.Linq;
using Newtonsoft.Json;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    public class Product : MagentoRestEntity<ProductInterface>, IMagentoEntity, IProduct, IEqualityComparer<IProduct>, IMagentoAuditableEntity, IMagentoCustomAttributesEntity
    {
        
    }
}
