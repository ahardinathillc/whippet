using System;
using CouchDB.Driver.Types;

namespace Athi.Whippet.Data.Database.NoSQL.Apache.CouchDB.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IWhippetCouchUser"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IWhippetCouchUserExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IWhippetCouchUser"/> object to a <see cref="WhippetCouchUser"/> object.
        /// </summary>
        /// <param name="obj"><see cref="IWhippetCouchUser"/> object to convert.</param>
        /// <returns><see cref="WhippetCouchUser"/> object.</returns>
        public static WhippetCouchUser ToWhippetCouchUser(this IWhippetCouchUser obj)
        {
            WhippetCouchUser user = null;

            if (obj != null)
            {
                if (obj is WhippetCouchUser)
                {
                    user = ((WhippetCouchUser)(obj));
                }
                else
                {
                    user = new WhippetCouchUser(obj.ToCouchUser());
                }
            }

            return user;
        }
    }
}
