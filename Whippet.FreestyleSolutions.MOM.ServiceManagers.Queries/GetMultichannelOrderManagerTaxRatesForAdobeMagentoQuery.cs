//using System;
//using Athi.Whippet.Data.CQRS;

//namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries
//{
//    public sealed class GetMultichannelOrderManagerTaxRatesForAdobeMagentoQuery : WhippetQuery<MultichannelOrderManagerSupplier>, IWhippetQuery<MultichannelOrderManagerSupplier>
//    {
//        public GetMultichannelOrderManagerTaxRatesForAdobeMagentoQuery()
//        {
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NodaTime;
//using Athi.Whippet.Data.CQRS;
//using Athi.Whippet.Security.Tenants;

//namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries
//{
//    /// <summary>
//    /// Represents a query that retrieves all <see cref="MultichannelOrderManagerSupplier"/> objects in the data store. This class cannot be inherited.
//    /// </summary>
//    public sealed class GetMultichannelOrderManagerSuppliersQuery 
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerSuppliersQuery"/> class with no arguments.
//        /// </summary>
//        public GetMultichannelOrderManagerSuppliersQuery()
//            : base()
//        { }

//        /// <summary>
//        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
//        /// </summary>
//        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
//        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
//        {
//            return NoParameters;
//        }
//    }
//}
