using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data.CQRS.ResourceFiles
{
    /// <summary>
    /// Provides an index of all exceptions available in the <see cref="Athi.Whippet.Data.CQRS"/> assembly. This class cannot be inherited.
    /// </summary>
    internal static class ExceptionResourceIndex
    {
        public const string AggregateNotFoundException = nameof(AggregateNotFoundException);
        public const string InvalidEventType = nameof(InvalidEventType);
    }
}
