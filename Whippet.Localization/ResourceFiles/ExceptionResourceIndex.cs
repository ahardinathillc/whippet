using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Localization.ResourceFiles
{
    /// <summary>
    /// Provides an index of all shared exceptions available in Whippet. This class cannot be inherited.
    /// </summary>
    public static class ExceptionResourceIndex
    {
        public const string EmptyGuidException = nameof(EmptyGuidException);
        public const string EventNotSupportedException = nameof(EventNotSupportedException);
        public const string NumericValueRequiredException = nameof(NumericValueRequiredException);
        public const string ArgumentExceedsMaximumLengthWithValueException = nameof(ArgumentExceedsMaximumLengthWithValueException);
        public const string ArgumentExceedsMaximumLengthException = nameof(ArgumentExceedsMaximumLengthException);
        public const string InvalidTypeException = nameof(InvalidTypeException);
    }
}
