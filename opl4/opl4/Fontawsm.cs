using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using FontAwesome.Sharp;

namespace opl4
{

    public static class IconCharExtensions
    {

        public static System.Drawing.Icon ToSystemIcon(this IconChar iconChar, int size, Color color)
        {
            int bitmapSize = size * 2;
            using (var bitmap = new Bitmap(bitmapSize, bitmapSize))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.Transparent);
                graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                using (var font = new Font("Font Awesome 6 Free", size * 0.8f))
                {
                    var format = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };

                    graphics.DrawString(
                        char.ConvertFromUtf32((int)iconChar),
                        font,
                        new SolidBrush(color),
                        new RectangleF(0, 0, bitmapSize, bitmapSize),
                        format);
                }

                using (var ms = new MemoryStream())
                {
                    bitmap.Save(ms, ImageFormat.Png);
                    ms.Position = 0; 
                    using (var tmpBmp = new Bitmap(ms))
                    {
                        return System.Drawing.Icon.FromHandle(tmpBmp.GetHicon());
                    }
                }
            }
        }
    }
}
