using ClickerHeroesClicker.Shared;
using System;
using System.Threading;

namespace ClickerHeroesClicker.Modules.Threads
{
    public class UpgradeHeroes: Worker
    {
        public UpgradeHeroes(IntPtr hwnd)
        {
            _hwnd = hwnd;
            _thread = new Thread(Run);
        }

        private void Run()
        {
            while(true)
            {
                wh.WaitOne();

                Methods.PressKey(_hwnd, Win32API.VK_CONTROL);
                Methods.SendMouseLeft(_hwnd, Values.UpgradeHeroe.X, Values.UpgradeHeroe.Y);
                Methods.ReleaseKey(_hwnd, Win32API.VK_CONTROL);

                Thread.Sleep(30000);
            }
        }
    }
}
