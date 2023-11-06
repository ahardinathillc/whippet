using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using Athi.Whippet.Data;

namespace Athi.Whippet.Security.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IWhippetUser"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IWhippetUserExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IWhippetUser"/> object to a <see cref="WhippetUser"/> object.
        /// </summary>
        /// <param name="wUser"><see cref="IWhippetUser"/> object to convert.</param>
        /// <param name="id"><see cref="Guid"/> to assign to the <see cref="WhippetEntity.ID"/> property.</param>
        /// <returns><see cref="WhippetUser"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static WhippetUser ToWhippetUser(this IWhippetUser wUser, Guid? id = null)
        {
            if(wUser == null)
            {
                throw new ArgumentNullException(nameof(wUser));
            }
            else
            {
                WhippetUser user = null;

                if (wUser is WhippetUser)
                {
                    user = (WhippetUser)(wUser);
                }
                else
                {
                    user = new WhippetUser(
                        id.GetValueOrDefault(Guid.NewGuid()),
                        wUser.UserName,
                        wUser.Password,
                        wUser.CreatedDateTime,
                        wUser.CreatedBy,
                        wUser.LastModifiedDateTime,
                        wUser.LastModifiedBy,
                        wUser.TimeZoneIdentifier,
                        wUser.Active,
                        wUser.Deleted,
                        wUser.Email,
                        wUser.IPAddress);
                }

                return user;
            }
        }

        /// <summary>
        /// Creates the non-interactive system login instance.
        /// </summary>
        /// <param name="wUser"><see cref="IWhippetUser"/> object.</param>
        /// <returns><see cref="IWhippetUser"/> object.</returns>
        public static IWhippetUser CreateNonInteractiveSystemUser(this IWhippetUser wUser)
        {
            Guid id = new Guid("00000000-0000-0000-0000-000000000001");

            WhippetUser system = new WhippetUser();
            system.ID = id;
            system.UserName = "system";
            system.TimeZoneIdentifier = "America/New_York";
            system.Active = true;
            system.Deleted = false;
            system.Email = "no-reply@domain.local";
            system.IPAddress = "127.0.0.1";
            system.Password = "SYSTEM";

            return system;
        }
    }
}
