using System;
using Athi.Whippet.Data;

namespace Athi.Whippet.ServiceManagers
{
    /// <summary>
    /// Provides functionality for seeding certain <see cref="WhippetEntity"/> objects.
    /// </summary>
    public interface ISeedServiceManager : IServiceManager
    {
        /// <summary>
        /// Seeds the backing data store for one or more entities.
        /// </summary>
        /// <param name="reportProgress"><see cref="ProgressDelegate"/> that reports the current status to an external caller.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        WhippetResult Seed(ProgressDelegate reportProgress = null);
    }
}
