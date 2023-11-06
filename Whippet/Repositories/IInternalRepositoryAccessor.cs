using System;
namespace Athi.Whippet.Repositories
{
    /// <summary>
    /// Provides access to an internal repository that the current instance is wrapping.
    /// </summary>
    public interface IInternalRepositoryAccessor
    {
        /// <summary>
        /// Retrieves the internal repository that the current instance is wrapping.
        /// </summary>
        /// <returns><see langword="dynamic"/> object that represents the repository being wrapped.</returns>
        dynamic GetInternalRepository();
    }
}

