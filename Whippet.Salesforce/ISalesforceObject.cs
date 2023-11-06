using System;
using NodaTime;
using Newtonsoft.Json.Linq;
using Athi.Whippet.Data;
using Athi.Whippet.Json;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Represents an object Salesforce.
    /// </summary>
    public interface ISalesforceObject : IWhippetEntityDynamicImportMapper, IWhippetEntityExternalDataRowImportMapper, IWhippetEntity, IJsonSerializableObject
    {
        /// <summary>
        /// Unique ID of the Salesforce object.
        /// </summary>
        SalesforceReference? ObjectID
        { get; set; }

        /// <summary>
        /// ID of the object who owns the current instance.
        /// </summary>
        SalesforceReference? OwnerID
        { get; set; }

        /// <summary>
        /// ID of the parent object (if any).
        /// </summary>
        SalesforceReference? ParentID
        { get; set; }

        /// <summary>
        /// ID of the record type assigned to the current instance.
        /// </summary>
        SalesforceReference? RecordTypeID
        { get; set; }

        /// <summary>
        /// Value is one of the following, whichever is the most recent: due date of the most recent event logged against the record, or, due date of the most recently closed task associated with the record.
        /// </summary>
        Instant? LastActivityDate
        { get; set; }

        /// <summary>
        /// The timestamp for when the current user last viewed a record related to this record.
        /// </summary>
        Instant? LastReferencedDate
        { get; set; }

        /// <summary>
        /// The timestamp for when the current user last viewed this record. If this value is null, this record might only have been referenced (<see cref="LastReferencedDate"/>) and not viewed.
        /// </summary>
        Instant? LastViewedDate
        { get; set; }

        /// <summary>
        /// Imports a JSON result returned from Salesforce.
        /// </summary>
        /// <param name="jsonObj"><see cref="JObject"/> that was returned from Salesforce.</param>
        /// <param name="availableFields">Available fields returned from the Salesforce instance.</param>
        /// <exception cref="ArgumentNullException" />
        void ImportJsonObject(dynamic jsonObj, IEnumerable<string> availableFields);
    }
}

