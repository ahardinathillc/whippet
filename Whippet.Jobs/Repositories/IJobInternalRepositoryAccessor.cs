using System;
using Athi.Whippet.Repositories;

namespace Athi.Whippet.Jobs.Repositories
{
    /// <summary>
    /// Provides access to the internal repository that the current instance wraps.
    /// </summary>
    public interface IJobInternalRepositoryAccessor : IInternalRepositoryAccessor
    { }
}

