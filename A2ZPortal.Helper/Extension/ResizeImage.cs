using System.Drawing;
using System.Drawing.Drawing2D;

namespace A2ZPortal.Helper.Extension
{
    public static class ResizeImage
    {
        //System.Drawing.Image i = resizeImage(b, new Size(100, 100));
        public static  Image ResizeImageData(string imagePath, Size size)
        {
            
            var imgToResize = Image.FromFile(imagePath);
            var sourceWidth = imgToResize.Width;
            var sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            nPercentW = size.Width / (float) sourceWidth;
            nPercentH = size.Height / (float) sourceHeight;
            nPercent = nPercentH < nPercentW ? nPercentH : nPercentW;
            var destWidth = (int) (sourceWidth * nPercent);
            var destHeight = (int) (sourceHeight * nPercent);
            var b = new Bitmap(destWidth, destHeight);
            var g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return b;
        }
    }
}