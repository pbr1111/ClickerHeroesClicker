using ClickerHeroesClicker.Modules.Threads.Workers;
using System;
using System.Drawing;

namespace ClickerHeroesClicker.Modules.Threads
{
    public static class WorkerContainer
    {
        private static IntPtr _hwnd;

        public static Worker AbilitiesThread;
        public static Worker UpgradeHeroesThread;
        public static Worker ClickScreenThread;
        public static AutoClicker AutoClickerThread;
        public static Worker AscensionWaiterThread;

        public static void Create(IntPtr hwnd, Rectangle rect)
        {
            _hwnd = hwnd;
            AbilitiesThread = new Abilities(hwnd);
            UpgradeHeroesThread = new UpgradeHeroes(hwnd);
            ClickScreenThread = new ClickClickables(hwnd);
            AutoClickerThread = new AutoClicker(hwnd);
            AscensionWaiterThread = new AscensionWaiter(hwnd, rect);
        }

        public static void Stop()
        {
            if (_hwnd != IntPtr.Zero)
            {
                AbilitiesThread.Stop();
                UpgradeHeroesThread.Stop();
                ClickScreenThread.Stop();
                AutoClickerThread.Stop();
                AscensionWaiterThread.Stop();
            }
        }
    }
}
