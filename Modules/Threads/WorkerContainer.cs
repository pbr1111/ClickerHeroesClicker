using ClickerHeroesClicker.Modules.Threads.Workers;
using System;
using System.Drawing;

namespace ClickerHeroesClicker.Modules.Threads
{
    public static class WorkerContainer
    {
        public static Worker AbilitiesThread;
        public static Worker UpgradeHeroesThread;
        public static Worker ClickClickablesThread;
        public static AutoClicker AutoClickerThread;
        public static Worker AutoClickClickablesThread;
        //public static Worker BuyAllHeroesThread;

        public static void Create(IntPtr hwnd, Rectangle rect)
        {
            AbilitiesThread = new Abilities(hwnd);
            UpgradeHeroesThread = new UpgradeHeroes(hwnd);
            ClickClickablesThread = new ClickClickables(hwnd);
            AutoClickerThread = new AutoClicker(hwnd);
            AutoClickClickablesThread = new AutoClickClickables(hwnd, rect);
            //BuyAllHeroesThread = new BuyAllHeroes(hwnd, rect);
        }

        public static void Stop()
        {
            AbilitiesThread.Stop();
            UpgradeHeroesThread.Stop();
            ClickClickablesThread.Stop();
            AutoClickerThread.Stop();
            AutoClickClickablesThread.Stop();
            //BuyAllHeroesThread.Stop();
        }
    }
}
