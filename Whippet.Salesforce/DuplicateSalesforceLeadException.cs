using System;
using System.Runtime.Serialization;
using Athi.Whippet;
using Athi.Whippet.Localization;
using Athi.Whippet.Salesforce.ResourceFiles;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Exception that is thrown when a duplicate <see cref="SalesforceLead"/> is attempted to be saved to the Salesforce instance. This class cannot be inherited.
    /// </summary>
    public sealed class DuplicateSalesforceLeadException : WhippetException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateSalesforceLeadException"/> class with no arguments.
        /// </summary>
        private DuplicateSalesforceLeadException()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateSalesforceLeadException"/> class with the specified lead name and inner exception.
        /// </summary>
        /// <param name="leadName">Lead name that caused the duplicate exception.</param>
        /// <param name="innerException"><see cref="Exception"/> that was encountered prior to the current exception being thrown.</param>
        public DuplicateSalesforceLeadException(string leadName, Exception innerException)
            : base(LocalizedStringResourceLoader.GetException<DuplicateSalesforceLeadException>(ExceptionResourceIndex.DuplicateSalesforceLeadException, new[] { leadName }), innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateSalesforceLeadException"/> class with serialized data.
        /// </summary>
        /// <param name="serializationInfo">The <see cref="SerializationInfo"/> object that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="SerializationException" />
        internal DuplicateSalesforceLeadException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        { }
    }
}

