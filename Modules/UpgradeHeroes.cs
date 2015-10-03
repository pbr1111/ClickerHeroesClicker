using ClickerHeroesClicker.StaticMembers;
using System;
using System.Threading;

namespace ClickerHeroesClicker.Modules
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
                Shared.SendMouseLeft(_hwnd, Positions.UpgradeHeroe.X, Positions.UpgradeHeroe.Y);
                ReleaseZKey();

                Thread.Sleep(5000);
            }
        }

        private void PressZKey()
        {
            External.PostMessage(_hwnd, External.WM_KEYDOWN, (IntPtr)External.Z_KEY, (IntPtr)0x2c0001);
        }

        private void ReleaseZKey()
        {
            External.PostMessage(_hwnd, External.WM_KEYUP, (IntPtr)External.Z_KEY, IntPtr.Zero);
        }
    }
}
