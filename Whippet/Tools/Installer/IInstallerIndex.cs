using System;
using System.Collections.Generic;
using Athi.Whippet.Data;

namespace Athi.Whippet.Tools.Installer
{
    /// <summary>
    /// Provides support to objects who are consumed by Whippet installers for creating and populating entities in the data store.
    /// </summary>
    public interface IInstallerIndex
    {
        /// <summary>
        /// Retrieves all <see cref="IWhippetEntitySeed"/> objects in the order they are to be processed by the installer. This method must be overridden.
        /// </summary>
        /// <returns><see cref="SortedList{TKey, TValue}"/> of all <see cref="IWhippetEntitySeed"/> objects to install.</returns>
        SortedList<int, IWhippetEntitySeed> GetObjects();
    }
}

