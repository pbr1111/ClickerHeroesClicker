using ClickerHeroesClicker.StaticMembers;
using System;
using System.Threading;

namespace ClickerHeroesClicker.Modules
{
    public class AutoClicker : Worker
    {
        private static int MIN_INTENSITY = 1;
        private static int MAX_INTENSITY = 2;
        
        private int Intensity = MIN_INTENSITY;

        public AutoClicker(IntPtr hwnd)
        {
            _hwnd = hwnd;
            _thread = new Thread(Run);
        }

        private void Run()
        {
            while (true)
            {
                wh.WaitOne();

                switch(Intensity)
                {
                    case 1:
                        Shared.SendMouseLeft(_hwnd, Positions.ComboMantainer.X, Positions.ComboMantainer.Y);
                        Thread.Sleep(150);
                        break;
                    case 2:
                        Shared.SendMouseLeft(_hwnd, Positions.ComboMantainer.X, Positions.ComboMantainer.Y);
                        Shared.SendMouseLeft(_hwnd, Positions.ComboMantainer.X, Positions.ComboMantainer.Y);
                        Shared.SendMouseLeft(_hwnd, Positions.ComboMantainer.X, Positions.ComboMantainer.Y);
                        Shared.SendMouseLeft(_hwnd, Positions.ComboMantainer.X, Positions.ComboMantainer.Y);
                        Thread.Sleep(100);
                        break;
                };
            }
        }

        public int GetMinIntensity()
        {
            return MIN_INTENSITY;
        }

        public int UpIntensity()
        {
            if(Intensity < MAX_INTENSITY)
            {
                Intensity++;
            }
            return Intensity;
        }
        public int DownIntensity()
        {
            if (Intensity > MIN_INTENSITY)
            {
                Intensity--;
            }
            return Intensity;
        }

    }
}
