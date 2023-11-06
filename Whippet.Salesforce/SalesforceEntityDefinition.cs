using System;
using NodaTime;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Represents a Salesforce entity definition which decribes the properties and relationships for an <see cref="ISalesforceObject"/>. This class cannot be inherited.
    /// </summary>
    public sealed class SalesforceEntityDefinition
    {
        /// <summary>
        /// Gets the unique entity definition ID. This property is read-only.
        /// </summary>
        public string EntityDefinitionID
        { get; private set; }

        /// <summary>
        /// Gets the qualified API name of the property. This property is read-only.
        /// </summary>
        public string QualifiedApiName
        { get; private set; }

        /// <summary>
        /// Gets the entity's label. This property is read-only.
        /// </summary>
        public string Label
        { get; private set; }

        /// <summary>
        /// Durable ID of the entity. This property is read-only.
        /// </summary>
        public string DurableID
        { get; private set; }

        /// <summary>
        /// Indicates whether the field history is tracked. This property is read-only.
        /// </summary>
        public bool IsFieldHistoryTracked
        { get; private set; }

        /// <summary>
        /// Indicates whether the object is indexed. This property is read-only.
        /// </summary>
        public bool IsIndexed
        { get; private set; }

        /// <summary>
        /// Gets the date/time the entity was last modified. This property is read-only.
        /// </summary>
        public Instant? LastModifiedDate
        { get; private set; }

        /// <summary>
        /// Gets the relationship name assigned to the object. This property is read-only.
        /// </summary>
        public string RelationshipName
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceEntityDefinition"/> class with no arguments.
        /// </summary>
        private SalesforceEntityDefinition()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceEntityDefinition"/> class.
        /// </summary>
        /// <param name="entityDefinitionId">Unique entity definition ID.</param>
        /// <param name="qualifiedApiName">Qualified API name of the property.</param>
        /// <param name="label">Label of the property.</param>
        /// <param name="durableId">Durable ID of the entity.</param>
        /// <param name="isFieldHistoryTracked">Indicates whether the field history is tracked.</param>
        /// <param name="isIndexed">Indicates whether the entity is indexed.</param>
        /// <param name="lastModifiedDate">Last date/time the entity was modified.</param>
        /// <param name="relationshipName">Relationship name assigned to the object.</param>
        public SalesforceEntityDefinition(string entityDefinitionId, string qualifiedApiName, string label, string durableId, bool isFieldHistoryTracked, bool isIndexed, Instant? lastModifiedDate, string relationshipName)
            : this()
        {
            EntityDefinitionID = entityDefinitionId;
            QualifiedApiName = qualifiedApiName;
            Label = label;
            DurableID = durableId;
            IsFieldHistoryTracked = isFieldHistoryTracked;
            IsIndexed = isIndexed;
            LastModifiedDate = lastModifiedDate;
            RelationshipName = relationshipName;
        }
    }
}

