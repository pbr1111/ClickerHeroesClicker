using ClickerHeroesClicker.Shared;
using System;

namespace ClickerHeroesClicker.Modules.Threads.Workers
{
    public class AutoClicker : Worker
    {
        private IntensityLevel Intensity;

        public AutoClicker(IntPtr hwnd) : base(hwnd, 100)
        {
            this.Intensity = IntensityLevel.Minimum;
        }

        protected override void Run(object args)
        {
            switch (this.Intensity)
            {
                case IntensityLevel.Minimum:
                    Methods.SendMouseLeft(this.Hwnd, Values.ComboMantainer.X, Values.ComboMantainer.Y);
                    break;
                case IntensityLevel.Maximum:
                    Methods.SendMouseLeft(this.Hwnd, Values.ComboMantainer.X, Values.ComboMantainer.Y);
                    Methods.SendMouseLeft(this.Hwnd, Values.ComboMantainer.X, Values.ComboMantainer.Y);
                    Methods.SendMouseLeft(this.Hwnd, Values.ComboMantainer.X, Values.ComboMantainer.Y);
                    Methods.SendMouseLeft(this.Hwnd, Values.ComboMantainer.X, Values.ComboMantainer.Y);
                    break;
            }
        }

        public int GetMinIntensity()
        {
            return (int)IntensityLevel.Minimum;
        }

        public int UpIntensity()
        {
            if (this.Intensity < IntensityLevel.Maximum)
            {
                this.Intensity++;
            }
            return (int)this.Intensity;
        }
        public int DownIntensity()
        {
            if (this.Intensity > IntensityLevel.Minimum)
            {
                this.Intensity--;
            }
            return (int)this.Intensity;
        }

        public enum IntensityLevel
        {
            Minimum = 1,
            Maximum = 2,
        }

    }
}
