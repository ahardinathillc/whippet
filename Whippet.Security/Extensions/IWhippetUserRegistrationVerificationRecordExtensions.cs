using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.Security.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IWhippetUserRegistrationVerificationRecord"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IWhippetUserRegistrationVerificationRecordExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IWhippetUserRegistrationVerificationRecord"/> object to a <see
        /// </summary>
        /// <param name="verificationRecord"><see cref="IWhippetUserRegistrationVerificationRecord"/> object to convert.</param>
        /// <returns><see cref="WhippetUserRegistrationVerificationRecord"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public static WhippetUserRegistrationVerificationRecord ToWhippetUserRegistrationVerificationRecord(this IWhippetUserRegistrationVerificationRecord verificationRecord)
        {
            if(verificationRecord == null)
            {
                throw new ArgumentNullException(nameof(verificationRecord));
            }
            else
            {
                WhippetUserRegistrationVerificationRecord wuRecord = new WhippetUserRegistrationVerificationRecord(
                    verificationRecord.ID,
                    verificationRecord.UserName,
                    verificationRecord.AuthenticationKey,
                    verificationRecord.AuthenticationUrl,
                    verificationRecord.RequestExpirationDate,
                    verificationRecord.DateAuthenticated,
                    verificationRecord.IPAddress,
                    verificationRecord.CreatedDateTime,
                    verificationRecord.CreatedBy,
                    verificationRecord.LastModifiedDateTime,
                    verificationRecord.LastModifiedBy,
                    verificationRecord.Deleted,
                    verificationRecord.Tenant?.ToWhippetTenant()
                );

                wuRecord.UserId = verificationRecord.UserId;

                return wuRecord;
            }
        }
    }
}
