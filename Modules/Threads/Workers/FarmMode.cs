using ClickerHeroesClicker.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ClickerHeroesClicker.Modules.Threads.Workers
{
    public class FarmMode : Worker
    {
        private const int MaxTolerance = 5;
        private Rectangle Bounds;

        public FarmMode(IntPtr hwnd) : base(hwnd, 20000)
        {

        }

        protected override bool StartOrResume()
        {
            Rectangle windowDimensions = Win32API.GetClientRect(this.Hwnd);
            if (windowDimensions.Width == 0)
            {
                Console.WriteLine("La finestra no ha d'estar minimitzada. Prem una tecla per continuar.");
                Console.ReadKey(true);
                return false;
            }
            this.Bounds = windowDimensions;
            return base.StartOrResume();
        }

        protected override void Run(object args)
        {
            if (!this.IsFarmModeActive())
            {
                Methods.SendMouseLeft(this.Hwnd, Values.FarmMode.X, Values.FarmMode.Y);
            }
        }

        private bool IsFarmModeActive()
        {
            bool active = true;
            using (Bitmap bmp = WindowImageMethods.CaptureWindow(this.Hwnd, this.Bounds))
            {
                Color pixelColor = bmp.GetPixel(Values.FarmMode.X, Values.FarmMode.Y);
                double colorComparison = WindowImageMethods.CompareColors(pixelColor, Values.FarmModeInactiveColor);
                active = colorComparison >= FarmMode.MaxTolerance;
            }
            return active;
        }
    }
}
