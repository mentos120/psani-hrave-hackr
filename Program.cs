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
            Console.WriteLine("TP/O/TGT/FISH [test psani / ostatni psani / bonus kolo / ryba");
            string choose = Console.ReadLine();
            new InputSimulator().Keyboard
                .KeyDown(VirtualKeyCode.MENU)
                .ModifiedKeyStroke(VirtualKeyCode.TAB, VirtualKeyCode.TAB)
                .Sleep(500)
                .KeyUp(VirtualKeyCode.MENU) 
                .Sleep(500) 
                .KeyPress(VirtualKeyCode.SPACE)
                .Sleep(800);
            CaptureScreen(choose);
        }   
        static void CaptureScreen(string choose)
        {
            switch (choose)
            {
                case "TP":
                    TPResolve();
                    break;
                case "O":
                    OResolve();
                    break;
                case "TGT":
                    TGTResolve();
                    break;
                case "FISH":
                    FishResolve();
                    break;

            }
        }
        static void OResolve()
        {
            Rectangle rect = new Rectangle(1608, 339, 820, 420);
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            bmp.Save("C:\\Users\\fabih\\Pictures\\psanihrave\\img.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            OCRresolve();
        }
        static void TPResolve()
        {
            Rectangle rect = new Rectangle(1500, 300, 820, 402);
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            bmp.Save("C:\\Users\\fabih\\Pictures\\psanihrave\\img.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            OCRresolve();
        }
        static void TGTResolve()
        {
            for (int i = 0; i <= 20; i++)
            {
                Thread.Sleep(300);
                Rectangle rect = new Rectangle(1946, 540, 151, 35);
                Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(bmp); 
                g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
                bmp.Save("C:\\Users\\fabih\\Pictures\\psanihrave\\img.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                var engine = new TesseractEngine("C:\\Users\\fabih\\source\\repos\\psani hrave hackr","ces", EngineMode.Default);
                var img = Pix.LoadFromFile("C:\\Users\\fabih\\Pictures\\psanihrave\\img.bmp");
                var page = engine.Process(img);
                var text = page.GetText();
                text.Remove(0, text.Length);
                Console.WriteLine(text);
                string cleanText = text.Replace("\n", " ").Replace("  ", " ");
                char[] chars = cleanText.ToCharArray();
                Console.WriteLine();
                foreach (char c in chars) { Console.Write(c); }
                WriteText(chars);
            }            
        }
        static void FishResolve()
        {
            Thread.Sleep(4000);
            for (int i =0; i < 20; i++)
            {
                Thread.Sleep(1300);
                Rectangle rect = new Rectangle(1614, 402, 800, 339);
                Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(bmp);
                g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
                bmp.Save("C:\\Users\\fabih\\Pictures\\psanihrave\\img.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                var engine = new TesseractEngine("C:\\Users\\fabih\\source\\repos\\psani hrave hackr","ces", EngineMode.Default);
                var img = Pix.LoadFromFile("C:\\Users\\fabih\\Pictures\\psanihrave\\img.bmp");
                var page = engine.Process(img);
                var text = page.GetText();
                text.Remove(0, text.Length);
                Console.WriteLine(text);
                string cleanText = text.Replace("\n", "").Replace(" ", "");
                char[] chars = cleanText.ToCharArray();
                Console.WriteLine();
                foreach (char c in chars) { Console.Write(c); }
                WriteText(chars);
            }
            
        }
        static void WriteText(char[] chars)
        {
            foreach(char c in chars)
            {
                new InputSimulator().Keyboard
                .TextEntry(c.ToString())
                .Sleep(150);
            }
        }
        static void OCRresolve()
        {
            var engine = new TesseractEngine("C:\\Users\\fabih\\source\\repos\\psani hrave hackr","ces", EngineMode.Default);
            var img = Pix.LoadFromFile("C:\\Users\\fabih\\Pictures\\psanihrave\\img.bmp");
            var page = engine.Process(img);
            var text = page.GetText();
            Console.WriteLine(text);
            string cleanText = text.Replace("\n", " ").Replace("  ", " ").Remove(0, 2);
            char[] chars = cleanText.ToCharArray(); 
            Console.WriteLine();
            foreach (char c in chars) { Console.Write(c); }
            WriteText(chars);
        }
    }
}
