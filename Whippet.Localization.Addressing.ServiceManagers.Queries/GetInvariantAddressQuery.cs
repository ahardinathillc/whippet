using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="InvariantAddress"/> objects in the system filtered by <see cref="ICity"/>. This class cannot be inherited.
    /// </summary>
    public sealed class GetInvariantAddressQuery : WhippetQuery<InvariantAddress>, IWhippetQuery<InvariantAddress>
    {
        /// <summary>
        /// Gets the <see cref="IInvariantAddress"/> to search for. This property is read-only.
        /// </summary>
        public IInvariantAddress Address
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetInvariantAddressQuery"/> class with no arguments.
        /// </summary>
        private GetInvariantAddressQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetInvariantAddressQuery"/> class with the specified <see cref="IInvariantAddress"/>.
        /// </summary>
        /// <param name="address"><see cref="IInvariantAddress"/> to filter by.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public GetInvariantAddressQuery(IInvariantAddress address)
            : this()
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }
            else
            {
                Address = address;
            }
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add(nameof(Address), Address);

            return parameters;
        }
    }
}
