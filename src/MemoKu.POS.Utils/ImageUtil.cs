using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace MemoKu.POS.Utils
{
    public static class ImageUtil
    {
        public static byte[] Resize(this Image img, int width, int height)
        {
            var imageResized = img.ResizeToImage(width, height);
            MemoryStream stream = new MemoryStream();
            imageResized.Save(stream, ImageFormat.Png);
            return stream.ToArray();
        }

        public static Image ResizeToImage(this Image img, int width, int height)
        {
            int sourceWidth = img.Width;
            int sourceHeight = img.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)width / (float)sourceWidth);
            nPercentH = ((float)height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(img, 0, 0, destWidth, destHeight);
            g.Dispose();

            img = (Image)b;
            return img;
        }
    }
}
