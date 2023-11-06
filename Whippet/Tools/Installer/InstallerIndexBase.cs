using System;
using System.Collections.Generic;
using NHibernate;
using Athi.Whippet.Data;

namespace Athi.Whippet.Tools.Installer
{
    /// <summary>
    /// Base class for all entity and seed data installer classes. This class must be inherited.
    /// </summary>
    public abstract class InstallerIndexBase : IInstallerIndex
    {
        /// <summary>
        /// Gets the <see cref="ISession"/> object that defines the context for the data store. This property is read-only.
        /// </summary>
        protected ISession Session
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="Athi.Whippet.ProgressDelegate"/> used to measure the progress of the current operation.
        /// </summary>
        protected ProgressDelegate ProgressDelegate
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstallerIndexBase"/> class with the specified <see cref="ISession"/> and progress delegate.
        /// </summary>
        /// <param name="session"><see cref="ISession"/> object that defines the data store context.</param>
        /// <param name="progressDelegate"><see cref="Athi.Whippet.ProgressDelegate"/> used to measure the progress of the current operation.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected InstallerIndexBase(ISession session, ProgressDelegate progressDelegate = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            else
            {
                Session = session;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="IWhippetEntitySeed"/> objects in the order they are to be processed by the installer. This method must be overridden.
        /// </summary>
        /// <returns><see cref="SortedList{TKey, TValue}"/> of all <see cref="IWhippetEntitySeed"/> objects to install.</returns>
        public abstract SortedList<int, IWhippetEntitySeed> GetObjects();
    }
}

