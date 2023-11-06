using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Security.ResourceFiles
{
    /// <summary>
    /// Provides an index of all exceptions available in the <see cref="Athi.Whippet.Security"/> assembly. This class cannot be inherited.
    /// </summary>
    internal static class ExceptionResourceIndex
    {
        public const string RootTenantCannotBeInactiveException = nameof(RootTenantCannotBeDeletedException);
        public const string RootTenantCannotBeDeletedException = nameof(RootTenantCannotBeDeletedException);
        public const string UserAlreadyExistsException = nameof(UserAlreadyExistsException);
        public const string UserNotFoundException = nameof(UserNotFoundException);
        public const string RootTenantAlreadySetException = nameof(RootTenantAlreadySetException);
    }
}
