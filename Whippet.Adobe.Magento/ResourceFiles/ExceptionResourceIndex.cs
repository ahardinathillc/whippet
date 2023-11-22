using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Adobe.Magento.ResourceFiles
{
    /// <summary>
    /// Provides an index of all shared exceptions available in Whippet. This class cannot be inherited.
    /// </summary>
    public static class ExceptionResourceIndex
    {
        public const string MagentoBulkOperationFailedException = nameof(MagentoBulkOperationFailedException);
        public const string MagentoOperationApplicationException = nameof(MagentoOperationApplicationException);
    }
}
