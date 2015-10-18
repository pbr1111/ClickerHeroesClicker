using ClickerHeroesClicker.Shared;
using System;
using System.Drawing;
using System.Threading;

namespace ClickerHeroesClicker.Modules.Threads.Workers
{
    public class BuyAllHeroes : Worker
    {
        private const int MaxTolerance = 40;
        private Rectangle bounds;

        public BuyAllHeroes(IntPtr hwnd, Rectangle rect) : base(hwnd, 10000)
        {
            bounds = rect;
        }

        protected override void Run(object args)
        {
            //GoToFirstHeroe();

            /*Methods.PressMouseLeft(_hwnd, Values.Scroll.X, Values.Scroll.DownY);
            while (true)
            {
                using (Bitmap bmp = WindowImageMethods.CaptureWindow(_hwnd, bounds))
                {
                    if (WindowImageMethods.CompareColors(bmp.GetPixel(548, 611), Color.FromArgb(212, 177, 79)) < MaxTolerance)
                    {
                        Methods.ReleaseMouseLeft(_hwnd, Values.Scroll.X, Values.Scroll.DownY);
                        break;
                    }
                }
                Thread.Sleep(1000);
            }*/

            //Methods.ReleaseMouseLeft(_hwnd, Values.Scroll.X, Values.Scroll.DownY);
        }

        private void GoToFirstHeroe()
        {
            Methods.PressMouseLeft(_hwnd, Values.Scroll.X, Values.Scroll.UpY);
            while (true)
            {
                using (Bitmap bmp = WindowImageMethods.CaptureWindow(_hwnd, bounds))
                {
                    if (WindowImageMethods.CompareColors(bmp.GetPixel(548, 201), Color.FromArgb(212, 149, 27)) < MaxTolerance)
                    {
                        Methods.ReleaseMouseLeft(_hwnd, Values.Scroll.X, Values.Scroll.UpY);
                        break;
                    }
                }
                Thread.Sleep(2000);
            }
        }
    }
}
