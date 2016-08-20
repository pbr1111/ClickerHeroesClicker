using ClickerHeroesClicker.Shared;
using System;

namespace ClickerHeroesClicker.Modules.Threads.Workers
{
    public class UpgradeHeroes : Worker
    {
        public UpgradeHeroes(IntPtr hwnd) : base(hwnd, 30000)
        {

        }

        protected override void Run(object args)
        {
            Methods.PressKey(this.Hwnd, Win32API.VK_CONTROL);
            Methods.SendMouseLeft(this.Hwnd, Values.UpgradeHeroe.X, Values.UpgradeHeroe.Y);
            Methods.ReleaseKey(this.Hwnd, Win32API.VK_CONTROL);
        }
    }
}
