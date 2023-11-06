using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Athi.Whippet.Collections;

namespace Athi.Whippet.Applications.Setup
{
    /// <summary>
    /// Represents a collection of <see cref="IWhippetSettingGroup"/> objects that belong to a specific <see cref="IWhippetApplication"/>. This class must be inherited.
    /// </summary>
    /// <typeparam name="TSettingGroup"><see cref="IWhippetSettingGroup"/> object stored in the collection.</typeparam>
    [Serializable]
    [DebuggerDisplay("Count = {Count}")]
    public abstract class WhippetSettingGroupCollection<TSettingGroup> : ReadOnlyCollection<TSettingGroup>, IList<TSettingGroup>, ICollection<TSettingGroup>, IEnumerable<TSettingGroup>, IEnumerable, IList, ICollection, IReadOnlyList<TSettingGroup>, IReadOnlyCollection<TSettingGroup>
        where TSettingGroup : IWhippetSettingGroup
    {
        private readonly IWhippetApplication _Application;

        /// <summary>
        /// Gets the <typeparamref name="TSettingGroup"/> object with the specified <see cref="IWhippetSettingGroup.SettingGroupID"/>.
        /// </summary>
        /// <param name="groupId"><see cref="IWhippetSettingGroup.SettingGroupID"/> value to search for.</param>
        /// <returns><typeparamref name="TSettingGroup"/> object or <see langword="null"/> if the item could not be found.</returns>
        public TSettingGroup this[Guid groupId]
        {
            get
            {
                return this.Where(sg => sg.SettingGroupID.Equals(groupId)).FirstOrDefault();
            }
        }

        /// <summary>
        /// Gets the <see cref="IWhippetApplication"/> that the setting group(s) apply to. This property is read-only.
        /// </summary>
        public IWhippetApplication Application
        {
            get
            {
                return _Application;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSettingGroupCollection{TSettingGroup}"/> class with the specified <see cref="IWhippetApplication"/> and collection.
        /// </summary>
        /// <param name="application"><see cref="IWhippetApplication"/> that the setting groups apply to.</param>
        /// <param name="settingGroups"><see cref="IList{T}"/> of the <typeparamref name="TSettingGroup"/> objects to initialize with.</param>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="CollectionRestrictionViolationException" />
        protected WhippetSettingGroupCollection(IWhippetApplication application, IList<TSettingGroup> settingGroups)
            : base(settingGroups)
        {
            if (application == null)
            {
                throw new ArgumentNullException(nameof(application));
            }
            else
            {
                _Application = application;

                if (settingGroups != null && settingGroups.Any())
                {
                    if (settingGroups.Where(sg => !sg.Application.ApplicationID.Equals(application.ApplicationID)).Any())
                    {
                        throw new CollectionRestrictionViolationException();
                    }
                    else
                    {
                        foreach (TSettingGroup sg in settingGroups)
                        {
                            if (settingGroups.Where(sg => sg.SettingGroupID.Equals(sg)).Count() > 1)
                            {
                                throw new ArgumentException();
                            }
                        }
                    }
                }
            }
        }
    }
}

