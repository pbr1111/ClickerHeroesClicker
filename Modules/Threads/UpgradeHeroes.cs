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

                PressZKey();
                Methods.SendMouseLeft(_hwnd, Values.UpgradeHeroe.X, Values.UpgradeHeroe.Y);
                ReleaseZKey();

                Thread.Sleep(5000);
            }
        }

        private void PressZKey()
        {
            Win32API.PostMessage(_hwnd, Win32API.WM_KEYDOWN, (IntPtr)Win32API.Z_KEY, (IntPtr)0x2c0001);
        }

        private void ReleaseZKey()
        {
            Win32API.PostMessage(_hwnd, Win32API.WM_KEYUP, (IntPtr)Win32API.Z_KEY, IntPtr.Zero);
        }
    }
}
