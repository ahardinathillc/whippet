using System;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.CRM.Extensions;

namespace Athi.Whippet.SuperDuper.Legacy.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ILegacySuperDuperAccount"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ILegacySuperDuperAccountExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ILegacySuperDuperAccount"/> object to a <see cref="LegacySuperDuperAccount"/> object.
        /// </summary>
        /// <param name="account"><see cref="ILegacySuperDuperAccount"/> object to convert.</param>
        /// <returns><see cref="LegacySuperDuperAccount"/> object.</returns>
        public static LegacySuperDuperAccount ToLegacySuperDuperAccount(this ILegacySuperDuperAccount account)
        {
            LegacySuperDuperAccount act = null;

            if (account is LegacySuperDuperAccount)
            {
                act = (LegacySuperDuperAccount)(account);
            }
            else if (account != null)
            {
                act = new LegacySuperDuperAccount(account.ID);
                act.CustomerNumber = account.CustomerNumber;
                act.UUID = account.UUID;
                act.Email = account.Email;
                act.CreatedDTTM = account.CreatedDTTM;
                act.Registered = account.Registered;
                act.Password = account.Password;
                act.LastName = account.LastName;
                act.FirstName = account.FirstName;
                act.SuperDuperAccountOccupation = account.SuperDuperAccountOccupation.ToLegacySuperDuperAccountOccupation();
                act.PasswordResetID = account.PasswordResetID;
                act.TaxExempt = account.TaxExempt;
                act.MultichannelOrderManagerAccount = account.MultichannelOrderManagerAccount.ToCustomer();
                act.SessionID = account.SessionID;
            }

            return act;
        }
    }
}
