using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Mnist.DesktopApp
{
    class ImageUtils
    {
        public static Bitmap PanelToBitmap(Panel pnl)
        {
            var bmp = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            return bmp;
        }

        public static Bitmap ResizeImage(Bitmap imgToResize, Size size)
        {
            Bitmap b = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(imgToResize, 0, 0, size.Width, size.Height);
            }
            return b;
        }

        public static float[] ConvertToGrayScaleArray(Bitmap image)
        {
            var height = image.Size.Height;
            var width = image.Size.Width;
            var data = new float[height * width];
            for (var x = 0; x < height; x++)
            {
                for (var y = 0; y < width; y++)
                {
                    // Be careful about the X/Y direction
                    var color = image.GetPixel(y, x);
                    // 1. Convert to gray
                    // 2. Normalize to [-0.5,0.5]
                    // 3. Turn to black background and white digit like MNIST dataset
                    data[x * width + y] = (float)(0.5 - (color.R + color.G + color.B) / (3.0 * 255));
                }
            }
            return data;
        }
    }
}
