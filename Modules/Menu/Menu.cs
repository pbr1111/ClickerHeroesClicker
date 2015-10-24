using ClickerHeroesClicker.Modules.Threads;
using System;

namespace ClickerHeroesClicker.Modules.Menu
{
    public static class Menu
    {
        private static int Intensity;

        public static void ShowOptionsWaiter()
        {
            Intensity = WorkerContainer.AutoClickerThread.GetMinIntensity();

            ShowOptions(Intensity);

            ConsoleKey pressed;
            while ((pressed = Console.ReadKey(true).Key) != ConsoleKey.Escape)
            {
                switch (pressed)
                {
                    case ConsoleKey.F1:
                        WorkerContainer.AbilitiesThread.ChangeRunState();
                        break;
                    case ConsoleKey.F2:
                        WorkerContainer.UpgradeHeroesThread.ChangeRunState();
                        break;
                    case ConsoleKey.F3:
                        WorkerContainer.ClickClickablesThread.ChangeRunState();
                        break;
                    case ConsoleKey.F4:
                        WorkerContainer.AutoClickerThread.ChangeRunState();
                        break;
                    case ConsoleKey.F5:
                        WorkerContainer.AutoClickClickablesThread.ChangeRunState();
                        break;
                    /*case ConsoleKey.F6:
                        WorkerContainer.BuyAllHeroes.ChangeRunState();
                        break;*/
                    case ConsoleKey.UpArrow:
                        Intensity = WorkerContainer.AutoClickerThread.UpIntensity();
                        break;
                    case ConsoleKey.DownArrow:
                        Intensity = WorkerContainer.AutoClickerThread.DownIntensity();
                        break;
                    default:
                        break;
                }
                ShowOptions(Intensity);
            }
        }

        private static void ShowOptions(int intensity)
        {
            Console.Clear();
            Console.WriteLine("Opcions:");
            Console.WriteLine("\tF1 - {0} utilitzar habilitats.", GetTextNextStateOption(WorkerContainer.AbilitiesThread.IsRunning()));
            Console.WriteLine("\tF2 - {0} pujar heroi fixe x100.", GetTextNextStateOption(WorkerContainer.UpgradeHeroesThread.IsRunning()));
            Console.WriteLine("\tF3 - {0} clicar als clicables.", GetTextNextStateOption(WorkerContainer.ClickClickablesThread.IsRunning()));
            Console.WriteLine("\tF4 - {0} l'autoclicker. Nivell: {1} (amunt/avall).", GetTextNextStateOption(WorkerContainer.AutoClickerThread.IsRunning()), intensity);
            Console.WriteLine("\tF5 - {0} clicar clicables intel·ligent.", GetTextNextStateOption(WorkerContainer.AutoClickClickablesThread.IsRunning()));
            //Console.WriteLine("\tF6 - {0} comprar automàticament 200 de cada heroi.", GetTextNextStateOption(WorkerContainer.BuyAllHeroes.IsRunning()));
            Console.WriteLine("ESC per sortir");
        }

        private static string GetTextNextStateOption(bool optionState)
        {
            return optionState ? "Desactivar" : "Activar";
        }

    }
}
