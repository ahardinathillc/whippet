using System;
using System.ComponentModel;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="MultichannelOrderManagerCustomerRelationshipType"/> enumeration values. This class cannot be inherited.
    /// </summary>
    public static class MultichannelOrderManagerCustomerRelationshipTypeExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="MultichannelOrderManagerCustomerRelationshipType"/> value to its equivalent character field value.
        /// </summary>
        /// <param name="value"><see cref="MultichannelOrderManagerCustomerRelationshipType"/> value to convert.</param>
        /// <returns><see cref="char"/> value representing the field value in the database.</returns>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        public static char ToCharacter(this MultichannelOrderManagerCustomerRelationshipType value)
        {
            switch (value)
            {
                case MultichannelOrderManagerCustomerRelationshipType.AlternateAddress:
                    return 'A';
                case MultichannelOrderManagerCustomerRelationshipType.BillToAddress:
                    return 'B';
                case MultichannelOrderManagerCustomerRelationshipType.ContactNameAddress:
                    return 'C';
                case MultichannelOrderManagerCustomerRelationshipType.GiftRecipient:
                    return 'G';
                case MultichannelOrderManagerCustomerRelationshipType.MailToAddress:
                    return 'M';
                case MultichannelOrderManagerCustomerRelationshipType.PrimaryAddress:
                    return 'P';
                case MultichannelOrderManagerCustomerRelationshipType.ShipToAddress:
                    return 'S';
                case MultichannelOrderManagerCustomerRelationshipType.SoldToAddress:
                    return 'L';
                default:
                    throw new InvalidEnumArgumentException(nameof(value), Convert.ToInt32(value), typeof(MultichannelOrderManagerCustomerRelationshipType));
            }
        }

        /// <summary>
        /// Converts the specified <see cref="char"/> value to its equivalent <see cref="MultichannelOrderManagerCustomerRelationshipType"/> value.
        /// </summary>
        /// <param name="value"><see cref="MultichannelOrderManagerCustomerRelationshipType"/> enum object.</param>
        /// <param name="fieldValue"><see cref="char"/> value to parse.</param>
        /// <returns><see cref="MultichannelOrderManagerCustomerRelationshipType"/> value.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static MultichannelOrderManagerCustomerRelationshipType ParseFieldValue(this MultichannelOrderManagerCustomerRelationshipType value, char fieldValue)
        {
            fieldValue = Char.ToUpper(fieldValue);

            switch (fieldValue)
            {
                case 'A':
                    return MultichannelOrderManagerCustomerRelationshipType.AlternateAddress;
                case 'B':
                    return MultichannelOrderManagerCustomerRelationshipType.BillToAddress;
                case 'C':
                    return MultichannelOrderManagerCustomerRelationshipType.ContactNameAddress;
                case 'G':
                    return MultichannelOrderManagerCustomerRelationshipType.GiftRecipient;
                case 'M':
                    return MultichannelOrderManagerCustomerRelationshipType.MailToAddress;
                case 'P':
                    return MultichannelOrderManagerCustomerRelationshipType.PrimaryAddress;
                case 'S':
                    return MultichannelOrderManagerCustomerRelationshipType.ShipToAddress;
                case 'L':
                    return MultichannelOrderManagerCustomerRelationshipType.SoldToAddress;
                default:
                    throw new ArgumentException();
            }
        }
    }
}

