using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Represents a query that is executed against a query handler to return one or more entity objects that match a predefined criterion. This class must be inherited.
    /// </summary>
    public abstract class WhippetQuery
    {
        private IReadOnlyDictionary<string, object> _noParams;

        /// <summary>
        /// Represents an empty parameter set for <see cref="GetQueryParametersAndValues"/>. This property is read-only.
        /// </summary>
        protected IReadOnlyDictionary<string, object> NoParameters
        {
            get
            {
                if (_noParams == null)
                {
                    _noParams = new Dictionary<string, object>();
                }

                return _noParams;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetQuery"/> class with no arguments.
        /// </summary>
        protected WhippetQuery()
        { }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected abstract IReadOnlyDictionary<string, object> GetQueryParametersAndValues();

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            IReadOnlyDictionary<string, object> values = GetQueryParametersAndValues();

            builder.Append("{");

            if (values != null && values.Any())
            {
                foreach (KeyValuePair<string, object> kvp in values)
                {
                    builder.Append("{ ");
                    builder.Append(kvp.Key + " = " + kvp.Value == null ? "null" : kvp.Value.ToString());
                    builder.Append(" }");
                }
            }

            builder.Append("}");

            return builder.ToString();
        }
    }

    /// <summary>
    /// Represents a query that is executed against a query handler to return one or more entity objects that match a predefined criterion. This class must be inherited.
    /// </summary>
    public abstract class WhippetQuery<TEntity> : WhippetQuery where TEntity : IWhippetEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetQuery{TEntity}"/> class with no arguments.
        /// </summary>
        protected WhippetQuery()
            : base()
        { }
    }
}
