using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace Midbay_NG.Operators
{
    public static class ImageCompression
    {
        public static Image CreateThumbnail(string lcFilename, int lnWidth, int lnHeight)
        {
            Image image = new Bitmap(lcFilename);
            Image pThumbnail = image.GetThumbnailImage(lnWidth, lnHeight, () => false, IntPtr.Zero);
            return pThumbnail;

        }

    }
}