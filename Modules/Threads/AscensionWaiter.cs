using ClickerHeroesClicker.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;

namespace ClickerHeroesClicker.Modules.Threads
{
    public class AscensionWaiter : Worker
    {
        private const int MAX_TOLERANCE = 40;

        private Rectangle bounds;
        private bool found;

        public AscensionWaiter(IntPtr hwnd, Win32API.WindowDimension rc)
        {
            _hwnd = hwnd;
            _thread = new Thread(Run);
            bounds = new Rectangle(rc.Left, rc.Top, rc.Right - rc.Left, rc.Bottom - rc.Top);
            found = false;
        }

        private void Run()
        {
            int clickableId = -1;
            while (true)
            {
                wh.WaitOne();

                if ((clickableId = IsClickableVisible()) != -1)
                {
                    Methods.SendMouseLeft(_hwnd, Values.Clickables[clickableId, 0], Values.Clickables[clickableId, 1]);
                }
                Thread.Sleep(2000);
            }
        }

        public int IsClickableVisible()
        {
            int clickableId = -1;
            using (Bitmap bmp = CaptureWindow())
            {
                List<double> colorComparison = new List<double>();
                for (int i = 0; i < Values.Clickables.Length / 2; i++)
                {
                    colorComparison.Add(
                        CompareColors(
                            bmp.GetPixel(Values.Clickables[i, 0], Values.Clickables[i, 1]),
                            Values.ClickableColor));
                }
                double minValue = colorComparison.Min();
                if (minValue < MAX_TOLERANCE)
                {
                    if (!found)
                    {
                        found = true;
                    }
                    else
                    {
                        clickableId = colorComparison.IndexOf(minValue);
                        found = false;
                    }
                }
                else if (found)
                {
                    found = false;
                }
//#if DEBUG
                if (clickableId != -1)
                {
                    string logPath = @"C:\Users\Pol\Desktop\clickerlog\img_" + DateTime.Now.ToString("yyyy_MM_dd");
                    if (!Directory.Exists(logPath))
                    {
                        Directory.CreateDirectory(logPath);
                    }
                    string hourStr = DateTime.Now.ToString("HH_mm_ss");
                    Color pixel = bmp.GetPixel(Values.Clickables[clickableId, 0], Values.Clickables[clickableId, 1]);
                    bmp.SetPixel(Values.Clickables[clickableId, 0], Values.Clickables[clickableId, 1], Color.Red);
                    bmp.Save(logPath + @"\img_" + hourStr + ".png", ImageFormat.Png);

                    using (StreamWriter outputFile = new StreamWriter(logPath + @"\positions.txt", true))
                    {
                        outputFile.WriteLine("{0} - ClickableId: {1}, X: {2}, Y: {3}, CompareColor: {4}, Pixel: ({5}, {6}, {7})",
                            hourStr,
                            clickableId,
                            Values.Clickables[clickableId, 0],
                            Values.Clickables[clickableId, 1],
                            minValue,
                            pixel.R,
                            pixel.G,
                            pixel.B);
                    }
                }
//#endif
            }
            return clickableId;
        }

        private Bitmap CaptureWindow()
        {
            Bitmap bmp = new Bitmap(bounds.Width, bounds.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                IntPtr hdcBitmap = g.GetHdc();
                try
                {
                    Win32API.PrintWindow(_hwnd, hdcBitmap, Win32API.PW_CLIENTONLY);
                }
                finally
                {
                    g.ReleaseHdc(hdcBitmap);
                }
            }
            return bmp;
        }

        private double CompareColors(Color a, Color b)
        {
            return Math.Sqrt(
                Math.Abs(
                    Math.Pow(a.R - b.R, 2) +
                    Math.Pow(a.G - b.G, 2) +
                    Math.Pow(a.B - b.B, 2)));
        }
    }
}
