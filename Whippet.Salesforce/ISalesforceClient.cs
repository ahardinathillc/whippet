using System;
using Salesforce.Force;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Represents a client that executes and receives RESTful calls to Salesforce.
    /// </summary>
    public interface ISalesforceClient : IForceClient, IDisposable
    { }
}

