using ClickerHeroesClicker.Shared;
using System;
using System.Threading;

namespace ClickerHeroesClicker.Modules.Threads.Workers
{
    public class UpgradeHeroes : Worker
    {
        public UpgradeHeroes(IntPtr hwnd) : base(hwnd, 30000)
        {

        }

        protected override void Run(object args)
        {
            Methods.PressKey(_hwnd, Win32API.VK_CONTROL);
            Methods.SendMouseLeft(_hwnd, Values.UpgradeHeroe.X, Values.UpgradeHeroe.Y);
            Methods.ReleaseKey(_hwnd, Win32API.VK_CONTROL);
        }
    }
}
