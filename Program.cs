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
using WindowsInput;
using Tesseract;
using System.Threading;

namespace psani_hrave_hackr
{
    internal static class Program
    {
        static void Main()
        {
            new InputSimulator().Keyboard
                .KeyDown(VirtualKeyCode.MENU)
                .ModifiedKeyStroke(VirtualKeyCode.TAB, VirtualKeyCode.TAB)
                .Sleep(100)
                .KeyUp(VirtualKeyCode.MENU)
                .Sleep(500);           
            Thread.Sleep(500);
            OResolve();
        }   
        static void OResolve()
        {
            Thread.Sleep(500);
            Rectangle rect = new Rectangle(62, 246, 2500, 150);
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            bmp.Save("C:\\Users\\fabih\\Pictures\\psanihrave\\img.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            OCRresolve();
        }
        static void WriteText(char[] chars)
        {
            foreach(char c in chars)
            {
                Random r = new Random();
                int rInt = r.Next(300, 500);
                new InputSimulator().Keyboard
                .TextEntry(c.ToString())
                .Sleep(rInt);
                Console.WriteLine(rInt);
            }
        }
        static void OCRresolve()
        {
            var engine = new TesseractEngine("C:\\Users\\fabih\\source\\repos\\psani hrave hackr","ces", EngineMode.Default);
            var img = Pix.LoadFromFile("C:\\Users\\fabih\\Pictures\\psanihrave\\img.bmp");
            var page = engine.Process(img);
            var text = page.GetText();
            Console.WriteLine(text);
            string cleanText = text.Remove(text.Length-1, 1);
            char[] chars = cleanText.ToCharArray(); 
            Console.WriteLine();
            foreach (char c in chars) { Console.Write(c); }
            WriteText(chars);
        }
    }
}
