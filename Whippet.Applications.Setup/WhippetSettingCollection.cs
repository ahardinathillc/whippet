using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Athi.Whippet.Collections;

namespace Athi.Whippet.Applications.Setup
{
    /// <summary>
    /// Represents a collection of <see cref="IWhippetSetting"/> objects that belong to a specific <see cref="IWhippetSettingGroup"/>. This class must be inherited.
    /// </summary>
    /// <typeparam name="TSetting"><see cref="IWhippetSetting"/> object stored in the collection.</typeparam>
    [Serializable]
    [DebuggerDisplay("Count = {Count}")]
    public abstract class WhippetSettingCollection<TSetting> : ReadOnlyCollection<TSetting>
        where TSetting : IWhippetSetting
    {
        private readonly IWhippetSettingGroup _SettingGroup;

        /// <summary>
        /// Gets the <typeparamref name="TSetting"/> object with the specified <see cref="IWhippetSetting.SettingID"/>.
        /// </summary>
        /// <param name="groupId"><see cref="IWhippetSetting.SettingID"/> value to search for.</param>
        /// <returns><typeparamref name="TSetting"/> object or <see langword="null"/> if the item could not be found.</returns>
        public TSetting this[Guid groupId]
        {
            get
            {
                return this.Where(sg => sg.SettingID.Equals(groupId)).FirstOrDefault();
            }
        }

        /// <summary>
        /// Gets the <see cref="IWhippetSettingGroup"/> that the setting group(s) apply to. This property is read-only.
        /// </summary>
        public IWhippetSettingGroup SettingGroup
        {
            get
            {
                return _SettingGroup;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSettingCollection{TSetting}"/> class with the specified <see cref="IWhippetSettingGroup"/> and collection.
        /// </summary>
        /// <param name="settingGroup"><see cref="IWhippetSettingGroup"/> that the setting groups apply to.</param>
        /// <param name="settings"><see cref="IList{T}"/> of the <typeparamref name="TSetting"/> objects to initialize with.</param>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="CollectionRestrictionViolationException" />
        protected WhippetSettingCollection(IWhippetSettingGroup settingGroup, IList<TSetting> settings)
            : base(settings)
        {
            if (settingGroup == null)
            {
                throw new ArgumentNullException(nameof(settingGroup));
            }
            else
            {
                _SettingGroup = settingGroup;

                if (settings != null && settings.Any())
                {
                    if (settings.Where(sg => !sg.Group.SettingGroupID.Equals(settingGroup.SettingGroupID)).Any())
                    {
                        throw new CollectionRestrictionViolationException();
                    }
                    else
                    {
                        foreach (TSetting sg in settings)
                        {
                            if (settings.Where(sg => sg.SettingID.Equals(sg)).Count() > 1)
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

