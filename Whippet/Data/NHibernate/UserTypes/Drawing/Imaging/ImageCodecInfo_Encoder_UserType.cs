using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using NHibernate;
using NHibernate.UserTypes;
using NHibernate.SqlTypes;
using NHibernate.Engine;

namespace Athi.Whippet.Data.NHibernate.UserTypes.Drawing.Imaging
{
    /// <summary>
    /// Represents the custom <see cref="IUserType"/> for <see cref="ImageCodecInfo"/> objects that are used for getting image encodings.
    /// </summary>
    public class ImageCodecInfo_Encoder_UserType : ImageCodecInfoUserTypeBase, IUserType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageCodecInfo_Encoder_UserType"/> class with no arguments.
        /// </summary>
        public ImageCodecInfo_Encoder_UserType()
            : base(true)
        { }
    }
}