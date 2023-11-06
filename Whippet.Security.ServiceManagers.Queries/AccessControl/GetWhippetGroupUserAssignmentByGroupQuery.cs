using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Data;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Queries
{
    /// <summary>
    /// Query that retrieves a <see cref="WhippetGroupUserAssignment"/> by the associated <see cref="WhippetGroup"/> ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetWhippetGroupUserAssignmentByGroupQuery : WhippetQuery<WhippetGroupUserAssignment>, IWhippetQuery<WhippetGroupUserAssignment>
    {
        /// <summary>
        /// Gets or sets the <see cref="IWhippetGroup"/> to filter by.
        /// </summary>
        public IWhippetGroup Group
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetGroupUserAssignmentByGroupQuery"/> class with no arguments.
        /// </summary>
        public GetWhippetGroupUserAssignmentByGroupQuery()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetGroupByIdQuery"/> class with the specified group.
        /// </summary>
        /// <param name="group"><see cref="IWhippetGroup"/> to filter by.</param>
        public GetWhippetGroupUserAssignmentByGroupQuery(IWhippetGroup group)
            : base()
        {
            Group = group;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add(nameof(Group), Group);

            return parameters;
        }
    }
}

