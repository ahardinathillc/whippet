using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Imaging;
using NHibernate;
using NHibernate.UserTypes;
using NHibernate.SqlTypes;
using NHibernate.Engine;
using Athi.Whippet.Extensions.Drawing.Imaging;

namespace Athi.Whippet.Data.NHibernate.UserTypes.Drawing.Imaging
{
    /// <summary>
    /// Base class for the custom <see cref="IUserType"/> for <see cref="ImageCodecInfo"/>. This class must be inherited.
    /// </summary>
    public abstract class ImageCodecInfoUserTypeBase : WhippetUserTypeBase, IUserType
    {
        /// <summary>
        /// Determines if the <see cref="ImageCodecInfo"/> object is an encoder or decoder.
        /// </summary>
        private bool IsEncoder
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageCodecInfoUserTypeBase"/> class with no arguments.
        /// </summary>
        private ImageCodecInfoUserTypeBase()
        {
            SqlTypes = new[] { SqlTypeFactory.Guid };
            ReturnedType = typeof(ImageCodecInfo);
            IsMutable = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageCodecInfoUserTypeBase"/> class.
        /// </summary>
        /// <param name="isEncoder">If <see langword="true"/>, the returned <see cref="ImageCodecInfo"/> object will be loaded as an encoder type; otherwise, a decoder type will be used.</param>
        protected ImageCodecInfoUserTypeBase(bool isEncoder)
            : this()
        {
            IsEncoder = isEncoder;
        }

        /// <summary>
        /// Retrieves an instance of the mapped class from an ADO result set. Implementors should handle possibility of <see langword="null"/> values. This method must be overridden.
        /// </summary>
        /// <param name="rs"><see cref="DbDataReader"/> object returned from the query.</param>
        /// <param name="names">Column names returned from the query.</param>
        /// <param name="session">The session for which the operation is done.</param>
        /// <param name="owner">The containing entity.</param>
        /// <returns>Value constructed from the data reader.</returns>
        public override object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
        {
            object rawObj = null;

            ImageCodecInfo codec = null;

            Guid guidValue = Guid.Empty;

            if (rs != null && names != null)
            {
                if (names.Any())
                {
                    rawObj = NHibernateUtil.Guid.NullSafeGet(rs, names[0], session);
                }
            }

            if (rawObj != null)
            {
                guidValue = Guid.Parse(Convert.ToString(rawObj));
                codec = IsEncoder ? (from ici in ImageCodecInfo.GetImageEncoders() where ici.FormatID == guidValue select ici).FirstOrDefault() : (from ici in ImageCodecInfo.GetImageEncoders() where ici.FormatID == guidValue select ici).FirstOrDefault();
            }

            return codec;
        }

        /// <summary>
        /// Writes an instance of the mapped class to a prepared statement. Implementors should handle possibility of <see langword="null"/> values. A multi-column type should be written to parameters starting from <paramref name="index"/>. This method must be overridden.
        /// </summary>
        /// <param name="cmd"><see cref="DbCommand"/> object containing the command statement.</param>
        /// <param name="value">Object to write.</param>
        /// <param name="index">Command parameter index.</param>
        /// <param name="session">The session for which the operation is done.</param>
        public override void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session)
        {
            if (cmd != null)
            {
                if (value == null)
                {
                    ((IDataParameter)(cmd.Parameters[index])).Value = DBNull.Value;
                }
                else
                {
                    ((IDataParameter)(cmd.Parameters[index])).Value = ((ImageCodecInfo)(value)).FormatID;
                }
            }
        }
    }
}
