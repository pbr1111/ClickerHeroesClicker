using ClickerHeroesClicker.Modules.Threads.Workers;
using System;

namespace ClickerHeroesClicker.Modules.Threads
{
    public static class WorkerContainer
    {
        public static Worker AbilitiesThread;
        public static Worker UpgradeHeroesThread;
        public static Worker ClickClickablesThread;
        public static AutoClicker AutoClickerThread;
        public static Worker AutoClickClickablesThread;
        public static Worker FarmModeThread;
        //public static Worker BuyAllHeroesThread;

        public static void Create(IntPtr hwnd)
        {
            WorkerContainer.AbilitiesThread = new Abilities(hwnd);
            WorkerContainer.UpgradeHeroesThread = new UpgradeHeroes(hwnd);
            WorkerContainer.ClickClickablesThread = new ClickClickables(hwnd);
            WorkerContainer.AutoClickerThread = new AutoClicker(hwnd);
            WorkerContainer.AutoClickClickablesThread = new AutoClickClickables(hwnd);
            WorkerContainer.FarmModeThread = new FarmMode(hwnd);
            //WorkerContainer.BuyAllHeroesThread = new BuyAllHeroes(hwnd, rect);
        }

        public static void Stop()
        {
            WorkerContainer.AbilitiesThread.Stop();
            WorkerContainer.UpgradeHeroesThread.Stop();
            WorkerContainer.ClickClickablesThread.Stop();
            WorkerContainer.AutoClickerThread.Stop();
            WorkerContainer.AutoClickClickablesThread.Stop();
            WorkerContainer.FarmModeThread.Stop();
            //WorkerContainer.BuyAllHeroesThread.Stop();
        }
    }
}
