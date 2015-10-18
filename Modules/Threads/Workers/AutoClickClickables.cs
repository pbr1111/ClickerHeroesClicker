using ClickerHeroesClicker.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;

namespace ClickerHeroesClicker.Modules.Threads.Workers
{
    public class AutoClickClickables : Worker
    {
        private const int MaxTolerance = 40;

        private Rectangle bounds;
        private bool found;

        public AutoClickClickables(IntPtr hwnd, Rectangle rect) : base(hwnd, 5000)
        {
            bounds = rect;
            found = false;
        }

        protected override void Run(object args)
        {
            int clickableId = -1;
            if ((clickableId = IsClickableVisible()) != -1)
            {
                Methods.SendMouseLeft(_hwnd, Values.Clickables[clickableId, 0], Values.Clickables[clickableId, 1]);
            }
        }

        public int IsClickableVisible()
        {
            int clickableId = -1;
            using (Bitmap bmp = WindowImageMethods.CaptureWindow(_hwnd, bounds))
            {
                List<double> colorComparison = new List<double>();
                for (int i = 0; i < Values.Clickables.Length / 2; i++)
                {
                    colorComparison.Add(
                        WindowImageMethods.CompareColors(
                            bmp.GetPixel(Values.Clickables[i, 0], Values.Clickables[i, 1]),
                            Values.ClickableColor));
                }
                double minValue = colorComparison.Min();
                if (minValue < MaxTolerance)
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
    }
}
