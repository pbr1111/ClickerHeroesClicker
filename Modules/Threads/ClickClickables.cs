using ClickerHeroesClicker.Shared;
using System;
using System.Threading;

namespace ClickerHeroesClicker.Modules.Threads
{
    public class ClickClickables : Worker
    {
        public ClickClickables(IntPtr hwnd)
        {
            _hwnd = hwnd;
            _thread = new Thread(Run);
        }

        private void Run()
        {
            while (true)
            {
                wh.WaitOne();

                ClickClickablePositions();
                Thread.Sleep(5000);
            }
        }

        private void ClickClickablePositions()
        {
            for (int i = 0; i < Values.Clickables.Length / 2; i++)
            {
                Methods.SendMouseLeft(_hwnd, Values.Clickables[i, 0], Values.Clickables[i, 1]);
            }
        }
    }
}
