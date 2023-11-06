using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="InvariantAddress"/> objects in the system filtered by <see cref="IPostalCode"/>. This class cannot be inherited.
    /// </summary>
    public sealed class GetInvariantAddressesForPostalCodeQuery : WhippetQuery<InvariantAddress>, IWhippetQuery<InvariantAddress>
    {
        /// <summary>
        /// Gets the <see cref="IPostalCode"/> to filter by. This property is read-only.
        /// </summary>
        public IPostalCode PostalCode
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetInvariantAddressesForPostalCodeQuery"/> class with no arguments.
        /// </summary>
        private GetInvariantAddressesForPostalCodeQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetInvariantAddressesForPostalCodeQuery"/> class with the specified <see cref="IPostalCode"/>.
        /// </summary>
        /// <param name="postalCode"><see cref="IPostalCode"/> to filter by.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public GetInvariantAddressesForPostalCodeQuery(IPostalCode postalCode)
            : this()
        {
            if (postalCode == null)
            {
                throw new ArgumentNullException(nameof(postalCode));
            }
            else
            {
                PostalCode = postalCode;
            }
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add(nameof(PostalCode), PostalCode);

            return parameters;
        }
    }
}
