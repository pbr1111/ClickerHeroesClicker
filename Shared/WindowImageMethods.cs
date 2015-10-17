using System;
using System.Drawing;

namespace ClickerHeroesClicker.Shared
{
    public static class WindowImageMethods
    {
        public static Bitmap CaptureWindow(IntPtr hwnd, Rectangle bounds)
        {
            Bitmap bmp = new Bitmap(bounds.Width, bounds.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                IntPtr hdcBitmap = g.GetHdc();
                try
                {
                    Win32API.PrintWindow(hwnd, hdcBitmap, Win32API.PW_CLIENTONLY);
                }
                finally
                {
                    g.ReleaseHdc(hdcBitmap);
                }
            }
            return bmp;
        }

        public static double CompareColors(Color a, Color b)
        {
            return Math.Sqrt(
                Math.Abs(
                    Math.Pow(a.R - b.R, 2) +
                    Math.Pow(a.G - b.G, 2) +
                    Math.Pow(a.B - b.B, 2)));
        }
    }
}
