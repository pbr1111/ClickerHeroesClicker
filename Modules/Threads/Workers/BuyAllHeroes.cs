using ClickerHeroesClicker.Shared;
using System;
using System.Threading;

namespace ClickerHeroesClicker.Modules.Threads.Workers
{
    public class BuyAllHeroes : Worker
    {
        public BuyAllHeroes(IntPtr hwnd) : base(hwnd)
        {
            _thread = new Thread(Run);
        }

        private void Run()
        {
            while (true)
            {
                wh.WaitOne();

                Thread.Sleep(5000);
            }
        }
    }
}
