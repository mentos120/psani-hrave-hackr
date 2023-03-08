using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace psani_hrave_hackr
{
    internal static class Program
    {
        static void Main()
        {
            CaptureScreen();
        }
        static void CaptureScreen()
        {
            Rectangle rect = new Rectangle(1531, 306, 803, 407);
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            bmp.Save("C:\\Users\\fabih\\Pictures\\psanihrave\\img.jpg", ImageFormat.Jpeg);
        }
    }
}
