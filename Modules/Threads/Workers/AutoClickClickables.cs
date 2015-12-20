using ClickerHeroesClicker.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace ClickerHeroesClicker.Modules.Threads.Workers
{
    public class AutoClickClickables : Worker
    {
        private const int MaxTolerance = 40;

        private Rectangle Bounds;
        private bool Found;

        public AutoClickClickables(IntPtr hwnd) : base(hwnd, 5000)
        {
            Found = false;
        }

        protected override bool StartOrResume()
        {
            Rectangle windowDimensions = Win32API.GetClientRect(Hwnd);
            if (windowDimensions.Width == 0)
            {
                Console.WriteLine("La finestra no ha d'estar minimitzada. Prem una tecla per continuar.");
                Console.ReadKey(true);
                return false;
            }
            Bounds = windowDimensions;
            return base.StartOrResume();
        }

        protected override void Run(object args)
        {
            int clickableId = -1;
            if ((clickableId = IsClickableVisible()) != -1)
            {
                Methods.SendMouseLeft(Hwnd, Values.Clickables[clickableId, 0], Values.Clickables[clickableId, 1]);
            }
        }

        public int IsClickableVisible()
        {
            int clickableId = -1;
            using (Bitmap bmp = WindowImageMethods.CaptureWindow(Hwnd, Bounds))
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
                    if (!Found)
                    {
                        Found = true;
                    }
                    else
                    {
                        clickableId = colorComparison.IndexOf(minValue);
                        Found = false;
                    }
                }
                else if (Found)
                {
                    Found = false;
                }
#if DEBUG
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
#endif
            }
            return clickableId;
        }
    }
}
