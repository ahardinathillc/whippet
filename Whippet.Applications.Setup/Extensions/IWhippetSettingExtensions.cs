using System;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.Applications.Setup.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IWhippetSetting"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IWhippetSettingExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IWhippetSetting"/> object to a <see cref="WhippetSetting"/> object.
        /// </summary>
        /// <param name="settingObj"><see cref="IWhippetSetting"/> object to convert.</param>
        /// <returns><see cref="WhippetSetting"/> object.</returns>
        public static WhippetSetting ToWhippetSetting(this IWhippetSetting settingObj)
        {
            WhippetSetting setting = null;

            if (settingObj != null)
            {
                if (settingObj is WhippetSetting)
                {
                    setting = (WhippetSetting)(settingObj);
                }
                else
                {
                    setting = new WhippetSetting(
                        settingObj.ID,
                        settingObj.Group.ToWhippetSettingGroup(),
                        settingObj.SettingID,
                        settingObj.Name,
                        settingObj.Description,
                        settingObj.ByteValue,
                        settingObj.InstantValue,
                        settingObj.IntegerValue,
                        settingObj.DecimalValue,
                        settingObj.DoubleValue,
                        settingObj.BoolValue,
                        settingObj.StringValue,
                        settingObj.GuidValue
                    );
                }
            }

            return setting;
        }
    }
}
