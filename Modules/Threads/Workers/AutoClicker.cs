using ClickerHeroesClicker.Shared;
using System;
using System.Threading;

namespace ClickerHeroesClicker.Modules.Threads.Workers
{
    public class AutoClicker : Worker
    {
        private IntensityLevel Intensity;

        public AutoClicker(IntPtr hwnd) : base(hwnd, 100)
        {
            Intensity = IntensityLevel.Minimum;
        }

        protected override void Run(object args)
        {
            switch (Intensity)
            {
                case IntensityLevel.Minimum:
                    Methods.SendMouseLeft(_hwnd, Values.ComboMantainer.X, Values.ComboMantainer.Y);
                    break;
                case IntensityLevel.Maximum:
                    Methods.SendMouseLeft(_hwnd, Values.ComboMantainer.X, Values.ComboMantainer.Y);
                    Methods.SendMouseLeft(_hwnd, Values.ComboMantainer.X, Values.ComboMantainer.Y);
                    Methods.SendMouseLeft(_hwnd, Values.ComboMantainer.X, Values.ComboMantainer.Y);
                    Methods.SendMouseLeft(_hwnd, Values.ComboMantainer.X, Values.ComboMantainer.Y);
                    break;
            }
        }

        public int GetMinIntensity()
        {
            return (int)IntensityLevel.Minimum;
        }

        public int UpIntensity()
        {
            if (Intensity < IntensityLevel.Maximum)
            {
                Intensity++;
            }
            return (int)Intensity;
        }
        public int DownIntensity()
        {
            if (Intensity > IntensityLevel.Minimum)
            {
                Intensity--;
            }
            return (int)Intensity;
        }

        public enum IntensityLevel
        {
            Minimum = 1,
            Maximum = 2,
        }

    }
}
