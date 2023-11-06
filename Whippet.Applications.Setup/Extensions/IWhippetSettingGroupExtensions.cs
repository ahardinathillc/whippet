using System;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.Applications.Setup.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IWhippetSettingGroup"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IWhippetSettingGroupExtensions
    {
        public static WhippetSettingGroup ToWhippetSettingGroup(this IWhippetSettingGroup groupObj)
        {
            WhippetSettingGroup group = null;

            if (groupObj != null)
            {
                if (groupObj is WhippetSettingGroup)
                {
                    group = (WhippetSettingGroup)(groupObj);
                }
                else
                {
                    group = new WhippetSettingGroup(groupObj.ID, groupObj.Application.ToWhippetApplication(), groupObj.SettingGroupID, groupObj.Name, groupObj.Description);
                }
            }

            return group;
        }
    }
}
