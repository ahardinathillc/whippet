using System;
using System.Collections;
using NHibernate;
using Athi.Whippet.Data;
using Athi.Whippet.Tools.Installer;

namespace Athi.Whippet.Localization.Addressing.Installer
{
    /// <summary>
    /// Retrieves a sorted list of all addressing installation objects to be loaded into the Whippet database. This class cannot be inherited.
    /// </summary>
    public sealed class AddressingInstallerIndex : InstallerIndexBase
    {
        /// <summary>
        /// Indicates whether the seed function can be skipped.
        /// </summary>
        private bool SkipSeed
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressingInstallerIndex"/> class with the specified <see cref="ISession"/> and progress delegate.
        /// </summary>
        /// <param name="session"><see cref="ISession"/> object that defines the data store context.</param>
        /// <param name="progressDelegate"><see cref="Athi.Whippet.ProgressDelegate"/> used to measure the progress of the current operation.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public AddressingInstallerIndex(ISession session, ProgressDelegate progressDelegate = null)
            : this(session, false, progressDelegate)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressingInstallerIndex"/> class with the specified <see cref="ISession"/> and progress delegate.
        /// </summary>
        /// <param name="session"><see cref="ISession"/> object that defines the data store context.</param>
        /// <param name="progressDelegate"><see cref="Athi.Whippet.ProgressDelegate"/> used to measure the progress of the current operation.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public AddressingInstallerIndex(ISession session, bool skipSeed, ProgressDelegate progressDelegate = null)
            : base(session, progressDelegate)
        {
            SkipSeed = skipSeed;
        }

        /// <summary>
        /// Retrieves all <see cref="IWhippetEntitySeed"/> objects in the order they are to be processed by the installer.
        /// </summary>
        /// <returns><see cref="SortedList{TKey, TValue}"/> of all <see cref="IWhippetEntitySeed"/> objects to install.</returns>
        public override SortedList<int, IWhippetEntitySeed> GetObjects()
        {
            int order = 0;
            SortedList<int, IWhippetEntitySeed> seedObjects = new SortedList<int, IWhippetEntitySeed>();

            if (!SkipSeed)
            {
                seedObjects.Add(++order, new CountrySeed(Session, ProgressDelegate));
                seedObjects.Add(++order, new StateProvinceSeed(Session, ProgressDelegate));
                seedObjects.Add(++order, new CitySeed(Session, ProgressDelegate));
                seedObjects.Add(++order, new PostalCodeSeed(Session, ProgressDelegate));
            }

            return seedObjects;
        }
    }
}

