using ClickerHeroesClicker.Shared;
using System;
using System.Threading;

namespace ClickerHeroesClicker.Modules.Threads.Workers
{
    public class AutoClicker : Worker
    {
        private IntensityLevel Intensity = IntensityLevel.Min;

        public AutoClicker(IntPtr hwnd) : base(hwnd)
        {
            _thread = new Thread(Run);
        }

        private void Run()
        {
            while (true)
            {
                wh.WaitOne();

                switch (Intensity)
                {
                    case IntensityLevel.Min:
                        Methods.SendMouseLeft(_hwnd, Values.ComboMantainer.X, Values.ComboMantainer.Y);
                        Thread.Sleep(150);
                        break;
                    case IntensityLevel.Max:
                        Methods.SendMouseLeft(_hwnd, Values.ComboMantainer.X, Values.ComboMantainer.Y);
                        Methods.SendMouseLeft(_hwnd, Values.ComboMantainer.X, Values.ComboMantainer.Y);
                        Methods.SendMouseLeft(_hwnd, Values.ComboMantainer.X, Values.ComboMantainer.Y);
                        Methods.SendMouseLeft(_hwnd, Values.ComboMantainer.X, Values.ComboMantainer.Y);
                        Thread.Sleep(100);
                        break;
                }
            }
        }

        public int GetMinIntensity()
        {
            return (int)IntensityLevel.Min;
        }

        public int UpIntensity()
        {
            if (Intensity < IntensityLevel.Max)
            {
                Intensity++;
            }
            return (int)Intensity;
        }
        public int DownIntensity()
        {
            if (Intensity > IntensityLevel.Min)
            {
                Intensity--;
            }
            return (int)Intensity;
        }

        public enum IntensityLevel
        {
            Min = 1,
            Max = 2
        }

    }
}
