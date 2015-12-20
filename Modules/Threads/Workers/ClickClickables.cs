using ClickerHeroesClicker.Shared;
using System;

namespace ClickerHeroesClicker.Modules.Threads.Workers
{
    public class ClickClickables : Worker
    {
        public ClickClickables(IntPtr hwnd) : base(hwnd, 5000)
        {

        }

        protected override void Run(object args)
        {
            for (int i = 0; i < Values.Clickables.Length / 2; i++)
            {
                Methods.SendMouseLeft(Hwnd, Values.Clickables[i, 0], Values.Clickables[i, 1]);
            }
        }
    }
}

