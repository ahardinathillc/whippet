using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using NHibernate;
using NHibernate.UserTypes;
using NHibernate.SqlTypes;
using NHibernate.Engine;

namespace Athi.Whippet.Data.NHibernate.UserTypes.Drawing
{
    /// <summary>
    /// Represents the custom <see cref="IUserType"/> for <see cref="Image"/>.
    /// </summary>
    public class ImageUserType : WhippetUserTypeBase, IUserType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageUserType"/> class with no arguments.
        /// </summary>
        public ImageUserType()
        {
            SqlTypes = new[] { SqlTypeFactory.GetBinaryBlob(Int32.MaxValue) };
            ReturnedType = typeof(Image);
            IsMutable = true;
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
            bool failed = false;

            object rawObj = null;

            Image image = null;

            ImageConverter imageConverter = null;

            if (rs != null && names != null)
            {
                if (names.Any())
                {
                    rawObj = NHibernateUtil.BinaryBlob.NullSafeGet(rs, names[0], session);
                }
            }

            if (rawObj != null)
            {
                try
                {
                    imageConverter = new ImageConverter();
                    image = imageConverter.ConvertFrom(rawObj) as Image;
                }
                catch (Exception)
                {
                    failed = true;
                    throw;
                }
                finally
                {
                    if (failed && (image != null))
                    {
                        image.Dispose();
                        image = null;
                    }
                }
            }

            return image;
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
            ImageConverter imageConverter = null;

            byte[] imageBytes = null;

            if (cmd != null)
            {
                if (value == null)
                {
                    ((IDataParameter)(cmd.Parameters[index])).Value = DBNull.Value;
                }
                else
                {
                    imageConverter = new ImageConverter();
                    imageBytes = (byte[])(imageConverter.ConvertTo(value, typeof(byte[])));

                    ((IDataParameter)(cmd.Parameters[index])).Value = imageBytes;
                }
            }
        }
    }
}