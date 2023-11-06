using System;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Provides support to Salesforce references that are composite references (i.e., referencing two or more fields to make a composite key).
    /// </summary>
    public interface ISalesforceCompositeReference
    {
        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> that is indexed by the Salesforce object column name and associated <see cref="SalesforceReference"/> value. This property is read-only.
        /// </summary>
        IReadOnlyDictionary<string, SalesforceReference> CompositeValue
        { get; }
    }
}

