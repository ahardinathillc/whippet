using System;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Indicates a record's clean status as compared with Data.com.
    /// </summary>
    public enum SalesforceCleanStatus
    {
        In_Sync,
        Different,
        Reviewed,
        Not_Found,
        Inactive,
        Not_Compared,
        Select_Match,
        Skipped
    }
}

