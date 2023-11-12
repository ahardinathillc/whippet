using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Athi.Whippet.ResourceFiles;

namespace Athi.Whippet.Collections.Trees
{
    /// <summary>
    /// Exception that is thrown when a <see cref="TreeNode{TItem}"/> is attempted to be set an index greater than the last child item's index. This class cannot be inherited.
    /// </summary>
    public sealed class TreeNodeIndexHigherThanLastItemIndexException : WhippetException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TreeNodeIndexHigherThanLastItemIndexException"/> class with no arguments.
        /// </summary>
        public TreeNodeIndexHigherThanLastItemIndexException()
            : base(LocalizeString(ExceptionResourceIndex.TreeIndexCannotExceedChildrenCountException, culture: CurrentCulture))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeNodeIndexHigherThanLastItemIndexException"/> class with the specified error message.
        /// </summary>
        /// <param name="message">Message to display.</param>
        public TreeNodeIndexHigherThanLastItemIndexException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeNodeIndexHigherThanLastItemIndexException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception or <see langword="null"/> if no inner exception is specified.</param>
        public TreeNodeIndexHigherThanLastItemIndexException(string message, Exception innerException)
            : base(String.IsNullOrWhiteSpace(message) ? LocalizeString(ExceptionResourceIndex.TreeIndexCannotExceedChildrenCountException, culture: CurrentCulture) : message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeNodeIndexHigherThanLastItemIndexException"/> class with serialized data.
        /// </summary>
        /// <param name="serializationInfo">The <see cref="SerializationInfo"/> object that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="SerializationException" />
        public TreeNodeIndexHigherThanLastItemIndexException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        { }
    }
}