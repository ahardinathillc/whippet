using System;
using System.Linq;
using System.Linq.Expressions;
using System.Drawing.Imaging;

namespace Athi.Whippet.Extensions.Drawing.Imaging
{
    /// <summary>
    /// Provides extension methods to <see cref="ImageCodecInfo"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ImageCodecInfoExtensions
    {
        /// <summary>
        /// Gets the <see cref="ImageCodecInfo"/> object for the specified <see cref="ImageFormat"/>.
        /// </summary>
        /// <param name="codec"><see cref="ImageCodecInfo"/> object.</param>
        /// <param name="format"><see cref="ImageFormat"/> to get the <see cref="ImageCodecInfo"/> for.</param>
        /// <returns><see cref="ImageCodecInfo"/> object or <see langword="null"/> if no appropriate codec could be found.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ImageCodecInfo GetEncoder(this ImageCodecInfo codec, ImageFormat format)
        {
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }
            else
            {
                return (from ici in ImageCodecInfo.GetImageEncoders() where ici.FormatID == format.Guid select ici).FirstOrDefault();
            }
        }
    }
}

